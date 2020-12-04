using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Darkec.MockData;
using Darkec.Models;
using Darkec.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Darkec.Pages.Apartments
{
    public class GetAllApartmentsModel : PageModel
    {
        public Dictionary<int, Apartment> Catalog { get; set; }

        private IObjectRepository<int, Apartment> repo;

        public GetAllApartmentsModel(IObjectRepository<int,Apartment> repository)
        {
            repo = repository;
        }

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }
        public Dictionary<int, Apartment> Apartments { get; private set; }

        public IActionResult OnGet()
        {
            Apartments = repo.GetAllObjects();
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Apartments = repo.FilterObjects(FilterCriteria);
            }

            return Page();
        }
    }
}
