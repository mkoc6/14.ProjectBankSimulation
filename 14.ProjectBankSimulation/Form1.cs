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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection
            (@"Data Source=DESKTOP-1DQCP20\SQLEXPRESS;Initial Catalog=14.ProjeDbBankaTest;Integrated Security=True");

        private void bunifuMetroTextbox1_Click(object sender, EventArgs e)
        {
            txtHesapNo.Text = "";
        }

        private void bunifuMetroTextbox2_Click(object sender, EventArgs e)
        {
            TxtSifre.Text = "";        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnKayıtol_Click(object sender, EventArgs e)
        {
            kayıtool btk = new kayıtool();
            this.Hide();
            btk.Show();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select * from TBLKISILER where hesapno=@p1 and sıfre=@p2",baglanti);
            komut1.Parameters.AddWithValue("@p1", txtHesapNo.Text);
            komut1.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader DR = komut1.ExecuteReader();
           
                if (DR.Read())
                {
                    Form2 TR = new Form2();
                TR.HESAPNO = txtHesapNo.Text;
                    TR.Show();
                }
            else
            {
                MessageBox.Show("Incorrect account number or Password", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
               


            baglanti.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
    }
}
