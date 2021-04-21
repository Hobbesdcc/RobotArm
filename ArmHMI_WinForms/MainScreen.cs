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

		// Command Strings, Same KeyWords used on both sides (serial to Ardunio to C# Form)
		string CMD_Home_All				= "HOME_ALL";
		string CMD_Home_AxisA			= "HOME_AXIS_A";
		string CMD_Home_AxisB			= "HOME_AXIS_B";
		string CMD_Home_Base			= "HOME_Base";

		string CMD_State_Idel			= "STATE_IDEL";
		string CMD_State_Started		= "STATE_STARTED";
		string CMD_State_Stopped		= "STATE_STOPPED";

		string CMD_State_Start			= "STATE_START";
		string CMD_State_Stop			= "STATE_STOP";
		string CMD_State_Reset			= "STATE_RESET";

		string CMD_Mode_Init			= "MODE_INIT";
		string CMD_Mode_Manual			= "MODE_MANUAL";
		string CMD_Mode_Auto			= "MODE_AUTO";

		string CMD_Servos_Attach		= "SERVOS_ATTACH";
		string CMD_Servos_Detach		= "SERVOS_DETACH";

		string CMD_Status_GetState		= "STATUS_GETSTATE";
		string CMD_Status_GetMode		= "STATUS_GETMODE";
		string CMD_Status_UpdateState	= "STATUS_UPDATESTATE";
		string CMD_Status_UpdateMode	= "STATUS_UPDATEMODE";


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
					serialPort1.Write(cmd + "#");
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
			IssueSerialCommand(CMD_Status_GetMode);
		}
		private void Bnt_GetState_Click(object sender, EventArgs e)
		{
			IssueSerialCommand(CMD_Status_GetState);
		}
		private void Bnt_GetMode_Click(object sender, EventArgs e)
		{
			IssueSerialCommand(CMD_Status_GetMode);
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
				serialPort1.Write(textBox_textSent.Text + "#");
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
