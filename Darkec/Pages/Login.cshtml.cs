using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Darkec.Models;
using Darkec.Services;
using Darkec.Services.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;


namespace Darkec.Pages
{
    public class LoginModel : PageModel
    {
        public static User CurrentUser { get; set; }
        [BindProperty] public string Email { get; set; }
        [BindProperty] public string Password { get; set; }

        private IObjectRepository<int, User> repo;
        private UserRepository userRepository = new UserRepository();
        public LoginModel(IObjectRepository<int, User> repository)
        {
            repo = repository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            foreach (var user in repo.GetAllObjects().Values)
            {
                CurrentUser = CheckLogin();
                break;
            }
            if (CurrentUser != null)
            {
                return RedirectToPage("Services");
            }
            return Page();
        }

        private User CheckLogin()
        {
            User validUser = userRepository.CheckedUser(Email, Password);
            return validUser;
        }
    }
}
