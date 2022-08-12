using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PianoScoreTool.Models;
using PianoScoreTool.Utility;
using System.IO;
using System.Text;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace PianoScoreTool.ViewModels
{
    internal class MusicScoreViewModel : ObservableObject
    {
        internal ICommand MusicScoreOperateCommand;
        private MusicScoreModel musicScoreM;
        internal MusicScoreModel MusicScoreM
        {
            get { return musicScoreM; }
            set { SetProperty(ref musicScoreM, value); }
        }
        internal MusicScoreViewModel()
        {
            if (MusicScoreM == null)
            {
                MusicScoreM = new MusicScoreModel();
                MusicScoreM.IsGetAudio = true;
                MusicScoreOperateCommand = new RelayCommand(MusicScoreOperate);
            }
        }
        private void MusicScoreOperate()
        {
            if (!string.IsNullOrEmpty(MusicScoreM.FolderPath))
            {
                StringBuilder sb = new StringBuilder();
                int i = 0;
                foreach (var item in Directory.GetFiles(MusicScoreM.FolderPath))
                {
                    string[] split = item.Split('_');
                    string id = "_" + split[split.Length - 1];
                    string newFilePath = item.Replace(id, ".pdf");
                    if (newFilePath.Contains("_简谱"))
                    {
                        newFilePath = newFilePath.Replace("_简谱", "_首调简谱");
                    }
                    else if (!newFilePath.Contains("_简谱") && !newFilePath.Contains("固定调简谱"))
                    {
                        newFilePath = newFilePath.Replace(".pdf", "_五线谱.pdf");
                    }
                    File.Move(item, newFilePath);
                    string fileName = Path.GetFileNameWithoutExtension(newFilePath);
                    string newDirectoryPath = MusicScoreM.FolderPath + "\\" + fileName.Replace("_五线谱", "").Replace("_首调简谱", "").Replace("_固定调简谱", "");
                    Directory.CreateDirectory(newDirectoryPath);
                    File.Move(newFilePath, newDirectoryPath + "\\" + Path.GetFileName(newFilePath));
                    i++;
                    if (i == 3)
                    {
                        if (MusicScoreM.IsGetAudio == true)
                        {
                            string jsonCode = GetAudio.GetMp3Json(id.Replace(".pdf", "").Replace("_", ""));
                            GetAudio.GetResult(jsonCode, newDirectoryPath);
                        }
                        sb.AppendLine("[" + newDirectoryPath + "]  " + "操作成功！");
                        i = 0;
                    }
                }
                sb.AppendLine("处理完成！");
                MusicScoreM.Log = sb.ToString();
            }
        }
    }
}