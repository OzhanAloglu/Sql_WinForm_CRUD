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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormUygulama
{
    public partial class Form1 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=ALOGLU\\SQLEXPRESS;Initial Catalog=Kayıt;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();

        }

        int sayac = 1;

        private void verigöster()
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Kayıtbilgi", baglanti);
            DataSet dt = new DataSet();
            da.Fill(dt);
            dataGridView1.DataSource = dt.Tables[0];
            baglanti.Close();



        }



        private void btn_ekle_Click(object sender, EventArgs e)
        {


            SqlCommand komut = new SqlCommand("insert into Kayıtbilgi(TC,ADISOYADI,YAŞI,MEZUNİYETİ,CİNSİYET,DOĞUMYERİ,TELEFON) values (@V1,@V2,@V3,@V4,@V5,@V6,@V7)", baglanti);

            komut.Parameters.AddWithValue("@V1", mskd_tc.Text);
            komut.Parameters.AddWithValue("@V2", txt_adısoyadı.Text);
            komut.Parameters.AddWithValue("@V3", txt_yas.Text);
            komut.Parameters.AddWithValue("@V4", txt_Mezuniyet.Text);

            string cinsi;

            if (radio_bay.Checked)
            {
                cinsi = "Bay";
                komut.Parameters.AddWithValue("@V5", cinsi.ToString());
            }

            else if (radio_bayan.Checked)
            {
                cinsi = "Bayan";
                komut.Parameters.AddWithValue("@V5", cinsi.ToString());
            }

            else
            {
                MessageBox.Show("Lütfen cinsiyet seçiniz");
            }

            komut.Parameters.AddWithValue("@V6", txt_dogumyeri.Text);
            komut.Parameters.AddWithValue("@V7", mskd_tel.Text);

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            label8.Text = sayac.ToString();
            label8.Text = sayac++.ToString();
            verigöster();
        }






        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete From Kayıtbilgi where TC=@V1", baglanti);
            komutsil.Parameters.AddWithValue("@V1", mskd_tc.Text);
            komutsil.ExecuteNonQuery();
            label8.Text = sayac--.ToString();
            if (sayac == -1)
            {
                MessageBox.Show("Silinecek bişey kalmadı zorlama!");
            }
            baglanti.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            verigöster();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            mskd_tc.Clear();
            txt_adısoyadı.Clear();
            txt_dogumyeri.Clear();
            txt_Mezuniyet.Clear();
            txt_yas.Clear();
            mskd_tel.Clear();

            SqlCommand komut = new SqlCommand("insert into Kayıtbilgi(TC,ADISOYADI,YAŞI,MEZUNİYETİ,CİNSİYET,DOĞUMYERİ,TELEFON) values (@V1,@V2,@V3,@V4,@V5,@V6,@V7)", baglanti);

            komut.Parameters.AddWithValue("@V1", mskd_tc.Text);
            komut.Parameters.AddWithValue("@V2", txt_adısoyadı.Text);
            komut.Parameters.AddWithValue("@V3", txt_yas.Text);
            komut.Parameters.AddWithValue("@V4", txt_Mezuniyet.Text);

            string cinsi;

            if (radio_bay.Checked)
            {
                cinsi = "Bay";
                komut.Parameters.AddWithValue("@V5", cinsi.ToString());
            }

            else if (radio_bayan.Checked)
            {
                cinsi = "Bayan";
                komut.Parameters.AddWithValue("@V5", cinsi.ToString());
            }

            else
            {
                MessageBox.Show("Lütfen cinsiyet seçiniz");
            }

            komut.Parameters.AddWithValue("@V6", txt_dogumyeri.Text);
            komut.Parameters.AddWithValue("@V7", mskd_tel.Text);

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            verigöster();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count>0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
        }
    }
}
