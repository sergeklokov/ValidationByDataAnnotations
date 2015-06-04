using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ValidationByDataAnnotations
{
    class Program
    {
        static void Main(string[] args)
        {

            var person = new Person { Name = "Serge", LastName = "Klokov", Age = 55 };
            var validationContext = new ValidationContext(person, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(person, validationContext, validationResults, true);


            if (isValid)
                Console.WriteLine("{0} is valid", person.Name);
            else
                foreach (var validationResult in validationResults)
                    Console.WriteLine("Validation error: {0}", validationResult);

            // **************************************** 

            var person2 = new Person { 
                Name = "Bad", 
                Age = 300,
                IpAddress = "23432432.23.323:3"};

            validationContext = new ValidationContext(person2, serviceProvider: null, items: null);
            validationResults = new List<ValidationResult>();
            isValid = Validator.TryValidateObject(person2, validationContext, validationResults, true);

            if (isValid)
                Console.WriteLine("{0} is valid", person2.Name);
            else
                foreach (var validationResult in validationResults)
                    Console.WriteLine("Validation error: {0}", validationResult);


            Console.ReadKey();
        }
    }
}
