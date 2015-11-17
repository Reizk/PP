using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace WebSpiderWinform.Helper
{
    public interface ISiteHelper
    {
        List<string> GetAllDataUrlsByArtist(string artist);
        List<string> GetUpdateDataUrlsByArtist(string artist);
    }

    public class SDanbooru : ISiteHelper
    {
        public List<string> GetAllDataUrlsByArtist(string artist)
        {
            return GetAllDataUrlsByFirstUrl(GetFirstPageUrlByArtist(artist));
        }

        public List<string> GetUpdateDataUrlsByArtist(string artist)
        {
            return GetUpdateUrlsByFirstUrl(GetFirstPageUrlByArtist(artist));
        }

        public string GetFirstPageUrlByArtist(string artist)
        {
            return "http://danbooru.donmai.us/posts?page=1&tags=" + artist;
        }

        public string GetNextPageUrl(string url)
        {
            Regex re = new Regex("page=(.*?)&tags=", RegexOptions.IgnoreCase);
            Match m = re.Match(url);
            if (m.Success)
            {
                return url.Replace("page=" + m.Groups[1].Value, "page=" + (int.Parse(m.Groups[1].Value) + 1).ToString());
            }
            else
            {
                throw new Exception();
            }
        }

        public List<string> GetImageUrlsByPageUrl(string url)
        {
            List<string> imgUrls = new List<string>();
            Regex re = new Regex("data-file-url=\"(/data/.*?)\"", RegexOptions.IgnoreCase);

            string htmlCode = Helper.HttpHelper.HttpHelper.HtmlCode(url);

            if (CurrentUrlHasImgData(htmlCode))
            {
                var matchs = re.Matches(htmlCode);
                foreach (Match m in matchs)
                {
                    imgUrls.Add("http://danbooru.donmai.us" + m.Groups[1]);
                }
            }
            return imgUrls;
        }

        public List<string> GetAllDataUrlsByFirstUrl(string url)
        {
            List<string> allimgUrls = new List<string>();
            string _url = url;
            List<string> imglist = GetImageUrlsByPageUrl(_url);

            while (imglist.Count > 0)
            {
                allimgUrls.AddRange(imglist);
                _url = GetNextPageUrl(_url);
                imglist = GetImageUrlsByPageUrl(_url);
            }
            return RemoveExistUrl(allimgUrls);
        }

        public List<string> GetUpdateUrlsByFirstUrl(string url)
        {
            List<string> allimgUrls = new List<string>();
            string _url = url;
            List<string> imglist = RemoveExistUrl(GetImageUrlsByPageUrl(_url));
            while (imglist.Count > 0)
            {
                allimgUrls.AddRange(imglist);
                _url = GetNextPageUrl(_url);
                imglist = RemoveExistUrl(GetImageUrlsByPageUrl(_url));
            }
            return allimgUrls;
        }

        private List<string> RemoveExistUrl(List<string> urls)
        {
            return urls.FindAll(tmp => !Global.Global.DownloadedData.Contains("Danbooru" + "_" + tmp.GetMD5ByImgURL()));
        }

        private bool CurrentUrlHasImgData(string htmlCode)
        {
            Regex re = new Regex("data-file-url=\"/data/.*?..*?\"", RegexOptions.IgnoreCase);
            return re.Match(htmlCode).Success;
        }
    }

    public class STBIB : ISiteHelper
    {
        public List<string> GetAllDataUrlsByArtist(string artist)
        {
            return GetAllDataUrlsByFirstUrl(GetFirstPageUrlByArtist(artist));
        }

        public List<string> GetUpdateDataUrlsByArtist(string artist)
        {
            return GetUpdateUrlsByFirstUrl(GetFirstPageUrlByArtist(artist));
        }
        public string GetFirstPageUrlByArtist(string artist)
        {
            return "http://www.tbib.org/index.php?page=post&s=list&tags=" + artist + "&pid=0";
        }

        public string GetNextPageUrl(string url)
        {
            int n;
            string num = url.Split('=').Last();
            try
            {
                n = int.Parse(num);
                return url.Replace("&pid=" + num, "&pid=" + (n + 50).ToString());
            }
            catch
            {
                throw new Exception();
            }
        }

        public List<string> GetImageUrlsByPageUrl(string url)
        {
            List<string> imgUrls = new List<string>();
            Regex re = new Regex("<img src=\"http://tbib.org/thumbnails/(.*?)\\?", RegexOptions.IgnoreCase);
            string htmlCode = Helper.HttpHelper.HttpHelper.HtmlCode(url);
            if (CurrentUrlHasImgData(htmlCode))
            {
                var matchs = re.Matches(htmlCode);
                foreach (Match m in matchs)
                {
                    string order = m.Groups[1].Value.Split('/')[0];
                    string md5 = m.Groups[1].Value.Split('/')[1].Split('_')[1].Split('?')[0];
                    imgUrls.Add("http://tbib.org//images/" + order + '/' + md5);
                }
            }
            return imgUrls;
        }

        public List<string> GetAllDataUrlsByFirstUrl(string url)
        {
            List<string> allimgUrls = new List<string>();
            string _url = url;
            List<string> imglist = GetImageUrlsByPageUrl(_url);

            while (imglist.Count > 0)
            {
                allimgUrls.AddRange(imglist);
                _url = GetNextPageUrl(_url);
                imglist = GetImageUrlsByPageUrl(_url);
            }
            return RemoveExistUrl(allimgUrls);
        }

        public List<string> GetUpdateUrlsByFirstUrl(string url)
        {
            List<string> allimgUrls = new List<string>();
            string _url = url;
            List<string> imglist = RemoveExistUrl(GetImageUrlsByPageUrl(_url));
            while (imglist.Count > 0)
            {
                allimgUrls.AddRange(imglist);
                _url = GetNextPageUrl(_url);
                imglist = RemoveExistUrl(GetImageUrlsByPageUrl(_url));
            }
            return allimgUrls;
        }


        private List<string> RemoveExistUrl(List<string> urls)
        {
            lock (Global.Global.DownloadedData)
            {
                return urls.FindAll(tmp => !Global.Global.DownloadedData.Contains("TBIB" + "_" + tmp.GetMD5ByImgURL()));
            }
        }

        private bool CurrentUrlHasImgData(string htmlCode)
        {
            Regex re = new Regex("<img src=\"http://tbib.org/thumbnails/(.*?)\\?", RegexOptions.IgnoreCase);
            return re.Match(htmlCode).Success;
        }
    }

    public static class URLHelper
    {
        public static string GetMD5ByImgURL(this string url)
        {
            return url.Substring(url.LastIndexOf('/') + 1).Split('.')[0];
        }
    }

    class DownLoadHelper
    {

        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="url"></param>
        public static string DowloadImg(string url, string path)
        {
            if (!string.IsNullOrEmpty(url))
            {
                string truepath = string.Empty;
                try
                {
                    //if (!url.Contains("http"))
                    //{
                    //    url = Global.WebUrl + url;
                    //}
                    string aLastName = url.Substring(url.LastIndexOf(".") + 1, (url.Length - url.LastIndexOf(".") - 1));   //扩展名
                    string md5 = url.Substring(url.LastIndexOf('/') + 1).Split('.')[0];
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                    request.KeepAlive = false;

                    request.Timeout = 2000;
                    request.UserAgent = "Mozilla/5.0 (Windows NT 5.2) AppleWebKit/534.30 (KHTML, like Gecko) Chrome/12.0.742.122 Safari/534.30";// "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.1.4322)"; // 
                    request.AllowAutoRedirect = true;//是否允许302


                    truepath=path + "\\" + md5 + "." + aLastName;
                    using (WebResponse response = request.GetResponse())
                    {
                        using (Stream reader = response.GetResponseStream())
                        {

                            using (FileStream writer = new FileStream(truepath, FileMode.OpenOrCreate, FileAccess.Write))
                            {

                                byte[] buff;

                                buff = new byte[512];


                                int c = 0; //实际读取的字节数
                                while ((c = reader.Read(buff, 0, buff.Length)) > 0)
                                {
                                    writer.Write(buff, 0, c);
                                }
                            }
                        }

                    }
                    return md5;//(aFirstName + "." + aLastName);
                }
                catch (Exception)
                {
                    Thread.Sleep(1000);

                    FileInfo fi = new FileInfo(truepath);
                    if (fi.Exists)
                    {
                        fi.Delete();
                    }
                    return "";
                }
            }
            return "";
        }
    }
}
