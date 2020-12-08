using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Darkec.MockData;
using Darkec.Models;
using Darkec.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Darkec.Pages.Boats
{
    public class GetAllBoatsModel : PageModel
    {
        private IObjectRepository<int, Boat> repo;

        public GetAllBoatsModel(IObjectRepository<int,Boat> repository)
        {
            repo = repository;
        }

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }
        public Dictionary<int, Boat> Boats { get; private set; }

        public IActionResult OnGet()
        {
            Boats = repo.GetAllObjects();
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Boats = repo.FilterObjects(FilterCriteria);
            }

            return Page();
        }
    }
}
