using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using DataLayer;


namespace NtierStore
{
    public partial class BookForm : Form
    {
        bool isNew = true;
        BookTableData bdata = new BookTableData();
        
        public BookForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(BookForm_Load);
           
        }
        void BookForm_Load(object sender, EventArgs e)
        {
            List<Book> Blist = bdata.GetList();
            dataGridView1.DataSource = Blist;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = e.RowIndex;
            object selectedObject = dataGridView1.Rows[selectedIndex].DataBoundItem;
            Book selectedbook = selectedObject as Book;
            textBox1.Text = selectedbook.BookNo.ToString();
            textBox2.Text = selectedbook.BookName;
            textBox3.Text = selectedbook.Author;
            textBox4.Text = selectedbook.Category;
            textBox5.Text = selectedbook.Price;
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            if (isNew)
            {
                Book bk = new Book();

                bk.BookName = textBox2.Text;
                bk.Author = textBox3.Text;
                bk.Category = textBox4.Text;
                bk.Price = textBox5.Text;
               
                bool isSuccess = bdata.Insert(bk);
                if (isSuccess)
                {
                    dataGridView1.DataSource = bdata.GetList();
                }
                else
                {
                    MessageBox.Show("Sorry! Something went wrong!!!");
                }

            }

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            Book selectedBook = dataGridView1.SelectedRows[0].DataBoundItem as Book;
            bool isSuccess = bdata.Delete(selectedBook.BookNo);
            if (isSuccess)
            {
                dataGridView1.DataSource = bdata.GetList();
            }
            else
            {
                MessageBox.Show("Sorry! Something went wrong!!!");
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            Book b = new Book();
            b.BookNo = Convert.ToInt32(textBox1.Text);
            b.BookName = textBox2.Text;
            b.Author = textBox3.Text;
            b.Category = textBox4.Text;
            b.Price = textBox5.Text;
          bool isSuccess = bdata.Update(b);
            if (isSuccess)
            {
                dataGridView1.DataSource = bdata.GetList();
            }
            else
            {
                MessageBox.Show("Sorry! Something went wrong!!!");
            }
        }
    }
}
