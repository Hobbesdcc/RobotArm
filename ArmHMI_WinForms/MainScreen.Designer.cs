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
			this.components = new System.ComponentModel.Container();
			this.bnt_Home_All = new System.Windows.Forms.Button();
			this.bnt_Home_AxisA = new System.Windows.Forms.Button();
			this.bnt_Home_AxisB = new System.Windows.Forms.Button();
			this.bnt_Home_Base = new System.Windows.Forms.Button();
			this.groupBox_ModeSelect = new System.Windows.Forms.GroupBox();
			this.Bnt_GetMode = new System.Windows.Forms.Button();
			this.Bnt_Mode_Manual = new System.Windows.Forms.Button();
			this.textBox_Status_Mode = new System.Windows.Forms.TextBox();
			this.Bnt_Mode_Auto = new System.Windows.Forms.Button();
			this.Bnt_State_Stop = new System.Windows.Forms.Button();
			this.Bnt_State_Start = new System.Windows.Forms.Button();
			this.groupBox_Manual1 = new System.Windows.Forms.GroupBox();
			this.Bnt_AttachServos = new System.Windows.Forms.Button();
			this.Bnt_DetachServos = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.OutputText_PortName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.OutputText_BaudRate = new System.Windows.Forms.TextBox();
			this.Bnt_Serial_StartListen = new System.Windows.Forms.Button();
			this.Bnt_Serial_StopListen = new System.Windows.Forms.Button();
			this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
			this.richTextBox_textReceiver = new System.Windows.Forms.RichTextBox();
			this.label_status = new System.Windows.Forms.Label();
			this.textBox_textSent = new System.Windows.Forms.TextBox();
			this.Bnt_Serial_Send = new System.Windows.Forms.Button();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.textBox_StatusBar = new System.Windows.Forms.TextBox();
			this.Bnt_ClearTextReceiver = new System.Windows.Forms.Button();
			this.groupBox_MahineStates = new System.Windows.Forms.GroupBox();
			this.Bnt_GetState = new System.Windows.Forms.Button();
			this.textBox_Status_State = new System.Windows.Forms.TextBox();
			this.Bnt_State_Reset = new System.Windows.Forms.Button();
			this.groupBox_Manual2 = new System.Windows.Forms.GroupBox();
			this.check_BigSteps = new System.Windows.Forms.CheckBox();
			this.Bnt_IssueZdown = new System.Windows.Forms.Button();
			this.check_IssueOnPress = new System.Windows.Forms.CheckBox();
			this.Bnt_IssueYdown = new System.Windows.Forms.Button();
			this.Bnt_IssueXdown = new System.Windows.Forms.Button();
			this.Bnt_IssueZup = new System.Windows.Forms.Button();
			this.Bnt_IssueYup = new System.Windows.Forms.Button();
			this.Bnt_IssueXup = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox_goto_posZ = new System.Windows.Forms.TextBox();
			this.textBox_goto_posY = new System.Windows.Forms.TextBox();
			this.Bnt_IssueGoToCommand = new System.Windows.Forms.Button();
			this.textBox_goto_posX = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.groupBox_Automatic1 = new System.Windows.Forms.GroupBox();
			this.Bnt_AutoClearScript = new System.Windows.Forms.Button();
			this.richTextBox_Auto = new System.Windows.Forms.RichTextBox();
			this.groupBox_Manual4 = new System.Windows.Forms.GroupBox();
			this.panel_Machinebox = new System.Windows.Forms.Panel();
			this.panel_Manualbox = new System.Windows.Forms.Panel();
			this.label9 = new System.Windows.Forms.Label();
			this.Bnt_Script_TeachPoint = new System.Windows.Forms.Button();
			this.groupBox_Manual3 = new System.Windows.Forms.GroupBox();
			this.Bnt_Script_CloseGrip = new System.Windows.Forms.Button();
			this.Bnt_Script_OpenGrip = new System.Windows.Forms.Button();
			this.Bnt_Script_Delay = new System.Windows.Forms.Button();
			this.panel_Autobox = new System.Windows.Forms.Panel();
			this.label12 = new System.Windows.Forms.Label();
			this.textBox_Script_Delay = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.Bnt_CloseGrip = new System.Windows.Forms.Button();
			this.Bnt_OpenGrip = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.Bnt_Script_Loop = new System.Windows.Forms.Button();
			this.groupBox_ModeSelect.SuspendLayout();
			this.groupBox_Manual1.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox_MahineStates.SuspendLayout();
			this.groupBox_Manual2.SuspendLayout();
			this.groupBox_Manual4.SuspendLayout();
			this.panel_Machinebox.SuspendLayout();
			this.panel_Manualbox.SuspendLayout();
			this.groupBox_Manual3.SuspendLayout();
			this.panel_Autobox.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// bnt_Home_All
			// 
			this.bnt_Home_All.Location = new System.Drawing.Point(6, 22);
			this.bnt_Home_All.Name = "bnt_Home_All";
			this.bnt_Home_All.Size = new System.Drawing.Size(312, 40);
			this.bnt_Home_All.TabIndex = 0;
			this.bnt_Home_All.Text = "Home All";
			this.bnt_Home_All.UseVisualStyleBackColor = true;
			this.bnt_Home_All.Click += new System.EventHandler(this.Bnt_Home_All_Click);
			// 
			// bnt_Home_AxisA
			// 
			this.bnt_Home_AxisA.Location = new System.Drawing.Point(6, 68);
			this.bnt_Home_AxisA.Name = "bnt_Home_AxisA";
			this.bnt_Home_AxisA.Size = new System.Drawing.Size(100, 30);
			this.bnt_Home_AxisA.TabIndex = 1;
			this.bnt_Home_AxisA.Text = "Home Axis A";
			this.bnt_Home_AxisA.UseVisualStyleBackColor = true;
			this.bnt_Home_AxisA.Click += new System.EventHandler(this.Bnt_Home_AxisA_Click);
			// 
			// bnt_Home_AxisB
			// 
			this.bnt_Home_AxisB.Location = new System.Drawing.Point(112, 68);
			this.bnt_Home_AxisB.Name = "bnt_Home_AxisB";
			this.bnt_Home_AxisB.Size = new System.Drawing.Size(100, 30);
			this.bnt_Home_AxisB.TabIndex = 2;
			this.bnt_Home_AxisB.Text = "Home Axis B";
			this.bnt_Home_AxisB.UseVisualStyleBackColor = true;
			this.bnt_Home_AxisB.Click += new System.EventHandler(this.Bnt_Home_AxisB_Click);
			// 
			// bnt_Home_Base
			// 
			this.bnt_Home_Base.Location = new System.Drawing.Point(215, 68);
			this.bnt_Home_Base.Name = "bnt_Home_Base";
			this.bnt_Home_Base.Size = new System.Drawing.Size(100, 30);
			this.bnt_Home_Base.TabIndex = 6;
			this.bnt_Home_Base.Text = "Home Base";
			this.bnt_Home_Base.UseVisualStyleBackColor = true;
			this.bnt_Home_Base.Click += new System.EventHandler(this.Bnt_Home_Base_Click);
			// 
			// groupBox_ModeSelect
			// 
			this.groupBox_ModeSelect.Controls.Add(this.Bnt_GetMode);
			this.groupBox_ModeSelect.Controls.Add(this.Bnt_Mode_Manual);
			this.groupBox_ModeSelect.Controls.Add(this.textBox_Status_Mode);
			this.groupBox_ModeSelect.Controls.Add(this.Bnt_Mode_Auto);
			this.groupBox_ModeSelect.Location = new System.Drawing.Point(12, 610);
			this.groupBox_ModeSelect.Name = "groupBox_ModeSelect";
			this.groupBox_ModeSelect.Size = new System.Drawing.Size(450, 100);
			this.groupBox_ModeSelect.TabIndex = 8;
			this.groupBox_ModeSelect.TabStop = false;
			this.groupBox_ModeSelect.Text = "Mode Selection";
			// 
			// Bnt_GetMode
			// 
			this.Bnt_GetMode.Location = new System.Drawing.Point(6, 18);
			this.Bnt_GetMode.Name = "Bnt_GetMode";
			this.Bnt_GetMode.Size = new System.Drawing.Size(100, 20);
			this.Bnt_GetMode.TabIndex = 19;
			this.Bnt_GetMode.Text = "Get Mode";
			this.Bnt_GetMode.UseVisualStyleBackColor = true;
			this.Bnt_GetMode.Click += new System.EventHandler(this.Bnt_GetMode_Click);
			// 
			// Bnt_Mode_Manual
			// 
			this.Bnt_Mode_Manual.Location = new System.Drawing.Point(7, 46);
			this.Bnt_Mode_Manual.Name = "Bnt_Mode_Manual";
			this.Bnt_Mode_Manual.Size = new System.Drawing.Size(100, 40);
			this.Bnt_Mode_Manual.TabIndex = 18;
			this.Bnt_Mode_Manual.Text = "Manual";
			this.Bnt_Mode_Manual.UseVisualStyleBackColor = true;
			this.Bnt_Mode_Manual.Click += new System.EventHandler(this.Bnt_Mode_Manual_Click);
			// 
			// textBox_Status_Mode
			// 
			this.textBox_Status_Mode.Location = new System.Drawing.Point(112, 19);
			this.textBox_Status_Mode.Name = "textBox_Status_Mode";
			this.textBox_Status_Mode.ReadOnly = true;
			this.textBox_Status_Mode.Size = new System.Drawing.Size(206, 20);
			this.textBox_Status_Mode.TabIndex = 17;
			this.textBox_Status_Mode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Bnt_Mode_Auto
			// 
			this.Bnt_Mode_Auto.Location = new System.Drawing.Point(112, 46);
			this.Bnt_Mode_Auto.Name = "Bnt_Mode_Auto";
			this.Bnt_Mode_Auto.Size = new System.Drawing.Size(100, 40);
			this.Bnt_Mode_Auto.TabIndex = 1;
			this.Bnt_Mode_Auto.Text = "Automatic";
			this.Bnt_Mode_Auto.UseVisualStyleBackColor = true;
			this.Bnt_Mode_Auto.Click += new System.EventHandler(this.Bnt_Mode_Auto_Click);
			// 
			// Bnt_State_Stop
			// 
			this.Bnt_State_Stop.Location = new System.Drawing.Point(112, 47);
			this.Bnt_State_Stop.Name = "Bnt_State_Stop";
			this.Bnt_State_Stop.Size = new System.Drawing.Size(100, 40);
			this.Bnt_State_Stop.TabIndex = 1;
			this.Bnt_State_Stop.Text = "Stop";
			this.Bnt_State_Stop.UseVisualStyleBackColor = true;
			this.Bnt_State_Stop.Click += new System.EventHandler(this.Bnt_State_Stop_Click);
			// 
			// Bnt_State_Start
			// 
			this.Bnt_State_Start.Location = new System.Drawing.Point(6, 47);
			this.Bnt_State_Start.Name = "Bnt_State_Start";
			this.Bnt_State_Start.Size = new System.Drawing.Size(100, 40);
			this.Bnt_State_Start.TabIndex = 0;
			this.Bnt_State_Start.Text = "Start";
			this.Bnt_State_Start.UseVisualStyleBackColor = true;
			this.Bnt_State_Start.Click += new System.EventHandler(this.Bnt_State_Start_Click);
			// 
			// groupBox_Manual1
			// 
			this.groupBox_Manual1.Controls.Add(this.bnt_Home_Base);
			this.groupBox_Manual1.Controls.Add(this.bnt_Home_All);
			this.groupBox_Manual1.Controls.Add(this.bnt_Home_AxisB);
			this.groupBox_Manual1.Controls.Add(this.bnt_Home_AxisA);
			this.groupBox_Manual1.Location = new System.Drawing.Point(468, 68);
			this.groupBox_Manual1.Name = "groupBox_Manual1";
			this.groupBox_Manual1.Size = new System.Drawing.Size(330, 111);
			this.groupBox_Manual1.TabIndex = 9;
			this.groupBox_Manual1.TabStop = false;
			this.groupBox_Manual1.Text = "Manual - Homing";
			// 
			// Bnt_AttachServos
			// 
			this.Bnt_AttachServos.Location = new System.Drawing.Point(12, 55);
			this.Bnt_AttachServos.Name = "Bnt_AttachServos";
			this.Bnt_AttachServos.Size = new System.Drawing.Size(150, 30);
			this.Bnt_AttachServos.TabIndex = 2;
			this.Bnt_AttachServos.Text = "Attach Servos";
			this.Bnt_AttachServos.UseVisualStyleBackColor = true;
			this.Bnt_AttachServos.Click += new System.EventHandler(this.Bnt_AttachServos_Click);
			// 
			// Bnt_DetachServos
			// 
			this.Bnt_DetachServos.Location = new System.Drawing.Point(168, 55);
			this.Bnt_DetachServos.Name = "Bnt_DetachServos";
			this.Bnt_DetachServos.Size = new System.Drawing.Size(150, 30);
			this.Bnt_DetachServos.TabIndex = 2;
			this.Bnt_DetachServos.Text = "Detach Servos";
			this.Bnt_DetachServos.UseVisualStyleBackColor = true;
			this.Bnt_DetachServos.Click += new System.EventHandler(this.Bnt_DetachServos_Click);
			// 
			// groupBox4
			// 
			this.groupBox4.BackColor = System.Drawing.SystemColors.ControlDark;
			this.groupBox4.Controls.Add(this.label2);
			this.groupBox4.Controls.Add(this.OutputText_PortName);
			this.groupBox4.Controls.Add(this.label1);
			this.groupBox4.Controls.Add(this.OutputText_BaudRate);
			this.groupBox4.Location = new System.Drawing.Point(300, 13);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(144, 74);
			this.groupBox4.TabIndex = 10;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Connection Info";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Port:";
			// 
			// OutputText_PortName
			// 
			this.OutputText_PortName.Location = new System.Drawing.Point(69, 45);
			this.OutputText_PortName.Name = "OutputText_PortName";
			this.OutputText_PortName.ReadOnly = true;
			this.OutputText_PortName.Size = new System.Drawing.Size(69, 20);
			this.OutputText_PortName.TabIndex = 5;
			this.OutputText_PortName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(61, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Baud Rate:";
			// 
			// OutputText_BaudRate
			// 
			this.OutputText_BaudRate.Location = new System.Drawing.Point(69, 19);
			this.OutputText_BaudRate.Name = "OutputText_BaudRate";
			this.OutputText_BaudRate.ReadOnly = true;
			this.OutputText_BaudRate.Size = new System.Drawing.Size(69, 20);
			this.OutputText_BaudRate.TabIndex = 3;
			this.OutputText_BaudRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// Bnt_Serial_StartListen
			// 
			this.Bnt_Serial_StartListen.Location = new System.Drawing.Point(6, 19);
			this.Bnt_Serial_StartListen.Name = "Bnt_Serial_StartListen";
			this.Bnt_Serial_StartListen.Size = new System.Drawing.Size(150, 30);
			this.Bnt_Serial_StartListen.TabIndex = 12;
			this.Bnt_Serial_StartListen.Text = "Connect";
			this.Bnt_Serial_StartListen.UseVisualStyleBackColor = true;
			this.Bnt_Serial_StartListen.Click += new System.EventHandler(this.Bnt_Serial_Connect_Click);
			// 
			// Bnt_Serial_StopListen
			// 
			this.Bnt_Serial_StopListen.Location = new System.Drawing.Point(6, 55);
			this.Bnt_Serial_StopListen.Name = "Bnt_Serial_StopListen";
			this.Bnt_Serial_StopListen.Size = new System.Drawing.Size(150, 30);
			this.Bnt_Serial_StopListen.TabIndex = 13;
			this.Bnt_Serial_StopListen.Text = "Disconnect";
			this.Bnt_Serial_StopListen.UseVisualStyleBackColor = true;
			this.Bnt_Serial_StopListen.Click += new System.EventHandler(this.Bnt_Serial_Disconnect_Click);
			// 
			// serialPort1
			// 
			this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
			// 
			// richTextBox_textReceiver
			// 
			this.richTextBox_textReceiver.Location = new System.Drawing.Point(6, 124);
			this.richTextBox_textReceiver.Name = "richTextBox_textReceiver";
			this.richTextBox_textReceiver.ReadOnly = true;
			this.richTextBox_textReceiver.Size = new System.Drawing.Size(438, 266);
			this.richTextBox_textReceiver.TabIndex = 14;
			this.richTextBox_textReceiver.Text = "";
			this.richTextBox_textReceiver.TextChanged += new System.EventHandler(this.richTextBox_textReceiver_TextChanged);
			// 
			// label_status
			// 
			this.label_status.BackColor = System.Drawing.SystemColors.ControlDark;
			this.label_status.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.label_status.Location = new System.Drawing.Point(162, 19);
			this.label_status.Name = "label_status";
			this.label_status.Size = new System.Drawing.Size(132, 62);
			this.label_status.TabIndex = 15;
			this.label_status.Text = "DISCONNECTED";
			this.label_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textBox_textSent
			// 
			this.textBox_textSent.Location = new System.Drawing.Point(6, 95);
			this.textBox_textSent.Name = "textBox_textSent";
			this.textBox_textSent.Size = new System.Drawing.Size(361, 20);
			this.textBox_textSent.TabIndex = 16;
			// 
			// Bnt_Serial_Send
			// 
			this.Bnt_Serial_Send.Location = new System.Drawing.Point(369, 93);
			this.Bnt_Serial_Send.Name = "Bnt_Serial_Send";
			this.Bnt_Serial_Send.Size = new System.Drawing.Size(75, 25);
			this.Bnt_Serial_Send.TabIndex = 17;
			this.Bnt_Serial_Send.Text = "Send";
			this.Bnt_Serial_Send.UseVisualStyleBackColor = true;
			this.Bnt_Serial_Send.Click += new System.EventHandler(this.Bnt_Serial_Send_Click);
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.textBox_StatusBar);
			this.groupBox5.Controls.Add(this.Bnt_ClearTextReceiver);
			this.groupBox5.Controls.Add(this.textBox_textSent);
			this.groupBox5.Controls.Add(this.groupBox4);
			this.groupBox5.Controls.Add(this.Bnt_Serial_Send);
			this.groupBox5.Controls.Add(this.Bnt_Serial_StartListen);
			this.groupBox5.Controls.Add(this.Bnt_Serial_StopListen);
			this.groupBox5.Controls.Add(this.label_status);
			this.groupBox5.Controls.Add(this.richTextBox_textReceiver);
			this.groupBox5.Location = new System.Drawing.Point(12, 68);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(450, 430);
			this.groupBox5.TabIndex = 18;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Serial Listener";
			// 
			// textBox_StatusBar
			// 
			this.textBox_StatusBar.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.textBox_StatusBar.Location = new System.Drawing.Point(6, 395);
			this.textBox_StatusBar.Name = "textBox_StatusBar";
			this.textBox_StatusBar.ReadOnly = true;
			this.textBox_StatusBar.Size = new System.Drawing.Size(361, 20);
			this.textBox_StatusBar.TabIndex = 19;
			this.textBox_StatusBar.Text = "DISCONNECTED";
			// 
			// Bnt_ClearTextReceiver
			// 
			this.Bnt_ClearTextReceiver.Location = new System.Drawing.Point(369, 393);
			this.Bnt_ClearTextReceiver.Name = "Bnt_ClearTextReceiver";
			this.Bnt_ClearTextReceiver.Size = new System.Drawing.Size(75, 25);
			this.Bnt_ClearTextReceiver.TabIndex = 18;
			this.Bnt_ClearTextReceiver.Text = "Clear";
			this.Bnt_ClearTextReceiver.UseVisualStyleBackColor = true;
			this.Bnt_ClearTextReceiver.Click += new System.EventHandler(this.Bnt_ClearTextReceiver_Click);
			// 
			// groupBox_MahineStates
			// 
			this.groupBox_MahineStates.Controls.Add(this.Bnt_GetState);
			this.groupBox_MahineStates.Controls.Add(this.textBox_Status_State);
			this.groupBox_MahineStates.Controls.Add(this.Bnt_State_Reset);
			this.groupBox_MahineStates.Controls.Add(this.Bnt_State_Stop);
			this.groupBox_MahineStates.Controls.Add(this.Bnt_State_Start);
			this.groupBox_MahineStates.Location = new System.Drawing.Point(12, 504);
			this.groupBox_MahineStates.Name = "groupBox_MahineStates";
			this.groupBox_MahineStates.Size = new System.Drawing.Size(450, 100);
			this.groupBox_MahineStates.TabIndex = 9;
			this.groupBox_MahineStates.TabStop = false;
			this.groupBox_MahineStates.Text = "Machine State";
			// 
			// Bnt_GetState
			// 
			this.Bnt_GetState.Location = new System.Drawing.Point(6, 21);
			this.Bnt_GetState.Name = "Bnt_GetState";
			this.Bnt_GetState.Size = new System.Drawing.Size(100, 20);
			this.Bnt_GetState.TabIndex = 19;
			this.Bnt_GetState.Text = "Get State";
			this.Bnt_GetState.UseVisualStyleBackColor = true;
			this.Bnt_GetState.Click += new System.EventHandler(this.Bnt_GetState_Click);
			// 
			// textBox_Status_State
			// 
			this.textBox_Status_State.Location = new System.Drawing.Point(112, 21);
			this.textBox_Status_State.Name = "textBox_Status_State";
			this.textBox_Status_State.ReadOnly = true;
			this.textBox_Status_State.Size = new System.Drawing.Size(206, 20);
			this.textBox_Status_State.TabIndex = 16;
			this.textBox_Status_State.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Bnt_State_Reset
			// 
			this.Bnt_State_Reset.Location = new System.Drawing.Point(218, 47);
			this.Bnt_State_Reset.Name = "Bnt_State_Reset";
			this.Bnt_State_Reset.Size = new System.Drawing.Size(100, 40);
			this.Bnt_State_Reset.TabIndex = 1;
			this.Bnt_State_Reset.Text = "Reset";
			this.Bnt_State_Reset.UseVisualStyleBackColor = true;
			this.Bnt_State_Reset.Click += new System.EventHandler(this.Bnt_State_Reset_Click);
			// 
			// groupBox_Manual2
			// 
			this.groupBox_Manual2.Controls.Add(this.check_BigSteps);
			this.groupBox_Manual2.Controls.Add(this.Bnt_IssueZdown);
			this.groupBox_Manual2.Controls.Add(this.check_IssueOnPress);
			this.groupBox_Manual2.Controls.Add(this.Bnt_IssueYdown);
			this.groupBox_Manual2.Controls.Add(this.Bnt_IssueXdown);
			this.groupBox_Manual2.Controls.Add(this.Bnt_IssueZup);
			this.groupBox_Manual2.Controls.Add(this.Bnt_IssueYup);
			this.groupBox_Manual2.Controls.Add(this.Bnt_IssueXup);
			this.groupBox_Manual2.Controls.Add(this.label5);
			this.groupBox_Manual2.Controls.Add(this.label4);
			this.groupBox_Manual2.Controls.Add(this.label3);
			this.groupBox_Manual2.Controls.Add(this.textBox_goto_posZ);
			this.groupBox_Manual2.Controls.Add(this.textBox_goto_posY);
			this.groupBox_Manual2.Controls.Add(this.Bnt_IssueGoToCommand);
			this.groupBox_Manual2.Controls.Add(this.textBox_goto_posX);
			this.groupBox_Manual2.Location = new System.Drawing.Point(468, 185);
			this.groupBox_Manual2.Name = "groupBox_Manual2";
			this.groupBox_Manual2.Size = new System.Drawing.Size(330, 102);
			this.groupBox_Manual2.TabIndex = 19;
			this.groupBox_Manual2.TabStop = false;
			this.groupBox_Manual2.Text = "Manual - Go To Postion";
			// 
			// check_BigSteps
			// 
			this.check_BigSteps.AutoSize = true;
			this.check_BigSteps.Location = new System.Drawing.Point(205, 40);
			this.check_BigSteps.Name = "check_BigSteps";
			this.check_BigSteps.Size = new System.Drawing.Size(107, 17);
			this.check_BigSteps.TabIndex = 26;
			this.check_BigSteps.Text = "Enable Big Steps";
			this.check_BigSteps.UseVisualStyleBackColor = true;
			// 
			// Bnt_IssueZdown
			// 
			this.Bnt_IssueZdown.Location = new System.Drawing.Point(66, 70);
			this.Bnt_IssueZdown.Name = "Bnt_IssueZdown";
			this.Bnt_IssueZdown.Size = new System.Drawing.Size(24, 20);
			this.Bnt_IssueZdown.TabIndex = 26;
			this.Bnt_IssueZdown.Text = "<";
			this.Bnt_IssueZdown.UseVisualStyleBackColor = true;
			this.Bnt_IssueZdown.Click += new System.EventHandler(this.Bnt_IssueZdown_Click);
			// 
			// check_IssueOnPress
			// 
			this.check_IssueOnPress.AutoSize = true;
			this.check_IssueOnPress.Location = new System.Drawing.Point(205, 17);
			this.check_IssueOnPress.Name = "check_IssueOnPress";
			this.check_IssueOnPress.Size = new System.Drawing.Size(119, 17);
			this.check_IssueOnPress.TabIndex = 25;
			this.check_IssueOnPress.Text = "Issue CMD on Click";
			this.check_IssueOnPress.UseVisualStyleBackColor = true;
			// 
			// Bnt_IssueYdown
			// 
			this.Bnt_IssueYdown.Location = new System.Drawing.Point(66, 44);
			this.Bnt_IssueYdown.Name = "Bnt_IssueYdown";
			this.Bnt_IssueYdown.Size = new System.Drawing.Size(24, 20);
			this.Bnt_IssueYdown.TabIndex = 26;
			this.Bnt_IssueYdown.Text = "<";
			this.Bnt_IssueYdown.UseVisualStyleBackColor = true;
			this.Bnt_IssueYdown.Click += new System.EventHandler(this.Bnt_IssueYdown_Click);
			// 
			// Bnt_IssueXdown
			// 
			this.Bnt_IssueXdown.Location = new System.Drawing.Point(66, 18);
			this.Bnt_IssueXdown.Name = "Bnt_IssueXdown";
			this.Bnt_IssueXdown.Size = new System.Drawing.Size(24, 20);
			this.Bnt_IssueXdown.TabIndex = 26;
			this.Bnt_IssueXdown.Text = "<";
			this.Bnt_IssueXdown.UseVisualStyleBackColor = true;
			this.Bnt_IssueXdown.Click += new System.EventHandler(this.Bnt_IssueXdown_Click);
			// 
			// Bnt_IssueZup
			// 
			this.Bnt_IssueZup.Location = new System.Drawing.Point(162, 69);
			this.Bnt_IssueZup.Name = "Bnt_IssueZup";
			this.Bnt_IssueZup.Size = new System.Drawing.Size(24, 20);
			this.Bnt_IssueZup.TabIndex = 25;
			this.Bnt_IssueZup.Text = ">";
			this.Bnt_IssueZup.UseVisualStyleBackColor = true;
			this.Bnt_IssueZup.Click += new System.EventHandler(this.Bnt_IssueZup_Click);
			// 
			// Bnt_IssueYup
			// 
			this.Bnt_IssueYup.Location = new System.Drawing.Point(162, 43);
			this.Bnt_IssueYup.Name = "Bnt_IssueYup";
			this.Bnt_IssueYup.Size = new System.Drawing.Size(24, 20);
			this.Bnt_IssueYup.TabIndex = 25;
			this.Bnt_IssueYup.Text = ">";
			this.Bnt_IssueYup.UseVisualStyleBackColor = true;
			this.Bnt_IssueYup.Click += new System.EventHandler(this.Bnt_IssueYup_Click);
			// 
			// Bnt_IssueXup
			// 
			this.Bnt_IssueXup.Location = new System.Drawing.Point(162, 17);
			this.Bnt_IssueXup.Name = "Bnt_IssueXup";
			this.Bnt_IssueXup.Size = new System.Drawing.Size(24, 20);
			this.Bnt_IssueXup.TabIndex = 25;
			this.Bnt_IssueXup.Text = ">";
			this.Bnt_IssueXup.UseVisualStyleBackColor = true;
			this.Bnt_IssueXup.Click += new System.EventHandler(this.Bnt_IssueXup_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(8, 74);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(57, 13);
			this.label5.TabIndex = 24;
			this.label5.Text = "Z Position:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(8, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(57, 13);
			this.label4.TabIndex = 23;
			this.label4.Text = "Y Position:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(8, 22);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(57, 13);
			this.label3.TabIndex = 22;
			this.label3.Text = "X Position:";
			// 
			// textBox_goto_posZ
			// 
			this.textBox_goto_posZ.Location = new System.Drawing.Point(96, 69);
			this.textBox_goto_posZ.Name = "textBox_goto_posZ";
			this.textBox_goto_posZ.Size = new System.Drawing.Size(60, 20);
			this.textBox_goto_posZ.TabIndex = 21;
			this.textBox_goto_posZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBox_goto_posY
			// 
			this.textBox_goto_posY.Location = new System.Drawing.Point(96, 43);
			this.textBox_goto_posY.Name = "textBox_goto_posY";
			this.textBox_goto_posY.Size = new System.Drawing.Size(60, 20);
			this.textBox_goto_posY.TabIndex = 20;
			this.textBox_goto_posY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Bnt_IssueGoToCommand
			// 
			this.Bnt_IssueGoToCommand.Location = new System.Drawing.Point(205, 63);
			this.Bnt_IssueGoToCommand.Name = "Bnt_IssueGoToCommand";
			this.Bnt_IssueGoToCommand.Size = new System.Drawing.Size(100, 30);
			this.Bnt_IssueGoToCommand.TabIndex = 18;
			this.Bnt_IssueGoToCommand.Text = "Issue Goto CMD";
			this.Bnt_IssueGoToCommand.UseVisualStyleBackColor = true;
			this.Bnt_IssueGoToCommand.Click += new System.EventHandler(this.Bnt_IssueGoToCommand_Click);
			// 
			// textBox_goto_posX
			// 
			this.textBox_goto_posX.Location = new System.Drawing.Point(96, 18);
			this.textBox_goto_posX.Name = "textBox_goto_posX";
			this.textBox_goto_posX.Size = new System.Drawing.Size(60, 20);
			this.textBox_goto_posX.TabIndex = 17;
			this.textBox_goto_posX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.ForeColor = System.Drawing.Color.Gainsboro;
			this.label11.Location = new System.Drawing.Point(124, 10);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(211, 31);
			this.label11.TabIndex = 22;
			this.label11.Text = "Machine Control";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBox_Automatic1
			// 
			this.groupBox_Automatic1.Location = new System.Drawing.Point(804, 68);
			this.groupBox_Automatic1.Name = "groupBox_Automatic1";
			this.groupBox_Automatic1.Size = new System.Drawing.Size(330, 111);
			this.groupBox_Automatic1.TabIndex = 21;
			this.groupBox_Automatic1.TabStop = false;
			this.groupBox_Automatic1.Text = "Automatic Mode Controls";
			// 
			// Bnt_AutoClearScript
			// 
			this.Bnt_AutoClearScript.Location = new System.Drawing.Point(224, 489);
			this.Bnt_AutoClearScript.Name = "Bnt_AutoClearScript";
			this.Bnt_AutoClearScript.Size = new System.Drawing.Size(100, 30);
			this.Bnt_AutoClearScript.TabIndex = 22;
			this.Bnt_AutoClearScript.Text = "Clear Script";
			this.Bnt_AutoClearScript.UseVisualStyleBackColor = true;
			this.Bnt_AutoClearScript.Click += new System.EventHandler(this.Bnt_AutoClearScript_Click);
			// 
			// richTextBox_Auto
			// 
			this.richTextBox_Auto.Location = new System.Drawing.Point(6, 19);
			this.richTextBox_Auto.Name = "richTextBox_Auto";
			this.richTextBox_Auto.Size = new System.Drawing.Size(318, 464);
			this.richTextBox_Auto.TabIndex = 21;
			this.richTextBox_Auto.Text = "";
			// 
			// groupBox_Manual4
			// 
			this.groupBox_Manual4.Controls.Add(this.Bnt_CloseGrip);
			this.groupBox_Manual4.Controls.Add(this.Bnt_OpenGrip);
			this.groupBox_Manual4.Controls.Add(this.Bnt_DetachServos);
			this.groupBox_Manual4.Controls.Add(this.Bnt_AttachServos);
			this.groupBox_Manual4.Location = new System.Drawing.Point(468, 551);
			this.groupBox_Manual4.Name = "groupBox_Manual4";
			this.groupBox_Manual4.Size = new System.Drawing.Size(330, 159);
			this.groupBox_Manual4.TabIndex = 22;
			this.groupBox_Manual4.TabStop = false;
			this.groupBox_Manual4.Text = "Manual - Servo Controls";
			// 
			// panel_Machinebox
			// 
			this.panel_Machinebox.BackColor = System.Drawing.Color.Gray;
			this.panel_Machinebox.Controls.Add(this.label11);
			this.panel_Machinebox.Location = new System.Drawing.Point(12, 12);
			this.panel_Machinebox.Name = "panel_Machinebox";
			this.panel_Machinebox.Size = new System.Drawing.Size(450, 50);
			this.panel_Machinebox.TabIndex = 24;
			// 
			// panel_Manualbox
			// 
			this.panel_Manualbox.BackColor = System.Drawing.Color.Gray;
			this.panel_Manualbox.Controls.Add(this.label9);
			this.panel_Manualbox.Location = new System.Drawing.Point(468, 12);
			this.panel_Manualbox.Name = "panel_Manualbox";
			this.panel_Manualbox.Size = new System.Drawing.Size(330, 50);
			this.panel_Manualbox.TabIndex = 25;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.ForeColor = System.Drawing.Color.Gainsboro;
			this.label9.Location = new System.Drawing.Point(60, 10);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(211, 31);
			this.label9.TabIndex = 22;
			this.label9.Text = "Manual Controls";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Bnt_Script_TeachPoint
			// 
			this.Bnt_Script_TeachPoint.Location = new System.Drawing.Point(79, 52);
			this.Bnt_Script_TeachPoint.Name = "Bnt_Script_TeachPoint";
			this.Bnt_Script_TeachPoint.Size = new System.Drawing.Size(166, 30);
			this.Bnt_Script_TeachPoint.TabIndex = 2;
			this.Bnt_Script_TeachPoint.Text = "Teach this point";
			this.Bnt_Script_TeachPoint.UseVisualStyleBackColor = true;
			this.Bnt_Script_TeachPoint.Click += new System.EventHandler(this.Bnt_Script_TeachPoint_Click);
			// 
			// groupBox_Manual3
			// 
			this.groupBox_Manual3.Controls.Add(this.Bnt_Script_Loop);
			this.groupBox_Manual3.Controls.Add(this.label6);
			this.groupBox_Manual3.Controls.Add(this.textBox_Script_Delay);
			this.groupBox_Manual3.Controls.Add(this.Bnt_Script_CloseGrip);
			this.groupBox_Manual3.Controls.Add(this.Bnt_Script_OpenGrip);
			this.groupBox_Manual3.Controls.Add(this.Bnt_Script_Delay);
			this.groupBox_Manual3.Controls.Add(this.Bnt_Script_TeachPoint);
			this.groupBox_Manual3.Location = new System.Drawing.Point(468, 293);
			this.groupBox_Manual3.Name = "groupBox_Manual3";
			this.groupBox_Manual3.Size = new System.Drawing.Size(330, 252);
			this.groupBox_Manual3.TabIndex = 23;
			this.groupBox_Manual3.TabStop = false;
			this.groupBox_Manual3.Text = "Manual - Script Buliding";
			// 
			// Bnt_Script_CloseGrip
			// 
			this.Bnt_Script_CloseGrip.Location = new System.Drawing.Point(79, 160);
			this.Bnt_Script_CloseGrip.Name = "Bnt_Script_CloseGrip";
			this.Bnt_Script_CloseGrip.Size = new System.Drawing.Size(166, 30);
			this.Bnt_Script_CloseGrip.TabIndex = 5;
			this.Bnt_Script_CloseGrip.Text = "Close Grip";
			this.Bnt_Script_CloseGrip.UseVisualStyleBackColor = true;
			this.Bnt_Script_CloseGrip.Click += new System.EventHandler(this.Bnt_Script_CloseGrip_Click);
			// 
			// Bnt_Script_OpenGrip
			// 
			this.Bnt_Script_OpenGrip.Location = new System.Drawing.Point(79, 124);
			this.Bnt_Script_OpenGrip.Name = "Bnt_Script_OpenGrip";
			this.Bnt_Script_OpenGrip.Size = new System.Drawing.Size(166, 30);
			this.Bnt_Script_OpenGrip.TabIndex = 4;
			this.Bnt_Script_OpenGrip.Text = "Open Grip";
			this.Bnt_Script_OpenGrip.UseVisualStyleBackColor = true;
			this.Bnt_Script_OpenGrip.Click += new System.EventHandler(this.Bnt_Script_OpenGrip_Click);
			// 
			// Bnt_Script_Delay
			// 
			this.Bnt_Script_Delay.Location = new System.Drawing.Point(79, 87);
			this.Bnt_Script_Delay.Name = "Bnt_Script_Delay";
			this.Bnt_Script_Delay.Size = new System.Drawing.Size(100, 30);
			this.Bnt_Script_Delay.TabIndex = 3;
			this.Bnt_Script_Delay.Text = "Delay (s)";
			this.Bnt_Script_Delay.UseVisualStyleBackColor = true;
			this.Bnt_Script_Delay.Click += new System.EventHandler(this.Bnt_Script_Delay_Click);
			// 
			// panel_Autobox
			// 
			this.panel_Autobox.BackColor = System.Drawing.Color.Gray;
			this.panel_Autobox.Controls.Add(this.label12);
			this.panel_Autobox.Location = new System.Drawing.Point(804, 12);
			this.panel_Autobox.Name = "panel_Autobox";
			this.panel_Autobox.Size = new System.Drawing.Size(330, 50);
			this.panel_Autobox.TabIndex = 26;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label12.ForeColor = System.Drawing.Color.Gainsboro;
			this.label12.Location = new System.Drawing.Point(43, 10);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(244, 31);
			this.label12.TabIndex = 22;
			this.label12.Text = "Automatic Controls";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textBox_Script_Delay
			// 
			this.textBox_Script_Delay.Location = new System.Drawing.Point(185, 93);
			this.textBox_Script_Delay.Name = "textBox_Script_Delay";
			this.textBox_Script_Delay.Size = new System.Drawing.Size(60, 20);
			this.textBox_Script_Delay.TabIndex = 22;
			this.textBox_Script_Delay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.SystemColors.ControlDark;
			this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.label6.Location = new System.Drawing.Point(3, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(321, 30);
			this.label6.TabIndex = 23;
			this.label6.Text = "COMMAND LIST";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Bnt_CloseGrip
			// 
			this.Bnt_CloseGrip.Location = new System.Drawing.Point(168, 19);
			this.Bnt_CloseGrip.Name = "Bnt_CloseGrip";
			this.Bnt_CloseGrip.Size = new System.Drawing.Size(150, 30);
			this.Bnt_CloseGrip.TabIndex = 7;
			this.Bnt_CloseGrip.Text = "Close Grip";
			this.Bnt_CloseGrip.UseVisualStyleBackColor = true;
			this.Bnt_CloseGrip.Click += new System.EventHandler(this.Bnt_CloseGrip_Click);
			// 
			// Bnt_OpenGrip
			// 
			this.Bnt_OpenGrip.Location = new System.Drawing.Point(12, 19);
			this.Bnt_OpenGrip.Name = "Bnt_OpenGrip";
			this.Bnt_OpenGrip.Size = new System.Drawing.Size(150, 30);
			this.Bnt_OpenGrip.TabIndex = 6;
			this.Bnt_OpenGrip.Text = "Open Grip";
			this.Bnt_OpenGrip.UseVisualStyleBackColor = true;
			this.Bnt_OpenGrip.Click += new System.EventHandler(this.Bnt_OpenGrip_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.Bnt_AutoClearScript);
			this.groupBox1.Controls.Add(this.richTextBox_Auto);
			this.groupBox1.Location = new System.Drawing.Point(804, 185);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(330, 525);
			this.groupBox1.TabIndex = 27;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Automatic Script";
			// 
			// Bnt_Script_Loop
			// 
			this.Bnt_Script_Loop.Location = new System.Drawing.Point(79, 196);
			this.Bnt_Script_Loop.Name = "Bnt_Script_Loop";
			this.Bnt_Script_Loop.Size = new System.Drawing.Size(166, 30);
			this.Bnt_Script_Loop.TabIndex = 24;
			this.Bnt_Script_Loop.Text = "Loop (use at end)";
			this.Bnt_Script_Loop.UseVisualStyleBackColor = true;
			this.Bnt_Script_Loop.Click += new System.EventHandler(this.Bnt_Script_Loop_Click);
			// 
			// MainScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlDark;
			this.ClientSize = new System.Drawing.Size(1145, 721);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.panel_Autobox);
			this.Controls.Add(this.panel_Manualbox);
			this.Controls.Add(this.groupBox_Manual3);
			this.Controls.Add(this.groupBox_Manual4);
			this.Controls.Add(this.groupBox_Automatic1);
			this.Controls.Add(this.groupBox_Manual2);
			this.Controls.Add(this.groupBox_MahineStates);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.groupBox_Manual1);
			this.Controls.Add(this.groupBox_ModeSelect);
			this.Controls.Add(this.panel_Machinebox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "MainScreen";
			this.Text = "Robot Arm HMI";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainScreen_FormClosing);
			this.Load += new System.EventHandler(this.MainScreen_Load);
			this.groupBox_ModeSelect.ResumeLayout(false);
			this.groupBox_ModeSelect.PerformLayout();
			this.groupBox_Manual1.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.groupBox_MahineStates.ResumeLayout(false);
			this.groupBox_MahineStates.PerformLayout();
			this.groupBox_Manual2.ResumeLayout(false);
			this.groupBox_Manual2.PerformLayout();
			this.groupBox_Manual4.ResumeLayout(false);
			this.panel_Machinebox.ResumeLayout(false);
			this.panel_Machinebox.PerformLayout();
			this.panel_Manualbox.ResumeLayout(false);
			this.panel_Manualbox.PerformLayout();
			this.groupBox_Manual3.ResumeLayout(false);
			this.groupBox_Manual3.PerformLayout();
			this.panel_Autobox.ResumeLayout(false);
			this.panel_Autobox.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.Button bnt_Home_All;
		private System.Windows.Forms.Button bnt_Home_AxisA;
		private System.Windows.Forms.Button bnt_Home_AxisB;
		private System.Windows.Forms.Button bnt_Home_Base;
		private System.Windows.Forms.GroupBox groupBox_ModeSelect;
		private System.Windows.Forms.GroupBox groupBox_Manual1;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.TextBox OutputText_BaudRate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox OutputText_PortName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button Bnt_Serial_StartListen;
		private System.Windows.Forms.Button Bnt_Serial_StopListen;
		private System.IO.Ports.SerialPort serialPort1;
		private System.Windows.Forms.RichTextBox richTextBox_textReceiver;
		private System.Windows.Forms.Label label_status;
		private System.Windows.Forms.TextBox textBox_textSent;
		private System.Windows.Forms.Button Bnt_Serial_Send;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.GroupBox groupBox_MahineStates;
		public System.Windows.Forms.Button Bnt_State_Start;
		public System.Windows.Forms.Button Bnt_State_Stop;
		public System.Windows.Forms.Button Bnt_DetachServos;
		public System.Windows.Forms.Button Bnt_AttachServos;
		public System.Windows.Forms.Button Bnt_State_Reset;
		public System.Windows.Forms.Button Bnt_Mode_Auto;
		private System.Windows.Forms.TextBox textBox_Status_Mode;
		private System.Windows.Forms.TextBox textBox_Status_State;
		private System.Windows.Forms.Button Bnt_ClearTextReceiver;
		private System.Windows.Forms.TextBox textBox_StatusBar;
		public System.Windows.Forms.Button Bnt_Mode_Manual;
		private System.Windows.Forms.Button Bnt_GetState;
		private System.Windows.Forms.Button Bnt_GetMode;
		private System.Windows.Forms.GroupBox groupBox_Manual2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox_goto_posZ;
		private System.Windows.Forms.TextBox textBox_goto_posY;
		public System.Windows.Forms.Button Bnt_IssueGoToCommand;
		private System.Windows.Forms.TextBox textBox_goto_posX;
		public System.Windows.Forms.Button Bnt_IssueZdown;
		public System.Windows.Forms.Button Bnt_IssueYdown;
		public System.Windows.Forms.Button Bnt_IssueXdown;
		public System.Windows.Forms.Button Bnt_IssueZup;
		public System.Windows.Forms.Button Bnt_IssueYup;
		public System.Windows.Forms.Button Bnt_IssueXup;
		private System.Windows.Forms.CheckBox check_IssueOnPress;
		private System.Windows.Forms.CheckBox check_BigSteps;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.GroupBox groupBox_Automatic1;
		private System.Windows.Forms.GroupBox groupBox_Manual4;
		private System.Windows.Forms.Panel panel_Machinebox;
		private System.Windows.Forms.Panel panel_Manualbox;
		private System.Windows.Forms.Label label9;
		public System.Windows.Forms.Button Bnt_Script_TeachPoint;
		private System.Windows.Forms.GroupBox groupBox_Manual3;
		private System.Windows.Forms.Panel panel_Autobox;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.RichTextBox richTextBox_Auto;
		public System.Windows.Forms.Button Bnt_AutoClearScript;
		public System.Windows.Forms.Button Bnt_Script_Delay;
		public System.Windows.Forms.Button Bnt_Script_CloseGrip;
		public System.Windows.Forms.Button Bnt_Script_OpenGrip;
		private System.Windows.Forms.TextBox textBox_Script_Delay;
		public System.Windows.Forms.Button Bnt_CloseGrip;
		public System.Windows.Forms.Button Bnt_OpenGrip;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox groupBox1;
		public System.Windows.Forms.Button Bnt_Script_Loop;
	}
}

