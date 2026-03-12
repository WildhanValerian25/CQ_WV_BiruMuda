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

namespace PraktikumADO
{
    public partial class Form1 : Form
    {

        // "Tambah variabel SqlConnection dan SqlCommand"
        SqlConnection conn;
        SqlCommand cmd;
        public Form1()
        {
            InitializeComponent();
        }

        // Menambhakn fungsi koneksi ke database 
        private void Koneksi()
        {
            conn = new SqlConnection(
                "Data Source=NAMA_SERVER_KAMU;Initial Catalog=DBAkademikADO;Integrated Security=True"
            );
            // Menambahkan Validasi cek status Koneksi
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        // Menambahkan fungsi tombol connect
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();
                MessageBox.Show("Koneksi ke database berhasil!");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //  Menghitung jumlah mahasiswa menggunakan ExecuteScalar
        private void btnHitungMhs_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();
                string query = "SELECT COUNT(*) FROM Mahasiswa";
                cmd = new SqlCommand(query, conn);
                int jumlah = (int)cmd.ExecuteScalar();
                txtHasil.Text = jumlah.ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // Tambah fungsi ExecuteScalar hitung mata kuliah
        private void btnHitungMK_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();
                string query = "SELECT COUNT(*) FROM MataKuliah";
                cmd = new SqlCommand(query, conn);
                int jumlah = (int)cmd.ExecuteScalar();
                txtHasil.Text = jumlah.ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // Menambahkan fungsi ExecuteNonQuery update mahasiswa
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();
                string query = "UPDATE Mahasiswa SET Alamat='Yogyakarta' WHERE NIM='23110100001'";
                cmd = new SqlCommand(query, conn);
                int hasil = cmd.ExecuteNonQuery();
                MessageBox.Show("Jumlah baris terpengaruh : " + hasil);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // Menambahkan fungsi untuk hitung jumlah dosen
        private void btnHitungDosen_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();
                string query = "SELECT COUNT(*) FROM Dosen";
                cmd = new SqlCommand(query, conn);
                int jumlah = (int)cmd.ExecuteScalar();
                txtHasil.Text = jumlah.ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // Menambahkan  fungsi update SKS mata kuliah
        private void btnUpdateMK_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();
                string query = "UPDATE MataKuliah SET SKS=4 WHERE KodeMK='IF210101'";
                cmd = new SqlCommand(query, conn);
                int hasil = cmd.ExecuteNonQuery();
                MessageBox.Show("Jumlah baris terpengaruh : " + hasil);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // Menambahkan fungsi insert program studi 
        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();
                string query = "INSERT INTO ProgramStudi VALUES('MI01','Manajemen Informatika')";
                cmd = new SqlCommand(query, conn);
                int hasil = cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil ditambahkan! Baris terpengaruh : " + hasil);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
