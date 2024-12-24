namespace BD
{
    partial class Items
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.advancedDataGridViewitems = new Zuby.ADGV.AdvancedDataGridView();
            this.buttonExit = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonFind = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewitems)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(44, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Справочник продуктов";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(49, 543);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(113, 35);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(168, 543);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(113, 35);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(287, 543);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(113, 35);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(406, 543);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(113, 35);
            this.buttonUpdate.TabIndex = 5;
            this.buttonUpdate.Text = "Обновить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // advancedDataGridViewitems
            // 
            this.advancedDataGridViewitems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.advancedDataGridViewitems.DefaultCellStyle = dataGridViewCellStyle1;
            this.advancedDataGridViewitems.FilterAndSortEnabled = true;
            this.advancedDataGridViewitems.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.advancedDataGridViewitems.Location = new System.Drawing.Point(49, 114);
            this.advancedDataGridViewitems.MaxFilterButtonImageHeight = 23;
            this.advancedDataGridViewitems.Name = "advancedDataGridViewitems";
            this.advancedDataGridViewitems.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advancedDataGridViewitems.RowHeadersWidth = 51;
            this.advancedDataGridViewitems.RowTemplate.Height = 24;
            this.advancedDataGridViewitems.Size = new System.Drawing.Size(843, 407);
            this.advancedDataGridViewitems.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.advancedDataGridViewitems.TabIndex = 6;
            this.advancedDataGridViewitems.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.advancedDataGridViewitems_CellDoubleClick);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(929, 568);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(113, 35);
            this.buttonExit.TabIndex = 7;
            this.buttonExit.Text = "Выход";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(49, 77);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(367, 22);
            this.textBox1.TabIndex = 8;
            // 
            // buttonFind
            // 
            this.buttonFind.Location = new System.Drawing.Point(422, 74);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(113, 29);
            this.buttonFind.TabIndex = 9;
            this.buttonFind.Text = "Найти";
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(46, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(196, 18);
            this.label10.TabIndex = 28;
            this.label10.Text = "Поиск по названию товара";
            // 
            // Items
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 603);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.buttonFind);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.advancedDataGridViewitems);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.label1);
            this.Name = "Items";
            this.Text = "Продукты";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewitems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonUpdate;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridViewitems;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.Label label10;
    }
}