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

		private SerialPort mySerialPort;
		bool serialConnected;


		public MainScreen()
		{
			InitializeComponent();
		}


		private void SerialSetup()
		{
			String data;
			String inputvalue;

			mySerialPort = new SerialPort();
			mySerialPort.BaudRate = 9600;
			mySerialPort.PortName = "COM5";
			//mySerialport.ReadTimeout = 1000;
			//mySerialport.WriteTimeout = 1000;
			
			mySerialPort.Open();

			//Output info to HMI screen
			OutputText_BaudRate.Text = mySerialPort.BaudRate.ToString();
			OutputText_PortName.Text = mySerialPort.PortName.ToString();
			
			serialConnected = true;
			mySerialPort.WriteLine("\r\n");

			while (serialConnected)
			{
				data = mySerialPort.ReadLine();
				Console.WriteLine(data);


				if (data == "Input GOTO X: \r" || data == "Input GOTO Y: \r")
				{
					//inputvalue = Console.ReadLine();
					//mySerialPort.WriteLine(inputvalue);
					Bnt_Home_All_Click.PerformClick();
				}
			}
		}

		private void SerialStop()
		{
			mySerialPort.Close();

			//Output info to HMI screen
			OutputText_BaudRate.Text = "";
			OutputText_PortName.Text = "";
		}


		void sendSerialCommand()//String command
		{
			
		}


		

		//Homing Buttons  --------------------------------------------------------------------------------------- 
		private void Bnt_Home_All_Click(object sender, EventArgs e)
		{
			mySerialPort.WriteLine("10");
		}

		private void Bnt_Home_AxisA_Click(object sender, EventArgs e)
		{
			
		}

		private void Bnt_Home_AxisB_Click(object sender, EventArgs e)
		{
			
		}

		private void Bnt_Home_Base_Click(object sender, EventArgs e)
		{
			//mySerialport.WriteLine("\r\n");
			textBox1.Text = textBox1.Text + mySerialPort.ReadLine() + Environment.NewLine;
			textBox1.SelectionStart = textBox1.TextLength;
			textBox1.ScrollToCaret();
		}

		// Serial Listen Buttons --------------------------------------------------------------------------------------- 
		private void Bnt_Serial_StartListen_Click(object sender, EventArgs e)
		{
			SerialSetup();
		}

		private void Bnt_Serial_StopListen_Click(object sender, EventArgs e)
		{
			SerialStop();
		}


	}
}
