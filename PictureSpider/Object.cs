using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using G = WebSpiderWinform.Global.Global;
using D = WebSpiderWinform.Helper.DownLoadHelper;
using WebSpiderWinform.Helper;

namespace PictureSpider
{
    public class BaseObject
    {

    }

    public class CSite
    {
        public string Name { get; set; }
    }

    public class CArtist
    {
        
        public CSite Site;
        public string Name { get; set; }
        public string SiteName { get { return Site.Name; } }
    }

    public class CDownloadImage
    {
        public CArtist Artist { get; set;}

        public string Md5 { get; set; }

        public string UniqueData { get { return Artist.SiteName + "_" + Md5; } }

        public string Path { get; set; }

        public string Url { get; set; }

        public bool Success { get; set; }
    }

    public static class CImageDataBuilder
    {
        public static List<CDownloadImage> GetALLImageDataByArtist(this CArtist ca)
        {
            List<CDownloadImage> list = new List<CDownloadImage>();
            ISiteHelper dl;
            if (ca.SiteName == "Danbooru")
            {
                dl = new SDanbooru();
            }
            else if (ca.SiteName == "TBIB")
            {
                dl = new STBIB();
            }
            else
            {
                throw new Exception();
            }
            List<string> urls = dl.GetAllDataUrlsByArtist(ca.Name);
            urls.ForEach(tmp =>
                {
                    var item = new CDownloadImage()
                    {
                        Artist = ca,
                        Md5 = URLHelper.GetMD5ByImgURL(tmp),
                        Success = false,
                        Url = tmp,
                        Path = G.RootFloder + "\\" + ca.SiteName + "\\" + ca.Name
                    };
                        list.Add(item);
                });
            return list;
        }
        public static List<CDownloadImage> GetUpdateImageDataByArtist(this CArtist ca)
        {
            List<CDownloadImage> list = new List<CDownloadImage>();
            ISiteHelper dl;
            if (ca.SiteName == "Danbooru")
            {
                dl = new SDanbooru();
            }
            else if (ca.SiteName == "TBIB")
            {
                dl = new STBIB();
            }
            else
            {
                throw new Exception();
            }
            List<string> urls = dl.GetUpdateDataUrlsByArtist(ca.Name);
            urls.ForEach(tmp =>
            {
                var item = new CDownloadImage()
                {
                    Artist = ca,
                    Md5 = URLHelper.GetMD5ByImgURL(tmp),
                    Success = false,
                    Url = tmp,
                    Path = G.RootFloder + "\\" + ca.SiteName + "\\" + ca.Name
                };
                list.Add(item);
            });
            return list;
        }



        //private bool CheckIsExist(CDownloadImage cdi)
        //{
        //    return G.DownloadedData.Contains(cdi.UniqueData);
        //}

    }

}
