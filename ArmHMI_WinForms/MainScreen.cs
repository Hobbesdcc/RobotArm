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


		// Command Strings to send over serial to Ardunio 
		string CMD_Home_All			= "HOME_ALL";
		string CMD_Home_AxisA		= "HOME_AXIS_A";
		string CMD_Home_AxisB		= "HOME_AXIS_B";
		string CMD_Home_Base		= "HOME_Base";

		string CMD_State_Start		= "STATE_START";
		string CMD_State_Stop		= "STATE_STOP";
		string CMD_State_Reset		= "STATE_RESET";

		string CMD_Mode_Manual		= "MODE_MANUAL";
		string CMD_Mode_Auto		= "MODE_AUTO";

		string CMD_Servos_Attach	= "SERVOS_ATTACH";
		string CMD_Servos_Detach	= "SERVOS_DETACH";


		public MainScreen()
		{
			InitializeComponent();
		}

		private void MainScreen_Load(object sender, EventArgs e)
		{
			//add defult settings
			Bnt_Serial_StartListen.Enabled = true;
			Bnt_Serial_StopListen.Enabled = false;
			label_status.Text = "DISCONNECTED";
			label_status.ForeColor = Color.Red;

			OutputText_BaudRate.Enabled = false;
			OutputText_PortName.Enabled = false;
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


		// Fuction ==================================================================
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
				label_status.Text = "NOT CONNECTED, CANT ISSUE COMMANDS!";
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



		//Events: Serial listener & Connect/disconnect Buttons -----------------------------------------------------------
		private void Bnt_Serial_StartListen_Click(object sender, EventArgs e)
		{
			try
			{
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
				label_status.Text = "CONNECTED";
				label_status.ForeColor = Color.Green;
			}
			catch (Exception error)
			{
				MessageBox.Show(error.Message);
				label_status.Text = "FAILED TO CONNECT!";
			}

		}

		private void Bnt_Serial_StopListen_Click(object sender, EventArgs e)
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
					label_status.Text = "DISCONNECTED";
					label_status.ForeColor = Color.Red;

				}
				catch (Exception error)
				{
					MessageBox.Show(error.Message);
					label_status.Text = "FAILED TO CLOSE PORT!";
				}
			}
		}

		private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			Console.WriteLine("HEY");
			serialDataIn = serialPort1.ReadExisting();
			this.Invoke(new EventHandler(ShowData));
			Console.WriteLine(serialDataIn);
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
	}
}
