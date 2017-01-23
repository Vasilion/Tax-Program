using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1v3
{
    /// <summary>
    /// Handles all input checking to be sure data passed in is valid.
    /// </summary>
    class Validator
    {

        /// <summary>
        /// Checks to see if a string is empty.
        /// </summary>
        /// <param name="str">a string that is passed in by ref</param>
        /// <returns>returns a boolean value, if false concatinates an error message to the string</returns>
        public static bool IsPresent(ref string str)
        {
            if (str == "") {
                str += (" name is blank");
                return false;
            }
            else
            {
                return true;
            }
            
        }

        /// <summary>
        /// Converts to a decimal and checks to see if it is in a range
        /// </summary>
        /// <param name="str">a string that is passed in by ref</param>
        /// <returns>returns a boolean value, if false concatinates an error message to string</returns>
        public static bool CheckRange(ref string str, decimal low, decimal high)
        {
            decimal result;
            Decimal.TryParse(str,out result);
            if (result < low || result > high)
            {
                str += " Number is Invalid";
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// Checks a decimal value to see if it is less than zero.
        /// </summary>
        /// <param name="str">a string that is passed in by ref</param>
        /// <returns>returns a boolean value, if false concatinates an error message to string</returns>
        public static bool CheckNegative(ref string str)
        {
            decimal result;
            Decimal.TryParse(str, out result);
            if (result < 0)
            {
                str += "Number is less than zero";
                return false;
            }
            else
                return true;
                

        }

        /// <summary>
        /// Checks the Employee's relationship status for married or single.
        /// </summary>
        /// <param name="str">a string that is passed in by ref</param>
        /// <returns>returns a boolean value, if false concatinates an error message to string</returns>
        public static bool CheckRelationshipStatus(ref string str)
        {
            if (str == "s" || str == "S" || str == "m" || str == "M")
            {
                return true;
            }
            else
            {
                str += " Relationship status must me single(s) or married(m)";
                return false;
            }
        }

       
    }
}
