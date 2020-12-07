using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Darkec.Models;
using Darkec.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Darkec.Pages.Apartments
{
    public class CreateApartmentModel : PageModel
    {
        [BindProperty]
        public Apartment Apartment { get; set; }

        private IObjectRepository<int, Apartment> repo;

        public CreateApartmentModel(IObjectRepository<int, Apartment> repository)
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
            repo.AddObject(Apartment);
            return RedirectToPage("GetAllApartments");
        }
    }
}
