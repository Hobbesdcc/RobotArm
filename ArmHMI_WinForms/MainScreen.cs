using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace ArmHMI_WinForms
{
	public partial class MainScreen : Form
	{
		string serialDataIn;
		bool bulidingStringInProgress;
		char endCharacter = (char)35; //"#"
		char startCharacter = (char)36; //"$"
		StringBuilder stringBuilder = new StringBuilder();
		string currentLine = string.Empty;

		// Command Strings, Same KeyWords used on both sides (serial to Ardunio to C# Form)
		string CMD_Home_All				= "$HOME_ALL#";
		string CMD_Home_AxisA			= "$HOME_AXIS_A#";
		string CMD_Home_AxisB			= "$HOME_AXIS_B#";
		string CMD_Home_Base			= "$HOME_Base#";

		string CMD_State_Idel			= "$STATE_IDEL#";
		string CMD_State_Started		= "$STATE_STARTED#";
		string CMD_State_Stopped		= "$STATE_STOPPED#";

		string CMD_State_Start			= "$STATE_START#";
		string CMD_State_Stop			= "$STATE_STOP#";
		string CMD_State_Reset			= "$STATE_RESET#";

		string CMD_Mode_Manual			= "$MODE_MANUAL#";
		string CMD_Mode_Auto			= "$MODE_AUTO#";

		string CMD_Servos_Attach		= "$SERVOS_ATTACH#";
		string CMD_Servos_Detach		= "$SERVOS_DETACH#";
		string CMD_Servos_GOTO			= "$SERVOS_GOTO_X,Y,Z#";
		string CMD_Servos_OPENGRIP		= "$SERVOS_OPENGRIP#";
		string CMD_Servos_CLOSEGRIP		= "$SERVOS_CLOSEGRIP#";

		string CMD_Status_GetState		= "$STATUS_GETSTATE#";
		string CMD_Status_GetMode		= "$STATUS_GETMODE#";

		


		//FORM ----------------------------------------------------------------------------------------------------------- 
		public MainScreen()
		{
			InitializeComponent();
		}
		private void MainScreen_Load(object sender, EventArgs e)
		{
			//add defult settings
			Bnt_Serial_StartListen.Enabled = true;
			Bnt_Serial_StopListen.Enabled = false;
			textBox_StatusBar.Text = "DISCONNECTED";
			label_status.Text = "DISCONNECTED";
			label_status.ForeColor = Color.Red;

			textBox_Status_State.Text = "null";
			textBox_Status_Mode.Text = "null";

			textBox_goto_posX.Text = "12";
			textBox_goto_posY.Text = "12";
			textBox_goto_posZ.Text = "0";
			textBox_Script_Delay.Text = "0";

			check_IssueOnPress.Checked = true;
			

		}
		private void MainScreen_FormClosing(object sender, FormClosingEventArgs e)
		{
			//On form close, close open serial port
			if (serialPort1.IsOpen)
			{
				try
				{
					serialPort1.Close();
				}
				catch (Exception error)
				{
					MessageBox.Show(error.Message);
				}
			}
		}


		// Fuction =======================================================================================================
		private void IssueSerialCommand(String cmd)
		{
			//Check if port is open, if so send the inputed string coming from the fuction call
			if (serialPort1.IsOpen)
			{
				try
				{
					serialPort1.Write(cmd);
					textBox_StatusBar.Text = cmd;
				}
				catch (Exception error)
				{
					MessageBox.Show(error.Message);
				}
			}
			else
			{
				textBox_StatusBar.Text = "NOT CONNECTED, CANT ISSUE COMMANDS!";
			}
		}
		
		private void PaseSerialCommand(String Serialdata)
		{
			Console.WriteLine("currentLine: " + Serialdata);

			//Check for mode change modes, if found, change text and remove that string from the string concat
			//So bc called this fuction/method from another thread "Cross thread operation not valid"
			//you have to do some vodo magic Invoke stuff to get the method to trigger an event in another thread
		
			if (-1 != Serialdata.IndexOf(CMD_Mode_Manual))
			{
				textBox_Status_Mode.Invoke((MethodInvoker)(() => textBox_Status_Mode.Text = "MANUAL"));

				groupBox_Manual1.Invoke((MethodInvoker)(() => groupBox_Manual1.Enabled = true));
				groupBox_Manual2.Invoke((MethodInvoker)(() => groupBox_Manual2.Enabled = true));
				groupBox_Manual3.Invoke((MethodInvoker)(() => groupBox_Manual3.Enabled = true));
				groupBox_Manual4.Invoke((MethodInvoker)(() => groupBox_Manual4.Enabled = true));

				groupBox_Automatic1.Invoke((MethodInvoker)(() => groupBox_Automatic1.Enabled = false));

				panel_Manualbox.BackColor	= Color.OliveDrab;
				panel_Autobox.BackColor		= Color.Gray;
			}
			if (-1 != Serialdata.IndexOf(CMD_Mode_Auto))
			{
				textBox_Status_Mode.Invoke((MethodInvoker)(() => textBox_Status_Mode.Text = "AUTOMATIC"));

				groupBox_Manual1.Invoke((MethodInvoker)(() => groupBox_Manual1.Enabled = false));
				groupBox_Manual2.Invoke((MethodInvoker)(() => groupBox_Manual2.Enabled = false));
				groupBox_Manual3.Invoke((MethodInvoker)(() => groupBox_Manual3.Enabled = false));
				groupBox_Manual4.Invoke((MethodInvoker)(() => groupBox_Manual4.Enabled = false));

				groupBox_Automatic1.Invoke((MethodInvoker)(() => groupBox_Automatic1.Enabled = true));

				panel_Manualbox.BackColor	= Color.Gray;
				panel_Autobox.BackColor		= Color.OliveDrab;
			}

			//Check for mode change modes, if found, change text and remove that string from the string concat
			if (-1 != Serialdata.IndexOf(CMD_State_Idel))
			{
				textBox_Status_State.Invoke((MethodInvoker)(() => textBox_Status_State.Text = "IDEL"));
				panel_Machinebox.BackColor	= Color.CornflowerBlue;
			}
			if (-1 != Serialdata.IndexOf(CMD_State_Started))
			{
				textBox_Status_State.Invoke((MethodInvoker)(() => textBox_Status_State.Text = "STARTED"));
				panel_Machinebox.BackColor = Color.OliveDrab;
			}
			if (-1 != Serialdata.IndexOf(CMD_State_Stopped))
			{
				textBox_Status_State.Invoke((MethodInvoker)(() => textBox_Status_State.Text = "STOPPED"));
				panel_Machinebox.BackColor = Color.IndianRed;
			}
		}

		//Events: Buttons Commands --------------------------------------------------------------------------------------- 
		private void Bnt_Home_All_Click(object sender, EventArgs e)
		{
			IssueSerialCommand(CMD_Home_All);
		}
		private void Bnt_Home_AxisA_Click(object sender, EventArgs e)
		{
			IssueSerialCommand(CMD_Home_AxisA);
		}
		private void Bnt_Home_AxisB_Click(object sender, EventArgs e)
		{
			IssueSerialCommand(CMD_Home_AxisB);
		}
		private void Bnt_Home_Base_Click(object sender, EventArgs e)
		{
			IssueSerialCommand(CMD_Home_Base);
		}


		//Events: Mode & State Command buttons ---------------------------------------------------------------------------
		private void Bnt_Mode_Auto_Click(object sender, EventArgs e)
		{
			IssueSerialCommand(CMD_Mode_Auto);
		}
		private void Bnt_Mode_Manual_Click(object sender, EventArgs e)
		{
			IssueSerialCommand(CMD_Mode_Manual);
		}
		private void Bnt_GetState_Click(object sender, EventArgs e)
		{
			IssueSerialCommand(CMD_Status_GetState);
		}
		private void Bnt_GetMode_Click(object sender, EventArgs e)
		{
			IssueSerialCommand(CMD_Status_GetMode);
		}
		private void Bnt_State_Start_Click(object sender, EventArgs e)
		{
			IssueSerialCommand(CMD_State_Start);
		}
		private void Bnt_State_Stop_Click(object sender, EventArgs e)
		{
			IssueSerialCommand(CMD_State_Stop);
		}
		private void Bnt_State_Reset_Click(object sender, EventArgs e)
		{
			IssueSerialCommand(CMD_State_Reset);
		}
		private void Bnt_AttachServos_Click(object sender, EventArgs e)
		{
			IssueSerialCommand(CMD_Servos_Attach);
		}
		private void Bnt_DetachServos_Click(object sender, EventArgs e)
		{
			IssueSerialCommand(CMD_Servos_Detach);
		}
		private void Bnt_OpenGrip_Click(object sender, EventArgs e)
		{
			IssueSerialCommand(CMD_Servos_OPENGRIP);
		}
		private void Bnt_CloseGrip_Click(object sender, EventArgs e)
		{
			IssueSerialCommand(CMD_Servos_CLOSEGRIP);
		}

		private void Bnt_IssueGoToCommand_Click(object sender, EventArgs e)
		{
			//Modify the CMD_Servos_GOTO command to insert the X,Y,Z positons
			String cmdModified = CMD_Servos_GOTO.Insert(CMD_Servos_GOTO.IndexOf('X') + 1, textBox_goto_posX.Text);
			cmdModified = cmdModified.Insert(cmdModified.IndexOf('Y') + 1, textBox_goto_posY.Text);
			cmdModified = cmdModified.Insert(cmdModified.IndexOf('Z') + 1, textBox_goto_posZ.Text);

			IssueSerialCommand(cmdModified);
		}
		private void Bnt_IssueXup_Click(object sender, EventArgs e)
		{
			float temp = float.Parse(textBox_goto_posX.Text);
			if (check_BigSteps.Checked){
				temp = temp + 4f;
			}else{
				temp = temp + 1f;
			}
			
			textBox_goto_posX.Text = temp.ToString();

			if (check_IssueOnPress.Checked){
				Bnt_IssueGoToCommand.PerformClick();
			}
		}
		private void Bnt_IssueYup_Click(object sender, EventArgs e)
		{
			float temp = float.Parse(textBox_goto_posY.Text);

			if (check_BigSteps.Checked){
				temp = temp + 4f;
			}else{
				temp = temp + 1f;
			}

			textBox_goto_posY.Text = temp.ToString();

			if (check_IssueOnPress.Checked){
				Bnt_IssueGoToCommand.PerformClick();
			}
		}
		private void Bnt_IssueZup_Click(object sender, EventArgs e)
		{
			float temp = float.Parse(textBox_goto_posZ.Text);

			if (check_BigSteps.Checked){
				temp = temp + 4f;
			}else{
				temp = temp + 1f;
			}

			textBox_goto_posZ.Text = temp.ToString();

			if (check_IssueOnPress.Checked){
				Bnt_IssueGoToCommand.PerformClick();
			}
		}
		private void Bnt_IssueXdown_Click(object sender, EventArgs e)
		{
			float temp = float.Parse(textBox_goto_posX.Text);

			if (check_BigSteps.Checked){
				temp = temp - 4f;
			}else{
				temp = temp - 1f;
			}

			textBox_goto_posX.Text = temp.ToString();

			if (check_IssueOnPress.Checked){
				Bnt_IssueGoToCommand.PerformClick();
			}
		}
		private void Bnt_IssueYdown_Click(object sender, EventArgs e)
		{
			float temp = float.Parse(textBox_goto_posY.Text);

			if (check_BigSteps.Checked){
				temp = temp - 4f;
			}else{
				temp = temp - 1f;
			}

			textBox_goto_posY.Text = temp.ToString();

			if (check_IssueOnPress.Checked){
				Bnt_IssueGoToCommand.PerformClick();
			}
		}
		private void Bnt_IssueZdown_Click(object sender, EventArgs e)
		{
			float temp = float.Parse(textBox_goto_posZ.Text);

			if (check_BigSteps.Checked){
				temp = temp - 4f;
			}else{
				temp = temp - 1f;
			}

			textBox_goto_posZ.Text = temp.ToString();

			if (check_IssueOnPress.Checked) {
				Bnt_IssueGoToCommand.PerformClick();
			}
		}

		private void Bnt_AutoClearScript_Click(object sender, EventArgs e)
		{
			richTextBox_Auto.Text = "";
		}
		private void Bnt_Script_TeachPoint_Click(object sender, EventArgs e)
		{
			richTextBox_Auto.Text += "GOTO" + textBox_goto_posX.Text + "X," + textBox_goto_posY.Text + "Y," + textBox_goto_posZ.Text + "Z;\r\n";
		}
		private void Bnt_Script_OpenGrip_Click(object sender, EventArgs e)
		{
			richTextBox_Auto.Text += "OpenGrip;\r\n";
		}
		private void Bnt_Script_CloseGrip_Click(object sender, EventArgs e)
		{
			richTextBox_Auto.Text += "CloseGrip;\r\n";
		}
		private void Bnt_Script_Delay_Click(object sender, EventArgs e)
		{
			richTextBox_Auto.Text += "Delay(" + textBox_Script_Delay.Text + ");\r\n";
		}
		private void Bnt_Script_Loop_Click(object sender, EventArgs e)
		{
			richTextBox_Auto.Text += "Loop;\r\n";
		}

		//Events: Serial listener & Connect/disconnect Buttons -----------------------------------------------------------
		private void Bnt_Serial_Connect_Click(object sender, EventArgs e)
		{
			try
			{
				Bnt_ClearTextReceiver.PerformClick(); //clear text box

				//Open Serial Port
				serialPort1.BaudRate = 9600;
				serialPort1.PortName = "COM5";
				serialPort1.Open();

				//GUI Output info about comms

				OutputText_BaudRate.Text = serialPort1.BaudRate.ToString();
				OutputText_PortName.Text = serialPort1.PortName.ToString();

				//GUI status
				Bnt_Serial_StartListen.Enabled = false;
				Bnt_Serial_StopListen.Enabled = true;
				textBox_StatusBar.Text = "CONNECTED";
				label_status.Text = "CONNECTED";
				label_status.ForeColor = Color.Green;

				//Get Machine State & Mode
				IssueSerialCommand(CMD_Status_GetState);
				IssueSerialCommand(CMD_Status_GetMode);

			}
			catch (Exception error)
			{
				MessageBox.Show(error.Message);
				textBox_StatusBar.Text = "FAILED TO CONNECT!";
			}

		}

		private void Bnt_Serial_Disconnect_Click(object sender, EventArgs e)
		{
			//Check if port is open, if so try to close, and update UI
			if (serialPort1.IsOpen)
			{
				try
				{
					serialPort1.Close();

					//Output info to HMI screen
					OutputText_BaudRate.Text = "";
					OutputText_PortName.Text = "";
					Bnt_Serial_StartListen.Enabled = true;
					Bnt_Serial_StopListen.Enabled = false;
					textBox_StatusBar.Text = "DISCONNECTED";
					label_status.Text = "DISCONNECTED";
					label_status.ForeColor = Color.Red;

					textBox_Status_State.Text = "null";
					textBox_Status_Mode.Text = "null";
					panel_Machinebox.BackColor = Color.Gray;
					panel_Manualbox.BackColor = Color.Gray;
					panel_Autobox.BackColor = Color.Gray;

				}
				catch (Exception error)
				{
					MessageBox.Show(error.Message);
					textBox_StatusBar.Text = "FAILED TO CLOSE PORT!";
				}
			}
		}

		private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			serialDataIn = serialPort1.ReadExisting();
			this.Invoke(new EventHandler(ShowData));

			//Loop through each char that is coming in to serial
			foreach (char c in serialDataIn)
			{
				//Check if see special START Character, if so start buliding string
				if (c == startCharacter)
				{
					stringBuilder.Clear();
					stringBuilder.Append(c);
					bulidingStringInProgress = true;
				}
				//Check if see special END Character, if end string, pass it to "currentLine" and send have cmd parsed
				else if (c == endCharacter)
				{
					stringBuilder.Append(c);

					currentLine = stringBuilder.ToString();
					stringBuilder.Clear();
					bulidingStringInProgress = false;

					//Console.WriteLine("currentLine: " + currentLine);
					PaseSerialCommand(currentLine);
				}
				//if not start or end Character & bulidingStringInProgress is set true, just keep on buliding
				else if (bulidingStringInProgress)
				{
					stringBuilder.Append(c);
				}
			}
		}

		private void ShowData(object sender, EventArgs e)
		{
			richTextBox_textReceiver.Text += serialDataIn;
		}

		private void richTextBox_textReceiver_TextChanged(object sender, EventArgs e)
		{
			richTextBox_textReceiver.SelectionStart = richTextBox_textReceiver.Text.Length;
			richTextBox_textReceiver.ScrollToCaret();
		}

		private void Bnt_Serial_Send_Click(object sender, EventArgs e)
		{
			//Try to send what ever is in "textBox_textSent" on click
			try
			{
				//serialPort1.Write(textBox_textSent.Text); //+ "#"
				IssueSerialCommand(textBox_textSent.Text);
			}
			catch (Exception error)
			{
				MessageBox.Show(error.Message);
			}
		}

		private void Bnt_ClearTextReceiver_Click(object sender, EventArgs e)
		{
			richTextBox_textReceiver.Text = "";
		}


	}
}
