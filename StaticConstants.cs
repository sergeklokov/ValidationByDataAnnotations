using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationByDataAnnotations
{
    public class StaticConstants
    {
        // Dictionary to store standard error codes and text values
        // Later it will be stored in the database table
        public static Dictionary<int, string> OurErrorCodes = new Dictionary<int, string>()
        {
            {0006, "Should be positive"},
            {8101, "Dude, IP address is wrong!"},
            {8103, "The LastName field is required."}
        };

        // it will return 0 for unknown error
        public static int GetErrorNumberByErrorText(string errorText)
        {
            var error = OurErrorCodes.FirstOrDefault(p => p.Value == errorText);

            return error.Key;  
        }
    }
}
