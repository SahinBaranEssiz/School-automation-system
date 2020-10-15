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
    
    public partial class personel_kayit : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da; 

        public personel_kayit()
        {
            InitializeComponent();
        }

        public string sunucu { get; private set; }

        //SqlConnection bahglanti = new SqlConnection(@"Data Source=DESKTOP-B8IL08U;Initial Catalog=login;Integrated Security=True");
        void Prsbilgi()
        {
            baglanti = new SqlConnection(@"Data Source="+sunucu+";Initial Catalog=Anaokulu;Integrated Security=True");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT * FROM Personel", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            ResimTxt.Text = openFileDialog1.FileName;
        }

        
        

        private void SilBtn_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM Personel WHERE ID=@ID";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@ID", Convert.ToInt32(ID.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Prsbilgi();
        }
        

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            ID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            Adtxt.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            SoyadTxt.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            TcNotxt.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            TcSeriNoTxt.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            GsmTxt.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            EvTelTxt.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            Adrestxt.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            Dtarihi.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            Giris.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            Cikis.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            UnvanTxt.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            MaasiTxt.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            DurumuTxt.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            TahsiliTxt.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
            CalısmaTxt.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
            MailTxt.Text = dataGridView1.CurrentRow.Cells[16].Value.ToString();
            Kantxt.Text = dataGridView1.CurrentRow.Cells[17].Value.ToString();
            Izintxt.Text = dataGridView1.CurrentRow.Cells[18].Value.ToString();

        }

        private void eklebtn_Click(object sender, EventArgs e)
        {
            //ekle
            string sorgu = "INSERT INTO Personel(ID,Padi,Psoyad,Ptc,Ptcserino,Ptelefon,Pevtel,Padresi,Pdtarihi,Pgiris,Pcikis,Punvan,Pmaasi,Pdurumu,Ptahsili,Pcalismasaati,Pemail,Pkan,Pizinler,Presim) VALUES(@ID,@Padi,@Psoyad,@Ptc,@Ptcserino,@Ptelefon,@Pevtel,@Padresi,@Pdtarihi,@Pgiris,@Pcikis,@Punvan,@Pmaasi,@Pdurumu,@Ptahsili,@Pcalismasaati,@Pemail,@Pkan,@Pizinler,@Presim)";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@Padi", Adtxt.Text);
            komut.Parameters.AddWithValue("@Psoyad", SoyadTxt.Text);
            komut.Parameters.AddWithValue("@Ptc", TcNotxt.Text);
            komut.Parameters.AddWithValue("@Ptcserino", TcSeriNoTxt.Text);
            komut.Parameters.AddWithValue("@Ptelefon", GsmTxt.Text);
            komut.Parameters.AddWithValue("@Pevtel", EvTelTxt.Text);
            komut.Parameters.AddWithValue("@Padresi", Adrestxt.Text);
            komut.Parameters.AddWithValue("@Pdtarihi", Dtarihi.Value);
            komut.Parameters.AddWithValue("@Pgiris", Giris.Value);
            komut.Parameters.AddWithValue("@Pcikis", Cikis.Value);
            komut.Parameters.AddWithValue("@Punvan", UnvanTxt.Text);
            komut.Parameters.AddWithValue("@Pmaasi", MaasiTxt.Text);
            komut.Parameters.AddWithValue("@Pdurumu", DurumuTxt.Text);
            komut.Parameters.AddWithValue("@Tahsili", TahsiliTxt.Text);
            komut.Parameters.AddWithValue("@Pcalismasaati", CalısmaTxt.Text);
            komut.Parameters.AddWithValue("@Pemail", MailTxt.Text);
            komut.Parameters.AddWithValue("@Pkan", Kantxt.Text);
            komut.Parameters.AddWithValue("@Pizinler", Izintxt.Text);
            komut.Parameters.AddWithValue("@Presim", ResimTxt.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Prsbilgi();
        }

        private void GncBtn_Click(object sender, EventArgs e)
        {
            //Güncelle
            string sorgu = "UPDATE Personel SET Padi=@Padi,Psoyad=@Psoyad,Ptc=@Ptc,Ptcserino=@Ptcserino,Ptelefon=@Ptelefon,Pevtel=@Pevtel,Padresi=@Padresi,Pdtarihi=@Pdtarihi,Pgiris =@Pgiris,Pcikis= @Pcikis,Punvan= @Punvan,Pmaasi= @Pmaasi,Pdurumu =@Pdurumu,Tahsili= @Tahsili,Pcalismasaati= @Pcalismasaati,Pemail=@Pemail,Pkan= @Pkan,Pizinler= @Pizinler,Presim =@Presim WHERE ID=@ID";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@ID", Convert.ToInt32(ID.Text));
            komut.Parameters.AddWithValue("@Padi", Adtxt.Text);
            komut.Parameters.AddWithValue("@Psoyad", SoyadTxt.Text);
            komut.Parameters.AddWithValue("@Ptc", TcNotxt.Text);
            komut.Parameters.AddWithValue("@Ptcserino", TcSeriNoTxt.Text);
            komut.Parameters.AddWithValue("@Ptelefon", GsmTxt.Text);
            komut.Parameters.AddWithValue("@Pevtel", EvTelTxt.Text);
            komut.Parameters.AddWithValue("@Padresi", Adrestxt.Text);
            komut.Parameters.AddWithValue("@Pdtarihi", Dtarihi.Value); 
            komut.Parameters.AddWithValue("@Pgiris", Giris.Value);
            komut.Parameters.AddWithValue("@Pcikis", Cikis.Value);
            komut.Parameters.AddWithValue("@Punvan", UnvanTxt.Text); 
            komut.Parameters.AddWithValue("@Pmaasi", MaasiTxt.Text);
            komut.Parameters.AddWithValue("@Pdurumu", DurumuTxt.Text);
            komut.Parameters.AddWithValue("@Tahsili", TahsiliTxt.Text);
            komut.Parameters.AddWithValue("@Pcalismasaati", CalısmaTxt.Text); 
            komut.Parameters.AddWithValue("@Pemail", MailTxt.Text); 
            komut.Parameters.AddWithValue("@Pkan", Kantxt.Text);
            komut.Parameters.AddWithValue("@Pizinler", Izintxt.Text);
            komut.Parameters.AddWithValue("@Presim", ResimTxt.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Prsbilgi();
        }

        private void personel_kayit_Load_1(object sender, EventArgs e)
        {
            Prsbilgi();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult tus;
            tus = colorDialog1.ShowDialog();
            if (tus == DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Close();
        }
    }
}
