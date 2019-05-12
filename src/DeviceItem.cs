using NAudio.Lame;
using NAudio.Wave;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace VoiceRecorder
{
    public class DeviceItem
    {
        public ProgressBar Progress { get; set; }
        public CheckBox Name { get; set; }
        public WaveInCapabilities Device { get; set; }
        public IWaveIn WaveIn { get; set; }
        public Stream StreamWriter { get; set; }

        public Stream CreateStreamWriter()
        {
            var nameFixed = Regex.Replace(Name.Text, "[^a-zA-Z0-9]", "");
            var filename = $@"{DateTime.Now:yyyyMMdd}_{DateTime.Now:HHmmss}_{nameFixed}.mp3";
            var format = new WaveFormat(44100, 1);
            this.StreamWriter = new LameMP3FileWriter(filename, WaveIn.WaveFormat, LAMEPreset.ABR_96);
            return this.StreamWriter;
        }
    }
}
