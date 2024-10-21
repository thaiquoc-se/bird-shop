using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Services.IServices;

namespace BirdFarmShop.Pages
{
    public class BirdDetailsModel : PageModel
    {
        private readonly IBirdService _birdService;
        private readonly ICommentService _commentService;

        public BirdDetailsModel(IBirdService birdService, ICommentService commentService)
        {
            _birdService = birdService;
            _commentService = commentService;
        }
        [BindProperty]
        public Bird Bird { get; set; } = default!;
        public IList<TblComment> TblComment { get; set; } = default!;
        [BindProperty]
        public TblComment Comment { get; set; } = default!;
        public int UserID { get; private set; }

        public IActionResult OnGet(int? id)
        {

            var bird = _birdService.GetBirdByID(id.Value);
            var comment = _commentService.GetAllCommnets().Where(b => b.Bird.BirdId == id).ToList();
            TblComment = comment;
            if (bird == null)
            {
                return NotFound();
            }
            else 
            {
                Bird = bird;
            }
            return Page();
        }
        public IActionResult OnPostAsync()
        {
            try
            {
                UserID = (int)HttpContext.Session.GetInt32("UserID")!;
            }
            catch
            {
                return RedirectToPage("/Login");
            }
            if (string.IsNullOrEmpty(Comment.Content) || string.IsNullOrEmpty(Comment.Rating.ToString()) || Comment.Rating < 0 || Comment.Rating > 5)
            {
                OnGet(Bird.BirdId);
                return Page();
            }
            var comment = new TblComment()
            {
                UserId = UserID,
                BirdId = Bird.BirdId,
                CommentDate = DateTime.Now,
                Content = Comment.Content,
                Rating = Comment.Rating,
            };
            _commentService.AddNew(comment);

            OnGet(Bird.BirdId);
            return Page();
        }
    }
}
