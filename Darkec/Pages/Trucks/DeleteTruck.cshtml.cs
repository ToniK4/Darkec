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
    public class DeleteTruckModel : PageModel
    {
        [BindProperty]
        public Truck Truck { get; set; }

        private IObjectRepository<int, Truck> repo;

        public DeleteTruckModel(IObjectRepository<int, Truck> repository)
        {
            repo = repository;
        }
        public IActionResult OnGet(int id)
        {
            Truck = repo.GetObject(id);
            return Page();
        }
        public IActionResult OnPost()
        {
            repo.DeleteObject(Truck);
            return RedirectToPage("GetAllTrucks");
        }
    }
}
