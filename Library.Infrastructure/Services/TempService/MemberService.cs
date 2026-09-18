using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace Library.Infrastructure.Services.TempService
{
    public class MemberService : IMemberService
    {
        private readonly LibraryDbContext _dbContext;
        public MemberService(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddMembersAsyc(AllMembersDto members)
        {
            Member member = members.ToMember();
            await _dbContext.Members.AddAsync(member);
            int count = await _dbContext.SaveChangesAsync();
            return count;
        }

        public async Task<int> DeleteMemberAsync(Guid? Id)
        {
            var member = await _dbContext.Members.FirstOrDefaultAsync(x => x.Id == Id);
            if(member != null)
            {
                _dbContext.Members.Remove(member);
                return await _dbContext.SaveChangesAsync();
            }
            return 0;   
        }


        public async Task<int> EditMembersAsync(AllMembersDto allMembers)
        {
            var member = await _dbContext.Members.FirstOrDefaultAsync(x => x.Id == allMembers.Id);
            if(member == null)
            {
                throw new KeyNotFoundException("Book not found.");
            }

            // update  fields
            member.Name = allMembers.Name;
            member.Address = allMembers.Address;
            member.Email = allMembers.Email;
            member.Phone = allMembers.Phone;
            member.Status = allMembers.Status;

            int res = await _dbContext.SaveChangesAsync();
            if(res == 0)
            {
                return 0;
            }
            return res;
        }

        public async Task<List<MemberDropdownDto>> GetAllMembers()
        {
            List<Member> members = await _dbContext.Members.ToListAsync();
            List<MemberDropdownDto> memberDropdown = new List<MemberDropdownDto>();

            foreach (var member in members)
            {
                MemberDropdownDto memb = new MemberDropdownDto
                {
                    Id = member.Id,
                    Name = member.Name
                };
                memberDropdown.Add(memb);
            }

            return memberDropdown;
        }

        public async Task<AllMembersDto> GetMemberByIdAsync(Guid? Id)
        {
            IQueryable<Member> query = _dbContext.Members.AsNoTracking();

            var member = await query.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if(member == null)
            {
                throw new KeyNotFoundException("Member not found.");
            }

            return new AllMembersDto
            {
                Name = member.Name,
                Address = member.Address,
                Email = member.Email,
                Phone = member.Phone,
                Status = member.Status
            };
        }

        public async Task<PaginatedAllMembersDto> ListAllMembersAsync(int page, int pageSize, string searchByName, string searchByStatus)
        {
            IQueryable<Member> query = _dbContext.Members.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(searchByName))
            {
                searchByName = searchByName.Trim();
                query = query.Where(x => x.Name.Contains(searchByName));
            }

            if (!string.IsNullOrWhiteSpace(searchByStatus))
            {
                searchByStatus = searchByStatus.Trim();
                query = query.Where(x => x.Status.Contains(searchByStatus));
            }

            // pagination
            int totalRecords = query.Count();

            // 2 - Calculate total pages
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            // 3 - Get only the requested pages
            query = query
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize);

            var members = await query.Select( m => new AllMembersDto
            {
                Id = m.Id,
                Name = m.Name,
                Email = m.Email,
                Phone = m.Phone,
                Status = m.Status,
                Address = m.Address,
                MemberImage = m.Image.Url.ToString(),

                BookTransactions = m.BookTransactions.Select(x => new AllBookTransactionDto
                {
                    BookTitle = x.Book.Title,
                    IssueDate = x.IssueDate,
                    DueDate = x.DueDate,
                    ReturnDate = x.ReturnDate
                }).ToList()
            }).ToListAsync();

            return new PaginatedAllMembersDto
            {
                Items = members,
                TotalRecords = totalRecords,
                TotalPages = totalPages,
                CurrentPage = page,
            };
        }
    }
}
