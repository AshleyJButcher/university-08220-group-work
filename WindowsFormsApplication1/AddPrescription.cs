using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApplication1
{
    public partial class AddPrescription : Form
    {
        ListHolder parentlistholder; //Parent List Holder
        List<Prescription> PrescriptList = new List<Prescription>();
        ListHolder.Usertype usertype; //Users Type

        public AddPrescription(ListHolder holder, ListHolder.Usertype value) //Constructor Method
        {
            InitializeComponent();
            parentlistholder = holder; //Loads in ListHolder
            parentlistholder.Initialise(); // Loads in Dodgy Bobs Stock Control System
            adddoc = new AddDoctor(parentlistholder); //Create a Instance of the AddDoctor Form
            usertype = value;
        }

        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPrescription_Load(object sender, EventArgs e)
        {
            UpdateDoctorCombo(); //Update Doctors Drop Down Box
            DodgyBobStockControl.StockControl.LOAD(); //Load Stock Control Data
            ItemCombo.Items.AddRange(DodgyBobStockControl.StockControl.GET_ITEMS()); //Add Items to Item Drop Down
            RemoveOutOfDateItems(); //Remove the Items That are Out of Date
        }
        /// <summary>
        /// Updates the Doctor Drop Down with all of the Doctors
        /// </summary>
        private void UpdateDoctorCombo() //Add Doctors to the Combo Box
        {
            XmlDocument DoctorsFile= new XmlDocument();
            DoctorsCombo.Items.Clear(); //Clean Items Out to Load New Ones In
            DoctorsFile.Load("Doctors.xml"); //Load In Doctors XML
            XmlNodeList DoctorsList = DoctorsFile.GetElementsByTagName("Name"); //Make a List of Doctors By Name
            foreach (XmlNode node in DoctorsList) //For Each Doctor in the list
            {
                DoctorsCombo.Items.Add(node.InnerText); //Add to Drop Down
            }
        }
        /// <summary>
        /// Removes Out of Date Items from the Items Drop Down
        /// </summary>
        public void RemoveOutOfDateItems()
        {
            int currentday = DateTime.Now.Date.Day; //Day Today
            int currentmonth = DateTime.Now.Date.Month; //Month Today
            int currentyear = DateTime.Now.Date.Year; //Current year

            for (int i = 0; i < ItemCombo.Items.Count; i++) //For Each Item in the Item Drop Down
            {
                string expirydate = DodgyBobStockControl.StockControl.ASK("'" + ItemCombo.Items[i].ToString() + "' expiry please"); ; //gets the expiry date
                expirydate = expirydate.Substring(14); //Removes "It Will Expire On "
                int expiryday = int.Parse(expirydate.Substring(0, 2)); //Gets the Day
                int expirymonth = int.Parse(expirydate.Substring(3, 2)); //Gets the Month
                int expiryyear = int.Parse(expirydate.Substring(6, 4)); //Gets the Year

                if (expiryday <= currentday && expirymonth <= currentmonth && expiryyear <= currentyear) //Check if it is out of date
                    ItemCombo.Items.Remove(ItemCombo.Items[i]); //Remove From the List
            }
        }
/// <summary>
/// Adjusts the Width of the Columns
/// </summary>
        public void UpdateColumnSize()
        {
            foreach (ColumnHeader ch in this.ItemView.Columns) //For Each Column
            {
                ch.Width = -2; //Update Width
            }
        }

        /// <summary>
        /// Add Item Button Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddItem_Click(object sender, EventArgs e)
        {
            ListViewItem listviewitem;		// Used for creating listview items.
            string ItemName = null; //Item Name
            bool QuantityUpdate = false; //Do We Need to Update Quantity
            int Location = -1; //Location in the List
            if (ItemCombo.Text != "") //If there is Text in the Drop Down
            {
                /*
                * SUBITEMS[0] is the product Name
                * SUBITEMS[1] is the quantity
                */
                for (int i = 0; i < ItemView.Items.Count; i++) //Loop Through the list checking if there are previous entries
                {
                    ItemName = ItemView.Items[i].SubItems[0].Text; //Selects the previous entry
                    if (ItemName == ItemCombo.Text) //If Just Quantity needs updating
                    {
                        QuantityUpdate = true; //We Need to update the quantity rather than create a new one
                        Location = i; //the location in the list to update the quantity
                        break; //Leave the Loop
                    }

                }

                if (QuantityUpdate == true) //If we need to update quantity
                {
                    int ItemCount = int.Parse(ItemView.Items[Location].SubItems[1].Text); //Get the Quantity as a Integer
                    ItemCount++; //Increment
                    ItemView.Items[Location].SubItems[1].Text = ItemCount.ToString(); //Write Back
                    QuantityUpdate = false; //Reset Quantity Update Flag
                }
                else //If we are adding new item
                {
                    listviewitem = new ListViewItem(ItemCombo.Text); //Add Item Name
                    listviewitem.SubItems.Add("1"); //Quantity Add 1
                    this.ItemView.Items.Add(listviewitem); //Add To ListView
                }

                UpdateColumnSize(); //Automatically Resize the columns
            }
        
        }
        /// <summary>
        /// Saves New Prescription File, Updates Stock and Cleans For a New Prescription
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, EventArgs e)
        {
            if (txtPatientName.Text.Equals("")) //If there is Nothing in Patient Name Box
            {
                MessageBox.Show("Please Enter a Patient Name"); //Show Error Message
            }
            else if (DoctorsCombo.Text.Equals("")) //If there is Nothing in Doctor Drop Down
            {
                MessageBox.Show("Please Select a Doctor"); //Show Error Message
            }
            else if (ItemView.Items.Count == 0) //If there is Nothing in Items View
            {
                MessageBox.Show("No Items Have Been Selected"); //Show Error Message
            }
            else if (txtInstructions.Text.Equals("")) //If there is Nothing in Instructions
            {
                MessageBox.Show("No Instructions have been typed"); //Show Error Message
            }
            else
            {
                bool allitemsinstock = true; //Flag for Items in Stock
                for (int i = 0; i < ItemView.Items.Count; i++) //For Every Item
                {
                    string quan = DodgyBobStockControl.StockControl.ASK("'" + ItemView.Items[i].SubItems[0].Text + "' stockcheck please"); //Check the Stock Available
                    quan = quan.Substring(8);// Gets rid of "We Have "
                    string[] tempvalues = quan.Split(' '); //Splits the string at " "'s
                    int quaninstock = int.Parse(tempvalues[0]); //Gets the values before the space
                    int quantocheck = int.Parse(ItemView.Items[i].SubItems[1].Text); //Gets the amount of Items in the prescription
                    if (quaninstock < quantocheck) //If we dont have enough items in stock
                    {
                        MessageBox.Show("Pharmacy has not got enough items in stock"); //Show Error Message
                        allitemsinstock = false; //Set the Flag
                    }
                }
                if (allitemsinstock) //If we have enough items in stock
                {
                    Prescription TempPrescriptionClass = new Prescription(txtPatientName.Text); //Create a New Prescription Class
                    TempPrescriptionClass.SetDoctorName(DoctorsCombo.Text); //Set Doctor Name
                    TempPrescriptionClass.SetInstructions(txtInstructions.Text); //Set Instructions
                    for (int i = 0; i < ItemView.Items.Count; i++) //For Each Item
                    {
                        TempPrescriptionClass.AddItemNameList(ItemView.Items[i].SubItems[0].Text); //Add Item Name to List
                        TempPrescriptionClass.AddQuantity(ItemView.Items[i].SubItems[1].Text); //Add Quantity to List
                    }
                    PrescriptList.Add(TempPrescriptionClass); //Add Class to Class List
                    if (File.Exists(@"Prescriptions.xml") == true) //Check If prescription file already exists                   
                        ReadOldFile(); //If So Read Old Values First
                    WritePrescription(); //Write Out Everything
                    MessageBox.Show("Prescription Saved"); //Tell User Prescription has been saved
                }
            }
            
        }
        

        /// <summary>
        /// Reads the Prescription Files and Loads them into classes
        /// </summary>
        public void ReadOldFile() {
            XmlDocument PrescriptionFile = new XmlDocument();
            PrescriptionFile.Load("Prescriptions.xml"); //Load Prescription File
            XmlNodeList Prescript = PrescriptionFile.GetElementsByTagName("Prescription"); //Get a List of Prescriptions
    
            foreach (XmlNode node in Prescript) //For Each Prescription in the list
            {
                string Name = node["Name"].InnerText; //Get Patient Name
                string Doctor = node["Doctor"].InnerText;  //Get Doctor Name
                string instructions = node["Instructions"].InnerText; //Get Instructions
                XmlNodeList Items = node.SelectNodes("Item");   //Creates a List of Items
                Prescription CurrentPrescript = new Prescription(Name); //Creates a New Class
                CurrentPrescript.SetDoctorName(Doctor); //Sets Doctor name to the value read in
                CurrentPrescript.SetInstructions(instructions);  //Sets Instructions to the value read in
                foreach (XmlNode node2 in Items) //For each Item in the list
                {
                    string NameItem = node2.InnerText;  //Read Item Name
                    CurrentPrescript.AddItemNameList(NameItem); //Set Item Name
                    string Number = node2.Attributes["Quantity"].InnerText; //Read Quantity
                    CurrentPrescript.AddQuantity(Number); //Set Quantity
                }
                PrescriptList.Add(CurrentPrescript); //Add Class to Class List
            }
        }
        /// <summary>
        /// Writes the Prescription XML file
        /// </summary>
        public void WritePrescription()
        {
            XmlWriterSettings set = new XmlWriterSettings();
            set.Indent = true; //Indents the Values
            set.NewLineOnAttributes = true; //Makes So Everything isnt on the same line
            using (XmlWriter writer = XmlWriter.Create("Prescriptions.xml", set)) //Create Prescription File
            {
                writer.WriteStartDocument();
                    writer.WriteStartElement("Prescriptions"); //Parent Node
                    foreach (Prescription node in PrescriptList) //For Each Prescription
                    {
                       int ListPos = 0; //Position in the List
                        writer.WriteStartElement("Prescription"); 
                        writer.WriteElementString("Name", node.GetPatientName()); //Writes Patient Name to XML File
                        writer.WriteElementString("Doctor", node.GetDoctorName()); //Writes Doctor Name to XML File
                        writer.WriteElementString("Instructions", node.GetInstruction()); //Writes Instructions to XML File
                        foreach(string item in node.ItemName) //For each item in prescription
                        {
                            writer.WriteStartElement("Item");
                            writer.WriteAttributeString("Quantity", node.Quantity[ListPos]); //Writes Item Quantity to XML File
                            writer.WriteString(item); //Writes Item Name to XML File
                            writer.WriteEndElement();
                            ListPos++; //Increments to Set next position in the list
                        }
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
        AddDoctor adddoc;
        /// <summary>
        /// Add New Doctor Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDoctor_Click(object sender, EventArgs e)
        {
            adddoc.Show(); //Show Form
        }
        /// <summary>
        /// Clears all the Items from the list view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_Click(object sender, EventArgs e)
        {
            if (ItemView.Items.Count > 0) //if there is a item selected
            {
                ItemView.Items.Clear(); //Clear Items in the List View
            }
            else //if not
            {
                MessageBox.Show("There are No Items to be Removed!"); //Show Error Message
            }
        }
        /// <summary>
        /// Remove Items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveItem_Click(object sender, EventArgs e)
        {
                if (ItemView.SelectedItems.Count > 0) //if no item is selected
                {
                    int value = int.Parse(ItemView.SelectedItems[0].SubItems[1].Text); //store the amount of items 
                    if (value > 1) //if there are more than one, you will take one away
                    {
                        value--; //Decrement 
                        ItemView.SelectedItems[0].SubItems[1].Text = value.ToString(); //set the new value
                    }
                    else //if your only removing one item
                    {
                        ItemView.Items.Remove(ItemView.SelectedItems[0]); //Remove Item
                    }

                }
                else
                {
                    MessageBox.Show("You Have Not Selected Anything!");
                }
        }
        /// <summary>
        /// Close the Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close_Click(object sender, EventArgs e)
        {
            MainForm form = new MainForm(usertype, parentlistholder);
            form.Show();
            this.Close();
        }
        /// <summary>
        /// When the Doctor Dropdown is clicked, it automatically reads in the doctors, to fix the add new doctor form bug
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoctorsCombo_Click(object sender, EventArgs e)
        {
            UpdateDoctorCombo(); //Update Doctor Drop Down
        }
  
   
    }
}
