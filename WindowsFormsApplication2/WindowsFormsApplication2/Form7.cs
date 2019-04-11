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
    public partial class Form7 : Form
    {
        public Form7()
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

            int no_process = int.Parse(textBox1.Text);

            int[] arrival_time = new int[no_process];
            int[] burst_time = new int[no_process];
            int[] prioriy = new int[no_process];

            int[] wait = new int[no_process];
            int[] temp = new int[no_process];
            int[] btime = new int[no_process];
            int[] turnaround = new int[no_process];

            string[] pid = (textBox5.Text).Split('\n');
            string[] ARRIVAL = (textBox2.Text).Split('\n');
            string[] BURST = (textBox3.Text).Split('\n');
            string[] PRI = (textBox4.Text).Split('\n');

            for (int i = 0; i < no_process; i++)
            {
                arrival_time[i] = int.Parse(ARRIVAL[i]);
                burst_time[i] = int.Parse(BURST[i]);
                prioriy[i] = int.Parse(PRI[i]);
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
                        swap(ref prioriy[j + 1], ref prioriy[j]);
                    }
                }

            }

                   /*-------------------------------------------------------------------------------*/

            int[] bt = new int[no_process]; // copy of burst time 
            int[] at = new int[no_process]; // copy of arrival time 
            int[] id = new int[no_process]; // copy of id 
            int[] priority_new = new int[no_process]; // copy of prioriy 

            List<int> chart_at = new List<int>();
            List<int> chart_bt = new List<int>();
            List<string> chart_id = new List<string>();
            List<int> wt = new List<int>();
            List<int> tat = new List<int>();
      
        // Copy the burst time into rt[] 
        for (int i = 0; i < no_process; i++)
        {
            bt[i] = burst_time[i];
            at[i] = arrival_time[i];
            id[i] = Int32.Parse(pid[i]);
            priority_new[i] = prioriy[i];
        }
      
        int complete = 0, t = 0, minm = 2000; 
        int shortest = 0, shortest_at = 0, finish_time, bt_prio = 0; 
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
                if ((at[j] <= t) && (priority_new[j] <= minm) && priority_new[j] > 0 && bt[j] >0)  
                { 
                    minm = priority_new[j];
                    shortest = id[j];
                    shortest_at = at[j];
                    bt_prio = bt[j];
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
                    bt_prio = bt[i];
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

                    //minm = priority_new[i];
                }
                } 
            
            
      
            // Update minimum 
            if (bt_prio == 0)
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
        textBox6.Text = (average_wt / no_process).ToString();
         // Method to calculate turn around time 
   
        // calculating turnaround time by adding 
        // bt[i] + wt[i] 

      /*  for (int i = 0; i < no_process; i++) 
         {
            tat.Add(bt[i] + wt[i]); 
         }
            int waiting_time = 0;
        for (int i = 0; i < no_process; i++)
        {
            waiting_time += wt[i];
        }

        textBox5.Text =(waiting_time / no_process).ToString();
  */
    
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
