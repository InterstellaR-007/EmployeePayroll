using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace employee_payroll_test
{
    public class EmployeeRepo
    {
        public List<EmployeeModel> EmployeePayrollData = new List<EmployeeModel>();
        public static string connection = @"Data Source=(localdb)\localdb_2;Initial Catalog=payroll_service;Integrated Security=True";



        /// <summary>
        /// Gets all employees.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void getAllEmployees()
        {
            try
            {
                EmployeeModel employee = new EmployeeModel();
                using (SqlConnection sqlConnection = new SqlConnection(connection))
                {

                    string query = @"Select * from payroll";

                    SqlCommand cmd = new SqlCommand(query,sqlConnection);

                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    

                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            employee.emp_Id = sqlDataReader.GetInt32(0);
                            employee.basicPay = sqlDataReader.GetDecimal(1);
                            employee.deductions = sqlDataReader.GetDecimal(2);
                            employee.taxablePay = sqlDataReader.GetDecimal(3);
                            employee.NetPay = sqlDataReader.GetDecimal(4);

                            Console.WriteLine("{0} {1} {2} {3} \n ", employee.emp_Id, employee.basicPay,employee.taxablePay, employee.NetPay);
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("no data ");
                        
                    }
                    sqlDataReader.Close();
                    sqlConnection.Close();
                    
                }
                
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            
            
        }

        /// <summary>Adds the employee using thread.</summary>
        /// <param name="input_EmployeeList">The input employee list.</param>
        public void AddEmployeeDataToPayrollUsingThread(List<EmployeeModel> input_EmployeeList)
        {
            Parallel.ForEach(input_EmployeeList, employee =>
            {
                AddEmployeePayroll(employee);
            });  

        }
        public void AddEmployeePayroll(EmployeeModel employee)
        {
            string sql = String.Format("Insert into payroll(emp_ID,basicPay,deductions,taxablePay,NetPay)" + "Values( {0},{1},{2},{3},{4})" + " Select * from payroll", employee.emp_Id, employee.basicPay, employee.deductions, employee.taxablePay, employee.NetPay);


            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connection))
                {
                    SqlCommand command = new SqlCommand(sql, sqlConnection);
                    sqlConnection.Open();
                    var rows_Affected = command.ExecuteReader();

                    if (rows_Affected.HasRows)
                    {
                        EmployeeModel added_emp = new EmployeeModel();

                        added_emp.emp_Id = employee.emp_Id;
                        added_emp.basicPay = employee.basicPay;
                        added_emp.deductions = employee.deductions;
                        added_emp.taxablePay = employee.taxablePay;
                        added_emp.NetPay = employee.NetPay;


                        EmployeePayrollData.Add(added_emp);


                    }

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        /// <summary>
        /// Adds the employee.
        /// </summary>
        /// <param name="input_EmployeeList">The input employee list.</param>
        public void AddEmployeeDataToPayroll( List<EmployeeModel> input_EmployeeList)
        {
            foreach (var employee in input_EmployeeList)
            {
                AddEmployeePayroll(employee);

            }

        }
    }
}
