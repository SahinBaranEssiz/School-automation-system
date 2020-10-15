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
using Microsoft.Win32;
using System.Data.Sql;

namespace Bitirme_Tezi
{
    public partial class AdminPage : Form
    {
        SqlConnection baglanti;
        SqlDataAdapter da;

        public AdminPage()
        {
            InitializeComponent();
        }

        public string sunucu { get; private set; }

        void Adminrndv()
        {
            baglanti = new SqlConnection("Data Source=" + sunucu + ";Initial Catalog=Anaokulu;Integrated Security=True");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT*FROM Rndv", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        void Adminogr()
        {
            baglanti = new SqlConnection("Data Source=" + sunucu + ";Initial Catalog=Anaokulu;Integrated Security=True");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT*FROM BilgiO", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView2.DataSource = tablo;
            baglanti.Close();
        }

        //private void öğrenciBilgileriTakibiToolStripMenuItem_Click(object sender, EventArgs e){}
        private void button1_Click(object sender, EventArgs e)
        {
           OgrBil ogr = new OgrBil();
            ogr.Show();
        }

        private void PersonelBtn_Click(object sender, EventArgs e)
        {
            personel_kayit prs= new personel_kayit();
            prs.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Randevu rndv = new Randevu();
            rndv.Show();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AdminPage_Load(object sender, EventArgs e)
        {
            Adminogr();
            Adminrndv();
        }

        private void button8_MouseClick(object sender, MouseEventArgs e)
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
            
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            KasaTakibi KasaT = new KasaTakibi();
            KasaT.Show();
        }
    }
}
