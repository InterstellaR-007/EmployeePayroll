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
            //Arrange
            ///Set service object
            EmpPayrollService update = new EmpPayrollService();

            ///Creating employee object to be updated 
            PayrollModel employee = new PayrollModel() {emp_Id=210, basicPay = 100, deductions = 20, taxablePay = 1000, NetPay = 30000 };

            //Act
            bool EmpSalary = update.UpdateEmpSalary(employee);

            //Assert
            Assert.AreEqual(true, EmpSalary);
            
        }

        [Test]
        public void GivenStartDate_AbletoFindEmployeesBetweenRange()
        {
            //Arrange
            EmpPayrollService update = new EmpPayrollService();
            
            //Act
            bool isExists = update.FindEmpBetweenRange("2013-01-01", "2015-09-09");

            //Assert
            Assert.AreEqual(true,isExists);

        }



        [Test]
        public void GivenEmployeeAndPyarollTable_AddDataToEmployeeAndPayroll_UsingThread()
        {
            //Make sure to change ID of each Employee Data for test to pass to be same and unique, due to Primary Key and Foreign Key Constraint.

            //Arrange

            ///Declaring EmployeeRepo object
            EmployeeRepo repo = new EmployeeRepo();
            
            
            ///List of PreDefined Employee Details To be added to Payroll Table
            List<PayrollModel> employeePayroll_List = new List<PayrollModel>() {

                new PayrollModel { emp_Id = 319, basicPay = 600, deductions = 100, taxablePay = 200, NetPay = 200 },
                new PayrollModel { emp_Id = 321, basicPay = 200, deductions = 100, taxablePay = 200, NetPay = 200 },
                new PayrollModel { emp_Id = 330, basicPay = 700, deductions = 100, taxablePay = 200, NetPay = 200 }
            };

            ///List of Predefined Employee Details to be added to Employee Table
            List<EmployeeTableModel> employeeList = new List<EmployeeTableModel>()
            {
                new EmployeeTableModel{emp_Id=319,name="anuj",salary=600,start_date="2014-01-02",gender='M'},
                new EmployeeTableModel{emp_Id=321,name="juna",salary=600,start_date="2014-06-01",gender='M'},
                new EmployeeTableModel{emp_Id=330,name="abc",salary=800,start_date="2014-03-08",gender='F'}

            };

            //Act
            ///Calling Threaded Method, passing List of each Employees to be added in Database Tables
            repo.AddEmployeeDataToPayrollAndEmployee_PayrollUsingThread(employeePayroll_List, employeeList);
            

            //Assert
            Console.WriteLine(employeeList.Count + " " + repo.EmployeeTableData.Count);
            Assert.AreEqual(employeeList.Count, repo.EmployeeTableData.Count);



        }
    }
}