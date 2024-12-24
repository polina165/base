
using FirebirdSql.Data.FirebirdClient;
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
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net;


namespace BD
{
    public partial class Brands : Form
    {
        private UserCredentials credentials1;
        FbConnectionStringBuilder fb_cons;
        FbConnection fbCon;
        FbDataAdapter adapter;
        DataSet ds1;
        DataSet ds2;
        string sql = "SELECT * FROM BRANDS";
        string sql2 = @"SELECT b.brands_id,b.brands_name, b.chains_name,b.shops_code, s.city,s.address
                       FROM BRANDS_SHOPS b
                       LEFT JOIN Shops s ON b.shops_code = s.shops_code";
                     
        public Brands(UserCredentials credentials)
        {
            InitializeComponent();
            credentials1 = credentials;
            LoadComboBoxData();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string login = credentials1.UserId;
            string password = credentials1.Password;
            dataGridViewBrands.AllowUserToAddRows = false;
            dataGridViewBrands.ReadOnly = true;
            dataGridViewBrands.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            advancedDataGridViewBrandsShops.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            advancedDataGridViewBrandsShops.AllowUserToAddRows =false;
            advancedDataGridViewBrandsShops.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            advancedDataGridViewBrandsShops.EditMode = DataGridViewEditMode.EditProgrammatically;
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
                ds1 = new DataSet();
                adapter.Fill(ds1);

                if (ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                {

                    dataGridViewBrands.DataSource = ds1.Tables[0];
                    dataGridViewBrands.Columns[1].HeaderText = "Бренд";
                    dataGridViewBrands.Columns["Brands_id"].Visible = false;

                    if (dataGridViewBrands.Columns["BRANDS_LOGOTYPE"] != null)
                    {
                        dataGridViewBrands.Columns.Remove("BRANDS_LOGOTYPE");
                    }

                    DataGridViewImageColumn imageColumn = new DataGridViewImageColumn
                    {
                        Name = "BRANDS_LOGOTYPE",
                        HeaderText = "Логотип бренда",
                        ImageLayout = DataGridViewImageCellLayout.Normal
                    };
                    dataGridViewBrands.Columns.Add(imageColumn);

                    foreach (DataRow row in ds1.Tables[0].Rows)
                    {
                        string imagePath = row["BRANDS_LOGOTYPE"].ToString();

                        if (File.Exists(imagePath))
                        {
                            Image img = Image.FromFile(imagePath);
                            int rowIndex = row.Table.Rows.IndexOf(row);
                            Image resizedImage = ResizeImage(img, 90, 80);
                            dataGridViewBrands.Rows[rowIndex].Cells["BRANDS_LOGOTYPE"].Value = resizedImage;
                        }
                        else
                        {
                            dataGridViewBrands.Rows[row.Table.Rows.IndexOf(row)].Cells["BRANDS_LOGOTYPE"].Value = null;
                        }
                    }


                    foreach (DataGridViewRow row in dataGridViewBrands.Rows)
                    {
                        if (row.Cells["BRANDS_LOGOTYPE"].Value != null)
                        {
                            row.Height = 80;
                        }
                    }

                    dataGridViewBrands.Refresh();
                }
            }

            using (fbCon = new FbConnection(fb_cons.ToString()))
            {
                adapter = new FbDataAdapter(sql2, fbCon);
                ds2 = new DataSet();
                adapter.Fill(ds2);

                if (ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
                {
                    DataTable dataTable = ds2.Tables[0];


                    dataTable.Columns.Add("Магазин", typeof(string));

                    foreach (DataRow row in dataTable.Rows)
                    {
                        string networkName = row["Chains_name"].ToString();
                        string city = row["city"].ToString();
                        string address = row["address"].ToString();


                        string combinedValue = $"{networkName}, {city}, {address}";


                        row["Магазин"] = combinedValue;
                    }
                    advancedDataGridViewBrandsShops.DataSource = dataTable;
                    advancedDataGridViewBrandsShops.DataSource = ds2.Tables[0];
                    advancedDataGridViewBrandsShops.Columns["Brands_id"].Visible = false;
                    advancedDataGridViewBrandsShops.Columns["Chains_name"].Visible = false;
                    advancedDataGridViewBrandsShops.Columns["Shops_code"].Visible = false;
                    advancedDataGridViewBrandsShops.Columns["City"].Visible = false;
                    advancedDataGridViewBrandsShops.Columns["Address"].Visible = false;
                    advancedDataGridViewBrandsShops.Columns[1].HeaderText = "Бренд";
                    advancedDataGridViewBrandsShops.Columns[2].HeaderText = "Название сети магазина";
                    advancedDataGridViewBrandsShops.Columns[3].HeaderText = "Код магазина";
                    advancedDataGridViewBrandsShops.Columns[4].HeaderText = "Город";
                    advancedDataGridViewBrandsShops.Columns[4].ReadOnly = true;
                }
            }

        }
        
        private Image ResizeImage(Image img, int width, int height)
        {
            Bitmap b = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.DrawImage(img, 0, 0, width, height);
            }
            return b;
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            fbCon.Open();
            string selectString = "brands_name Like '%" + textBox1.Text.Trim() + "%'";
            DataRowCollection allRows = ((DataTable)dataGridViewBrands.DataSource).Rows;
            DataRow[] searchedRows = ((DataTable)dataGridViewBrands.DataSource).Select(selectString);
            if (searchedRows.Length > 0) 
            {
                int rowIndex = allRows.IndexOf(searchedRows[0]);
                dataGridViewBrands.CurrentCell = dataGridViewBrands[1, rowIndex];
            }
            else
            {
                MessageBox.Show("Значения не найдено.", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            fbCon.Close();
        }


        private void buttonAdd2_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow row = ds2.Tables[0].NewRow();
                ds2.Tables[0].Rows.Add(row);
                advancedDataGridViewBrandsShops.Refresh();
                int newRowIndex = ds2.Tables[0].Rows.Count - 1;
                advancedDataGridViewBrandsShops.CurrentCell = advancedDataGridViewBrandsShops.Rows[newRowIndex].Cells[1];
                advancedDataGridViewBrandsShops.Rows[newRowIndex].Selected = true;
                advancedDataGridViewBrandsShops.FirstDisplayedScrollingRowIndex = newRowIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave2_Click(object sender, EventArgs e)
        {
            try
            {
                fbCon.Open();

                if (advancedDataGridViewBrandsShops.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = advancedDataGridViewBrandsShops.SelectedRows[0]; 

                    if (!selectedRow.IsNewRow)
                    {
                        string brands = selectedRow.Cells["Brands_name"].Value?.ToString();
                        string combinedColumnValue = selectedRow.Cells["Магазин"].Value?.ToString();
                        string[] parts = combinedColumnValue.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        if (parts.Length >= 3)
                        {
                            string chainName = parts[0].Trim();
                            string city = parts[1].Trim();
                            string address = parts[2].Trim();
                            int? shopsCode = null;

                            using (FbDataAdapter adapter = new FbDataAdapter("GET_SHOPS_CODE", fbCon))
                            {
                                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                                adapter.SelectCommand.Parameters.AddWithValue("chains_name", chainName);
                                adapter.SelectCommand.Parameters.AddWithValue("city", city);
                                adapter.SelectCommand.Parameters.AddWithValue("address", address);

                                FbParameter shopsCodeParam = new FbParameter("shops_code", FbDbType.Integer)
                                {
                                    Direction = ParameterDirection.Output
                                };
                                adapter.SelectCommand.Parameters.Add(shopsCodeParam);

                                adapter.SelectCommand.ExecuteNonQuery();

                                if (shopsCodeParam.Value != DBNull.Value)
                                {
                                    shopsCode = Convert.ToInt32(shopsCodeParam.Value);
                                }
                                else
                                {
                                    MessageBox.Show($"Таких данных нет", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }

                            if (shopsCode.HasValue)
                            {
                               
                                using (FbDataAdapter adapter = new FbDataAdapter("BRANDSHOP1", fbCon))
                                {
                                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                                    adapter.SelectCommand.Parameters.AddWithValue("brands_name", brands);
                                    adapter.SelectCommand.Parameters.AddWithValue("chains_name", chainName);
                                    adapter.SelectCommand.Parameters.AddWithValue("shops_code", shopsCode.Value);

                                    adapter.SelectCommand.ExecuteNonQuery();
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

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            using (fbCon = new FbConnection(fb_cons.ToString()))
            {
                fbCon.Open();

                foreach (DataGridViewRow row in advancedDataGridViewBrandsShops.SelectedRows)
                {

                    var brand = row.Cells["brands_id"].Value;
                    var shop = row.Cells["shops_code"].Value;     
                    string query = "DELETE FROM brands_shops WHERE brands_id = @brand and shops_code=@shop ";

                    using (var command = new FbCommand(query, fbCon))
                    {
                        command.Parameters.AddWithValue("@brand", brand);
                        command.Parameters.AddWithValue("@shop", shop);
                        command.ExecuteNonQuery();
                    }

                    advancedDataGridViewBrandsShops.Rows.Remove(row);
                }
            }

        }
       
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            using (fbCon = new FbConnection(fb_cons.ToString()))
            {
                adapter = new FbDataAdapter(sql2, fbCon);
                ds2 = new DataSet();
                adapter.Fill(ds2);

                if (ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
                {
                    DataTable dataTable = ds2.Tables[0];

                    dataTable.Columns.Add("Магазин", typeof(string));

                    
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string networkName = row["Chains_name"].ToString();
                        string city = row["city"].ToString();
                        string address = row["address"].ToString();

                        string combinedValue = $"{networkName}, {city}, {address}";

                        row["Магазин"] = combinedValue;
                    }
                    advancedDataGridViewBrandsShops.DataSource = dataTable;
                    advancedDataGridViewBrandsShops.DataSource = ds2.Tables[0];
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
        
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void advancedDataGridViewBrandsShops_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            DataGridViewCell currentCell = advancedDataGridViewBrandsShops.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (currentCell.IsInEditMode) return;
            try
            {
                advancedDataGridViewBrandsShops.BeginEdit(true);
                currentCell.Selected = true; 
                advancedDataGridViewBrandsShops.CurrentCell = currentCell; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при начале редактирования: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
   