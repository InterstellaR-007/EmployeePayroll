﻿using employee_payroll;
using System;

namespace employee_payroll_test
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeRepo employee = new EmployeeRepo();
            EmployeeModel employeeModel = new EmployeeModel() {basicPay=1000,deductions=200,taxablePay=100,NetPay=600 };


            EmpPayrollService empPayroll = new EmpPayrollService();
            empPayroll.FindSumAvgMinMax();

            //employee.AddEmployee(employeeModel);
            //UpdateSalary update = new UpdateSalary();
            //update.UpdateEmpSalry(employeeModel);
            
        }
    }
}
