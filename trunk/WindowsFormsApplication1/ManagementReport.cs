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
    public partial class ManagementReport : Form
    {
        ListHolder prescriptions;
        ListHolder.Usertype usertype; //Users Type
        List<Prescription> PrescriptionsList = new List<Prescription>(); //List of Prescriptions
        /// <summary>
        /// Constructor Method
        /// </summary>
        /// <param name="listholder"></param>
        public ManagementReport(ListHolder listholder, ListHolder.Usertype value)
        {
            InitializeComponent();
            prescriptions = listholder;
            usertype = value;

        }
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManagementReport_Load(object sender, EventArgs e)
        {
            ReadPrescriptionsFile(); //Read in the prescription into the list
            ReadDoctorFile(); //Read Doctors

            #region Total sold by each doctor
            for (int i = 0; i < DoctorSoldView.Items.Count; i++) //For Every Doctor
           {
                foreach (Prescription node in PrescriptionsList) //For Each Prescription
                {
                    string doctorname = node.GetDoctorName(); //Get Prescriptions Doctor Name
                    string doctortocomparewith = DoctorSoldView.Items[i].Text; //Get Doctor in the Lists Name
                    if (doctorname.Equals(doctortocomparewith)) //See If they are the same
                    {
                        double addprice = double.Parse(DoctorSoldView.Items[i].SubItems[1].Text); //Get Doctor in the lists total
                        addprice += double.Parse(node.GetPrice()); //Add Prescription Total to It
                        DoctorSoldView.Items[i].SubItems[1].Text = addprice.ToString(); //Write it back
                    }
                }

           }
            #endregion


            #region Add Items to Listview
            prescriptions.Initialise(); //Loads in Items from stock control
            string[] Items = DodgyBobStockControl.StockControl.GET_ITEMS(); //Makes an string array containing the items
            int Counter = 0; //Counter variable
            foreach (string name in Items) //For Every item in the list
            {
                ItemQuantitySold.Items.Add(name); //Add Item Name to the List
                ItemQuantitySold.Items[Counter].SubItems.Add("0"); //Set Quantity Sold as 0
                Counter++; //Move to Next Item
            }
            #endregion

            #region Total Items Sold
            foreach (Prescription node in PrescriptionsList) //Go through each prescription
            {
                Counter = 0; //Resuing variable
                foreach (string itemname in node.ItemName) //Go Throught each item in the prescription
                {
                    string PrescriptionItemName = node.ItemName[Counter]; //Sets as the Prescription Item Name
                    for (int ListViewPos = 0; ListViewPos < ItemQuantitySold.Items.Count; ListViewPos++) //Each Item in the list view
                    {
                        string ItemInTheTableName = ItemQuantitySold.Items[ListViewPos].Text; //Sets as Item In The Tables Name

                        if (ItemInTheTableName.Equals(PrescriptionItemName)) //If the current Item in the list view is the same as the current item in the prescription
                        {
                            double Quantity = double.Parse(ItemQuantitySold.Items[ListViewPos].SubItems[1].Text); //Get Quantity Sold from the list
                            Quantity += int.Parse(node.Quantity[Counter]); //Adds Amount Sold to Total
                            ItemQuantitySold.Items[ListViewPos].SubItems[1].Text = Quantity.ToString(); //write it back
                        }

                    }
                    Counter++;
                }
            }
            #endregion

        }
        /// <summary>
        /// Read Doctors Name From XML file
        /// </summary>
        public void ReadDoctorFile()
        {
            XmlDocument DoctorFile = new XmlDocument();
            DoctorFile.Load("Doctors.xml"); //Read Doctor XML File
            XmlNodeList DoctorsName = DoctorFile.GetElementsByTagName("Name"); //Get List of Doctor By Doctor Name
            int i = 0;
            foreach (XmlNode node in DoctorsName) //For Each Doctor in the List
            {

                string Name = node.InnerText; //Get Doc Name
               DoctorSoldView.Items.Add(Name); //Add Name to the list
               DoctorSoldView.Items[i].SubItems.Add("0"); //Set Quantity Sold as 0
               i++; //Move to Next Doc
            }
        }
        /// <summary>
        /// Date Drop Down Update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FirstDayOfTheWeek_ValueChanged(object sender, EventArgs e)
        {     
            DateTime StartDate;
            StartDate = FirstDayOfTheWeek.Value; //Gets the Value from the Date Drop Down
            if (!StartDate.DayOfWeek.Equals(DayOfWeek.Monday)) //Check If its not a Monday
                MessageBox.Show("Please Choose a Monday"); //Returns Error Message
        }
        /// <summary>
        /// Read Prescriptions File XML
        /// </summary>
        public void ReadPrescriptionsFile()
        {
            XmlDocument PrescriptionFile = new XmlDocument();
            PrescriptionFile.Load("CompletedPrescriptions.xml"); //Opens Prescriptions XML File
            XmlNodeList Prescript = PrescriptionFile.GetElementsByTagName("Prescription"); //Gets a List of Prescriptions
            int index = 0; //Prescription List Counter

            foreach (XmlNode node in Prescript) //For each prescription in the list
            {
                string Name = node["Name"].InnerText; //Get Patient Name
                string Doctor = node["Doctor"].InnerText; //Get Doctor Name
                string Price = node["Price"].InnerText; //Get Price
                string DateIssue = node["DateIssue"].InnerText; //Get Date Issued
                string DateExpiry = node["DateExpiry"].InnerText; //Get Expiry Date
                string PharaName = node["Pharmacist"].InnerText; //Get Pharmacist Name
                string PresStatus = node["Completed"].InnerText; //Get Whether it was collect or not
                XmlNodeList Items = node.SelectNodes("Item"); //Create a List of Items
                Prescription CurrentPrescript = new Prescription(Name); //Create a New Class
                CurrentPrescript.SetDoctorName(Doctor);
                CurrentPrescript.SetPrice(Price);
                CurrentPrescript.SetPharmacistName(PharaName);
                CurrentPrescript.SetDateIssued(DateIssue);
                CurrentPrescript.SetDateExpiry(DateExpiry);
                CurrentPrescript.SetCompleted(PresStatus);

                foreach (XmlNode node2 in Items) //For Every Item in the list
                {
                    string NameItem = node2.InnerText; //get Item Name
                    CurrentPrescript.AddItemNameList(NameItem);
                    string Number = node2.Attributes["Quantity"].InnerText; //Get Quantity
                    CurrentPrescript.AddQuantity(Number);
                }
                PrescriptionsList.Add(CurrentPrescript); //Add Class to Class List
                index++; //Move to Next Prescription
            }
        }
        /// <summary>
        /// Generate Data Based on the start Date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Generate_Click(object sender, EventArgs e)
        {
            DateTime[] DaysInWeek = new DateTime[7]; //There are 7 Days in a Week
            DaysInWeek[0] = FirstDayOfTheWeek.Value; //Set First Day as Start Date
            double totalprice = 0.0; //This will store the total
            for (int i = 1; i < 7; i++) //For every day in the week
            {
                DaysInWeek[i] = DaysInWeek[i - 1].AddDays(1); //Add New Date to Array
            }

            foreach (Prescription node in PrescriptionsList) //For Every Prescription in the list
            {
                for(int i = 0; i < 7; i++) //For Every Day in the week
                {
                    if (node.GetDateIssued() == DaysInWeek[i].ToLongDateString()) //If date Issued is one of these days
                        totalprice += double.Parse(node.GetPrice()); //Add prescription total to the overall total
                }
            }
            TotalWeeklySales.Text = "£" +  String.Format("{0:0.00}", totalprice.ToString()); //Write out Total in £00.00 format
        }
        /// <summary>
        /// Close Button Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Closebtn_Click_1(object sender, EventArgs e)
        {
            MainForm form = new MainForm(usertype, prescriptions);
            form.Show();
            this.Close();
        }


    }
}
