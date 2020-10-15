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
using System.IO;
namespace Bitirme_Tezi
{
    public partial class KlcGirişi : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;

        public string sunucu { get; private set; }

        public KlcGirişi()
        {
            InitializeComponent();
        }

        
         void Prsbilgi()
            {
            baglanti = new SqlConnection("Data Source=" + sunucu + ";Initial Catalog=Anaokulu;Integrated Security=True");
            baglanti.Open();
             da = new SqlDataAdapter("SELECT * FROM parola", baglanti);
             DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
           baglanti.Close();
          }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                string sql = "Select * From parola where Klcadi=@Klcadi AND Sifre=@sifresi";
                SqlParameter prm1 = new SqlParameter("Klcadi", usertxt.Text.Trim());
                SqlParameter prm2 = new SqlParameter("sifresi", passtxt.Text.Trim());
                SqlCommand komut = new SqlCommand(sql, baglanti);
                komut.Parameters.Add(prm1);
                komut.Parameters.Add(prm2);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(komut);
                da.Fill(dt);
                Prsbilgi();
                if (dt.Rows.Count > 0)
                {
                    AdminPage fr = new AdminPage();
                    fr.Show();
                    this.Hide();
                    Hide();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("hatalı giriş yapıldı tekrar deneyiniz.");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sorgu = "INSERT INTO parola(Klcadi,AdSoyad,Sifre,Resim)VALUES(@Klcadi,@AdSoyad,@Sifre,@Resim)";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@Klcadi", txtklcad.Text);
            komut.Parameters.AddWithValue("@AdSoyad", adsoyad.Text);
            komut.Parameters.AddWithValue("@Sifre", sifre.Text);
            komut.Parameters.AddWithValue("@Resim", resim.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Prsbilgi();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            resim.Text = openFileDialog1.FileName;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
             Prsbilgi();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //ayarları açar
            ayarlar options = new ayarlar();
            options.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult tus;
            tus = colorDialog1.ShowDialog();
            if (tus == DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;
            }
        }

        

        private void hakkinda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu program Şahin Baran Eşsiz tarafından yazılmıştır.");
        }
    }
}
