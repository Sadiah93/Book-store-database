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
    public partial class EmployeeForm : Form
    {
        bool isNew = true;
        EmployeeData empData = new EmployeeData();
        public EmployeeForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(EmployeeForm_Load); 
        }
        void EmployeeForm_Load(object sender, EventArgs e)
        {
            List<Employee> empList = empData.GetList();
            dataGridView1.DataSource = empList;
            
        }

       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = e.RowIndex;
            object selectedObject = dataGridView1.Rows[selectedIndex].DataBoundItem;
            Employee selectedemp = selectedObject as Employee;
            textBox1.Text = selectedemp.EmpNo.ToString();
            textBox2.Text = selectedemp.EId;
            textBox3.Text = selectedemp.EName;
            textBox4.Text = selectedemp.Joindate;
            textBox5.Text = selectedemp.Address;
            textBox6.Text = selectedemp.MobileNo;
        }


        private void Insert_Click(object sender, EventArgs e)
        {
            if (isNew)
            {
                Employee emp = new Employee();
                emp.EId = textBox2.Text;
                emp.EName = textBox3.Text;
                emp.Joindate = textBox4.Text;
                emp.Address = textBox5.Text;
                emp.MobileNo = textBox6.Text;


                bool isSuccess = empData.Insert(emp);
                if (isSuccess)
                {
                    dataGridView1.DataSource = empData.GetList();
                }
                else
                {
                    MessageBox.Show("Sorry! Something went wrong!!!");
                }

            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            Employee selectedemp = dataGridView1.SelectedRows[0].DataBoundItem as Employee;
            bool isSuccess = empData.Delete(selectedemp.EmpNo);
            if (isSuccess)
            {
                dataGridView1.DataSource = empData.GetList();
            }
            else
            {
                MessageBox.Show("Sorry! Something went wrong!!!");
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            Employee e1 = new Employee();
            e1.EmpNo = Convert.ToInt32(textBox1.Text);
            e1.EId = textBox2.Text;
            e1.EName = textBox3.Text;
            e1.Joindate = textBox4.Text;
            e1.Address = textBox5.Text;
            e1.MobileNo = textBox6.Text;


            bool isSuccess = empData.Update(e1);
            if (isSuccess)
            {
                dataGridView1.DataSource = empData.GetList();
            }
            else
            {
                MessageBox.Show("Sorry! Something went wrong!!!");
            }
        }
    }
}
