using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace deneme2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-UK4AJ54Q;Initial Catalog=kullanicilar;Integrated Security=True");
        private void veriler()
        {
            //Admin kısmına liste ekleyip verileri görüntüleyebilmek için;
            /*listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From parola", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["Ad"].ToString());
                ekle.SubItems.Add(oku["Sifre"].ToString());
                listView1.Items.Add(ekle);
            }
            baglanti.Close();*/
        }
        int id = 0;


        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update parola set Sifre="+ textBox2.Text.ToString()+"where id= "+ textBox1.Text.ToString(),baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            veriler();
            MessageBox.Show("Şifreniz başarıyla değiştirildi.");
        }

        /*private void listView1_DoubleClick(object sender, EventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[2].Text;
        }*/

        private void Form3_Load(object sender, EventArgs e)
        {
            veriler();
        }
    }
}
