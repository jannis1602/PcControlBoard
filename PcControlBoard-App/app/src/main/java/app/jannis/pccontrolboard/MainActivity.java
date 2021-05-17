package app.jannis.pccontrolboard;

import androidx.appcompat.app.AppCompatActivity;
import android.os.Bundle;
import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.SharedPreferences;
import android.util.Log;
import android.view.KeyEvent;
import android.view.View;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.EditText;

public class MainActivity extends Activity {

    app.jannis.pccontrolboard.TCPClient tcpClient;
    app.jannis.pccontrolboard.Screen screen;
    Thread clientConnectThread;
    app.jannis.pccontrolboard.Settings settings;
    app.jannis.pccontrolboard.UpdateProcess updateProcess;
    SharedPreferences sharedPrefs;
    SharedPreferences.Editor sharedPrefsEditor;

    private EditText textIP;
    private EditText textPort;
    //String ipAdress;
    //int port;
    public static final String SHARED_PREFS = "appPrefs";
    public static final String PREFS_IP = "prefsIp";
    public static final String PREFS_PORT = "prefsPort";


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        getWindow().addFlags (WindowManager.LayoutParams.FLAG_KEEP_SCREEN_ON);
        if (settings == null)
            settings = new app.jannis.pccontrolboard.Settings();
        if (updateProcess == null)
            updateProcess = new app.jannis.pccontrolboard.UpdateProcess(this);
        sharedPrefs = getSharedPreferences(SHARED_PREFS, MODE_PRIVATE);
        sharedPrefsEditor = sharedPrefs.edit();
        connectMenue();

    }

    private void connectMenue() {
        setContentView(R.layout.activity_main);
        textIP = (EditText) findViewById(R.id.editTextIP);
        textPort = (EditText) findViewById(R.id.editTextPort);
        try {
            textIP.setText(sharedPrefs.getString(SHARED_PREFS, PREFS_IP));
            textPort.setText(sharedPrefs.getString(SHARED_PREFS, PREFS_PORT));
        } catch (Exception e) {
            e.printStackTrace();
        }
        textIP.setText(sharedPrefs.getString(PREFS_IP, ""));
        textPort.setText(sharedPrefs.getString(PREFS_PORT, ""));

        Button btnConnect = (Button) findViewById(R.id.btnConnect);
        btnConnect.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                textIP = (EditText) findViewById(R.id.editTextIP);
                textPort = (EditText) findViewById(R.id.editTextPort);
                Log.e("connectIP", String.valueOf(textIP.getText()));
                Log.e("connectPort", String.valueOf(textPort.getText()));
                sharedPrefsEditor.putString(PREFS_IP, textIP.getText().toString());
                sharedPrefsEditor.putString(PREFS_PORT, textPort.getText().toString());
                sharedPrefsEditor.commit();
                connect();
            }
        });
    }

    public void connected() {
        screen = new app.jannis.pccontrolboard.Screen(this, this);
        runOnUiThread(new Runnable() {
            @Override
            public void run() {
                setContentView(screen);
            }
        });
        //Log.i("connected ","sendLayout");
        //tcpClient.sendString("<sendLayout>");
    }

    public void disconnected() {
        screen=null;
        runOnUiThread(new Runnable() {
            public void run() {
                connectMenue();
            }
        });
    }

    public void updateData(String message) {
        updateProcess.update(message);
    }

    public void connect() {
        //if (!checkWifiOnAndConnected()) {
        //    msg(getString(C0277R.string.wifi_off));
        //}
        clientConnectThread = new Thread(new Runnable() {
            public void run() {
                try {
                    tcpClient = new app.jannis.pccontrolboard.TCPClient(MainActivity.this);
                    //tcpClient.connect("192.168.178.53", 3322);// +Ip und port aus textfeld!
                    tcpClient.connect(sharedPrefs.getString(PREFS_IP, ""),
                            Integer.valueOf(sharedPrefs.getString(PREFS_PORT, "")));
                } catch (Exception e) {
                }
            }
        });
        clientConnectThread.start();
    }
    //private boolean checkWifiOnAndConnected() {
    //    return ((ConnectivityManager) getSystemService("connectivity")).getNetworkInfo(1).isConnected();
    //}


   /* public void dismissDialog() {
        runOnUiThread(new Runnable() {
            public void run() {
                try {
                    MainActivity.this.waitDialog.dismiss();
                } catch (Exception e) {
                }
            }
        });
    }
    */


    //   @Override
    //   public void onBackPressed() {
    //       finish();
    //       super.onBackPressed();
    //    }

    AlertDialog.Builder back;

    @Override
    public boolean onKeyDown(int keyCode, KeyEvent event) {
        Log.i("onKeyDown", "Event");
        if ((keyCode == KeyEvent.KEYCODE_BACK)&&screen!=null) {
            Log.i("onKeyDown", "KeyCode_Back");

            back = new AlertDialog.Builder(this);
            back.setIcon(R.drawable.ic_launcher_foreground);         //verlinkt Icon aus drawable Ordner
            back.setTitle("Zur zur Auswahl");
            back.setMessage("Zur zur Auswahl");

            back.setPositiveButton("Ja", new DialogInterface.OnClickListener() {

                public void onClick(DialogInterface dialog, int whichButton) {
                    Log.i("onKeyDown", "onClick ja");
                    tcpClient.close();
                    disconnected();
                }

            });

            back.setNegativeButton("Nein", new DialogInterface.OnClickListener() {
                @Override
                public void onClick(DialogInterface dialog, int which) {
                    Log.i("onKeyDown", "onClick nein");
                }
            });

            back.create().show();
        }else if (keyCode == KeyEvent.KEYCODE_BACK){ finish();}
        //return false;
        return true;
    }


}