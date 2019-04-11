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
    public partial class Form5 : Form
    {
        public Form5()
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
            int q = int.Parse(textBox6.Text);

            int[] arrival_time = new int[no_process];
            int[] burst_time = new int[no_process];

            int[] wait = new int[no_process];
            int[] temp = new int[no_process];
            int[] btime = new int[no_process];
            int[] turnaround = new int[no_process];
            int[] p_id= new int[no_process];

            string[] pid = (textBox1.Text).Split('\n');
            string[] ARRIVAL = (textBox3.Text).Split('\n');
            string[] BURST = (textBox2.Text).Split('\n');

            for (int i = 0; i < no_process; i++)
            {
                arrival_time[i] = int.Parse(ARRIVAL[i]);
                burst_time[i] = int.Parse(BURST[i]);
            }

            for (int i = 0; i < no_process; i++)
            {
                p_id[i] = int.Parse(pid[i]);
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

            List<int> chart_at = new List<int>();
            List<int> chart_bt = new List<int>();
            List<int> new_bt = new List<int>();
            List<string> chart_id = new List<string>();

            List<int> at = new List<int>();
            List<int> bt = new List<int>();
            List<string> id = new List<string>();

            List<int> flag = new List<int>();

            for(int i = 0; i < no_process; i++)
            {
                bt.Add(burst_time[i]);
                at.Add(arrival_time[i]);
                id.Add(pid[i]);
            }
            int element = 0;
            while (bt.Count() != 0)
            {
                if (bt[element] <= q)
                {
                    chart_bt.Add(bt[element]);
                    chart_at.Add(at[element]);
                    chart_id.Add(id[element]);
                   
                    flag.Add(1);

                    bt.Remove(bt[element]);
                    at.Remove(at[element]);
                    id.Remove(id[element]);
                    
                    
                }
                else
                {
                    chart_bt.Add(q);
                    chart_at.Add(at[element]);
                    chart_id.Add(id[element]);
                    
                    flag.Add(0);

                    bt.Add(bt[element] - q);
                    at.Add(at[element]);
                    id.Add(id[element]);


                    bt.Remove(bt[element]);
                    at.Remove(at[element]);
                    id.Remove(id[element]);

                }
            }



            int[] chart_p_id = new int[chart_bt.Count()];
            for (int i = 0; i < chart_bt.Count(); i++)
            {
               chart_p_id[i] = int.Parse(chart_id[i]);
            }

           
           /* for (int i = 0; i < chart_bt.Count(); i++ )
            {
                if (chart_bt[i] <= q)
                {
                    flag.Add(chart_p_id[i]);
                }
                else
                {
                    flag.Add(0);
                }
            }*/

            temp[0] = 0; float avgwait = 0;
            for (int i = 1; i < no_process; i++)
            {
                temp[i] = temp[i - 1] + burst_time[i - 1];
              //  wait[i] = temp[i] - arrival_time[i];
                //  turnaround[i] = wait[i] + burst_time[i];
              //  avgwait += wait[i];
            }
            int last = 0;
            for (int i = 0; i < chart_bt.Count(); i++)
            {
              //  if (arrival_time[i] > temp[i])
               
                    this.chart1.Series["Series1"].Points.AddXY(chart_id[i], last, last + chart_bt[i]);
                    last = last + chart_bt[i];
              //  else
                  //  this.chart1.Series["Series1"].Points.AddXY(pid[i], temp[i], temp[i] + chart_at[i]);
            }
            int departure = 0;
            int nn = chart_bt.Count();
            int[] new_b = new int[nn];

            for (int i = 0; i < no_process; i++)
            {
                for (int j = 0; j < nn; j++)
                {
                    if (pid[i] == chart_id[j])
                    {
                        new_b[j] = burst_time[i];
                    }
                }
            }
            

            for (int i = 0; i < chart_bt.Count(); i++)
            {
                departure += chart_bt[i];
                if (flag[i] != 0)
                {
                    int u =  0;
                    u = departure - chart_at[i]- new_b[i];
                    avgwait += u;
                }
            
            }

            textBox5.Text = (avgwait / no_process).ToString();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }


        }
    }

