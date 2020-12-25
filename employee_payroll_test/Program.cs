using employee_payroll;
using System;

namespace employee_payroll_test
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeRepo employee = new EmployeeRepo();
            PayrollModel employeeModel = new PayrollModel() {basicPay=1000,deductions=200,taxablePay=100,NetPay=600 };


            //EmpPayrollService empPayroll = new EmpPayrollService();
            //empPayroll.FindSumAvgMinMax();

            //employee.AddEmployeeUsingThread(100, 10, 200, 10, 1000);

            Console.WriteLine("Welcome to Employee Payroll Management Program based using ADO.NET Connected Framework \n");


            bool exit_Program = false;
            

            while (exit_Program != true)
            {
                EmployeeTableModel employee1;
                PayrollModel payroll;
                EmpPayrollService payrollService = new EmpPayrollService();

                int emp_ID;
                string emp_Name;
                string emp_Salary;
                string emp_StartDate;
                string emp_Gender;
                string emp_BasicPay;
                string emp_Deductions;
                string emp_TaxablePay;
                string emp_NetPay;
                

                Console.WriteLine("Choose among the following operations :");
                Console.WriteLine("1: Add a new Employee Payroll to Payroll Table ");
                Console.WriteLine("2: Add a new Employee to Employee Table ");
                Console.WriteLine("3: Update an existing Employee Payroll Data in Payroll Table ");
                Console.WriteLine("4: Display all the current Employee's Payroll in Payroll Table");
                Console.WriteLine("5: Display all the current Employee's Data in Employee Table ");
                Console.WriteLine("6: Display Sum Avg Min Max Salary grouped by Gender <M,F> ");
                Console.WriteLine("7: Display Employee who joined between Date Range ");
                Console.WriteLine("8: Delete specific Employee Payroll Data from Payroll Table");
                Console.WriteLine("9: Exit Program");


                int input_Option = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (input_Option)
                {
                    case 1:
                        

                        payroll = new PayrollModel();

                        Console.WriteLine("Enter the Employee ID :");
                        payroll.emp_Id = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the Basic Pay");
                        payroll.basicPay = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the Deductions");
                        payroll.deductions = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the Taxable pay");
                        payroll.taxablePay = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the Net Pay");
                        payroll.NetPay = int.Parse(Console.ReadLine());


                        if (payrollService.AddEmployeeToPayrollTable(payroll) == true)
                            Console.WriteLine("Employee Payroll Added ! \n");
                        else
                            Console.WriteLine("Employee Payroll Not Added\n");

                        break;

                    case 2:
                        employee1 = new EmployeeTableModel();

                        Console.WriteLine("Enter the Employee ID :");
                        employee1.emp_Id = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the Name");
                        employee1.name = Console.ReadLine();

                        Console.WriteLine("Enter the Salary");
                        employee1.salary = decimal.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the Start Date <YYYY-MM-DD>");
                        employee1.start_date = Console.ReadLine();

                        Console.WriteLine("Enter the Gender <M/F>");
                        employee1.gender = char.Parse(Console.ReadLine());


                        if (payrollService.AddEmployeeToEmployeeTable(employee1) == true)
                            Console.WriteLine("Employee Data Added ! \n");
                        else
                            Console.WriteLine("Employee Not Added\n");

                        break;

                    case 3:

                        payroll = new PayrollModel();
                        Console.WriteLine("Enter the Employee ID you want to update its details of:");
                        payroll.emp_Id = int.Parse(Console.ReadLine());
                        
                        Console.WriteLine("Enter the Basic Pay");
                        payroll.basicPay = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the Deductions");
                        payroll.deductions = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the Taxable pay");
                        payroll.taxablePay = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the Net Pay");
                        payroll.NetPay = int.Parse(Console.ReadLine());

                        if (payrollService.UpdateEmpSalary(payroll) == true)
                            Console.WriteLine("Updation successful ! \n");
                        else
                            Console.WriteLine("Cannot be updated ! \n");

                        break;


                    case 4:

                        payrollService.getPayrollTableData();

                        break;

                    case 5:

                        payrollService.getEmployeeTableData();

                        break;

                    case 6:

                        payrollService.FindSumAvgMinMax();

                        break;

                    case 7:

                        Console.WriteLine("Enter the first Date <YYYY-MM-DD>");

                        string firstDate = Console.ReadLine();

                        Console.WriteLine("Enter the last Date <YYYY-MM-DD>");

                        string lastDate = Console.ReadLine();

                        payrollService.FindEmpBetweenRange(firstDate, lastDate);

                        break;

                    case 8:

                        Console.WriteLine("Enter the Employee ID you want to delete");

                        emp_ID = int.Parse(Console.ReadLine());

                        if (payrollService.DeleteEmployeeFromPayrollTable(emp_ID) == true)
                            Console.WriteLine("Employee Payroll deleted from Payroll Table! \n");
                        else
                            Console.WriteLine("Deletion Unsuccessful \n");

                        break;

                    case 9:

                        exit_Program = true;
                        break;



                }
            }


        }
    }
}
