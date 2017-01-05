namespace DAMetaDataViewer
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.metaDataList = new System.Windows.Forms.ListBox();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.metaDataTreeView = new System.Windows.Forms.TreeView();
            this.menuStrip1.SuspendLayout();
            this.leftPanel.SuspendLayout();
            this.rightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(640, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openDirectoryToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openDirectoryToolStripMenuItem
            // 
            this.openDirectoryToolStripMenuItem.Name = "openDirectoryToolStripMenuItem";
            this.openDirectoryToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openDirectoryToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.openDirectoryToolStripMenuItem.Text = "&Open Directory...";
            this.openDirectoryToolStripMenuItem.Click += new System.EventHandler(this.openDirectoryToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(203, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // leftPanel
            // 
            this.leftPanel.Controls.Add(this.metaDataList);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 24);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(129, 456);
            this.leftPanel.TabIndex = 1;
            // 
            // metaDataList
            // 
            this.metaDataList.DisplayMember = "FileName";
            this.metaDataList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metaDataList.FormattingEnabled = true;
            this.metaDataList.IntegralHeight = false;
            this.metaDataList.Location = new System.Drawing.Point(0, 0);
            this.metaDataList.Name = "metaDataList";
            this.metaDataList.Size = new System.Drawing.Size(129, 456);
            this.metaDataList.TabIndex = 0;
            this.metaDataList.SelectedIndexChanged += new System.EventHandler(this.metaDataList_SelectedIndexChanged);
            // 
            // rightPanel
            // 
            this.rightPanel.Controls.Add(this.metaDataTreeView);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightPanel.Location = new System.Drawing.Point(129, 24);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(511, 456);
            this.rightPanel.TabIndex = 2;
            // 
            // metaDataTreeView
            // 
            this.metaDataTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metaDataTreeView.Location = new System.Drawing.Point(0, 0);
            this.metaDataTreeView.Name = "metaDataTreeView";
            this.metaDataTreeView.Size = new System.Drawing.Size(511, 456);
            this.metaDataTreeView.TabIndex = 0;
            this.metaDataTreeView.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.metaDataTreeView_AfterCollapse);
            this.metaDataTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.metaDataTreeView_BeforeExpand);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 480);
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.leftPanel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DA Metadata Viewer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.leftPanel.ResumeLayout(false);
            this.rightPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.ListBox metaDataList;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.TreeView metaDataTreeView;
    }
}

