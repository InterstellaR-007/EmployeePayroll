using System;
using System.Collections.Generic;
using System.Text;

namespace employee_payroll_test
{
    public class EmployeeTableModel
    {
        public int emp_Id { get; set; }
        public string name{ get; set; }
        public decimal salary { get; set; }

        public string start_date { get; set; }

        public char gender { get; set; }

        public override bool Equals(object obj)
        {
            var employee = obj as EmployeeTableModel;

            if (employee ==null)
            {
                return false;
            }
            return (this.emp_Id == employee.emp_Id) && (this.name == employee.name) && (this.salary == employee.salary) && (this.start_date== employee.start_date);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


    }
}
