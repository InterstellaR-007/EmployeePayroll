﻿using employee_payroll;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace employee_payroll_test
{
    public class EmployeeRepo
    {

        public List<PayrollModel> EmployeePayrollData = new List<PayrollModel>();
        public List<EmployeeTableModel> EmployeeTableData = new List<EmployeeTableModel>();
        public static string connection = @"Data Source=(localdb)\localdb_2;Initial Catalog=payroll_service;Integrated Security=True";



        /// <summary>Adds the employee data using thread.</summary>
        /// <param name="input_EmployeeList">The input employee list.</param>
        public void AddEmployeeDataToPayrollAndEmployee_PayrollUsingThread(List<PayrollModel> input_PayrollList,List<EmployeeTableModel> input_EmployeeList)
        {

            EmpPayrollService empPayrollServie = new EmpPayrollService();


            //Invoking AddEmployee Method with argument data Type EmployeeTableModel inside Parallel foreach method
            Parallel.ForEach(input_EmployeeList, (i) =>
            {
                if(empPayrollServie.AddEmployeeToEmployeeTable(i)==true)
                    //Adding Employee to List when Inserted successfully
                    EmployeeTableData.Add(i);

                
            });



            //Invoking AddEmployee Method with argument data Type PayrollTableModel inside Parallel foreach method
            Parallel.ForEach(input_PayrollList, (i) =>
            {
                if(empPayrollServie.AddEmployeeToPayrollTable(i)==true)
                    //Adding Employee to List when Inserted successfully
                    EmployeePayrollData.Add(i);

                
            });


        }


    }
        
      
        
        

}

