using Google.Cloud.Firestore;
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
    public partial class viewPrescription : Form
    {
        FirestoreDb db;
        FirestoreDb database;
        public viewPrescription()
        {
            InitializeComponent();
        }

        
        private void dregview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = presview.Rows[index];
            chno.Text = selectedRow.Cells[1].Value.ToString();
            date.Text = selectedRow.Cells[6].Value.ToString();
            name.Text = selectedRow.Cells[2].Value.ToString();
            prob.Text = selectedRow.Cells[4].Value.ToString();
            pres.Text = selectedRow.Cells[5].Value.ToString();
            
        }

        private void viewPrescription_Load(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"sentars-medicals-firebase-adminsdk-uff2i-a5b1ff40cd.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            db = FirestoreDb.Create("sentars-medicals");

            
        }

        async void GetAllDocument(string v, string u, string w)
        {
            Query pres = db.Collection(v).Document(u).Collection(w);
            QuerySnapshot snap = await pres.GetSnapshotAsync();

            

            foreach (DocumentSnapshot pressnap in snap.Documents)
            {
                presInfo docinfo = pressnap.ConvertTo<presInfo>();

                if (pressnap.Exists)
                {
                    presview.Rows.Add(pressnap.Id, docinfo.channelNo, docinfo.username, docinfo.userEmail, docinfo.problem, docinfo.prescription, docinfo.date);

                }
                else
                {
                    MessageBox.Show("Some information are missing");
                }
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            GetAllDocument("prescription", searchval.Text.ToString(), "preslist");
        }

        private void print_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
                DateTime thisDay = DateTime.Now;
                e.Graphics.DrawString("Sentars Medicals", new Font("Times New Roman", 22, FontStyle.Bold), Brushes.Black, new Point(300, 50));
                e.Graphics.DrawString("Private Hospital PLC Ltd", new Font("Times New Roman", 18, FontStyle.Bold), Brushes.Black, new Point(275, 80));
                e.Graphics.DrawString("157/1, Pitipana North, Homagama", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(285, 108));
                e.Graphics.DrawString(thisDay.ToString(), new Font("Times New Roman", 10, FontStyle.Bold), Brushes.Black, new Point(350, 128));
                e.Graphics.DrawString("-----------------------------------------------------------------------------------------------------------------------------------", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(50, 145));
                e.Graphics.DrawString("Channel No  ", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new Point(130, 230));
                e.Graphics.DrawString(":  ", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new Point(250, 230));
                e.Graphics.DrawString(chno.Text, new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new Point(290, 230));
                e.Graphics.DrawString("Date", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new Point(130, 280));
                e.Graphics.DrawString(":", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new Point(250, 280));
                e.Graphics.DrawString(date.Text, new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new Point(290, 280));
                e.Graphics.DrawString("Name", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new Point(130, 330));
                e.Graphics.DrawString(":", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new Point(250, 330));
                e.Graphics.DrawString(name.Text, new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new Point(290, 330));
                e.Graphics.DrawString("Problem", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new Point(130, 380));
                e.Graphics.DrawString(":", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new Point(250, 380));
                e.Graphics.DrawString(prob.Text, new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new Point(290, 380));
                e.Graphics.DrawString("Prescription", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new Point(130, 430));
                e.Graphics.DrawString(":", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new Point(250, 430));
                e.Graphics.DrawString(pres.Text, new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new Point(290, 430));
                e.Graphics.DrawString("-----------------------------------------------------------------------------------------------------------------------------------", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(50, 950));
                e.Graphics.DrawString("Your health is our priority", new Font("Times New Roman", 10, FontStyle.Bold), Brushes.Black, new Point(340, 970));
                e.Graphics.DrawString("Thank you", new Font("Times New Roman", 10, FontStyle.Bold), Brushes.Black, new Point(380, 990));




        }

        private void back_Click(object sender, EventArgs e)
        {
            pharmacyHome phome = new pharmacyHome();
            phome.Show();
            this.Hide();
        }

        
    }
}
