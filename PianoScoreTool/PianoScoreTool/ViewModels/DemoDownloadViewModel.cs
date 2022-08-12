using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json.Linq;
using PianoScoreTool.Models;
using PianoScoreTool.Utility;
using System;
using System.IO;
using System.Net;
using System.Web;
using System.Windows.Input;

namespace PianoScoreTool.ViewModels
{
    internal class DemoDownloadViewModel : ObservableObject
    {
        internal ICommand AudioDownloadCommand;
        private DemoDownloadModel demoDownloadM;
        internal DemoDownloadModel DemoDownloadM
        {
            get { return demoDownloadM; }
            set { SetProperty(ref demoDownloadM, value); }
        }
        internal DemoDownloadViewModel()
        {
            if (DemoDownloadM == null)
            {
                DemoDownloadM = new DemoDownloadModel();
                AudioDownloadCommand = new RelayCommand(AudioDownload);
            }
        }
        private void AudioDownload()
        {
            if (!string.IsNullOrEmpty(DemoDownloadM.FolderPath) || !string.IsNullOrEmpty(DemoDownloadM.MusicScoreID))
            {
                string jsonCode =GetAudio. GetMp3Json(DemoDownloadM.MusicScoreID);
                DemoDownloadM.Log = GetAudio.GetResult(jsonCode, DemoDownloadM.FolderPath);
            }
        }
    }
}
