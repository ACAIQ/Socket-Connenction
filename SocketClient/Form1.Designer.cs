namespace SocketClient
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
            this.txt_Info = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_IP = new System.Windows.Forms.TextBox();
            this.txt_Port = new System.Windows.Forms.TextBox();
            this.btn_Connection = new System.Windows.Forms.Button();
            this.txt_msg = new System.Windows.Forms.TextBox();
            this.btn_Send = new System.Windows.Forms.Button();
            this.btn_Break = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_Info
            // 
            this.txt_Info.Location = new System.Drawing.Point(1, 1);
            this.txt_Info.Multiline = true;
            this.txt_Info.Name = "txt_Info";
            this.txt_Info.ReadOnly = true;
            this.txt_Info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Info.Size = new System.Drawing.Size(543, 236);
            this.txt_Info.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "端口号：";
            // 
            // txt_IP
            // 
            this.txt_IP.Location = new System.Drawing.Point(34, 264);
            this.txt_IP.Name = "txt_IP";
            this.txt_IP.Size = new System.Drawing.Size(127, 21);
            this.txt_IP.TabIndex = 3;
            // 
            // txt_Port
            // 
            this.txt_Port.Location = new System.Drawing.Point(242, 264);
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.Size = new System.Drawing.Size(104, 21);
            this.txt_Port.TabIndex = 4;
            // 
            // btn_Connection
            // 
            this.btn_Connection.Location = new System.Drawing.Point(420, 262);
            this.btn_Connection.Name = "btn_Connection";
            this.btn_Connection.Size = new System.Drawing.Size(113, 23);
            this.btn_Connection.TabIndex = 5;
            this.btn_Connection.Text = "连接";
            this.btn_Connection.UseVisualStyleBackColor = true;
            this.btn_Connection.Click += new System.EventHandler(this.btn_Connection_Click);
            // 
            // txt_msg
            // 
            this.txt_msg.Location = new System.Drawing.Point(1, 300);
            this.txt_msg.Name = "txt_msg";
            this.txt_msg.Size = new System.Drawing.Size(338, 21);
            this.txt_msg.TabIndex = 6;
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(420, 300);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(113, 23);
            this.btn_Send.TabIndex = 7;
            this.btn_Send.Text = "发送";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // btn_Break
            // 
            this.btn_Break.Location = new System.Drawing.Point(316, 333);
            this.btn_Break.Name = "btn_Break";
            this.btn_Break.Size = new System.Drawing.Size(113, 23);
            this.btn_Break.TabIndex = 8;
            this.btn_Break.Text = "断开连接";
            this.btn_Break.UseVisualStyleBackColor = true;
            this.btn_Break.Click += new System.EventHandler(this.btn_Break_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 368);
            this.Controls.Add(this.btn_Break);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.txt_msg);
            this.Controls.Add(this.btn_Connection);
            this.Controls.Add(this.txt_Port);
            this.Controls.Add(this.txt_IP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Info);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Info;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_IP;
        private System.Windows.Forms.TextBox txt_Port;
        private System.Windows.Forms.Button btn_Connection;
        private System.Windows.Forms.TextBox txt_msg;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.Button btn_Break;
    }
}

