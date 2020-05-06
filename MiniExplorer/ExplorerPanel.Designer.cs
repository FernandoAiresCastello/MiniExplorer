namespace MiniExplorer
{
    partial class ExplorerPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExplorerPanel));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TxtRootPath = new System.Windows.Forms.TextBox();
            this.ToolBar = new System.Windows.Forms.ToolStrip();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.LbFileCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.LbFolderCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.LbSort = new System.Windows.Forms.ToolStripStatusLabel();
            this.Icons = new System.Windows.Forms.ImageList(this.components);
            this.DirectoryListView = new MiniExplorer.DirectoryListView();
            this.tableLayoutPanel1.SuspendLayout();
            this.StatusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.DirectoryListView, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.TxtRootPath, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ToolBar, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.StatusBar, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(336, 402);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // TxtRootPath
            // 
            this.TxtRootPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtRootPath.Location = new System.Drawing.Point(3, 28);
            this.TxtRootPath.Name = "TxtRootPath";
            this.TxtRootPath.Size = new System.Drawing.Size(330, 20);
            this.TxtRootPath.TabIndex = 0;
            this.TxtRootPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtRootPath_KeyDown);
            // 
            // ToolBar
            // 
            this.ToolBar.Location = new System.Drawing.Point(0, 0);
            this.ToolBar.Name = "ToolBar";
            this.ToolBar.Size = new System.Drawing.Size(336, 25);
            this.ToolBar.TabIndex = 2;
            this.ToolBar.Text = "toolStrip1";
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LbFileCount,
            this.LbFolderCount,
            this.LbSort});
            this.StatusBar.Location = new System.Drawing.Point(0, 380);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(336, 22);
            this.StatusBar.TabIndex = 3;
            this.StatusBar.Text = "statusStrip1";
            // 
            // LbFileCount
            // 
            this.LbFileCount.Name = "LbFileCount";
            this.LbFileCount.Size = new System.Drawing.Size(39, 17);
            this.LbFileCount.Text = "0 Files";
            // 
            // LbFolderCount
            // 
            this.LbFolderCount.Name = "LbFolderCount";
            this.LbFolderCount.Size = new System.Drawing.Size(54, 17);
            this.LbFolderCount.Text = "0 Folders";
            // 
            // LbSort
            // 
            this.LbSort.Name = "LbSort";
            this.LbSort.Size = new System.Drawing.Size(107, 17);
            this.LbSort.Text = "Sort: Filename ASC";
            // 
            // Icons
            // 
            this.Icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Icons.ImageStream")));
            this.Icons.TransparentColor = System.Drawing.Color.Transparent;
            this.Icons.Images.SetKeyName(0, "folder.png");
            this.Icons.Images.SetKeyName(1, "page_white.png");
            this.Icons.Images.SetKeyName(2, "arrow_undo.png");
            // 
            // DirectoryListView
            // 
            this.DirectoryListView.AllowColumnReorder = true;
            this.DirectoryListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DirectoryListView.ExplorerPanel = null;
            this.DirectoryListView.FullRowSelect = true;
            this.DirectoryListView.GridLines = true;
            this.DirectoryListView.HideSelection = false;
            this.DirectoryListView.Location = new System.Drawing.Point(3, 54);
            this.DirectoryListView.Name = "DirectoryListView";
            this.DirectoryListView.Size = new System.Drawing.Size(330, 323);
            this.DirectoryListView.SortBy = MiniExplorer.DirectoryListView.DetailColumn.Filename;
            this.DirectoryListView.TabIndex = 1;
            this.DirectoryListView.UseCompatibleStateImageBehavior = false;
            this.DirectoryListView.View = System.Windows.Forms.View.Details;
            // 
            // ExplorerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ExplorerPanel";
            this.Size = new System.Drawing.Size(336, 402);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DirectoryListView DirectoryListView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox TxtRootPath;
        private System.Windows.Forms.ToolStrip ToolBar;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripStatusLabel LbFileCount;
        private System.Windows.Forms.ToolStripStatusLabel LbFolderCount;
        private System.Windows.Forms.ToolStripStatusLabel LbSort;
        public System.Windows.Forms.ImageList Icons;
    }
}
