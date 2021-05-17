using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PcControlBoard
{
    class SideMenu : Panel
    {
        FormControlBoard formControlBoard;
        public void setFormControlBoard(FormControlBoard formControlBoard) { this.formControlBoard = formControlBoard; }

        private readonly int SUB_BTN_SIZE = 45;
        private LinkedList<String> menuItems;               // wird nicht benutzt

        public Color mainButtonBackgroundColor;
        public Color mainButtonTextColor = System.Drawing.Color.White;
        public Color mainButtonBorderColor = System.Drawing.Color.Gray;

        public Color subButtonBackgroundColor;
        public Color subButtonTextColor = System.Drawing.Color.White;
        public Color subButtonBorderColor = System.Drawing.Color.Gray;


        private LinkedList<Panel> subPanelList;
        private int nextElementY = 0;
        public SideMenu(int x, int y, int w, int h)
        {

            menuItems = new LinkedList<String>();
            subPanelList = new LinkedList<Panel>();


            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.Location = new System.Drawing.Point(x, y);
            this.Name = "sidePanel";
            this.Size = new System.Drawing.Size(w, h);

            Panel panel_action_image = new Panel();
            panel_action_image.Dock = System.Windows.Forms.DockStyle.Top;
            panel_action_image.Location = new System.Drawing.Point(x, y);
            panel_action_image.Name = "panel_action_image";
            panel_action_image.Size = new System.Drawing.Size(this.Width, 20);
            this.Controls.Add(panel_action_image);
        }

        public void setSideMenuBackgroundColor(Color c) { this.BackColor = c; }


        public void AddMenuItem(String[] pMenuItem)
        {
            pMenuItem.First();
            Panel subPanel = CreateSubPanel(pMenuItem.Length - 1, pMenuItem.First());
            for (int i = pMenuItem.Length - 1; i > 0; i--)
                subPanel.Controls.Add(CreateSubButton(i, pMenuItem.ElementAt(i), pMenuItem.First()));
            this.Controls.Add(subPanel);
            this.Controls.Add(CreateMainButton(pMenuItem.First()));
        }



        private Button CreateMainButton(String name)
        {
            Button btn = new Button();
            btn.BackColor = mainButtonBackgroundColor;
            btn.ForeColor = mainButtonTextColor;
            btn.Dock = System.Windows.Forms.DockStyle.Top;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = mainButtonBorderColor;
            btn.Location = new System.Drawing.Point(0, nextElementY);
            btn.Name = "main_btn_" + name;
            btn.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            btn.Size = new System.Drawing.Size(this.Size.Width, 45);
            //btn.TabIndex = 0;
            btn.Text = name;
            btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn.UseVisualStyleBackColor = true;
            btn.Click += main_btn_Click;
            nextElementY += btn.Size.Height;        //position des nächsten Elements
            Debug.WriteLine(nextElementY);

            return btn;
        }

        private Panel CreateSubPanel(int itemCount, String mainBtn)
        {
            Panel subPanel = new Panel();
            subPanel.Dock = System.Windows.Forms.DockStyle.Top;
            subPanel.Location = new System.Drawing.Point(0, nextElementY);
            subPanel.Name = "subpanel_" + mainBtn;
            subPanel.Size = new System.Drawing.Size(this.Size.Width, itemCount * SUB_BTN_SIZE);
            nextElementY += subPanel.Size.Height;        //position des nächsten Elements
            Debug.WriteLine(nextElementY);
            subPanelList.AddLast(subPanel);
            return subPanel;
        }

        private Button CreateSubButton(int index, String subBtnName, String mainBtn)
        {
            Button subBtn = new Button();
            subBtn.BackColor = subButtonBackgroundColor;
            subBtn.ForeColor = subButtonTextColor;
            subBtn.Dock = System.Windows.Forms.DockStyle.Top;
            //subBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;     //  Ändern?
            subBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            subBtn.FlatAppearance.BorderColor = subButtonBorderColor;

            subBtn.Location = new System.Drawing.Point(0, index * SUB_BTN_SIZE);
            subBtn.Name = mainBtn + "_subbtn_" + subBtnName;
            subBtn.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            subBtn.Size = new System.Drawing.Size(this.Size.Width, SUB_BTN_SIZE);
            subBtn.Text = subBtnName;
            subBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            subBtn.UseVisualStyleBackColor = true;
            subBtn.Click += sub_btn_Click;
            return subBtn;
        }


        public void CloseAllSubMenus()
        {
            foreach (Panel panel in subPanelList)
                panel.Visible = false;
        }

        private void sub_btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Debug.WriteLine(btn.Name);
            String[] temp = btn.Name.Split('_');
            formControlBoard.sideMenuButtonClick(temp[0], temp[2]);
        }

        private void main_btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Debug.WriteLine(btn.Name);
            foreach (Panel panel in subPanelList)
            {
                if (btn.Name.Replace("main_btn_", "") == panel.Name.Replace("subpanel_", ""))
                {
                    if (panel.Visible == false) panel.Visible = true;
                    else panel.Visible = false;
                    break;
                }
            }

        }



    }
}
