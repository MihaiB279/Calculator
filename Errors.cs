using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Errors
    {
        public const string factorialError = "The factorial operation of this calculator works only with integers!";
        public const string wrongOperationError = "The operation introduced is wrong!";
        public const string radicalError = "Radical of even order for a negative number is a wrong operation!";
        public const string divisionError = "Division by 0!";
        public const string powError = "0 to the power of 0 is not defined!";
        public const string radicalBoxError = "Please insert a valid order in the box of the radical!";
        public const string paranthesisError = "Wrong distribution of paranthesis!";
        public const string settingsError = "If \"At your choice\" is selected, please insert a number lower than 15 in its text area!";
    }
}
