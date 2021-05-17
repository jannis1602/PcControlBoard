using System.Drawing;

namespace PcControlBoard
{
    partial class FormControlBoard
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormControlBoard));
            this.panel_drag = new System.Windows.Forms.Panel();
            this.lbl_window_title = new System.Windows.Forms.Label();
            this.btn_panel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnBoard = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnAccounts = new System.Windows.Forms.Button();
            this.panel_exit_mini_tray = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_taskbar = new System.Windows.Forms.Button();
            this.btn_tray = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.panel_board = new System.Windows.Forms.Panel();
            this.tb_titel = new System.Windows.Forms.TextBox();
            this.lbl_titel = new System.Windows.Forms.Label();
            this.boardobj_options = new System.Windows.Forms.Button();
            this.panel_btn_config = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_btn_bg_color = new System.Windows.Forms.Label();
            this.btn_edit_title = new System.Windows.Forms.Button();
            this.btn_choose_icon = new System.Windows.Forms.Button();
            this.lbl_icon = new System.Windows.Forms.Label();
            this.lbl_btn_action_name = new System.Windows.Forms.Label();
            this.btn_config_delete = new System.Windows.Forms.Button();
            this.pbImg1 = new System.Windows.Forms.PictureBox();
            this.panel_empty_left_side = new System.Windows.Forms.Panel();
            this.panel_layout_list = new System.Windows.Forms.Panel();
            this.panel_layout_list_top = new System.Windows.Forms.Panel();
            this.panel_layout_list_bottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_add_new_layout = new System.Windows.Forms.Button();
            this.btn_remove_layout = new System.Windows.Forms.Button();
            this.btn_save_layout = new System.Windows.Forms.Button();
            this.btn_load_layout = new System.Windows.Forms.Button();
            this.lbl_ip_port = new System.Windows.Forms.Label();
            this.notify_icon = new System.Windows.Forms.NotifyIcon(this.components);
            this.context_menu_notify_icon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pcControlBoardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iPPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectedClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_client_name = new System.Windows.Forms.Label();
            this.btn_action_button_list = new System.Windows.Forms.Button();
            this.btn_layout_list = new System.Windows.Forms.Button();
            this.panel_client_name = new System.Windows.Forms.FlowLayoutPanel();
            this.panel_drag.SuspendLayout();
            this.btn_panel.SuspendLayout();
            this.panel_exit_mini_tray.SuspendLayout();
            this.panel_btn_config.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImg1)).BeginInit();
            this.panel_layout_list.SuspendLayout();
            this.panel_layout_list_bottom.SuspendLayout();
            this.context_menu_notify_icon.SuspendLayout();
            this.panel_client_name.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_drag
            // 
            this.panel_drag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(102)))), ((int)(((byte)(150)))));
            this.panel_drag.Controls.Add(this.lbl_window_title);
            this.panel_drag.Controls.Add(this.btn_panel);
            this.panel_drag.Controls.Add(this.panel_exit_mini_tray);
            this.panel_drag.Location = new System.Drawing.Point(0, 0);
            this.panel_drag.Margin = new System.Windows.Forms.Padding(0);
            this.panel_drag.Name = "panel_drag";
            this.panel_drag.Size = new System.Drawing.Size(1151, 30);
            this.panel_drag.TabIndex = 3;
            this.panel_drag.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            this.panel_drag.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_MouseMove);
            this.panel_drag.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_MouseUp);
            // 
            // lbl_window_title
            // 
            this.lbl_window_title.AutoSize = true;
            this.lbl_window_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_window_title.Location = new System.Drawing.Point(2, 5);
            this.lbl_window_title.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_window_title.Name = "lbl_window_title";
            this.lbl_window_title.Size = new System.Drawing.Size(171, 20);
            this.lbl_window_title.TabIndex = 0;
            this.lbl_window_title.Text = "PcControlBoard v.0.1.1";
            // 
            // btn_panel
            // 
            this.btn_panel.Controls.Add(this.btnBoard);
            this.btn_panel.Controls.Add(this.btnSettings);
            this.btn_panel.Controls.Add(this.btnAccounts);
            this.btn_panel.Location = new System.Drawing.Point(221, 0);
            this.btn_panel.Margin = new System.Windows.Forms.Padding(0);
            this.btn_panel.Name = "btn_panel";
            this.btn_panel.Size = new System.Drawing.Size(90, 30);
            this.btn_panel.TabIndex = 7;
            // 
            // btnBoard
            // 
            this.btnBoard.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBoard.BackgroundImage")));
            this.btnBoard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBoard.FlatAppearance.BorderSize = 0;
            this.btnBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBoard.Location = new System.Drawing.Point(0, 0);
            this.btnBoard.Margin = new System.Windows.Forms.Padding(0);
            this.btnBoard.Name = "btnBoard";
            this.btnBoard.Size = new System.Drawing.Size(30, 30);
            this.btnBoard.TabIndex = 0;
            this.btnBoard.UseVisualStyleBackColor = true;
            this.btnBoard.Click += new System.EventHandler(this.btnBoard_Click);
            this.btnBoard.MouseHover += new System.EventHandler(this.btnBoard_MouseHover);
            // 
            // btnSettings
            // 
            this.btnSettings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSettings.BackgroundImage")));
            this.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Location = new System.Drawing.Point(30, 0);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(0);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(30, 30);
            this.btnSettings.TabIndex = 1;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnAccounts
            // 
            this.btnAccounts.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAccounts.BackgroundImage")));
            this.btnAccounts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAccounts.FlatAppearance.BorderSize = 0;
            this.btnAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccounts.Location = new System.Drawing.Point(60, 0);
            this.btnAccounts.Margin = new System.Windows.Forms.Padding(0);
            this.btnAccounts.Name = "btnAccounts";
            this.btnAccounts.Size = new System.Drawing.Size(30, 30);
            this.btnAccounts.TabIndex = 2;
            this.btnAccounts.UseVisualStyleBackColor = true;
            // 
            // panel_exit_mini_tray
            // 
            this.panel_exit_mini_tray.Controls.Add(this.btn_taskbar);
            this.panel_exit_mini_tray.Controls.Add(this.btn_tray);
            this.panel_exit_mini_tray.Controls.Add(this.btn_exit);
            this.panel_exit_mini_tray.Location = new System.Drawing.Point(1061, 0);
            this.panel_exit_mini_tray.Margin = new System.Windows.Forms.Padding(0);
            this.panel_exit_mini_tray.Name = "panel_exit_mini_tray";
            this.panel_exit_mini_tray.Size = new System.Drawing.Size(90, 30);
            this.panel_exit_mini_tray.TabIndex = 4;
            // 
            // btn_taskbar
            // 
            this.btn_taskbar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_taskbar.BackgroundImage")));
            this.btn_taskbar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_taskbar.FlatAppearance.BorderSize = 0;
            this.btn_taskbar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_taskbar.Location = new System.Drawing.Point(0, 0);
            this.btn_taskbar.Margin = new System.Windows.Forms.Padding(0);
            this.btn_taskbar.Name = "btn_taskbar";
            this.btn_taskbar.Size = new System.Drawing.Size(30, 30);
            this.btn_taskbar.TabIndex = 0;
            this.btn_taskbar.UseVisualStyleBackColor = true;
            this.btn_taskbar.Click += new System.EventHandler(this.btn_taskbar_Click);
            // 
            // btn_tray
            // 
            this.btn_tray.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_tray.BackgroundImage")));
            this.btn_tray.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_tray.FlatAppearance.BorderSize = 0;
            this.btn_tray.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_tray.Location = new System.Drawing.Point(30, 0);
            this.btn_tray.Margin = new System.Windows.Forms.Padding(0);
            this.btn_tray.Name = "btn_tray";
            this.btn_tray.Size = new System.Drawing.Size(30, 30);
            this.btn_tray.TabIndex = 1;
            this.btn_tray.UseVisualStyleBackColor = true;
            this.btn_tray.Click += new System.EventHandler(this.btn_tray_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_exit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_exit.BackgroundImage")));
            this.btn_exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_exit.FlatAppearance.BorderSize = 0;
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.Location = new System.Drawing.Point(60, 0);
            this.btn_exit.Margin = new System.Windows.Forms.Padding(0);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(30, 30);
            this.btn_exit.TabIndex = 2;
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // panel_board
            // 
            this.panel_board.AllowDrop = true;
            this.panel_board.Location = new System.Drawing.Point(250, 60);
            this.panel_board.Margin = new System.Windows.Forms.Padding(3, 30, 3, 3);
            this.panel_board.Name = "panel_board";
            this.panel_board.Size = new System.Drawing.Size(650, 350);
            this.panel_board.TabIndex = 5;
            this.panel_board.DragDrop += new System.Windows.Forms.DragEventHandler(this.board_panel_DragDrop);
            this.panel_board.DragOver += new System.Windows.Forms.DragEventHandler(this.board_panel_DragOver);
            this.panel_board.Paint += new System.Windows.Forms.PaintEventHandler(this.Board_panel_Paint);
            this.panel_board.MouseClick += new System.Windows.Forms.MouseEventHandler(this.board_panel_MouseClick);
            // 
            // tb_titel
            // 
            this.tb_titel.BackColor = System.Drawing.Color.Silver;
            this.tb_titel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_titel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_titel.Location = new System.Drawing.Point(148, 23);
            this.tb_titel.Margin = new System.Windows.Forms.Padding(1, 1, 3, 3);
            this.tb_titel.MaxLength = 30;
            this.tb_titel.Name = "tb_titel";
            this.tb_titel.Size = new System.Drawing.Size(100, 19);
            this.tb_titel.TabIndex = 8;
            // 
            // lbl_titel
            // 
            this.lbl_titel.AutoSize = true;
            this.lbl_titel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_titel.Location = new System.Drawing.Point(106, 24);
            this.lbl_titel.Margin = new System.Windows.Forms.Padding(3, 1, 2, 0);
            this.lbl_titel.Name = "lbl_titel";
            this.lbl_titel.Size = new System.Drawing.Size(39, 18);
            this.lbl_titel.TabIndex = 9;
            this.lbl_titel.Text = "Titel:";
            // 
            // boardobj_options
            // 
            this.boardobj_options.BackColor = System.Drawing.Color.Gray;
            this.boardobj_options.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.boardobj_options.Location = new System.Drawing.Point(0, 131);
            this.boardobj_options.Name = "boardobj_options";
            this.boardobj_options.Size = new System.Drawing.Size(101, 31);
            this.boardobj_options.TabIndex = 10;
            this.boardobj_options.Text = "Options";
            this.boardobj_options.UseVisualStyleBackColor = false;
            this.boardobj_options.Click += new System.EventHandler(this.boardobj_options_Click);
            // 
            // panel_btn_config
            // 
            this.panel_btn_config.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel_btn_config.Controls.Add(this.button1);
            this.panel_btn_config.Controls.Add(this.lbl_btn_bg_color);
            this.panel_btn_config.Controls.Add(this.btn_edit_title);
            this.panel_btn_config.Controls.Add(this.btn_choose_icon);
            this.panel_btn_config.Controls.Add(this.lbl_icon);
            this.panel_btn_config.Controls.Add(this.lbl_btn_action_name);
            this.panel_btn_config.Controls.Add(this.tb_titel);
            this.panel_btn_config.Controls.Add(this.lbl_titel);
            this.panel_btn_config.Controls.Add(this.btn_config_delete);
            this.panel_btn_config.Controls.Add(this.pbImg1);
            this.panel_btn_config.Controls.Add(this.boardobj_options);
            this.panel_btn_config.Location = new System.Drawing.Point(250, 418);
            this.panel_btn_config.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.panel_btn_config.Name = "panel_btn_config";
            this.panel_btn_config.Size = new System.Drawing.Size(650, 220);
            this.panel_btn_config.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(160, 70);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 22);
            this.button1.TabIndex = 17;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // lbl_btn_bg_color
            // 
            this.lbl_btn_bg_color.AutoSize = true;
            this.lbl_btn_bg_color.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_btn_bg_color.Location = new System.Drawing.Point(106, 72);
            this.lbl_btn_bg_color.Margin = new System.Windows.Forms.Padding(3, 6, 2, 0);
            this.lbl_btn_bg_color.Name = "lbl_btn_bg_color";
            this.lbl_btn_bg_color.Size = new System.Drawing.Size(49, 18);
            this.lbl_btn_bg_color.TabIndex = 16;
            this.lbl_btn_bg_color.Text = "Color:";
            // 
            // btn_edit_title
            // 
            this.btn_edit_title.Location = new System.Drawing.Point(254, 23);
            this.btn_edit_title.Name = "btn_edit_title";
            this.btn_edit_title.Size = new System.Drawing.Size(20, 20);
            this.btn_edit_title.TabIndex = 15;
            this.btn_edit_title.Text = "T";
            this.btn_edit_title.UseVisualStyleBackColor = true;
            // 
            // btn_choose_icon
            // 
            this.btn_choose_icon.BackColor = System.Drawing.Color.Gray;
            this.btn_choose_icon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_choose_icon.Location = new System.Drawing.Point(148, 46);
            this.btn_choose_icon.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btn_choose_icon.Name = "btn_choose_icon";
            this.btn_choose_icon.Size = new System.Drawing.Size(100, 22);
            this.btn_choose_icon.TabIndex = 14;
            this.btn_choose_icon.Text = "choose...";
            this.btn_choose_icon.UseVisualStyleBackColor = false;
            this.btn_choose_icon.Click += new System.EventHandler(this.btn_choose_icon_Click);
            // 
            // lbl_icon
            // 
            this.lbl_icon.AutoSize = true;
            this.lbl_icon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_icon.Location = new System.Drawing.Point(106, 48);
            this.lbl_icon.Margin = new System.Windows.Forms.Padding(3, 1, 2, 0);
            this.lbl_icon.Name = "lbl_icon";
            this.lbl_icon.Size = new System.Drawing.Size(40, 18);
            this.lbl_icon.TabIndex = 13;
            this.lbl_icon.Text = "Icon:";
            // 
            // lbl_btn_action_name
            // 
            this.lbl_btn_action_name.AutoSize = true;
            this.lbl_btn_action_name.BackColor = System.Drawing.Color.Gray;
            this.lbl_btn_action_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_btn_action_name.Location = new System.Drawing.Point(2, 2);
            this.lbl_btn_action_name.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_btn_action_name.Name = "lbl_btn_action_name";
            this.lbl_btn_action_name.Size = new System.Drawing.Size(97, 18);
            this.lbl_btn_action_name.TabIndex = 12;
            this.lbl_btn_action_name.Text = "Board: Action";
            // 
            // btn_config_delete
            // 
            this.btn_config_delete.BackColor = System.Drawing.Color.Sienna;
            this.btn_config_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_config_delete.Location = new System.Drawing.Point(622, 3);
            this.btn_config_delete.Name = "btn_config_delete";
            this.btn_config_delete.Size = new System.Drawing.Size(25, 25);
            this.btn_config_delete.TabIndex = 11;
            this.btn_config_delete.Text = "X";
            this.btn_config_delete.UseVisualStyleBackColor = false;
            this.btn_config_delete.Click += new System.EventHandler(this.btn_config_delete_Click);
            // 
            // pbImg1
            // 
            this.pbImg1.BackColor = System.Drawing.Color.DimGray;
            this.pbImg1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbImg1.BackgroundImage")));
            this.pbImg1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbImg1.InitialImage = null;
            this.pbImg1.Location = new System.Drawing.Point(0, 25);
            this.pbImg1.Name = "pbImg1";
            this.pbImg1.Size = new System.Drawing.Size(100, 100);
            this.pbImg1.TabIndex = 6;
            this.pbImg1.TabStop = false;
            this.pbImg1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbImg_MouseDown);
            // 
            // panel_empty_left_side
            // 
            this.panel_empty_left_side.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.panel_empty_left_side.Location = new System.Drawing.Point(0, 90);
            this.panel_empty_left_side.Margin = new System.Windows.Forms.Padding(3, 0, 20, 3);
            this.panel_empty_left_side.Name = "panel_empty_left_side";
            this.panel_empty_left_side.Size = new System.Drawing.Size(230, 548);
            this.panel_empty_left_side.TabIndex = 12;
            // 
            // panel_layout_list
            // 
            this.panel_layout_list.AutoScroll = true;
            this.panel_layout_list.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.panel_layout_list.Controls.Add(this.panel_layout_list_top);
            this.panel_layout_list.Location = new System.Drawing.Point(920, 90);
            this.panel_layout_list.Margin = new System.Windows.Forms.Padding(20, 3, 3, 0);
            this.panel_layout_list.Name = "panel_layout_list";
            this.panel_layout_list.Size = new System.Drawing.Size(230, 508);
            this.panel_layout_list.TabIndex = 13;
            // 
            // panel_layout_list_top
            // 
            this.panel_layout_list_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_layout_list_top.Location = new System.Drawing.Point(0, 0);
            this.panel_layout_list_top.Name = "panel_layout_list_top";
            this.panel_layout_list_top.Size = new System.Drawing.Size(230, 20);
            this.panel_layout_list_top.TabIndex = 3;
            // 
            // panel_layout_list_bottom
            // 
            this.panel_layout_list_bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel_layout_list_bottom.Controls.Add(this.btn_add_new_layout);
            this.panel_layout_list_bottom.Controls.Add(this.btn_remove_layout);
            this.panel_layout_list_bottom.Controls.Add(this.btn_save_layout);
            this.panel_layout_list_bottom.Controls.Add(this.btn_load_layout);
            this.panel_layout_list_bottom.Location = new System.Drawing.Point(920, 598);
            this.panel_layout_list_bottom.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.panel_layout_list_bottom.Name = "panel_layout_list_bottom";
            this.panel_layout_list_bottom.Size = new System.Drawing.Size(230, 40);
            this.panel_layout_list_bottom.TabIndex = 2;
            // 
            // btn_add_new_layout
            // 
            this.btn_add_new_layout.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_add_new_layout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add_new_layout.ForeColor = System.Drawing.Color.White;
            this.btn_add_new_layout.Location = new System.Drawing.Point(0, 0);
            this.btn_add_new_layout.Margin = new System.Windows.Forms.Padding(0);
            this.btn_add_new_layout.Name = "btn_add_new_layout";
            this.btn_add_new_layout.Size = new System.Drawing.Size(40, 40);
            this.btn_add_new_layout.TabIndex = 0;
            this.btn_add_new_layout.Text = "new Layout";
            this.btn_add_new_layout.UseVisualStyleBackColor = true;
            this.btn_add_new_layout.Click += new System.EventHandler(this.btn_add_new_layout_Click);
            // 
            // btn_remove_layout
            // 
            this.btn_remove_layout.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_remove_layout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_remove_layout.ForeColor = System.Drawing.Color.White;
            this.btn_remove_layout.Location = new System.Drawing.Point(40, 0);
            this.btn_remove_layout.Margin = new System.Windows.Forms.Padding(0);
            this.btn_remove_layout.Name = "btn_remove_layout";
            this.btn_remove_layout.Size = new System.Drawing.Size(40, 40);
            this.btn_remove_layout.TabIndex = 3;
            this.btn_remove_layout.Text = "delete Layout";
            this.btn_remove_layout.UseVisualStyleBackColor = true;
            this.btn_remove_layout.Click += new System.EventHandler(this.btn_remove_layout_Click);
            // 
            // btn_save_layout
            // 
            this.btn_save_layout.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_save_layout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save_layout.ForeColor = System.Drawing.Color.White;
            this.btn_save_layout.Location = new System.Drawing.Point(80, 0);
            this.btn_save_layout.Margin = new System.Windows.Forms.Padding(0);
            this.btn_save_layout.Name = "btn_save_layout";
            this.btn_save_layout.Size = new System.Drawing.Size(40, 40);
            this.btn_save_layout.TabIndex = 1;
            this.btn_save_layout.Text = "save Layouts";
            this.btn_save_layout.UseVisualStyleBackColor = true;
            this.btn_save_layout.Click += new System.EventHandler(this.btn_save_layout_Click);
            // 
            // btn_load_layout
            // 
            this.btn_load_layout.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_load_layout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_load_layout.ForeColor = System.Drawing.Color.White;
            this.btn_load_layout.Location = new System.Drawing.Point(120, 0);
            this.btn_load_layout.Margin = new System.Windows.Forms.Padding(0);
            this.btn_load_layout.Name = "btn_load_layout";
            this.btn_load_layout.Size = new System.Drawing.Size(40, 40);
            this.btn_load_layout.TabIndex = 2;
            this.btn_load_layout.Text = "load Layouts";
            this.btn_load_layout.UseVisualStyleBackColor = true;
            this.btn_load_layout.Click += new System.EventHandler(this.btn_load_layout_Click);
            // 
            // lbl_ip_port
            // 
            this.lbl_ip_port.AutoSize = true;
            this.lbl_ip_port.BackColor = System.Drawing.Color.Gray;
            this.lbl_ip_port.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_ip_port.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ip_port.Location = new System.Drawing.Point(0, 30);
            this.lbl_ip_port.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lbl_ip_port.Name = "lbl_ip_port";
            this.lbl_ip_port.Size = new System.Drawing.Size(47, 16);
            this.lbl_ip_port.TabIndex = 14;
            this.lbl_ip_port.Text = "IP Port";
            // 
            // notify_icon
            // 
            this.notify_icon.ContextMenuStrip = this.context_menu_notify_icon;
            this.notify_icon.Icon = ((System.Drawing.Icon)(resources.GetObject("notify_icon.Icon")));
            this.notify_icon.Text = "PcControlBoard";
            this.notify_icon.Visible = true;
            this.notify_icon.Click += new System.EventHandler(this.notify_icon_Click);
            // 
            // context_menu_notify_icon
            // 
            this.context_menu_notify_icon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pcControlBoardToolStripMenuItem,
            this.iPPortToolStripMenuItem,
            this.connectedClientToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.context_menu_notify_icon.Name = "context";
            this.context_menu_notify_icon.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.context_menu_notify_icon.ShowImageMargin = false;
            this.context_menu_notify_icon.Size = new System.Drawing.Size(134, 92);
            // 
            // pcControlBoardToolStripMenuItem
            // 
            this.pcControlBoardToolStripMenuItem.Name = "pcControlBoardToolStripMenuItem";
            this.pcControlBoardToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.pcControlBoardToolStripMenuItem.Text = "PcControlBoard";
            this.pcControlBoardToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // iPPortToolStripMenuItem
            // 
            this.iPPortToolStripMenuItem.Name = "iPPortToolStripMenuItem";
            this.iPPortToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.iPPortToolStripMenuItem.Text = "IP, Port";
            this.iPPortToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // connectedClientToolStripMenuItem
            // 
            this.connectedClientToolStripMenuItem.Name = "connectedClientToolStripMenuItem";
            this.connectedClientToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.connectedClientToolStripMenuItem.Text = "client";
            this.connectedClientToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(32, 19);
            // 
            // lbl_client_name
            // 
            this.lbl_client_name.AutoSize = true;
            this.lbl_client_name.BackColor = System.Drawing.Color.Gray;
            this.lbl_client_name.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_client_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_client_name.Location = new System.Drawing.Point(190, 0);
            this.lbl_client_name.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_client_name.Name = "lbl_client_name";
            this.lbl_client_name.Size = new System.Drawing.Size(41, 16);
            this.lbl_client_name.TabIndex = 15;
            this.lbl_client_name.Text = "Client";
            this.lbl_client_name.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btn_action_button_list
            // 
            this.btn_action_button_list.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(102)))), ((int)(((byte)(150)))));
            this.btn_action_button_list.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btn_action_button_list.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_action_button_list.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_action_button_list.Location = new System.Drawing.Point(0, 60);
            this.btn_action_button_list.Margin = new System.Windows.Forms.Padding(0);
            this.btn_action_button_list.Name = "btn_action_button_list";
            this.btn_action_button_list.Size = new System.Drawing.Size(230, 30);
            this.btn_action_button_list.TabIndex = 0;
            this.btn_action_button_list.Text = "Action Buttons:  search...";
            this.btn_action_button_list.UseVisualStyleBackColor = false;
            // 
            // btn_layout_list
            // 
            this.btn_layout_list.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(102)))), ((int)(((byte)(150)))));
            this.btn_layout_list.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btn_layout_list.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_layout_list.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_layout_list.Location = new System.Drawing.Point(920, 60);
            this.btn_layout_list.Margin = new System.Windows.Forms.Padding(0);
            this.btn_layout_list.Name = "btn_layout_list";
            this.btn_layout_list.Size = new System.Drawing.Size(230, 30);
            this.btn_layout_list.TabIndex = 17;
            this.btn_layout_list.Text = "Layouts:  search...";
            this.btn_layout_list.UseVisualStyleBackColor = false;
            // 
            // panel_client_name
            // 
            this.panel_client_name.BackColor = System.Drawing.Color.Transparent;
            this.panel_client_name.Controls.Add(this.lbl_client_name);
            this.panel_client_name.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panel_client_name.Location = new System.Drawing.Point(920, 30);
            this.panel_client_name.Margin = new System.Windows.Forms.Padding(0);
            this.panel_client_name.Name = "panel_client_name";
            this.panel_client_name.Size = new System.Drawing.Size(231, 16);
            this.panel_client_name.TabIndex = 16;
            // 
            // FormControlBoard
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1150, 650);
            this.Controls.Add(this.btn_layout_list);
            this.Controls.Add(this.btn_action_button_list);
            this.Controls.Add(this.panel_client_name);
            this.Controls.Add(this.lbl_ip_port);
            this.Controls.Add(this.panel_layout_list_bottom);
            this.Controls.Add(this.panel_layout_list);
            this.Controls.Add(this.panel_empty_left_side);
            this.Controls.Add(this.panel_btn_config);
            this.Controls.Add(this.panel_board);
            this.Controls.Add(this.panel_drag);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1150, 650);
            this.MinimumSize = new System.Drawing.Size(1150, 650);
            this.Name = "FormControlBoard";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "PcControllBoard";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel_drag.ResumeLayout(false);
            this.panel_drag.PerformLayout();
            this.btn_panel.ResumeLayout(false);
            this.panel_exit_mini_tray.ResumeLayout(false);
            this.panel_btn_config.ResumeLayout(false);
            this.panel_btn_config.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImg1)).EndInit();
            this.panel_layout_list.ResumeLayout(false);
            this.panel_layout_list_bottom.ResumeLayout(false);
            this.context_menu_notify_icon.ResumeLayout(false);
            this.panel_client_name.ResumeLayout(false);
            this.panel_client_name.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBoard;
        private System.Windows.Forms.Button btnAccounts;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Panel panel_drag;
        private System.Windows.Forms.FlowLayoutPanel panel_exit_mini_tray;
        private System.Windows.Forms.Button btn_taskbar;
        private System.Windows.Forms.Button btn_tray;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Panel panel_board;
        private System.Windows.Forms.PictureBox pbImg1;
        private System.Windows.Forms.FlowLayoutPanel btn_panel;
        private System.Windows.Forms.TextBox tb_titel;
        private System.Windows.Forms.Label lbl_titel;
        private System.Windows.Forms.Button boardobj_options;
        private System.Windows.Forms.Panel panel_btn_config;
        private System.Windows.Forms.Button btn_config_delete;
        private System.Windows.Forms.Label lbl_window_title;
        private System.Windows.Forms.Panel panel_empty_left_side;
        private System.Windows.Forms.Panel panel_layout_list;
        private System.Windows.Forms.FlowLayoutPanel panel_layout_list_bottom;
        private System.Windows.Forms.Button btn_add_new_layout;
        private System.Windows.Forms.Button btn_save_layout;
        private System.Windows.Forms.Button btn_load_layout;
        private System.Windows.Forms.Label lbl_ip_port;
        private System.Windows.Forms.Button btn_remove_layout;
        private System.Windows.Forms.Panel panel_layout_list_top;
        private System.Windows.Forms.Label lbl_btn_action_name;
        private System.Windows.Forms.NotifyIcon notify_icon;
        private System.Windows.Forms.ContextMenuStrip context_menu_notify_icon;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem iPPortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pcControlBoardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectedClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label lbl_client_name;
        private System.Windows.Forms.Button btn_action_button_list;
        private System.Windows.Forms.Button btn_layout_list;
        private System.Windows.Forms.FlowLayoutPanel panel_client_name;
        private System.Windows.Forms.Button btn_edit_title;
        private System.Windows.Forms.Button btn_choose_icon;
        private System.Windows.Forms.Label lbl_icon;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_btn_bg_color;
    }
}

