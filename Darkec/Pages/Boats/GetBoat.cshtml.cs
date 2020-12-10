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
    public class GetBoatModel : PageModel
    {
        [BindProperty]
        public Boat Boat { get; set; }

        private IObjectRepository<int, Boat> repo;

        public GetBoatModel(IObjectRepository<int, Boat> repository)
        {
            repo = repository;
        }
        public IActionResult OnGet(int id)
        {
            Boat = repo.GetObject(id);
            return Page();
        }
        public IActionResult OnPostBook(int id)
        {
            Boat = repo.GetObject(id);
            repo.BookObject(LoginModel.CurrentUser, Boat);
            return Page();
        }
        public IActionResult OnPostCancel(int id)
        {
            Boat = repo.GetObject(id);
            repo.CancelObject(LoginModel.CurrentUser, Boat);
            return Page();
        }
    }
}
