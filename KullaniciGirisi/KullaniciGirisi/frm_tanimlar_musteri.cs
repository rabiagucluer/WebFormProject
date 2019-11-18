﻿using System;
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
    public partial class frm_tanimlar_musteri : Form
    {
        public frm_tanimlar_musteri()
        {
            InitializeComponent();
        }

        public static SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-H9K25347;Initial Catalog=KullanıcıGiris;Integrated Security=True");
        
        public static DataRow MODALRESULT = null;
        public static DataRow ac()
        {
            frm_tanimlar_musteri f = new frm_tanimlar_musteri();
            f.ShowDialog();
            f.Dispose();
            return MODALRESULT;
        }
        public void verilerigöster()
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select MUSTERIID[Müşteri ID],MUSTERIAD[Müşteri Ad],MUSTERISOYAD[Müşteri Soyad],MUSTERIADRES[Müşteri Adres],MUSTERIMAIL[Müşteri Mail] from musteri",baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            baglanti.Close();

        }
        private void frm_tanim_musteri_Load(object sender, EventArgs e)
        {
            verilerigöster();
            dataGridView1.MouseClick += new MouseEventHandler(dataGridView1_MouseClick);
        }

       

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (dataGridView1.CurrentCell.RowIndex) + 1;
            frm_tanimlar_musteri_musterikayit.ac(id);
            verilerigöster();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MODALRESULT = (dataGridView1.DataSource as DataTable).Rows[dataGridView1.CurrentCell.RowIndex];
            this.Close();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
            }
            else
            {
                ContextMenuStrip menu = new System.Windows.Forms.ContextMenuStrip();
            }
        }

        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_tanimlar_musteri_musterikayit.ac(0);
            verilerigöster();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
