using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketClient
{
    public partial class Form1 : Form
    {
        //创建客户端连接字和负责监听服务端请求的线程
        Thread threadclient = null;
        Socket socketclient = null;
        bool flag = false;//用于判断客户端当前是否处于连接状态
        public Form1()
        {
            InitializeComponent();

            //设置对话框起始位置
            StartPosition = FormStartPosition.CenterScreen;
            //关闭对文本框的非法线程操作检查
            TextBox.CheckForIllegalCrossThreadCalls = false;

            txt_IP.Text = "192.168.233.1";
            txt_Port.Text = "8000";
        }

        private void btn_Connection_Click(object sender, EventArgs e)
        {
            if (txt_IP.Text == "" || txt_Port.Text == "")
            {
                txt_Info.Text= "请输入IP和端口号！";
                return;
            }
            //如果客户端当前正处于连接状态，再次连接则先关闭之前的连接
            if (flag)
            {
                btn_Break_Click(null, null);
            }
            //定义一个套接字监听
            socketclient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //获取ip与端口号
            IPAddress addr = IPAddress.Parse(txt_IP.Text);
            int port = Convert.ToInt32(txt_Port.Text);

            //将IP与端口绑定在网络节点上
            IPEndPoint point = new IPEndPoint(addr, port);

            try
            {              
                socketclient.Connect(point);
                txt_Info.Clear();
                flag = true;
            }
            catch(Exception ex)
            {
                txt_Info.AppendText("连接失败\r\n" + ex.Message);
                return;
            }
            threadclient = new Thread(Recv);
            threadclient.IsBackground = true;//将该线程设为后台线程
            threadclient.Start();
        }
        //接收服务端发来的消息
        private void Recv()
        {
            int x = 0;
            //持续监听服务端消息
            while(true)
            {
                try
                {
                  //  socketclient.Be
                    byte[] bytemsg = new byte[1024];
                    //将客户端连接字收到的数据存入内存缓冲区，并获取长度
                    int length = socketclient.Receive(bytemsg);
                    //char[] chars = new char[length + 1];
                    ////将连接字获取到的字符数组转换为人可识别的字符串
                    //System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();
                    //int charlen = d.GetChars(bytemsg, 0, length, chars, 0);
                    string strmsg = Encoding.UTF8.GetString(bytemsg, 0, length);
                    //char[] strmsg = Encoding.UTF8.GetChars(bytemsg);
                    if (x==1)
                    {
                        this.txt_Info.AppendText("服务器：" + GetCurrentTime() + "\r\n" + strmsg + "\r\n\n");
                        
                    }
                    else
                    {
                        this.txt_Info.AppendText(strmsg + "\r\n\n");
                        x = 1;
                    }
                }
                catch(Exception ex)
                {
                    this.txt_Info.AppendText(ex.Message);
                    break;
                }
            }
        }
        //获取系统时间
        private DateTime GetCurrentTime()
        {
            DateTime currentTime = new DateTime();
            currentTime = DateTime.Now;
            return currentTime;
        }
        //发送字符信息到服务端的方法  
        private void ClientSendMsg(string sendMsg)
        {
            //将输入的内容字符串转化为字节数组
            byte[] arrsendmsg = Encoding.UTF8.GetBytes(sendMsg);
            socketclient.Send(arrsendmsg);

            //将发送的信息追加到聊天内容文本框中     
            this.txt_Info.AppendText(GetCurrentTime() + "\r\n" + sendMsg + "\r\n");
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            ClientSendMsg(txt_msg.Text.Trim());
            txt_msg.Clear();
        }

        private void btn_Break_Click(object sender, EventArgs e)
        {
            socketclient.Close();
            flag = false;
        }
    }

    public class SocketPacket
    {
        public SocketPacket(Socket socket)
        {
            currentSocket = socket;
        }
        public Socket currentSocket;
        //定义一个1M的内存缓冲区，用于临时存储收到的消息
        public byte[] dataBuffer = new byte[1024 * 1024];
    }
}
