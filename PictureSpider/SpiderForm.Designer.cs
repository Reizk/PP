namespace PictureSpider
{
    partial class SpiderForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lv_DownloadedImage = new System.Windows.Forms.ListView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lv_AllNewImages = new System.Windows.Forms.ListView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.cms_DownLoad = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_Download = new System.Windows.Forms.ToolStripMenuItem();
            this.全选ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gb_DAndT = new System.Windows.Forms.GroupBox();
            this.btn_CreateArtist = new System.Windows.Forms.Button();
            this.clb_Sites = new System.Windows.Forms.CheckedListBox();
            this.clb_Artists = new System.Windows.Forms.CheckedListBox();
            this.dgv_Artists = new PictureSpider.BaseDataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_SetRoot = new System.Windows.Forms.Button();
            this.lb_rootfloder = new System.Windows.Forms.Label();
            this.btn_GetUpdateData = new System.Windows.Forms.Button();
            this.btn_GetAllData = new System.Windows.Forms.Button();
            this.lb_Count = new System.Windows.Forms.Label();
            this.lb_Artist = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.cms_DownLoad.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gb_DAndT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Artists)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.splitContainer2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(963, 723);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lv_DownloadedImage
            // 
            this.lv_DownloadedImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_DownloadedImage.Location = new System.Drawing.Point(0, 0);
            this.lv_DownloadedImage.Margin = new System.Windows.Forms.Padding(2);
            this.lv_DownloadedImage.MultiSelect = false;
            this.lv_DownloadedImage.Name = "lv_DownloadedImage";
            this.lv_DownloadedImage.Size = new System.Drawing.Size(194, 717);
            this.lv_DownloadedImage.TabIndex = 4;
            this.lv_DownloadedImage.UseCompatibleStateImageBehavior = false;
            this.lv_DownloadedImage.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lv_DownloadedImage_ItemSelectionChanged);
            this.lv_DownloadedImage.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lv_DownloadedImage_MouseDoubleClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(759, 717);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lv_AllNewImages);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(963, 723);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lv_AllNewImages
            // 
            this.lv_AllNewImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_AllNewImages.Location = new System.Drawing.Point(3, 3);
            this.lv_AllNewImages.Margin = new System.Windows.Forms.Padding(2);
            this.lv_AllNewImages.Name = "lv_AllNewImages";
            this.lv_AllNewImages.Size = new System.Drawing.Size(957, 648);
            this.lv_AllNewImages.TabIndex = 10;
            this.lv_AllNewImages.UseCompatibleStateImageBehavior = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 651);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(957, 69);
            this.panel2.TabIndex = 9;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(957, 69);
            this.progressBar1.TabIndex = 0;
            // 
            // cms_DownLoad
            // 
            this.cms_DownLoad.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Download,
            this.全选ToolStripMenuItem});
            this.cms_DownLoad.Name = "cms_DownLoad";
            this.cms_DownLoad.Size = new System.Drawing.Size(101, 48);
            // 
            // tsmi_Download
            // 
            this.tsmi_Download.Name = "tsmi_Download";
            this.tsmi_Download.Size = new System.Drawing.Size(100, 22);
            this.tsmi_Download.Text = "下载";
            this.tsmi_Download.Click += new System.EventHandler(this.tsmi_Download_Click);
            // 
            // 全选ToolStripMenuItem
            // 
            this.全选ToolStripMenuItem.Name = "全选ToolStripMenuItem";
            this.全选ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.全选ToolStripMenuItem.Text = "全选";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(963, 723);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gb_DAndT);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgv_Artists);
            this.splitContainer1.Size = new System.Drawing.Size(957, 639);
            this.splitContainer1.SplitterDistance = 319;
            this.splitContainer1.TabIndex = 12;
            // 
            // gb_DAndT
            // 
            this.gb_DAndT.Controls.Add(this.btn_CreateArtist);
            this.gb_DAndT.Controls.Add(this.clb_Sites);
            this.gb_DAndT.Controls.Add(this.clb_Artists);
            this.gb_DAndT.Dock = System.Windows.Forms.DockStyle.Top;
            this.gb_DAndT.Location = new System.Drawing.Point(0, 0);
            this.gb_DAndT.Name = "gb_DAndT";
            this.gb_DAndT.Size = new System.Drawing.Size(319, 349);
            this.gb_DAndT.TabIndex = 11;
            this.gb_DAndT.TabStop = false;
            this.gb_DAndT.Text = "D_And_B";
            // 
            // btn_CreateArtist
            // 
            this.btn_CreateArtist.Location = new System.Drawing.Point(218, 307);
            this.btn_CreateArtist.Name = "btn_CreateArtist";
            this.btn_CreateArtist.Size = new System.Drawing.Size(75, 23);
            this.btn_CreateArtist.TabIndex = 2;
            this.btn_CreateArtist.Text = "组合";
            this.btn_CreateArtist.UseVisualStyleBackColor = true;
            this.btn_CreateArtist.Click += new System.EventHandler(this.btn_CreateArtist_Click);
            // 
            // clb_Sites
            // 
            this.clb_Sites.CheckOnClick = true;
            this.clb_Sites.FormattingEnabled = true;
            this.clb_Sites.Location = new System.Drawing.Point(6, 20);
            this.clb_Sites.Name = "clb_Sites";
            this.clb_Sites.Size = new System.Drawing.Size(120, 260);
            this.clb_Sites.TabIndex = 0;
            // 
            // clb_Artists
            // 
            this.clb_Artists.CheckOnClick = true;
            this.clb_Artists.FormattingEnabled = true;
            this.clb_Artists.Location = new System.Drawing.Point(132, 20);
            this.clb_Artists.Name = "clb_Artists";
            this.clb_Artists.Size = new System.Drawing.Size(181, 260);
            this.clb_Artists.TabIndex = 1;
            // 
            // dgv_Artists
            // 
            this.dgv_Artists.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgv_Artists.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Artists.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Artists.Location = new System.Drawing.Point(0, 0);
            this.dgv_Artists.Name = "dgv_Artists";
            this.dgv_Artists.RowTemplate.Height = 23;
            this.dgv_Artists.Size = new System.Drawing.Size(634, 639);
            this.dgv_Artists.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_SetRoot);
            this.panel1.Controls.Add(this.lb_rootfloder);
            this.panel1.Controls.Add(this.btn_GetUpdateData);
            this.panel1.Controls.Add(this.btn_GetAllData);
            this.panel1.Controls.Add(this.lb_Count);
            this.panel1.Controls.Add(this.lb_Artist);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 642);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(957, 78);
            this.panel1.TabIndex = 10;
            // 
            // btn_SetRoot
            // 
            this.btn_SetRoot.Location = new System.Drawing.Point(6, 37);
            this.btn_SetRoot.Name = "btn_SetRoot";
            this.btn_SetRoot.Size = new System.Drawing.Size(75, 23);
            this.btn_SetRoot.TabIndex = 8;
            this.btn_SetRoot.Text = "设置根目录";
            this.btn_SetRoot.UseVisualStyleBackColor = true;
            this.btn_SetRoot.Visible = false;
            this.btn_SetRoot.Click += new System.EventHandler(this.btn_SetRoot_Click);
            // 
            // lb_rootfloder
            // 
            this.lb_rootfloder.AutoSize = true;
            this.lb_rootfloder.Location = new System.Drawing.Point(87, 46);
            this.lb_rootfloder.Name = "lb_rootfloder";
            this.lb_rootfloder.Size = new System.Drawing.Size(29, 12);
            this.lb_rootfloder.TabIndex = 7;
            this.lb_rootfloder.Text = "ROOT";
            // 
            // btn_GetUpdateData
            // 
            this.btn_GetUpdateData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_GetUpdateData.Location = new System.Drawing.Point(883, 37);
            this.btn_GetUpdateData.Name = "btn_GetUpdateData";
            this.btn_GetUpdateData.Size = new System.Drawing.Size(69, 30);
            this.btn_GetUpdateData.TabIndex = 4;
            this.btn_GetUpdateData.Text = "Updata";
            this.btn_GetUpdateData.UseVisualStyleBackColor = true;
            this.btn_GetUpdateData.Click += new System.EventHandler(this.btn_GetUpdateData_Click);
            // 
            // btn_GetAllData
            // 
            this.btn_GetAllData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_GetAllData.Location = new System.Drawing.Point(780, 37);
            this.btn_GetAllData.Name = "btn_GetAllData";
            this.btn_GetAllData.Size = new System.Drawing.Size(69, 30);
            this.btn_GetAllData.TabIndex = 4;
            this.btn_GetAllData.Text = "ALL";
            this.btn_GetAllData.UseVisualStyleBackColor = true;
            this.btn_GetAllData.Click += new System.EventHandler(this.btn_GetAllData_Click);
            // 
            // lb_Count
            // 
            this.lb_Count.AutoSize = true;
            this.lb_Count.Location = new System.Drawing.Point(696, 69);
            this.lb_Count.Name = "lb_Count";
            this.lb_Count.Size = new System.Drawing.Size(0, 12);
            this.lb_Count.TabIndex = 6;
            // 
            // lb_Artist
            // 
            this.lb_Artist.AutoSize = true;
            this.lb_Artist.Location = new System.Drawing.Point(696, 31);
            this.lb_Artist.Name = "lb_Artist";
            this.lb_Artist.Size = new System.Drawing.Size(0, 12);
            this.lb_Artist.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(971, 749);
            this.tabControl1.TabIndex = 11;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lv_DownloadedImage);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer2.Size = new System.Drawing.Size(957, 717);
            this.splitContainer2.SplitterDistance = 194;
            this.splitContainer2.TabIndex = 5;
            // 
            // SpiderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 749);
            this.Controls.Add(this.tabControl1);
            this.Name = "SpiderForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.SpiderForm_Load);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.cms_DownLoad.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gb_DAndT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Artists)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox gb_DAndT;
        private System.Windows.Forms.Button btn_CreateArtist;
        private System.Windows.Forms.CheckedListBox clb_Sites;
        private System.Windows.Forms.CheckedListBox clb_Artists;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_GetUpdateData;
        private System.Windows.Forms.Button btn_GetAllData;
        private System.Windows.Forms.Label lb_Count;
        private System.Windows.Forms.Label lb_Artist;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private BaseDataGridView dgv_Artists;
        private System.Windows.Forms.Label lb_rootfloder;
        private System.Windows.Forms.Button btn_SetRoot;
        private System.Windows.Forms.ListView lv_DownloadedImage;
        private System.Windows.Forms.ListView lv_AllNewImages;
        private System.Windows.Forms.ContextMenuStrip cms_DownLoad;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Download;
        private System.Windows.Forms.ToolStripMenuItem 全选ToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.SplitContainer splitContainer2;

    }
}

