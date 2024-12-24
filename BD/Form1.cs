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
using FirebirdSql.Data.FirebirdClient;

namespace BD
{
    public partial class Applacation : Form
    {
        
        private UserCredentials credentials1;
        FbConnectionStringBuilder fb_cons;
        FbConnection fbCon;
        FbDataAdapter adapter;
        DataSet ds;
        string sql = "SELECT * FROM SALES";
        string sql1 = @"SELECT s.date_id,s.brands_id,s.brands_name,s.chains_name,s.shops_code,s.items_id, s.items_name,s.category, s.cost_price, s.sales_items,s.sales_value, bs.city,bs.address
                       FROM sales s
                       LEFT JOIN shops bs ON s.shops_code = bs.shops_code";
        

        public Applacation(UserCredentials credentials)
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(Applacation_FormClosed);
            credentials1 = credentials;
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string login = credentials1.UserId;
            string password = credentials1.Password;
            advancedDataGridViewSales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            advancedDataGridViewSales.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            advancedDataGridViewSales.AllowUserToAddRows = false;
            resultTextBox.ReadOnly = true;
            advancedDataGridViewSales.EditMode = DataGridViewEditMode.EditProgrammatically;
            advancedDataGridViewSales.ReadOnly= false;
           
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
                    advancedDataGridViewSales.DataSource = dataTable;
                    advancedDataGridViewSales.DataSource = ds.Tables[0];
                    advancedDataGridViewSales.Columns[0].HeaderText = "Дата";
                    advancedDataGridViewSales.Columns[2].HeaderText = "Бренд";
                    advancedDataGridViewSales.Columns[2].Width = 80;
                    advancedDataGridViewSales.Columns[5].Width = 70;
                    advancedDataGridViewSales.Columns[6].Width = 200;
                    advancedDataGridViewSales.Columns[6].HeaderText = "Наименование товара";
                    advancedDataGridViewSales.Columns[7].HeaderText = "Категория товара";
                    advancedDataGridViewSales.Columns[8].HeaderText = "Цена";
                    advancedDataGridViewSales.Columns[8].Width = 80;  
                    advancedDataGridViewSales.Columns[9].HeaderText = "Количество штук";
                    advancedDataGridViewSales.Columns[9].Width = 60;
                    advancedDataGridViewSales.Columns[10].HeaderText = "Общая стоимость";
                    advancedDataGridViewSales.Columns[10].Width = 70;
                    advancedDataGridViewSales.Columns[11].Width = 80;
                    advancedDataGridViewSales.Columns[11].HeaderText = "Общая стоимсоть";
                    advancedDataGridViewSales.Columns["Brands_id"].Visible = false;
                    advancedDataGridViewSales.Columns["Items_id"].Visible = false;
                    advancedDataGridViewSales.Columns["Chains_name"].Visible = false;
                    advancedDataGridViewSales.Columns["Shops_code"].Visible = false;
                    advancedDataGridViewSales.Columns["City"].Visible = false;
                    advancedDataGridViewSales.Columns["Address"].Visible = false;
                    advancedDataGridViewSales.Columns["Магазин"].DisplayIndex = 4;
                }
            }
        }
        

        private void брендыToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string login = credentials1.UserId;
            string password = credentials1.Password;
            UserCredentials credentials = new UserCredentials(login, password);
            Brands form2 = new Brands(credentials);
            form2.Show();
        }
        private void магазиныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string login = credentials1.UserId;
            string password = credentials1.Password;
            UserCredentials credentials = new UserCredentials(login, password);
            Shops form3 = new Shops(credentials);
            form3.Show();
        }

        private void продуктыToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string login = credentials1.UserId;
            string password = credentials1.Password;
            UserCredentials credentials = new UserCredentials(login, password);
            Items form4 = new Items(credentials);
            form4.Show();
        }

        private void поставкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string login = credentials1.UserId;
            string password = credentials1.Password;
            UserCredentials credentials = new UserCredentials(login, password);
            ItemsShops form5 = new ItemsShops(credentials);
            form5.Show();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string login = credentials1.UserId;
            string password = credentials1.Password;
            UserCredentials credentials = new UserCredentials(login, password);
            Form6 form6 = new Form6(credentials);
            form6.Show();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            using (fbCon = new FbConnection(fb_cons.ToString()))
            {
                fbCon.Open();

                foreach (DataGridViewRow row in advancedDataGridViewSales.SelectedRows)
                {

                    var date = row.Cells["date_id"].Value;
                    var shop = row.Cells["shops_code"].Value;
                    var item = row.Cells["items_id"].Value;
                    string query = "DELETE FROM sales WHERE date_id = @date and shops_code=@shop and items_id=@item";

                    using (var command = new FbCommand(query, fbCon))
                    {
                        command.Parameters.AddWithValue("@date", date);
                        command.Parameters.AddWithValue("@shop", shop);
                        command.Parameters.AddWithValue("@item", item);
                        command.ExecuteNonQuery();
                    }

                    advancedDataGridViewSales.Rows.Remove(row);
                }
            }
        }


        private void buttonUpdate_Click(object sender, EventArgs e)
        {
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
                    advancedDataGridViewSales.DataSource = dataTable;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime? startDate = null;
            DateTime? endDate = null;
            string brand = brandTextBox.Text.Trim();
            string shop = shopTextBox.Text.Trim();
            string category = categoryTextBox.Text.Trim();

            if (!string.IsNullOrWhiteSpace(textBox2.Text))
            {
                if (!DateTime.TryParse(textBox2.Text, out DateTime parsedStartDate))
                {
                    MessageBox.Show("Некорректная дата начала. Пожалуйста, введите правильную дату.");
                    return; 
                }
                startDate = parsedStartDate; 
            }

            if (!string.IsNullOrWhiteSpace(textBox3.Text))
            {
                if (!DateTime.TryParse(textBox3.Text, out DateTime parsedEndDate))
                {
                    
                    MessageBox.Show("Некорректная дата конца. Пожалуйста, введите правильную дату.");
                    return; 
                }
                endDate = parsedEndDate; 
            }

            using (fbCon = new FbConnection(fb_cons.ToString()))
            {
                fbCon.Open();
                using (var command = new FbCommand())
                {
                    command.Connection = fbCon;

                    var query = "SELECT SUM(s.sales_items) AS sales_items, SUM(s.sales_value) AS sales_value FROM sales s WHERE 1=1";
                    var parameters = new List<FbParameter>();

                    if (startDate.HasValue)
                    {
                        query += " AND s.date_id >= @StartDate";
                        parameters.Add(new FbParameter("@StartDate", startDate.Value));
                    }

                    if (endDate.HasValue)
                    {
                        query += " AND s.date_id <= @EndDate";
                        parameters.Add(new FbParameter("@EndDate", endDate.Value));
                    }

                    if (!string.IsNullOrEmpty(brand))
                    {
                        query += " AND s.brands_name = @Brand";
                        parameters.Add(new FbParameter("@Brand", brand));
                    }

                    if (!string.IsNullOrEmpty(shop))
                    {
                        query += " AND s.chains_name = @Shop";
                        parameters.Add(new FbParameter("@Shop", shop));
                    }

                    if (!string.IsNullOrEmpty(category))
                    {
                        query += " AND s.category = @Category";
                        parameters.Add(new FbParameter("@Category", category));
                    }

                    command.CommandText = query;

                    foreach (var param in parameters)
                    {
                        command.Parameters.Add(param);
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int salesItems = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                            decimal salesValue = reader.IsDBNull(1) ? 0 : reader.GetDecimal(1);

                            resultTextBox.Text = $"Количество проданных штук: {salesItems + " шт"}{Environment.NewLine}Общая стоимость: {salesValue:C2}";
                        }
                        else
                        {
                            MessageBox.Show("No data found.");
                        }
                    }
                }
            }
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
              this.Close();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearTextBoxes(this);
        }
        private void ClearTextBoxes(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
              
                if (control is TextBox textBox)
                {
                    textBox.Clear();
                }
                
            }
        }
        private void Applacation_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); 
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            fbCon.Open();
            string selectString = "items_name Like '%" + textBox1.Text.Trim() + "%'";
            DataRowCollection allRows = ((DataTable)advancedDataGridViewSales.DataSource).Rows;
            DataRow[] searchedRows = ((DataTable)advancedDataGridViewSales.DataSource).Select(selectString);
            if (searchedRows.Length > 0)
            {
                int rowIndex = allRows.IndexOf(searchedRows[0]);
                advancedDataGridViewSales.CurrentCell = advancedDataGridViewSales[0, rowIndex];
            }
            else
            {
                MessageBox.Show("Значения не найдено.", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            fbCon.Close();
        }

        private void advancedDataGridViewSales_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            DataGridViewCell currentCell = advancedDataGridViewSales.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (currentCell.IsInEditMode) return;
            try
            {
                advancedDataGridViewSales.BeginEdit(true);
                currentCell.Selected = true;
                advancedDataGridViewSales.CurrentCell = currentCell;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при начале редактирования: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}

