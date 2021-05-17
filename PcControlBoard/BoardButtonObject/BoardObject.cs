using System;
using System.Drawing;


namespace PcControlBoard.BoardButtonObject
{
    [Serializable]
    public abstract class BoardObject
    {
        public String[] Actions { get; set; }
        public String BtnEvent { get; set; }
        public String Text { get; set; }
        public int Gridx { get; set; }
        public int Gridy { get; set; }
        public int Sizex { get; set; }
        public int Sizey { get; set; }
        public int Offsetx { get; set; }
        public int GridSize { get; set; }
        public Bitmap backgroundBmp { get; set; }



        public BoardObject() { }

        public abstract Bitmap Render();
        public abstract Bitmap GetBitmap();
        public abstract void BoardObjectEvent();
        public abstract void ShowOptions();
        public abstract Boolean IsTouched(float tx, float ty);

        public abstract BoardObject Clone();

    }

}
