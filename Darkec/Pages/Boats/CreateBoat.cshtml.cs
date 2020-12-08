using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Darkec.Models;
using Darkec.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Darkec.Pages.Boats
{
    public class CreateBoatModel : PageModel
    {
        [BindProperty]
        public Boat Boat { get; set; }

        private IObjectRepository<int, Boat> repo;

        public CreateBoatModel(IObjectRepository<int, Boat> repository)
        {
            repo = repository;      
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            repo.AddObject(Boat);
            return RedirectToPage("GetAllBoats");
        }
    }
}
