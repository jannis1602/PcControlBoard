using NAudio.Wave;
using QRCoder;
using System;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace PcControlBoard
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
            mtb_port.Text = Properties.Settings.Default.Port.ToString();
            String[] items = new String[WaveOut.DeviceCount];
            int selectedItemIndex = 0;
            for (int i = 0; i < WaveOut.DeviceCount; i++)
            {
                items[i] = WaveOut.GetCapabilities(i).ProductName;
                if (WaveOut.GetCapabilities(i).ProductName == Properties.Settings.Default.SoundOutDevice)
                    selectedItemIndex = i;
            }
            cbox_sound_out_device.Items.AddRange(items);
            cbox_sound_out_device.SelectedIndex = selectedItemIndex;
            cbox_sound_out_device.SelectedItem = Properties.Settings.Default.SoundOutDevice;

            foreach (String s in FormControlBoard.GetAllLocalIPv4(NetworkInterfaceType.Ethernet))
                cbox_ip_port.Items.Add(s + " - " + Properties.Settings.Default.Port);
            foreach (String s in FormControlBoard.GetAllLocalIPv4(NetworkInterfaceType.Wireless80211))
                cbox_ip_port.Items.Add(s);
            cbox_ip_port.SelectedIndex = 0;
        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Properties.Settings.Default.Port = int.Parse(mtb_port.Text);
                Properties.Settings.Default.SoundOutDevice = (String)cbox_sound_out_device.SelectedItem;
                Properties.Settings.Default.Save();
                Debug.WriteLine(mtb_port.Text);
            }
            catch (Exception) { e.Cancel = true; }
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            // Test
            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode(cbox_ip_port.Text, QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);
            picture_box_qr.BackgroundImage = code.GetGraphic(10);

        }

        private void picture_box_qr_Click(object sender, EventArgs e)
        {
            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode(cbox_ip_port.Text, QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);
            picture_box_qr.BackgroundImage = code.GetGraphic(10);
        }
    }
}
