using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace adding_elements
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddTopLevelMenu_Click(object sender, EventArgs e)
        {
            string topLevelMenuName = TopLevelMenu.Text.Trim();
            if (string.IsNullOrEmpty(topLevelMenuName))
            {
                MessageBox.Show("Введите имя для пункта верхнего уровня.");
                return;
            }

            ToolStripMenuItem topLevelItem = new ToolStripMenuItem(topLevelMenuName);
            menuStrip1.Items.Add(topLevelItem);
        }

        private void btnAddSubItem_Click(object sender, EventArgs e)
        {
            if (menuStrip1.Items.Count == 0)
            {
                MessageBox.Show("Сначала добавьте пункт верхнего уровня.");
                return;
            }

            string subItemName = SubItem.Text.Trim();
            if (string.IsNullOrEmpty(subItemName))
            {
                MessageBox.Show("Введите имя для подменю.");
                return;
            }

            ToolStripMenuItem topLevelItem = (ToolStripMenuItem)menuStrip1.Items[menuStrip1.Items.Count - 1];

            ToolStripMenuItem subItem = new ToolStripMenuItem(subItemName);
            topLevelItem.DropDownItems.Add(subItem);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
