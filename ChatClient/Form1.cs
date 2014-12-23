using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            serverport = 8888;
            btnDisconnect.Enabled = false;
            btnSend.Enabled = false;
            serveraddress = "127.0.0.1";
        }
        private Thread receive = null;
        protected void OnClosed(EventArgs e)
        {
            QuitChat();
            if (receive != null && receive.IsAlive)
                receive.Abort();

            base.OnClosed(e);
        }
        private bool connected = false;
        private bool logging = false;
        private bool privatemode = false;
        private string clientname;
        private int serverport;
        private NetworkStream ns;
        private StreamReader sr;
        private TcpClient clientsocket;
        private StreamWriter logwriter;
        private string serveraddress;
       
        private void EstablishConnection()
        {
            statusBar1.Text = "Connecting to Server";
            try
            {
                clientsocket = new TcpClient(serveraddress, serverport);
                ns = clientsocket.GetStream();
                sr = new StreamReader(ns);
                connected = true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Could not connect to Server", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                statusBar1.Text = "Disconnected";
            }
        }
        private void RegisterWithServer()
        {
            try
            {
                string command = "CONN|" + ChatOut.Text;
                Byte[] outbytes = System.Text.Encoding.ASCII.GetBytes(command.ToCharArray());
                ns.Write(outbytes, 0, outbytes.Length);

                string serverresponse = sr.ReadLine();
                serverresponse.Trim();
                string[] tokens = serverresponse.Split(new Char[] { '|' });
                if (tokens[0] == "LIST")
                {
                    statusBar1.Text = "Connected";
                    btnDisconnect.Enabled = true;
                }
                for (int n = 1; n < tokens.Length - 1; n++)
                    lbChatters.Items.Add(tokens[n].Trim(new char[] { '\r', '\n' }));
                this.Text = clientname + ": Connected to Chat Server";

            }
            catch (Exception e)
            {
                MessageBox.Show("Error Registering", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void ReceiveChat()
        {
            bool keepalive = true;
            while (keepalive)
            {
                try
                {
                    Byte[] buffer = new Byte[2048];
                    ns.Read(buffer, 0, buffer.Length);
                    string chatter = System.Text.Encoding.ASCII.GetString(buffer);

                    string[] tokens = chatter.Split(new Char[] { '|' });

                    if (tokens[0] == "CHAT")
                    {
                        rtbChatIn.AppendText(tokens[1]);
                        if (logging)
                            logwriter.WriteLine(tokens[1]);
                    }
                    if (tokens[0] == "PRIV")
                    {
                        rtbChatIn.AppendText("Private from ");
                        rtbChatIn.AppendText(tokens[1].Trim());
                        rtbChatIn.AppendText(tokens[2] + "\r\n");
                        if (logging)
                        {
                            logwriter.Write("Private from ");
                            logwriter.Write(tokens[1].Trim());
                            logwriter.WriteLine(tokens[2] + "\r\n");
                        }
                    }
                    if (tokens[0] == "JOIN")
                    {
                        rtbChatIn.AppendText(tokens[1].Trim());
                        rtbChatIn.AppendText(" has joined the Chat\r\n");
                        if (logging)
                        {
                            logwriter.WriteLine(tokens[1] + " has joined the Chat");
                        }
                        string newguy = tokens[1].Trim(new char[] { '\r', '\n' });
                        lbChatters.Items.Add(newguy);
                    }
                    if (tokens[0] == "GONE")
                    {
                        rtbChatIn.AppendText(tokens[1].Trim());
                        rtbChatIn.AppendText(" has left the Chat\r\n");
                        if (logging)
                        {
                            logwriter.WriteLine(tokens[1] + " has left the Chat");
                        }
                        lbChatters.Items.Remove(tokens[1].Trim(new char[] { '\r', '\n' }));
                    }
                    if (tokens[0] == "QUIT")
                    {
                        ns.Close();
                        clientsocket.Close();
                        keepalive = false;
                        statusBar1.Text = "Server has stopped";
                        connected = false;
                        btnSend.Enabled = false;
                        btnDisconnect.Enabled = false;
                    }
                }
                catch (Exception e) { }
            }
        }
       void QuitChat()
        {
            if (connected)
            {
                try
                {
                    string command = "GONE|" + clientname;
                    Byte[] outbytes = System.Text.Encoding.ASCII.GetBytes(command.ToCharArray());
                    ns.Write(outbytes, 0, outbytes.Length);
                    clientsocket.Close();
                }
                catch (Exception ex)
                {
                }
            }
            if (logging)
                logwriter.Close();

            if (receive != null && receive.IsAlive)
                receive.Abort();
            this.Text = "ChatClient";

        }
        private void StartStopLogging()
        {
            if (!logging)
            {
                if (!Directory.Exists("logs"))
                    Directory.CreateDirectory("logs");
                string fname = "logs\\" + DateTime.Now.ToString("ddMMyyHHmm") + ".txt";
                logwriter = new StreamWriter(new FileStream(fname, FileMode.OpenOrCreate,
                    FileAccess.Write));
                logging = true;
                btnLog.Text = "Stop Logging";
                statusBar1.Text = "Connected - Log on";
            }
            else
            {
                logwriter.Close();
                logging = false;
                btnLog.Text = "Start Logging";
                statusBar1.Text = "Connected - Log off";
            }

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (ChatOut.Text == "")
            {
                MessageBox.Show("Enter a name in the box before connecting", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
                clientname = ChatOut.Text;

            EstablishConnection();

            if (connected)
            {
                RegisterWithServer();
                receive = new Thread(new ThreadStart(ReceiveChat));
                receive.Start();
                btnSend.Enabled = true;
                btnConnect.Enabled = false;
                ChatOut.Text = "";
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string dclient = "";
                if (!privatemode)
                {
                    string pubcommand = "CHAT|" + clientname + ": " + ChatOut.Text + "\r\n";
                    Byte[] outbytes = System.Text.Encoding.ASCII.GetBytes(pubcommand.ToCharArray());
                    ns.Write(outbytes, 0, outbytes.Length);
                    ChatOut.Text = "";
                }
                else
                {
                    if (lbChatters.SelectedIndex == -1)
                    {
                        MessageBox.Show("Select a chatter name from the list", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    string destclient = lbChatters.SelectedItem.ToString();
                    string command = "PRIV|" + clientname + "|: " + ChatOut.Text + "|" + destclient;
                    Byte[] outbytes = System.Text.Encoding.ASCII.GetBytes(command.ToCharArray());
                    ns.Write(outbytes, 0, outbytes.Length);
                    ChatOut.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection with Server lost", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ns.Close();
                clientsocket.Close();
                if (receive != null && receive.IsAlive)
                    receive.Abort();
                connected = false;
                statusBar1.Text = "Disconnected";
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            QuitChat();
            btnDisconnect.Enabled = false;
            btnConnect.Enabled = true;
            btnSend.Enabled = false;
            ns.Close();
            clientsocket.Close();
            receive.Abort();
            connected = false;
            lbChatters.Items.Clear();
            statusBar1.Text = "Disconnected";
        }

        private void ChatOut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                if (connected)
                    btnSend_Click(sender, e);
                else
                    btnConnect_Click(sender, e);
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            StartStopLogging();
        }

        private void cbPrivate_CheckStateChanged(object sender, EventArgs e)
        {
            if (cbPrivate.Checked)
            {
                privatemode = true;
                lbChatters.SelectionMode = System.Windows.Forms.SelectionMode.One;
            }
            else
            {
                privatemode = false;
                lbChatters.SelectionMode = System.Windows.Forms.SelectionMode.None;
            }
        }
    }
}
