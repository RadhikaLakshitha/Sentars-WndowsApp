using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SentarsMedicals
{
    public partial class adminHome : Form
    {
        

        public adminHome()
        {
            InitializeComponent();
        }



        private void registerDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            regDoctor rdoc = new regDoctor();
            rdoc.Show();
            this.Hide();
        }

        private void viewDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewDoctor vdoc = new viewDoctor();
            vdoc.Show();
            this.Hide();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Hide();
        }
    }
}
