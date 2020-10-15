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

namespace Bitirme_Tezi
{
   // public string sunucu { get; private set; }
    public partial class Randevu : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;
        public string sunucu { get; private set; }
        void Rndv()
        {
            baglanti = new SqlConnection(@"Data Source="+sunucu+";Initial Catalog=Anaokulu;Integrated Security=True");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT*FROM Rndv", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        public Randevu()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtnumara.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtgsebebi.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txttarih.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtgnotlari.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtemail.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void Randevu_Load(object sender, EventArgs e)
        {
            Rndv();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            //ekle
            string sorgu = "INSERT INTO Rndv(AdSoyad,Numara,GrsSebebi,Tarih,GrsNotlari,Eposta) VALUES(@adi,@num,@sebeb,@tarihi,@notlar,@eposta)";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@adi", txtad.Text);
            komut.Parameters.AddWithValue("@num", txtnumara.Text);
            komut.Parameters.AddWithValue("@sebeb", txtgsebebi.Text);
            komut.Parameters.AddWithValue("@tarihi", txttarih.Value);
            komut.Parameters.AddWithValue("@notlar", txtgnotlari.Text);
            komut.Parameters.AddWithValue("@eposta", txtemail.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Rndv();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            //sil
            string sorgu = "DELETE FROM Rndv WHERE ID=@ID";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@ID", Convert.ToInt32(txtID.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Rndv();
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            //güncelle
            string sorgu = "UPDATE Rndv SET AdSoyad=@adi,Numara=@num,GrsSebebi=@sebeb,Tarih=@tarih,GrsNotlari=@notlar,Eposta=@eposta WHERE ID=@ID";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@ID", Convert.ToInt32(txtID.Text));
            komut.Parameters.AddWithValue("@adi", txtad.Text);
            komut.Parameters.AddWithValue("@num", txtnumara.Text);
            komut.Parameters.AddWithValue("@sebeb", txtgsebebi.Text);
            komut.Parameters.AddWithValue("@tarih", txttarih.Value);
            komut.Parameters.AddWithValue("@notlar", txtgnotlari.Text);
            komut.Parameters.AddWithValue("@eposta", txtemail.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Rndv();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult tus;
            tus = colorDialog1.ShowDialog();
            if (tus == DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            
        }
    }
}
