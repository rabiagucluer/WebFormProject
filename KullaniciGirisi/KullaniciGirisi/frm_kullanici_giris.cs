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
using System.Media;

namespace KullaniciGirisi
{
    public partial class frm_kullanici_giris : Form //Partial class bir class' ı birden fazla class olarak bölmemize olanak sağlar.
    {
        public frm_kullanici_giris() 
        {
            InitializeComponent(); //InitializeComponent(); adlı fonksiyon çağırılarak frm_kullanici_giris nesnesine ait olan üye elemanlarla (button,label,textbox vs) ilgili ilk işlemler yapılır
        }

        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-H9K25347;Initial Catalog=KullanıcıGiris;Integrated Security=True");//sunucuya /database ye bağlanıldı.
        public static int ID;
        public static int yetki; 

        private void button2_Click(object sender, EventArgs e)// kapat butonu aktifleştirildi.
        {
            Dispose();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e) // giriş butonu aktifleştirildi.
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from kullanici where KULLANICIAD='" + textBox1.Text + "'and SIFRE='" + textBox2.Text + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                ID = Convert.ToInt32(oku["KULLANICIID"].ToString());
                frm_tanimlar f4 = new frm_tanimlar();
                f4.Show();
                this.Hide();

            if (Convert.ToBoolean(oku["MUSTERILISTE"].ToString()) == false)
            {
                f4.button4.Enabled = false;
            }
            if (Convert.ToBoolean(oku["STOKLISTE"]) == false)
            {
                f4.button1.Enabled = false;
            }
            if (Convert.ToBoolean(oku["DEPOLISTE"]) == false)
            {
                f4.button3.Enabled = false;
            }
            if (Convert.ToBoolean(oku["SATISLISTE"]) == false)
            {
                f4.button6.Enabled = false;
            }
            if (Convert.ToBoolean(oku["SATIS"]) == false)
            {
                f4.button2.Enabled = false;
            }
            if (Convert.ToBoolean(oku["KULLANICILISTE"]) == false)
            {
                f4.button5.Enabled = false;
            }   
            }
            else
            {
                HATACAL();
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı");
            } 
            baglanti.Close();
        }
        void HATACAL()//HATALI BARKOD GİRİLDİĞİ ZAMAN SES ÇALMASI.
        {
            SoundPlayer ses = new SoundPlayer();
            ses.SoundLocation = @"C:\Users\Toshiba\Documents\visual studio 2015\Projects\KullaniciGirisi\KullaniciGirisi\bin\Debug\BARKODHATA.WAV";
            ses.Play();
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("select * from kullanici where KULLANICIAD='" + textBox1.Text + "'and SIFRE='" + textBox2.Text + "'", baglanti);
                SqlDataReader oku = komut.ExecuteReader();        
                if (oku.Read())
                {
                    ID = Convert.ToInt32(oku["KULLANICIID"].ToString());
                    frm_tanimlar f4 = new frm_tanimlar();
                    f4.Show();
                    this.Hide();

                    if (Convert.ToBoolean(oku["MUSTERILISTE"].ToString()) == false)
                    {
                        f4.button4.Enabled = false;
                    }
                    if (Convert.ToBoolean(oku["STOKLISTE"]) == false)
                    {
                        f4.button1.Enabled = false;
                    }
                    if (Convert.ToBoolean(oku["DEPOLISTE"]) == false)
                    {
                        f4.button3.Enabled = false;
                    }
                    if (Convert.ToBoolean(oku["SATISLISTE"]) == false)
                    {
                        f4.button6.Enabled = false;
                    }
                    if (Convert.ToBoolean(oku["SATIS"]) == false)
                    {
                        f4.button2.Enabled = false;
                    }
                    if (Convert.ToBoolean(oku["KULLANICILISTE"]) == false)
                    {
                        f4.button5.Enabled = false;
                    }
                }
                else
                {
                    HATACAL();
                    MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı");
                }
                baglanti.Close();
            }
        }
        
        private void button3_Click(object sender, EventArgs e)
        {  
            frm_kullanicigiris_yüztanima f = new frm_kullanicigiris_yüztanima();
            f.ShowDialog();
            this.Hide();
          
        }
    }
        }

      
    

