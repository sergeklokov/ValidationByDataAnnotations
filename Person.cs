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
        [Range(1, int.MaxValue, ErrorMessage = "Should be positive")]
        public int PersonID { get; set; }

        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Range(1, 150)]
        public int Age { get; set; }

        [RegularExpression(@"^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$", ErrorMessage = "Dude, IP address is wrong!")]
        public string IpAddress { get; set; }
    }
}
