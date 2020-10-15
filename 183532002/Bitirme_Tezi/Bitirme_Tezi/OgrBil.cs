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
    public partial class OgrBil : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;

        public OgrBil()
        {
            InitializeComponent();
        }

        public string sunucu { get; private set; }
        //SqlConnection bagglanti = new SqlConnection(@"Data Source=DESKTOP-B8IL08U;Initial Catalog=login;Integrated Security=True");

        void Ogrbilgi()
        {
            baglanti = new SqlConnection(@"Data Source="+sunucu+";Initial Catalog=Anaokulu;Integrated Security=True");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT*FROM BilgiO",baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void button_ekle_Click(object sender, EventArgs e)
        { //ekle
            string sorgu = "INSERT INTO BilgiO(OgrAdı,Ogrsoy,TcNo,OkulNo,AnneAd,BabaAd,VeliNo,Alerjiler,Ilaclar,Dtarihi,BabaIs,AnneIs,OdemeBil) VALUES(@OgrAdı,@Ogrsoy,@TcNo,@OkulNo,@AnneAd,@BabaAd,@VeliNo,@Alerjiler,@Ilaclar,@Dtarihi,@BabaIs,@AnneIs,@OdemeBil)";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@OgrAdı", txtad.Text);
            komut.Parameters.AddWithValue("@Ogrsoy", txtsoyad.Text);
            komut.Parameters.AddWithValue("@TcNo", txttc.Text);
            komut.Parameters.AddWithValue("@OkulNo", txtokul.Text);
            komut.Parameters.AddWithValue("@AnneAd", txtannead.Text);
            komut.Parameters.AddWithValue("@BabaAd", txtbabaad.Text);
            komut.Parameters.AddWithValue("@VeliNo", txtvelino.Text);
            komut.Parameters.AddWithValue("@Alerjiler", txtalerji.Text);
            komut.Parameters.AddWithValue("@Ilaclar", txtilac.Text);
            komut.Parameters.AddWithValue("@Dtarihi", datetarih.Value);
            komut.Parameters.AddWithValue("@BabaIs", txtbabais.Text);
            komut.Parameters.AddWithValue("@AnneIs", txtanneis.Text);
            komut.Parameters.AddWithValue("@OdemeBil", txtodeme.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Ogrbilgi();


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        { //burda görüntelenecek
            txtad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txttc.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtokul.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            datetarih.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            txtbabaad.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtannead.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtvelino.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtalerji.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txtilac.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            txtbabais.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            txtanneis.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            txtodeme.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //güncelle
            string sorgu = "UPDATE BilgiO SET OgrAdı=@OgrAdı,Ogrsoy=@Ogrsoy,TcNo=@TcNo,OkulNo=@OkulNo,AnneAd=@AnneAd,BabaAd=@BabaAd,VeliNo=@VeliNo,Alerjiler=@Alerjiler,Ilaclar=@Ilaclar,Dtarihi=@Dtarihi,BabaIs=@BabaIs,AnneIs=@AnneIs,OdemeBil=@OdemeBil WHERE ID=@ID";
            komut = new SqlCommand(sorgu,baglanti);
            komut.Parameters.AddWithValue("@ID", Convert.ToInt32(txtId.Text));
            komut.Parameters.AddWithValue("@OgrAdı", txtad.Text);
            komut.Parameters.AddWithValue("@Ogrsoy", txtsoyad.Text);
            komut.Parameters.AddWithValue("@TcNo", txttc.Text);
            komut.Parameters.AddWithValue("@OkulNo", txtokul.Text);
            komut.Parameters.AddWithValue("@AnneAd", txtannead.Text);
            komut.Parameters.AddWithValue("@BabaAd", txtbabaad.Text);
            komut.Parameters.AddWithValue("@VeliNo", txtvelino.Text);
            komut.Parameters.AddWithValue("@Alerjiler", txtalerji.Text);
            komut.Parameters.AddWithValue("@Ilaclar", txtilac.Text);
            komut.Parameters.AddWithValue("@Dtarihi", datetarih.Value);
            komut.Parameters.AddWithValue("@BabaIs", txtbabais.Text);
            komut.Parameters.AddWithValue("@AnneIs", txtanneis.Text);
            komut.Parameters.AddWithValue("@OdemeBil", txtodeme.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Ogrbilgi();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //sil
            string sorgu = "DELETE FROM BilgiO WHERE ID=@ID";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@ID",Convert.ToInt32(txtId.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Ogrbilgi();
        }

        private void OgrBil_Load(object sender, EventArgs e)
        {
           Ogrbilgi();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult tus;
            tus = colorDialog1.ShowDialog();
            if (tus == DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Close();
        }
    }
}
