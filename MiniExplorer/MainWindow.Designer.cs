namespace MiniExplorer
{
    partial class MainWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.RootPanel = new System.Windows.Forms.Panel();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.SplitContainer = new System.Windows.Forms.SplitContainer();
            this.MainStatusBar = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnToggleDualPanel = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnToggleGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnFont = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.LeftPanel = new MiniExplorer.ExplorerPanel();
            this.RightPanel = new MiniExplorer.ExplorerPanel();
            this.BtnResetFont = new System.Windows.Forms.ToolStripMenuItem();
            this.RootPanel.SuspendLayout();
            this.ContentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).BeginInit();
            this.SplitContainer.Panel1.SuspendLayout();
            this.SplitContainer.Panel2.SuspendLayout();
            this.SplitContainer.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RootPanel
            // 
            this.RootPanel.Controls.Add(this.ContentPanel);
            this.RootPanel.Controls.Add(this.MainStatusBar);
            this.RootPanel.Controls.Add(this.menuStrip1);
            this.RootPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RootPanel.Location = new System.Drawing.Point(0, 0);
            this.RootPanel.Name = "RootPanel";
            this.RootPanel.Size = new System.Drawing.Size(833, 441);
            this.RootPanel.TabIndex = 0;
            // 
            // ContentPanel
            // 
            this.ContentPanel.Controls.Add(this.SplitContainer);
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(0, 24);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(833, 395);
            this.ContentPanel.TabIndex = 2;
            // 
            // SplitContainer
            // 
            this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer.Name = "SplitContainer";
            // 
            // SplitContainer.Panel1
            // 
            this.SplitContainer.Panel1.Controls.Add(this.LeftPanel);
            // 
            // SplitContainer.Panel2
            // 
            this.SplitContainer.Panel2.Controls.Add(this.RightPanel);
            this.SplitContainer.Size = new System.Drawing.Size(833, 395);
            this.SplitContainer.SplitterDistance = 405;
            this.SplitContainer.TabIndex = 0;
            // 
            // MainStatusBar
            // 
            this.MainStatusBar.Location = new System.Drawing.Point(0, 419);
            this.MainStatusBar.Name = "MainStatusBar";
            this.MainStatusBar.Size = new System.Drawing.Size(833, 22);
            this.MainStatusBar.TabIndex = 1;
            this.MainStatusBar.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(833, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnRefresh,
            this.toolStripSeparator1,
            this.BtnExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // BtnExit
            // 
            this.BtnExit.Image = ((System.Drawing.Image)(resources.GetObject("BtnExit.Image")));
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(180, 22);
            this.BtnExit.Text = "Exit";
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("BtnRefresh.Image")));
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.BtnRefresh.Size = new System.Drawing.Size(180, 22);
            this.BtnRefresh.Text = "Refresh";
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnToggleDualPanel,
            this.BtnToggleGrid,
            this.BtnFont,
            this.BtnResetFont});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // BtnToggleDualPanel
            // 
            this.BtnToggleDualPanel.Name = "BtnToggleDualPanel";
            this.BtnToggleDualPanel.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.BtnToggleDualPanel.Size = new System.Drawing.Size(205, 22);
            this.BtnToggleDualPanel.Text = "Dual panel toggle";
            this.BtnToggleDualPanel.Click += new System.EventHandler(this.BtnToggleDualPanel_Click);
            // 
            // BtnToggleGrid
            // 
            this.BtnToggleGrid.Name = "BtnToggleGrid";
            this.BtnToggleGrid.Size = new System.Drawing.Size(205, 22);
            this.BtnToggleGrid.Text = "Grid toggle";
            this.BtnToggleGrid.Click += new System.EventHandler(this.BtnToggleGrid_Click);
            // 
            // BtnFont
            // 
            this.BtnFont.Name = "BtnFont";
            this.BtnFont.Size = new System.Drawing.Size(205, 22);
            this.BtnFont.Text = "Font...";
            this.BtnFont.Click += new System.EventHandler(this.BtnFont_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // LeftPanel
            // 
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.RootPath = null;
            this.LeftPanel.Size = new System.Drawing.Size(405, 395);
            this.LeftPanel.TabIndex = 0;
            this.LeftPanel.TabStop = false;
            // 
            // RightPanel
            // 
            this.RightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightPanel.Location = new System.Drawing.Point(0, 0);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.RootPath = null;
            this.RightPanel.Size = new System.Drawing.Size(424, 395);
            this.RightPanel.TabIndex = 0;
            this.RightPanel.TabStop = false;
            // 
            // BtnResetFont
            // 
            this.BtnResetFont.Name = "BtnResetFont";
            this.BtnResetFont.Size = new System.Drawing.Size(205, 22);
            this.BtnResetFont.Text = "Reset default font";
            this.BtnResetFont.Click += new System.EventHandler(this.BtnResetFont_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 441);
            this.Controls.Add(this.RootPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mini Explorer";
            this.RootPanel.ResumeLayout(false);
            this.RootPanel.PerformLayout();
            this.ContentPanel.ResumeLayout(false);
            this.SplitContainer.Panel1.ResumeLayout(false);
            this.SplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).EndInit();
            this.SplitContainer.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel RootPanel;
        private System.Windows.Forms.StatusStrip MainStatusBar;
        private System.Windows.Forms.Panel ContentPanel;
        private System.Windows.Forms.SplitContainer SplitContainer;
        private ExplorerPanel LeftPanel;
        private ExplorerPanel RightPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BtnExit;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BtnFont;
        private System.Windows.Forms.ToolStripMenuItem BtnToggleDualPanel;
        private System.Windows.Forms.ToolStripMenuItem BtnToggleGrid;
        private System.Windows.Forms.ToolStripMenuItem BtnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem BtnResetFont;
    }
}

