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
    public partial class EntryForm : Form
    {
        
        public EntryForm()
        {
            InitializeComponent();
            //textBox1.Text = "Blackdiamond";
            //textBox2.Text = "Bookstoredb";
        }

        private void Enter_Click(object sender, EventArgs e)
        {
            TableList f = new TableList();
            f.Show();
            this.Hide();
        }    
    }
}
