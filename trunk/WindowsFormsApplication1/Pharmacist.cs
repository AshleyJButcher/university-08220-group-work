using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Pharmacist : Form 
    {
        double SetPrice = 0.1; //Checks if its either 0 or 7.5

        ListHolder ParentListHolder;
        string PatientName; //Hold Patient Name
        string DoctorName; //Holds Doctor Name

        List<Prescription> ToDoPrescriptList = new List<Prescription>();
        /// <summary>
        /// Constructor Method
        /// </summary>
        /// <param name="listhold"></param>
        public Pharmacist(ListHolder listhold)
        {
            InitializeComponent();
            ParentListHolder = listhold;
            ParentListHolder.Initialise(); //Loads Stock Control Method
        }
    
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pharmacist_Load(object sender, EventArgs e)
        {
            DateExpiry.MinDate = DateTime.Now.Date; //Set Minimum Expiry Date to Todays Date
            foreach (Users LoadUsers in ParentListHolder.UserList) //For Every User in the User List
            {
                if (LoadUsers.GetUserStatus() == ListHolder.Usertype.Pharmacist) //If User is a Pharmacist /""/
                    PharmaCombo.Items.Add(LoadUsers.GetUsername());    //If your a pharmacist
            }
            ReadToDoPrescriptionsFile(); //Read In Prescriptions to Process
            ReadPrescriptionsFile(); //Read In Prescription to Collect
            #region Check if more than 24 hours have gone by
            foreach (Prescription prescript in ParentListHolder.FinalPrescriptionList) //For Every Prescription that needs collecting
            {
                string dateissued = prescript.GetDateIssued(); //Get Date Issued
                DateTime date = Convert.ToDateTime(dateissued); //Convert to Date Format
                if (date.Add(TimeSpan.FromDays(1)) < DateTime.Today.Date && prescript.GetCompleted() == "Not Completed") //If It Has Not Been Collected
                {
                    MessageBox.Show(prescript.GetPatientName() + ": " + prescript.GetDateIssued() + " Prescription has not been collected please return items to stock"); //Show Message
                    int ItemCount = 0; //Counter
                    foreach (string itemname in prescript.ItemName) //For every Item in Prescription
                    {
                        DodgyBobStockControl.StockControl.DO("'" + itemname + "' restock " + prescript.Quantity[ItemCount] + " please"); //Return items to stock
                        ItemCount++;//Next Item
                    }
                    if (DodgyBobStockControl.StockControl.SAVE() == true) //Save stock update
                    {
                        ParentListHolder.FinalPrescriptionList.Remove(prescript); //Delete Prescription
                    }
                }
            #endregion
                WritePrescription(); //this should remove any prescriptions that are out of date
                UpdatePrescriptionsToCollect(); //Update Prescription to Collect XML file
            }
        }
        
        #region To Do Prescriptions
        /// <summary>
        /// Read Prescriptions to Complete XML
        /// </summary>
        public void ReadToDoPrescriptionsFile()
        {
            XmlDocument PrescriptionFile = new XmlDocument();
            PrescriptionFile.Load("Prescriptions.xml"); //Read XML file
            XmlNodeList Prescript = PrescriptionFile.GetElementsByTagName("Prescription"); //Get a List of Prescriptions
            int index = 0;

            foreach (XmlNode node in Prescript) //For Every Prescription
            {
                string Name = node["Name"].InnerText; //Get Patient Name
                string Doctor = node["Doctor"].InnerText; //Get Doctor Name
                string instructions = node["Instructions"].InnerText; //Get Instructions
                XmlNodeList Items = node.SelectNodes("Item"); //Make a list of Items
                Prescription CurrentPrescript = new Prescription(Name); //Create New CLass
                CurrentPrescript.SetDoctorName(Doctor); //Set Doc Name
                CurrentPrescript.SetInstructions(instructions); //Set Instructions
                foreach (XmlNode node2 in Items) //For each item in prescription
                {
                    string NameItem = node2.InnerText; //Get Item Name
                    CurrentPrescript.AddItemNameList(NameItem); //Add to Class
                    string Number = node2.Attributes["Quantity"].InnerText; //Get Quantity
                    CurrentPrescript.AddQuantity(Number); //Add to CLass
                }
                ToDoPrescriptList.Add(CurrentPrescript); //Add Class to Class list
                PrescriptionList.Items.Add(CurrentPrescript.GetPatientName()); //Add to Complete List
                index++; //Next prescription
            }
        }
        /// <summary>
        /// Writes Out Prescription Still to Do
        /// </summary>
        public void WriteToDoPrescription()
        {
            XmlWriterSettings set = new XmlWriterSettings();
            set.Indent = true;
            set.NewLineOnAttributes = true;
            using (XmlWriter writer = XmlWriter.Create("Prescriptions.xml", set)) //Creates the File
            {

                writer.WriteStartDocument();
                writer.WriteStartElement("Prescriptions"); //Parent Element
                foreach (Prescription node in ToDoPrescriptList) //For every prescription in the list
                {
                    int amount = 0;
                    writer.WriteStartElement("Prescription"); //Write Element
                    writer.WriteElementString("Name", node.GetPatientName()); //Write Patient Name
                    writer.WriteElementString("Doctor", node.GetDoctorName()); //Write Doc Name
                    writer.WriteElementString("Instructions", node.GetInstruction()); //Write Instructions
                    foreach (string item in node.ItemName) //For Every item in the list
                    {
                        writer.WriteStartElement("Item"); //Element
                        writer.WriteAttributeString("Quantity", node.Quantity[amount]); //Write Quantity
                        writer.WriteString(item); //Write Item Name
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    amount++; //Next Item
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
        #endregion

        #region Completed Prescriptions
        /// <summary>
        /// Reads Prescription that have still gotta be collected
        /// </summary>
        public void ReadPrescriptionsFile()
        {
            XmlDocument PrescriptionFile = new XmlDocument();
            PrescriptionFile.Load("CompletedPrescriptions.xml"); //Read XML file
            XmlNodeList Prescript = PrescriptionFile.GetElementsByTagName("Prescription"); //Creates a list of prescriptions
            int index = 0;

            foreach (XmlNode node in Prescript) //For every prescription in the list
            {
                string Name = node["Name"].InnerText; //get patient name
                string Doctor = node["Doctor"].InnerText; //get doc name
                string DateIssue = node["DateIssue"].InnerText; //get date issued
                string DateExpiry = node["DateExpiry"].InnerText; //get date expiry
                string ReadPrice = node["Price"].InnerText; //Get price
                string PharaName = node["Pharmacist"].InnerText; //Get pharmacist name
                string PresStatus = node["Completed"].InnerText; //get whether it has been completed
                XmlNodeList Items = node.SelectNodes("Item"); //make a list of items 
                Prescription CurrentPrescript = new Prescription(Name); //create new class
                CurrentPrescript.SetDoctorName(Doctor); //set doc name
                CurrentPrescript.SetPharmacistName(PharaName); //set pharmacist name
                CurrentPrescript.SetPrice(ReadPrice); //set price
                CurrentPrescript.SetDateIssued(DateIssue); //set date issued
                CurrentPrescript.SetDateExpiry(DateExpiry); //set date expiry
                CurrentPrescript.SetCompleted(PresStatus); //set collected status

                foreach (XmlNode node2 in Items) //for all of the items
                {
                    string NameItem = node2.InnerText; //get item name
                    CurrentPrescript.AddItemNameList(NameItem); //add item to class
                    string Number = node2.Attributes["Quantity"].InnerText; //get quantity
                    CurrentPrescript.AddQuantity(Number); //add quantity to class
                }
                ParentListHolder.FinalPrescriptionList.Add(CurrentPrescript); //add class to class list
                index++; //next item
            }
        }
        /// <summary>
        /// write completed prescriptions XML file
        /// </summary>
        public void WritePrescription()
        {
            XmlWriterSettings set = new XmlWriterSettings();
            set.Indent = true;
            set.NewLineOnAttributes = true;
            using (XmlWriter writer = XmlWriter.Create("CompletedPrescriptions.xml", set)) //creates xml file
            {

                writer.WriteStartDocument();
                writer.WriteStartElement("Prescriptions"); //parent element
                foreach (Prescription node in ParentListHolder.FinalPrescriptionList) //for all of the prescriptions in the list
                {
                    int amount = 0;
                    writer.WriteStartElement("Prescription"); 
                    writer.WriteElementString("Name", node.GetPatientName()); //write patient name
                    writer.WriteElementString("Doctor", node.GetDoctorName()); //write doc name
                    writer.WriteElementString("Pharmacist", node.GetPharmacistName()); //write pharmacist name
                    writer.WriteElementString("Price", node.GetPrice()); //write price
                    writer.WriteElementString("DateIssue", node.GetDateIssued()); //write date issued
                    writer.WriteElementString("DateExpiry", node.GetDateExpiry()); //write date expiry
                    writer.WriteElementString("Completed", node.GetCompleted()); //write completed status
                    foreach (string item in node.ItemName) //for all of the items in the prescription
                    {
                        writer.WriteStartElement("Item"); //element
                        writer.WriteAttributeString("Quantity", node.Quantity[amount]); //write quantity
                        writer.WriteString(item); //write item name
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    amount++; //next item
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        #endregion

        #region Prescription Certificates
        /// <summary>
        /// patient has a set price (£7.50)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FixedPrice_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count < 0) //if nothing is selected
            {
                MessageBox.Show("Must Select a Prescription First"); //show error message
            }
            else
            {
                SetPrice = 7.5; //set price to 7.50
                MessageBox.Show("Patient will pay a fixed price of £7.50"); //show message
            }
        }
        /// <summary>
        /// If patient doesnt have to pay anything
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Free_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count < 0) //if nothing is selected
            {
                MessageBox.Show("Must Select a Prescription First"); //show error message
            }
            else
            {
                SetPrice = 0.0; //set price to 0
                MessageBox.Show("Patient will Not pay for this prescription"); //show message
            }
        }
        #endregion
        /// <summary>
        /// When a new prescription is selected in the drop down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrescriptionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem listviewitem;		// Used for creating listview items.	   
            listView1.Items.Clear(); //Reset old items
            if (PrescriptionList.SelectedIndex > -1)  //if something is selected
            {
                Prescription loadprescript = ToDoPrescriptList[PrescriptionList.SelectedIndex]; //load prescription class
                for (int totalitems = 0; totalitems < loadprescript.ItemName.Count; totalitems++) //for every item
                {
                    listviewitem = new ListViewItem(loadprescript.ItemName[totalitems]); //add item to list view
                    listviewitem.SubItems.Add(loadprescript.Quantity[totalitems]); //add quantity
                    string price = DodgyBobStockControl.StockControl.ASK("'" + loadprescript.ItemName[totalitems] + "' cost please"); //get items price
                    listviewitem.SubItems.Add(price);//add price to list view
                    string expiry = DodgyBobStockControl.StockControl.ASK("'" + loadprescript.ItemName[totalitems] + "' expiry please"); //get expiry date
                    listviewitem.SubItems.Add(expiry); //add expiry date to list view
                    PatientName = loadprescript.GetPatientName(); //These are used later on for saving completed prescriptions
                    DoctorName = loadprescript.GetDoctorName();  //**
                    this.listView1.Items.Add(listviewitem); //add to list view
                }
                UpdateColumnSize(); //update column size
                txtInstructions.Text = loadprescript.GetInstruction(); //set instructions
            }
        }
        /// <summary>
        /// Updates the column width
        /// </summary>
        public void UpdateColumnSize()
        {
            foreach (ColumnHeader ch in this.listView1.Columns) //for every column in the list
            {
                ch.Width = -2; //update column width
            }
        }
        /// <summary>
        /// Finish button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Complete_Click(object sender, EventArgs e)
        {
            double TotalPrice = 0; //Prescription total
            if (listView1.Items.Count > 0 && PharmaCombo.Text != null) //If Fields are filledin
            {
                for (int i = 0; i < listView1.Items.Count; i++) //for each of the items
                {
                    #region Total Price
                    string pricestring = listView1.Items[i].SubItems[2].Text.Substring(1); //get items price
                    string quantitystring = listView1.Items[i].SubItems[1].Text; //get items quantity
                    double price = double.Parse(pricestring); //Items Price
                    int quantity = int.Parse(quantitystring); //Items Quantity
                    price = price * quantity; //price is quantity times items price
                    TotalPrice += price; //add the price to the total price
                    #endregion
                    DodgyBobStockControl.StockControl.DO("'" + listView1.Items[i].Text + "' consume " + quantity + " please"); //remove from stock
                }
                DodgyBobStockControl.StockControl.SAVE(); //Saves the stock update
                #region Saving the data to a class
                Prescription tempprescrip = new Prescription(PatientName); //create class
                if (Collecting.Checked == true) //if patient is collecting now
                {
                    tempprescrip.SetCompleted("Completed"); //set status to completed
                }
                else
                {
                    tempprescrip.SetCompleted("Not Completed"); //this means they are waiting
                }
                tempprescrip.SetDoctorName(DoctorName); //set doc name
                tempprescrip.SetPharmacistName(PharmaCombo.Text); //set pharmacist name
                tempprescrip.SetDateExpiry(DateExpiry.Text); //set date expiry
                tempprescrip.SetDateIssued(DateIssue.Text); //set date issued
                tempprescrip.SetPrice(TotalPrice.ToString()); //set price
                for (int i = 0; i < listView1.Items.Count; i++) //for every single item
                {
                    string itemnamestring = listView1.Items[i].Text; //get item name
                    string quantitystring = listView1.Items[i].SubItems[1].Text; //get quantity
                    tempprescrip.ItemName.Add(itemnamestring); //add item name
                    tempprescrip.Quantity.Add(quantitystring); //add quantity
                }
                ParentListHolder.FinalPrescriptionList.Add(tempprescrip); //add class to class list
                #endregion
                UpdatePrescriptionsToCollect(); // updates prescriptions XML file 
                #region Tidying Up
                for (int i = 0; i < ToDoPrescriptList.Count; i++)//Removes the completed prescription from the old list
                {
                    Prescription node = ToDoPrescriptList[i]; //get prescription class
                    if (node.GetPatientName() == PatientName && node.GetDoctorName() == DoctorName && node.GetInstruction() == txtInstructions.Text) //check its the right one
                    {
                        ToDoPrescriptList.Remove(node); //remove it
                        break; //leave loop 
                    }
                }

                WriteToDoPrescription(); //Re-Writes To Do Prescriptions without
                ToDoPrescriptList.Clear(); //Cleans the List
                PrescriptionList.Items.Clear(); //Reset items in list
                ReadToDoPrescriptionsFile(); //Reads the Prescriptions Back
                listView1.Items.Clear(); //Reset items in list
                txtInstructions.Text = ""; //set instruction to blank
                Collecting.Checked = false; //reset collecting variable

                #endregion
                if (File.Exists("CompletedPrescription.xml") == true) //if completed file exist
                    ReadPrescriptionsFile(); //read old one first
                WritePrescription(); //write it out

                if (SetPrice != 0.1) //if price is a set one
                    TotalPrice = SetPrice; //set total price

                ToPay Newform = new ToPay("£" + string.Format("{0:0.00}", TotalPrice)); //formats the price with two decimal places
                Newform.Show();
            }
            else //if no prescription is selected 
            {
                MessageBox.Show("No Prescription Selected"); //show error message
            }
        }

        #region  Prescriptions To Collect
        /// <summary>
        /// Read Prescription that need collecting
        /// </summary>
        public void UpdatePrescriptionsToCollect()
        {
            PrescriptionToCollect.Items.Clear(); //reset items
            foreach (Prescription node in ParentListHolder.FinalPrescriptionList) //for every prescription in the list
            {
                string CompletedStatus = node.GetCompleted(); //get completed status
                if (CompletedStatus.Equals("Not Completed")) //if no collected 
                {
                    string displayname = node.GetPatientName() + ": " + node.GetDateIssued(); //makes a unique indentifer
                    PrescriptionToCollect.Items.Add(displayname); //adds to collect list
                }
            }
        }
        /// <summary>
        /// prescription collected button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Collected_Click(object sender, EventArgs e)
        {
            if (PrescriptionToCollect.SelectedItems.Count > 0) //if something is selected
            {
                string[] tempvalues = PrescriptionToCollect.SelectedItem.ToString().Split((":").ToCharArray()); //get pieces of the unique id
                foreach (Prescription node in ParentListHolder.FinalPrescriptionList) 
                {
                    //Made a Unique ID with date issued and Patient Name this breaks it down and checks against the classes
                    if (node.GetDateIssued().Equals(tempvalues[1].Substring(1)) && node.GetPatientName().Equals(tempvalues[0])) //Find the appropriate prescription class
                    {
                        node.SetCompleted("Completed"); //set status to completed
                        MessageBox.Show("Prescription Has Been Collected"); //show message
                        UpdatePrescriptionsToCollect(); //update XML file
                    }
                }
            }
            else 
            {
                MessageBox.Show("No Prescription Selected");
            }
        }


        #endregion
       /// <summary>
       /// When Date Issue is changed
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void DateIssue_ValueChanged(object sender, EventArgs e)
        {
            DateExpiry.MinDate = DateIssue.Value; //set min date as date issued
            DateExpiry.Enabled = true; //Allow Expiry date to be used
        }
        /// <summary>
        /// if close button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close_Click(object sender, EventArgs e)
        {
            this.Close(); //close form
        }
        /// <summary>
        /// customer waiting check box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Collecting_CheckedChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count < 0) //if there is no prescription selected
            {
                Collecting.Checked = false;  //set back to un-ticked
                MessageBox.Show("Must Select a Prescription First"); //show message
            }
        }
    }
}

