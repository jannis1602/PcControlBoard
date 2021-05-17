using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;

namespace PcControlBoard.BoardButtonObject
{
    [Serializable]
    public class BoardButtonSounds : BoardButton
    {
        // Fehlt: Multi Device output!!!

        LinkedList<String> actionObjectList = new LinkedList<String>();
        [NonSerialized] private FormBtnObjOptions form;

        private String audioFile = null;                                 // audiofile in Programm Ordner speichern?
        private String soundWaveOut = "DefaultSoundOutputDevice";
        private IWavePlayer outDevice = null;

        public void SetAudioFile(String file) { audioFile = file; }

        public BoardButtonSounds()
        {
            Actions = new String[] { "Sounds", "PlaySound", "StopPlaying" };
        }

        public BoardButtonSounds(int gridx, int gridy, int sizex, int sizey, String text, String objEvent)
        {
            Actions = new String[] { "Sounds", "PlaySound", "StopPlaying" };
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
                case "PlaySound":
                    Debug.WriteLine("<EVENT>PlaySound...");
                    PlaySingleSound.PlayAudio(audioFile, soundWaveOut, outDevice);
                    //PlayAudioThread();
                    // PlaySound();
                    break;
                case "StopPlaying":
                    Debug.WriteLine("<EVENT>mute/unmuteSystemSound...");
                    PlaySingleSound.StopPlaying();
                    break;

            }
        }

        //   private void PlaySound()
        //   {
        //  Debug.WriteLine(WaveOut.DeviceCount);
        //for (int i = 0; i < NAudio.Wave.WaveOut.DeviceCount; i++)
        //{
        //    Debug.WriteLine(NAudio.Wave.WaveOut.GetCapabilities(i).ProductName); ;
        //}

        //  DirectSoundOut waveOut = null;
        //  waveOut = new DirectSoundOut();

        //WaveFileReader inputFile = new WaveFileReader("C:\\Users\\mattl\\Desktop\\Wav-Sounds\\NobodyCares.wav");
        //IWavePlayer outDevice = new WaveOut();
        //outDevice.Init(inputFile);
        //outDevice.Play();

        //ParameterizedThreadStart audioThread = new ParameterizedThreadStart(this.PlayAudioThread);
        //Thread thread = new Thread(audioThread);
        //thread.Start(0);

        //  ParameterizedThreadStart audioThread2 = new ParameterizedThreadStart(this.PlayAudioThread);
        //  Thread thread2 = new Thread(audioThread2);
        //  thread2.Start(soundWaveOut);

        // PlayAudioThread();

        //}


        /*  public void PlayAudioThread()       // wird nicht als Thread benutzt!
          {
              if (audioFile != null && isPlaying == false)
              {
                  WaveFileReader inputFile = new WaveFileReader(audioFile);
                  WaveOut waveOut = new WaveOut();
                  waveOut.DeviceNumber = 0;
                  for (int i = 0; i < WaveOut.DeviceCount; i++)
                  {
                      if (Properties.Settings.Default.SoundOutDevice == "DefaultSoundOutputDevice")
                      {
                          if (WaveOut.GetCapabilities(i).ProductName == Properties.Settings.Default.SoundOutDevice)
                          {
                              waveOut.DeviceNumber = i;
                          }
                      }
                      else
                      {
                          if (WaveOut.GetCapabilities(i).ProductName == soundWaveOut)
                              waveOut.DeviceNumber = i;
                      }
                  }
                  //waveOut.DeviceNumber = (int)outputDevice;
                  if (outDevice == null)
                      outDevice = waveOut;
                  outDevice.Init(inputFile);
                  outDevice.Play();
                  isPlaying = true;

                  outDevice.PlaybackStopped += SetIsPlayingFalse;
              }
              else if (isPlaying) outDevice.Stop();
          }*/

        private static class PlaySingleSound
        {
            private static Boolean isPlaying = false;
            private static IWavePlayer outDevice;
            private static String audioFile;
            public static void PlayAudio(String pAudioFile, String soundWaveOutName, IWavePlayer pOutDevice)
            {
                if (pAudioFile != null)
                {
                    if (isPlaying && (audioFile == pAudioFile)) { outDevice.Stop(); return; }
                    if (isPlaying) outDevice.Stop();
                    outDevice = pOutDevice;
                    audioFile = pAudioFile;
                    WaveFileReader inputFile = new WaveFileReader(audioFile);
                    WaveOut waveOut = new WaveOut();
                    waveOut.DeviceNumber = 0;
                    for (int i = 0; i < WaveOut.DeviceCount; i++)
                    {
                        if (Properties.Settings.Default.SoundOutDevice == "DefaultSoundOutputDevice")
                        {
                            if (WaveOut.GetCapabilities(i).ProductName == Properties.Settings.Default.SoundOutDevice)
                            {
                                waveOut.DeviceNumber = i;
                            }
                        }
                        else
                        {
                            if (WaveOut.GetCapabilities(i).ProductName == soundWaveOutName)
                                waveOut.DeviceNumber = i;
                        }
                    }
                    if (outDevice == null)
                        outDevice = waveOut;
                    outDevice.Init(inputFile);
                    outDevice.Play();
                    isPlaying = true;

                    outDevice.PlaybackStopped += SetIsPlayingFalse;
                }
            }
            private static void SetIsPlayingFalse(object sender, StoppedEventArgs e) { isPlaying = false; }
            public static void StopPlaying() { if (outDevice != null) outDevice.Stop(); }
        }


        // fehlt: play multi sound



        // public void StopPlaying() { if (outDevice != null) outDevice.Stop(); }
        // private void SetIsPlayingFalse(object sender, StoppedEventArgs e) { isPlaying = false; }

        public override void ShowOptions()
        {
            if (form == null)
            {
                form = new FormBtnObjOptions(this);
                switch (BtnEvent)       // besser:  .ToLower()
                {
                    case "PlaySound":
                        form.BtnSize(Sizex, Sizey);
                        form.FileChooser(audioFile);
                        String[] items = new String[WaveOut.DeviceCount + 1];
                        items[0] = "DefaultSoundOutputDevice";
                        for (int i = 1; i < WaveOut.DeviceCount + 1; i++)
                            items[i] = WaveOut.GetCapabilities(i - 1).ProductName;
                        form.CBoxOutput(items, soundWaveOut);
                        break;
                    case "StopPlaying":     // Methoden fehlen!
                        form.BtnSize(Sizex, Sizey);
                        break;
                }
                form.Refresh();
            }
            form.Show();
        }

        public override BoardObject Clone()
        {
            BoardButtonSounds tempBoardObject = new BoardButtonSounds(Gridx, Gridy, Sizex, Sizey, Text, BtnEvent);
            tempBoardObject.SetAudioFile(audioFile);
            tempBoardObject.soundWaveOut = soundWaveOut;
            tempBoardObject.backgroundBmp = backgroundBmp;
            return tempBoardObject;
        }

        public override Boolean ChangeProperties()
        {
            if (!((Sizex = Convert.ToInt16(form.tb_sizex.Text)) >= 1)) { MessageBox.Show("Error: x<1", "Error"); return false; }
            if (!((Sizey = Convert.ToInt16(form.tb_sizey.Text)) >= 1)) { MessageBox.Show("Error: y<1", "Error"); return false; }
            audioFile = form.ChooseFileName;
            soundWaveOut = form.combo_box_output.Text;
            return true;
        }
    }



    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    [Serializable]
    public class BoardButtonSystem : BoardButton
    {
        [NonSerialized] private FormBtnObjOptions form;

        String simKeyCode;
        VirtualKeyCode virtualKeyCode;

        public BoardButtonSystem()
        {
            Actions = new String[] { "System", "MuteSound", "SoundUp", "SoundDown", "SimulateKey", "MediaKeys", "SimulateKeysAsText" };//  "SimulateKeysAsText"
        }

        public BoardButtonSystem(int gridx, int gridy, int sizex, int sizey, String text, String objEvent)
        {
            Actions = new String[] { "System", "MuteSound", "SoundUp", "SoundDown", "SimulateKey", "MediaKeys", "SimulateKeysAsText" };
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
                case "MuteSound":
                    Debug.WriteLine("<EVENT>MuteSound");
                    simKeyCode = "VOLUME_MUTE";
                    virtualKeyCode = (VirtualKeyCode)Enum.Parse(typeof(VirtualKeyCode), simKeyCode);
                    simMediaKey();
                    break;
                case "SoundUp":
                    Debug.WriteLine("<EVENT>SoundUp");
                    simKeyCode = "VOLUME_UP";
                    virtualKeyCode = (VirtualKeyCode)Enum.Parse(typeof(VirtualKeyCode), simKeyCode);
                    simMediaKey();
                    break;
                case "SoundDown":
                    Debug.WriteLine("<EVENT>SoundDown");
                    simKeyCode = "VOLUME_DOWN";
                    virtualKeyCode = (VirtualKeyCode)Enum.Parse(typeof(VirtualKeyCode), simKeyCode);
                    simMediaKey();
                    break;
                case "SimulateKey":
                    Debug.WriteLine("<EVENT>SimulateKey... " + simKeyCode);
                    simKey();
                    break;
                case "MediaKeys":
                    Debug.WriteLine("<EVENT>MediaKeys... " + simKeyCode);
                    simMediaKey();
                    break;
                case "SimulateKeysAsText":
                    Debug.WriteLine("<EVENT>SimulateKeysAsText... " + simKeyCode);
                  //  InputSimulator inputSimulator = new InputSimulator();
                 //   inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_T);
                  //  Thread.Sleep(10);
                    foreach(char c in simKeyCode)
                        SendKeys.SendWait(c.ToString());
                  //  Thread.Sleep(10);
                    // SendKeys.SendWait("{ENTER}");       // boolean...
                  //  inputSimulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);

                    break;

            }
        }

        private void simKey()
        {
            InputSimulator sim = new InputSimulator();
            SendKeys.SendWait(simKeyCode);

            //sim.Keyboard.KeyPress(VirtualKeyCode.MEDIA_STOP);
            //sim.Keyboard.KeyPress(VirtualKeyCode.MEDIA_NEXT_TRACK);
            //sim.Keyboard.KeyPress(VirtualKeyCode.MEDIA_PREV_TRACK);
            // sim.Keyboard.KeyPress(VirtualKeyCode.MEDIA_PLAY_PAUSE);
            // sim.Keyboard.KeyPress(VirtualKeyCode.VK_B);
            // Press enter
            // sim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
        }
        private void simMediaKey()
        {
            InputSimulator sim = new InputSimulator();
            sim.Keyboard.KeyPress(virtualKeyCode);
        }


        public override void ShowOptions()
        {
            if (form == null)
            {
                form = new FormBtnObjOptions(this);
                switch (BtnEvent)
                {
                    case "MuteSound":
                        form.BtnSize(Sizex, Sizey);
                        break;
                    case "SoundUp":
                        form.BtnSize(Sizex, Sizey);
                        break;
                    case "SoundDown":
                        form.BtnSize(Sizex, Sizey);
                        break;
                    case "SimulateKey":     // record keyPress...
                        form.BtnSize(Sizex, Sizey);
                        char[] alphabet = "abcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();
                        String[] itemsKeys = new String[alphabet.Length];
                        for (int i = 0; i < alphabet.Length; i++)
                            itemsKeys[i] = alphabet[i].ToString();
                        form.CBoxAction(itemsKeys, 0);
                        break;
                    case "MediaKeys":
                        form.BtnSize(Sizex, Sizey);
                        String[] itemsMedia = new String[] { "MEDIA_PLAY_PAUSE", "MEDIA_PREV_TRACK", "MEDIA_NEXT_TRACK", "MEDIA_STOP" };
                        form.CBoxAction(itemsMedia, 0);
                        break;
                    case "SimulateKeysAsText":
                        form.tbText(simKeyCode);
                        break;
                }
                form.Refresh();
            }
            form.Show();
        }

        public override BoardObject Clone()
        {
            BoardButtonSystem tempBoardObject = new BoardButtonSystem(Gridx, Gridy, Sizex, Sizey, Text, BtnEvent);
            tempBoardObject.simKeyCode = simKeyCode;
            tempBoardObject.virtualKeyCode = virtualKeyCode;
            tempBoardObject.backgroundBmp = backgroundBmp;
            return tempBoardObject;
        }

        public override Boolean ChangeProperties()
        {
            if (!((Sizex = Convert.ToInt16(form.tb_sizex.Text)) >= 1)) { MessageBox.Show("Error: x<1", "Error"); return false; }
            if (!((Sizey = Convert.ToInt16(form.tb_sizey.Text)) >= 1)) { MessageBox.Show("Error: y<1", "Error"); return false; }
            if (BtnEvent == "SimulateKey" || BtnEvent == "MediaKeys")
            {
                simKeyCode = form.combo_box_action.SelectedItem.ToString();
                try
                {
                    virtualKeyCode = (VirtualKeyCode)Enum.Parse(typeof(VirtualKeyCode), form.combo_box_action.SelectedItem.ToString());
                }
                catch (Exception) { }
            }
            if (BtnEvent == "SimulateKeysAsText") { simKeyCode = form.tb_text.Text; }
            return true;
        }
    }

}
