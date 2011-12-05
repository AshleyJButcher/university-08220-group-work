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
    public partial class UserManagement : Form
    {
        ListHolder users;
        ListHolder.Usertype usertype;
        /// <summary>
        /// Constructor Method
        /// </summary>
        /// <param name="listhold"></param>
        public UserManagement(ListHolder listhold, ListHolder.Usertype value)
        {
            InitializeComponent();
            users = listhold;
            usertype = value;
        }
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserManagement_Load(object sender, EventArgs e)
        {
            //Add Each of the User Types to the Drop Down
            UserTypeCombo.Items.Add(ListHolder.Usertype.Administrator.ToString()); 
            UserTypeCombo.Items.Add(ListHolder.Usertype.Cashier.ToString());
            UserTypeCombo.Items.Add(ListHolder.Usertype.Pharmacist.ToString());
            PopulateListView(); //Adds Users to the list view
        }
        /// <summary>
        /// Adds all existing users to the list view
        /// </summary>
        public void PopulateListView()
        {
            UserListView.Items.Clear(); //Wipe the view
            int Count = 0;
            foreach (Users user in users.UserList) //For Every User in the List
            {
                UserListView.Items.Add(user.GetUsername()); //Adds UserName to listview
                UserListView.Items[Count].SubItems.Add(user.GetPassword()); //Add Password to listview
                UserListView.Items[Count].SubItems.Add(user.GetUserStatus().ToString()); //Adds User Type to listview
                Count++; //Next User
            }
        }
        /// <summary>
        /// Remove User Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Remove_Click(object sender, EventArgs e)
        {
            if (UserListView.SelectedItems.Count > 0) //If there is a user to remove
            {
                string username = UserListView.SelectedItems[0].SubItems[0].Text; //Get Username
                string password = UserListView.SelectedItems[0].SubItems[1].Text; //Get Password
                string type = UserListView.SelectedItems[0].SubItems[2].Text; //Get User Type
                foreach (Users node in users.UserList) //For each of the user classes in the class list
                {
                    if (node.GetUsername() == username && node.GetPassword() == password && node.GetUserStatus().ToString() == type) //Find one to remove
                    {
                        users.UserList.Remove(node); //Remove User from class list so it wont get written to a file
                        break; //Found no need to keep looping
                    }
                }
                UserListView.Items.Remove(UserListView.SelectedItems[0]); //Removes From View
                WriteUsers(); //Write Out Users Without the old one
            }
            else //If there is no user selected
            {
                MessageBox.Show("Nothing Selected"); //Show error Message
            }
        }
        /// <summary>
        /// Adding a Nwe User
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text != "" && txtPassword.Text != "" && UserTypeCombo.Text != "") //If all the fields are filled in
            {
                bool UniqueUsername = true; //Flag for a Unique Username
                for (int i = 0; i < UserListView.Items.Count; i++) //For Every user in the list
                {
                    if (UserListView.Items[i].Text == txtUsername.Text) //Check if the one typed is uniquw
                    {
                        UniqueUsername = false; //If it is not uniquw
                        MessageBox.Show("Username Already Exists"); //Show Error Message
                    }
                }
                if (UniqueUsername) //If it is a Unique Username
                {
                    Users tempuserclass = new Users(txtUsername.Text, txtPassword.Text); //Create New Class
                    ListHolder.Usertype tempusertype = ListHolder.Usertype.Cashier; //Default Value
                    switch (UserTypeCombo.Text) //For Each User Type
                    {
                        case "Administrator":
                            tempusertype = ListHolder.Usertype.Administrator; //Set Admin
                            break;
                        case "Pharmacist":
                            tempusertype = ListHolder.Usertype.Pharmacist; //Set Pharmacist
                            break;
                        case "Cashier":
                            tempusertype = ListHolder.Usertype.Cashier; //Set Cashier
                            break;
                    }
                    tempuserclass.pJobtype = tempusertype; //Set Class User type as this one
                    users.UserList.Add(tempuserclass); //Adds the New User

                    PopulateListView(); //Update List View
                    WriteUsers(); //Write Users Out
                }
            }
            else //If Not all fields are filled in
            {
                MessageBox.Show("Not All the Fields Contain Data"); //Show error Message
            }
        }
        /// <summary>
        /// Writes out User XML File
        /// </summary>
        public void WriteUsers()
        {
            XmlWriterSettings set = new XmlWriterSettings();
            set.Indent = true;
            set.NewLineOnAttributes = true;
            using (XmlWriter writer = XmlWriter.Create("Users.xml", set)) //Create Users.xml
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Users"); //Parent element
                foreach (Users node in users.UserList) //For each User class in the class list
                {
                        writer.WriteStartElement("Username"); //Write Username Element
                        writer.WriteAttributeString("Password", node.GetPassword()); //write Password
                        writer.WriteAttributeString("UserType", node.GetUserStatus().ToString()); //Write Usertype
                        writer.WriteString(node.GetUsername()); //Write Username
                        writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
        /// <summary>
        /// Close Form Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            MainForm form = new MainForm(usertype, users);
            form.Show();
            this.Close();
        }
  
    }
}
