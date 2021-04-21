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


		//Homing Buttons  --------------------------------------------------------------------------------------- 
		private void Bnt_Home_All_Click(object sender, EventArgs e)
		{
			serialPort1.WriteLine("10");
		}

		private void Bnt_Home_AxisA_Click(object sender, EventArgs e)
		{
			
		}

		private void Bnt_Home_AxisB_Click(object sender, EventArgs e)
		{
			
		}

		private void Bnt_Home_Base_Click(object sender, EventArgs e)
		{   /*
			//serialPort1.WriteLine("\r\n");
			textBox1.Text = textBox1.Text + serialPort1.ReadLine() + Environment.NewLine;
			textBox1.SelectionStart = textBox1.TextLength;
			textBox1.ScrollToCaret();
			//*/
		}

		// Serial Listen Buttons --------------------------------------------------------------------------------------- 
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
