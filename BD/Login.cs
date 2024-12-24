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

namespace BD
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userId = textBox1.Text;
            string password = textBox2.Text;
           
            FbConnectionStringBuilder fb_cons = new FbConnectionStringBuilder
            {
                DataSource = "localhost",
                Port = 3050,
                Role = "",
                Dialect = 3,
                Charset = "WIN1251",
                UserID = userId, 
                Password = password, 
                Database = @"D:\datebase\BD.fdb"
            };

            
            using (var connection = new FbConnection(fb_cons.ToString()))
            {
                try
                {
                    connection.Open();


                    UserCredentials credentials = new UserCredentials(userId, password);
                    Applacation form1 = new Applacation(credentials);
                    form1.Show();
                    
                    this.Hide(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка подключения: {ex.Message}");
                }
            }
        }
    }
}
