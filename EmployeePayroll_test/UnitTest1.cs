using employee_payroll;
using employee_payroll_test;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EmployeePayroll_test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void GivenSalaryDetails_AbleTOUpdateSalry()
        {

            EmpPayrollService update = new EmpPayrollService();
            PayrollModel employee = new PayrollModel() {emp_Id=111, basicPay = 100, deductions = 20, taxablePay = 1000, NetPay = 30000 };

            int EmpSalary = update.UpdateEmpSalary(employee);
            Assert.AreEqual(employee.basicPay, EmpSalary);
            
        }

        [Test]
        public void GivenStartDate_AbletoFindEmployeesBetweenRange()
        {

            EmpPayrollService update = new EmpPayrollService();
            //EmployeeModel employee = new EmployeeModel() { emp_Id = 111, basicPay = 100, deductions = 20, taxablePay = 1000, NetPay = 30000 };
            bool isExists = update.FindEmpBetweenRange("2013-01-01", "2013-09-09");

            
            Assert.AreEqual(true,isExists);

        }

        [Test]
        public void GivenEmployeePayrollTable_AddEmployeePayrollData()
        {
            EmployeeRepo repo = new EmployeeRepo();
            PayrollModel employee = new PayrollModel() { basicPay = 100, deductions = 20, taxablePay = 1000, NetPay = 30000 };
            System.DateTime startTime = DateTime.Now;

            List<PayrollModel> employee_List = new List<PayrollModel>() {
             new PayrollModel { emp_Id = 101, basicPay = 600, deductions = 100, taxablePay = 200, NetPay = 200 },
             new PayrollModel { emp_Id = 102, basicPay = 200, deductions = 100, taxablePay = 200, NetPay = 200 },
             new PayrollModel { emp_Id = 103, basicPay = 700, deductions = 100, taxablePay = 200, NetPay = 200 }
            };
            
            //repo.AddEmployeeDataToPayrollUsingThread(employee_List);
            //var emp1 = repo.AddEmployeeUsingThread(691,100,20,1000,30000);
            //var emp2 = repo.AddEmployeeUsingThread(659, 100, 20, 1000, 30000);
            //var emp3 = repo.AddEmployeeUsingThread(669, 300, 40, 1000, 30000);
            //var emp4 = repo.AddEmployeeUsingThread(679, 6600, 20, 1000, 30000);

            DateTime endTime = DateTime.Now;
            Console.WriteLine("Time taken : " + (endTime - startTime));
            Assert.AreEqual(employee_List,repo.EmployeePayrollData);


        }


        [Test]
        public void GivenEmployeeAndPyarollTable_AddEmployeeDataToEmployeeAndPayroll()
        {
            EmployeeRepo repo = new EmployeeRepo();
            //PayrollModel employee = new PayrollModel() { basicPay = 100, deductions = 20, taxablePay = 1000, NetPay = 30000 };
            System.DateTime startTime = DateTime.Now;

            List<PayrollModel> employeePayroll_List = new List<PayrollModel>() {
             new PayrollModel { emp_Id = 119, basicPay = 600, deductions = 100, taxablePay = 200, NetPay = 200 },
             new PayrollModel { emp_Id = 121, basicPay = 200, deductions = 100, taxablePay = 200, NetPay = 200 },
             new PayrollModel { emp_Id = 130, basicPay = 700, deductions = 100, taxablePay = 200, NetPay = 200 }
            };
            List<EmployeeTableModel> employeeList = new List<EmployeeTableModel>()
            {
                new EmployeeTableModel{emp_Id=119,name="anuj",salary=600,start_date="2014-01-02",gender='M'},
                new EmployeeTableModel{emp_Id=121,name="juna",salary=600,start_date="2014-06-01",gender='M'},
                new EmployeeTableModel{emp_Id=130,name="abc",salary=800,start_date="2014-03-08",gender='F'}

            };

            //repo.AddEmployeeDataToEmployee_Payroll(employeeList);
            repo.AddEmployeeDataToPayrollAndEmployee_PayrollUsingThread(employeePayroll_List, employeeList);
            //var emp1 = repo.AddEmployeeUsingThread(691,100,20,1000,30000);
            //var emp2 = repo.AddEmployeeUsingThread(659, 100, 20, 1000, 30000);
            //var emp3 = repo.AddEmployeeUsingThread(669, 300, 40, 1000, 30000);
            //var emp4 = repo.AddEmployeeUsingThread(679, 6600, 20, 1000, 30000);

            DateTime endTime = DateTime.Now;
            Console.WriteLine("Time taken : " + (endTime - startTime));
            Assert.AreEqual(employeeList, repo.EmployeeTableData);


        }
    }
}