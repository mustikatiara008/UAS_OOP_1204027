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

namespace UAS_OOP_1204027
{
    public partial class Prodi : Form
    {
        private MySqlCommand cmd;
        private DataSet ds;
        private MySqlDataAdapter da;
        private MySqlDataReader rd;

        private string random()
        {
            long prodi;
            string urutan;
            db database = new db();
            MySqlConnection conn = database.GetConn();
            conn.Open();
            cmd = new MySqlCommand("select kode_prodi from ms_prodi where kode_prodi in(select max(kode_prodi) from ms_prodi) order by kode_prodi desc", conn);
            rd = cmd.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                prodi = Convert.ToInt64(rd[0].ToString().Substring(rd["kode_prodi"].ToString().Length - 3, 3)) + 1;
                string joinstr = "000" + prodi;
                urutan = "PRD" + joinstr.Substring(joinstr.Length - 3, 3);

            }
            else
            {
                urutan = "PRD001";
            }
            rd.Close();
            conn.Close();

            return urutan;
        }
        private void clear_textbox()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        private void set_dataset()
        {
            string url = "Server=localhost;Database=UAS;Uid=root;Pwd=;";
            MySqlConnection conn = new MySqlConnection(url);
            conn.Open();
            cmd = new MySqlCommand("SELECT * FROM ms_prodi", conn);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);

            da.Fill(ds, "ms_prodi");
            ds_prodi.DataSource = ds;
            ds_prodi.DataMember = "ms_prodi";
            ds_prodi.AllowUserToAddRows = false;
            ds_prodi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ds_prodi.Refresh();
        }
        public Prodi()
        {
            InitializeComponent();
            set_dataset();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            set_dataset();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void ds_prodi_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
