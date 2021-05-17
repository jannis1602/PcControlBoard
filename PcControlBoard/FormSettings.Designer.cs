namespace PcControlBoard
{
    partial class FormSettings
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_general = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_export_layout = new System.Windows.Forms.Button();
            this.btn_load_layout = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_sound_out = new System.Windows.Forms.Label();
            this.cbox_sound_out_device = new System.Windows.Forms.ComboBox();
            this.tab_network = new System.Windows.Forms.TabPage();
            this.lbl_qrcode = new System.Windows.Forms.Label();
            this.picture_box_qr = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_port = new System.Windows.Forms.Label();
            this.mtb_port = new System.Windows.Forms.MaskedTextBox();
            this.lbl_port_info = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_ips = new System.Windows.Forms.Label();
            this.cbox_ip_port = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tab_general.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tab_network.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_box_qr)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_general);
            this.tabControl1.Controls.Add(this.tab_network);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(754, 394);
            this.tabControl1.TabIndex = 4;
            // 
            // tab_general
            // 
            this.tab_general.Controls.Add(this.flowLayoutPanel4);
            this.tab_general.Controls.Add(this.flowLayoutPanel2);
            this.tab_general.Location = new System.Drawing.Point(4, 22);
            this.tab_general.Margin = new System.Windows.Forms.Padding(0);
            this.tab_general.Name = "tab_general";
            this.tab_general.Padding = new System.Windows.Forms.Padding(3);
            this.tab_general.Size = new System.Drawing.Size(746, 368);
            this.tab_general.TabIndex = 0;
            this.tab_general.Text = "General";
            this.tab_general.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.btn_export_layout);
            this.flowLayoutPanel4.Controls.Add(this.btn_load_layout);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(6, 40);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(327, 29);
            this.flowLayoutPanel4.TabIndex = 1;
            // 
            // btn_export_layout
            // 
            this.btn_export_layout.BackColor = System.Drawing.Color.Gray;
            this.btn_export_layout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_export_layout.Location = new System.Drawing.Point(3, 3);
            this.btn_export_layout.Name = "btn_export_layout";
            this.btn_export_layout.Size = new System.Drawing.Size(86, 23);
            this.btn_export_layout.TabIndex = 0;
            this.btn_export_layout.Text = "Exoprt Layout";
            this.btn_export_layout.UseVisualStyleBackColor = false;
            // 
            // btn_load_layout
            // 
            this.btn_load_layout.BackColor = System.Drawing.Color.Gray;
            this.btn_load_layout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_load_layout.Location = new System.Drawing.Point(95, 3);
            this.btn_load_layout.Name = "btn_load_layout";
            this.btn_load_layout.Size = new System.Drawing.Size(86, 23);
            this.btn_load_layout.TabIndex = 1;
            this.btn_load_layout.Text = "Load Layout";
            this.btn_load_layout.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.lbl_sound_out);
            this.flowLayoutPanel2.Controls.Add(this.cbox_sound_out_device);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(6, 6);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(327, 27);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // lbl_sound_out
            // 
            this.lbl_sound_out.AutoSize = true;
            this.lbl_sound_out.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sound_out.Location = new System.Drawing.Point(3, 6);
            this.lbl_sound_out.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lbl_sound_out.Name = "lbl_sound_out";
            this.lbl_sound_out.Size = new System.Drawing.Size(152, 16);
            this.lbl_sound_out.TabIndex = 1;
            this.lbl_sound_out.Text = "DefaultSoundOutDevice";
            // 
            // cbox_sound_out_device
            // 
            this.cbox_sound_out_device.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_sound_out_device.FormattingEnabled = true;
            this.cbox_sound_out_device.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.cbox_sound_out_device.Location = new System.Drawing.Point(161, 3);
            this.cbox_sound_out_device.Name = "cbox_sound_out_device";
            this.cbox_sound_out_device.Size = new System.Drawing.Size(160, 21);
            this.cbox_sound_out_device.TabIndex = 0;
            // 
            // tab_network
            // 
            this.tab_network.Controls.Add(this.lbl_qrcode);
            this.tab_network.Controls.Add(this.picture_box_qr);
            this.tab_network.Controls.Add(this.flowLayoutPanel1);
            this.tab_network.Controls.Add(this.flowLayoutPanel3);
            this.tab_network.Location = new System.Drawing.Point(4, 22);
            this.tab_network.Name = "tab_network";
            this.tab_network.Padding = new System.Windows.Forms.Padding(3);
            this.tab_network.Size = new System.Drawing.Size(746, 368);
            this.tab_network.TabIndex = 1;
            this.tab_network.Text = "Network";
            this.tab_network.UseVisualStyleBackColor = true;
            // 
            // lbl_qrcode
            // 
            this.lbl_qrcode.AutoSize = true;
            this.lbl_qrcode.Location = new System.Drawing.Point(199, 109);
            this.lbl_qrcode.Name = "lbl_qrcode";
            this.lbl_qrcode.Size = new System.Drawing.Size(122, 13);
            this.lbl_qrcode.TabIndex = 6;
            this.lbl_qrcode.Text = "(QRCode noch in Arbeit)";
            // 
            // picture_box_qr
            // 
            this.picture_box_qr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_box_qr.Location = new System.Drawing.Point(202, 6);
            this.picture_box_qr.Name = "picture_box_qr";
            this.picture_box_qr.Size = new System.Drawing.Size(100, 100);
            this.picture_box_qr.TabIndex = 5;
            this.picture_box_qr.TabStop = false;
            this.picture_box_qr.Click += new System.EventHandler(this.picture_box_qr_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lbl_port);
            this.flowLayoutPanel1.Controls.Add(this.mtb_port);
            this.flowLayoutPanel1.Controls.Add(this.lbl_port_info);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(190, 26);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // lbl_port
            // 
            this.lbl_port.AutoSize = true;
            this.lbl_port.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_port.Location = new System.Drawing.Point(3, 3);
            this.lbl_port.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_port.Name = "lbl_port";
            this.lbl_port.Size = new System.Drawing.Size(42, 20);
            this.lbl_port.TabIndex = 2;
            this.lbl_port.Text = "Port:";
            // 
            // mtb_port
            // 
            this.mtb_port.HidePromptOnLeave = true;
            this.mtb_port.ImeMode = System.Windows.Forms.ImeMode.On;
            this.mtb_port.Location = new System.Drawing.Point(51, 3);
            this.mtb_port.Mask = "00000";
            this.mtb_port.Name = "mtb_port";
            this.mtb_port.RejectInputOnFirstFailure = true;
            this.mtb_port.Size = new System.Drawing.Size(42, 20);
            this.mtb_port.TabIndex = 1;
            // 
            // lbl_port_info
            // 
            this.lbl_port_info.AutoSize = true;
            this.lbl_port_info.Location = new System.Drawing.Point(99, 6);
            this.lbl_port_info.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lbl_port_info.Name = "lbl_port_info";
            this.lbl_port_info.Size = new System.Drawing.Size(84, 13);
            this.lbl_port_info.TabIndex = 3;
            this.lbl_port_info.Text = "(Program restart)";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.lbl_ips);
            this.flowLayoutPanel3.Controls.Add(this.cbox_ip_port);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(6, 38);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(190, 26);
            this.flowLayoutPanel3.TabIndex = 5;
            // 
            // lbl_ips
            // 
            this.lbl_ips.AutoSize = true;
            this.lbl_ips.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ips.Location = new System.Drawing.Point(3, 3);
            this.lbl_ips.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_ips.Name = "lbl_ips";
            this.lbl_ips.Size = new System.Drawing.Size(28, 20);
            this.lbl_ips.TabIndex = 2;
            this.lbl_ips.Text = "IP:";
            // 
            // cbox_ip_port
            // 
            this.cbox_ip_port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_ip_port.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbox_ip_port.FormattingEnabled = true;
            this.cbox_ip_port.ItemHeight = 15;
            this.cbox_ip_port.Location = new System.Drawing.Point(34, 1);
            this.cbox_ip_port.Margin = new System.Windows.Forms.Padding(0, 1, 1, 0);
            this.cbox_ip_port.Name = "cbox_ip_port";
            this.cbox_ip_port.Size = new System.Drawing.Size(155, 23);
            this.cbox_ip_port.TabIndex = 6;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 394);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormSettings";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettings_FormClosing);
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.tabControl1.ResumeLayout(false);
            this.tab_general.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.tab_network.ResumeLayout(false);
            this.tab_network.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_box_qr)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_general;
        private System.Windows.Forms.TabPage tab_network;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lbl_port;
        private System.Windows.Forms.MaskedTextBox mtb_port;
        private System.Windows.Forms.Label lbl_port_info;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.ComboBox cbox_sound_out_device;
        private System.Windows.Forms.Label lbl_sound_out;
        private System.Windows.Forms.PictureBox picture_box_qr;
        private System.Windows.Forms.ComboBox cbox_ip_port;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label lbl_ips;
        private System.Windows.Forms.Label lbl_qrcode;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Button btn_export_layout;
        private System.Windows.Forms.Button btn_load_layout;
    }
}