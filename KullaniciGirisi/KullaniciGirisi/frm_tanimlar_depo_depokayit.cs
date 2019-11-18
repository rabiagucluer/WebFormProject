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
    public partial class frm_tanimlar_depo_depokayit : Form
    {
        public frm_tanimlar_depo_depokayit()
        {
            InitializeComponent();
        }
        public static SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-H9K25347;Initial Catalog=KullanıcıGiris;Integrated Security=True");

        public static int item;
       
        public static int AC(int id)
        {
            
            frm_tanimlar_depo_depokayit depo = new frm_tanimlar_depo_depokayit();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select DEPOID,KOD,ISIM,ADRES,AKTIF from depotanim where DEPOID=@ID", baglanti);
            komut.Parameters.AddWithValue("@ID", id);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            item = id;
            if (id != 0)
            {    
                 depo.textBox1.Text = tablo.Rows[0]["KOD"].ToString();
                 depo.textBox2.Text = tablo.Rows[0]["ISIM"].ToString();
                 depo.textBox3.Text = tablo.Rows[0]["ADRES"].ToString();
                 depo.checkBox1.Checked = Convert.ToBoolean(tablo.Rows[0]["AKTIF"]);
                 depo.textBox4.Text = tablo.Rows[0]["DEPOID"].ToString();
            }
            else
            {
                MessageBox.Show("YENİ DEPO EKLEYİNİZ");
            }

            baglanti.Close();
            da.Dispose();
            tablo.Dispose();
            depo.ShowDialog();
            depo.Dispose();
            return id;
        }

        private void frm_tanim_depo_bilgi_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            if (item != 0)
            {
               
                SqlCommand komut = new SqlCommand("UPDATE depotanim SET ISIM=@NAME,KOD=@KOD,ADRES=@ADRES,AKTIF=@AKTIF WHERE DEPOID=@ID", baglanti);
                komut.Parameters.AddWithValue("@KOD", textBox1.Text);
                komut.Parameters.AddWithValue("@NAME", textBox2.Text);   
                komut.Parameters.AddWithValue("@ADRES", textBox3.Text);
                komut.Parameters.AddWithValue("@AKTIF", checkBox1.Checked);
                komut.Parameters.AddWithValue("@ID",item);
                komut.ExecuteNonQuery();
            }
            else
            {
                SqlCommand komut = new SqlCommand("INSERT INTO depotanim(KOD,ISIM,ADRES,AKTIF) VALUES(@KOD,@NAME,@ADRES,@AKTIF) ", baglanti);
                komut.Parameters.AddWithValue("@KOD", textBox1.Text);
                komut.Parameters.AddWithValue("@NAME", textBox2.Text);  
                komut.Parameters.AddWithValue("@ADRES", textBox3.Text);
                komut.Parameters.AddWithValue("@AKTIF", checkBox1.Checked);
                komut.Parameters.AddWithValue("@DEPOID",item);
                komut.ExecuteNonQuery();
            }

            baglanti.Close();
            this.Dispose();
        }
    }
}
