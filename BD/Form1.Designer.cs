namespace BD
{
    partial class Applacation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.advancedDataGridViewSales = new Zuby.ADGV.AdvancedDataGridView();
            this.брендыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.магазиныToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.продуктыToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.поставкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.brandTextBox = new System.Windows.Forms.TextBox();
            this.shopTextBox = new System.Windows.Forms.TextBox();
            this.categoryTextBox = new System.Windows.Forms.TextBox();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Findbutton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewSales)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(20, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Продажи";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(25, 600);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(115, 32);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(146, 600);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(115, 32);
            this.buttonDelete.TabIndex = 4;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(267, 600);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(115, 32);
            this.buttonUpdate.TabIndex = 6;
            this.buttonUpdate.Text = "Обновить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // advancedDataGridViewSales
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.advancedDataGridViewSales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.advancedDataGridViewSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.advancedDataGridViewSales.DefaultCellStyle = dataGridViewCellStyle4;
            this.advancedDataGridViewSales.FilterAndSortEnabled = true;
            this.advancedDataGridViewSales.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.advancedDataGridViewSales.Location = new System.Drawing.Point(25, 147);
            this.advancedDataGridViewSales.MaxFilterButtonImageHeight = 23;
            this.advancedDataGridViewSales.Name = "advancedDataGridViewSales";
            this.advancedDataGridViewSales.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advancedDataGridViewSales.RowHeadersWidth = 51;
            this.advancedDataGridViewSales.RowTemplate.Height = 24;
            this.advancedDataGridViewSales.Size = new System.Drawing.Size(1081, 418);
            this.advancedDataGridViewSales.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.advancedDataGridViewSales.TabIndex = 7;
            this.advancedDataGridViewSales.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.advancedDataGridViewSales_CellMouseDoubleClick);
            // 
            // брендыToolStripMenuItem
            // 
            this.брендыToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.брендыToolStripMenuItem.Checked = true;
            this.брендыToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.брендыToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.брендыToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.брендыToolStripMenuItem.Name = "брендыToolStripMenuItem";
            this.брендыToolStripMenuItem.Size = new System.Drawing.Size(89, 29);
            this.брендыToolStripMenuItem.Text = "Бренды";
            this.брендыToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.брендыToolStripMenuItem.Click += new System.EventHandler(this.брендыToolStripMenuItem_Click_1);
            // 
            // магазиныToolStripMenuItem
            // 
            this.магазиныToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.магазиныToolStripMenuItem.Name = "магазиныToolStripMenuItem";
            this.магазиныToolStripMenuItem.Size = new System.Drawing.Size(108, 29);
            this.магазиныToolStripMenuItem.Text = "Магазины";
            this.магазиныToolStripMenuItem.Click += new System.EventHandler(this.магазиныToolStripMenuItem_Click);
            // 
            // продуктыToolStripMenuItem1
            // 
            this.продуктыToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.продуктыToolStripMenuItem1.Name = "продуктыToolStripMenuItem1";
            this.продуктыToolStripMenuItem1.Size = new System.Drawing.Size(109, 29);
            this.продуктыToolStripMenuItem1.Text = "Продукты";
            this.продуктыToolStripMenuItem1.Click += new System.EventHandler(this.продуктыToolStripMenuItem1_Click);
            // 
            // поставкиToolStripMenuItem
            // 
            this.поставкиToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.поставкиToolStripMenuItem.Name = "поставкиToolStripMenuItem";
            this.поставкиToolStripMenuItem.Size = new System.Drawing.Size(128, 29);
            this.поставкиToolStripMenuItem.Text = "Поставщики";
            this.поставкиToolStripMenuItem.Click += new System.EventHandler(this.поставкиToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.брендыToolStripMenuItem,
            this.магазиныToolStripMenuItem,
            this.продуктыToolStripMenuItem1,
            this.поставкиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1563, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // brandTextBox
            // 
            this.brandTextBox.Location = new System.Drawing.Point(1124, 228);
            this.brandTextBox.Name = "brandTextBox";
            this.brandTextBox.Size = new System.Drawing.Size(194, 22);
            this.brandTextBox.TabIndex = 10;
            // 
            // shopTextBox
            // 
            this.shopTextBox.Location = new System.Drawing.Point(1124, 289);
            this.shopTextBox.Name = "shopTextBox";
            this.shopTextBox.Size = new System.Drawing.Size(194, 22);
            this.shopTextBox.TabIndex = 11;
            // 
            // categoryTextBox
            // 
            this.categoryTextBox.Location = new System.Drawing.Point(1124, 347);
            this.categoryTextBox.Name = "categoryTextBox";
            this.categoryTextBox.Size = new System.Drawing.Size(197, 22);
            this.categoryTextBox.TabIndex = 12;
            // 
            // resultTextBox
            // 
            this.resultTextBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.resultTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultTextBox.Location = new System.Drawing.Point(1124, 458);
            this.resultTextBox.Multiline = true;
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.Size = new System.Drawing.Size(336, 81);
            this.resultTextBox.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1127, 389);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 32);
            this.button1.TabIndex = 14;
            this.button1.Text = "Рассчитать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(1122, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 29);
            this.label2.TabIndex = 15;
            this.label2.Text = "Сводный отчет";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(1124, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 18);
            this.label3.TabIndex = 16;
            this.label3.Text = "Начальная дата";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(1349, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 18);
            this.label4.TabIndex = 17;
            this.label4.Text = "Конечная дата";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(1124, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 18);
            this.label5.TabIndex = 18;
            this.label5.Text = "Название бренда";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(1124, 268);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 18);
            this.label6.TabIndex = 19;
            this.label6.Text = "Название сети магазина";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(1124, 326);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 18);
            this.label7.TabIndex = 20;
            this.label7.Text = "Категория товаров";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(1121, 437);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 18);
            this.label8.TabIndex = 21;
            this.label8.Text = "Результат";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1324, 173);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 16);
            this.label9.TabIndex = 22;
            this.label9.Text = "-";
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(1430, 657);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(115, 32);
            this.buttonExit.TabIndex = 23;
            this.buttonExit.Text = "Выход";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(1248, 389);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(115, 32);
            this.buttonClear.TabIndex = 24;
            this.buttonClear.Text = "Очистить";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(25, 102);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(478, 22);
            this.textBox1.TabIndex = 25;
            // 
            // Findbutton
            // 
            this.Findbutton.Location = new System.Drawing.Point(509, 99);
            this.Findbutton.Name = "Findbutton";
            this.Findbutton.Size = new System.Drawing.Size(115, 29);
            this.Findbutton.TabIndex = 26;
            this.Findbutton.Text = "Найти";
            this.Findbutton.UseVisualStyleBackColor = true;
            this.Findbutton.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(22, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(196, 18);
            this.label10.TabIndex = 27;
            this.label10.Text = "Поиск по названию товара";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1124, 170);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(194, 22);
            this.textBox2.TabIndex = 28;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(1341, 170);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(194, 22);
            this.textBox3.TabIndex = 29;
            // 
            // Applacation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1563, 692);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Findbutton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.categoryTextBox);
            this.Controls.Add(this.shopTextBox);
            this.Controls.Add(this.brandTextBox);
            this.Controls.Add(this.advancedDataGridViewSales);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Applacation";
            this.Text = "Аналитическое агентство";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewSales)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonUpdate;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridViewSales;
        private System.Windows.Forms.ToolStripMenuItem брендыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem магазиныToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem продуктыToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem поставкиToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TextBox brandTextBox;
        private System.Windows.Forms.TextBox shopTextBox;
        private System.Windows.Forms.TextBox categoryTextBox;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Findbutton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
    }
}

