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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection
    (@"Data Source=DESKTOP-1DQCP20\SQLEXPRESS;Initial Catalog=14.ProjeDbBankaTest;Integrated Security=True");
      public  String HESAPNO;
        void bakiyee()
        {
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select * from TBLHESAP where hesapno =" + HESAPNO, baglanti);
            SqlDataReader drr = komut3.ExecuteReader();
            while (drr.Read())
            {
                btnmev.ButtonText = drr[1].ToString();
            }
            baglanti.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lbltarih.Text = lbltarih.Text = DateTime.Now.ToLongDateString();
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select * from TBLKISILER where HESAPNO=" +HESAPNO,baglanti);
            SqlDataReader dr = komut1.ExecuteReader();
            while (dr.Read())
            {
                lblAdSoyad.Text = dr[1] + " " + dr[2];
                LblTelefon.Text = dr[4].ToString();
                lblHesapNo.Text = dr[5].ToString();
                lblTC.Text = dr[3].ToString();

            }

            baglanti.Close();
            
            bakiyee();


        }
        
        void Hareketlerpaneli()
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO TBLHAREKET (GONDEREN,ALICI,TUTAR,TARIH) VALUES (@P1,@P2,@P3,@P4)", baglanti);
        cmd.Parameters.AddWithValue("@P1", lblHesapNo.Text);
                cmd.Parameters.AddWithValue("@P2", mskhesapno.Text);
                cmd.Parameters.AddWithValue("@P3", txtTutar.Text);
                cmd.Parameters.AddWithValue("@P4", lbltarih.Text);
                cmd.ExecuteNonQuery();
                baglanti.Close();
            }
        


    private void BtnGönder_Click(object sender, EventArgs e)
        {

            //Gönderilen Hesabın Para Artışı
            baglanti.Open();
            SqlCommand KOMUT = new SqlCommand("update TBLHESAP set bakıye = bakıye+@p1 where hesapno=@p2", baglanti);
            KOMUT.Parameters.AddWithValue("@p1", decimal.Parse(txtTutar.Text));
            KOMUT.Parameters.AddWithValue("@p2", mskhesapno.Text);
            KOMUT.ExecuteNonQuery();
            baglanti.Close();
          

            // Göndeen Hesabın Para Azalışı
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Update TBLHESAP SET BAKIYE = BAKIYE-@B1 WHERE HESAPNO=@B2",baglanti);
            komut2.Parameters.AddWithValue("@B1",Decimal.Parse(txtTutar.Text ));
            komut2.Parameters.AddWithValue("@B2",HESAPNO );
            komut2.ExecuteNonQuery();
            baglanti.Close();
            bakiyee();
            MessageBox.Show("Your Transaction Has Been Made");
            /// Hareket
            Hareketlerpaneli();

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            hareket hr = new hareket();
            hr.HESAPNOO = lblHesapNo.Text;
            hr.Show();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            Form1 ax = new Form1();
            this.Hide();
            ax.Show();
        }
    }
}
