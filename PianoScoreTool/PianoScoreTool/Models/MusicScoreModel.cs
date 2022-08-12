using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PianoScoreTool.Models
{
    internal class MusicScoreModel : ObservableObject
    {
        private string folderPath;
        internal string FolderPath
        {
            get => folderPath;
            set => SetProperty(ref folderPath, value);
        }
        private string log;
        internal string Log
        {
            get => log;
            set => SetProperty(ref log, value);
        }
        private bool isGetAudio;
        internal bool IsGetAudio
        {
            get => isGetAudio;
            set => SetProperty(ref isGetAudio, value);
        }
    }
}
