using System;
using System.Collections.Generic;
using System.Text;

namespace employee_payroll_test
{
    public class EmployeeModel
    {
        public int emp_Id { get; set; }
        public decimal basicPay{ get; set; }
        public decimal deductions { get; set; }

        public decimal taxablePay { get; set; }

        public decimal NetPay { get; set; }

        public override bool Equals(object obj)
        {
            var employee = obj as EmployeeModel;

            if (employee ==null)
            {
                return false;
            }
            return (this.basicPay == employee.basicPay) && (this.deductions == employee.deductions) && (this.taxablePay == employee.taxablePay) && (this.NetPay== employee.NetPay);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


    }
}
