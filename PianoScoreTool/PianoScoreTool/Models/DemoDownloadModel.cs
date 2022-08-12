using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PianoScoreTool.Models
{
    internal class DemoDownloadModel : ObservableObject
    {
        private string folderPath;
        internal string FolderPath
        {
            get => folderPath;
            set => SetProperty(ref folderPath, value);
        }
        private string musicScoreID;
        internal string MusicScoreID
        {
            get => musicScoreID;
            set => SetProperty(ref musicScoreID, value);
        }
        private string log;
        internal string Log
        {
            get => log;
            set => SetProperty(ref log, value);
        }
    }
}
