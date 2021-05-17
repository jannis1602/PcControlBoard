using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using PcControlBoard.BoardButtonObject;

namespace PcControlBoard
{
    public partial class FormControlBoard : Form
    {
        LinkedList<String[]> objectActionList;  // alle Listen mit allen Button Actions

        private TCPServer tcpServer;
        private int gridx = 7, gridy = 4;       // 7 4
        public static int gridSize;
        public static int offset = 0;       // wird noch nicht benutzt (offset fur da Board zum zentrieren)
        private Point contextMenuPoint;
        private BoardObject activeConfiguredBoardObject;
        private Boolean clickOnBoard = false;
        public String clientName = "client";
        private ToolTip toolTip;

        OpenFileDialog openFileDialogImg;


        private BoardLayout activeLayout;
        private LinkedList<BoardObject> boardObjectList;
        private LinkedList<BoardLayout> boardLayoutList;
        //private LinkedList<LinkedList<BoardObject>> boardLayouts;

        //MovingForm
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);

        public FormControlBoard()
        {
            InitializeComponent();
            tcpServer = new TCPServer(this);
            this.Location = Properties.Settings.Default.FormPosition;
            toolTip = new ToolTip();
            setObjectActionList();

            CreateSideMenu();

            //connectedClientToolStripMenuItem.Text = clientName;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // in den Konstruktor packen?
            gridSize = panel_board.Height / gridy;
            offset = (panel_board.Width - gridx * gridSize) / 2;
            //Debug.WriteLine("offset: " + offset);

            boardLayoutList = new LinkedList<BoardLayout>();
            boardObjectList = new LinkedList<BoardObject>();
            AddLayout("main");

            panel_board.Invalidate();
            panel_btn_config.Visible = false;

            if (FormControlBoard.GetAllLocalIPv4(NetworkInterfaceType.Ethernet).ElementAt(0) != null)
                lbl_ip_port.Text = FormControlBoard.GetAllLocalIPv4(NetworkInterfaceType.Ethernet).ElementAt(0) + ":" + Properties.Settings.Default.Port;
            else lbl_ip_port.Text = FormControlBoard.GetAllLocalIPv4(NetworkInterfaceType.Wireless80211).ElementAt(0) + ":" + Properties.Settings.Default.Port;
        }

        private void CreateSideMenu()
        {
            SideMenu sideMenu = new SideMenu(0, 0, 230, 578);
            sideMenu.setSideMenuBackgroundColor(Color.FromArgb(34, 34, 34));
            sideMenu.setFormControlBoard(this);

            sideMenu.mainButtonBackgroundColor = Color.FromArgb(30, 30, 30);
            sideMenu.mainButtonTextColor = Color.FromArgb(255, 255, 255);    // ist sowieso weiß!
            sideMenu.mainButtonBorderColor = Color.FromArgb(60, 60, 60);

            sideMenu.subButtonBackgroundColor = Color.FromArgb(40, 40, 40);
            sideMenu.subButtonTextColor = Color.FromArgb(255, 255, 255);    // ist sowieso weiß!
            sideMenu.subButtonBorderColor = Color.FromArgb(60, 60, 60);

            panel_empty_left_side.Controls.Add(sideMenu);
            foreach (String[] btnActions in objectActionList)
                sideMenu.AddMenuItem(btnActions);
            sideMenu.CloseAllSubMenus();
        }

        public static List<string> GetAllLocalIPv4(NetworkInterfaceType type)
        {
            return NetworkInterface.GetAllNetworkInterfaces()
                           .Where(x => x.NetworkInterfaceType == type && x.OperationalStatus == OperationalStatus.Up)
                           .SelectMany(x => x.GetIPProperties().UnicastAddresses)
                           .Where(x => x.Address.AddressFamily == AddressFamily.InterNetwork)
                           .Select(x => x.Address.ToString())
                           .ToList();
        }

        private T Deserialize<T>(string pathOrFileName)
        {
            BinaryFormatter bformatter = new BinaryFormatter();
            T items;
            using (Stream stream = File.Open(pathOrFileName, FileMode.Open))
            {
                try
                {
                    items = (T)bformatter.Deserialize(stream);
                }
                catch (SerializationException e)
                {
                    Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                    throw;
                }
            }
            return items;
        }

        private void Serialize(String path, object obj)
        {
            using (Stream stream = File.Open(path, FileMode.Create))
            {
                BinaryFormatter bformatter = new BinaryFormatter();

                bformatter.Serialize(stream, obj);
            }
        }

        private void btn_save_layout_Click(object sender, EventArgs e)
        {
            Serialize(System.Environment.CurrentDirectory + @"\Test.bin", boardLayoutList); // .pcb
        }

        private void btn_load_layout_Click(object sender, EventArgs e)
        {
            boardLayoutList = Deserialize<LinkedList<BoardLayout>>(System.Environment.CurrentDirectory + @"\Test.bin");
            changeLayout("main");
            PanelLayoutListUpdate();
            panel_board.Invalidate();
        }

        private void setObjectActionList()
        {
            objectActionList = new LinkedList<String[]>();

            BoardButtonSystem boardButtonSystem = new BoardButtonSystem();
            objectActionList.AddLast(boardButtonSystem.Actions);
            boardButtonSystem = null;
            BoardButtonSounds boardButtonSounds = new BoardButtonSounds();
            objectActionList.AddLast(boardButtonSounds.Actions);
            boardButtonSounds = null;
            BoardButtonBoard boardButtonBoard = new BoardButtonBoard();
            objectActionList.AddLast(boardButtonBoard.Actions);
            boardButtonBoard = null;
        }
        private void btnBoard_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("btnBoard changed ");
            if (clickOnBoard)
            {
                btnBoard.BackgroundImage = PcControlBoard.Properties.Resources.mouse_click7;
                clickOnBoard = false;
            }
            else
            {
                btnBoard.BackgroundImage = PcControlBoard.Properties.Resources.mouse_click8;
                clickOnBoard = true;
            }
            btnBoard.Refresh();
        }
        private void btnSettings_Click(object sender, EventArgs e)
        {
            FormSettings formSettings = new FormSettings();
            formSettings.Show();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            ExitProgram();
        }
        private void btn_taskbar_Click(object sender, EventArgs e)
        {
            //this.ShowInTaskbar = true;
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Minimized;
        }
        private void btn_tray_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }
        private void toolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            Debug.WriteLine(item.Name);
            switch (item.Name)
            {
                case "pcControlBoardToolStripMenuItem":
                    this.WindowState = FormWindowState.Normal;
                    this.ShowInTaskbar = true;
                    break;
                case "exitToolStripMenuItem":
                    ExitProgram();
                    break;
            }
        }
        private void notify_icon_Click(object sender, EventArgs e)
        {
            connectedClientToolStripMenuItem.Text = clientName;
        }
        private void ExitProgram()
        {
            // save
            Properties.Settings.Default.FormPosition = this.Location;
            Properties.Settings.Default.Save();
            Environment.Exit(0);
        }

        public void sideMenuButtonClick(String mainBtn, String subBtn)
        {
            Debug.WriteLine(mainBtn + " " + subBtn);
            // configure new btn
            tb_titel.Text = null;
            try
            {
                // Tag Für BUTTON , Slider...////////////////////////////////////////////////////////

                switch (mainBtn)
                {
                    case "Board":
                        activeConfiguredBoardObject = new BoardButtonBoard(0, 0, 1, 1, "", subBtn);
                        break;
                    case "Sounds":
                        activeConfiguredBoardObject = new BoardButtonSounds(0, 0, 1, 1, "", subBtn);
                        break;
                    case "System":
                        activeConfiguredBoardObject = new BoardButtonSystem(0, 0, 1, 1, "", subBtn);
                        break;

                }
                lbl_btn_action_name.Text = mainBtn + ": " + subBtn;
                openFileDialogImg = null;
                panel_btn_config.Visible = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + "   " + ex.StackTrace);
            }
        }
        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }
        private void panel_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }
        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }
        private void pbImg_MouseDown(object sender, MouseEventArgs e)
        {
            pbImg1.DoDragDrop(pbImg1.BackgroundImage, DragDropEffects.Copy);
        }
        private void board_panel_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }
        private void board_panel_DragDrop(object sender, DragEventArgs e)
        {
            //Debug.WriteLine("DragDrop " + e.X + " " + e.Y);
            int sizex = 1, sizey = 1;
            int ex = e.X - panel_board.Location.X - this.Location.X;
            int ey = e.Y - panel_board.Location.Y - this.Location.Y;

            Debug.WriteLine("DragDrop: " + ex + " " + ey);
            for (int ix = 0; ix < gridx; ix++)
                for (int iy = 0; iy < gridy; iy++)
                {
                    if (ex > ix * gridSize + offset
                        && ex < ix * gridSize + offset + sizex * gridSize
                        && ey > iy * gridSize
                        && ey < iy * gridSize + sizey * gridSize)
                    {
                        if (ix + activeConfiguredBoardObject.Sizex <= gridx && iy + activeConfiguredBoardObject.Sizey <= gridy)
                        {
                            for (int i = 0; i < boardObjectList.Count; i++)
                            {
                                if (boardObjectList.ElementAt(i).IsTouched(ex, ey))
                                {
                                    DialogResult result = MessageBox.Show("Did you want to delete the old object?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (result == DialogResult.Yes)
                                    {
                                        String stringBtnRemove = "btnremove:" + Convert.ToString(boardObjectList.ElementAt(i).Gridx) + "#" + Convert.ToString(boardObjectList.ElementAt(i).Gridy);
                                        Debug.WriteLine("stringBtnRemove: " + stringBtnRemove);
                                        tcpServer.SendData(stringBtnRemove);
                                        boardObjectList.Remove(boardObjectList.ElementAt(i));
                                        panel_board.Invalidate();
                                    }
                                    else return;
                                    break;
                                }
                            }
                            BoardObject newTempObject = activeConfiguredBoardObject.Clone();
                            newTempObject.Gridx = ix;
                            newTempObject.Gridy = iy;
                            if (tb_titel.Text.Replace(" ", "").Length < 1)
                            {
                                newTempObject.Text = Convert.ToString("<null>");
                                //boardObjectList.AddLast(new BoardButton(ix, iy, 1, 1, Convert.ToString("<null>"),objEventTreeView));
                            }
                            else
                            {
                                newTempObject.Text = tb_titel.Text.Replace(" ", "_");
                                //boardObjectList.AddLast(new BoardButton(ix, iy, 1, 1, tb_titel.Text.Replace(" ", "_"), objEventTreeView)); 
                            }
                            boardObjectList.AddLast(newTempObject);

                            Debug.WriteLine("grid gefunden!!! " + ix + " " + iy);
                            panel_board.Invalidate();
                            String dataString = null;
                            if (tb_titel.Text.Length >= 1)
                                dataString = "btn:" + Convert.ToString(ix) + "#" + Convert.ToString(iy) + "#" + Convert.ToString(newTempObject.Sizex) + "#" + Convert.ToString(newTempObject.Sizey) + "#" + tb_titel.Text.Replace(" ", "_") + "#";
                            if (tb_titel.Text.Length < 1)
                                dataString = "btn:" + Convert.ToString(ix) + "#" + Convert.ToString(iy) + "#" + Convert.ToString(newTempObject.Sizex) + "#" + Convert.ToString(newTempObject.Sizey) + "#" + "<null>" + "#";
                            Debug.WriteLine("CB DataString: " + dataString);
                            //tcpServer.SendData(dataString);
                            panel_board.Invalidate();
                            tcpServer.SendLayout("<UpdateLayout>", activeLayout.GetBitmap());
                            //tcpServer.SendButton("<LayoutEnd>", bitmap);
                            //Thread.Sleep(400);
                            //tcpServer.SendButton(dataString, newTempObject.GetBitmap());
                            return;
                        }
                        else MessageBox.Show("Object ist zu Groß", "Error");
                    }
                }
        }

        private void Board_panel_Paint(object sender, PaintEventArgs e)
        {
            iPPortToolStripMenuItem.Text = lbl_ip_port.Text;
            lbl_client_name.Text = "Client: " + clientName;

            /*    Graphics g = e.Graphics;
                Brush brush = new SolidBrush(Color.Gray);
                Pen pen = new Pen(Color.Black);
                for (int ix = 0; ix < gridx; ix++)
                    for (int iy = 0; iy < gridy; iy++)
                    {
                        g.FillRectangle(brush, ix * gridSize + offset, iy * gridSize, gridSize, gridSize);
                        g.DrawRectangle(pen, ix * gridSize + offset, iy * gridSize, gridSize, gridSize);
                    }
                brush = new SolidBrush(Color.DarkGray);
                for (int i = 0; i < boardObjectList.Count; i++)
                {
                    //g.FillRectangle(brush, btnList.ElementAt(i).X * gridSize, btnList.ElementAt(i).Y * gridSize, gridSize, gridSize);
                    //g.DrawRectangle(pen, btnList.ElementAt(i).X * gridSize, btnList.ElementAt(i).Y * gridSize, gridSize, gridSize);
                    //boardObjectList.ElementAt(i).Render(g);
                    g.DrawImage(boardObjectList.ElementAt(i).GetBitmap(), new Point(boardObjectList.ElementAt(i).Gridx * gridSize + offset, boardObjectList.ElementAt(i).Gridy * gridSize));
                }
            */
            // MAIN BITMAP-------------------------------------------------------------

            /*  bitmap = new Bitmap(gridx * gridSize, gridy * gridSize);
              Graphics graphics = Graphics.FromImage(bitmap);
              Brush brush = new SolidBrush(Color.Gray);
              Pen pen = new Pen(Color.Black);
              for (int ix = 0; ix < gridx; ix++)
                  for (int iy = 0; iy < gridy; iy++)
                  {
                      graphics.FillRectangle(brush, ix * gridSize, iy * gridSize, gridSize, gridSize);
                      graphics.DrawRectangle(pen, ix * gridSize, iy * gridSize, gridSize, gridSize);
                  }
              for (int i = 0; i < boardObjectList.Count; i++)
              {
                  graphics.DrawImage(boardObjectList.ElementAt(i).GetBitmap(), new Point(boardObjectList.ElementAt(i).Gridx * gridSize, boardObjectList.ElementAt(i).Gridy * gridSize));
              }
                    */
            e.Graphics.DrawImage(activeLayout.Render(), new Point(offset, 0));        // gridSize berechnen !!!
            //tcpServer.SendLayout("<UpdateLayout>", activeLayout.GetBitmap());           // nicht immer senden nur bei Änderung!!!

        }
        private void board_panel_MouseClick(object sender, MouseEventArgs e)
        {
            if (clickOnBoard)
                if (e.Button == MouseButtons.Left)
                    for (int i = 0; i < boardObjectList.Count; i++)
                        if (boardObjectList.ElementAt(i).IsTouched(e.X, e.Y))
                        {
                            boardObjectList.ElementAt(i).BoardObjectEvent();
                            return;
                        }

            if (e.Button == MouseButtons.Right)
                for (int i = 0; i < boardObjectList.Count; i++)
                    if (boardObjectList.ElementAt(i).IsTouched(e.X, e.Y))
                    {
                        Debug.WriteLine("ContextMenu");
                        ContextMenu contextMenu = new ContextMenu();
                        MenuItem deleteItem = new MenuItem("Delete");
                        MenuItem editItem = new MenuItem("Edit");
                        deleteItem.Click += deleteItem_Click;
                        editItem.Click += editItem_Click;
                        contextMenu.MenuItems.Add(deleteItem);
                        contextMenu.MenuItems.Add(editItem);
                        contextMenuPoint = new Point(e.X, e.Y);
                        contextMenu.Show(this.panel_board, contextMenuPoint);
                        return;
                    }
        }
        private void deleteItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < boardObjectList.Count; i++)
            {
                if (boardObjectList.ElementAt(i).IsTouched(contextMenuPoint.X, contextMenuPoint.Y))
                {

                    String dataString = "btnremove:" + Convert.ToString(boardObjectList.ElementAt(i).Gridx) + "#" + Convert.ToString(boardObjectList.ElementAt(i).Gridy);
                    Debug.WriteLine("DataString: " + dataString);
                    tcpServer.SendData(dataString);

                    boardObjectList.Remove(boardObjectList.ElementAt(i));
                    panel_board.Invalidate();
                    return;
                }
            }
        }
        private void editItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < boardObjectList.Count; i++)
            {
                if (boardObjectList.ElementAt(i).IsTouched(contextMenuPoint.X, contextMenuPoint.Y))
                {
                    activeConfiguredBoardObject = boardObjectList.ElementAt(i).Clone();
                    // im Moment nur für button...
                    lbl_btn_action_name.Text = activeConfiguredBoardObject.Actions.ElementAt(0) + ": " + activeConfiguredBoardObject.BtnEvent;
                    tb_titel.Text = activeConfiguredBoardObject.Text;
                    if (activeConfiguredBoardObject.Text == "<null>")
                        tb_titel.Text = null;
                    panel_btn_config.Visible = true;

                    //String dataString = "btnremove:" + Convert.ToString(boardObjectList.ElementAt(i).Gridx) + "#" + Convert.ToString(boardObjectList.ElementAt(i).Gridy);
                    //Debug.WriteLine("DataString: " + dataString);
                    //tcpServer.SendData(dataString);
                    //boardObjectList.Remove(boardObjectList.ElementAt(i));
                    //board_panel.Invalidate();
                    return;
                }
            }
        }
        public void SendLayouts()
        {
            String gridString = "grid:" + Convert.ToString(gridx + "#" + gridy);
            tcpServer.SendData(gridString);
            foreach (BoardLayout bl in boardLayoutList)
            {
                Thread.Sleep(10);
                tcpServer.SendLayout("addLayout>" + bl.name + ">" + bl.gridx + ">" + bl.gridy + ">", bl.GetBitmap());
            }
            Thread.Sleep(400);
            tcpServer.SendData("changeLayout>" + activeLayout.name);

        }

        public void UpdateMessage(String message)
        {
            Console.WriteLine("UpdateBoardAction");
            ParameterizedThreadStart updateMessage = new ParameterizedThreadStart(this.UpdateMessageThread);
            Thread thread = new Thread(updateMessage);
            thread.Start(message);

        }
        public void UpdateMessageThread(Object parameter)
        {
            String message = (String)parameter;
            Debug.WriteLine(message);

            if (message.Contains("<"))
            {
                if (message.Contains("<name:"))
                {
                    Debug.WriteLine(message);
                    String temp1 = message.Replace('>', ' ');
                    String[] temp = temp1.Split(':');
                    SetClientName(temp[1]);
                }
                else if (message.Equals("<sendLayouts>"))
                {
                    SendLayouts();
                }
            }
            else
            {
                if (message.Contains("btn:"))
                {
                    String[] temp = message.Split(':');
                    String[] splitBtn = temp[1].Split('#');
                    BoardObjectEvent(int.Parse(splitBtn[0]), int.Parse(splitBtn[1]));
                }
            }

        }
        private void btn_config_delete_Click(object sender, EventArgs e)
        {
            panel_btn_config.Visible = false;
            activeConfiguredBoardObject = null;
        }
        private void boardobj_options_Click(object sender, EventArgs e)
        {
            activeConfiguredBoardObject.ShowOptions();
        }

        public void btn_layout_list_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Debug.WriteLine("btn text = " + btn.Text);
            changeLayout(btn.Text);

            //test
            FocusSelectedLayoutBtn();
        }

        private void FocusSelectedLayoutBtn()
        {
            foreach (BoardLayout bl in boardLayoutList)
                bl.Focus(false);
            activeLayout.Focus(true);
        }

        private void btn_add_new_layout_Click(object sender, EventArgs e)                   // Layout Namen Abfragen
        {
            //boardLayoutList.AddLast(new BoardLayout(boardLayoutList.Count.ToString()));     // TEST...
            AddLayout(boardLayoutList.Count.ToString());
            boardObjectList = boardLayoutList.ElementAt(boardLayoutList.Count - 1).boardObjects;
            panel_board.Invalidate();
        }

        private void BoardObjectEvent(int gx, int gy)
        {
            for (int i = 0; i < boardObjectList.Count(); i++)
            {
                if (boardObjectList.ElementAt(i).Gridx == gx && boardObjectList.ElementAt(i).Gridy == gy)
                {
                    boardObjectList.ElementAt(i).BoardObjectEvent();
                    return;
                }
            }
        }

        public void changeLayout(String layoutName)
        {
            Debug.WriteLine("Change Layout: " + layoutName);
            if (layoutName == "<previous_layout>")
            {
                Debug.WriteLine("ControllBoard: Previous Layout");
                for (int i = 0; i < boardLayoutList.Count; i++)
                {
                    if (boardLayoutList.ElementAt(i) == activeLayout)
                        if (i != 0)
                        {
                            boardObjectList = boardLayoutList.ElementAt(i - 1).boardObjects;
                            activeLayout = boardLayoutList.ElementAt(i - 1);
                            panel_board.Invalidate();
                            //tcpServer.SendData("<clearLayout>");
                            tcpServer.SendData("<changeLayout>" + activeLayout.name);
                            break;
                        }
                        else
                        {
                            boardObjectList = boardLayoutList.ElementAt(boardLayoutList.Count - 1).boardObjects;
                            activeLayout = boardLayoutList.ElementAt(boardLayoutList.Count - 1);
                            panel_board.Invalidate();
                            //tcpServer.SendData("<clearLayout>");
                            tcpServer.SendData("<changeLayout>" + activeLayout.name);
                        }
                }
            }
            else if (layoutName == "<next_layout>")
            {
                Debug.WriteLine("ControllBoard: Next Layout");
                for (int i = 0; i < boardLayoutList.Count; i++)
                {
                    if (boardLayoutList.ElementAt(i) == activeLayout)
                        if (i != boardLayoutList.Count - 1)
                        {
                            boardObjectList = boardLayoutList.ElementAt(i + 1).boardObjects;
                            activeLayout = boardLayoutList.ElementAt(i + 1);
                            panel_board.Invalidate();
                            // tcpServer.SendData("<clearLayout>");
                            tcpServer.SendData("<changeLayout>" + activeLayout.name);
                            break;
                        }
                        else
                        {
                            boardObjectList = boardLayoutList.ElementAt(0).boardObjects;
                            activeLayout = boardLayoutList.ElementAt(0);
                            panel_board.Invalidate();
                            // tcpServer.SendData("<clearLayout>");
                            tcpServer.SendData("<changeLayout>" + activeLayout.name);
                        }
                }
            }
            else               // direkt zum namen wechseln 
            {
                Debug.WriteLine("ControllBoard: Changed Active Layout to: " + layoutName);
                for (int i = 0; i < boardLayoutList.Count; i++)
                {
                    if (boardLayoutList.ElementAt(i).name == layoutName)
                    {
                        boardObjectList = boardLayoutList.ElementAt(i).boardObjects;
                        activeLayout = boardLayoutList.ElementAt(i);
                        panel_board.Invalidate();
                        //tcpServer.SendData("<clearLayout>");
                        tcpServer.SendData("<changeLayout>" + activeLayout.name);
                        break;
                    }
                }
            }
            FocusSelectedLayoutBtn();
        }

        private void AddLayout(string layoutName)
        {
            Debug.WriteLine("ControllBoard: add Layout: " + layoutName);
            for (int i = 0; i < boardLayoutList.Count; i++)
            {
                if (boardLayoutList.ElementAt(i).name == layoutName)
                {
                    MessageBox.Show("A layout with this name already exists!", "Error");
                    return;
                }
            }
            BoardLayout tempBL = new BoardLayout(layoutName, gridx, gridy, panel_board.Height);               // change GRID...
            boardLayoutList.AddLast(tempBL);
            // boardLayoutButtonList.AddLast(tempBL.getButton(panel_layout_list.Width));
            // panel_layout_list.Controls.Add(tempBL.getButton(panel_layout_list.Width));  // verbessern?
            PanelLayoutListUpdate();
            tcpServer.SendLayout("addLayout>" + tempBL.name + ">" + tempBL.gridx + ">" + tempBL.gridy + ">", tempBL.GetBitmap());
            changeLayout(layoutName);
        }
        private void RemoveLayout(BoardLayout boardLayout)
        {
            Debug.WriteLine("ControllBoard: remove Layout: " + boardLayout.name);
            for (int i = 0; i < boardLayoutList.Count; i++)
            {
                if (boardLayoutList.ElementAt(i) == boardLayout)
                {
                    if (boardLayout.name == "main")
                    {
                        MessageBox.Show("The main layout cannot be deleted.", "Error");
                        return;
                    }
                    DialogResult result = MessageBox.Show("do you want to delete the layout " + boardLayout.name + "?",
                    "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        boardLayoutList.Remove(boardLayoutList.ElementAt(i));
                        //  boardLayoutButtonList.Remove(boardLayoutButtonList.ElementAt(i));
                        //panel_layout_list.Controls.RemoveAt(i);
                        PanelLayoutListUpdate();
                        tcpServer.SendData("removeLayout>" + boardLayout.name);
                        changeLayout(boardLayoutList.ElementAt(i - 1).name);
                    }
                    else return;
                }
            }
        }

        private void PanelLayoutListUpdate()
        {
            panel_layout_list.Controls.Clear();
            for (int i = boardLayoutList.Count - 1; i >= 0; i--)
            {
                panel_layout_list.Controls.Add(boardLayoutList.ElementAt(i).GetButton());
            }
        }

        private void btn_remove_layout_Click(object sender, EventArgs e)
        {
            RemoveLayout(activeLayout);
        }

        public void SetClientName(string name)
        {
            clientName = name;
            connectedClientToolStripMenuItem.Text = clientName;
            //panel_board.Invalidate();
        }

        private void btnBoard_MouseHover(object sender, EventArgs e)
        {
            if (!clickOnBoard) toolTip.Show("enable mouse on board", btnBoard);
            else toolTip.Show("disable mouse on Board", btnBoard);
        }

        private void btn_choose_icon_Click(object sender, EventArgs e)
        {
            openFileDialogImg = new OpenFileDialog();
            openFileDialogImg.FileName = "select Image";
            //image filter
            openFileDialogImg.FileOk += new System.ComponentModel.CancelEventHandler(openFileDialogImg_ok);
            openFileDialogImg.ShowDialog();
        }
        private void openFileDialogImg_ok(object sender, EventArgs e)
        {
            activeConfiguredBoardObject.backgroundBmp = new Bitmap(Image.FromFile(openFileDialogImg.FileName));
        }

        [Serializable]
        class BoardLayout
        {
            public int gridx, gridy, gridSize;
            public String name;
            public Bitmap bitmap;
            public LinkedList<BoardObject> boardObjects;
            [NonSerialized] public Button btn = null;

            public BoardLayout(String name, int gridx, int gridy, int pHeight)
            {
                this.name = name;
                this.gridx = gridx;
                this.gridy = gridy;
                this.gridSize = pHeight / gridy;
                boardObjects = new LinkedList<BoardObject>();
            }
            public Button GetButton()
            {
                if (btn == null)
                {
                    btn = new Button();
                    btn.BackColor = Color.FromArgb(30, 30, 30);
                    btn.ForeColor = Color.FromArgb(255, 255, 255);
                    btn.FlatAppearance.BorderColor = Color.FromArgb(60, 60, 60);
                    btn.Dock = DockStyle.Top;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.Location = new Point(0, 10);
                    btn.Name = "btn_layout_" + name;
                    btn.Padding = new Padding(10, 0, 0, 0);
                    btn.Size = new Size(230, 30);   // height = 30
                    btn.Text = name;
                    btn.TextAlign = ContentAlignment.MiddleLeft;
                    btn.UseVisualStyleBackColor = true;
                    btn.Click += Program.formControlBoard.btn_layout_list_Click;
                }
                return btn;
            }

            public Bitmap Render()
            {
                bitmap = new Bitmap(gridx * gridSize, gridy * gridSize);
                Graphics graphics = Graphics.FromImage(bitmap);
                Brush brush = new SolidBrush(Color.Gray);
                Pen pen = new Pen(Color.Black);
                for (int ix = 0; ix < gridx; ix++)
                    for (int iy = 0; iy < gridy; iy++)
                    {
                        graphics.FillRectangle(brush, ix * gridSize, iy * gridSize, gridSize, gridSize);
                        graphics.DrawRectangle(pen, ix * gridSize, iy * gridSize, gridSize, gridSize);
                    }
                for (int i = 0; i < boardObjects.Count; i++)
                {
                    graphics.DrawImage(boardObjects.ElementAt(i).GetBitmap(), new Point(boardObjects.ElementAt(i).Gridx * gridSize, boardObjects.ElementAt(i).Gridy * gridSize));
                }
                return bitmap;
            }

            public Bitmap GetBitmap()
            {
                if (bitmap == null)
                    return Render();
                return bitmap;
            }

            public void Focus(Boolean inFocus)
            {
                if (btn == null) GetButton();
                if (inFocus) btn.BackColor = Color.FromArgb(40, 40, 40);
                else btn.BackColor = Color.FromArgb(30, 30, 30);
            }
        }


    }
}

