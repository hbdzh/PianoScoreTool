using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Web;

namespace PianoScoreTool.Utility
{
    internal class GetAudio
    {
        /// <summary>
        /// 解析JSON
        /// </summary>
        /// <param name="jsonCode"></param>
        /// <param name="savePath"></param>
        internal static string GetResult(string jsonCode, string savePath)
        {
            string mp3Url = JObject.Parse(jsonCode)["list"]["audition_urtext"].ToString().Split('?')[0];//将翻译结果添加到集合
            string name = HttpUtility.UrlDecode(JObject.Parse(jsonCode)["list"]["name"].ToString().Split('?')[0]);
            using (var web = new WebClient())
            {
                web.DownloadFile(mp3Url, savePath + "\\" + name + ".mp3");
            }
            return "[" + savePath + "\\" + name + ".mp3]  " + "下载完成！";
        }
        /// <summary>
        /// 获取MP3的Json
        /// </summary>
        internal static string GetMp3Json(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                string url = string.Format("https://www.gangqinpu.com/api/home/user/getOpernDetail?service_type=ccgq&platform=web-ccgq&service_uid=&service_key=&ccgq_uuid=&uid=&id={0}", id);
                Uri uri = new Uri(url);
                var request = (HttpWebRequest)WebRequest.Create(uri);
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                return responseString;
            }
            else
            {
                return "error";
            }
        }
    }
}
