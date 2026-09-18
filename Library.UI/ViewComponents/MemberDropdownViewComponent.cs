using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.UI.ViewComponents
{
    public class MemberDropdownViewComponent: ViewComponent
    {
        private readonly IMemberService _memberService;
        public MemberDropdownViewComponent(IMemberService memberService)
        {
            _memberService = memberService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<MemberDropdownDto> member =  await _memberService.GetAllMembers();
            return View(member);
        }
    }
}
