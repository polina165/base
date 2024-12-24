namespace BD
{
    partial class Brands
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewBrands = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonFind = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonAdd2 = new System.Windows.Forms.Button();
            this.buttonSave2 = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.advancedDataGridViewBrandsShops = new Zuby.ADGV.AdvancedDataGridView();
            this.buttonExit = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBrands)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewBrandsShops)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(51, 374);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Список поставщиков магазинов";
            // 
            // dataGridViewBrands
            // 
            this.dataGridViewBrands.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBrands.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewBrands.Location = new System.Drawing.Point(55, 130);
            this.dataGridViewBrands.Name = "dataGridViewBrands";
            this.dataGridViewBrands.RowHeadersWidth = 51;
            this.dataGridViewBrands.RowTemplate.Height = 24;
            this.dataGridViewBrands.Size = new System.Drawing.Size(711, 220);
            this.dataGridViewBrands.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(51, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Бренды";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(55, 92);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(422, 22);
            this.textBox1.TabIndex = 4;
            // 
            // buttonFind
            // 
            this.buttonFind.Location = new System.Drawing.Point(495, 89);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(99, 28);
            this.buttonFind.TabIndex = 5;
            this.buttonFind.Text = "Найти";
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(52, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(239, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Поиск по названию бренда";
            // 
            // buttonAdd2
            // 
            this.buttonAdd2.Location = new System.Drawing.Point(787, 482);
            this.buttonAdd2.Name = "buttonAdd2";
            this.buttonAdd2.Size = new System.Drawing.Size(112, 35);
            this.buttonAdd2.TabIndex = 10;
            this.buttonAdd2.Text = "Добавить";
            this.buttonAdd2.UseVisualStyleBackColor = true;
            this.buttonAdd2.Click += new System.EventHandler(this.buttonAdd2_Click);
            // 
            // buttonSave2
            // 
            this.buttonSave2.Location = new System.Drawing.Point(787, 585);
            this.buttonSave2.Name = "buttonSave2";
            this.buttonSave2.Size = new System.Drawing.Size(112, 35);
            this.buttonSave2.TabIndex = 11;
            this.buttonSave2.Text = "Сохранить";
            this.buttonSave2.UseVisualStyleBackColor = true;
            this.buttonSave2.Click += new System.EventHandler(this.buttonSave2_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(787, 533);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(112, 35);
            this.buttonDelete.TabIndex = 12;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(787, 637);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(112, 35);
            this.buttonUpdate.TabIndex = 13;
            this.buttonUpdate.Text = "Обновить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // advancedDataGridViewBrandsShops
            // 
            this.advancedDataGridViewBrandsShops.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.advancedDataGridViewBrandsShops.DefaultCellStyle = dataGridViewCellStyle2;
            this.advancedDataGridViewBrandsShops.FilterAndSortEnabled = true;
            this.advancedDataGridViewBrandsShops.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.advancedDataGridViewBrandsShops.Location = new System.Drawing.Point(55, 417);
            this.advancedDataGridViewBrandsShops.MaxFilterButtonImageHeight = 23;
            this.advancedDataGridViewBrandsShops.Name = "advancedDataGridViewBrandsShops";
            this.advancedDataGridViewBrandsShops.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advancedDataGridViewBrandsShops.RowHeadersWidth = 51;
            this.advancedDataGridViewBrandsShops.RowTemplate.Height = 24;
            this.advancedDataGridViewBrandsShops.Size = new System.Drawing.Size(711, 302);
            this.advancedDataGridViewBrandsShops.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.advancedDataGridViewBrandsShops.TabIndex = 15;
            this.advancedDataGridViewBrandsShops.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.advancedDataGridViewBrandsShops_CellDoubleClick);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(911, 766);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(112, 35);
            this.buttonExit.TabIndex = 16;
            this.buttonExit.Text = "Выход";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(463, 751);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(289, 24);
            this.comboBox1.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(466, 732);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "Список магазинов";
            // 
            // Brands
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 802);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.advancedDataGridViewBrandsShops);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonSave2);
            this.Controls.Add(this.buttonAdd2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonFind);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewBrands);
            this.Name = "Brands";
            this.Text = "Бренды";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBrands)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewBrandsShops)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewBrands;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonAdd2;
        private System.Windows.Forms.Button buttonSave2;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonUpdate;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridViewBrandsShops;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
    }
}