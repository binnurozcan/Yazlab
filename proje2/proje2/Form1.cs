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

namespace proje2
{

    public partial class Form1 : Form
    {
   
        public Form1()
        {
            InitializeComponent();
         
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }



        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'dersProgramiDataSet.kisitlar' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.kisitlarTableAdapter.Fill(this.dersProgramiDataSet.kisitlar);
            // TODO: Bu kod satırı 'dersProgramiDataSet.ders' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.dersTableAdapter.Fill(this.dersProgramiDataSet.ders);
            // TODO: Bu kod satırı 'dersProgramiDataSet.akademisyen' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.akademisyenTableAdapter.Fill(this.dersProgramiDataSet.akademisyen);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Yeni akademisyen ekleme
            akademisyenBindingSource.AddNew();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            // Akademisyen verilerini güncelleme ve kaydetme
            // Veri düzenlemeyi bitir
            akademisyenBindingSource.EndEdit();

            akademisyenTableAdapter.Update(dersProgramiDataSet);

            // Başarıyla güncellendi
            MessageBox.Show("KAYDEDILDI", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Seçili akademisyeni silme
            akademisyenBindingSource.RemoveCurrent();

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

            dersBindingSource.AddNew();
           

        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Ders verilerini güncelleme ve kaydetme
            dersBindingSource.EndEdit();
            dersTableAdapter.Update(dersProgramiDataSet);

            // Başarıyla güncellendi
            MessageBox.Show("KAYDEDILDI", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            dersBindingSource.RemoveCurrent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        //private void button10_Click(object sender, EventArgs e)
       // {
        //    kisitlarBindingSource.AddNew();
        //}

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
           
        }

     

        private void button11_Click(object sender, EventArgs e)
        {
            // Seçili kısıtları silme
            kisitlarBindingSource.EndEdit();

            kisitlarTableAdapter.Update(dersProgramiDataSet);
            kisitlarBindingSource.RemoveCurrent();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            // Kısıtlar verilerini güncelleme ve kaydetme
            // Veri düzenlemeyi bitir
            kisitlarBindingSource.EndEdit();

                // Veritabanını güncelle
            kisitlarTableAdapter.Update(dersProgramiDataSet);


                // Başarıyla güncellendi
            MessageBox.Show("KAYDEDILDI", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox4_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label8_Click_2(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            kisitlarBindingSource.RemoveCurrent();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            kisitlarBindingSource.AddNew();
        }

        private void button12_Click_1(object sender, EventArgs e)
        {

            kisitlarBindingSource.EndEdit();

            kisitlarTableAdapter.Update(dersProgramiDataSet);

            // Başarıyla güncellendi
            MessageBox.Show("KAYDEDILDI", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}