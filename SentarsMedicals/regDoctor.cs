using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SentarsMedicals
{

    public partial class regDoctor : Form
    {
        FirestoreDb db;
        private BindingSource NameBindingSource;

        public regDoctor()
        {
            InitializeComponent();


        }

        private void back_Click(object sender, EventArgs e)
        {
            adminHome ahome = new adminHome();
            ahome.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void regDoctor_Load(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"sentars-medicals-firebase-adminsdk-uff2i-a5b1ff40cd.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            db = FirestoreDb.Create("sentars-medicals");

            GetAllDocument("doctor");
        }



        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void nic_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void fname_TextChanged(object sender, EventArgs e)
        {

        }

        private void lname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void email_TextChanged(object sender, EventArgs e)
        {

        }

        private void cno_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void sarea_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pass_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void cpass_TextChanged(object sender, EventArgs e)
        {

        }

        private void about_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void choose_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.Filter = "Image files(*.jpg, *.jpeg, *.bmp, *.png, ) | *.jpg; *.jpeg; *.bmp; *.png;|All files (*.*)|*.*";

            if (od.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Load(od.FileName);
            }
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void date_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private async void register_Click(object sender, EventArgs e)
        {
            Add_Document_with_AutoID();
            
           

        }

        private void reset_Click(object sender, EventArgs e)
        {

        }

        private void dregview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void sid_TextChanged(object sender, EventArgs e)
        {

        }


        private async void display_Click(object sender, EventArgs e)
        {
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        async Task Add_Document_with_AutoID()
        {
            

            MemoryStream ms = new MemoryStream();
            pictureBox2.Image.Save(ms, ImageFormat.Jpeg);
            byte[] a = ms.GetBuffer();

            string output = Convert.ToBase64String(a);


            //CollectionReference collectionReference = db.Collection("doctor");
            DocumentReference documentReference = db.Collection("doctor").Document(temail.Text);
            Dictionary<string, object> data = new Dictionary<string, object>()
            {
                {"NIC", tnic.Text },
                {"Fname", tfname.Text },
                {"Lname", tlname.Text },
                {"Email", temail.Text },
                {"ContactNo", tcno.Text },
                {"Sarea", tsarea.Text },
                {"Password", tpass.Text },
                {"Cpassword", tcpass.Text },
                {"About", tabout.Text },
                {"Photo", output },
                {"Date", tdate.Text },
                {"Role", "doctor" },

            };
            await documentReference.CreateAsync(data);
            MessageBox.Show("Registered Successfully");

        }

        async void GetAllDocument(string nameofCollection)
        {
            Query doctor = db.Collection(nameofCollection);
            QuerySnapshot snap = await doctor.GetSnapshotAsync();


            foreach(DocumentSnapshot docsnap in snap.Documents)
            {
                docinfo docinfo = docsnap.ConvertTo<docinfo>();

                if (docsnap.Exists)
                {
                    dregview.Rows.Add(docsnap.Id, docinfo.NIC, docinfo.Fname, docinfo.Lname, docinfo.Email, docinfo.ContactNo, docinfo.Sarea, docinfo.About, docinfo.Date);
                    
                }
                else
                {
                    MessageBox.Show("Some information are missing");
                }
            }
        }
        async void searchnic(string nameofCollection, string doc)
        {
            DocumentReference docref = db.Collection(nameofCollection).Document(doc);
            DocumentSnapshot snap = await docref.GetSnapshotAsync();

            docinfo docinfo = snap.ConvertTo<docinfo>();

            if (snap.Exists)
            {
                dregview.Rows.Add(snap.Id, docinfo.NIC, docinfo.Fname, docinfo.Lname, docinfo.Email, docinfo.ContactNo, docinfo.Sarea, docinfo.About, docinfo.Date);
            }

            


            

        }

        private void textMail(object sender, EventArgs e)
        {
            Regex mRegxExpression;
            if (temail.Text.Trim() != string.Empty)
            {
                mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");

                if (!mRegxExpression.IsMatch(temail.Text.Trim()))
                {
                    MessageBox.Show("E-mail address format is not correct.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    temail.Focus();
                }
            }
        }

        private void ConfirmPass(object sender, EventArgs e)
        {
            if(tpass.Text != tcpass.Text)
            {
                MessageBox.Show("Password Not matching", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NicCheck(object sender, EventArgs e)
        {
            string pattern = null; pattern = "^[0-9]{9}[vVxX]$";

            if (Regex.IsMatch(tnic.Text, pattern))
            {
                
            }
            else
            {
                MessageBox.Show("NIC Format is incorrect", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
            
}
