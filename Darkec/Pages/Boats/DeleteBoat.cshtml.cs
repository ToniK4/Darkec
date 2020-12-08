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
    public class DeleteBoatModel : PageModel
    {
        [BindProperty]
        public Boat Boat { get; set; }

        private IObjectRepository<int, Boat> repo;

        public DeleteBoatModel(IObjectRepository<int, Boat> repository)
        {
            repo = repository;
        }
        public IActionResult OnGet(int id)
        {
            Boat = repo.GetObject(id);
            return Page();
        }
        public IActionResult OnPost()
        {
            repo.DeleteObject(Boat);
            return RedirectToPage("GetAllBoats");
        }
    }
}
