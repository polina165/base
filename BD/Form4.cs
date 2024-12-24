using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BD
{
    public partial class Items : Form
    {
        private UserCredentials credentials1;
        FbConnectionStringBuilder fb_cons;
        FbConnection fbCon;
        FbDataAdapter adapter;
        FbCommandBuilder commandBuilder;
        DataSet ds;
        string sql = "SELECT * FROM ITEMS";
        public Items(UserCredentials credentials)
        {
            InitializeComponent();
            credentials1 = credentials;

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            string login = credentials1.UserId;
            string password = credentials1.Password;
            advancedDataGridViewitems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            advancedDataGridViewitems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            advancedDataGridViewitems.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            advancedDataGridViewitems.AllowUserToAddRows = false;
            advancedDataGridViewitems.EditMode = DataGridViewEditMode.EditProgrammatically;

            fb_cons = new FbConnectionStringBuilder
            {
                DataSource = "localhost",
                Port = 3050,
                Role = "",
                Dialect = 3,
                Charset = "WIN1251",
                UserID = login,
                Password = password,
                Database = @"D:\datebase\BD.fdb" 
            };

            using (fbCon = new FbConnection(fb_cons.ToString()))
            {
                adapter = new FbDataAdapter(sql, fbCon);
                ds = new DataSet();
                adapter.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    advancedDataGridViewitems.DataSource = ds.Tables[0];
                    advancedDataGridViewitems.Columns["Items_id"].Visible = false;
                    advancedDataGridViewitems.Columns[1].HeaderText = "Наименование товара";
                    advancedDataGridViewitems.Columns[1].Width = 250;
                    advancedDataGridViewitems.Columns[2].HeaderText = "Категория";
                    advancedDataGridViewitems.Columns[3].HeaderText = "Вес";
                    advancedDataGridViewitems.Columns[4].HeaderText = "Цена";
                    advancedDataGridViewitems.Columns[5].HeaderText = "Цена с НДС";
                    advancedDataGridViewitems.Columns[5].ReadOnly = true;
                }

            }
        }
       
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables[0].NewRow();
            ds.Tables[0].Rows.Add(row);
            advancedDataGridViewitems.Refresh();
            int newRowIndex = ds.Tables[0].Rows.Count - 1;
            advancedDataGridViewitems.CurrentCell = advancedDataGridViewitems.Rows[newRowIndex].Cells[1];
            advancedDataGridViewitems.Rows[newRowIndex].Selected = true;
            advancedDataGridViewitems.FirstDisplayedScrollingRowIndex = newRowIndex;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            using (fbCon = new FbConnection(fb_cons.ToString()))
            {
                fbCon.Open();

                foreach (DataGridViewRow row in advancedDataGridViewitems.SelectedRows)
                { 
                    var item = row.Cells["items_id"].Value;
                    string query1 = "DELETE FROM items WHERE items_id=@item ";
                    using (var command = new FbCommand(query1, fbCon))
                    {
                        command.Parameters.AddWithValue("@item", item);
                        command.ExecuteNonQuery();
                    }
                    advancedDataGridViewitems.Rows.Remove(row);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (advancedDataGridViewitems.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для сохранения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                fbCon.Open();
                adapter = new FbDataAdapter(sql, fbCon);
                commandBuilder = new FbCommandBuilder(adapter);
                adapter.InsertCommand = new FbCommand("ITEMS1", fbCon);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new FbParameter("@items_name", FbDbType.VarChar, 255, "items_name"));
                adapter.InsertCommand.Parameters.Add(new FbParameter("@category", FbDbType.VarChar, 50, "category"));
                adapter.InsertCommand.Parameters.Add(new FbParameter("@weight", FbDbType.Decimal, 0, "weight"));
                adapter.InsertCommand.Parameters.Add(new FbParameter("@price", FbDbType.Decimal, 0, "price"));
                adapter.Update(ds);
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                if (fbCon.State == ConnectionState.Open)
                {
                    fbCon.Close();
                }
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            using (fbCon = new FbConnection(fb_cons.ToString()))
            {
                adapter = new FbDataAdapter(sql, fbCon);
                ds = new DataSet();
                adapter.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    advancedDataGridViewitems.DataSource = ds.Tables[0];
                }
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            fbCon.Open();
            string selectString = "items_name Like '%" + textBox1.Text.Trim() + "%'";
            DataRowCollection allRows = ((DataTable)advancedDataGridViewitems.DataSource).Rows;
            DataRow[] searchedRows = ((DataTable)advancedDataGridViewitems.DataSource).Select(selectString);
            if (searchedRows.Length > 0)
            {
                int rowIndex = allRows.IndexOf(searchedRows[0]);
                advancedDataGridViewitems.CurrentCell = advancedDataGridViewitems[1, rowIndex];
            }
            else
            {
                MessageBox.Show("Значения не найдено.", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            fbCon.Close();
        }

        private void advancedDataGridViewitems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            DataGridViewCell currentCell = advancedDataGridViewitems.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (currentCell.IsInEditMode) return;
            try
            {
                advancedDataGridViewitems.BeginEdit(true);
                currentCell.Selected = true;
                advancedDataGridViewitems.CurrentCell = currentCell;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при начале редактирования: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
