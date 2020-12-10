using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Darkec.Models;
using Darkec.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Darkec.Pages.Trucks
{
    public class CreateTruckModel : PageModel
    {
        [BindProperty]
        public Truck Truck { get; set; }

        private IObjectRepository<int, Truck> repo;

        public CreateTruckModel(IObjectRepository<int, Truck> repository)
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
            repo.AddObject(Truck);
            return RedirectToPage("GetAllTrucks");
        }
    }
}
