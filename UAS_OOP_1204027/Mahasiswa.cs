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
    public partial class Mahasiswa : Form
    {

        private MySqlCommand cmd;
        private DataSet ds;
        private MySqlDataAdapter da;
        private MySqlDataReader rd;

        private string random()
        {
            long npm;
            string urutan;
            db database = new db();
            MySqlConnection conn = database.GetConn();
            conn.Open();
            cmd = new MySqlCommand("select npm from ms_mhs where npm in(select max(npm) from ms_mhs) order by npm desc", conn);
            rd = cmd.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                npm = Convert.ToInt64(rd[0].ToString().Substring(rd["npm"].ToString().Length - 3, 3)) + 1;
                string joinstr = "000" + npm;
                urutan = "120" + joinstr.Substring(joinstr.Length - 3, 3);

            }
            else
            {
                urutan = "120001";
            }
            rd.Close();
            conn.Close();

            return urutan;
        }

        private void get_prodi_list()
        {
            db database = new db();
            MySqlDataReader rd;
            MySqlConnection conn = database.GetConn();
            conn.Open();

            cmd = new MySqlCommand("select * from ms_prodi", conn);
            cmd.CommandType = CommandType.Text;
            rd = cmd.ExecuteReader();

            while (rd.Read())
            {

                comboBox1.Items.Add(rd[0].ToString());

            }
            rd.Close();
            conn.Close();

        }

        private void clear_textbox()
        {
            textBox1.Text = "";
            textBox3.Text = "";
            comboBox1.ResetText();
        }

        private void set_dataset()
        {
            string url = "Server=localhost;Database=UAS;Uid=root;Pwd=;";
            MySqlConnection conn = new MySqlConnection(url);
            conn.Open();
            cmd = new MySqlCommand("SELECT * FROM ms_mhs", conn);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);

            da.Fill(ds, "ms_mhs");
            ds_mhs.DataSource = ds;
            ds_mhs.DataMember = "ms_mhs";
            ds_mhs.AllowUserToAddRows = false;
            ds_mhs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ds_mhs.Refresh();
        }

        public Mahasiswa()
        {
            InitializeComponent();
            set_dataset();
            get_prodi_list();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            set_dataset();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ds_mhs_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
