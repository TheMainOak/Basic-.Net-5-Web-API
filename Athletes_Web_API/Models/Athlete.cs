using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Athletes_Web_API.Models
{
    public class Athlete
    {
        public int ID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Sport { get; set; } = string.Empty;
        public int Age { get; set; }
    }
}
