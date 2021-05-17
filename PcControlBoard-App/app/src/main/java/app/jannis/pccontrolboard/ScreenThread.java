package app.jannis.pccontrolboard;

import android.annotation.SuppressLint;
import android.graphics.Canvas;

public class ScreenThread extends Thread {
    static final long FPS = 4;//10
    private Screen screen;
    private boolean isRunning = false;

    public ScreenThread(Screen screen) {
        this.screen = screen;
    }

    public void setRunning(boolean run) {
        isRunning = run;
    }

    @SuppressLint("WrongCall")
    @Override
    public void run() {
        long TPS = 1000 / FPS;
        long startTime, sleepTime;
        while (isRunning) {
            Canvas canvas = null;
            startTime = System.currentTimeMillis();
            try {
                canvas = screen.getHolder().lockCanvas();
                synchronized (screen.getHolder()) {
                    screen.onDraw(canvas);
                }
            } finally {
                if (canvas != null)
                    screen.getHolder().unlockCanvasAndPost(canvas);
            }
            sleepTime = TPS - (System.currentTimeMillis() - startTime);
            try {
                if (sleepTime > 0)
                    sleep(sleepTime);
                else
                    sleep(10);
            } catch (Exception e) {
            }
        }
    }
}




/*
 private class DemoView extends View {
        public DemoView(Context context) {
            super(context);
        }

        @Override
        protected void onDraw(Canvas canvas) {
            super.onDraw(canvas);

            // custom drawing code here
            Paint paint = new Paint();
            paint.setStyle(Paint.Style.FILL);

            // make the entire canvas white
            paint.setColor(Color.WHITE);
            canvas.drawPaint(paint);

            canvas.save();

            // draw blue circle with anti aliasing turned off
            paint.setAntiAlias(false);
            paint.setColor(Color.BLUE);
            canvas.drawCircle(20, 20, 15, paint);

            // draw green circle with anti aliasing turned on
            paint.setAntiAlias(true);
            paint.setColor(Color.GREEN);
            canvas.drawCircle(60, 20, 15, paint);

            // draw red rectangle with anti aliasing turned off
            paint.setAntiAlias(false);
            paint.setColor(Color.RED);
            canvas.drawRect(100, 5, 200, 30, paint);

            // draw the rotated text
            canvas.rotate(-45);

            paint.setStyle(Paint.Style.FILL);
            canvas.drawText("Graphics Rotation", 40, 180, paint);

            //undo the rotate
            canvas.restore();
            canvas.drawText(String.valueOf(System.nanoTime()), 40, 400, paint);
        }
    }


 */