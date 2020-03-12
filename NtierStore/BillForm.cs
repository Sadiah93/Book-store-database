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
    public partial class BillForm : Form
    {
        bool isNew = true;
        BillData bldata = new BillData();
        public BillForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(BillForm_Load);
        }
        void BillForm_Load(object sender, EventArgs e)
        {
            List<Bill> bllist = bldata.GetList();
            dataGridView1.DataSource = bllist;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = e.RowIndex;
            object selectedObject = dataGridView1.Rows[selectedIndex].DataBoundItem;
            Bill selectedbill = selectedObject as Bill;
            textBox1.Text = selectedbill.BillNo.ToString();
            textBox2.Text = selectedbill.CName;
            textBox3.Text = selectedbill.C_ContactNo;
            textBox4.Text = selectedbill.TotalBill;
            isNew = false;
        }
         private void Insert_Click(object sender, EventArgs e)
        {
            if (isNew)
            {
                Bill bl = new Bill();

                bl.CName = textBox2.Text;
                bl.C_ContactNo = textBox3.Text;
                bl.TotalBill = textBox4.Text;
               


                bool isSuccess = bldata.Insert(bl);
                if (isSuccess)
                {
                    dataGridView1.DataSource = bldata.GetList();
                }
                else
                {
                    MessageBox.Show("Sorry! Something went wrong!!!");
                }

            }
         }

         private void Delete_Click(object sender, EventArgs e)
         {
             Bill selectedBill = dataGridView1.SelectedRows[0].DataBoundItem as Bill;
             bool isSuccess = bldata.Delete(selectedBill.BillNo);
             if (isSuccess)
             {
                 dataGridView1.DataSource = bldata.GetList();
             }
             else
             {
                 MessageBox.Show("Sorry! Something went wrong!!!");
             }
         }
      
        private void Update_Click(object sender, EventArgs e)
        {
            Bill b1 = new Bill();
            b1.BillNo = Convert.ToInt32(textBox1.Text);
            b1.CName = textBox2.Text;
            b1.C_ContactNo = textBox3.Text;
            b1.TotalBill = textBox4.Text;
            
            bool isSuccess = bldata.Update(b1);
            if (isSuccess)
            {
                dataGridView1.DataSource = bldata.GetList();
            }
            else
            {
                MessageBox.Show("Sorry! Something went wrong!!!");
            }
           }
     }
   }

