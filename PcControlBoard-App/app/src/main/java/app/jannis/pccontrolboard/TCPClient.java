package app.jannis.pccontrolboard;

import android.os.SystemClock;
import android.util.Log;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.InetSocketAddress;
import java.net.Socket;
import java.nio.charset.Charset;
import java.util.ArrayList;
import java.util.List;


public class TCPClient {
    private static int MAX_BUFFER_SIZE = 2000000;//65536;// 65536;//2048
    private String receiveMessage = "";
    public boolean running = false;
    private int delay = 5;
    private long lastStringSent = 0;
    private Thread receiveThread;
    private Thread messageQueue;
    public MainActivity mainActivity;
    public List<String> stringQueue;
    public Socket socket;
    private int tries = 0;

    DataOutputStream dOutStream;
    DataInputStream dInStream;

    public TCPClient(MainActivity mainActivity) {
        this.mainActivity = mainActivity;
        stringQueue = new ArrayList();
    }

    public void connect(String serverAddress, int serverPort) {
        try {
            this.socket = new Socket();
            this.socket.connect(new InetSocketAddress(serverAddress, serverPort), 1000);
            this.socket.setSoTimeout(0);
            // this.main.dismissDialog();
            this.running = true;
            dOutStream = new DataOutputStream(socket.getOutputStream());
            dInStream = new DataInputStream(socket.getInputStream());
            run();
        } catch (Exception e) {
            if (this.tries < 10) {
                this.tries++;
                SystemClock.sleep(1000);
                connect(serverAddress, serverPort);
                return;
            }
            e.printStackTrace();
            //   this.main.dismissDialog();
            close();
        }
    }

    public void close() {
        this.running = false;
        try {
            this.socket.setSoTimeout(1);
            this.socket.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }


    public void sendString(final String s) {
        new Thread(new Runnable() {
            public void run() {
                try {
                    WriteString(dOutStream, s);
                    Log.i("TCP:sendString: ", s);
                } catch (IOException e) {
                    e.printStackTrace();
                    close();
                    mainActivity.disconnected();
                }
            }
        }).start();
    }


    public void run() {
       /* messageQueue = new Thread(new Runnable() {
            public void run() {
                while (running) {
                    try {
                        if (stringQueue.size() > 0) {
                            sendString((String) stringQueue.get(0));
                            stringQueue.remove(0);
                        }
                        Thread.sleep(delay);
                    } catch (Exception e) {
                        return;
                    }
                }
            }
        });*/
        receiveThread = new Thread(new Runnable() {

            public void run() {
                Log.i("TCP", "ReceiveThread start");
                while (running) {
                    try {
                        if ((receiveMessage = ReadString(dInStream)) != null) {
                            Log.i("READ_IN_THREAD",receiveMessage);
                            // if (receiveMessage.contains("<end>")) {
                            //    mainActivity.updateData(receiveMessage.replaceAll("<end>", ""));
                            mainActivity.updateData(receiveMessage);    //Test ohne <end>
                            receiveMessage = "";
                            //sendString("<next>");
                        } else if (ReadString(dInStream) == null) {
                            Log.e("ReceiveThread", "Server has disconected");
                            close();
                            mainActivity.disconnected();
                        }
                    } catch (Exception e) {
                        Log.e("ReceiveThread", "Server has disconected");
                        e.printStackTrace();
                        close();
                        mainActivity.disconnected();
                    }
                }
                Log.e("RECEIVE_THREAD","END!");
            }
        });
        //this.messageQueue.start();
        this.receiveThread.start();
    }

    // Read Data in
    public static String ReadString(DataInputStream is) throws IOException {
        String ret = null;
        int len = ReadInt(is);
        if ((len == 0) || (len > MAX_BUFFER_SIZE)) {
            ret = "";
            Log.i("tcp", "len 0");
        } else {
            byte[] buffer = new byte[len];
            is.readFully(buffer, 0, len);
            ret = new String(buffer, Charset.defaultCharset());
        }
        return (ret);
    }

    public static int ReadInt(DataInputStream is) throws IOException {
        int ret = 0;
        byte[] intAsBytes = new byte[4];
        is.readFully(intAsBytes);
        ret = ConvertBytesToInt(intAsBytes);
        return (ret);
    }

    public static int ConvertBytesToInt(byte[] array) {
        int rv = 0;
        for (int x = 3; x >= 0; x--) {
            long bv = array[x];
            if (x < 3 & bv < 0)
                bv += 256;
            //rv *= 256;
            rv = rv << 8;
            rv += bv;
        }
        Log.e("received bytes to int", String.valueOf(rv));
        return rv;
    }


    // Write Data out
    public static void WriteString(DataOutputStream os, String value) throws IOException {
        if (value != null) {
            byte[] array = value.getBytes(Charset.defaultCharset());

            String tempTest = "";
            for (byte b : array)
                tempTest += String.valueOf(b) + " ";
            Log.i("WRITE_OUT:ArrayBytes", tempTest);

            WriteBuffer(os, array);
        } else {
            WriteInt(os, 0);
        }
        Log.i("WRITE_OUT", "msg was send");
    }

    public static void WriteBuffer(DataOutputStream os, byte[] array) throws IOException {
        if ((array != null) && (array.length > 0) && (array.length <= MAX_BUFFER_SIZE)) {
            Log.i("WRITE_OUT:ArrayLength", String.valueOf(array.length));

            WriteInt(os, array.length);
            os.write(array);
            os.flush(); // //
        } else {
            Log.e("WRITE_OUT:WriteBuffer", "ERROR 0");
            WriteInt(os, 0);
        }
    }

    public static void WriteInt(DataOutputStream os, int value) throws IOException {
        //  byte[] result = new byte[4];
        //  result[0] = (byte) (value >> 24);
        //  result[1] = (byte) (value >> 16);
        //  result[2] = (byte) (value >> 8);
        //  result[3] = (byte) (value >> 0);
        //byte[] intAsBytes = result; //ConvertIntToBytes(value);

        byte[] intAsBytes = intToBytes(value);
        //for (byte b : intAsBytes)
            //Log.e("int as bytes", String.valueOf(b));
        os.write(intAsBytes);
        os.flush();     // //
    }

    private static byte[] intToBytes(final int data) {
        return new byte[]{
                (byte) ((data >> 24)),
                (byte) ((data >> 16)),
                (byte) ((data >> 8)),
                (byte) ((data >> 0)),
        };
    }


}
