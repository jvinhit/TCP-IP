namespace ChatClient
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.rtbChatIn = new System.Windows.Forms.RichTextBox();
            this.ChatOut = new System.Windows.Forms.TextBox();
            this.lbChatters = new System.Windows.Forms.ListBox();
            this.cbPrivate = new System.Windows.Forms.CheckBox();
            this.btnLog = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbChatIn
            // 
            this.rtbChatIn.BackColor = System.Drawing.Color.Azure;
            this.rtbChatIn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbChatIn.ForeColor = System.Drawing.Color.Black;
            this.rtbChatIn.Location = new System.Drawing.Point(12, 13);
            this.rtbChatIn.Name = "rtbChatIn";
            this.rtbChatIn.ReadOnly = true;
            this.rtbChatIn.Size = new System.Drawing.Size(347, 226);
            this.rtbChatIn.TabIndex = 6;
            this.rtbChatIn.Text = "";
            // 
            // ChatOut
            // 
            this.ChatOut.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChatOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ChatOut.Location = new System.Drawing.Point(12, 244);
            this.ChatOut.Name = "ChatOut";
            this.ChatOut.Size = new System.Drawing.Size(347, 24);
            this.ChatOut.TabIndex = 1;
            this.ChatOut.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ChatOut_KeyPress);
            // 
            // lbChatters
            // 
            this.lbChatters.BackColor = System.Drawing.Color.LavenderBlush;
            this.lbChatters.Location = new System.Drawing.Point(365, 12);
            this.lbChatters.Name = "lbChatters";
            this.lbChatters.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbChatters.Size = new System.Drawing.Size(88, 225);
            this.lbChatters.TabIndex = 8;
            // 
            // cbPrivate
            // 
            this.cbPrivate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPrivate.ForeColor = System.Drawing.Color.Fuchsia;
            this.cbPrivate.Location = new System.Drawing.Point(459, 119);
            this.cbPrivate.Name = "cbPrivate";
            this.cbPrivate.Size = new System.Drawing.Size(80, 24);
            this.cbPrivate.TabIndex = 14;
            this.cbPrivate.Text = "Private";
            this.cbPrivate.CheckStateChanged += new System.EventHandler(this.cbPrivate_CheckStateChanged);
            // 
            // btnLog
            // 
            this.btnLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLog.Location = new System.Drawing.Point(459, 81);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(87, 26);
            this.btnLog.TabIndex = 13;
            this.btnLog.Text = "Save";
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisconnect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDisconnect.Location = new System.Drawing.Point(459, 46);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(87, 26);
            this.btnDisconnect.TabIndex = 12;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnConnect.Location = new System.Drawing.Point(459, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(87, 26);
            this.btnConnect.TabIndex = 11;
            this.btnConnect.Text = "Connect";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.ForeColor = System.Drawing.Color.Maroon;
            this.btnSend.Location = new System.Drawing.Point(365, 244);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(88, 24);
            this.btnSend.TabIndex = 15;
            this.btnSend.Text = "Send";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 279);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(551, 19);
            this.statusBar1.SizingGrip = false;
            this.statusBar1.TabIndex = 16;
            this.statusBar1.Text = "Disconnected";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ChatClient.Properties.Resources.Client_icon;
            this.pictureBox1.Location = new System.Drawing.Point(459, 149);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(87, 88);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(464, 248);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "GK_LTM";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 298);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.cbPrivate);
            this.Controls.Add(this.btnLog);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.lbChatters);
            this.Controls.Add(this.ChatOut);
            this.Controls.Add(this.rtbChatIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chat_Cilent";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbChatIn;
        private System.Windows.Forms.TextBox ChatOut;
        private System.Windows.Forms.ListBox lbChatters;
        private System.Windows.Forms.CheckBox cbPrivate;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}

