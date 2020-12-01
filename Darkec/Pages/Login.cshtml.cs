using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Darkec.Pages
{
    public class LoginModel : PageModel
    {
        public int woah = 3;
        public void OnGet()
        {
            Console.WriteLine("skjsdfhjsjhfdj");
        }
    }
}
