using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Library.UI.Controllers
{
    public class MembersController : Controller
    {
        private readonly IMemberService _memberService;
        public MembersController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        public async Task<IActionResult> Index(string searchByName, string searchByStatus, int page = 1, int pageSize = 4)
        {
            PaginatedAllMembersDto members = await _memberService.ListAllMembersAsync(page, pageSize, searchByName, searchByStatus);
            ViewBag.SearchByName = searchByName;
            ViewBag.SearchByStatus = searchByStatus;
            ViewBag.PageSize = pageSize;
            return View(members);
        }

        [HttpGet]
        public IActionResult AddMember()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMember(AllMembersDto members)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(e=>e.Errors).Select(em=>em.ErrorMessage).ToList();
                return View(members);
            }
            int result = await _memberService.AddMembersAsyc(members);
            if(result == 0)
            {
                return View(members);
            }
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> DeleteMember(Guid? id)
        {
            if(id != Guid.Empty)
            {
                await _memberService.DeleteMemberAsync(id);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> EditMember(Guid? id)
        {
            if(id != Guid.Empty)
            {
                AllMembersDto members = await _memberService.GetMemberByIdAsync(id);
                return View(members);
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> EditMember(AllMembersDto member)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(er => er.Errors).Select(e => e.ErrorMessage).ToList();
                return View(member);
            }
            int result = await _memberService.EditMembersAsync(member);
            return RedirectToAction("Index");
        }


        public IActionResult MemberById()
        {
            return View();
        }
    }
}
