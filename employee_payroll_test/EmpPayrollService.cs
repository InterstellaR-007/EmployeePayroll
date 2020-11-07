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
        

        public static string connection = @"Data Source=(localdb)\localdb_2;Initial Catalog=payroll_service;Integrated Security=True";

        SqlConnection sqlConnection = new SqlConnection(connection);

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
            finally
            {
                this.sqlConnection.Close();
            }
        }

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
                    EmployeeModel employee = new EmployeeModel();
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

        public int UpdateEmpSalary(EmployeeModel employee)
        {
            int salary = 0;
            try
            {
                using (sqlConnection)
                {
                    this.sqlConnection.Open();
                    EmployeeModel employee_model = new EmployeeModel();
                    SqlCommand command = new SqlCommand("updateEmployeeSalary", sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id", employee.emp_Id);
                    command.Parameters.AddWithValue("@basicPay", employee.basicPay);
                    command.Parameters.AddWithValue("@deductions", employee.deductions);
                    command.Parameters.AddWithValue("@taxablePay", employee.taxablePay);
                    command.Parameters.AddWithValue("@NetPay", employee.NetPay);

                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employee_model.emp_Id = Convert.ToInt32(dr["emp_ID"]);
                            employee_model.basicPay = Convert.ToDecimal(dr["basicPay"]);
                            employee_model.deductions = Convert.ToDecimal(dr["deductions"]);
                            employee_model.taxablePay = Convert.ToDecimal(dr["taxablePay"]);
                            employee_model.NetPay = Convert.ToDecimal(dr["NetPay"]);

                            Console.WriteLine("{0} {1} {2}", employee_model.emp_Id, employee_model.basicPay, employee_model.NetPay);
                            salary = Convert.ToInt32(employee_model.basicPay);
                        }


                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    dr.Close();
                    this.sqlConnection.Close();

                    //var updated_Salary = command.Parameters["@baiscPay"];
                    //var rows = command.ExecuteScalar();
                    //var id = int.Parse(rows.ToString());
                    


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
            return salary;

        }

        
    }
}
