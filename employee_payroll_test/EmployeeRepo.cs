using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace employee_payroll_test
{
    public class EmployeeRepo
    {
        public List<PayrollModel> EmployeePayrollData = new List<PayrollModel>();
        public List<EmployeeTableModel> EmployeeTableData = new List<EmployeeTableModel>();
        public static string connection = @"Data Source=(localdb)\localdb_2;Initial Catalog=payroll_service;Integrated Security=True";



        

        /// <summary>Adds the employee using thread.</summary>
        /// <param name="input_EmployeeList">The input employee list.</param>
        public void AddEmployeeDataToPayrollAndEmployee_PayrollUsingThread(List<PayrollModel> input_PayrollList,List<EmployeeTableModel> input_EmployeeList)
        {
            foreach(var employee in input_EmployeeList)
            {

                //Task thread1 = new Task(() =>
                //{
                //    AddEmployeeToEmployee_Payroll(employee);
                //});
                //thread1.Start();
                    
               

            }

            Task.WaitAll();
            

            foreach(var employee in input_PayrollList)
            {
                //Task thread2 = new Task(() =>
                //{
                //    AddEmployeeToPayroll(employee);
                //});
                //thread2.Start();
                    
                
            }

            Task.WaitAll();
            
            

        }
        
        

        /// <summary>
        /// Adds the employee.
        /// </summary>
        /// <param name="input_EmployeeList">The input employee list.</param>
        
        

    }
}
