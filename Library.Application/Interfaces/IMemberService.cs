using Library.Application.DTOs;

namespace Library.Application.Interfaces
{
    public interface IMemberService
    {
        Task<PaginatedAllMembersDto> ListAllMembersAsync(int page, int pageSize, string searchByName, string searchByStatus);
        Task<List<MemberDropdownDto>> GetAllMembers();
        Task<int> AddMembersAsyc(AllMembersDto members);
        Task<AllMembersDto> GetMemberByIdAsync(Guid? Id);
        Task<int> DeleteMemberAsync(Guid? Id);
        Task<int> EditMembersAsync(AllMembersDto members);
    }
}
