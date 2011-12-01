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
            if (usertype == ListHolder.Usertype.Cashier)
            {
                AddPrescription.Enabled = true;
            }
            else if (usertype == ListHolder.Usertype.Pharmacist)
            {
                ProcessPrescription.Enabled = true;
            }
            else if (usertype == ListHolder.Usertype.Administrator)
            {
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
            usermanagement.Show();
        }

        private void StockControl_Click(object sender, EventArgs e)
        {
            StockControl stockcontrol = new StockControl();
            stockcontrol.Show();
        }

        private void ProcessPrescription_Click(object sender, EventArgs e)
        {
            Pharmacist process = new Pharmacist(parentlistholder);
            process.Show();
        }

        private void AddPrescription_Click(object sender, EventArgs e)
        {
            AddPrescription addprescript = new AddPrescription(parentlistholder);
            addprescript.Show();
        }

        private void ManagementReport_Click(object sender, EventArgs e)
        {
            ManagementReport report = new ManagementReport(parentlistholder);
            report.Show();
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
