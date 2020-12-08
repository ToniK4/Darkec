using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Darkec.Models
{
    public class Truck

    {
        public int Id { get; set; }

        [Required (ErrorMessage = "Truck Registration Number is required")]
        public string RegistrationNumber { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public int CarryingWeight { get; set; }
        public int EngineHorsepower { get; set; }
        public string ImageName { get; set; }

    }
}
