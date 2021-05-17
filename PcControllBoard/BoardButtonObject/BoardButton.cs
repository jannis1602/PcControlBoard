using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcControlBoard.BoardButtonObject
{
    [Serializable]
    public abstract class BoardButton : BoardObject
    {

        //public String[] Actions { get; set; }
        //public String BtnEvent { get; set; }
        public String Path { get; set; }

        private Bitmap btnBmp;

        //public BoardButton() { }

        /*public BoardButton(int gridx, int gridy, int sizex, int sizey, String text, String objEvent)
        {
            this.Gridx = gridx;
            this.Gridy = gridy;
            this.Sizex = sizex;
            this.Sizey = sizey;
            this.Text = text;
            this.GridSize = FormControlBoard.gridSize;
            this.Offsetx = FormControlBoard.offset;
            this.objEventString = objEvent;
            this.objEvent = (ObjectEvent)Enum.Parse(typeof(ObjectEvent), objEvent); 
        }*/

        public override Bitmap Render()
        {
            this.GridSize = FormControlBoard.gridSize;
            this.Offsetx = FormControlBoard.offset;

            btnBmp = new Bitmap(Sizex * GridSize, Sizey * GridSize);
            Graphics graphics = Graphics.FromImage(btnBmp);

            Brush brush = new SolidBrush(ColorTranslator.FromHtml("0xFF444444"));   // farbe ändern
                                                                                    // graphics.DrawRectangle(pen, Gridx * GridSize + Offsetx, Gridy * GridSize, GridSize * Sizex, GridSize * Sizey);
                                                                                    // FillRoundedRectangle(graphics, brush, Gridx * GridSize + 5 + Offsetx, Gridy * GridSize + 5, GridSize * Sizex - 10, GridSize * Sizey - 10, GridSize / 4, GridSize / 4);
                                                                                    // DrawRoundedRectangle(graphics, new Pen(Brushes.Black, 4), Gridx * GridSize + 5 + Offsetx, Gridy * GridSize + 5, GridSize * Sizex - 10, GridSize * Sizey - 10, GridSize / 4, GridSize / 4);
            graphics.FillRectangle(new SolidBrush(Color.Gray), 0, 0, GridSize, GridSize);
            graphics.DrawRectangle(new Pen(Color.Black), 0, 0, GridSize, GridSize);
            if (backgroundBmp != null)
            {
                graphics.DrawImage(new Bitmap(backgroundBmp, Sizex * GridSize, Sizey * GridSize), new Point(0, 0));
            }
            else
            {
                FillRoundedRectangle(graphics, brush, 5, 5, GridSize * Sizex - 10, GridSize * Sizey - 10, GridSize / 4, GridSize / 4);
            }
            DrawRoundedRectangle(graphics, new Pen(Brushes.Black, 4), 5, 5, GridSize * Sizex - 10, GridSize * Sizey - 10, GridSize / 4, GridSize / 4);

            if (Text != "<null>")
                using (Font font1 = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Point))
                {
                    int rectIn = 9;      // TEST
                    Rectangle rect1 = new Rectangle(rectIn, rectIn, GridSize * Sizex - rectIn * 2, GridSize * Sizey - rectIn * 2);
                    StringFormat stringFormat = new StringFormat();
                    stringFormat.Alignment = StringAlignment.Near;          // Center            // auswahl...
                    stringFormat.LineAlignment = StringAlignment.Near;      // Center  
                    graphics.DrawString(Text, font1, Brushes.Black, rect1, stringFormat);
                }
            return btnBmp;

            /*         Brush brush = new SolidBrush(ColorTranslator.FromHtml("0xFF444444"));
                     Pen pen = new Pen(Color.Black);
                     //g.FillRectangle(brush, Gridx * GridSize, Gridy * GridSize, GridSize * Sizex, GridSize * Sizey);
                     g.DrawRectangle(pen, Gridx * GridSize + Offsetx, Gridy * GridSize, GridSize * Sizex, GridSize * Sizey);
                     FillRoundedRectangle(g, brush, Gridx * GridSize + 5 + Offsetx, Gridy * GridSize + 5, GridSize * Sizex - 10, GridSize * Sizey - 10, GridSize / 4, GridSize / 4);
                     DrawRoundedRectangle(g, new Pen(Brushes.Black, 4), Gridx * GridSize + 5 + Offsetx, Gridy * GridSize + 5, GridSize * Sizex - 10, GridSize * Sizey - 10, GridSize / 4, GridSize / 4);
                     if (Text != "<null>")
                         using (Font font1 = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Point))
                         {
                             int rectIn =9;      // TEST
                             Rectangle rect1 = new Rectangle(Gridx * GridSize + Offsetx+ rectIn, Gridy * GridSize+ rectIn, GridSize * Sizex- rectIn*2, GridSize * Sizey- rectIn*2);
                             StringFormat stringFormat = new StringFormat();
                             stringFormat.Alignment = StringAlignment.Near;          // Center            // auswahl...
                             stringFormat.LineAlignment = StringAlignment.Near;      // Center  
                             g.DrawString(Text, font1, Brushes.Black, rect1, stringFormat);
                         }*/
        }
        public override Bitmap GetBitmap()
        {
            if (btnBmp == null)
                return Render();
            return btnBmp;
        }

        static void DrawRoundedRectangle(Graphics g, Pen p,
            int x, int y, int w, int h, int rx, int ry)
        {
            System.Drawing.Drawing2D.GraphicsPath path
              = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(x, y, rx + rx, ry + ry, 180, 90);
            path.AddLine(x + rx, y, x + w - rx, y);
            path.AddArc(x + w - 2 * rx, y, 2 * rx, 2 * ry, 270, 90);
            path.AddLine(x + w, y + ry, x + w, y + h - ry);
            path.AddArc(x + w - 2 * rx, y + h - 2 * ry, rx + rx, ry + ry, 0, 90);
            path.AddLine(x + rx, y + h, x + w - rx, y + h);
            path.AddArc(x, y + h - 2 * ry, 2 * rx, 2 * ry, 90, 90);

            path.CloseFigure();
            g.DrawPath(p, path);
        }

        static void FillRoundedRectangle(Graphics g, Brush brush, int x, int y, int w, int h, int rx, int ry)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(x, y, rx + rx, ry + ry, 180, 90);
            path.AddArc(x + w - 2 * rx, y, 2 * rx, 2 * ry, 270, 90);
            path.AddArc(x + w - 2 * rx, y + h - 2 * ry, rx + rx, ry + ry, 0, 90);
            path.AddArc(x, y + h - 2 * ry, 2 * rx, 2 * ry, 90, 90);

            path.CloseFigure();
            g.FillPath(brush, path);
        }



        /*public void render(Canvas canvas){
            this.gridSize = screen.gridSize;
            this.offsetx = screen.offset;

            Paint pt = new Paint();
            final int fontSize = (int)(20 * screen.getDensity());
            int yTextPos = (int)(gridy * gridSize + 25 * screen.getDensity());
            Typeface font = Typeface.create("Arial", Typeface.NORMAL);
            pt.setColor(Color.LTGRAY);
            pt.setTypeface(font);
            pt.setTextSize(fontSize);
            pt.setAntiAlias(true);
            int x = (int)(gridx * gridSize + offsetx + 20 * screen.getDensity());
            canvas.drawText(text, x, yTextPos, pt);}*/



        public abstract override void BoardObjectEvent();
        public abstract override void ShowOptions();
        public abstract Boolean ChangeProperties();
        public abstract override BoardObject Clone();
    }
}
