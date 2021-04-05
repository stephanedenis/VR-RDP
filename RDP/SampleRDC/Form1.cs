using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Windows.Forms;
using AxMSTSCLib;
using MSTSCLib;

namespace SampleRDC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                rdp.Server = txtServer.Text;
                rdp.UserName = txtUserName.Text;
                rdp.AdvancedSettings9.EnableCredSspSupport = true;

                rdp.OnDisconnected += (object s, IMsTscAxEvents_OnDisconnectedEvent ev)  =>
                {
                    Console.WriteLine("Disconected : " + ev.discReason);
                    // https://social.technet.microsoft.com/wiki/contents/articles/37870.remote-desktop-client-troubleshooting-disconnect-codes-and-reasons.aspx
                };
               
                IMsTscNonScriptable secured = (IMsTscNonScriptable)rdp.GetOcx();
                secured.ClearTextPassword = txtPassword.Text;
                rdp.Connect();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error Connecting", "Error connecting to remote desktop " + txtServer.Text + " Error:  " + Ex.Message,MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if connected before disconnecting
                if (rdp.Connected.ToString() == "1")
                    rdp.Disconnect();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error Disconnecting", "Error disconnecting from remote desktop " + txtServer.Text + " Error:  " + Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}