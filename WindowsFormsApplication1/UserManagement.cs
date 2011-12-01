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
        public UserManagement(ListHolder listhold)
        {
            InitializeComponent();
            users = listhold;
        }

        private void UserManagement_Load(object sender, EventArgs e)
        {
            UserTypeCombo.Items.Add(ListHolder.Usertype.Administrator.ToString());
            UserTypeCombo.Items.Add(ListHolder.Usertype.Cashier.ToString());
            UserTypeCombo.Items.Add(ListHolder.Usertype.Pharmacist.ToString());
            PopulateListView();
        }

        public void PopulateListView()
        {
            UserListView.Items.Clear();
            int Count = 0;
            foreach (Users user in users.UserList)
            {
                UserListView.Items.Add(user.GetUsername()); //Adds UserName to listview
                UserListView.Items[Count].SubItems.Add(user.GetPassword()); //Add Password to listview
                UserListView.Items[Count].SubItems.Add(user.GetUserStatus().ToString()); //Adds User Type to listview
                Count++;
            }
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            string username = UserListView.SelectedItems[0].SubItems[0].Text;
            string password = UserListView.SelectedItems[0].SubItems[1].Text;
            string type = UserListView.SelectedItems[0].SubItems[2].Text;
            foreach (Users node in users.UserList)
            {
                if (node.GetUsername() == username && node.GetPassword() == password && node.GetUserStatus().ToString() == type)
                {
                    users.UserList.Remove(node); //Remove User from class list so it wont get written to a file
                    break;
                }
            }
            UserListView.Items.Remove(UserListView.SelectedItems[0]); //Removes From View
            WriteUsers();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text != "" && txtPassword.Text != "" && UserTypeCombo.Text != "")
            {
                Users tempuserclass = new Users(txtUsername.Text,txtPassword.Text);
                ListHolder.Usertype tempusertype;
                tempusertype = ListHolder.Usertype.Cashier; //Default Value
                switch(UserTypeCombo.Text)
                {
                    case "Administrator":
                        tempusertype = ListHolder.Usertype.Administrator;
                        break;
                    case "Pharmacist":
                        tempusertype = ListHolder.Usertype.Pharmacist;
                        break;
                    case "Cashier":
                        tempusertype = ListHolder.Usertype.Cashier;
                        break;
                }
                tempuserclass.pJobtype = tempusertype;
                users.UserList.Add(tempuserclass); //Adds the New User

                PopulateListView();
                WriteUsers();
            }
        }


        public void WriteUsers()
        {
            XmlWriterSettings set = new XmlWriterSettings();
            set.Indent = true;
            set.NewLineOnAttributes = true;
            using (XmlWriter writer = XmlWriter.Create("Users.xml", set))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Users");
                foreach (Users node in users.UserList)
                {
                        writer.WriteStartElement("Username");
                        writer.WriteAttributeString("Password", node.GetPassword());
                        writer.WriteAttributeString("UserType", node.GetUserStatus().ToString());
                        writer.WriteString(node.GetUsername());
                        writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
}
