using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApplication1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
  
        XmlDocument UsersFile;
        public ListHolder loadusers = new ListHolder();
        private void Loginbutton_Click(object sender, EventArgs e)
        {
            bool UserAuth = false; //User is authenticated
            ListHolder.Usertype logintype = ListHolder.Usertype.Cashier; //default value
            foreach (Users userclass in loadusers.UserList)
            {
                if (txtUsername.Text == userclass.GetUsername() && txtPassword.Text == userclass.GetPassword())
                {
                    UserAuth = true;
                    logintype = userclass.GetUserStatus();
                }
            }
            if(UserAuth == true){
                MainForm lol = new MainForm(logintype, loadusers);
                lol.Show();
                this.Hide();
                } else {
                    MessageBox.Show("Invalid Username or Password");
                }
        }

  

        private void Login_Load(object sender, EventArgs e)
        {
            UsersFile = new XmlDocument();
            UsersFile.Load("Users.xml");
            XmlNodeList Users = UsersFile.GetElementsByTagName("Username");
            foreach (XmlNode node in Users)
            {

                string Username = node.InnerText; //Sets the Username
                string Password = node.Attributes["Password"].InnerText; //Sets the Password
                string Usertype = node.Attributes["UserType"].InnerText; //String of the Users Job
                Users tempuserclass = new Users(Username, Password);

                switch (Usertype)
                {
                    case "Administrator":
                        tempuserclass.SetAsAdmin();
                        break;
                    case "Pharmacist":
                        tempuserclass.SetAsPharmacist();
                        break;
                    case "Cashier":
                        tempuserclass.SetAsCashier();
                        break;
                }
                loadusers.UserList.Add(tempuserclass);
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    
    }
}
