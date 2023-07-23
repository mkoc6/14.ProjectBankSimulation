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
    public partial class hareket : Form
    {
        public hareket()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-1DQCP20\SQLEXPRESS;Initial Catalog=14.ProjeDbBankaTest;Integrated Security=True");
     public string HESAPNOO;
        private void hareket_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select ID, ALICI AS BUYER, TUTAR AS AMOUNT, TARIH AS HISTORY from TBLHAREKET where GONDEREN =" + HESAPNOO, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            bunifuDataGridView1.DataSource = dt;
            SqlDataAdapter da1 = new SqlDataAdapter("select ID , GONDEREN AS SENDER, TUTAR AS AMOUNT, TARIH AS HISTORY from TBLHAREKET where ALICI=" + HESAPNOO, baglanti);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            bunifuDataGridView2.DataSource = dt1;

        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            Form2 tr = new Form2();
            this.Hide();
            tr.TopMost = true;
            
        }
    }
}
