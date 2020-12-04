using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Darkec.Models
{
    public class Apartment
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "Apartment name is required")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Apartment price is required")]
        [Range(typeof(double), "20", "100", ErrorMessage = "Value for the price should be between 20 and 100 ")]
        public double Price { get; set; }
        public string ImageName { get; set; }

    }
}
