using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Globalization;


namespace UAS_OOP_1204027
{
    public partial class DaftarUlang : Form
    {
        private MySqlCommand cmd;
        private DataSet ds;
        private MySqlDataAdapter da;
        private MySqlDataReader rd;

        private void reset_kondisi()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
        }

        void limakosong()
        {
            textBox5.Text = string.Format(new CultureInfo("id-ID"), "{0:C}", double.Parse(textBox4.Text, NumberStyles.Currency) * 0.5);
            textBox6.Text = string.Format(new CultureInfo("id-ID"), "{0:C}", double.Parse(textBox4.Text, NumberStyles.Currency) - double.Parse(textBox5.Text, NumberStyles.Currency));


        }

        void dualima()
        {
            textBox5.Text = string.Format(new CultureInfo("id-ID"), "{0:C}", double.Parse(textBox4.Text, NumberStyles.Currency) * 0.25);
            textBox6.Text = string.Format(new CultureInfo("id-ID"), "{0:C}", double.Parse(textBox4.Text, NumberStyles.Currency) - double.Parse(textBox5.Text, NumberStyles.Currency));
        }
        void sepuluh()
        {
            textBox5.Text = string.Format(new CultureInfo("id-ID"), "{0:C}", double.Parse(textBox4.Text, NumberStyles.Currency) * 0.1);
            textBox6.Text = string.Format(new CultureInfo("id-ID"), "{0:C}", double.Parse(textBox4.Text, NumberStyles.Currency) - double.Parse(textBox5.Text, NumberStyles.Currency));
        }


        public DaftarUlang()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            limakosong();
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dualima();
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            sepuluh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reset_kondisi();
        }
    }
}
