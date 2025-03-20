using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WinFormsApp3.Form1;

namespace WinFormsApp3
{
    public partial class Form2 : Form
    {
        Form1 parent;
        public Form2(Form1 x)
        {
            InitializeComponent();
            parent = x;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GlobalVars.Ad = 1;
            parent.dataGridView1.Rows.Add(new object[] { GlobalVars.imie, GlobalVars.nazwisko, GlobalVars.Wiek, GlobalVars.Stanowisko });
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            GlobalVars.imie = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            GlobalVars.nazwisko = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            GlobalVars.Wiek = textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            GlobalVars.Stanowisko = textBox4.Text;
        }
    }
}
