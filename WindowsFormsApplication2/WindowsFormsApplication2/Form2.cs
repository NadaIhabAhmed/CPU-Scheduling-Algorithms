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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public void swap_str(ref string x, ref string y)
        {
            string t = x;
            x = y;
            y = t;

        }


        public void swap(ref int x, ref int y)
        {
            int t = x;
            x = y;
            y = t;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisY.Interval = 1;
            int no_process = int.Parse(textBox4.Text);

            int[] arrival_time = new int[no_process];
            int[] burst_time = new int[no_process];

            int[] wait = new int[no_process];
            int[] temp = new int[no_process];
            int[] btime = new int[no_process];
            int[] turnaround = new int[no_process];

            string[] pid = (textBox1.Text).Split('\n');
            string[] ARRIVAL = (textBox3.Text).Split('\n');
            string[] BURST = (textBox2.Text).Split('\n');

            for (int i = 0; i < no_process; i++)
            {
                arrival_time[i] = int.Parse(ARRIVAL[i]);
                burst_time[i] = int.Parse(BURST[i]);
            }

            for (int i = 0; i < no_process - 1; i++)
            {
                for (int j = 0; j < no_process - 1 - i; j++)
                {
                    if (arrival_time[j] > arrival_time[j + 1])
                    {
                        swap_str(ref pid[j + 1], ref pid[j]);
                        swap(ref arrival_time[j + 1], ref arrival_time[j]);
                        swap(ref burst_time[j + 1], ref burst_time[j]);
                    }
                }
            }


            

            temp[0] = 0; wait[0] = 0; float avgwait = 0;
            for (int i = 1; i < no_process; i++)
            {
                temp[i] = temp[i - 1] + burst_time[i - 1];
                wait[i] = temp[i] - arrival_time[i];
                //  turnaround[i] = wait[i] + burst_time[i];
                avgwait += wait[i];
            }

            if (avgwait < 0) avgwait = 0;

            this.chart1.Series["Series1"].Points.AddXY(pid[0], arrival_time[0], burst_time[0]);

            for (int i = 1; i < no_process; i++)
            {
                if (arrival_time [i] > temp[i] )
                    this.chart1.Series["Series1"].Points.AddXY(pid[i], arrival_time[i], temp[i] + burst_time[i]);
                else
                    this.chart1.Series["Series1"].Points.AddXY(pid[i], temp[i], temp[i] + burst_time[i]);
            }

            textBox5.Text = (avgwait / no_process).ToString();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
