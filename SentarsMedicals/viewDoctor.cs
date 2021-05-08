
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SentarsMedicals
{
    public partial class viewDoctor : Form
    {
        FirestoreDb db;
        FirestoreDb database;
        public viewDoctor()
        {
            InitializeComponent();
        }

        private void display_Click(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"sentars-medicals-firebase-adminsdk-uff2i-a5b1ff40cd.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            db = FirestoreDb.Create("sentars-medicals");

            dataGridView1.Rows.Clear();
            GetAllDocument("doctor");


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            textBox1.Text = selectedRow.Cells[0].Value.ToString();
            tnic.Text = selectedRow.Cells[1].Value.ToString();
            tfname.Text = selectedRow.Cells[2].Value.ToString();
            tlname.Text = selectedRow.Cells[3].Value.ToString();
            temail.Text = selectedRow.Cells[4].Value.ToString();
            tcno.Text = selectedRow.Cells[5].Value.ToString();
            tsarea.Text = selectedRow.Cells[6].Value.ToString();
            tpass.Text = selectedRow.Cells[7].Value.ToString();
            tabout.Text = selectedRow.Cells[8].Value.ToString();
            // byte[] img = (byte[])selectedRow.Cells[8].Value;
            tdate.Text = selectedRow.Cells[9].Value.ToString();




        }

        private void back_Click(object sender, EventArgs e)
        {
            adminHome ahome = new adminHome();
            ahome.Show();
            this.Hide();
        }

        private async void update_ClickAsync(object sender, EventArgs e)
        {
            UpdateDocument();
        }

        private async void delete_ClickAsync(object sender, EventArgs e)
        {
            DocumentReference docref = db.Collection("doctor").Document(textBox1.Text);
            docref.DeleteAsync();
            MessageBox.Show("Doctor deleted successfully");
            
        }

        async void GetAllDocument(string nameofCollection)
        {
            Query doctor = db.Collection(nameofCollection);
            QuerySnapshot snap = await doctor.GetSnapshotAsync();

            foreach (DocumentSnapshot docsnap in snap.Documents)
            {
                docinfo docinfo = docsnap.ConvertTo<docinfo>();

                if (docsnap.Exists)
                {
                    dataGridView1.Rows.Add(docsnap.Id, docinfo.NIC, docinfo.Fname, docinfo.Lname, docinfo.Email, docinfo.ContactNo, docinfo.Sarea, docinfo.Password, docinfo.About, docinfo.Date);
                }
            }
        }

        async void UpdateDocument()
        {


            DocumentReference document = db.Collection("doctor").Document(textBox1.Text);
            Dictionary<string, object> data = new Dictionary<string, object>()
            {
                {"NIC", tnic.Text },
                {"Fname", tfname.Text },
                {"Lname", tlname.Text },
                {"Email", temail.Text },
                {"ContactNo", tcno.Text },
                {"Sarea", tsarea.Text },
                {"Password", tpass.Text },
                {"About", tabout.Text },
                {"Date", tdate.Text },

            };

            DocumentSnapshot snap = await document.GetSnapshotAsync();
            if (snap.Exists)
            {
                await document.UpdateAsync(data);
            }

            MessageBox.Show("Information updated Successfully");

        }

        private void search_Click(object sender, EventArgs e)
        {
            searchEmail("doctor", docsearch.Text.ToString());
        }

        async void searchEmail(string a, string b)
        {
            database = FirestoreDb.Create("sentars-medicals");

            Query doc = database.Collection(a).WhereEqualTo("NIC", b);
            QuerySnapshot snap = await doc.GetSnapshotAsync();

            foreach (DocumentSnapshot docsnap in snap.Documents)
            {
                docinfo docinfo = docsnap.ConvertTo<docinfo>();

                if (docsnap.Exists)
                {
                    dataGridView1.Rows.Add(docsnap.Id, docinfo.NIC, docinfo.Fname, docinfo.Lname, docinfo.Email, docinfo.ContactNo, docinfo.Sarea, docinfo.Password, docinfo.About, docinfo.Date);
                }
            }









        }

       
    }
}
