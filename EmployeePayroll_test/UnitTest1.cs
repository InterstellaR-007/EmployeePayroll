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
        public void WhenBasicPayUpdated_WhenQueried_ReturnUpdatedData()
        {
            employee_payroll_test.EmployeeRepo employeeRepo = new employee_payroll_test.EmployeeRepo();
            SqlDataReader sqlData = null;
            sqlData = employeeRepo.getAllEmployees();
            
            
        }
    }
}