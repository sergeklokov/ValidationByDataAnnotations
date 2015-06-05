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
        static private bool IsClassInstanceValid(object instance, out List<ValidationResult> validationResults)
        {
            var validationContext = new ValidationContext(instance, serviceProvider: null, items: null);
            validationResults = new List<ValidationResult>();
            return Validator.TryValidateObject(instance, validationContext, validationResults, true);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("This solution use data annotation for validation,");
            Console.WriteLine("and convert each validation error into the number,");
            Console.WriteLine("for the cases when actual message will be hidden from customers,");
            Console.WriteLine("but they will be able to call support and tell them error #.");
            Console.WriteLine();

            // ************************  let's check good data first ************************  //

            var person1 = new Person { 
                PersonID = 234,
                FirstName = "Serge", 
                LastName = "Klokov", 
                Age = 105,
                IpAddress = "23.55.09.82",
            };

            var validationResults = new List<ValidationResult>();
            var isValid = IsClassInstanceValid(person1, out validationResults);

            if (isValid)
                Console.WriteLine("is person1 valid = {0}", isValid);

            Console.WriteLine();

            // ************************  now bad data to get validation errors ************************  //

            var person2 = new Person {
                PersonID = -34,
                FirstName = "Amanda",
                IpAddress = "23432432.23.323:3"};

            isValid = IsClassInstanceValid(person2, out validationResults);

            Console.WriteLine("is person2 valid = {0}", isValid);
            Console.WriteLine();

            foreach (var validationResult in validationResults)
            {
                Console.Write("Error # {0:0000} ", StaticConstants.GetErrorNumberByErrorText(validationResult.ErrorMessage));
                Console.WriteLine(validationResult.ErrorMessage);
            }


            Console.ReadKey();
        }
    }
}
