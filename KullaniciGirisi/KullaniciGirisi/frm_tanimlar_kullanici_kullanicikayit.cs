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
using System.IO;

namespace KullaniciGirisi
{
    public partial class frm_tanimlar_kullanici_kullanicikayit : Form
    {
        public frm_tanimlar_kullanici_kullanicikayit()
        {
            InitializeComponent();
        }
        public static SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-H9K25347;Initial Catalog=KullanıcıGiris;Integrated Security=True");

        public static int item;
        public static int ac(int id)
        {
            frm_tanimlar_kullanici_kullanicikayit f = new frm_tanimlar_kullanici_kullanicikayit();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from kullanici where KULLANICIID=@ID", baglanti);
            komut.Parameters.AddWithValue("@ID", id);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            item = id;
            if (id != 0)
            {
                f.textBox1.Text = dt.Rows[0]["KULLANICIID"].ToString();
                f.textBox2.Text = dt.Rows[0]["KULLANICIAD"].ToString();
                f.textBox3.Text = dt.Rows[0]["KULLANICISOYAD"].ToString();
                f.textBox5.Text = dt.Rows[0]["SIFRE"].ToString();
                f.checkBox1.Checked = Convert.ToBoolean(dt.Rows[0]["MUSTERILISTE"]);
                f.checkBox2.Checked = Convert.ToBoolean(dt.Rows[0]["STOKLISTE"]);
                f.checkBox3.Checked = Convert.ToBoolean(dt.Rows[0]["DEPOLISTE"]);
                f.checkBox4.Checked = Convert.ToBoolean(dt.Rows[0]["SATISLISTE"]);
                f.checkBox5.Checked = Convert.ToBoolean(dt.Rows[0]["SATIS"]);
                f.checkBox6.Checked = Convert.ToBoolean(dt.Rows[0]["KULLANICILISTE"]);
                f.textBox4.Text=dt.Rows[0]["RESIM"].ToString();
                
            }
            else
            {
                MessageBox.Show("YENİ KULLANICI EKLEYİNİZ");
            }
            
            baglanti.Close();
            da.Dispose();
            dt.Dispose();
            f.ShowDialog();
            f.Dispose();
            return id;
        }

        private void frm_tanimlar_kullanici_kullanicikayit_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = openFileDialog1.FileName;
          //ListView1.Columns.Add("Dosya yolu");
          //ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            if (item != 0)
            {
                SqlCommand komut = new SqlCommand("UPDATE kullanici SET KULLANICIAD=@2,SIFRE=@5,KULLANICISOYAD=@3,MUSTERILISTE=@6,STOKLISTE=@7,DEPOLISTE=@8,SATISLISTE=@9,SATIS=@10,KULLANICILISTE=@11,RESIM=@resim WHERE KULLANICIID=@1", baglanti);
                komut.Parameters.AddWithValue("@1", textBox1.Text);
                komut.Parameters.AddWithValue("@2", textBox2.Text);
                komut.Parameters.AddWithValue("@3", textBox3.Text);
                komut.Parameters.AddWithValue("@5", textBox5.Text);
                komut.Parameters.AddWithValue("@6", checkBox1.Checked);
                komut.Parameters.AddWithValue("@7", checkBox2.Checked);
                komut.Parameters.AddWithValue("@8", checkBox3.Checked);
                komut.Parameters.AddWithValue("@9", checkBox4.Checked);
                komut.Parameters.AddWithValue("@10", checkBox5.Checked);
                komut.Parameters.AddWithValue("@11", checkBox6.Checked);
                komut.Parameters.AddWithValue("@resim", textBox4.Text);
                komut.ExecuteNonQuery();
            }
            else
            {
                SqlCommand komut = new SqlCommand("INSERT INTO kullanici(KULLANICIAD,KULLANICISOYAD,SIFRE,MUSTERILISTE,STOKLISTE,DEPOLISTE,SATISLISTE,SATIS,KULLANICILISTE,RESIM) VALUES(@2,@3,@5,@6,@7,@8,@9,@10,@11,@resim) ", baglanti);
                  
                komut.Parameters.AddWithValue("@2", textBox2.Text);
                komut.Parameters.AddWithValue("@3", textBox3.Text);
                komut.Parameters.AddWithValue("@5", textBox5.Text);
                komut.Parameters.AddWithValue("@6", checkBox1.Checked);
                komut.Parameters.AddWithValue("@7", checkBox2.Checked);
                komut.Parameters.AddWithValue("@8", checkBox3.Checked);
                komut.Parameters.AddWithValue("@9", checkBox4.Checked);
                komut.Parameters.AddWithValue("@10", checkBox5.Checked);
                komut.Parameters.AddWithValue("@11", checkBox6.Checked);
                komut.Parameters.AddWithValue("@resim", textBox4.Text);
                komut.ExecuteNonQuery();
            }

            baglanti.Close();
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
             
             openFileDialog1.ShowDialog();
             openFileDialog1.Filter = "Jpg Görsel | *.jpg";
             openFileDialog1.Multiselect = true;
             pictureBox1.ImageLocation = openFileDialog1.FileName;
             textBox4.Text = openFileDialog1.FileName;

           /*  try
            {
                
                OpenFileDialog myFileDialog = new OpenFileDialog();
                DialogResult dr = new DialogResult();
                myFileDialog.Title = "Dosya ekle";
                myFileDialog.InitialDirectory = @"C:"; 
                myFileDialog.Filter= "Jpg Görsel | *.jpg";
                myFileDialog.Multiselect = true;
                dr = myFileDialog.ShowDialog(); 
                string[] fileNames = myFileDialog.FileNames;
                myFileDialog.CheckFileExists = true;
                myFileDialog.CheckPathExists = true;
 
                if (dr == DialogResult.OK)
                {
                    string[] dosya = fileNames;
                    for (int i = 0; i < fileNames.Length; i++)
                    {
                        ListViewItem li = new ListViewItem(dosya[i]); 
                        ListView1.Items.Add(li);
                    }
                    label6.Text = dosya.Length.ToString() + " dosya eklendi.";
                }
                else
                {
                    return;
                }
            }
            
            catch (Exception)
            {

                return;
            } */

        }
    }
}
