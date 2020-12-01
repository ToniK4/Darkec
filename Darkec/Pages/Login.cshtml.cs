using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Darkec.Pages
{
    public class LoginModel : PageModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }
    
        public IActionResult OnPost()
        {
            if (Username.Equals("Toni") && Password.Equals("NoBranchesPLS"))
            {

                return RedirectToPage();

            }
            else
            {
                Message = "Invalid";
                return Page();
            }
        }
    }
}
