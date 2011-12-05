using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {
        ListHolder parentlistholder;
        ListHolder.Usertype usertype;
        public MainForm(ListHolder.Usertype usertypevalue, ListHolder mainlist)
        {
            InitializeComponent();
            parentlistholder = mainlist;

            if (usertypevalue == ListHolder.Usertype.Cashier) //If User is a Cashier
            {
                AddPrescription.Enabled = true; //they can use the add prescription form
                usertype = usertypevalue; //Parses User Type
            }
            else if (usertypevalue == ListHolder.Usertype.Pharmacist)  //If User is a Pharmacist
            {
                ProcessPrescription.Enabled = true; //they can use the process prescription form
                usertype = usertypevalue; //Parses User Type
            }
            else if (usertypevalue == ListHolder.Usertype.Administrator)  //If User is a Admin
            {
                //Administrators can use everything
                ProcessPrescription.Enabled = true;
                AddPrescription.Enabled = true;
                StockControl.Enabled = true;
                UserManagement.Enabled = true;
                btnManagementReport.Enabled = true;
                usertype = usertypevalue; //Parses User Type
            }
        }

        private void UserManagement_Click(object sender, EventArgs e)
        {
            UserManagement usermanagement = new UserManagement(parentlistholder, usertype);
            usermanagement.Show(); //Open the user management form
            this.Close(); //Close this form
        }

        private void StockControl_Click(object sender, EventArgs e)
        {
            StockControl stockcontrol = new StockControl(parentlistholder, usertype);
            stockcontrol.Show(); //Open the stock control form
            this.Close(); //Close this form
        }

        private void ProcessPrescription_Click(object sender, EventArgs e)
        {
            Pharmacist process = new Pharmacist(parentlistholder, usertype);
            process.Show(); //Open the process prescription form
            this.Close(); //Close this form
        }

        private void AddPrescription_Click(object sender, EventArgs e)
        {
            AddPrescription addprescript = new AddPrescription(parentlistholder, usertype);
            addprescript.Show(); //Open the add prescription form
            this.Close(); //Close this form
        }

        private void ManagementReport_Click(object sender, EventArgs e)
        {
            ManagementReport report = new ManagementReport(parentlistholder, usertype);
            report.Show(); //Open the management report form
            this.Close(); //Close this form
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show(); //Re open the login form
            this.Close(); //Close this form
        }
    }
}
