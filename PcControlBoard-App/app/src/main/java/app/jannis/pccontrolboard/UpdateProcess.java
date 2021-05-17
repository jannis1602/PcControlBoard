package app.jannis.pccontrolboard;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.util.Base64;
import android.util.Log;

import java.util.LinkedList;

import app.jannis.objekte.Button;

public class UpdateProcess {
    private Thread updateThread;
    private MainActivity mainActivity;

    public UpdateProcess(MainActivity mainActivity) {
        this.mainActivity = mainActivity;
    }

    public void update(final String message) {
        updateThread = new Thread(new Runnable() {
            @Override
            public void run() {
                updateMessage(message);
            }
        });
        updateThread.start();
    }


    private void updateMessage(String message) {

        if (message.contains("<connected>")) {
            try {
                //Log.i("UpdateProcess", Build.MODEL);
                //mainActivity.tcpClient.sendString("<name:" + Build.MODEL + ">");
                Thread.sleep(10);
            } catch (Exception e) {
                e.printStackTrace();
            }
            Log.i("umsg", "sendLayouts");
            mainActivity.tcpClient.sendString("<sendLayouts>");
            mainActivity.connected();

        } else if (message.contains("addLayout>")) {
            if (mainActivity.screen.layoutList == null)
                mainActivity.screen.layoutList = new LinkedList<Screen.BoardLayout>();
            String[] split = message.split(">");
            byte[] decodedString = Base64.decode(split[4], Base64.DEFAULT);
            Bitmap bitmap = BitmapFactory.decodeByteArray(decodedString, 0, decodedString.length);
            bitmap = Bitmap.createScaledBitmap(bitmap, mainActivity.screen.gridx * mainActivity.screen.gridSize, mainActivity.screen.gridy * mainActivity.screen.gridSize, false);
            Log.i("Uproc", split[1]);
            mainActivity.screen.addLayout(split[1], Integer.valueOf(split[2]), Integer.valueOf(split[3]), bitmap);

        } else if (message.contains("changeLayout>")) {
            String[] split = message.split(">");
            mainActivity.screen.changeLayout(split[1]);

        } else if (message.contains("removeLayout>")) {
            String[] split = message.split(">");
            mainActivity.screen.removeLayout(split[1]);

        } else if (message.contains("<UpdateLayout>")) {
            String[] splitBtn = message.split(">");
            byte[] decodedString = Base64.decode(splitBtn[1], Base64.DEFAULT);
            Bitmap bitmap = BitmapFactory.decodeByteArray(decodedString, 0, decodedString.length);
            mainActivity.screen.bmp = Bitmap.createScaledBitmap(bitmap, mainActivity.screen.gridx * mainActivity.screen.gridSize, mainActivity.screen.gridy * mainActivity.screen.gridSize, false);

            //bmp=Bitmap.createScaledBitmap(bmp, 200, 200, false);

        } else {
            if (message.contains("grid:")) {
                String[] temp = message.split(":");
                String[] gridxy = temp[1].split("#");
                mainActivity.screen.updateGrid(Integer.valueOf(gridxy[0]), Integer.valueOf(gridxy[1]));
            } else if (message.contains("btn:")) {
                String[] temp = message.split(":");
                String[] splitBtn = temp[1].split("#");
                //byte[] decodedString = Base64.decode(splitBtn[5], Base64.DEFAULT);
                Bitmap bmp = null;// BitmapFactory.decodeByteArray(decodedString, 0, decodedString.length);
                //bmp=Bitmap.createScaledBitmap(bmp, 200, 200, false);
                if (!splitBtn[4].equals("<null>"))
                    mainActivity.screen.addBtnToList(new Button(Integer.valueOf(splitBtn[0]), Integer.valueOf(splitBtn[1]), Integer.valueOf(splitBtn[2]), Integer.valueOf(splitBtn[3]), splitBtn[4], mainActivity.screen, bmp));
                else
                    mainActivity.screen.addBtnToList(new Button(Integer.valueOf(splitBtn[0]), Integer.valueOf(splitBtn[1]), Integer.valueOf(splitBtn[2]), Integer.valueOf(splitBtn[3]), " ", mainActivity.screen, bmp));
            } else if (message.contains("btnremove:")) {
                String[] temp = message.split(":");
                String[] splitBtn = temp[1].split("#");
                mainActivity.screen.removeBtnFromList(Integer.valueOf(splitBtn[0]), Integer.valueOf(splitBtn[1]));
            }
        }
    }
}
