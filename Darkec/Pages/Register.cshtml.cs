using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Darkec.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Darkec.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public Customer Customer { get; set; }

        public void OnGet()
        {

        }

        public RegisterModel()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            return RedirectToPage("Index");
        }
    }
}
