using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketServer
{
    public partial class Form1 : Form
    {
        //声明一个Socket公共变量
        private Socket mainsocket;
        //用一个指示是否将初始状态设置为终止的布尔值初始化 ManualResetEvent 类的新实例。
        public ManualResetEvent allDone = new ManualResetEvent(false);
        private int clientcount = 0;//用于统计连接成功的客户端数量
        private DateTime dtStart = new DateTime();
        //创建一个List集合，用于存放当前连接的客户端信息
        private ArrayList workSocketList = ArrayList.Synchronized(new ArrayList());
        //创建一个委托
        public delegate void UpdateClientListCallBack();
        public delegate void UpdateRichEditCallback(string text);
        public bool flag = false;//判断是不是由关闭Socket引起的回调
        public AsyncCallback pfnWorkerCallBack;

        //可用于准确测量运行时间
        Stopwatch stopwatch = new Stopwatch();


        public Form1()
        {
            InitializeComponent();
            pnl_TextInfo.Visible = false;
            txt_IP.Text = GetIP();
        }
        //开始监听
        private void btn_StartListen_Click(object sender, EventArgs e)
        {
            try
            {
                if(txt_Port.Text=="")
                {
                    MessageBox.Show("请输入端口号！");
                    return;
                }

                int port = Convert.ToInt32(txt_Port.Text.Trim());

                //创建监听Socket...
                mainsocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                IPEndPoint iplocal = new IPEndPoint(IPAddress.Any, port);
                //绑定本地IP
                mainsocket.Bind(iplocal);
                //开始监听
                mainsocket.Listen(10);
                //设置无信号状态事件,将事件状态设置为非终止状态，导致线程阻止
                //allDone.Reset();
                ////开始一个异步操作来接收一个传入的连接尝试
                //mainsocket.BeginAccept(new AsyncCallback(OnClientConnect), mainsocket);
                //弹出一个提示框，提示连接中
                //pnl_TextInfo.Visible = true;
                ////等待连接创建,阻止当前线程，知道收到信号
                //allDone.WaitOne();

                Thread th = new Thread(ListenSocket);
                th.IsBackground = true;
                th.Start(mainsocket);

               // pnl_TextInfo.Visible = false;
                btn_StartListen.Enabled = false;
                btn_StopListen.Enabled = true;
               // lbl_client.Text = (clientcount - 1).ToString();
            }
            catch(SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }
        //采用多线程监听，可避免线程阻塞
        private void ListenSocket(object o)
        {
            Socket socket = o as Socket;
            allDone.Reset();
            //开始一个异步操作来接收一个传入的连接尝试
            socket.BeginAccept(new AsyncCallback(OnClientConnect), mainsocket);          
            //等待连接创建,阻止当前线程，知道收到信号
            allDone.WaitOne();
        }

        //这是一个回调方法，当客户端连接成功时，该方法会被调用
        private void OnClientConnect(IAsyncResult ar)
        {
            try
            {
                //将事件状态设置为终止状态，允许一个或多个等待线程继续
                allDone.Set();

                Socket worksocket = mainsocket.EndAccept(ar);

                //每当有客户端成功连接，clientcount会自增1
                Interlocked.Increment(ref clientcount);               

                if(clientcount==1)
                {
                    lock(this)
                    {                    
                        //开始或继续测量某个时间间隔的运行时间
                        stopwatch.Start();
                        dtStart = DateTime.Now;
                        //记录运行日志
                        writeLog("Server Start Socket Connect Time"+ dtStart.ToString("yyyy-MM-dd HH:mm:ss fff"));
                    }
                }
                //将连接的客户端添加到List
                workSocketList.Add(worksocket);
                //给客户端返回一个连接成功的提示信息
                string msg = "连接成功！\n";
                SendMsgToClient(msg,clientcount);
                //更新连接信息展示框
                UpdateClientListControl();
                //让work socket对刚刚连接的客户端进行进一步的处理,等待客户端发送信息
                WaiForData(worksocket, clientcount);
                //让主socket返回并等待其他试图连接的客户端
                mainsocket.BeginAccept(new AsyncCallback(OnClientConnect), null);
                //等待连接
                allDone.WaitOne();
            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\n OnClientConnection: Socket has been closed\n");
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }
        //等待客户端连接
        private void WaiForData(Socket worksocket,int clientNumber)
        {
            try
            {
                if(pfnWorkerCallBack==null)
                {
                    //指定回调函数被调用，当被连接的客户端有任何写入活动时
                    pfnWorkerCallBack = new AsyncCallback(OnDataReveiced);
                }
                Socketpacket theSocket = new Socketpacket(worksocket, clientNumber);
                worksocket.BeginReceive(theSocket.databuffer, 0, theSocket.databuffer.Length, SocketFlags.None, pfnWorkerCallBack, theSocket);
            }
            catch(SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }
        
        private void OnDataReveiced(IAsyncResult ar)
        {
            Socketpacket socketpacket = (Socketpacket)ar.AsyncState;
            string ip = "";
            if (socketpacket!=null && !flag)
            {
                ip = (socketpacket.currentsocket.RemoteEndPoint as IPEndPoint).Address.ToString();
            }
            try
            {
                int irx = socketpacket.currentsocket.EndReceive(ar);
                char[] chars = new char[irx + 1];
                Decoder d = UTF8Encoding.UTF8.GetDecoder();
                int charlen = d.GetChars(socketpacket.databuffer, 0, irx, chars, 0);

                String sdata = new String(chars);
                sdata = sdata.Replace("\0", "");
                string msg = "" + ip + ":";
                AppendToRichEditControl(msg +"\r\n"+ sdata);

                if(txt_ConnectNum.Text!="")
                {
                    if (clientcount ==int.Parse(txt_ConnectNum.Text))
                    {
                        string msgTime = "Server End Socket Action Time:";
                        lock (this)
                        {
                            stopwatch.Stop();
                            //lblTime.Text = stopwatch.Elapsed.Seconds.ToString();
                            int itime = stopwatch.Elapsed.Milliseconds;

                            //msgTime += stopwatch.Elapsed.Seconds.ToString()+"--"+itime.ToString();
                            msgTime += DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff");
                        }
                        writeLog(msgTime);
                        writeLog();
                        lbl_Time.Text = msgTime;
                    }
                    
                }               

                WaiForData(socketpacket.currentsocket, socketpacket.ClientNumber);
            }
            catch (ObjectDisposedException)
            {
                Debugger.Log(0, "1", "\nOnDataReceived: Socket has been closed\n");
            }
            catch(SocketException se)
            {
                if(se.ErrorCode==10054)
                {
                    string msg = "Client:" + ip + " Disconnected" + "\n";
                    AppendToRichEditControl(msg);
                    workSocketList[socketpacket.ClientNumber-1] =null;
                    //更新连接信息框
                    UpdateClientListControl();                
                }
                else
                {
                    MessageBox.Show(se.Message);
                }
            }
        }

        //更新信息接收框数据
        private void AppendToRichEditControl(string v)
        {
            if(InvokeRequired)
            {
                object[] plist = { v };
                txt_ReceivedMessage.BeginInvoke(new UpdateRichEditCallback(OnUpdateRichEdit), plist);
            }
            else
            {
                OnUpdateRichEdit(v);
            }
        }

        private void OnUpdateRichEdit(string msg)
        {
            txt_ReceivedMessage.AppendText(msg + "\r\n");
        }

        //list_ConnectClientInfo控件展示信息
        private void UpdateClientList()
        {
            list_ConnectClientInfo.Items.Clear();
            for(int i=0;i<workSocketList.Count;i++)
            {
                Socket socket = (Socket)workSocketList[i];
                if(socket!=null)
                {
                    string clientIp = (socket.RemoteEndPoint as IPEndPoint).Address.ToString();
                    string port = (socket.RemoteEndPoint as IPEndPoint).Port.ToString();
                    if (socket.Connected)
                    {
                        list_ConnectClientInfo.Items.Add(clientIp + ":" + port);
                    }
                }               
            }
            lbl_client.Text = (clientcount - 1).ToString();
        }

        private void UpdateClientListControl()
        {
            if (InvokeRequired)
            {
                //这是从一个线程中调用的，而不是创建的线程控件
                //我们不能在这个线程上更新GUI。
                //所有GUI控件都要由main（GUI）线程更新。
                //因此我们将在控件上使用invoke方法
                //当主线程是空闲的
                //在UI线程上做UI更新
                list_ConnectClientInfo.BeginInvoke(new UpdateClientListCallBack(UpdateClientList), null);
            }
            else
            {
                //主线程创建的控件，可以直接更新
                UpdateClientList();
            }
        }

        private void SendMsgToClient(string msg, int clientcount)
        {
            //将信息转化成字节数组
            byte[] bydata = UTF8Encoding.UTF8.GetBytes(msg);
            //获取刚连接成功的Socket
            Socket socket = (Socket)workSocketList[clientcount - 1];
            socket.BeginSend(bydata, 0, bydata.Length, 0, new AsyncCallback(SendCallback), socket);
        }

        private void SendCallback(IAsyncResult ar)
        {
            Socket client = (Socket)ar.AsyncState;
            //完成数据发送
            int n = client.EndSend(ar);
        }

        //写系统全局错误日志
        private void writeLog(string str)
        {
            string strlogFile = Application.StartupPath + "\\" + "ServerSocketLog";
            if(!Directory.Exists(strlogFile))
            {
                Directory.CreateDirectory(strlogFile);
            }
            string strLogFileName = "\\" + DateTime.Today.ToString("yyyymmdd") + "Log.log";
            using (StreamWriter sw = new StreamWriter(strlogFile + strLogFileName, true))
            {
                string str2 = DateTime.Now.ToString("hh:mm:ss") + "-" + str;
                sw.WriteLine(str2);
                sw.Close();
            }
        }
        private void writeLog()
        {
            string strlogfile = Application.StartupPath + "\\" + "ServerSocketLog";
            if(!Directory.Exists(strlogfile))
            {
                Directory.CreateDirectory(strlogfile);
            }

            string strlogfilename = "\\" + DateTime.Today.ToString("yyyyMMdd") + "ClientConnection.log";
            lock(this)
            {
                using (StreamWriter sw = new StreamWriter(strlogfile + strlogfilename, true))
                {
                    for(int i=0;i<workSocketList.Count;i++)
                    {                      
                        Socket socket = (Socket)workSocketList[i];
                        string clientIp = (socket.RemoteEndPoint as IPEndPoint).Address.ToString();
                        string clientport = (socket.RemoteEndPoint as IPEndPoint).Port.ToString();
                        if(socket.Connected)
                        {
                            string str2 = DateTime.Now.ToString("hh:mm:ss") + "-Client-" + clientIp + ":" + clientport;
                            sw.WriteLine(str2);
                        }
                    }
                }
            }
        }
        //
        public class Socketpacket
        {
            public Socketpacket (Socket socket,int clientNumber)
            {
                currentsocket = socket;
                ClientNumber = clientNumber;
            }
            public int ClientNumber;
            public Socket currentsocket;
            public byte[] databuffer=new byte[1024];
        }
        //发送信息到客户端
        private void btn_SendMessage_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = txt_SendMessageInfo.Text.Trim();
                byte[] bydata = UTF8Encoding.UTF8.GetBytes(msg);
                Socket socket1 = null;
                //for(int i=0;i<workSocketList.Count;i++)
                //{
                int i = Convert.ToInt32(lbl_client.Text);
                socket1 = (Socket)workSocketList[i];
                if (socket1 != null)
                {
                    if (socket1.Connected)
                    {
                        socket1.Send(bydata);
                    }
                }
                //}
                txt_SendMessageInfo.Clear();
                msg = DateTime.Now.ToString() + "\r\n" + msg;
                AppendToRichEditControl(msg);
            }
            catch(SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }
        //停止监听
        private void btn_StopListen_Click(object sender, EventArgs e)
        {
            CloseSocket();
            btn_StartListen.Enabled = true;
            btn_StopListen.Enabled = false;
        }
        //关闭Socket
        private void CloseSocket()
        {
            if(mainsocket!=null)
            {
                mainsocket.Close();
            }
            Socket socket2 = null;
            for(int i=0;i<workSocketList.Count;i++)
            {
                socket2 = (Socket)workSocketList[i];
                if(socket2!=null)
                {
                    socket2.Close();
                    socket2 = null;
                }
            }
        }
        //获取本机IP
        private string GetIP()
        {
            String strHostName = Dns.GetHostName();
            IPHostEntry ip = Dns.GetHostEntry(strHostName);
            String IPstr = "";
            Regex pattern = new Regex (@"\d+\.\d+\.\d+\.\d+");
            foreach (IPAddress ipaddr in ip.AddressList)
            {
                if(pattern.IsMatch(ipaddr.ToString()))
                {
                    IPstr=ipaddr.ToString();
                    return IPstr;
                }
                else
                   continue;
            }
            return IPstr;
        }
        //关闭
        private void btn_Close_Click(object sender, EventArgs e)
        {
            flag = true;
            allDone.Close();
            CloseSocket();
            Close();
        }
        //清空信息接收框
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txt_ReceivedMessage.Clear();
        }

        //选择需要发送信息的客户端
        private void list_ConnectClientInfo_Click(object sender, EventArgs e)
        {
            lbl_client.Text = list_ConnectClientInfo.SelectedIndex.ToString();
        }
    }
}
