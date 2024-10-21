using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Services.IServices;

namespace BirdFarmShop.Pages.Admin.CommentManagement
{
    public class DeleteModel : PageModel
    {
        private readonly ICommentService _commentService;
        private string isAdmin;

        public DeleteModel(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [BindProperty]
      public TblComment TblComment { get; set; } = default!;

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

            var tblcomment = _commentService.GetAllCommnets().Where(c => c.CommentId == id).FirstOrDefault();

            if (tblcomment == null)
            {
                return NotFound();
            }
            else 
            {
                TblComment = tblcomment;
            }
            return Page();
        }

        public IActionResult OnPost(int? id)
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
            _commentService.Delete(id.Value);
            return RedirectToPage("./Index");
        }
    }
}
