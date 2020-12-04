using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Darkec.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Darkec.Pages
{
    public class AdminLoginModel : PageModel
    {
        [BindProperty]
        public Admin Admin { get; set; }

        public void OnGet()
        {

        }
    }
}
