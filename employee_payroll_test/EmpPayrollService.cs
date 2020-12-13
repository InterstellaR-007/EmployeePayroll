using employee_payroll_test;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace employee_payroll
{
    public class EmpPayrollService
    {

        public List<PayrollModel> EmployeePayrollData = new List<PayrollModel>();
        public List<EmployeeTableModel> EmployeeTableData = new List<EmployeeTableModel>();
        string payrollTable_FieldTitle = String.Format("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}\n", "ID", "Basic Pay", "Deductions", "Taxable Pay", "Net Pay");
        string employeeTable_FieldTitle = String.Format("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}\n", "ID", "Name", "Salary", "Start Date", "Gender");

        public static string connection = @"Data Source=(localdb)\localdb_2;Initial Catalog=payroll_service;Integrated Security=True";

        SqlConnection sqlConnection = new SqlConnection(connection);


        /// <summary>
        /// Gets all employees.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void getEmployeeTableData()
        {
            try
            {
                EmployeeTableModel employee = new EmployeeTableModel();
                using (sqlConnection)
                {

                    string query = @"Select * from employee_payroll";

                    SqlCommand cmd = new SqlCommand(query, sqlConnection);

                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();


                    if (sqlDataReader.HasRows)
                    {
                        Console.WriteLine(employeeTable_FieldTitle);
                        while (sqlDataReader.Read())
                        {
                            employee.emp_Id = sqlDataReader.GetInt32(0);
                            employee.name = sqlDataReader.GetString(1);
                            employee.salary = sqlDataReader.GetDecimal(2);
                            employee.start_date = sqlDataReader.GetDateTime(3).ToString();
                            employee.gender = sqlDataReader.GetString(4).ToCharArray()[0];

                            Console.WriteLine(String.Format("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}\n", employee.emp_Id, employee.name, employee.salary, employee.start_date, employee.gender));
                        }

                    }
                    else
                    {
                        Console.WriteLine("no data ");

                    }

                    sqlDataReader.Close();
                    

                }

            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }


        }


        public void getPayrollTableData()
        {
            try
            {
                PayrollModel employee = new PayrollModel();
                using (sqlConnection)
                {

                    string query = @"Select * from payroll";

                    SqlCommand cmd = new SqlCommand(query, sqlConnection);

                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();


                    if (sqlDataReader.HasRows)
                    {
                        Console.WriteLine(payrollTable_FieldTitle);
                        while (sqlDataReader.Read())
                        {
                            employee.emp_Id = sqlDataReader.GetInt32(0);
                            employee.basicPay = sqlDataReader.GetDecimal(1);
                            employee.deductions = sqlDataReader.GetDecimal(2);
                            employee.taxablePay = sqlDataReader.GetDecimal(3);
                            employee.NetPay = sqlDataReader.GetDecimal(4);

                            Console.WriteLine(String.Format("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}\n", employee.emp_Id, employee.basicPay, employee.deductions, employee.taxablePay, employee.NetPay));
                        }

                    }
                    else
                    {
                        Console.WriteLine("no data ");

                    }
                    sqlDataReader.Close();
                    

                }

            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }


        }



        /// <summary>
        /// Adds the employee to Payroll Table.
        /// </summary>
        /// <param name="employee">The employee.</param>
        public bool AddEmployeeToPayrollTable(PayrollModel employee)
        {
            string sql = String.Format("Insert into payroll(id,basicPay,deductions,taxablePay,NetPay)" + "Values( {0},{1},{2},{3},{4})" , employee.emp_Id, employee.basicPay, employee.deductions, employee.taxablePay, employee.NetPay);


            try
            {
                using (sqlConnection)
                {
                    SqlCommand command = new SqlCommand(sql, sqlConnection);
                    sqlConnection.Open();
                    int rows_Affected = command.ExecuteNonQuery();

                    if (rows_Affected==1)
                    {
                        return true;


                    }

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }



        /// <summary>
        /// Deletes the employee from payroll table.
        /// </summary>
        /// <param name="emp_ID">The emp identifier.</param>
        /// <returns></returns>
        public bool DeleteEmployeeFromPayrollTable(int emp_ID)
        {
            string sql = String.Format("Delete from payroll where id={0}", emp_ID);


            try
            {
                using (sqlConnection)
                {
                    SqlCommand command = new SqlCommand(sql, sqlConnection);
                    sqlConnection.Open();
                    int rows_Affected = command.ExecuteNonQuery();

                    if (rows_Affected > 0)
                    {
                        return true;


                    }

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }



        /// <summary>
        /// Adds the employee to employee table.
        /// </summary>
        /// <param name="employee">The employee.</param>
        public bool AddEmployeeToEmployeeTable(EmployeeTableModel employee)
        {
            string sql = String.Format("Insert into employee_payroll(id, name, salary, start_date, gender)" + "Values({0},'{1}',{2},'{3}','{4}')" , employee.emp_Id, employee.name, employee.salary, employee.start_date, employee.gender);
            // 

            try
            {
                using (sqlConnection)
                {
                    SqlCommand command = new SqlCommand(sql, sqlConnection);
                    sqlConnection.Open();
                    int rows_Affected = command.ExecuteNonQuery();

                    if (rows_Affected==1)
                    {
                        return true;
                    }
                    


                }
                
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
            
        }


        /// <summary>
        /// Adds the multiple employees to payroll table.
        /// </summary>
        /// <param name="input_EmployeeList">The input employee list.</param>
        public void AddMultipleEmployeesToPayrollTable(List<PayrollModel> input_EmployeeList)
        {
            foreach (var employee in input_EmployeeList)
            {
                AddEmployeeToPayrollTable(employee);

            }

        }


        /// <summary>
        /// Adds the multiple employeesto employee table.
        /// </summary>
        /// <param name="input_EmployeeList">The input employee list.</param>
        public void AddMultipleEmployeestoEmployeeTable(List<EmployeeTableModel> input_EmployeeList)
        {
            foreach (var employee in input_EmployeeList)
            {
                AddEmployeeToEmployeeTable(employee);
            }
        }

        /// <summary>
        /// Finds the sum average minimum maximum of all employees grouped by gender.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void FindSumAvgMinMax()
        {
            string query = @"Select sum(salary),avg(salary),min(salary),max(salary) from employee_payroll group by gender";

            try
            {
                using (this.sqlConnection)
                {
                    SqlCommand sql = new SqlCommand(query, sqlConnection);
                    this.sqlConnection.Open();
                    SqlDataReader sqlData = sql.ExecuteReader();
                    if (sqlData.HasRows)
                    {
                        while (sqlData.Read())
                        {
                            Console.WriteLine(sqlData.GetDecimal(0) + " " + sqlData.GetDecimal(1) + " " + sqlData.GetDecimal(2) + " " + sqlData.GetDecimal(3));

                        }
                    }
                    else
                        Console.WriteLine("no data");

                    sqlData.Close();
                    sqlConnection.Close();
                }
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            
        }

        /// <summary>
        /// Finds the emp between Date Range of joining.
        /// </summary>
        /// <param name="firstRange">The first range.</param>
        /// <param name="lastRange">The last range.</param>
        /// <returns></returns>
        public bool FindEmpBetweenRange(string firstRange, string lastRange)
        {
            bool isExist = false;
            int id = 0;
            string name = "";
            try
            {
                using (sqlConnection)
                {
                    this.sqlConnection.Open();
                    PayrollModel employee = new PayrollModel();
                    SqlCommand command = new SqlCommand("findEmployeesBetweenRange", sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@firstRange", firstRange);
                    command.Parameters.AddWithValue("@lastRange", lastRange);

                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            id  = Convert.ToInt32(dataReader["id"]);
                            name = Convert.ToString(dataReader["name"]);
                            Console.WriteLine(id + " " + name);
                            isExist = true;
                            
                        }
                    }
                    else
                    {
                        Console.WriteLine("No records exist");
                        isExist = false;
                    }
                    dataReader.Close();
                    this.sqlConnection.Close();

                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.sqlConnection.Close();
            }
            return isExist;
        }

        /// <summary>
        /// Updates the fields of Employee in Payroll Table.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns></returns>
        public bool UpdateEmpSalary(PayrollModel employee)
        {
            
            try
            {
                using (sqlConnection)
                {
                    this.sqlConnection.Open();
                    PayrollModel employee_model = new PayrollModel();
                    SqlCommand command = new SqlCommand("updateEmployeeSalary", sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id", employee.emp_Id);
                    command.Parameters.AddWithValue("@basicPay", employee.basicPay);
                    command.Parameters.AddWithValue("@deductions", employee.deductions);
                    command.Parameters.AddWithValue("@taxablePay", employee.taxablePay);
                    command.Parameters.AddWithValue("@NetPay", employee.NetPay);

                    int affected_Rows = command.ExecuteNonQuery();

                    if (affected_Rows==1)
                    {
                        return true;


                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    
                    


                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;

        }

        
    }
}
