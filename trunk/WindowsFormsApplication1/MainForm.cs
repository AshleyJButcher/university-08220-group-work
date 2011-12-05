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
        ManagementReport report;
        UserManagement usermanagement;
        StockControl stockcontrol;
        AddPrescription addprescript;
        Pharmacist process;

        public MainForm(ListHolder.Usertype usertype, ListHolder mainlist)
        {
            InitializeComponent();
            parentlistholder = mainlist;
            //defines the forms so only one instance can be opened
            report = new ManagementReport(parentlistholder);
            usermanagement = new UserManagement(parentlistholder);
            stockcontrol = new StockControl(parentlistholder);
            addprescript = new AddPrescription(parentlistholder);
            process = new Pharmacist(parentlistholder);

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
            usermanagement.Show(); //Open the user management form
        }

        private void StockControl_Click(object sender, EventArgs e)
        {
            stockcontrol.Show(); //Open the stock control form
        }

        private void ProcessPrescription_Click(object sender, EventArgs e)
        {
            process.Show(); //Open the process prescription form
        }

        private void AddPrescription_Click(object sender, EventArgs e)
        {
            addprescript.Show(); //Open the add prescription form
        }

        private void ManagementReport_Click(object sender, EventArgs e)
        {
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
