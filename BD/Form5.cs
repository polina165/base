using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD
{
    public partial class ItemsShops : Form
    {
        private UserCredentials credentials1;
        FbConnectionStringBuilder fb_cons;
        FbConnection fbCon;
        FbDataAdapter adapter;
        DataSet ds;
        string sql = @"SELECT i.brands_id,i.brands_name, i.chains_name,i.shops_code,i.items_id, i.items_name, bs.city,bs.address
                       FROM ITEMS_SHOPS i
                       LEFT JOIN shops bs ON i.shops_code = bs.shops_code";
        public ItemsShops(UserCredentials credentials)
        {
            InitializeComponent();
            credentials1 = credentials;
            LoadComboBoxData();
            LoadComboBoxData2();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            string login = credentials1.UserId;
            string password = credentials1.Password;
            advancedDataGridViewItemsShops.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            advancedDataGridViewItemsShops.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            advancedDataGridViewItemsShops.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            advancedDataGridViewItemsShops.AllowUserToAddRows = false;
            advancedDataGridViewItemsShops.EditMode = DataGridViewEditMode.EditProgrammatically;
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
                    DataTable dataTable = ds.Tables[0];


                    dataTable.Columns.Add("Магазин", typeof(string));

                    foreach (DataRow row in dataTable.Rows)
                    {
                        string networkName = row["Chains_name"].ToString();
                        string city = row["city"].ToString();
                        string address = row["address"].ToString();


                        string combinedValue = $"{networkName}, {city}, {address}";


                        row["Магазин"] = combinedValue;
                    }
                    advancedDataGridViewItemsShops.DataSource = dataTable;
                    advancedDataGridViewItemsShops.DataSource = ds.Tables[0];
                    advancedDataGridViewItemsShops.Columns["Brands_id"].Visible = false;
                    advancedDataGridViewItemsShops.Columns["Items_id"].Visible = false;
                    advancedDataGridViewItemsShops.Columns["Shops_code"].Visible = false;
                    advancedDataGridViewItemsShops.Columns["City"].Visible = false;
                    advancedDataGridViewItemsShops.Columns["Address"].Visible = false;
                    advancedDataGridViewItemsShops.Columns["Chains_name"].Visible = false;
                    advancedDataGridViewItemsShops.Columns[1].HeaderText = "Бренд";
                    advancedDataGridViewItemsShops.Columns[5].HeaderText = "Наименование товара";
                    advancedDataGridViewItemsShops.Columns[5].Width = 200;
                    advancedDataGridViewItemsShops.Columns[1].Width = 100;
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables[0].NewRow();
            ds.Tables[0].Rows.Add(row);
            advancedDataGridViewItemsShops.Refresh();
            int newRowIndex = ds.Tables[0].Rows.Count - 1;
            advancedDataGridViewItemsShops.CurrentCell = advancedDataGridViewItemsShops.Rows[newRowIndex].Cells[1];
            advancedDataGridViewItemsShops.Rows[newRowIndex].Selected = true;
            advancedDataGridViewItemsShops.FirstDisplayedScrollingRowIndex = newRowIndex;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            using (fbCon = new FbConnection(fb_cons.ToString()))
            {
                fbCon.Open();

                foreach (DataGridViewRow row in advancedDataGridViewItemsShops.SelectedRows)
                {

                    var brand = row.Cells["brands_id"].Value;

                    var shop = row.Cells["shops_code"].Value;
                    var item = row.Cells["items_id"].Value;
                    string query = "DELETE FROM items_shops WHERE brands_id = @brand and shops_code=@shop and items_id=@item";

                    using (var command = new FbCommand(query, fbCon))
                    {
                        command.Parameters.AddWithValue("@brand", brand);
                        command.Parameters.AddWithValue("@shop", shop);
                        command.Parameters.AddWithValue("@item", item);
                        command.ExecuteNonQuery();
                    }

                    advancedDataGridViewItemsShops.Rows.Remove(row);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                fbCon.Open();
                if (advancedDataGridViewItemsShops.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = advancedDataGridViewItemsShops.SelectedRows[0];
                    {
                        string brands = selectedRow.Cells["Brands_name"].Value?.ToString();
                        string items = selectedRow.Cells["Items_name"].Value?.ToString();
                        string combinedColumnValue = selectedRow.Cells["Магазин"].Value?.ToString();
                        string[] parts = combinedColumnValue.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        if (parts.Length >= 3)
                        {
                            string chainName = parts[0].Trim();
                            string city = parts[1].Trim();
                            string address = parts[2].Trim();
                            int? shopsCode = null;
                            using (FbCommand command = new FbCommand("GET_SHOPS_CODE", fbCon))
                            {
                                command.CommandType = CommandType.StoredProcedure;

                                command.Parameters.AddWithValue("chains_name", chainName);
                                command.Parameters.AddWithValue("city", city);
                                command.Parameters.AddWithValue("address", address);

                                FbParameter shopsCodeParam = new FbParameter("shops_code", FbDbType.Integer)
                                {
                                    Direction = ParameterDirection.Output
                                };
                                command.Parameters.Add(shopsCodeParam);

                                command.ExecuteNonQuery();


                                if (shopsCodeParam.Value != DBNull.Value)
                                {
                                    shopsCode = Convert.ToInt32(shopsCodeParam.Value);
                                }
                                else
                                {
                                    MessageBox.Show($"No shops_code found for {chainName}, {city}, {address}.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }

                            if (shopsCode.HasValue)
                            {
                                using (FbCommand command = new FbCommand("ITEMSHOP1", fbCon))
                                {
                                    command.CommandType = CommandType.StoredProcedure;

                                    command.Parameters.AddWithValue("brands_name", brands);
                                    command.Parameters.AddWithValue("chains_name", chainName);
                                    command.Parameters.AddWithValue("shops_code", shopsCode.Value);
                                    command.Parameters.AddWithValue("items_name", items);
                                    command.ExecuteNonQuery();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Недостаточно данных в поле 'Магазин'.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (fbCon.State == System.Data.ConnectionState.Open)
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
                    DataTable dataTable = ds.Tables[0];


                    dataTable.Columns.Add("Магазин", typeof(string));

                    foreach (DataRow row in dataTable.Rows)
                    {
                        string networkName = row["Chains_name"].ToString();
                        string city = row["city"].ToString();
                        string address = row["address"].ToString();
                        string combinedValue = $"{networkName}, {city}, {address}";


                        row["Магазин"] = combinedValue;
                    }
                    advancedDataGridViewItemsShops.DataSource = dataTable;
                    advancedDataGridViewItemsShops.DataSource = ds.Tables[0];
                }
            }
        }
        private void LoadComboBoxData()
        {
            string login = credentials1.UserId;
            string password = credentials1.Password;
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
                try
                {
                    fbCon.Open();

                    string query = "SELECT items_name FROM items";

                    using (FbCommand command = new FbCommand(query, fbCon))
                    {
                        using (FbDataReader reader = command.ExecuteReader())
                        {
                            List<string> items = new List<string>();

                            while (reader.Read())
                            {
                                items.Add(reader["items_name"].ToString());
                            }

                            comboBox1.DataSource = items;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }
        private void LoadComboBoxData2()
        {
            string login = credentials1.UserId;
            string password = credentials1.Password;
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
                try
                {
                    fbCon.Open();

                    string query = "SELECT chains_name, city, address FROM shops";

                    using (FbCommand command = new FbCommand(query, fbCon))
                    {
                        using (FbDataReader reader = command.ExecuteReader())
                        {
                            List<string> shops = new List<string>();

                            while (reader.Read())
                            {

                                string combinedValue = $"{reader["Chains_name"]}, {reader["city"]}, {reader["address"]}";
                                shops.Add(combinedValue);
                            }

                            comboBox2.DataSource = shops;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
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
            DataRowCollection allRows = ((DataTable)advancedDataGridViewItemsShops.DataSource).Rows;
            DataRow[] searchedRows = ((DataTable)advancedDataGridViewItemsShops.DataSource).Select(selectString);
            if (searchedRows.Length > 0)
            {
                int rowIndex = allRows.IndexOf(searchedRows[0]);
                advancedDataGridViewItemsShops.CurrentCell = advancedDataGridViewItemsShops[1, rowIndex];
            }
            else
            {
                MessageBox.Show("Значения не найдено.", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            fbCon.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (fbCon = new FbConnection(fb_cons.ToString()))
            {
                fbCon.Open();

               
                string id = advancedDataGridViewItemsShops.SelectedRows[0].Cells["brands_id"].Value.ToString(); 
                string newName = advancedDataGridViewItemsShops.SelectedRows[0].Cells["items_id"].Value.ToString();


                string updateSql = $"UPDATE items_shops SET name = '{newName}' WHERE id = {id}"; 

                using (FbCommand command = new FbCommand(updateSql, fbCon))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Данные успешно обновлены!");
                    }
                    catch (FbException ex)
                    {
                        MessageBox.Show($"Ошибка обновления данных: {ex.Message}");
                    }
                }
            }
        }

        private void advancedDataGridViewItemsShops_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            DataGridViewCell currentCell = advancedDataGridViewItemsShops.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (currentCell.IsInEditMode) return;
            try
            {
                advancedDataGridViewItemsShops.BeginEdit(true);
                currentCell.Selected = true;
                advancedDataGridViewItemsShops.CurrentCell = currentCell;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при начале редактирования: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    }

