using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace PcControlBoard
{
    class TCPServer
    {
        private static readonly int MAX_BUFFER_SIZE = 65536;// 65536;//2048
        private int port = 2233;
        private static TcpListener serverSocket = null;
        private static TcpClient client = null;
        private NetworkStream netStream;
        private BinaryWriter bWriter;
        private BinaryReader bReader;
        private Boolean clientError = true;
        private FormControlBoard form;
        private Boolean lowResolution = false;

        public TCPServer(FormControlBoard form)     //int port)
        {
            this.form = form;
            // this.port = port;
            Debug.WriteLine("start TCPServer...");
            port = Properties.Settings.Default.Port;
            //Debug.WriteLine("Port: " + port);
            try
            {
                IPEndPoint ip = new IPEndPoint(IPAddress.Any, port);
                //serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //serverSocket.Bind(ip);
                //serverSocket.Listen(100);
                serverSocket = new TcpListener(IPAddress.Any, port);
                serverSocket.Start();
            }
            catch (Exception e) { Debug.WriteLine("Error!!! " + e.StackTrace); }
            ClientAccept();
        }

        private void ClientAccept()
        {
            Thread clAcThread = new Thread(new ThreadStart(ClientAcceptThread));
            clAcThread.Start();
        }
        public void ClientAcceptThread()
        {
            try
            {
                client = null;
                netStream = null;
                bWriter = null;
                bReader = null;
                clientError = true;
                form.SetClientName("No Client");
                Console.WriteLine("Waiting for a client...");
                client = serverSocket.AcceptTcpClient();

                netStream = client.GetStream();
                bWriter = new BinaryWriter(netStream);
                bReader = new BinaryReader(netStream);

                clientError = false;
                ReceiveData();
                Thread.Sleep(100);   //200
                SendData("<connected>");
            }
            catch (Exception e)
            { Debug.WriteLine(e.StackTrace); }
        }

        public void SendData(String data)
        {
            if (client != null)
                WriteString(bWriter, data);
            Debug.WriteLine("SEND_DATA:"+data);
        }
        public void SendLayout(String btnString, Bitmap bmp)
        {
            if (client != null)
            {
                if(lowResolution) bmp = new Bitmap(bmp, 50, 50);
                MemoryStream memory = new MemoryStream();
                bmp.Save(memory, ImageFormat.Bmp);
                string base64 = Convert.ToBase64String(memory.ToArray());
                memory.Close();
                memory.Dispose();

                SendData(btnString + base64);
                //Debug.WriteLine(btnString + base64);
            }
        }

        private void ReceiveData()
        {
            Thread DataReceiveThread = new Thread(new ThreadStart(ReceiveDataThread));
            DataReceiveThread.Start();
        }

        public void ReceiveDataThread()
        {
            String receiveMessage = null;
            Debug.WriteLine(">>RECEIVE_DATA_THREAD: START<<");
            while (!clientError)
            {
                try
                {
                    if ((receiveMessage = ReadString(bReader)) != "")
                    {
                        Debug.WriteLine("<client>" + ">: ");
                        Debug.WriteLine(receiveMessage);

                        //if (receiveMessage.Equals("<sendLayout>"))  // in update Process?
                        //    form.SendButtons();
                            form.UpdateMessage(receiveMessage);
                        // if (receiveMessage.Equals("check"))
                        //     sendMessage = "<check>";
                    }
                    else if (ReadString(bReader) == null)
                    {
                        Debug.WriteLine("Client has disconected!!!");
                        clientError = true;
                        ClientAccept();
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine("reseive clientmsg failed!!! => " + e.Message);
                    clientError = true;
                    ClientAccept();
                }
            }
        }


        // Write Data out
        public static void WriteString(BinaryWriter os, string value)
        {
            if (value != null)
            {
                byte[] array = System.Text.Encoding.UTF8.GetBytes(value);
                WriteBuffer(os, array);
            }
            else
            {
                WriteInt(os, 0);
            }
        }
        public static void WriteBuffer(BinaryWriter os, byte[] array)
        {
            if ((array != null) && (array.Length > 0) )//&& (array.Length < MAX_BUFFER_SIZE))
            {
                Debug.WriteLine(array.Length);

                WriteInt(os, array.Length);
                os.Write(array);
            }
            else
            {
                WriteInt(os, 0);
            }
        }
        public static void WriteInt(BinaryWriter outStream, int value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            //  Array.Reverse(buffer);
            try
            {
                outStream.Write(buffer);
            }
            catch (Exception e) { Debug.WriteLine("   ERROR!!!   " + e.Message + "     " + e.StackTrace + "    ERROR ENDE          "); }
        }


        // Read Data in
        public static String ReadString(BinaryReader br)
        {
            String ret = null;
            int len = ReadInt(br);
           // Debug.WriteLine("READ_IN: len=" + len);
            if ((len == 0) || (len > MAX_BUFFER_SIZE))
            {
                ret = "";
               // Debug.WriteLine("READ_IN: len=0=" + len);
            }
            else
            {
                Debug.WriteLine(len);
                byte[] buffer = new byte[len];
                //Debug.Write("READ_IN: len>0=" + len);
                int offset = 0;
                int readBytes;
                do
                {
                    readBytes = br.Read(buffer, offset, buffer.Length - offset);
                    //Debug.WriteLine("READ_IN: ReadBytes:" + readBytes);
                    offset += readBytes;
                } while (readBytes > 0 && offset < buffer.Length);

                if (offset < buffer.Length)
                {
                    Debug.WriteLine("READ_IN: Offset-Error!");
                    throw new EndOfStreamException();
                }
                //ret = new String(buffer, CharSet.Auto);
                ret = Encoding.UTF8.GetString(buffer);
            }
            return (ret);
        }

        public static int ReadInt(BinaryReader br)
        {
            int ret = 0;
            byte[] intAsBytes = new byte[4];
            intAsBytes = br.ReadBytes(intAsBytes.Length);

            ret = ConvertBytesToInt(intAsBytes);
            return (ret);
        }

        public static int ConvertBytesToInt(byte[] array)
        {
            int rv = 0;
            Array.Reverse(array);       //!!!Array umdrehen!!!
            for (int x = 3; x >= 0; x--)
            {
                int bv = array[x];
                if (x < 3 & bv < 0)
                    bv += 256;
                //rv *= 256;
                rv = rv << 8;
                rv += bv;
            }
            //Debug.WriteLine("rv int: " + rv);
            return rv;
        }


    }
}
