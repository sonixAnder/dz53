using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Remoting.Contexts;
//программа работает, файл сохраняет но пустые, так-же и при открытии и я не знаю как это исправить, контекстное меню тоже не вызывается :(
namespace TextEditor
{
    public partial class Form1 : Form
    {
        private RichTextBox richTextBox;
        private string currentFilePath = string.Empty;
        private ContextMenuStrip contextMenu;

        public Form1()
        {
            InitializeComponent();

            richTextBoxMain = new RichTextBox
            {
                Dock = DockStyle.Fill,
                Name = "richTextBoxMain"
            };
            this.Controls.Add(richTextBoxMain);

            richTextBoxMain.MouseDown += RichTextBoxMain_MouseDown;
            // Инициализация контекстного меню
            InitializeContextMenu();

            this.Text = "Текстовый редактор";
            richTextBoxMain = new RichTextBox { Dock = DockStyle.Fill };
            this.Controls.Add(richTextBox);

            var menuStrip = new MenuStrip();

            var fileMenu = new ToolStripMenuItem("Файл");
            var openMenuItem = new ToolStripMenuItem("Открыть", null, OpenFile) { Name = "openMenuItem" };
            var saveMenuItem = new ToolStripMenuItem("Сохранить", null, SaveFile) { Name = "saveMenuItem" };
            
            var newMenuItem = new ToolStripMenuItem("Новый", null, NewFile) { Name = "newMenuItem" };
            fileMenu.DropDownItems.AddRange(new[] { openMenuItem, saveMenuItem, newMenuItem });

            var editMenu = new ToolStripMenuItem("Редактирование");
            var copyMenuItem = new ToolStripMenuItem("Копировать", null, (s, e) => richTextBoxMain.Copy()) { Name = "copyMenuItem" };
            var cutMenuItem = new ToolStripMenuItem("Вырезать", null, (s, e) => richTextBoxMain.Cut()) { Name = "cutMenuItem" };
            var pasteMenuItem = new ToolStripMenuItem("Вставить", null, (s, e) => richTextBoxMain.Paste()) { Name = "pasteMenuItem" };
            var undoMenuItem = new ToolStripMenuItem("Отменить", null, (s, e) => richTextBoxMain.Undo()) { Name = "undoMenuItem" };
            var selectAllMenuItem = new ToolStripMenuItem("Выделить все", null, (s, e) => richTextBoxMain.SelectAll()) { Name = "selectAllMenuItem" };
            editMenu.DropDownItems.AddRange(new[] { copyMenuItem, cutMenuItem, pasteMenuItem, undoMenuItem, selectAllMenuItem });

            var settingsMenu = new ToolStripMenuItem("Настройки");
            var fontMenuItem = new ToolStripMenuItem("Шрифт", null, ChangeFont) { Name = "fontMenuItem" };
            var backgroundColorMenuItem = new ToolStripMenuItem("Цвет фона", null, ChangeBackgroundColor) { Name = "backgroundColorMenuItem" };
            settingsMenu.DropDownItems.AddRange(new[] { fontMenuItem, backgroundColorMenuItem });

            menuStrip.Items.AddRange(new[] { fileMenu, editMenu, settingsMenu });
            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);

            var contextMenuStrip1 = new ContextMenuStrip();
            contextMenuStrip1.Items.Add("Копировать", null, (s, e) => richTextBoxMain.Copy());
            contextMenuStrip1.Items.Add("Вырезать", null, (s, e) => richTextBoxMain.Cut());
            contextMenuStrip1.Items.Add("Вставить", null, (s, e) => richTextBoxMain.Paste());
            contextMenuStrip1.Items.Add("Отменить", null, (s, e) => richTextBoxMain.Undo());
            richTextBoxMain.ContextMenuStrip = contextMenuStrip1;
        }

        private void NewFile(object sender, EventArgs e)
        {
            richTextBoxMain.Clear();
            currentFilePath = string.Empty;
            this.Text = "Новый документ - Текстовый редактор";
        }

        private void OpenFile(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Text Files (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf|All Files (*.*)|*.*";
                    openFileDialog.Title = "Открыть файл";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;

                        if (filePath.EndsWith(".rtf"))
                        {
                            richTextBoxMain.LoadFile(filePath, RichTextBoxStreamType.RichText);
                        }
                        else
                        {
                            richTextBoxMain.Text = File.ReadAllText(filePath);
                        }

                        this.Text = $"Текстовый редактор - {filePath}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SaveFile(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Text Files (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf|All Files (*.*)|*.*";
                    saveFileDialog.Title = "Сохранить файл как";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;

                        if (filePath.EndsWith(".rtf"))
                        {
                            richTextBoxMain.SaveFile(filePath, RichTextBoxStreamType.RichText);
                        }
                        else
                        {
                            File.WriteAllText(filePath, richTextBoxMain.Text);
                        }

                        this.Text = $"Текстовый редактор - {filePath}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChangeFont(object sender, EventArgs e)
        {
            using (var fontDialog = new FontDialog())
            {
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBoxMain.Font = fontDialog.Font;
                }
            }
        }

        private void ChangeBackgroundColor(object sender, EventArgs e)
        {
            using (var colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBoxMain.BackColor = colorDialog.Color;
                }
            }
        }
        private void InitializeContextMenu()
        {
            contextMenu = new ContextMenuStrip();

            contextMenu.Items.Add("Копировать", null, CopyText);
            contextMenu.Items.Add("Вырезать", null, CutText);
            contextMenu.Items.Add("Вставить", null, PasteText);
            contextMenu.Items.Add("Отменить", null, UndoAction);

            richTextBoxMain.ContextMenuStrip = contextMenu;
        }
        private void RichTextBoxMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenu.Show(Cursor.Position);
            }
        }
        private void CopyText(object sender, EventArgs e)
        {
            if (richTextBoxMain.SelectedText.Length > 0)
            {
                Clipboard.SetText(richTextBoxMain.SelectedText);
            }
        }

        private void CutText(object sender, EventArgs e)
        {
            if (richTextBoxMain.SelectedText.Length > 0)
            {
                Clipboard.SetText(richTextBoxMain.SelectedText);
                richTextBoxMain.SelectedText = string.Empty;
            }
        }

        private void PasteText(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                int selectionStart = richTextBoxMain.SelectionStart;
                richTextBoxMain.Text = richTextBoxMain.Text.Insert(selectionStart, Clipboard.GetText());
            }
        }

        private void UndoAction(object sender, EventArgs e)
        {
            if (richTextBoxMain.CanUndo)
            {
                richTextBoxMain.Undo();
            }
        }
    }
}
