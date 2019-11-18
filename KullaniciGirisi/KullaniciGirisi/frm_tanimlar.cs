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

namespace KullaniciGirisi
{
    public partial class frm_tanimlar : Form
    {
        public frm_tanimlar()
        {
            InitializeComponent();
        }

        public static SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-H9K25347;Initial Catalog=KullanıcıGiris;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            frm_tanimlar_stok f5 = new frm_tanimlar_stok();
            f5.ShowDialog();
            f5.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_tanimler_satis f2 = new frm_tanimler_satis();
            f2.ShowDialog();
            f2.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm_tanimlar_depo frm_dp = new frm_tanimlar_depo();
            frm_dp.ShowDialog();
            frm_dp.Dispose();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frm_tanimlar_satislistesi stslist = new frm_tanimlar_satislistesi();
            stslist.ShowDialog();
            stslist.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frm_tanimlar_musteri f = new frm_tanimlar_musteri();
            f.ShowDialog();
            f.Dispose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frm_tanimlar_kullanici f = new frm_tanimlar_kullanici();
            f.ShowDialog();
            f.Dispose();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frm_tanimlar_Load(object sender, EventArgs e)
        {
           /* baglanti.Open();
            SqlCommand komut = new SqlCommand ("select * from kullanici where KULLANICIID=@id", baglanti);
            komut.Parameters.AddWithValue("@id",frm_kullanicigiris_yüztanima.ID);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (Convert.ToBoolean(dt.Rows[0]["MUSTERILISTE"].ToString())==false)
            {
                button4.Enabled = false;
            }
            if (Convert.ToBoolean(dt.Rows[0]["STOKLISTE"]) == false)
            {
                button1.Enabled = false;
            }
            if (Convert.ToBoolean(dt.Rows[0]["DEPOLISTE"]) == false)
            {
                button3.Enabled = false;
            }
            if (Convert.ToBoolean(dt.Rows[0]["SATISLISTE"]) == false)
            {
                button6.Enabled = false;
            }
            if (Convert.ToBoolean(dt.Rows[0]["SATIS"]) == false)
            {
                button2.Enabled = false;
            }
            if (Convert.ToBoolean(dt.Rows[0]["KULLANICILISTE"]) == false)
            {
                button5.Enabled = false;
            }
               baglanti.Close();*/
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frm_kullanici_giris f = new frm_kullanici_giris();
            f.Show();
            this.Close();
        }

        private void frm_tanimlar_KeyUp(object sender, KeyEventArgs e)//kısayol tuşuyla yetkiye göre butonları gösterme
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from kullanici where KULLANICIID=@id", baglanti);
            komut.Parameters.AddWithValue("@id", frm_kullanici_giris.ID);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (e.Control && e.KeyCode == Keys.S && Convert.ToBoolean(dt.Rows[0]["STOKLISTE"]) == true)
            {
                button1_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.S && Convert.ToBoolean(dt.Rows[0]["STOKLISTE"]) == false)
            {
                MessageBox.Show("YETKİNİZ YOKTUR.");
            }

            if (e.Control && e.KeyCode == Keys.M && Convert.ToBoolean(dt.Rows[0]["MUSTERILISTE"]) == true)
            {
                button4_Click(sender, e);
            }
            else if(e.Control && e.KeyCode == Keys.M && Convert.ToBoolean(dt.Rows[0]["MUSTERILISTE"]) == false)
            {
                MessageBox.Show("YETKİNİZ YOKTUR.");
            }
            if (e.Control && e.KeyCode == Keys.K && Convert.ToBoolean(dt.Rows[0]["KULLANICILISTE"]) == true)
            {
                button5_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.K && Convert.ToBoolean(dt.Rows[0]["KULLANICILISTE"]) == false)
            {
                MessageBox.Show("YETKİNİZ YOKTUR.");
            }
            if (e.Control && e.KeyCode == Keys.D && Convert.ToBoolean(dt.Rows[0]["DEPOLISTE"]) == true)
            {
                button3_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.D && Convert.ToBoolean(dt.Rows[0]["DEPOLISTE"]) == false)
            {
                MessageBox.Show("YETKİNİZ YOKTUR.");
            }
          
            if (e.Control && e.KeyCode == Keys.A && Convert.ToBoolean(dt.Rows[0]["SATIS"]) == true)
            {
                button2_Click(sender, e);
            }
          else if (e.Control && e.KeyCode == Keys.A && Convert.ToBoolean(dt.Rows[0]["SATIS"]) == false)
            {
                MessageBox.Show("YETKİNİZ YOKTUR.");
            }
            if (e.Control && e.KeyCode == Keys.L && Convert.ToBoolean(dt.Rows[0]["SATISLISTE"]) == true)
            {
                button6_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.L && Convert.ToBoolean(dt.Rows[0]["SATISLISTE"]) == false)
            {
                MessageBox.Show("YETKİNİZ YOKTUR.");
            }
            baglanti.Close();
        }
    }
}
