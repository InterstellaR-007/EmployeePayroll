

namespace employee_payroll_test
{
    /// <summary>
    /// Payroll Table Model CLass
    /// </summary>
    public class PayrollModel
    {
        public int emp_Id { get; set; }
        public decimal basicPay{ get; set; }
        public decimal deductions { get; set; }

        public decimal taxablePay { get; set; }

        public decimal NetPay { get; set; }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            var employee = obj as PayrollModel;

            if (employee ==null)
            {
                return false;
            }
            return (this.basicPay == employee.basicPay) && (this.deductions == employee.deductions) && (this.taxablePay == employee.taxablePay) && (this.NetPay== employee.NetPay);
        }
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


    }
}
