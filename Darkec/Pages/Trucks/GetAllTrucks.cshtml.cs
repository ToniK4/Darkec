using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Darkec.MockData;
using Darkec.Models;
using Darkec.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Darkec.Pages.Trucks
{
    public class GetAllTrucksModel : PageModel
    {
        private IObjectRepository<int, Truck> repo;

        public GetAllTrucksModel(IObjectRepository<int,Truck> repository)
        {
            repo = repository;
        }

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }
        public Dictionary<int, Truck> Trucks { get; private set; }

        public IActionResult OnGet()
        {
            Trucks = repo.GetAllObjects();
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Trucks = repo.FilterObjects(FilterCriteria);
            }

            return Page();
        }
    }
}
