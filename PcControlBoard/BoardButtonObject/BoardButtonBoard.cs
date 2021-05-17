using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PcControlBoard.BoardButtonObject
{
    [Serializable]
    public class BoardButtonBoard : BoardButton
    {
        [NonSerialized] private FormBtnObjOptions form;
        private String layoutName = "Main Layout";

        public BoardButtonBoard()
        {
            Actions = new String[] { "Board", "SwitchLayout", "PreviousLayout", "NextLayout" };
        }

        public BoardButtonBoard(int gridx, int gridy, int sizex, int sizey, String text, String objEvent)
        {
            Actions = new String[] { "Board", "SwitchLayout", "PreviousLayout", "NextLayout" };
            this.Gridx = gridx;
            this.Gridy = gridy;
            this.Sizex = sizex;
            this.Sizey = sizey;
            this.Text = text;
            this.GridSize = FormControlBoard.gridSize;
            this.Offsetx = FormControlBoard.offset;
            this.BtnEvent = objEvent;
        }

        public override Boolean IsTouched(float tx, float ty)
        {
            if (tx > Gridx * GridSize + Offsetx && tx < Gridx * GridSize + Sizex * GridSize + Offsetx && ty > Gridy * GridSize && ty < Gridy * GridSize + Sizey * GridSize)
            {
                //  Touched = true;
                Debug.WriteLine(Gridx + " " + Gridy + "<String:true>");
                return true;
            }
            return false;
        }

        public override void BoardObjectEvent()
        {
            Debug.WriteLine("Event!!!" + Gridx + " " + Gridy);
            switch (BtnEvent)
            {
                case "SwitchLayout":
                    Debug.WriteLine("<EVENT>SwitchLayout");
                    Program.formControlBoard.changeLayout(layoutName);
                    break;
                case "PreviousLayout":
                    Debug.WriteLine("<EVENT>PreviousLayout");
                    Program.formControlBoard.changeLayout("<previous_layout>");
                    break;
                case "NextLayout":
                    Debug.WriteLine("<EVENT>NextLayout");
                    Program.formControlBoard.changeLayout("<next_layout>");
                    break;
            }
        }

        public override void ShowOptions()
        {
            if (form == null)
            {
                form = new FormBtnObjOptions(this);
                switch (BtnEvent)
                {
                    case "SwitchLayout":
                        form.BtnSize(Sizex, Sizey);
                        // CBox mit allen Layouts
                        break;
                    case "PreviousLayout":
                        form.BtnSize(Sizex, Sizey);
                        break;
                    case "NextLayout":
                        form.BtnSize(Sizex, Sizey);
                        break;
                }
                form.Refresh();
            }
            form.Show();
        }

        public override BoardObject Clone()
        {
            BoardButtonBoard tempBoardObject = new BoardButtonBoard(Gridx, Gridy, Sizex, Sizey, Text, BtnEvent);
            tempBoardObject.backgroundBmp = backgroundBmp;
            return tempBoardObject;
        }

        public override Boolean ChangeProperties()
        {
            if (!((Sizex = Convert.ToInt16(form.tb_sizex.Text)) >= 1)) { MessageBox.Show("Error: x<1", "Error"); return false; }
            if (!((Sizey = Convert.ToInt16(form.tb_sizey.Text)) >= 1)) { MessageBox.Show("Error: y<1", "Error"); return false; }
            // get CBox layout choose
            return true;
        }
    }
}
