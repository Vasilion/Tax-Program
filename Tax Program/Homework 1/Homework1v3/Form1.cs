using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Homework1v3
{
    /// <summary>
    /// A class for Form1 load and controls
    /// </summary>
    public partial class Form1 : Form
    {
        string empOut;
        string empIn;
        string empError;
        string[] Employees;
        string[] EmployeeInfo;
        int ErrorCount = 0;
        int GoodCount =0;
        int recordCount = 0;
        Employee worker = new Employee();
        

        /// <summary>
        /// Loads the form
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Reads in file, assigns record information into variables, calculates taxes and pays, format and output the record.
        /// </summary>
        public void ReadAndProcess()
        {
            Employees = System.IO.File.ReadAllLines("InPayroll.txt");

            int length = Employees.GetLength(0);

            for (int count = 0; count < length -1; count++)
            {
                EmployeeInfo = Employees[count].Split('|');

                CalculatePayroll EInfo = new CalculatePayroll(worker);
                               

                try
                {

                    if (isValidData())
                    {
                        worker.name = EmployeeInfo[0];
                        worker.hoursWorked = Convert.ToDecimal(EmployeeInfo[1]);
                        worker.payRate = Convert.ToDecimal(EmployeeInfo[2]);
                        worker.YTD = Convert.ToDecimal(EmployeeInfo[3]);
                        worker.SM = EmployeeInfo[4];
                        worker.dependants = Convert.ToInt32(EmployeeInfo[5]);
                        empIn += worker.name + "|" + worker.hoursWorked + "|" + worker.payRate + "|" + worker.SM + "|" + worker.dependants + Environment.NewLine;
                        recordCount++;
                        decimal? grossPay = EInfo.GrossPay(Convert.ToDecimal(worker.hoursWorked), Convert.ToDecimal(worker.payRate));
                        decimal? miTax = EInfo.MichiganStateTax();
                        decimal? fica = ((EInfo.SocialSecurity(Convert.ToDecimal(worker.YTD)) + EInfo.Medicare()));
                        decimal? fw = EInfo.FederalWithholding(worker.dependants,worker.SM);
                        decimal? net = (grossPay - (miTax + fica +fw));
                        string formattedPayRate = String.Format("{0:C}", worker.payRate);
                        string formattedGrossPay = String.Format("{0:C}", grossPay);
                        string formattedMT = String.Format("{0:C}", miTax);
                        string formattedFICA = String.Format("{0:C}", fica);
                        string formattedFW = String.Format("{0:C}", fw);
                        string formattedNetPay = String.Format("{0:C}", net);


                        empOut = worker.name + "|" + worker.hoursWorked + "|" + formattedPayRate + "|" + formattedGrossPay + "|" + formattedMT + "|" + formattedFICA + "|" +  formattedFW + "|" + formattedNetPay;
                        


                        WriteGoodDataToFile();
                        GoodCount++;
                        textBox1.Text += empOut + Environment.NewLine;
                    }
                    else
                    {
                       
                        empIn += EmployeeInfo[0] + "|" + EmployeeInfo[1] + "|" + EmployeeInfo[2] + "|" + EmployeeInfo[3] + "|" + EmployeeInfo[4] + "|" + EmployeeInfo[5] + Environment.NewLine;
                        recordCount++;

                        empError = EmployeeInfo[0] + "|" + EmployeeInfo[1] + "|" + EmployeeInfo[2] + "|" + EmployeeInfo[3] + "|" + EmployeeInfo[4] + "|" + EmployeeInfo[5];

                        WriteBadDataToFile();
                        ErrorCount++;
                    }
                    
                    
                }
                catch (FormatException)
                {
                    
                }
                   
                           
                
                
                
            }


        }

        /// <summary>
        /// Checks the record for valid input
        /// </summary>
        /// <returns>a boolean value, if false concatinates an error message to the field of error.</returns>
        private bool isValidData()
        {
            return Validator.IsPresent(ref EmployeeInfo[0]) &&
                Validator.CheckRange(ref EmployeeInfo[1], 0, 60) &&
                Validator.CheckNegative(ref EmployeeInfo[2]) &&
                Validator.CheckRange(ref EmployeeInfo[5], 0, 20) &&
                Validator.CheckRelationshipStatus(ref EmployeeInfo[4]);
        }


        /// <summary>
        /// Writes data that passes validation to a specfic file.
        /// </summary>
        public void WriteGoodDataToFile()
        {

            System.IO.StreamWriter file = new System.IO.StreamWriter("OutPayrolldaterun.txt",true);
            file.WriteLine(empOut);
            file.Close();

        }
        /// <summary>
        /// Writes data that fails validation to a specific file.
        /// </summary>
        public void WriteBadDataToFile()
        {

            System.IO.StreamWriter file = new System.IO.StreamWriter("OutPayrollErrordaterun.txt",true);          
            file.WriteLine(empError);
            file.Close();

        }




        /// <summary>
        /// Erases files output files in debug and creates fresh data, shows input and output on run in form window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            System.IO.File.Delete(@"OutPayrolldaterun.txt");
            System.IO.File.Delete(@"OutPayrollErrordaterun.txt");
            ReadAndProcess();                    
            textBox2.Text = empIn;
            label2.Text = Convert.ToString(recordCount);
            label5.Text = Convert.ToString(ErrorCount);
            label6.Text = Convert.ToString(GoodCount);
            label6.Visible = true;
            label5.Visible = true;
            label2.Visible = true;

            
            }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    }



            
        

