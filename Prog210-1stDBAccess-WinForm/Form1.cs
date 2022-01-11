using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Prog210_1stDBAccess_WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // prepare and format the listView
            listView1.BackColor = Color.LightBlue;  // just playing with the listview props and appearance
            listView1.ForeColor = Color.Blue;
            listView1.BorderStyle = BorderStyle.Fixed3D;
            listView1.View = View.Details;  // just like file explorer, there are several view options
            listView1.Columns.Add("CompanyName", 200, HorizontalAlignment.Left);  // these numbers are pixels, not characters
            listView1.Columns.Add("ContactName", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("City", 150, HorizontalAlignment.Left);
            listView1.GridLines = true;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string myCountry = textBox1.Text;
            listView1.Items.Clear();
            List<Customer> formsList = DBaccess.GetData(myCountry);
            for (int i = 0; i < formsList.Count; i++)
            {
                listView1.Items.Add(formsList[i].CompanyName);
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(formsList[i].CompanyName);
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(formsList[i].City);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }




        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

