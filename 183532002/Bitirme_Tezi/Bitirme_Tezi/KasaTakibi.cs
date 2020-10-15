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
    public partial class KasaTakibi : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;

        public KasaTakibi()
        {
            InitializeComponent();
        }
        public string sunucu { get; private set; }
        void kasatakip()
        {
            baglanti = new SqlConnection(@"Data Source="+sunucu+";Initial Catalog=Anaokulu;Integrated Security=True");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT*FROM ogrodeme", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            OgrOdm.DataSource = tablo;
            baglanti.Close();
        }
        void kasatakip2()
        {
            baglanti = new SqlConnection("Data Source=" + sunucu + ";Initial Catalog=Anaokulu;Integrated Security=True");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT*FROM prsodeme", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            PrsOdm.DataSource = tablo;
            baglanti.Close();
        }

        private void KasaTakibi_Load(object sender, EventArgs e)
        {
            kasatakip();
            kasatakip2();

        }

        private void PrsOdm_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtcekp.Text = PrsOdm.CurrentRow.Cells[1].Value.ToString();
            txtnakitp.Text = PrsOdm.CurrentRow.Cells[2].Value.ToString();
            txthavalep.Text = PrsOdm.CurrentRow.Cells[3].Value.ToString();
            txtpadi.Text = PrsOdm.CurrentRow.Cells[4].Value.ToString();
            PrsTarih.Text = PrsOdm.CurrentRow.Cells[5].Value.ToString();
            txtnedenp.Text = PrsOdm.CurrentRow.Cells[6].Value.ToString();
            txtID.Text = PrsOdm.CurrentRow.Cells[0].Value.ToString();
        }

        private void OgrOdm_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtkredio.Text = OgrOdm.CurrentRow.Cells[1].Value.ToString();
            txtceko.Text = OgrOdm.CurrentRow.Cells[2].Value.ToString();
            txtnakito.Text = OgrOdm.CurrentRow.Cells[3].Value.ToString();
            txthavaleo.Text = OgrOdm.CurrentRow.Cells[4].Value.ToString();
            txtogradi.Text = OgrOdm.CurrentRow.Cells[5].Value.ToString();
            txtveliadi.Text = OgrOdm.CurrentRow.Cells[6].Value.ToString();
            OgrTarih.Text = OgrOdm.CurrentRow.Cells[7].Value.ToString();
            txtnedeno.Text = OgrOdm.CurrentRow.Cells[8].Value.ToString();
            txtID2.Text = OgrOdm.CurrentRow.Cells[0].Value.ToString();
        }

        private void BtnOdeme_Click(object sender, EventArgs e)
        {
            //ödeme personel
            string sorgu = "INSERT INTO prsodeme(Cek,Nakit,Havale,PersonelAdi,Tarih,OdemeNedeni) VALUES(@cek,@nakit,@havale,@padi,@tarih,@odmneden)";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@cek", txtcekp.Text);
            komut.Parameters.AddWithValue("@nakit", txtnakitp.Text);
            komut.Parameters.AddWithValue("@havale", txthavalep.Text);
            komut.Parameters.AddWithValue("@padi", txtpadi.Text);
            komut.Parameters.AddWithValue("@tarih", PrsTarih.Value);
            komut.Parameters.AddWithValue("@odmneden", txtnedenp.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            kasatakip();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            //sil personel
            string sorgu = "DELETE FROM prsodeme WHERE ID=@ID";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@ID", Convert.ToInt32(txtID.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            kasatakip();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            //güncelle personel
            string sorgu = "UPDATE prsodeme SET Cek=@cek,Nakit=@nakit,Havale=@havale,PersonelAdi=@padi,Tarih=@tarih,OdemeNedeni=@odneden, WHERE ID=@ID";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@ID", Convert.ToInt32(txtID.Text));
            komut.Parameters.AddWithValue("@cek", txtcekp.Text);
            komut.Parameters.AddWithValue("@nakit", txtnakitp.Text);
            komut.Parameters.AddWithValue("@havale", txthavalep.Text);
            komut.Parameters.AddWithValue("@padi", txtpadi.Text);
            komut.Parameters.AddWithValue("@tarih", PrsTarih.Value);
            komut.Parameters.AddWithValue("@odneden", txtnedenp.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            kasatakip();
        }

        private void KasaEkle_Click(object sender, EventArgs e)
        {
            //ekle ogr
            string sorgu = "INSERT INTO ogrodeme(Kredi,cek,nakit,havale,OgrenciAdi,VeliAdi,Tarih,OdemeNedeni) VALUES(@kredi,@cek,@nakit,@havale,@ogradi,@vadi,@tarih,@odmneden)";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@kredi", txtkredio.Text);
            komut.Parameters.AddWithValue("@cek", txtceko.Text);
            komut.Parameters.AddWithValue("@nakit", txtnakito.Text);
            komut.Parameters.AddWithValue("@havale", txthavaleo.Text);
            komut.Parameters.AddWithValue("@ogradi", txtogradi.Text);
            komut.Parameters.AddWithValue("@vadi", txtveliadi.Text);
            komut.Parameters.AddWithValue("@tarih", OgrTarih.Value);
            komut.Parameters.AddWithValue("@odmneden", txtnedeno.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            kasatakip2();

        }

        private void KasaGüncel_Click(object sender, EventArgs e)
        {
            //güncelle ogr
            string sorgu = "UPDATE ogrodeme SET Kredi=@kredi,cek=@cek,nakit=@nakit,havale=@havale,OgrenciAdi=@ogradi,VeliAdi=@vadi,tarih=@tarih,OdemeNedeni=@odmneden WHERE ID=@ID";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@ID", Convert.ToInt32(txtID2.Text));
            komut.Parameters.AddWithValue("@kredi", txtkredio.Text);
            komut.Parameters.AddWithValue("@cek", txtceko.Text);
            komut.Parameters.AddWithValue("@nakit", txtnakito.Text);
            komut.Parameters.AddWithValue("@havale", txthavaleo.Text);
            komut.Parameters.AddWithValue("@ogradi", txtogradi.Text);
            komut.Parameters.AddWithValue("@vadi", txtveliadi.Text);
            komut.Parameters.AddWithValue("@tarih", OgrTarih.Value);
            komut.Parameters.AddWithValue("@odmneden", txtnedeno.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            kasatakip2();
        }

        private void KasaSil_Click(object sender, EventArgs e)
        {
            //sil ogr
            string sorgu = "DELETE FROM pogrodeme WHERE ID=@ID";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@ID", Convert.ToInt32(txtID2.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            kasatakip2();
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
            this.Close();
            Close();
        }
    }
}
