using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmModifTuple : Form
    {
        public frmModifTuple()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmModifTuple_FormClosing(object sender, FormClosingEventArgs e)
        {
            Text_modif = txtModif.Text;
        }
    }
}
