﻿using System;
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
    public partial class pharmacyHome : Form
    {
        public pharmacyHome()
        {
            InitializeComponent();
        }

        private void doctorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Hide();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void viewDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewPrescription view = new viewPrescription();
            view.Show();
            this.Hide();
        }
    }
}
