using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace SentarsMedicals
{
    public partial class Form1 : Form {

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "zLTt08Xpb0s4SfykcGxJm4IT2bVPEU5Wt6GVjlFN",
            BasePath = "https://sentars-medicals-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;

    
        public Form1()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
            string user, pass;
            user = username.Text;
            pass = password.Text;

            if (user == "admin.sentars@gmail.com" && pass == "admin123")
            {
                adminHome ahome = new adminHome();
                
                ahome.Show();
                this.Hide();
                
            }else if (user == "pharmacy.sentars@gmail.com" && pass == "pharmacy123")
            {
                pharmacyHome pHome = new pharmacyHome();
                pHome.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password!", "Access Denied");
                
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            if (client != null)
            {
                MessageBox.Show("Connection Established");
            }
            else
            {
                MessageBox.Show("Something wrong with the database. Please contact IT section", "Connection error");
            }
        }
    }
}
