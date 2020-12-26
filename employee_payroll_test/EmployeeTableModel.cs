namespace employee_payroll_test
{
    /// <summary>
    /// Employee Table Model Class
    /// </summary>
    public class EmployeeTableModel
    {
        public int emp_Id { get; set; }
        public string name{ get; set; }
        public decimal salary { get; set; }

        public string start_date { get; set; }

        public char gender { get; set; }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            var employee = obj as EmployeeTableModel;

            if (employee ==null)
            {
                return false;
            }
            return (this.emp_Id == employee.emp_Id) && (this.name == employee.name) && (this.salary == employee.salary) && (this.start_date== employee.start_date);
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
