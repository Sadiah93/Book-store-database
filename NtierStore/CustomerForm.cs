using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;
using EntityLayer;

namespace NtierStore
{
    public partial class CustomerForm : Form
    {
        bool isNew = true;
        CustomerData csdata = new CustomerData();
        public CustomerForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(CustomerForm_Load);
        }
        void CustomerForm_Load(object sender, EventArgs e)
        {
            List<Customer> cslist = csdata.GetList();
            dataGridView1.DataSource = cslist;
 
        }
       

       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = e.RowIndex;
            object selectedObject = dataGridView1.Rows[selectedIndex].DataBoundItem;
            Customer selectedcustomer = selectedObject as Customer;
            textBox1.Text = selectedcustomer.SerialNo.ToString();
            textBox2.Text = selectedcustomer.CId;
            textBox3.Text = selectedcustomer.CName;
            textBox4.Text = selectedcustomer.C_Address;
            textBox5.Text = selectedcustomer.C_ContactNo;
            textBox6.Text = selectedcustomer.BookCopy;

        }

        private void Insert_Click(object sender, EventArgs e)
        {
            if (isNew)
            {
                Customer cus = new Customer();

                cus.CId = textBox2.Text;
                cus.CName = textBox3.Text;
                cus.C_Address = textBox4.Text;
                cus.C_ContactNo = textBox5.Text;
                cus.BookCopy = textBox6.Text;


                bool isSuccess = csdata.Insert(cus);
                if (isSuccess)
                {
                    dataGridView1.DataSource = csdata.GetList();
                }
                else
                {
                    MessageBox.Show("Sorry! Something went wrong!!!");
                }

            }

        }
        private void Delete_Click(object sender, EventArgs e)
        {

            Customer selectedcus = dataGridView1.SelectedRows[0].DataBoundItem as Customer;
            bool isSuccess = csdata.Delete(selectedcus.SerialNo);
            if (isSuccess)
            {
                dataGridView1.DataSource = csdata.GetList();
            }
            else
            {
                MessageBox.Show("Sorry! Something went wrong!!!");
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            Customer cm1 = new Customer();
            cm1.SerialNo = Convert.ToInt32(textBox1.Text);
            cm1.CId = textBox2.Text;
            cm1.CName = textBox3.Text;
            cm1.C_Address = textBox4.Text;
            cm1.C_ContactNo = textBox5.Text;
            cm1.BookCopy = textBox6.Text;


            bool isSuccess = csdata.Update(cm1);
            if (isSuccess)
            {
                dataGridView1.DataSource = csdata.GetList();
            }
            else
            {
                MessageBox.Show("Sorry! Something went wrong!!!");
            }
        }
       
    }
}
