using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EntityLayer;

namespace DataLayer
{
    public class BookTableData
    {
        const string ConnectionString = "Data Source=Blackdiamond;Initial Catalog=Bookstoredb;Integrated Security=True";
        public List<Book> GetList()
        {
            List<Book> bookList = new List<Book>();
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand("SELECT * FROM Book", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Book B = new Book();
                B.BookNo = reader.GetInt32(0);
                B.BookName = reader.GetString(1);
                B.Author = reader.GetString(2);
                B.Category = reader.GetString(3);
                B.Price = reader.GetString(4);

                bookList.Add(B);
            }
            reader.Close();
            connection.Close();
            return bookList;
        }
        public bool Insert(Book BkObj)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(
                "INSERT INTO Book (BookName, Author,Category,Price) VALUES (@BookName, @Author,@Category,@Price)", connection);

            SqlParameter p1 = new SqlParameter("@BookName", System.Data.SqlDbType.NVarChar, 70);
            p1.Value = BkObj.BookName;
            command.Parameters.Add(p1);

            SqlParameter p2 = new SqlParameter("@Author", System.Data.SqlDbType.NVarChar, 80);
            p2.Value = BkObj.Author;
            command.Parameters.Add(p2);

            SqlParameter p3 = new SqlParameter("@Category", System.Data.SqlDbType.VarChar, 50);
            p3.Value = BkObj.Category;
            command.Parameters.Add(p3);

            SqlParameter p4 = new SqlParameter("@Price", System.Data.SqlDbType.VarChar, 50);
            p4.Value = BkObj.Price;
            command.Parameters.Add(p4);


            connection.Open();
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result > 0;
        }
        public bool Delete(int BookNo)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand("DELETE Book WHERE BookNo = @BookNo", connection);
            SqlParameter p1 = new SqlParameter("@BookNo", System.Data.SqlDbType.Int);
            p1.Value = BookNo;
            command.Parameters.Add(p1);
            connection.Open();
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result > 0;
        }
        public bool Update(Book bkObj)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand("UPDATE [dbo].[Book] SET [BookName] = @BookName, [Author] = @Author, [Category] = @Category , [Price]= @Price WHERE [BookNo] = @BookNo", connection);
            SqlParameter k1 = new SqlParameter("@BookName", System.Data.SqlDbType.NVarChar, 70);
            k1.Value = bkObj.BookName;
            command.Parameters.Add(k1);

            SqlParameter k2 = new SqlParameter("Author", System.Data.SqlDbType.NVarChar, 80);
            k2.Value = bkObj.Author;
            command.Parameters.Add(k2);

            SqlParameter k3 = new SqlParameter("@Category", System.Data.SqlDbType.NVarChar, 50);
            k3.Value = bkObj.Category;
            command.Parameters.Add(k3);

            SqlParameter k4 = new SqlParameter("@Price", System.Data.SqlDbType.VarChar,50);
            k4.Value = bkObj.Price;
            command.Parameters.Add(k4);

            SqlParameter k5 = new SqlParameter("@BookNo", System.Data.SqlDbType.Int);
            k5.Value = bkObj.BookNo;
            command.Parameters.Add(k5);

            connection.Open();
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result > 0;
        }
    }
}
