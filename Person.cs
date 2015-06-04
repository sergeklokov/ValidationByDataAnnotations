using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; // please add .dll for it

namespace ValidationByDataAnnotations
{
    public class Person
    {
        public string Name { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }

        [Range(1, 120, ErrorMessage = "Age is wrong")]
        public int Age { get; set; }

        [RegularExpression(@"^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$", ErrorMessage = "IP address is wrong")]
        public string IpAddress { get; set; }
    }
}
