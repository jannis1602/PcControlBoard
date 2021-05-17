package app.jannis.pccontrolboard;

import android.annotation.SuppressLint;
import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Matrix;
import android.graphics.Paint;
import android.util.Log;
import android.view.MotionEvent;
import android.view.SurfaceHolder;
import android.view.SurfaceView;

import java.util.LinkedList;

import app.jannis.objekte.Button;

public class Screen extends SurfaceView {
    private float density;
    public int width, height;
    public int gridx = 6, gridy = 4;
    public int gridSize, offset;
    private boolean btnsCreated = false;

    private SurfaceHolder surfaceHolder;
    private ScreenThread screenThread;

    private Paint paint;
    private long lastClick;

    private LinkedList<Button> btnList;
    private MainActivity mainActivity;

    public boolean renderScreen = false;
    public Bitmap bmp = null;

    LinkedList<BoardLayout> layoutList = null;

    public Screen(Context context, MainActivity mainActivity) {
        super(context);
        this.mainActivity = mainActivity;
        surfaceHolder = getHolder();
        surfaceHolder.addCallback(new SurfaceHolder.Callback() {
            @Override
            public void surfaceCreated(SurfaceHolder holder) {
                newScreenThread();
                screenThread.setRunning(true);
                screenThread.start();
            }

            @SuppressLint("WrongCall")
            @Override
            public void surfaceChanged(SurfaceHolder holder, int format, int width, int height) {
                Log.d("Game", "surfaceChanged");
                //Canvas theCanvas = surfaceHolder.lockCanvas(null);
                //onDraw(theCanvas);
                //surfaceHolder.unlockCanvasAndPost(theCanvas);
            }

            @Override
            public void surfaceDestroyed(SurfaceHolder holder) {
                if (screenThread != null) {
                    screenThread.setRunning(false);
                    while (screenThread != null) {
                        try {
                            screenThread.join();
                            screenThread = null;
                        } catch (InterruptedException e) {
                        }
                    }
                }
            }
        });
        btnList = new LinkedList<Button>();
    }

    private void newScreenThread() {
        screenThread = null;
        screenThread = new ScreenThread(this);
    }

    @Override
    protected void onDraw(Canvas canvas) {
        if (width == 0) {
            width = getWidth();
            height = getHeight();
            offset = (width - (height / gridy * gridx)) / 2;
            gridSize = height / gridy;
        }
        if (!btnsCreated) {
            // if(getHeight()/gridy*gridx>getWidth())      //nur Test
            //     gridx=getWidth()/(getHeight()/gridy);

            //btnList.add(new Button(0, 0, 1, 1, getHeight() / gridy, (getWidth() - (getHeight() / gridy * gridx)) / 2,this, "btn1"));
            //btnList.add(new Button(1, 0, 1, 1, getHeight() / gridy, (getWidth() - (getHeight() / gridy * gridx)) / 2,this, "btn2"));
            //btnList.add(new Button(2, 0, 1, 1, getHeight() / gridy, (getWidth() - (getHeight() / gridy * gridx)) / 2,this));
            //btnList.add(new Button(0, 1, 2, 1, getHeight() / gridy, (getWidth() - (getHeight() / gridy * gridx)) / 2,this));
            //btnList.add(new Button(0, 2, 1, 1, getHeight() / gridy, (getWidth() - (getHeight() / gridy * gridx)) / 2,this));
            //btnList.add(new Button(3, 1, 1, 1, getHeight() / gridy, (getWidth() - (getHeight() / gridy * gridx)) / 2,this));
            //btnList.add(new Button(0, 3, 4, 1, getHeight() / gridy, (getWidth() - (getHeight() / gridy * gridx)) / 2,this));
            /*Log.e("Screen",String.valueOf(BoardActivity.allBtns.size()));

            for (int i = 0; i < BoardActivity.allBtns.size(); i++)
                btnList.add(new Button(
                        Integer.valueOf(BoardActivity.allBtns.get(i).get(0)),
                        Integer.valueOf(BoardActivity.allBtns.get(i).get(1)),
                        Integer.valueOf(BoardActivity.allBtns.get(i).get(2)),
                        Integer.valueOf(BoardActivity.allBtns.get(i).get(3)),
                        getHeight() / gridy, (getWidth() - (getHeight() / gridy * gridx)) / 2,
                        this, BoardActivity.allBtns.get(i).get(4)));*/


            // receiveLayout();          //Layout String!!!

            btnsCreated = true;
        }
        canvas.drawColor(Color.GRAY);
        paint = new Paint();
        paint.setColor(Color.BLACK);
        // canvas.drawRect(200, 200, 400, 400, paint);

        try {       //nur test...
            // if (renderScreen)
            canvas.drawBitmap(bmp, offset, 0, paint);
        } catch (Exception e) {
            Log.e("error", "canvas");
            e.printStackTrace();
        }
        //   for (int i = 0; i < btnList.size(); i++) {
        //       btnList.get(i).render(canvas);
        //   }

    }

    public void changeLayout(String layoutName) {
        for (int i = 0; i < layoutList.size(); i++) {
            if (layoutList.get(i).name.equals(layoutName)) {
                bmp = layoutList.get(i).bitmap;
                gridx = layoutList.get(i).gridx;
                gridy = layoutList.get(i).gridy;
                updateGrid(gridx,gridy);
            }
        }
    }
    public void addLayout(String name, int gridx, int gridy, Bitmap bitmap) {
        layoutList.add(new BoardLayout(name, gridx, gridy, bitmap));
    }
    public void removeLayout(String layoutName) {
        for (int i = 0; i < layoutList.size(); i++) {
            if (layoutList.get(i).name.equals(layoutName)) {
                layoutList.remove(i);
            }
        }
    }

   /* public void receiveLayout() {
        String layoutmsg = null;
        MainActivity.sendmsg.sendMsg("sendlayout");
        long startTime = System.currentTimeMillis();
        while (startTime - System.currentTimeMillis() < 100) {
            if (MainActivity.receivemsg.getReceivedMsg() != null && MainActivity.receivemsg.getReceivedMsg().contains("-")) {
                layoutmsg = MainActivity.receivemsg.getReceivedMsg();
                Log.e("Layout msg", layoutmsg);
                break;
            }
        }
        String[] layout = layoutmsg.split("-");
        gridx = Integer.valueOf(layout[0]);
        gridy = Integer.valueOf(layout[1]);
        Log.e("Layout", String.valueOf(gridx + " " + gridy));


        int btns = Integer.valueOf(layout[2]);
        String[] layoutBtns = layout[3].split("#");
        Log.i("layoutBtns.length", String.valueOf(layoutBtns.length));
        for (int i = 0; i < layoutBtns.length; i++) {
            Log.e("LayoutBtn", layoutBtns[i]);
            String[] Btn = layoutBtns[i].split("%");
            Button btn = new Button(Integer.valueOf(Btn[0]), Integer.valueOf(Btn[1]), Integer.valueOf(Btn[2]), Integer.valueOf(Btn[3]), getHeight() / gridy, (getWidth() - (getHeight() / gridy * gridx)) / 2, this, Btn[4]);
            btnList.add(btn);
        }
        Log.i("btnList.size()", String.valueOf(btnList.size()));

    }*/

    @Override
    public boolean onTouchEvent(MotionEvent event) {
        //if (System.currentTimeMillis() - lastClick > 200) {
        //   lastClick = System.currentTimeMillis();
        if (event.getAction() == MotionEvent.ACTION_DOWN) {
            float tx = event.getX();
            float ty = event.getY();
            Log.d("onTouchEvent", String.valueOf(tx + "  " + ty));

            for (int ix = 0; ix < gridx; ix++)
                for (int iy = 0; iy < gridy; iy++) {
                    if (tx > ix * gridSize + offset
                            && tx < ix * gridSize + offset + gridSize
                            && ty > iy * gridSize
                            && ty < iy * gridSize + gridSize) {
                        mainActivity.tcpClient.sendString("btn:" + ix + "#" + iy);
                        return true;
                    }
                }

           /* for (int i = 0; i < btnList.size(); i++) {
                if (btnList.get(i).isTouched(tx, ty)) {
                    mainActivity.tcpClient.sendString(btnList.get(i).event());
                    break;
                }
            }*/
        }
        return true;
    }

    // close();
    // mainActivity.disconnected();

   /*  AlertDialog.Builder back;

    @Override
    public boolean onKeyDown(int keyCode, KeyEvent event) {
        Log.i("onKeyDown","Event");
        if ((keyCode == KeyEvent.KEYCODE_BACK)) {
            Log.i("onKeyDown","KeyCode_Back");

            back = new AlertDialog.Builder(this.getContext());
            back.setIcon(R.drawable.ic_launcher_foreground);         //verlinkt Icon aus drawable Ordner
            back.setTitle("Sie haben die Zurück Taste gedrückt");
            back.setMessage("Möchten Sie das Programm wirklich beenden?");

            back.setPositiveButton("Ja", new DialogInterface.OnClickListener() {

                public void onClick(DialogInterface dialog, int whichButton) {
                    Log.i("onKeyDown","onClick ja");
                    //mainActivity.tcpClient.close();
                    //mainActivity.disconnected();
                }

            });

            back.setNegativeButton("Nein", new DialogInterface.OnClickListener() {
                @Override
                public void onClick(DialogInterface dialog, int which) {
                    Log.i("onKeyDown","onClick nein");
                }
            });

            back.show();
        }
//----------------------------------------------------------------
        return false;
    }       */


    public float getDensity() {
        density = getResources().getDisplayMetrics().density;
        return density;
    }


    public static Bitmap getResizedBitmap(Bitmap bm, int newWidth, int newHeight) {
        int width = bm.getWidth();
        int height = bm.getHeight();
        float scaleWidth = ((float) newWidth) / width;
        float scaleHeight = ((float) newHeight) / height;
        // CREATE A MATRIX FOR THE MANIPULATION
        Matrix matrix = new Matrix();
        // RESIZE THE BIT MAP
        matrix.postScale(scaleWidth, scaleHeight);
        // "RECREATE" THE NEW BITMAP
        Bitmap resizedBitmap = Bitmap.createBitmap(
                bm, 0, 0, width, height, matrix, false);
        bm.recycle();
        return resizedBitmap;
    }

    public void addBtnToList(Button btn) {
        btnList.add(btn);
    }

    public void clearBtnList() {
        btnList.clear();
    }

    public void removeBtnFromList(int gx, int gy) {
        for (int i = 0; i < btnList.size(); i++) {
            if (btnList.get(i).getGridx() == gx && btnList.get(i).getGridy() == gy) {
                btnList.remove(i);
                return;
            }
        }
    }

    public void updateGrid(int gridx, int gridy) {
        this.gridx = gridx;
        this.gridy = gridy;
        offset = (width - (height / gridy * gridx)) / 2;
        gridSize = height / gridy;
    }

    public int getGridx() {
        return gridx;
    }

    public int getGridy() {
        return gridy;
    }

    class BoardLayout {
        public int gridx, gridy;
        public String name;
        public Bitmap bitmap;

        public BoardLayout(String name, int gridx, int gridy, Bitmap bitmap) {
            this.name = name;
            this.gridx = gridx;
            this.gridy = gridy;
            this.bitmap = bitmap;
        }


    }

}
