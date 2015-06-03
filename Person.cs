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


        private int m_Age;
        [Range(1, 120, ErrorMessage="Age is wrong")]
        public int Age
        {
            get { return m_Age; }
            set { m_Age = value; }
        }
    }
}
