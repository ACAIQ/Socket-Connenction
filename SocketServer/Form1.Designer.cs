namespace SocketServer
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_IP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Port = new System.Windows.Forms.TextBox();
            this.btn_StartListen = new System.Windows.Forms.Button();
            this.btn_StopListen = new System.Windows.Forms.Button();
            this.txt_SendMessageInfo = new System.Windows.Forms.TextBox();
            this.btn_SendMessage = new System.Windows.Forms.Button();
            this.txt_ReceivedMessage = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.list_ConnectClientInfo = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_ConnectNum = new System.Windows.Forms.TextBox();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.lbl_Time = new System.Windows.Forms.Label();
            this.pnl_TextInfo = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_client = new System.Windows.Forms.Label();
            this.pnl_TextInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port:";
            // 
            // txt_IP
            // 
            this.txt_IP.Location = new System.Drawing.Point(75, 15);
            this.txt_IP.Name = "txt_IP";
            this.txt_IP.ReadOnly = true;
            this.txt_IP.Size = new System.Drawing.Size(201, 21);
            this.txt_IP.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "Send Message To Client";
            // 
            // txt_Port
            // 
            this.txt_Port.Location = new System.Drawing.Point(75, 49);
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.Size = new System.Drawing.Size(68, 21);
            this.txt_Port.TabIndex = 4;
            this.txt_Port.Text = "8000";
            // 
            // btn_StartListen
            // 
            this.btn_StartListen.BackColor = System.Drawing.Color.Blue;
            this.btn_StartListen.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_StartListen.ForeColor = System.Drawing.Color.Yellow;
            this.btn_StartListen.Location = new System.Drawing.Point(346, 15);
            this.btn_StartListen.Name = "btn_StartListen";
            this.btn_StartListen.Size = new System.Drawing.Size(132, 55);
            this.btn_StartListen.TabIndex = 5;
            this.btn_StartListen.Text = "StartListening";
            this.btn_StartListen.UseVisualStyleBackColor = false;
            this.btn_StartListen.Click += new System.EventHandler(this.btn_StartListen_Click);
            // 
            // btn_StopListen
            // 
            this.btn_StopListen.BackColor = System.Drawing.Color.Red;
            this.btn_StopListen.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_StopListen.ForeColor = System.Drawing.Color.Yellow;
            this.btn_StopListen.Location = new System.Drawing.Point(503, 15);
            this.btn_StopListen.Name = "btn_StopListen";
            this.btn_StopListen.Size = new System.Drawing.Size(132, 55);
            this.btn_StopListen.TabIndex = 6;
            this.btn_StopListen.Text = "StopListening";
            this.btn_StopListen.UseVisualStyleBackColor = false;
            this.btn_StopListen.Click += new System.EventHandler(this.btn_StopListen_Click);
            // 
            // txt_SendMessageInfo
            // 
            this.txt_SendMessageInfo.AcceptsReturn = true;
            this.txt_SendMessageInfo.Location = new System.Drawing.Point(14, 101);
            this.txt_SendMessageInfo.Multiline = true;
            this.txt_SendMessageInfo.Name = "txt_SendMessageInfo";
            this.txt_SendMessageInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_SendMessageInfo.Size = new System.Drawing.Size(276, 70);
            this.txt_SendMessageInfo.TabIndex = 7;
            // 
            // btn_SendMessage
            // 
            this.btn_SendMessage.Location = new System.Drawing.Point(14, 177);
            this.btn_SendMessage.Name = "btn_SendMessage";
            this.btn_SendMessage.Size = new System.Drawing.Size(276, 26);
            this.btn_SendMessage.TabIndex = 8;
            this.btn_SendMessage.Text = "Send Message";
            this.btn_SendMessage.UseVisualStyleBackColor = true;
            this.btn_SendMessage.Click += new System.EventHandler(this.btn_SendMessage_Click);
            // 
            // txt_ReceivedMessage
            // 
            this.txt_ReceivedMessage.BackColor = System.Drawing.SystemColors.ControlText;
            this.txt_ReceivedMessage.ForeColor = System.Drawing.SystemColors.Menu;
            this.txt_ReceivedMessage.Location = new System.Drawing.Point(346, 101);
            this.txt_ReceivedMessage.Multiline = true;
            this.txt_ReceivedMessage.Name = "txt_ReceivedMessage";
            this.txt_ReceivedMessage.ReadOnly = true;
            this.txt_ReceivedMessage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_ReceivedMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_ReceivedMessage.Size = new System.Drawing.Size(289, 243);
            this.txt_ReceivedMessage.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(344, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "Message Received From Client";
            // 
            // list_ConnectClientInfo
            // 
            this.list_ConnectClientInfo.FormattingEnabled = true;
            this.list_ConnectClientInfo.ItemHeight = 12;
            this.list_ConnectClientInfo.Location = new System.Drawing.Point(14, 221);
            this.list_ConnectClientInfo.Name = "list_ConnectClientInfo";
            this.list_ConnectClientInfo.Size = new System.Drawing.Size(276, 124);
            this.list_ConnectClientInfo.TabIndex = 11;
            this.list_ConnectClientInfo.Click += new System.EventHandler(this.list_ConnectClientInfo_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "Connected Client";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 367);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "Largest Connect Num:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 396);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "Test Time:";
            // 
            // txt_ConnectNum
            // 
            this.txt_ConnectNum.Location = new System.Drawing.Point(137, 364);
            this.txt_ConnectNum.Name = "txt_ConnectNum";
            this.txt_ConnectNum.Size = new System.Drawing.Size(153, 21);
            this.txt_ConnectNum.TabIndex = 15;
            // 
            // btn_Clear
            // 
            this.btn_Clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_Clear.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Clear.ForeColor = System.Drawing.Color.Red;
            this.btn_Clear.Location = new System.Drawing.Point(346, 350);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(132, 55);
            this.btn_Clear.TabIndex = 16;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = false;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.btn_Close.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_Close.Location = new System.Drawing.Point(503, 350);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(132, 55);
            this.btn_Close.TabIndex = 17;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // lbl_Time
            // 
            this.lbl_Time.AutoSize = true;
            this.lbl_Time.ForeColor = System.Drawing.Color.Red;
            this.lbl_Time.Location = new System.Drawing.Point(78, 396);
            this.lbl_Time.Name = "lbl_Time";
            this.lbl_Time.Size = new System.Drawing.Size(0, 12);
            this.lbl_Time.TabIndex = 18;
            // 
            // pnl_TextInfo
            // 
            this.pnl_TextInfo.Controls.Add(this.label8);
            this.pnl_TextInfo.Location = new System.Drawing.Point(194, 130);
            this.pnl_TextInfo.Name = "pnl_TextInfo";
            this.pnl_TextInfo.Size = new System.Drawing.Size(247, 100);
            this.pnl_TextInfo.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(66, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "等待连接中...";
            // 
            // lbl_client
            // 
            this.lbl_client.AutoSize = true;
            this.lbl_client.Location = new System.Drawing.Point(194, 57);
            this.lbl_client.Name = "lbl_client";
            this.lbl_client.Size = new System.Drawing.Size(0, 12);
            this.lbl_client.TabIndex = 20;
            this.lbl_client.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 452);
            this.Controls.Add(this.lbl_client);
            this.Controls.Add(this.pnl_TextInfo);
            this.Controls.Add(this.lbl_Time);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.txt_ConnectNum);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.list_ConnectClientInfo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_ReceivedMessage);
            this.Controls.Add(this.btn_SendMessage);
            this.Controls.Add(this.txt_SendMessageInfo);
            this.Controls.Add(this.btn_StopListen);
            this.Controls.Add(this.btn_StartListen);
            this.Controls.Add(this.txt_Port);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_IP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "SocketServer";
            this.pnl_TextInfo.ResumeLayout(false);
            this.pnl_TextInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_IP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Port;
        private System.Windows.Forms.Button btn_StartListen;
        private System.Windows.Forms.Button btn_StopListen;
        private System.Windows.Forms.TextBox txt_SendMessageInfo;
        private System.Windows.Forms.Button btn_SendMessage;
        private System.Windows.Forms.TextBox txt_ReceivedMessage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox list_ConnectClientInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_ConnectNum;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label lbl_Time;
        private System.Windows.Forms.Panel pnl_TextInfo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_client;
    }
}

