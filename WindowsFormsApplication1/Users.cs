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

        private string pUsername; //UserName
        private string pPassword; //Password

        public ListHolder.Usertype pJobtype; //User Type (Admin, Cashier, Ect)

        /// <summary>
        /// Returns Username
        /// </summary>
        /// <returns>Username</returns>
        public string GetUsername()
        {
            return pUsername;
        }
        /// <summary>
        /// Sets Username
        /// </summary>
        /// <param name="value">Username</param>
        public void SetUsername(string value)
        {
            pUsername = value;            
        }
        /// <summary>
        /// Returns Password
        /// </summary>
        /// <returns>Password</returns>
        public string GetPassword()
        {
            return pPassword;
        }
        /// <summary>
        /// Sets Password
        /// </summary>
        /// <param name="value">Password</param>
        public void SetPassword(string value)
        {
            pPassword = value;            
        }
        /// <summary>
        /// Sets User Type as Admin
        /// </summary>
        public void SetAsAdmin()
        {
            pJobtype = ListHolder.Usertype.Administrator;
        }
        /// <summary>
        ///  Sets User Type as Pharmacist
        /// </summary>
        public void SetAsPharmacist()
        {
            pJobtype = ListHolder.Usertype.Pharmacist;
        }
        /// <summary>
        ///  Sets User Type as Cashier
        /// </summary>
        public void SetAsCashier()
        {
            pJobtype = ListHolder.Usertype.Cashier;
        }
        /// <summary>
        /// Return User Type
        /// </summary>
        /// <returns>Usertype</returns>
        public ListHolder.Usertype GetUserStatus()
        {
            return pJobtype;
        }
    }
}
