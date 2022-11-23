using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net.Sockets;
namespace Подключение_попытка_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var port = 3306;
            var url = "5.183.188.132";

            using  (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
               
                   socket.ConnectAsync(url, port);
              
                 var t = Task.Run(async delegate
                {
                    await Task.Delay(1000);
                    return 42;
                });
                t.Wait();

                if (socket.Connected)

                   textBox1.Text = ($"Подключение к {url} установлено");
                else
                    textBox1.Text = ($"Не удалось установить подключение к {url}");
          
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string myConnectionString = "Database=db_vgu_test;Data Source=5.183.188.132;User Id=db_vgu_student;Password=thasrCt3pKYWAYcK";
            MySqlConnection myConnection = new MySqlConnection(myConnectionString);
            try
            {
                myConnection.Open();
                MessageBox.Show("Подключение прошло успешно!");
                string sql = "SELECT @@version";
               
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                string name = command.ExecuteScalar().ToString();
                textBox2.Text = (name);
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
    }
}
