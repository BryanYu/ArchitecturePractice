using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bryan.BMI.Practice.WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var height = textBox1.Text;
            var weight = textBox2.Text;

            var result = this.GetBMI(height, weight);
            label3.Text = result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var height = textBox1.Text;
            var weight = textBox2.Text;

            var bmi = this.GetBMI(height, weight);


            string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Bryan\Bryan.BMI.Practice\Bryan.BMI.Practice.WinForm\Database1.mdf;Integrated Security=True";
            var conn = new System.Data.SqlClient.SqlConnection(connStr);
            conn.Open();
            //這SQL很糟
            var sql = $"insert into BasicBMI (height, weight, bmi) values ({height},{weight},{bmi})";
            var command = new System.Data.SqlClient.SqlCommand(sql, conn);
            var ret = command.ExecuteNonQuery();
            MessageBox.Show("save to db ...result:" + ret);
        }

        private string GetBMI(string height,string weight)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:44643/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync("/api/bmi/" + "?height=" + height + "&weight=" + weight).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                MessageBox.Show("fail " + response.Content.ReadAsStringAsync().Result);
                return string.Empty;
            }
        }
    }
}
