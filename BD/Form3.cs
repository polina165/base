using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD
{
    public partial class Shops : Form
    {
        private UserCredentials credentials1;
        FbConnectionStringBuilder fb_cons;
        FbConnection fbCon;
        FbDataAdapter adapter;
        FbCommandBuilder commandBuilder;
        DataSet ds;
        string sql = @"SELECT s.chains_name,s.shops_code, s.city,s.address
                      FROM SHOPS s
                      GROUP BY s.chains_name,s.shops_code, s.city,s.address";
        public Shops(UserCredentials credentials)
        {
            InitializeComponent();
            credentials1 = credentials;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string login = credentials1.UserId;
            string password = credentials1.Password;
            advancedDataGridViewShops.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            advancedDataGridViewShops.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            advancedDataGridViewShops.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            advancedDataGridViewShops.AllowUserToAddRows = false;
            advancedDataGridViewShops.EditMode = DataGridViewEditMode.EditProgrammatically;

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
                    advancedDataGridViewShops.DataSource = ds.Tables[0];
                    advancedDataGridViewShops.Columns[0].HeaderText = "Название сети магазина";
                    advancedDataGridViewShops.Columns[1].HeaderText = "Код магазина";
                    advancedDataGridViewShops.Columns[2].HeaderText = "Город";
                    advancedDataGridViewShops.Columns[3].HeaderText = "Адрес";
                    advancedDataGridViewShops.Columns[1].ReadOnly = true;
                    advancedDataGridViewShops.Columns["Shops_code"].Visible = false;
                }

            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables[0].NewRow();
            ds.Tables[0].Rows.Add(row);
            advancedDataGridViewShops.Refresh();
            int newRowIndex = ds.Tables[0].Rows.Count - 1;
            advancedDataGridViewShops.CurrentCell = advancedDataGridViewShops.Rows[newRowIndex].Cells[0];
            advancedDataGridViewShops.Rows[newRowIndex].Selected = true;
            advancedDataGridViewShops.FirstDisplayedScrollingRowIndex = newRowIndex;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            using (fbCon = new FbConnection(fb_cons.ToString()))
            {
                fbCon.Open();

                foreach (DataGridViewRow row in advancedDataGridViewShops.SelectedRows)
                {
                    var shop = row.Cells["shops_code"].Value;
                    string query = "DELETE FROM shops WHERE shops_code=@shop ";

                    using (var command = new FbCommand(query, fbCon))
                    {
                        command.Parameters.AddWithValue("@shop", shop);
                        command.ExecuteNonQuery();
                    }

                    advancedDataGridViewShops.Rows.Remove(row);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

            try
            {
                fbCon.Open();
                adapter = new FbDataAdapter(sql, fbCon);
                commandBuilder = new FbCommandBuilder(adapter);
                adapter.InsertCommand = new FbCommand("SHOPS1", fbCon);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new FbParameter("@chains_name", FbDbType.VarChar, 50, "chains_name"));
                adapter.InsertCommand.Parameters.Add(new FbParameter("@city", FbDbType.VarChar, 50, "city"));
                adapter.InsertCommand.Parameters.Add(new FbParameter("@address", FbDbType.VarChar, 255, "address"));
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
                    advancedDataGridViewShops.DataSource = ds.Tables[0];
                }
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void advancedDataGridViewShops_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            DataGridViewCell currentCell = advancedDataGridViewShops.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (currentCell.IsInEditMode) return;
            try
            {
                advancedDataGridViewShops.BeginEdit(true);
                currentCell.Selected = true;
                advancedDataGridViewShops.CurrentCell = currentCell;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при начале редактирования: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
   
    }
