/////////////////////////
//Author: Aleksa Arsic//
///////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoCisco
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void monoFlat_Button1_Click(object sender, EventArgs e)
        {

            string number = txtNumber.Text;
            
            if (cb44.Checked)
            {
                txtNumber.Text = "00044" + txtNumber.Text;
                cb90.Checked = false;
                //string number = txtNumber.Text;
                number = number.Replace(" ", "");
            }

            if (cb90.Checked)
            {
                txtNumber.Text = "9" + txtNumber.Text;
                cb44.Checked = false;
               // string number = txtNumber.Text;
                number = number.Replace(" ", "");
            }
            

            Process[] processes = Process.GetProcessesByName("CTIOSSoftphone");
            if (processes.Length > 0)
            {
                WindowHelper.BringProcessToFront(processes[0]);
                SendKeys.SendWait("%(n)");
                SendKeys.SendWait("{DOWN}");
                SendKeys.SendWait("{DOWN}");
                SendKeys.SendWait("{DOWN}");
                SendKeys.SendWait("{DOWN}");
                SendKeys.SendWait("{DOWN}");
                SendKeys.SendWait("{DOWN}");
                SendKeys.SendWait("{DOWN}");
                SendKeys.SendWait("{DOWN}");
                SendKeys.SendWait("{ENTER}");
                System.Threading.Thread.Sleep(300);
                SendKeys.SendWait("%(d)");
                System.Threading.Thread.Sleep(600);
                SendKeys.SendWait("{BKSP}");
                System.Threading.Thread.Sleep(100);
                SendKeys.SendWait("9" + number);
                SendKeys.SendWait("{ENTER}");
                WindowHelper.BringProcessToFront(processes[0]);
                //SendKeys.SendWait("%(r)");

            }
            else
            {
                MessageBox.Show("Please launch CISCO Application first.", "CISCO Not running", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

        private void monoFlat_ThemeContainer1_Enter(object sender, EventArgs e)
        {
            txtNumber.Text = Clipboard.GetText();

        }

        private void cb90_CheckedChanged(object sender)
        {
            
        }

        private void cb44_CheckedChanged(object sender)
        {
            
        }

        private void cb90_CheckedChanged(object sender, EventArgs e)
        {
            cb44.Checked = false;
        }

        private void cb44_CheckedChanged(object sender, EventArgs e)
        {
            cb90.Checked = false;
        }

        private void monoFlat_Button2_Click(object sender, EventArgs e)
        {
            string storenum = textBox1.Text;
            System.Diagnostics.Process.Start("chrome.exe","https://my.morrisons.com/storefinder/" + storenum);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("If you are using Prefix 90 copy the whole store number. \n \n If you are using Prefix 00044 please DO NOT COPY only the inital 0!", "Instructions ",MessageBoxButtons.OK);
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            txtNumber.Text = Clipboard.GetText();
        }
    }
}
