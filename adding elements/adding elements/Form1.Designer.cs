namespace adding_elements
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.TopLevelMenu = new System.Windows.Forms.TextBox();
            this.SubItem = new System.Windows.Forms.TextBox();
            this.btnAddTopLevelMenu = new System.Windows.Forms.Button();
            this.btnAddSubItem = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TopLevelMenu
            // 
            this.TopLevelMenu.Location = new System.Drawing.Point(11, 48);
            this.TopLevelMenu.Name = "TopLevelMenu";
            this.TopLevelMenu.Size = new System.Drawing.Size(100, 20);
            this.TopLevelMenu.TabIndex = 0;
            // 
            // SubItem
            // 
            this.SubItem.Location = new System.Drawing.Point(117, 48);
            this.SubItem.Name = "SubItem";
            this.SubItem.Size = new System.Drawing.Size(100, 20);
            this.SubItem.TabIndex = 1;
            // 
            // btnAddTopLevelMenu
            // 
            this.btnAddTopLevelMenu.Location = new System.Drawing.Point(12, 75);
            this.btnAddTopLevelMenu.Name = "btnAddTopLevelMenu";
            this.btnAddTopLevelMenu.Size = new System.Drawing.Size(99, 59);
            this.btnAddTopLevelMenu.TabIndex = 2;
            this.btnAddTopLevelMenu.Text = "Добавить основную категорию";
            this.btnAddTopLevelMenu.UseVisualStyleBackColor = true;
            this.btnAddTopLevelMenu.Click += new System.EventHandler(this.btnAddTopLevelMenu_Click);
            // 
            // btnAddSubItem
            // 
            this.btnAddSubItem.Location = new System.Drawing.Point(117, 75);
            this.btnAddSubItem.Name = "btnAddSubItem";
            this.btnAddSubItem.Size = new System.Drawing.Size(100, 59);
            this.btnAddSubItem.TabIndex = 3;
            this.btnAddSubItem.Text = "Добавить доп категорию к основной";
            this.btnAddSubItem.UseVisualStyleBackColor = true;
            this.btnAddSubItem.Click += new System.EventHandler(this.btnAddSubItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(251, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Основное";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Дополнительное";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 169);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddSubItem);
            this.Controls.Add(this.btnAddTopLevelMenu);
            this.Controls.Add(this.SubItem);
            this.Controls.Add(this.TopLevelMenu);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TopLevelMenu;
        private System.Windows.Forms.TextBox SubItem;
        private System.Windows.Forms.Button btnAddTopLevelMenu;
        private System.Windows.Forms.Button btnAddSubItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

