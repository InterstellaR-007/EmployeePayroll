using employee_payroll;
using employee_payroll_test;
using NUnit.Framework;
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
            EmployeeModel employee = new EmployeeModel() {emp_Id=111, basicPay = 100, deductions = 20, taxablePay = 1000, NetPay = 30000 };

            int EmpSalary = update.UpdateEmpSalary(employee);
            Assert.AreEqual(employee.basicPay, EmpSalary);
            
        }

        [Test]
        public void GivenStartDate_AbletoFindEmployeesBetweenRange()
        {

            EmpPayrollService update = new EmpPayrollService();
            EmployeeModel employee = new EmployeeModel() { emp_Id = 111, basicPay = 100, deductions = 20, taxablePay = 1000, NetPay = 30000 };
            bool isExists = update.FindEmpBetweenRange("2013-01-01", "2013-09-09");

            
            Assert.AreEqual(true,isExists);

        }
    }
}