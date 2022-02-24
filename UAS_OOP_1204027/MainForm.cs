using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace UAS_OOP_1204027
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void mahasiswaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mahasiswa mhs = new Mahasiswa();
            mhs.Show();
        }

        private void prodiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Prodi prod = new Prodi();
            prod.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DaftarUlang du = new DaftarUlang();
            du.Show();
        }
    }
}
