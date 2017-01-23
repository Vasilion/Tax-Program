using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1v3
{
    /// <summary>
    /// Calculates all taxes and pay
    /// </summary>
    class CalculatePayroll
    {
        decimal? pay = 0;
        decimal? miTax = .0425m;
        decimal? ssTax = .062m;
        decimal? medTax = .0145m;        
        
        /// <summary>
        /// Generic defualt constructor for Employee
        /// </summary>
        /// <param name="myEmployee">A New employee of type Employee is created</param>
        public CalculatePayroll(Employee myEmployee)
        {
            decimal? rate = myEmployee.payRate;
            decimal? hours = myEmployee.hoursWorked;
            decimal? pay = 0;
            int allowances = myEmployee.dependants;
        }


        /// <summary>
        /// calculates the users pay before tax deductions
        /// </summary>
        /// <param name="hours">total hours worked</param>
        /// <param name="rate">amount of money made per hour</param>
        /// <returns>Users Gross Pay</returns>
        public decimal? GrossPay(decimal? hours, decimal? rate)
        {


            if (hours > 40)
            {
                decimal? otRate = rate * 1.5m;
                pay = (hours - 40) * otRate + (40 * rate);
                return pay;

            }

            else
            {
                pay = hours * rate;
                return pay;
            }
        }

        /// <summary>
        /// Calculates Michigan State Tax
        /// </summary>
        /// <returns>Total Michigan state tax withheld</returns>
        public decimal? MichiganStateTax()
        {
            return pay * miTax;
        }

        /// <summary>
        /// Calculates Social Security Tax 
        /// </summary>
        /// <param name="YTD">Year to Date</param>
        /// <returns>Total social security tax withheld</returns>
        public decimal? SocialSecurity(decimal toNow)
        {
            decimal difference = 0;

            if (toNow > 118500m)
            {
                return 0;
            }
            else if (toNow + pay < 118500m)
            {
                return pay * ssTax;
            }
            else if (toNow + pay >= 118500m)
            {
                difference = 118500m - toNow;
                return difference * ssTax;
            }

            return 0;
        }

        /// <summary>
        /// Calculates Medicare Tax
        /// </summary>
        /// <returns>Total medicare tax withheld</returns>
        public decimal? Medicare()
        {
            return pay * medTax;
        }

        /// <summary>
        /// Calculates Federal Witholding Tax
        /// </summary>
        /// <returns>Withholding according to number of depndants and single or married</returns>       

        public decimal? FederalWithholding(int allowances, string rel) ////need to add married calculations and a parameter for single or married
        {
            decimal? AWI = allowances * 67.31m;

            if (rel == "s" || rel == "S")
            {

                if (AWI < 43)
                {
                    return 0;
                }
                else if (AWI > 43 && AWI < 222)
                {
                    return ((AWI - 43m) * .1m);
                }
                else if (AWI > 222 && AWI < 767)
                {
                    return ((AWI - 222m) * .15m) + 17.90m;
                }
                else if (AWI > 767 && AWI < 1796)
                {
                    return ((AWI - 767m) * .25m) + 99.65m;
                }
                else if (AWI > 1796 && AWI < 3700)
                {
                    return ((AWI - 1796m) * .28m) + 356.90m;
                }
                else if (AWI > 3700 && AWI < 7992)
                {
                    return ((AWI - 3700m) * .33m) + 890.02m;
                }
                else if (AWI > 7992 && AWI < 8025)
                {
                    return ((AWI - 7992m) * .35m) + 2306.38m;
                }
                else
                    return ((AWI - 8025m) * .396m) + 2317.93m;
            }

            else if (rel == "m" || rel == "M")
            {
                if (AWI < 164)
                {
                    return 0;
                }
                else if (AWI > 164 && AWI < 521)
                {
                    return ((AWI - 164m) * .1m);
                }
                else if (AWI > 521 && AWI < 1613)
                {
                    return ((AWI - 521m) * .15m) + 35.70m;
                }
                else if (AWI > 1613 && AWI < 3086)
                {
                    return ((AWI - 1613m) * .25m) + 199.50m;
                }
                else if (AWI > 3086 && AWI < 4615)
                {
                    return ((AWI - 3086m) * .28m) + 567.75m;
                }
                else if (AWI > 4615 && AWI < 8113)
                {
                    return ((AWI - 4615m) * .33m) + 995.87m;
                }
                else if (AWI > 8113 && AWI < 9144)
                {
                    return ((AWI - 8113m) * .35m) + 2150.2m;
                }
                else
                    return ((AWI - 9144m) * .396m) + 2511.06m;
              }

            return -1;

        }








        






}
}