using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Services.IServices;

namespace BirdFarmShop.Pages.Admin.BirdChildrenMagement
{
    public class DetailsModel : PageModel
    {
        private readonly IBirdChildrenService _birdCHildrenService;
        private string isAdmin;

        public DetailsModel(IBirdChildrenService birdChildrenService)
        {
            _birdCHildrenService = birdChildrenService;
        }

        public Tblchildrenbird Tblchildrenbird { get; set; } = default!;

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

            var birdChildren = _birdCHildrenService.GetBirdChildrenByID(id.Value);
            if (birdChildren == null)
            {
                return NotFound();
            }
            else
            {
                Tblchildrenbird = birdChildren;
            }
            return Page();
        }
    }
}
