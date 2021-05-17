namespace PcControlBoard.BoardButtonObject
{
    partial class FormBtnObjOptions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_all = new System.Windows.Forms.Panel();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.flayout_options = new System.Windows.Forms.FlowLayoutPanel();
            this.panel_btn_size = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_sizex = new System.Windows.Forms.Label();
            this.tb_sizex = new System.Windows.Forms.TextBox();
            this.lbl_sizey = new System.Windows.Forms.Label();
            this.tb_sizey = new System.Windows.Forms.TextBox();
            this.panel_file_chosser = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_pfad = new System.Windows.Forms.Label();
            this.btn_file_dialog = new System.Windows.Forms.Button();
            this.panel_action = new System.Windows.Forms.FlowLayoutPanel();
            this.combo_box_action = new System.Windows.Forms.ComboBox();
            this.panel_output = new System.Windows.Forms.FlowLayoutPanel();
            this.combo_box_output = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel_text = new System.Windows.Forms.FlowLayoutPanel();
            this.tb_text = new System.Windows.Forms.TextBox();
            this.panel_all.SuspendLayout();
            this.flayout_options.SuspendLayout();
            this.panel_btn_size.SuspendLayout();
            this.panel_file_chosser.SuspendLayout();
            this.panel_action.SuspendLayout();
            this.panel_output.SuspendLayout();
            this.panel_text.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_all
            // 
            this.panel_all.Controls.Add(this.btn_cancel);
            this.panel_all.Controls.Add(this.btn_ok);
            this.panel_all.Controls.Add(this.flayout_options);
            this.panel_all.Location = new System.Drawing.Point(12, 12);
            this.panel_all.Name = "panel_all";
            this.panel_all.Size = new System.Drawing.Size(388, 402);
            this.panel_all.TabIndex = 0;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(268, 362);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(120, 40);
            this.btn_cancel.TabIndex = 6;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(0, 362);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(120, 40);
            this.btn_ok.TabIndex = 5;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // flayout_options
            // 
            this.flayout_options.Controls.Add(this.panel_btn_size);
            this.flayout_options.Controls.Add(this.panel_file_chosser);
            this.flayout_options.Controls.Add(this.panel_action);
            this.flayout_options.Controls.Add(this.panel_output);
            this.flayout_options.Controls.Add(this.panel_text);
            this.flayout_options.Location = new System.Drawing.Point(3, 0);
            this.flayout_options.Name = "flayout_options";
            this.flayout_options.Size = new System.Drawing.Size(248, 274);
            this.flayout_options.TabIndex = 4;
            // 
            // panel_btn_size
            // 
            this.panel_btn_size.Controls.Add(this.lbl_sizex);
            this.panel_btn_size.Controls.Add(this.tb_sizex);
            this.panel_btn_size.Controls.Add(this.lbl_sizey);
            this.panel_btn_size.Controls.Add(this.tb_sizey);
            this.panel_btn_size.Location = new System.Drawing.Point(3, 3);
            this.panel_btn_size.Name = "panel_btn_size";
            this.panel_btn_size.Size = new System.Drawing.Size(245, 24);
            this.panel_btn_size.TabIndex = 0;
            // 
            // lbl_sizex
            // 
            this.lbl_sizex.AutoSize = true;
            this.lbl_sizex.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sizex.Location = new System.Drawing.Point(3, 3);
            this.lbl_sizex.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.lbl_sizex.Name = "lbl_sizex";
            this.lbl_sizex.Size = new System.Drawing.Size(46, 16);
            this.lbl_sizex.TabIndex = 0;
            this.lbl_sizex.Text = "Size x:";
            // 
            // tb_sizex
            // 
            this.tb_sizex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_sizex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_sizex.Location = new System.Drawing.Point(52, 1);
            this.tb_sizex.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.tb_sizex.Name = "tb_sizex";
            this.tb_sizex.Size = new System.Drawing.Size(20, 20);
            this.tb_sizex.TabIndex = 1;
            this.tb_sizex.Text = "1";
            this.tb_sizex.TextChanged += new System.EventHandler(this.tb_sizex_TextChanged);
            // 
            // lbl_sizey
            // 
            this.lbl_sizey.AutoSize = true;
            this.lbl_sizey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sizey.Location = new System.Drawing.Point(78, 3);
            this.lbl_sizey.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.lbl_sizey.Name = "lbl_sizey";
            this.lbl_sizey.Size = new System.Drawing.Size(47, 16);
            this.lbl_sizey.TabIndex = 2;
            this.lbl_sizey.Text = "Size y:";
            // 
            // tb_sizey
            // 
            this.tb_sizey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_sizey.Location = new System.Drawing.Point(128, 1);
            this.tb_sizey.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.tb_sizey.Name = "tb_sizey";
            this.tb_sizey.Size = new System.Drawing.Size(20, 20);
            this.tb_sizey.TabIndex = 3;
            this.tb_sizey.Text = "1";
            this.tb_sizey.TextChanged += new System.EventHandler(this.tb_sizey_TextChanged);
            // 
            // panel_file_chosser
            // 
            this.panel_file_chosser.Controls.Add(this.lbl_pfad);
            this.panel_file_chosser.Controls.Add(this.btn_file_dialog);
            this.panel_file_chosser.Location = new System.Drawing.Point(3, 33);
            this.panel_file_chosser.Name = "panel_file_chosser";
            this.panel_file_chosser.Size = new System.Drawing.Size(245, 24);
            this.panel_file_chosser.TabIndex = 1;
            // 
            // lbl_pfad
            // 
            this.lbl_pfad.AutoSize = true;
            this.lbl_pfad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pfad.Location = new System.Drawing.Point(3, 3);
            this.lbl_pfad.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lbl_pfad.Name = "lbl_pfad";
            this.lbl_pfad.Size = new System.Drawing.Size(39, 16);
            this.lbl_pfad.TabIndex = 0;
            this.lbl_pfad.Text = "Pfad:";
            // 
            // btn_file_dialog
            // 
            this.btn_file_dialog.Location = new System.Drawing.Point(46, 1);
            this.btn_file_dialog.Margin = new System.Windows.Forms.Padding(1);
            this.btn_file_dialog.Name = "btn_file_dialog";
            this.btn_file_dialog.Size = new System.Drawing.Size(160, 21);
            this.btn_file_dialog.TabIndex = 1;
            this.btn_file_dialog.Text = "choose File";
            this.btn_file_dialog.UseVisualStyleBackColor = true;
            this.btn_file_dialog.Click += new System.EventHandler(this.btn_file_dialog_Click);
            // 
            // panel_action
            // 
            this.panel_action.Controls.Add(this.combo_box_action);
            this.panel_action.Location = new System.Drawing.Point(3, 63);
            this.panel_action.Name = "panel_action";
            this.panel_action.Size = new System.Drawing.Size(245, 27);
            this.panel_action.TabIndex = 4;
            // 
            // combo_box_action
            // 
            this.combo_box_action.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_box_action.FormattingEnabled = true;
            this.combo_box_action.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.combo_box_action.Location = new System.Drawing.Point(3, 3);
            this.combo_box_action.Name = "combo_box_action";
            this.combo_box_action.Size = new System.Drawing.Size(203, 21);
            this.combo_box_action.TabIndex = 2;
            // 
            // panel_output
            // 
            this.panel_output.Controls.Add(this.combo_box_output);
            this.panel_output.Location = new System.Drawing.Point(3, 96);
            this.panel_output.Name = "panel_output";
            this.panel_output.Size = new System.Drawing.Size(245, 27);
            this.panel_output.TabIndex = 5;
            // 
            // combo_box_output
            // 
            this.combo_box_output.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_box_output.FormattingEnabled = true;
            this.combo_box_output.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.combo_box_output.Location = new System.Drawing.Point(3, 3);
            this.combo_box_output.Name = "combo_box_output";
            this.combo_box_output.Size = new System.Drawing.Size(203, 21);
            this.combo_box_output.TabIndex = 3;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "File";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // panel_text
            // 
            this.panel_text.Controls.Add(this.tb_text);
            this.panel_text.Location = new System.Drawing.Point(3, 129);
            this.panel_text.Name = "panel_text";
            this.panel_text.Size = new System.Drawing.Size(245, 27);
            this.panel_text.TabIndex = 6;
            // 
            // tb_text
            // 
            this.tb_text.Location = new System.Drawing.Point(3, 3);
            this.tb_text.Name = "tb_text";
            this.tb_text.Size = new System.Drawing.Size(203, 20);
            this.tb_text.TabIndex = 0;
            // 
            // FormBtnObjOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 426);
            this.Controls.Add(this.panel_all);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormBtnObjOptions";
            this.Text = "Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBoardObjectOptions_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel_all.ResumeLayout(false);
            this.flayout_options.ResumeLayout(false);
            this.panel_btn_size.ResumeLayout(false);
            this.panel_btn_size.PerformLayout();
            this.panel_file_chosser.ResumeLayout(false);
            this.panel_file_chosser.PerformLayout();
            this.panel_action.ResumeLayout(false);
            this.panel_output.ResumeLayout(false);
            this.panel_text.ResumeLayout(false);
            this.panel_text.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_all;
        public System.Windows.Forms.TextBox tb_sizex;
        private System.Windows.Forms.Label lbl_sizex;
        private System.Windows.Forms.FlowLayoutPanel flayout_options;
        private System.Windows.Forms.FlowLayoutPanel panel_btn_size;
        private System.Windows.Forms.Label lbl_sizey;
        public System.Windows.Forms.TextBox tb_sizey;
        private System.Windows.Forms.FlowLayoutPanel panel_file_chosser;
        private System.Windows.Forms.Label lbl_pfad;
        private System.Windows.Forms.Button btn_file_dialog;
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.ComboBox combo_box_action;
        private System.Windows.Forms.FlowLayoutPanel panel_action;
        private System.Windows.Forms.FlowLayoutPanel panel_output;
        public System.Windows.Forms.ComboBox combo_box_output;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.FlowLayoutPanel panel_text;
        public System.Windows.Forms.TextBox tb_text;
    }
}