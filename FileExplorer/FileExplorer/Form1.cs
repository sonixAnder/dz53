using System;
using System.IO;
using System.Windows.Forms;

namespace FileExplorer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeListView();
            InitializeFileExplorer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.listView1 = new System.Windows.Forms.ListView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();

            this.InitializeListView();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void InitializeListView()
        {
            listView1.View = View.Details;
            listView1.Columns.Add("Имя", 300);

            ImageList imageList = new ImageList();
            imageList.Images.Add("folder", Properties.Resources.folder);
            imageList.Images.Add("file", Properties.Resources.file);

            listView1.LargeImageList = imageList;
        }

        private void LoadFilesAndFolders(string path)
        {
            listView1.Items.Clear();
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);

                foreach (var directory in directoryInfo.GetDirectories())
                {
                    ListViewItem dirItem = new ListViewItem(directory.Name);
                    dirItem.Tag = directory.FullName;
                    dirItem.ImageIndex = 0;
                    listView1.Items.Add(dirItem);
                }

                foreach (var file in directoryInfo.GetFiles())
                {
                    ListViewItem fileItem = new ListViewItem(file.Name);
                    fileItem.Tag = file.FullName;
                    fileItem.ImageIndex = 1;
                    listView1.Items.Add(fileItem);
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Нет доступа к папке.");
            }
        }


        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string path = e.Node.Tag.ToString();
            LoadFilesAndFolders(path);
        }

        private void InitializeFileExplorer()
        {
            treeView1.Nodes.Clear();

            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady)
                {
                    TreeNode driveNode = new TreeNode(drive.Name);
                    driveNode.Tag = drive.Name;
                    treeView1.Nodes.Add(driveNode);

                    LoadDirectories(drive.Name, driveNode);
                }
            }
        }

        private void LoadDirectories(string path, TreeNode node)
        {
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);

                foreach (var directory in directoryInfo.GetDirectories())
                {
                    TreeNode dirNode = new TreeNode(directory.Name);
                    dirNode.Tag = directory.FullName;
                    node.Nodes.Add(dirNode);
                    dirNode.Nodes.Add(new TreeNode());
                }
            }
            catch (UnauthorizedAccessException)
            {

            }
        }
    }
}
