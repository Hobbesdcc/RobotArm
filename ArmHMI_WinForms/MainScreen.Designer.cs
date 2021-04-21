namespace ArmHMI_WinForms
{
	partial class MainScreen
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
			this.bnt_Home_All = new System.Windows.Forms.Button();
			this.bnt_Home_AxisA = new System.Windows.Forms.Button();
			this.bnt_Home_AxisB = new System.Windows.Forms.Button();
			this.bnt_Home_Base = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.OutputText_PortName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.OutputText_BaudRate = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.Bnt_Serial_StartListen = new System.Windows.Forms.Button();
			this.Bnt_Serial_StopListen = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// bnt_Home_All
			// 
			this.bnt_Home_All.Location = new System.Drawing.Point(10, 20);
			this.bnt_Home_All.Name = "bnt_Home_All";
			this.bnt_Home_All.Size = new System.Drawing.Size(150, 50);
			this.bnt_Home_All.TabIndex = 0;
			this.bnt_Home_All.Text = "Home All";
			this.bnt_Home_All.UseVisualStyleBackColor = true;
			this.bnt_Home_All.Click += new System.EventHandler(this.Bnt_Home_All_Click);
			// 
			// bnt_Home_AxisA
			// 
			this.bnt_Home_AxisA.Location = new System.Drawing.Point(10, 76);
			this.bnt_Home_AxisA.Name = "bnt_Home_AxisA";
			this.bnt_Home_AxisA.Size = new System.Drawing.Size(150, 40);
			this.bnt_Home_AxisA.TabIndex = 1;
			this.bnt_Home_AxisA.Text = "Home Axis A";
			this.bnt_Home_AxisA.UseVisualStyleBackColor = true;
			this.bnt_Home_AxisA.Click += new System.EventHandler(this.Bnt_Home_AxisA_Click);
			// 
			// bnt_Home_AxisB
			// 
			this.bnt_Home_AxisB.Location = new System.Drawing.Point(10, 121);
			this.bnt_Home_AxisB.Name = "bnt_Home_AxisB";
			this.bnt_Home_AxisB.Size = new System.Drawing.Size(150, 40);
			this.bnt_Home_AxisB.TabIndex = 2;
			this.bnt_Home_AxisB.Text = "Home Axis B";
			this.bnt_Home_AxisB.UseVisualStyleBackColor = true;
			this.bnt_Home_AxisB.Click += new System.EventHandler(this.Bnt_Home_AxisB_Click);
			// 
			// bnt_Home_Base
			// 
			this.bnt_Home_Base.Location = new System.Drawing.Point(10, 167);
			this.bnt_Home_Base.Name = "bnt_Home_Base";
			this.bnt_Home_Base.Size = new System.Drawing.Size(150, 40);
			this.bnt_Home_Base.TabIndex = 6;
			this.bnt_Home_Base.Text = "Home Base";
			this.bnt_Home_Base.UseVisualStyleBackColor = true;
			this.bnt_Home_Base.Click += new System.EventHandler(this.Bnt_Home_Base_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.bnt_Home_All);
			this.groupBox1.Controls.Add(this.bnt_Home_Base);
			this.groupBox1.Controls.Add(this.bnt_Home_AxisA);
			this.groupBox1.Controls.Add(this.bnt_Home_AxisB);
			this.groupBox1.Location = new System.Drawing.Point(15, 118);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(170, 220);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Homeing";
			// 
			// groupBox2
			// 
			this.groupBox2.Location = new System.Drawing.Point(15, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(170, 100);
			this.groupBox2.TabIndex = 8;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Mode Selection";
			// 
			// groupBox3
			// 
			this.groupBox3.Location = new System.Drawing.Point(257, 12);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(200, 184);
			this.groupBox3.TabIndex = 9;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Manual Move";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.label2);
			this.groupBox4.Controls.Add(this.OutputText_PortName);
			this.groupBox4.Controls.Add(this.label1);
			this.groupBox4.Controls.Add(this.OutputText_BaudRate);
			this.groupBox4.Location = new System.Drawing.Point(644, 12);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(144, 78);
			this.groupBox4.TabIndex = 10;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Connection Info";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 51);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Port:";
			// 
			// OutputText_PortName
			// 
			this.OutputText_PortName.Location = new System.Drawing.Point(77, 48);
			this.OutputText_PortName.Name = "OutputText_PortName";
			this.OutputText_PortName.Size = new System.Drawing.Size(55, 20);
			this.OutputText_PortName.TabIndex = 5;
			this.OutputText_PortName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(61, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Baud Rate:";
			// 
			// OutputText_BaudRate
			// 
			this.OutputText_BaudRate.Location = new System.Drawing.Point(77, 22);
			this.OutputText_BaudRate.Name = "OutputText_BaudRate";
			this.OutputText_BaudRate.Size = new System.Drawing.Size(55, 20);
			this.OutputText_BaudRate.TabIndex = 3;
			this.OutputText_BaudRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(380, 250);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(303, 158);
			this.textBox1.TabIndex = 11;
			this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// Bnt_Serial_StartListen
			// 
			this.Bnt_Serial_StartListen.Location = new System.Drawing.Point(380, 214);
			this.Bnt_Serial_StartListen.Name = "Bnt_Serial_StartListen";
			this.Bnt_Serial_StartListen.Size = new System.Drawing.Size(150, 30);
			this.Bnt_Serial_StartListen.TabIndex = 12;
			this.Bnt_Serial_StartListen.Text = "Start Listening";
			this.Bnt_Serial_StartListen.UseVisualStyleBackColor = true;
			this.Bnt_Serial_StartListen.Click += new System.EventHandler(this.Bnt_Serial_StartListen_Click);
			// 
			// Bnt_Serial_StopListen
			// 
			this.Bnt_Serial_StopListen.Location = new System.Drawing.Point(533, 214);
			this.Bnt_Serial_StopListen.Name = "Bnt_Serial_StopListen";
			this.Bnt_Serial_StopListen.Size = new System.Drawing.Size(150, 30);
			this.Bnt_Serial_StopListen.TabIndex = 13;
			this.Bnt_Serial_StopListen.Text = "Stop Listening";
			this.Bnt_Serial_StopListen.UseVisualStyleBackColor = true;
			this.Bnt_Serial_StopListen.Click += new System.EventHandler(this.Bnt_Serial_StopListen_Click);
			// 
			// MainScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.WindowFrame;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.Bnt_Serial_StopListen);
			this.Controls.Add(this.Bnt_Serial_StartListen);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "MainScreen";
			this.Text = "Robot Arm HMI";
			this.groupBox1.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button bnt_Home_All;
		private System.Windows.Forms.Button bnt_Home_AxisA;
		private System.Windows.Forms.Button bnt_Home_AxisB;
		private System.Windows.Forms.Button bnt_Home_Base;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.TextBox OutputText_BaudRate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox OutputText_PortName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button Bnt_Serial_StartListen;
		private System.Windows.Forms.Button Bnt_Serial_StopListen;
	}
}

