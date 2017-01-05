using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

namespace DAMetaDataViewer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void openDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Dark Ages metafile directory";

                string programFiles;
                if (Environment.Is64BitOperatingSystem)
                {
                    programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
                }
                else
                {
                    programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
                }

                dialog.SelectedPath = Path.Combine(programFiles, "KRU", "Dark Ages", "metafile");

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    OpenDirectory(dialog.SelectedPath);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void metaDataList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listItem = (MetaDataListItem)metaDataList.SelectedItem;
            var metaData = listItem.MetaData;

            var nodes = new TreeNode[metaData.Elements.Count];

            for (int i = 0; i < nodes.Length; ++i)
            {
                var element = metaData.Elements[i];
                var node = new TreeNode(element.Text);
                node.Tag = element;
                if (element.Values.Count > 0)
                {
                    node.Nodes.Add("");
                }
                nodes[i] = node;
            }

            metaDataTreeView.BeginUpdate();
            metaDataTreeView.Nodes.Clear();
            metaDataTreeView.Nodes.AddRange(nodes);
            metaDataTreeView.EndUpdate();
            
            Text = $"DA Metadata Viewer - {listItem.FileName} ({metaData.Elements.Count} elements)";
        }

        private void metaDataTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            var element = (MetaDataElement)e.Node.Tag;

            e.Node.Nodes.Clear();

            foreach (var value in element.Values)
            {
                e.Node.Nodes.Add(value);
            }
        }

        private void metaDataTreeView_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            e.Node.Nodes.Clear();
            e.Node.Nodes.Add("");
        }

        private void OpenDirectory(string path)
        {
            var items = new List<MetaDataListItem>();

            foreach (string fileName in Directory.GetFiles(path))
            {
                MetaData metaData;

                using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    if (fileStream.ReadByte() == 0x78 && fileStream.ReadByte() == 0x9C)
                    {
                        using (var decompressedStream = new MemoryStream())
                        using (var decompressionStream = new DeflateStream(fileStream, CompressionMode.Decompress))
                        {
                            decompressionStream.CopyTo(decompressedStream);
                            decompressedStream.Seek(0, SeekOrigin.Begin);
                            metaData = new MetaData(decompressedStream);
                        }
                    }
                    else
                    {
                        fileStream.Seek(0, SeekOrigin.Begin);
                        metaData = new MetaData(fileStream);
                    }
                }

                items.Add(new MetaDataListItem(Path.GetFileName(fileName), metaData));
            }

            metaDataList.BeginUpdate();
            metaDataList.Items.Clear();
            metaDataList.Items.AddRange(items.ToArray());
            metaDataList.EndUpdate();

            if (metaDataList.Items.Count > 0)
            {
                metaDataList.SelectedIndex = 0;
            }
        }

        class MetaDataListItem
        {
            private string _fileName;
            private MetaData _metaData;

            public MetaDataListItem(string fileName, MetaData metaData)
            {
                _fileName = fileName;
                _metaData = metaData;
            }

            public string FileName
            {
                get
                {
                    return _fileName;
                }
            }

            public MetaData MetaData
            {
                get
                {
                    return _metaData;
                }
            }
        }
    }
}
