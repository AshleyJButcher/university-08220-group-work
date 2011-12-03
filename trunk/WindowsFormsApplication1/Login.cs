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
  
        public ListHolder loadusers = new ListHolder(); //List of Users
        /// <summary>
        /// Login Button Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Loginbutton_Click(object sender, EventArgs e)
        {
            bool UserAuth = false; //User is not authenticated (default value)
            ListHolder.Usertype logintype = ListHolder.Usertype.Cashier; //default value
            foreach (Users userclass in loadusers.UserList) //For Every User in the list
            {
                if (txtUsername.Text == userclass.GetUsername() && txtPassword.Text == userclass.GetPassword()) //Check Usernames & Passwords against what the user has typed
                {
                    UserAuth = true; //User is authenticated
                    logintype = userclass.GetUserStatus(); //Get the User type
                }
            }
            if(UserAuth == true){ //If user is allowed to login
                MainForm lol = new MainForm(logintype, loadusers); //Show Main Form
                lol.Show(); 
                this.Hide(); //Close This Form
                } else {
                    MessageBox.Show("Invalid Username or Password"); //Show Error Message
                }
        }

  /// <summary>
  /// When the form loads
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>

        private void Login_Load(object sender, EventArgs e)
        {

            XmlDocument UsersFile = new XmlDocument(); 
            UsersFile.Load("Users.xml"); //Load in User XML file
            XmlNodeList Users = UsersFile.GetElementsByTagName("Username"); //create a list of user by username
            foreach (XmlNode node in Users) //For every user in the list
            {

                string Username = node.InnerText; //Gets the Username
                string Password = node.Attributes["Password"].InnerText; //Sets the Password
                string Usertype = node.Attributes["UserType"].InnerText; //String of the Users Job
                Users tempuserclass = new Users(Username, Password); //Create new class

                switch (Usertype) //For each of the different types of user
                {
                    case "Administrator":
                        tempuserclass.SetAsAdmin(); //Set User Type
                        break;
                    case "Pharmacist":
                        tempuserclass.SetAsPharmacist(); //Set User Type
                        break;
                    case "Cashier":
                        tempuserclass.SetAsCashier(); //Set User Type
                        break;
                }
                loadusers.UserList.Add(tempuserclass); //Add Class to Class List
            }
        }
        /// <summary>
        /// Exit Button Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close(); //Close Form
        }
    
    }
}
