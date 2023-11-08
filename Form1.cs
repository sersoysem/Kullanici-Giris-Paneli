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
    public partial class Form1 : Form
    {
        
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-UK4AJ54Q;Initial Catalog=kullanicilar;Integrated Security=True");
        private int girisDenemesi = 3;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                string sql = "select * from parola where Ad= @adi AND Sifre= @sifresi ";
                SqlParameter prm1 = new SqlParameter("adi", textBox1.Text.Trim());
                SqlParameter prm2 = new SqlParameter("sifresi", textBox2.Text.Trim());
                SqlCommand komut = new SqlCommand(sql, baglanti);
                komut.Parameters.Add(prm1);
                komut.Parameters.Add(prm2);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(komut);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    Form2 fr = new Form2();
                    fr.Show();
                }
                else
                {
                    girisDenemesi--; // Her hata durumunda deneme hakkını azalt
                    MessageBox.Show("Kullanıcı adı veya şifreniz hatalı. Kalan Deneme Hakkı: " + girisDenemesi);

                    if (girisDenemesi == 0)
                    {
                        button1.Enabled = false; // Deneme hakkı tükendiğinde giriş düğmesini devre dışı bırak
                    }
                }
            }
            catch (Exception)
            {
                

            }
            finally
            {
                baglanti.Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 fr1 = new Form3();
            fr1.Show();

        }
    }
}
