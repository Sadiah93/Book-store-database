using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data.SqlClient;

namespace DataLayer
{
    public class BillData
    {
        const string ConnectionString = "Data Source=Blackdiamond;Initial Catalog=Bookstoredb;Integrated Security=True";
        public List<Bill> GetList()
        {
            List<Bill> billList = new List<Bill>();
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand("SELECT * FROM Bill", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Bill Bl = new Bill();
                Bl.BillNo= reader.GetInt32(0);
                Bl.CName = reader.GetString(1);
                Bl.C_ContactNo = reader.GetString(2);
                Bl.TotalBill = reader.GetString(3);
                billList.Add(Bl);
            }
            reader.Close();
            connection.Close();
            return billList;
        }

        
            public bool Insert(Bill BlObj)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand("INSERT INTO Bill (CName, C_ContactNo,TotalBill) VALUES (@CName, @C_ContactNo,@TotalBill)", connection);

            SqlParameter p1 = new SqlParameter("@CName", System.Data.SqlDbType.VarChar, 50);
            p1.Value = BlObj.CName;
            command.Parameters.Add(p1);

            SqlParameter p2 = new SqlParameter("@C_ContactNo", System.Data.SqlDbType.NVarChar,50);
            p2.Value = BlObj.C_ContactNo;
            command.Parameters.Add(p2);

            SqlParameter p3 = new SqlParameter("@TotalBill", System.Data.SqlDbType.NVarChar, 50);
            p3.Value = BlObj.TotalBill;
            command.Parameters.Add(p3);


            connection.Open();
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result > 0;
            
        }

            public bool Delete(int BillNo)
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                SqlCommand command = new SqlCommand("DELETE Bill WHERE BillNo = @BillNo", connection);
                SqlParameter l1 = new SqlParameter("@BillNo", System.Data.SqlDbType.Int);
                l1.Value = BillNo;
                command.Parameters.Add(l1);
                connection.Open();
                int result = command.ExecuteNonQuery();
                connection.Close();
                return result > 0;
            }
            public bool Update(Bill biObj)
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                SqlCommand command = new SqlCommand("UPDATE [dbo].[Bill] SET [CName] = @CName, [C_ContactNo] = @C_ContactNo, [TotalBill] = @TotalBill WHERE [BillNo] = @BillNo", connection);
                SqlParameter b1 = new SqlParameter("@CName", System.Data.SqlDbType.VarChar, 50);
                b1.Value = biObj.CName;
                command.Parameters.Add(b1);
              
                SqlParameter b2 = new SqlParameter("@C_ContactNo", System.Data.SqlDbType.NVarChar,50);
                b2.Value = biObj.C_ContactNo;
                command.Parameters.Add(b2);

                SqlParameter b3 = new SqlParameter("@TotalBill", System.Data.SqlDbType.NVarChar,50);
                b3.Value = biObj.TotalBill;
                command.Parameters.Add(b3);

                SqlParameter b4 = new SqlParameter("@BillNo", System.Data.SqlDbType.Int);
                b4.Value = biObj.BillNo;
                command.Parameters.Add(b4);

                connection.Open();
                int result = command.ExecuteNonQuery();
                connection.Close(); 
                return result > 0;
            }

        }
    }

