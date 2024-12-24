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
using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Services;

namespace BD
{
    public partial class Form6 : Form
    {
        private UserCredentials credentials1;
        FbConnectionStringBuilder fb_cons;
        FbConnection fbCon;
        FbDataAdapter adapter;
        DataSet ds;
        string sql1 = @"SELECT s.date_id,s.brands_id,s.brands_name,s.chains_name,s.shops_code,s.items_id, s.items_name,s.category, s.cost_price, s.sales_items,s.sales_value, bs.city,bs.address
                       FROM sales s
                       LEFT JOIN shops bs ON s.shops_code = bs.shops_code";
        public Form6(UserCredentials credentials)
        {
            InitializeComponent(); 
            credentials1 = credentials;
            LoadComboBoxData();
            LoadComboBoxData2();
            
        }
       
        private void Form6_Load(object sender, EventArgs e) { 
        {
            string login = credentials1.UserId;
            string password = credentials1.Password;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
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
                adapter = new FbDataAdapter(sql1, fbCon);
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
                        dataGridView1.DataSource = dataTable;
                        dataGridView1.DataSource = ds.Tables[0];
                        dataGridView1.Columns[0].HeaderText = "Дата";
                        dataGridView1.Columns[2].HeaderText = "Бренд";
                        dataGridView1.Columns[6].HeaderText = "Наименование товара";
                        dataGridView1.Columns[9].HeaderText = "Количество штук";
                        dataGridView1.Columns["Chains_name"].Visible = false;
                        dataGridView1.Columns["Shops_code"].Visible = false;
                        dataGridView1.Columns["City"].Visible = false;
                        dataGridView1.Columns["Address"].Visible = false;
                        dataGridView1.Columns["Brands_id"].Visible = false;
                        dataGridView1.Columns["Items_id"].Visible = false;
                        dataGridView1.Columns["Category"].Visible = false;
                        dataGridView1.Columns["Cost_price"].Visible = false;
                        dataGridView1.Columns["Sales_value"].Visible = false;
                        dataGridView1.Columns["Магазин"].DisplayIndex = 3;
                        dataGridView1.Columns[4].Width = 200;
                    }    
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

                            comboBox2.DataSource = items;
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
                            comboBox1.DataSource = shops;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                fbCon.Open();
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0]; 
                    if (!selectedRow.IsNewRow)
                    {
                        DateTime data;
                        if (!DateTime.TryParse(selectedRow.Cells["Date_id"].Value?.ToString(), out data))
                        {
                            MessageBox.Show("Invalid date format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string brands = selectedRow.Cells["Brands_name"].Value?.ToString();
                        string items = selectedRow.Cells["Items_name"].Value?.ToString();
                        int count;

                        if (!int.TryParse(selectedRow.Cells["Sales_items"].Value?.ToString(), out count))
                        {
                            MessageBox.Show("Invalid count format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

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
                             using (FbCommand command = new FbCommand("UPSERT_SALES1", fbCon))
                            {

                               command.CommandType = CommandType.StoredProcedure;
                               command.Parameters.AddWithValue("date_id", data);
                               command.Parameters.AddWithValue("brands_name", brands);
                               command.Parameters.AddWithValue("chains_name", chainName);
                               command.Parameters.AddWithValue("shops_code", shopsCode.Value);
                               command.Parameters.AddWithValue("items_name", items);
                               command.Parameters.AddWithValue("sales_items", count);
                               command.ExecuteNonQuery();
                        }

                     DialogResult result = MessageBox.Show("Данные успешно сохранены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                             if (result == DialogResult.OK)
                           {
                          this.Close(); 
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

        private void button2_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables[0].NewRow();
            ds.Tables[0].Rows.Add(row);
            dataGridView1.Refresh();
            int newRowIndex = ds.Tables[0].Rows.Count - 1;
            dataGridView1.CurrentCell = dataGridView1.Rows[newRowIndex].Cells[0];
            dataGridView1.Rows[newRowIndex].Selected = true;
            dataGridView1.FirstDisplayedScrollingRowIndex = newRowIndex;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            DataGridViewCell currentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (currentCell.IsInEditMode) return;
            try
            {
                dataGridView1.BeginEdit(true);
                currentCell.Selected = true;
                dataGridView1.CurrentCell = currentCell;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при начале редактирования: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }

}
