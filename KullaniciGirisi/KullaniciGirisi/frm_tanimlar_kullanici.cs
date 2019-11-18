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
    public partial class frm_tanimlar_kullanici : Form
    {
        public frm_tanimlar_kullanici()
        {
            InitializeComponent();
        }
        public static SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-H9K25347;Initial Catalog=KullanıcıGiris;Integrated Security=True");

        public static DataRow MODALRESULT = null;

        public static DataRow ac()
        {
            frm_tanimlar_kullanici f = new frm_tanimlar_kullanici();
            f.ShowDialog();
            f.Dispose();
            return MODALRESULT;
        }
        public void verilerigöster()
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select KULLANICIID[Kullanıcı ID],KULLANICIAD[Kullanıcı Ad],KULLANICISOYAD[Kullanıcı Soyad] from kullanici", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            baglanti.Close();

        }
        private void frm_tanimlar_kullanici_Load(object sender, EventArgs e)
        {
            verilerigöster();
            dataGridView1.MouseClick += new MouseEventHandler(dataGridView1_MouseClick);
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

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (dataGridView1.CurrentCell.RowIndex) + 1;
            frm_tanimlar_kullanici_kullanicikayit.ac(id);
            verilerigöster();
        }

        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_tanimlar_kullanici_kullanicikayit.ac(0);
            verilerigöster();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MODALRESULT = (dataGridView1.DataSource as DataTable).Rows[dataGridView1.CurrentCell.RowIndex];
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
