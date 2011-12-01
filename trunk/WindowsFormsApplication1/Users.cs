using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class Users
    {
        public Users(string user, string pass)
        {
            SetUsername(user);
            SetPassword(pass);
        }

        private string pUsername;
        private string pPassword;

        public ListHolder.Usertype pJobtype;
        public string GetUsername()
        {
            return pUsername;
        }
        public void SetUsername(string value)
        {
            pUsername = value;            
        }

        public string GetPassword()
        {
            return pPassword;
        }
        public void SetPassword(string value)
        {
            pPassword = value;            
        }
        
        public void SetAsAdmin()
        {
            pJobtype = ListHolder.Usertype.Administrator;
        }
        public void SetAsPharmacist()
        {
            pJobtype = ListHolder.Usertype.Pharmacist;
        }
        public void SetAsCashier()
        {
            pJobtype = ListHolder.Usertype.Cashier;
        }

        public ListHolder.Usertype GetUserStatus()
        {
            return pJobtype;
        }
    }
}
