package app.jannis.objekte;

import android.graphics.Bitmap;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.graphics.Rect;
import android.graphics.RectF;
import android.graphics.Typeface;
import android.util.Log;

import app.jannis.pccontrolboard.Screen;

public class Button {
    private int gridx, gridy;
    private int sizex, sizey;
    private int gridSize;
    private int offsetx;
    private Screen screen;
    private Paint paint;
    private boolean touched = false;
    private String text;
    private Bitmap bmp;

    public Button(int gridx, int gridy, int sizex, int sizey) {
        this.gridx = gridx;
        this.gridy = gridy;
        this.sizex = sizex;
        this.sizey = sizey;
    }

    public Button(int gridx, int gridy, int sizex, int sizey, String text, Screen screen, Bitmap bmp) {
        this.gridx = gridx;
        this.gridy = gridy;
        this.sizex = sizex;
        this.sizey = sizey;
        this.text = text;
        this.gridSize = screen.gridSize;
        this.offsetx = screen.offset;
        this.screen = screen;
        //this.bmp = Bitmap.createScaledBitmap(bmp, gridSize, gridSize, false);
    }

    public Button(int gridx, int gridy, int sizex, int sizey, Screen screen) {
        this.gridx = gridx;
        this.gridy = gridy;
        this.sizex = sizex;
        this.sizey = sizey;
        this.text = " ";
        this.gridSize = screen.gridSize;
        this.offsetx = screen.offset;
        this.screen = screen;
    }

    public Button(int gridx, int gridy, int sizex, int sizey, int gridSize, String text, int offsetx, Screen screen) {
        this.gridx = gridx;
        this.gridy = gridy;
        this.sizex = sizex;
        this.sizey = sizey;
        this.gridSize = gridSize;
        this.offsetx = offsetx;
        this.screen = screen;
        this.text = text;
    }


    public void render(Canvas canvas) {
        this.gridSize = screen.gridSize;
        this.offsetx = screen.offset;
        paint = new Paint();
        /*paint.setColor(Color.LTGRAY);
        //RectF rect = new RectF(gridx * gridSize + offsetx, gridy * gridSize, gridx * gridSize + sizex * gridSize + offsetx, gridy * gridSize + sizey * gridSize);
        if (touched) {
            canvas.drawRect(gridx * gridSize + offsetx, gridy * gridSize, gridx * gridSize + sizex * gridSize + offsetx, gridy * gridSize + sizey * gridSize, paint);
            touched = false;
        }
        paint.setColor(Color.DKGRAY);

        RectF rect = new RectF(gridx * gridSize + offsetx + (canvas.getHeight() / gridSize) * 3,
                gridy * gridSize + (canvas.getHeight() / gridSize) * 3,
                gridx * gridSize + sizex * gridSize + offsetx - (canvas.getHeight() / gridSize) * 3,
                gridy * gridSize + sizey * gridSize - (canvas.getHeight() / gridSize) * 3);
        canvas.drawRoundRect(rect, gridSize / 4, gridSize / 4, paint); //80
        /*canvas.drawRoundRect(
                gridx * gridSize + offsetx + (canvas.getHeight() / gridSize) * 3,
                gridy * gridSize + (canvas.getHeight() / gridSize) * 3,
                gridx * gridSize + sizex * gridSize + offsetx - (canvas.getHeight() / gridSize) * 3,
                gridy * gridSize + sizey * gridSize - (canvas.getHeight() / gridSize) * 3,
                gridSize / 4, gridSize / 4, paint); //80

         */
        /*paint.setStrokeWidth(10);
        paint.setStyle(Paint.Style.STROKE);
        paint.setColor(Color.BLACK);
        canvas.drawRoundRect(rect, gridSize / 4, gridSize / 4, paint); //80

        Paint pt = new Paint();
        final int fontSize = (int) (20 * screen.getDensity());
        int yTextPos = (int) (gridy * gridSize + 25 * screen.getDensity());
        Typeface font = Typeface.create("Arial", Typeface.NORMAL);
        pt.setColor(Color.LTGRAY);
        pt.setTypeface(font);
        pt.setTextSize(fontSize);
        pt.setAntiAlias(true);
        int x = (int) (gridx * gridSize + offsetx + 10 * screen.getDensity());
        //canvas.drawText(text, x, yTextPos, pt);

        Paint mPaint = new Paint(Paint.ANTI_ALIAS_FLAG);
        mPaint.setTextSize(12*screen.getDensity());
        Rect areaRect = new Rect(gridx * gridSize + offsetx + (canvas.getHeight() / gridSize) * 3,
                gridy * gridSize + (canvas.getHeight() / gridSize) * 3,
                gridx * gridSize + sizex * gridSize + offsetx - (canvas.getHeight() / gridSize) * 3,
                gridy * gridSize + sizey * gridSize - (canvas.getHeight() / gridSize) * 3);
        mPaint.setColor(Color.BLACK);
        //canvas.drawRect(areaRect, mPaint);
        String pageTitle = text;
        RectF bounds = new RectF(areaRect);
        bounds.right = mPaint.measureText(pageTitle, 0, pageTitle.length());
        bounds.bottom = mPaint.descent() - mPaint.ascent();
        bounds.left += (areaRect.width() - bounds.right) / 2.0f;
        bounds.top += (areaRect.height() - bounds.bottom) / 2.0f;
        mPaint.setColor(Color.WHITE);
        canvas.drawText(pageTitle, bounds.left, bounds.top - mPaint.ascent(), mPaint);
*/
        //canvas.drawBitmap(bmp, gridx * gridSize + offsetx, gridy * gridSize, paint);
    }

    public boolean isTouched(float tx, float ty) {
        if (tx > gridx * gridSize + offsetx && tx < gridx * gridSize + sizex * gridSize + offsetx && ty > gridy * gridSize && ty < gridy * gridSize + sizey * gridSize) {
            touched = true;
            Log.e("Button", String.valueOf(gridx + " " + gridy + " " + touched));
            return true;
        }
        return false;
    }

    public String event() {
        Log.e("Button", "Event!!!");
        return String.valueOf("btn:" + gridx + "#" + gridy);
    }

    public int getGridx() {
        return gridx;
    }

    public int getGridy() {
        return gridy;
    }
}
