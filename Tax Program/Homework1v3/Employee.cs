using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1v3
{
    /// <summary>
    /// The employee class is intented to store data about an individual employee. 
    /// </summary>
    class Employee
    {
        public string name;
        public decimal? hoursWorked;
        public decimal? payRate;
        public decimal? YTD;
        public string SM;
        public int dependants;

        /// <summary>
        /// default constructor for Employee. 
        /// </summary>
        public Employee()
        {
            name = "";
            hoursWorked = 0;
            payRate = 0;
            YTD = 0;
            SM = "";
            dependants = 0;

        }
    }
}
