using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (FCFS.Checked)
            {
                Form2 f2 = new Form2();         //fcfs 
                f2.ShowDialog();  
            }
            if (SJF.Checked && radioButton1.Checked)           // sjf pre  
            {
                Form6 f6 = new Form6();
                f6.ShowDialog();
            }
            if (PRIORITY.Checked && radioButton1.Checked)           // priority - pre
            {
                Form7 f7 = new Form7();
                f7.ShowDialog();
            }
            if (SJF.Checked && radioButton2.Checked)         // sjf
            {
                Form3 f3 = new Form3();
                f3.ShowDialog();
            }

            if (PRIORITY.Checked && radioButton2.Checked )         // priority
            {
                Form4 f4 = new Form4();
                f4.ShowDialog();
            }
            if (RR.Checked)          // round robin
            {
                Form5 f5 = new Form5();
                f5.ShowDialog();
            }
        }

        private void PRIORITY_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}
