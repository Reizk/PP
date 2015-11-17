using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using G = WebSpiderWinform.Global.Global;
using D = WebSpiderWinform.Helper.DownLoadHelper;
using System.IO;
using WebSpiderWinform.Helper;
using System.Threading;
using System.Collections.Concurrent;

namespace PictureSpider
{
    public partial class SpiderForm : Form
    {
        public delegate CDownloadImage QueueHandler(CDownloadImage cdi);

        private readonly int _maxtask = 8;
        private int _downingPicCount = 0;
        private int _getdataCount = 0;
        private int _downloadedCount = 0;
        
        

        public SpiderForm()
        {
            InitializeComponent();
            ServicePointManager.DefaultConnectionLimit = 10;

            this.clb_Sites.Items.AddRange(G.Sites.ToArray());
            this.clb_Artists.Items.AddRange(G.Artists.ToArray());

            G.RootFloder = Application.StartupPath + "\\resource";

            this.lb_rootfloder.Text = G.RootFloder;

            G.DownloadedData = new List<string>();
        }

        private void SpiderForm_Load(object sender, EventArgs e)
        {
            this.lv_AllNewImages.View = View.Details;
            this.lv_AllNewImages.Columns.Add("唯一性标识", 600, HorizontalAlignment.Left);
            this.lv_AllNewImages.Columns.Add("状态", 160, HorizontalAlignment.Left);
            this.lv_AllNewImages.MultiSelect = true;




            this.lv_DownloadedImage.View = View.Details;
            this.lv_DownloadedImage.Columns.Add("唯一性标识", 160, HorizontalAlignment.Left);
            this.lv_DownloadedImage.Columns.Add("状态", 160, HorizontalAlignment.Left);
            this.lv_DownloadedImage.MultiSelect = false;

            this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;



            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "请设置根目录";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                G.RootFloder = fbd.SelectedPath;
                this.lb_rootfloder.Text = G.RootFloder;
                GetDownLoadedData();
            }
            else
            {
                this.Close();
            }
        }

        private void btn_SetRoot_Click(object sender, EventArgs e)
        {
            //  SetRootFolder();
          
        }


        List<CArtist> SiteArtists;
        private void btn_CreateArtist_Click(object sender, EventArgs e)
        {
            SiteArtists = new List<CArtist>();
            foreach (string item in this.clb_Sites.CheckedItems)
            {
                foreach (string item2 in this.clb_Artists.CheckedItems)
                {
                    SiteArtists.Add(new CArtist()
                    {
                        Name = item2,
                        Site = new CSite() { Name = item }
                    });
                }
            }
            this.dgv_Artists.DataSource = SiteArtists;
        }


        private void GetDownLoadedData()
        {
            if (Directory.Exists(G.RootFloder))
            {
                G.Sites.ForEach(tmp =>
                {
                    string sitefloder = G.RootFloder + "\\" + tmp;
                    if (!Directory.Exists(sitefloder))
                    {
                        Directory.CreateDirectory(sitefloder);
                    }

                    G.Artists.ForEach(tm =>
                    {
                        string artistfloder = sitefloder + "\\" + tm;
                        if (!Directory.Exists(artistfloder))
                        {
                            Directory.CreateDirectory(artistfloder);
                        }

                        DirectoryInfo info = new DirectoryInfo(artistfloder);
                        List<FileInfo> imginfos = info.GetFiles().ToList();

                        imginfos.ForEach(t =>
                            {
                                G.DownloadedData.Add(tmp + "_" + t.Name.Split('.')[0]);
                            });
                    });
                });
            }
        }


        enum GetDataType
        {
            All,
            Update
        }

        List<CDownloadImage> AllNewImage = new List<CDownloadImage>();

        private void btn_GetAllData_Click(object sender, EventArgs e)
        {
            this.dgv_Artists.DataSource = null;
            this.btn_GetAllData.BackColor = Color.Brown;


            Action<GetDataType> startgetdatadelegate = StartGetDataDelegate;

            startgetdatadelegate.BeginInvoke(GetDataType.All, StartGetDataCallBack, startgetdatadelegate);
        }

        private void btn_GetUpdateData_Click(object sender, EventArgs e)
        {

            this.dgv_Artists.DataSource = null;
            this.btn_GetUpdateData.BackColor = Color.Brown;

            Action<GetDataType> startgetdatadelegate = StartGetDataDelegate;

            startgetdatadelegate.BeginInvoke(GetDataType.Update, StartGetDataCallBack, startgetdatadelegate);
           
        }



        private void RefreshAllNewImageListview()
        {
            this.lv_AllNewImages.BeginUpdate();

            AllNewImage.ForEach(tmp =>
                {
                    var lvitem = this.lv_AllNewImages.Items[tmp.UniqueData];
                    if (lvitem == null)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Name = tmp.UniqueData;
                        lvi.Text = tmp.UniqueData;
                        lvi.SubItems.Add("未下载");
                        lvi.Tag = tmp;

                        this.lv_AllNewImages.Items.Add(lvi);
                    }
                }
            );

            this.lv_AllNewImages.EndUpdate();


        }

        Queue<CDownloadImage> downloadingImageList = new Queue<CDownloadImage>();

        private void tsmi_Download_Click(object sender, EventArgs e)
        {
            //foreach (ListViewItem item in this.lv_AllNewImages.SelectedItems)
            //{
            //    downloadingImageList.Enqueue((CDownloadImage)item.Tag);
            //}

            //#region del

            ////Action startdelegate = () =>
            ////{


            ////    while (downloadingImageList.Count > 0)
            ////    {
            ////        QueueHandler downloaddelegate = (CDownloadImage cdi) =>
            ////        {



            ////            lv_AllNewImages.Invoke(new Action(() => { lv_AllNewImages.Items[cdi.UniqueData].SubItems[1].Text = "正在下载"; }));

            ////            return DownloadSiteImage(cdi);
            ////        };


            ////        AsyncCallback downloadcallback = (IAsyncResult i) =>
            ////        {


            ////            var q = (QueueHandler)i.AsyncState;
            ////            var result = q.EndInvoke(i);
            ////            if (result.Success)
            ////            {

            ////                lv_AllNewImages.Invoke(new Action(() => { lv_AllNewImages.Items[result.UniqueData].SubItems[1].Text = "下载完成"; }));


            ////                ListViewItem lvi = new ListViewItem();
            ////                lvi.Name = result.UniqueData;
            ////                lvi.Text = result.UniqueData;
            ////                lvi.SubItems.Add("已下载");
            ////                lvi.Tag = result;

            ////                lv_DownloadedImage.Invoke(new Action(() => { lv_DownloadedImage.Items.Add(lvi); }));

            ////            }
            ////            else
            ////            {

            ////                lv_AllNewImages.Invoke(new Action(() => { lv_AllNewImages.Items[result.UniqueData].SubItems[1].Text = "下载失败"; }));

            ////            }

            ////            _downingPicCount--;

            ////        };
            ////        _downingPicCount++;
            ////        downloaddelegate.BeginInvoke(downloadingImageList.Dequeue(), downloadcallback, downloaddelegate);



            ////       while (_downingPicCount >= _maxtask)
            ////        {
            ////            Thread.Sleep(5000);
            ////        }




            ////    }
            ////};










            ////AsyncCallback startcallback = (IAsyncResult i) =>
            ////{
            ////    this.BeginInvoke(new Action(() => { this.Text = "下载成功"; }));

            ////    Action ddelegate = (Action)(i.AsyncState);
            ////    ddelegate.EndInvoke(i);
            ////};
            //#endregion
            //Action startdelegate = StartDownloadDelegate;
            //startdelegate.BeginInvoke(StartDownloadCallBack, startdelegate);
        }

        /// <summary>
        /// 开始下载
        /// </summary>
        private void StartDownLoading()
        {
            this.lv_AllNewImages.Invoke(new Action(() =>
                {
                    foreach (ListViewItem item in this.lv_AllNewImages.Items)
                    {
                        if (!((CDownloadImage)item.Tag).Success)
                        {
                            downloadingImageList.Enqueue((CDownloadImage)item.Tag);
                        }
                    }
                }));
            if (downloadingImageList.Count > 0)
            {
                Action startdelegate = StartDownloadDelegate;
                startdelegate.BeginInvoke(StartDownloadCallBack, startdelegate);
            }
            else
            {
                MessageBox.Show("全部下载完成!");
            }
        }

        #region 获取信息主线程
        private void StartGetDataDelegate(GetDataType gdt)
        {
            switch (gdt)
            {
                case GetDataType.All:
                    while (SiteArtists.Count > 0)
                    {
                        var item = SiteArtists[0];
                        SiteArtists.RemoveAt(0);
                        Func<CArtist, List<CDownloadImage>> getdatadelegate = GetAllDataDelegate;
                        _getdataCount++;
                        getdatadelegate.BeginInvoke(item, GetDataCallBack, getdatadelegate);
                        while (_getdataCount > _maxtask)
                        {
                            Thread.Sleep(7000);
                        }
                    }
                    break;
                case GetDataType.Update:
                    while (SiteArtists.Count > 0)
                    {
                        var item = SiteArtists[0];
                        SiteArtists.RemoveAt(0);
                        Func<CArtist, List<CDownloadImage>> getdatadelegate = GetUpdateDataDelegate;
                        _getdataCount++;
                        getdatadelegate.BeginInvoke(item, GetDataCallBack, getdatadelegate);
                        while (_getdataCount > _maxtask)
                        {
                            Thread.Sleep(7000);
                        }
                    }
                    break;
            }
            while (_getdataCount > 0)
            {
                Thread.Sleep(5000);
            }
        }

        private void StartGetDataCallBack(IAsyncResult i)
        {
            Action<GetDataType> ddelegate = (Action<GetDataType>)(i.AsyncState);
            ddelegate.EndInvoke(i);

            btn_GetAllData.Invoke(new Action(() => { btn_GetAllData.BackColor = btn_SetRoot.BackColor; }));

            this.lv_AllNewImages.Invoke(new Action(() => { RefreshAllNewImageListview(); }));
            
            
           // MessageBox.Show("信息获取完成！开始下载!");
            progressBar1.Invoke(new Action(() => { progressBar1.Maximum = AllNewImage.Count(); }));
            StartDownLoading();
        }

        private List<CDownloadImage> GetAllDataDelegate(CArtist cdi)
        {
            return cdi.GetALLImageDataByArtist();
        }

        private List<CDownloadImage> GetUpdateDataDelegate(CArtist cdi)
        {
            return cdi.GetUpdateImageDataByArtist();
        }

        private void GetDataCallBack(IAsyncResult i)
        {
            Func<CArtist, List<CDownloadImage>> ddelegate = (Func<CArtist, List<CDownloadImage>>)(i.AsyncState);
            var result = ddelegate.EndInvoke(i);
            lock (AllNewImage)
            {
                AllNewImage.AddRange(result.FindAll(tm =>
                       AllNewImage.FindIndex(t => t.UniqueData == tm.UniqueData).Equals(-1))
                        );
            }
            _getdataCount--;
        }

        #endregion

        #region 下载循环主线程

        private void StartDownloadDelegate()
        {
            while (downloadingImageList.Count > 0)
            {
                QueueHandler downloaddelegate = DownloadDelegate;

                AsyncCallback downloadcallback = DownloadCallBack;

                _downingPicCount++;
                downloaddelegate.BeginInvoke(downloadingImageList.Dequeue(), downloadcallback, downloaddelegate);

                while (_downingPicCount >= _maxtask)
                {
                    Thread.Sleep(5000);
                }
            }


            while (_downingPicCount > 0)
            {
                Thread.Sleep(5000);
            }
        }

        private void StartDownloadCallBack(IAsyncResult i)
        {
            Action ddelegate = (Action)(i.AsyncState);
            ddelegate.EndInvoke(i);
            StartDownLoading();
        }

        #endregion

        #region 每个下载的线程

        private CDownloadImage DownloadDelegate(CDownloadImage cdi)
        {
            lv_AllNewImages.Invoke(new Action(() => { lv_AllNewImages.Items[cdi.UniqueData].SubItems[1].Text = "正在下载"; }));

            return DownloadSiteImage(cdi);
        }

        private void DownloadCallBack(IAsyncResult i)
        {
            var q = (QueueHandler)i.AsyncState;
            var result = q.EndInvoke(i);
            _downingPicCount--;
            if (result.Success)
            {
                lv_AllNewImages.Invoke(new Action(() => { lv_AllNewImages.Items[result.UniqueData].SubItems[1].Text = "下载完成"; }));
                progressBar1.BeginInvoke(new Action(() => { progressBar1.Value = ++_downloadedCount; }));

                ListViewItem lvi = new ListViewItem();
                lvi.Name = result.UniqueData;
                lvi.Text = result.UniqueData;
                lvi.SubItems.Add("已下载");
                lvi.Tag = result;

                lv_DownloadedImage.Invoke(new Action(() => { lv_DownloadedImage.Items.Add(lvi); }));

                lock (G.DownloadedData)
                {
                    G.DownloadedData.Add(result.UniqueData);
                }
            }
            else
            {
                lv_AllNewImages.Invoke(new Action(() => { lv_AllNewImages.Items[result.UniqueData].SubItems[1].Text = "下载失败"; }));
            }
        }

        #endregion

        private CDownloadImage DownloadSiteImage(CDownloadImage cdi)
        {
            if (D.DowloadImg(cdi.Url, cdi.Path) == "")
            {
                cdi.Success = false;
            }
            else
            {
                cdi.Success = true;
            }
            return cdi;
        }



        //已下载的图片，选择后显示
        private void lv_DownloadedImage_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            CDownloadImage tag = (CDownloadImage)e.Item.Tag;
            this.pictureBox1.ImageLocation = (tag.Path +
                "\\" + tag.Url.Substring(tag.Url.LastIndexOf('/') + 1));
        }

        private void lv_DownloadedImage_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lv_DownloadedImage.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("正的要删除吗?", "Caption", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var tag = ((CDownloadImage)this.lv_DownloadedImage.SelectedItems[0].Tag);
                    tag.Success = false;
                    lv_DownloadedImage.Items.Remove(lv_DownloadedImage.Items[tag.UniqueData]);
                    lv_AllNewImages.Invoke(new Action(() =>
                    {
                        lv_AllNewImages.Items[tag.UniqueData].SubItems[1].Text = "下载失败";
                    }));
                    lock (G.DownloadedData)
                    {
                        G.DownloadedData.Remove(tag.UniqueData);
                    }
                }
            }
        }

    }
}
