using System;

namespace employee_payroll_test
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeRepo employee = new EmployeeRepo();
            EmployeeModel employeeModel = new EmployeeModel();

            employeeModel.emp_Id = 125;
            employeeModel.basicPay = 3000;
            employeeModel.deductions = 200;
            employeeModel.taxablePay = 300;
            employeeModel.NetPay = 2500;

            //employee.AddEmployee(employeeModel);
            employee.getAllEmployees();
        }
    }
}
