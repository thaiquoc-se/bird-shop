using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Services.IServices;
using Services.UnitOfWork;

namespace BirdFarmShop.Pages.Admin.UserManagement
{
    public class DeleteModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;
        public string isAdmin;

        public DeleteModel(IUserService userService, IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
      public TblUser TblUser { get; set; } = default!;

        public IActionResult OnGet(int? id)
        {
            try
            {
                isAdmin = HttpContext.Session.GetString("isAdmin")!;
                if (isAdmin != "AD")
                {
                    return NotFound();
                }
                if (isAdmin == null)
                {
                    return NotFound();
                }
            }
            catch
            {
                NotFound();
            }
            var tbluser = _userService.GetUserByID(id.Value);

            if (tbluser.RoleId == "AD")
            {
                return BadRequest();
            }
            else 
            {
                TblUser = tbluser;
            }
            return Page();
        }

        public IActionResult OnPost(int? id)
        {

            var tbluser = _userService.GetUserByID(id.Value);
            try
            {
                if(tbluser != null)
                {
                     tbluser.UserStatus = false;
                    _unitOfWork.Update(tbluser);
                    _unitOfWork.SaveChanges();
                    return RedirectToPage("./ShowUserList");
                }
                return Page();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
