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

namespace _14.ProjectBankSimulation
{
    public partial class kayıtool : Form
    {
        public kayıtool()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-1DQCP20\SQLEXPRESS;Initial Catalog=14.ProjeDbBankaTest;Integrated Security=True");
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            int bakiye = 0;
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("insert into TBLKISILER ( AD, SOYAD, TC, TELEFON, HESAPNO, SIFRE) VALUES (@P1, @P2, @P3, @P4, @p5, @p6)",baglanti);

            komut1.Parameters.AddWithValue("@P1", txtAd.Text);
            komut1.Parameters.AddWithValue("@P2", txtSoyad.Text);
            komut1.Parameters.AddWithValue("@P3", mskTC.Text);
            komut1.Parameters.AddWithValue("@p4", mskTelefon.Text);
            komut1.Parameters.AddWithValue("@p5", mskHesapno.Text);
            komut1.Parameters.AddWithValue("@P6", txtSifre.Text);
            komut1.ExecuteNonQuery();
            MessageBox.Show("Successfully Registered");
            SqlCommand komut2 = new SqlCommand("insert into TBLHESAP (HESAPNO, BAKIYE) VALUES (@B1,@B2)", baglanti);
            komut2.Parameters.AddWithValue("@B1", mskHesapno.Text);
            komut2.Parameters.AddWithValue("@B2", bakiye);
            komut2.ExecuteNonQuery();
            baglanti.Close();
        }

        private void btnHesapNo_Click(object sender, EventArgs e)
        {
            int etk;
            Random br = new Random();
            etk = br.Next(100000,1000000);
            mskHesapno.Text = etk.ToString();


        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void kayıtool_Load(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            Form1 cr = new Form1();
            this.Hide();
            cr.Show();
        }
    }
}
