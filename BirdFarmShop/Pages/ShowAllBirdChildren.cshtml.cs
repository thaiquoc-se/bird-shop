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
    public class ShowAllBirdChildrenModel : PageModel
    {
        private readonly IBirdChildrenService _birdChildrenService;

        public ShowAllBirdChildrenModel(IBirdChildrenService birdChildrenService)
        {
            _birdChildrenService = birdChildrenService;
        }

        public IList<Tblchildrenbird> Tblchildrenbird { get;set; } = default!;

        public void OnGet()
        {
            Tblchildrenbird = _birdChildrenService.GetAllBirdChildren();     
        }
    }
}
