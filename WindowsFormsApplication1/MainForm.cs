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
        public MainForm(ListHolder.Usertype usertype, ListHolder mainlist)
        {
            InitializeComponent();
            parentlistholder = mainlist;
            if (usertype == ListHolder.Usertype.Cashier) //If User is a Cashier
            {
                AddPrescription.Enabled = true; //they can use the add prescription form
            }
            else if (usertype == ListHolder.Usertype.Pharmacist)  //If User is a Pharmacist
            {
                ProcessPrescription.Enabled = true; //they can use the process prescription form
            }
            else if (usertype == ListHolder.Usertype.Administrator)  //If User is a Admin
            {
                //Administrators can use everything
                ProcessPrescription.Enabled = true;
                AddPrescription.Enabled = true;
                StockControl.Enabled = true;
                UserManagement.Enabled = true;
                btnManagementReport.Enabled = true;
            }
        }

        private void UserManagement_Click(object sender, EventArgs e)
        {
            UserManagement usermanagement = new UserManagement(parentlistholder);
            usermanagement.Show(); //Open the user management form
        }

        private void StockControl_Click(object sender, EventArgs e)
        {
            StockControl stockcontrol = new StockControl(parentlistholder);
            stockcontrol.Show(); //Open the stock control form
        }

        private void ProcessPrescription_Click(object sender, EventArgs e)
        {
            Pharmacist process = new Pharmacist(parentlistholder);
            process.Show(); //Open the process prescription form
        }

        private void AddPrescription_Click(object sender, EventArgs e)
        {
            AddPrescription addprescript = new AddPrescription(parentlistholder);
            addprescript.Show(); //Open the add prescription form
        }

        private void ManagementReport_Click(object sender, EventArgs e)
        {
            ManagementReport report = new ManagementReport(parentlistholder);
            report.Show(); //Open the management report form
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show(); //Re open the login form
            this.Close(); //CLose this form
        }
    }
}
