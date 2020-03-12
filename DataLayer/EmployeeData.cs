using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data.SqlClient;

namespace DataLayer
{
    public class EmployeeData
    {
        const string ConnectionString = "Data Source=Blackdiamond;Initial Catalog=Bookstoredb;Integrated Security=True";
        public List<Employee> GetList()
        {
            List<Employee> employeeList = new List<Employee>();
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand("SELECT * FROM Employee", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Employee emp = new Employee();
                emp.EmpNo = reader.GetInt32(0);
                emp.EId = reader.GetString(1);
                emp.EName = reader.GetString(2);
                emp.Joindate = reader.GetString(3);
                emp.Address = reader.GetString(4);
                emp.MobileNo = reader.GetString(5);

                employeeList.Add(emp);
            }
            reader.Close();
            connection.Close();
            return employeeList;
        }
        public bool Insert(Employee empObj)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(
                "INSERT INTO Employee (EId, EName,Joindate,Address,MobileNo) VALUES (@EId, @EName,@Joindate,@Address,@MobileNo)", connection);

            SqlParameter p2 = new SqlParameter("@EId", System.Data.SqlDbType.NVarChar, 50);
            p2.Value = empObj.EId;
            command.Parameters.Add(p2);

            SqlParameter p3 = new SqlParameter("@EName", System.Data.SqlDbType.NVarChar, 50);
            p3.Value = empObj.EName;
            command.Parameters.Add(p3);

            SqlParameter p4 = new SqlParameter("@Joindate", System.Data.SqlDbType.VarChar, 50);
            p4.Value = empObj.Joindate;
            command.Parameters.Add(p4);

            SqlParameter p5 = new SqlParameter("@Address", System.Data.SqlDbType.NVarChar, 50);
            p5.Value = empObj.Address;
            command.Parameters.Add(p5);

            SqlParameter p6 = new SqlParameter("@MobileNo", System.Data.SqlDbType.NVarChar, 50);
            p6.Value = empObj.MobileNo;
            command.Parameters.Add(p6);

            connection.Open();
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result > 0;
        }

        public bool Delete(int EmpNo)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand("DELETE Employee WHERE EmpNo = @EmpNo", connection);
            SqlParameter p1 = new SqlParameter("@EmpNo", System.Data.SqlDbType.Int);
            p1.Value = EmpNo;
            command.Parameters.Add(p1);
            connection.Open();
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result > 0;
        }

        public bool Update(Employee epObj)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand("UPDATE [dbo].[Employee] SET [EId] = @EId, [EName] = @EName, [Joindate] = @Joindate ,[Address] =@Address,[MobileNo]=@MobileNo  WHERE [EmpNo] = @EmpNo", connection);

            SqlParameter m1 = new SqlParameter("@EId", System.Data.SqlDbType.NVarChar, 50);
            m1.Value = epObj.EId;
            command.Parameters.Add(m1);

            SqlParameter m2 = new SqlParameter("@EName", System.Data.SqlDbType.NVarChar, 50);
            m2.Value = epObj.EName;
            command.Parameters.Add(m2);

            SqlParameter m3 = new SqlParameter("@Joindate", System.Data.SqlDbType.VarChar, 50);
            m3.Value = epObj.Joindate;
            command.Parameters.Add(m3);

            SqlParameter m4 = new SqlParameter("@Address", System.Data.SqlDbType.NVarChar,50);
            m4.Value = epObj.Address;
            command.Parameters.Add(m4);

            SqlParameter m5 = new SqlParameter("@MobileNo", System.Data.SqlDbType.NVarChar, 50);
            m5.Value = epObj.MobileNo;
            command.Parameters.Add(m5);

            SqlParameter m6 = new SqlParameter("@EmpNo", System.Data.SqlDbType.Int);
            m6.Value = epObj.EmpNo;
            command.Parameters.Add(m6);

            connection.Open();
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result > 0;
        }
    }
}
