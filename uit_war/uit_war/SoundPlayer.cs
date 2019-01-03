using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
namespace uit_war
{
    class SoundPlayer
    {
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string lpstrCommand, StringBuilder lpstrReturnString, int uReturnLength, int hwdCallBack);

        public static void Open(string File)
        {
            string Format = @"open ""{0}"" type MPEGVideo alias MediaFile";
            string command = string.Format(Format, File);
            mciSendString(command, null, 0, 0);
        }

        public static void Play()
        {
            string command = "play MediaFile";
            mciSendString(command, null, 0, 0);
        }
        public void Stop()
        {
            string command = "stop MediaFile";
            mciSendString(command, null, 0, 0);
        }
        public static void PlayLooping()
        {
            string command = "play MediaFile repeat";
            mciSendString(command, null, 0, 0);
        }
        public static void ChangePlay(string File)
        {
            string command = "close MediaFile";
            string Format = @"open ""{0}"" type MPEGVideo alias MediaFile";
            mciSendString(command, null, 0, 0);
            command = string.Format(Format, File);
            mciSendString(command, null, 0, 0);
        }
    }
}
