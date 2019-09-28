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

namespace VeriTabanınaResimEkleme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-T2GKN5C\SQLEXPRESS;Initial Catalog=Dbo_FilmArsiv;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbo_FilmArsivDataSet.Tbl_Filmler' table. You can move, or remove it, as needed.
            this.tbl_FilmlerTableAdapter.Fill(this.dbo_FilmArsivDataSet.Tbl_Filmler);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            txtresim.Text = openFileDialog1.FileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Filmler(FilmAd,FilmTur,FilmPaun,FilmKategori,FilmResim) values (@p1,@p2,@p3,@p4,@p5)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txttur.Text);
            komut.Parameters.AddWithValue("@p3",float.Parse( txtpuan.Text));
            komut.Parameters.AddWithValue("@p4", txtkategori.Text);
            komut.Parameters.AddWithValue("@p5", txtresim.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("İşlem Tamamlandı.");
            baglanti.Close();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txttur.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtpuan.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtkategori.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtresim.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            pictureBox1.ImageLocation= dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }
    }
}
