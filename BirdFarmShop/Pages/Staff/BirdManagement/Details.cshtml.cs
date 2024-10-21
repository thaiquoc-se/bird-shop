using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Services.IServices;

namespace BirdFarmShop.Pages.Staff.BirdManagement
{
    public class DetailsModel : PageModel
    {
        private readonly IBirdService _birdService;

        public DetailsModel(IBirdService birdService)
        {
            _birdService = birdService;
        }

      public Bird Bird { get; set; } = default!; 

        public IActionResult OnGet(int? id)
        {

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
    }
}
