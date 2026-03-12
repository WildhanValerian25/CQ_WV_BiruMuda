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

        private void Koneksi()
        {
            conn = new SqlConnection(
                "Data Source=LAPTOP-24A5CGHI\\WILDHANFIGHT;Initial Catalog=DBAkademikADO;Integrated Security=True"
            );
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
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
