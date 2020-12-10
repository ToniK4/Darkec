using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Darkec.Models
{
    public abstract class Rentable
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public bool Available { get; set; }
    }
}
