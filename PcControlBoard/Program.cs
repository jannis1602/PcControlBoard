using System;
using System.Windows.Forms;

namespace PcControlBoard
{
    static class Program
    {
        public static FormControlBoard formControlBoard;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            formControlBoard = new FormControlBoard();
            Application.Run(formControlBoard);
        }
    }
}
