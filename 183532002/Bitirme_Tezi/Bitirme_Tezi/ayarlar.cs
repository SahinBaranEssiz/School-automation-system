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
using System.Data.Sql;
using Microsoft.Win32;


namespace Bitirme_Tezi
{
    public partial class ayarlar : Form
    {

        SqlConnection baglanti;

        public ayarlar()
        {
            InitializeComponent();
        }
        public bool Baglanti_Test(string sunucu)
        {
            baglanti = new SqlConnection("Data Source=" + sunucu + ";Initial Catalog=Anaokulu;Integrated Security=True");
            try
            {
                baglanti.Open();
                baglanti.Close();
                return true;
            }
            catch
            {
                baglanti.Close();
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Close();
        }

        public void button2_Click(object sender, EventArgs e)
        {
            //kaydet
            if (Baglanti_Test(txtVeriAdi.Text))
            {
                Ayarlar.Default.sunucu = txtVeriAdi.Text;
                
                Ayarlar.Default.Save();
                MessageBox.Show("Veritabanı ayarları kaydedildi\nProgram yeniden başlatılacak", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();
            }
            else
            {
                MessageBox.Show("Bağlantı testi başarısız olduğu için ayarlar kaydedilmedi !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        private void ayarlar_Load(object sender, EventArgs e)
        {

            txtVeriAdi.Text = Ayarlar.Default.sunucu;

        }
    }
}
