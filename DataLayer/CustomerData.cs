using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data.SqlClient;

namespace DataLayer
{
    public class CustomerData
    {
        const string ConnectionString = "Data Source=Blackdiamond;Initial Catalog=Bookstoredb;Integrated Security=True";
        public List<Customer> GetList()
        {
            List<Customer> customerlist= new List<Customer>();
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand("SELECT * FROM Customer", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Customer cus = new Customer();
                cus.SerialNo = reader.GetInt32(0);
                cus.CId = reader.GetString(1);
                cus.CName = reader.GetString(2);
                cus.C_Address = reader.GetString(3);
                cus.C_ContactNo = reader.GetString(4);
                cus.BookCopy = reader.GetString(5);

                customerlist.Add(cus);
            }
            reader.Close();
            connection.Close();
            return customerlist;
        }
        public bool Insert(Customer cusObj)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(
                "INSERT INTO Customer (CId, CName,C_Address,C_ContactNo,BookCopy) VALUES (@CId, @CName,@C_Address,@C_ContactNo,@BookCopy)", connection);

            SqlParameter p1 = new SqlParameter("@CId", System.Data.SqlDbType.NVarChar, 50);
            p1.Value = cusObj.CId;
            command.Parameters.Add(p1);

            SqlParameter p2 = new SqlParameter("@CName", System.Data.SqlDbType.NVarChar, 50);
            p2.Value = cusObj.CName;
            command.Parameters.Add(p2);

            SqlParameter p3 = new SqlParameter("@C_Address", System.Data.SqlDbType.VarChar, 50);
            p3.Value = cusObj.C_Address;
            command.Parameters.Add(p3);

            SqlParameter p4 = new SqlParameter("@C_ContactNo", System.Data.SqlDbType.NVarChar, 50);
            p4.Value = cusObj.C_ContactNo;
            command.Parameters.Add(p4);

            SqlParameter p5 = new SqlParameter("@BookCopy", System.Data.SqlDbType.VarChar, 50);
            p5.Value = cusObj.BookCopy;
            command.Parameters.Add(p5);

            connection.Open();
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result > 0;
        }
        public bool Delete(int SerialNo)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand("DELETE Customer WHERE SerialNo = @SerialNo", connection);
            SqlParameter p1 = new SqlParameter("@SerialNo", System.Data.SqlDbType.Int);
            p1.Value = SerialNo;
            command.Parameters.Add(p1);
            connection.Open();
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result > 0;
        }

        public bool Update(Customer cObj)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand("UPDATE [dbo].[Customer] SET [CId] = @CId, [CName] = @CName, [C_Address] = @C_Address, [C_ContactNo]=@C_ContactNo ,[BookCopy]=@BookCopy WHERE [SerialNo] = @SerialNo", connection);
            SqlParameter s1 = new SqlParameter("@CId", System.Data.SqlDbType.NVarChar, 50);
            s1.Value = cObj.CId;
            command.Parameters.Add(s1);

            SqlParameter s2 = new SqlParameter("@CName", System.Data.SqlDbType.NVarChar, 50);
            s2.Value = cObj.CName;
            command.Parameters.Add(s2);

            SqlParameter s3 = new SqlParameter("@C_Address", System.Data.SqlDbType.NVarChar, 50);
            s3.Value = cObj.C_Address;
            command.Parameters.Add(s3);

            SqlParameter s4 = new SqlParameter("@C_ContactNo", System.Data.SqlDbType.NVarChar,50);
            s4.Value = cObj.C_ContactNo;
            command.Parameters.Add(s4);

            SqlParameter s5 = new SqlParameter("@BookCopy", System.Data.SqlDbType.VarChar, 50);
            s5.Value = cObj.BookCopy;
            command.Parameters.Add(s5);
            
            SqlParameter s6 = new SqlParameter("@SerialNo", System.Data.SqlDbType.Int);
            s6.Value = cObj.SerialNo;
            command.Parameters.Add(s6);

            connection.Open();
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result > 0;
        }

       
    }
   }


