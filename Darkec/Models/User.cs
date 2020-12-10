using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Darkec.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [EmailAddress]
        [Required (ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required (ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required (ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [Required (ErrorMessage = "Card Number is required")]
        public string CardNumber { get; set; }
        [Required (ErrorMessage = "Telephone Number is required")]
        public string TelephoneNumber { get; set; }
        public bool IsAdmin { get; set; }
    }
}
