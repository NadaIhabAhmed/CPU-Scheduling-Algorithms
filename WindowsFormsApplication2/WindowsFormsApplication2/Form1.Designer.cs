namespace WindowsFormsApplication2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.FCFS = new System.Windows.Forms.RadioButton();
            this.RR = new System.Windows.Forms.RadioButton();
            this.PRIORITY = new System.Windows.Forms.RadioButton();
            this.SJF = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button1.Location = new System.Drawing.Point(167, 294);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "submit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FCFS
            // 
            this.FCFS.AutoSize = true;
            this.FCFS.Location = new System.Drawing.Point(23, 36);
            this.FCFS.Name = "FCFS";
            this.FCFS.Size = new System.Drawing.Size(63, 21);
            this.FCFS.TabIndex = 1;
            this.FCFS.TabStop = true;
            this.FCFS.Text = "FCFS\r\n";
            this.FCFS.UseVisualStyleBackColor = true;
            // 
            // RR
            // 
            this.RR.AutoSize = true;
            this.RR.Location = new System.Drawing.Point(23, 147);
            this.RR.Name = "RR";
            this.RR.Size = new System.Drawing.Size(49, 21);
            this.RR.TabIndex = 2;
            this.RR.TabStop = true;
            this.RR.Text = "RR";
            this.RR.UseVisualStyleBackColor = true;
            // 
            // PRIORITY
            // 
            this.PRIORITY.AutoSize = true;
            this.PRIORITY.Location = new System.Drawing.Point(23, 109);
            this.PRIORITY.Name = "PRIORITY";
            this.PRIORITY.Size = new System.Drawing.Size(93, 21);
            this.PRIORITY.TabIndex = 3;
            this.PRIORITY.TabStop = true;
            this.PRIORITY.Text = "PRIORITY";
            this.PRIORITY.UseVisualStyleBackColor = true;
            this.PRIORITY.CheckedChanged += new System.EventHandler(this.PRIORITY_CheckedChanged);
            // 
            // SJF
            // 
            this.SJF.AutoSize = true;
            this.SJF.Location = new System.Drawing.Point(23, 72);
            this.SJF.Name = "SJF";
            this.SJF.Size = new System.Drawing.Size(53, 21);
            this.SJF.TabIndex = 4;
            this.SJF.TabStop = true;
            this.SJF.Text = "SJF\r\n";
            this.SJF.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(26, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(100, 21);
            this.radioButton1.TabIndex = 6;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Preemptive";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(26, 68);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(129, 21);
            this.radioButton2.TabIndex = 7;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "non-Preemptive\r\n";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SJF);
            this.groupBox1.Controls.Add(this.PRIORITY);
            this.groupBox1.Controls.Add(this.RR);
            this.groupBox1.Controls.Add(this.FCFS);
            this.groupBox1.Location = new System.Drawing.Point(12, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(139, 181);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "mehod";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Location = new System.Drawing.Point(167, 82);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(239, 106);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "option";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 346);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton FCFS;
        private System.Windows.Forms.RadioButton RR;
        private System.Windows.Forms.RadioButton PRIORITY;
        private System.Windows.Forms.RadioButton SJF;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

