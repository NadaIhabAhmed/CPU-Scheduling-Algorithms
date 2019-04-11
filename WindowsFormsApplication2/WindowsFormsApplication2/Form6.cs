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
    public partial class Form6 : Form
    {
        public Form6()
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
            /*-------------------------------------------------------------------------------*/

            int[] bt = new int[no_process]; // copy of burst time 
            int[] at = new int[no_process]; // copy of burst time 
            int[] id = new int[no_process]; // copy of burst time 

            List<int> chart_at = new List<int>();
            List<int> chart_bt = new List<int>();
            List<string> chart_id = new List<string>();
            List<int> wt = new List<int>();

            // Copy the burst time into rt[] 
            for (int i = 0; i < no_process; i++)
            {
                bt[i] = burst_time[i];
                at[i] = arrival_time[i];
                id[i] = Int32.Parse(pid[i]);
            }

            int complete = 0, t = 0, minm = 2000;
            int shortest = 0, shortest_at = 0, finish_time;
            bool check = false;

            // Process until all processes gets 
            // completed 
            while (complete != no_process)
            {

                // Find process with minimum 
                // remaining time among the 
                // processes that arrives till the 
                // current time` 
                for (int j = 0; j < no_process; j++)
                {
                    if ((at[j] <= t) && (bt[j] <= minm) && bt[j] > 0)
                    {
                        minm = bt[j];
                        shortest = id[j];
                        shortest_at = at[j];
                        check = true;
                    }
                }

                if (check == false)
                {
                    t++;
                    continue;
                }

                chart_bt.Add(1);
                chart_at.Add(shortest_at);
                chart_id.Add(shortest.ToString());
          
                // Reduce remaining time by one 
                for (int i = 0; i < no_process; i++)
                {
                    if (id[i] == shortest)
                    {
                        bt[i]--;
                        minm = bt[i];
                        if (bt[i] == 0)
                        {

                            // Increment complete 
                            // complete++;
                            check = false;

                            // Find finish time of current 
                            // process 
                            finish_time = t + 1;

                            // Calculate waiting time 
                            wait[i] = finish_time - burst_time[i] - arrival_time[i];

                            if (wait[i] < 0)
                                wait[i] = 0;
                        }

                    }
                    

                }

                // Update minimum 
                if (minm == 0)
                {
                    minm = 2000;
                    complete++;
                }
                // If a process gets completely 
                // executed 
                // Increment time 
                t++;
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
            float average_wt = 0;
            for (int i = 0; i < no_process; i++)
            {
                average_wt += wait[i];
            }
            textBox5.Text = (average_wt / no_process).ToString();
        }

        // Method to calculate turn around time 
        /* static void findTurnAroundTime(Process []proc, int n, 
                                 int []wt, int []tat) 
         { 
             // calculating turnaround time by adding 
             // bt[i] + wt[i] 
             for (int i = 0; i < n; i++) 
                 tat[i] = proc[i].bt + wt[i]; 
         } */




    }



}
