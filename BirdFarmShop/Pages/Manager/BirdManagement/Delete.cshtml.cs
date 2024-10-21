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

namespace BirdFarmShop.Pages.Manager.BirdManagement
{
    public class DeleteModel : PageModel
    {
        private readonly IBirdService _birdService;
        private readonly IUnitOfWork _unitOfWork;
        private string isManager;

        public DeleteModel(IBirdService birdService, IUnitOfWork unitOfWork)
        {
            _birdService = birdService;
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Bird Bird { get; set; } = default!;

        public IActionResult OnGet(int? id)
        {
            try
            {
                isManager = HttpContext.Session.GetString("isManager")!;
                if (isManager != "MN")
                {
                    return NotFound();
                }
                if (isManager == null)
                {
                    return NotFound();
                }
            }
            catch
            {
                NotFound();
            }

            var bird = _birdService.GetBirdByID(id.Value);

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

        public IActionResult OnPost(int? id)
        {
            try
            {
                isManager = HttpContext.Session.GetString("isManager")!;
                if (isManager != "MN")
                {
                    return NotFound();
                }
                if (isManager == null)
                {
                    return NotFound();
                }
            }
            catch
            {
                NotFound();
            }
            var bird = _birdService.GetBirdByID(id.Value);

            if (bird != null)
            {
                bird.BirdStatus = false;
                _unitOfWork.Update(bird);
                _unitOfWork.SaveChanges();
            }
            else
            {
                return BadRequest();
            }

            return RedirectToPage("./Index");
        }
    }
}
