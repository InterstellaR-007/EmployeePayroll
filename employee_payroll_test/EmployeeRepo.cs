using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace employee_payroll_test
{
    public class EmployeeRepo
    {
        public static string connection = @"Data Source=(localdb)\localdb_2;Initial Catalog=payroll_service;Integrated Security=True";

        SqlConnection sqlConnection = new SqlConnection(connection);

        public void getAllEmployees()
        {
            try
            {
                EmployeeModel employee = new EmployeeModel();
                using (this.sqlConnection)
                {
                    string query = @"Select * from payroll";

                    SqlCommand cmd = new SqlCommand(query,this.sqlConnection);

                    this.sqlConnection.Open();
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
                    this.sqlConnection.Close();
                    
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

        public EmployeeModel AddEmployee( decimal basicPay,decimal deductions,decimal taxablePay,decimal NetPay)
        {
            EmployeeModel employee = null;

            string sql = String.Format("Insert into payroll(basicPay,deductions,taxablePay,NetPay)" + "Values( '%s','%s','%s','%s')", basicPay, deductions, taxablePay, NetPay);


            try
            {
                using (this.sqlConnection)
                {
                    SqlCommand command = new SqlCommand(sql, this.sqlConnection);
                    this.sqlConnection.Open();
                    var rows_Affected = command.ExecuteNonQuery();

                    if (rows_Affected != -1)
                    {
                         var id = command.Parameters["emp_Id"].Value.ToString();
                        employee.emp_Id = int.Parse(id);
                        employee.basicPay = basicPay;
                        employee.deductions = deductions;
                        employee.taxablePay = taxablePay;
                        employee.NetPay = NetPay;

                        
                    }
                    
                }
            }
            catch(SqlException e)
            {
                Console.WriteLine(e.Message);
            }

            this.sqlConnection.Close();
            return employee;
            
            //try
            //{
            //    using (this.sqlConnection)
            //    {

            //        SqlCommand cmd = new SqlCommand("payroll_sp", this.sqlConnection);
            //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("@emp_Id", employee.emp_Id);
            //        cmd.Parameters.AddWithValue("@basicPay", employee.basicPay);
            //        cmd.Parameters.AddWithValue("@deductions", employee.deductions);
            //        cmd.Parameters.AddWithValue("@taxablePay", employee.taxablePay);
            //        cmd.Parameters.AddWithValue("@NetPay", employee.NetPay);

            //        this.sqlConnection.Open();
            //        var result = cmd.ExecuteNonQuery();
            //        this.sqlConnection.Close();
            //        if (result != 0)
            //            return true;
            //        else
            //            return false;
            //    }
                

            //}
            //catch (Exception e)
            //{
            //    throw new Exception(e.Message);
            //}
            //finally
            //{
            //    this.sqlConnection.Close();
            //}
        }
    }
}
