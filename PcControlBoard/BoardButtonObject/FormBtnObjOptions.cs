using NAudio.Wave.Compression;
using System;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Diagnostics;

using System.Windows.Forms;

namespace PcControlBoard.BoardButtonObject
{
    public partial class FormBtnObjOptions : Form
    {
        public String ChooseFileName = null;

        BoardButton boardButton;
        public FormBtnObjOptions(BoardButton boardButton)
        {
            InitializeComponent();
            this.boardButton = boardButton;
            panel_btn_size.Visible = false;
            panel_file_chosser.Visible = false;
            panel_action.Visible = false;
            panel_output.Visible = false;
            panel_text.Visible = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        public void BtnSize(int sx, int sy)
        {
            tb_sizex.Text = sx.ToString();
            tb_sizey.Text = sy.ToString();
            panel_btn_size.Visible = true;
        }
        public void FileChooser(String file)
        {

            ChooseFileName = file;
            btn_file_dialog.Text = "choose File...";
            if (file != null)
                btn_file_dialog.Text = file;
            panel_file_chosser.Visible = true;
            openFileDialog1.Filter = "(*.wav) | *.wav";
        }
        public void CBoxAction(String[] items, int index)
        {
            panel_action.Visible = true;
            combo_box_action.Items.AddRange(items);
            combo_box_action.SelectedIndex = index;
        }
        public void CBoxOutput(String[] items, string selectedItem)
        {
            panel_output.Visible = true;
            combo_box_output.Items.AddRange(items);
            combo_box_output.SelectedItem = selectedItem;

        }
        public void tbText(String text)
        {
            panel_text.Visible = true;
            tb_text.Text = text;
        }

        private void tb_sizex_TextChanged(object sender, EventArgs e)
        {
            try
            {
                boardButton.Sizex = Convert.ToInt16(tb_sizex.Text);
                Debug.WriteLine(Convert.ToInt16(tb_sizex.Text));
                boardButton.Sizey = Convert.ToInt16(tb_sizey.Text);
                Debug.WriteLine(Convert.ToInt16(tb_sizey.Text));
            }
            catch (Exception) { }
        }

        private void tb_sizey_TextChanged(object sender, EventArgs e)
        {
            try
            {
                boardButton.Sizex = Convert.ToInt16(tb_sizex.Text);
                Debug.WriteLine(Convert.ToInt16(tb_sizex.Text));
                boardButton.Sizey = Convert.ToInt16(tb_sizey.Text);
                Debug.WriteLine(Convert.ToInt16(tb_sizey.Text));
            }
            catch (Exception) { }

        }

        private void btn_file_dialog_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            Debug.WriteLine(openFileDialog1.FileName);
            btn_file_dialog.Text = openFileDialog1.FileName;
            ChooseFileName = openFileDialog1.FileName;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {

            if (boardButton.ChangeProperties())
                this.Visible = false;
            /*
                        if (btn_file_dialog.Visible)
                        {
                            if (ChooseFileName != null)
                            {
                                boardButton.ChangeProperties();
                                this.Visible = false;
                            }
                            else
                            {
                                MessageBox.Show("no selected file!", "Error");
                            }
                        }
                        else
                        {
                            boardButton.ChangeProperties();
                            this.Visible = false;
                        }
            */

            // statt einzelne Abfrage eine am Ende mit alle aktiven Komponenten ////////////////
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void FormBoardObjectOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true;
        }
    }
}
