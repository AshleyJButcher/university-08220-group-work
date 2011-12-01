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
        public AddPrescription(ListHolder holder)
        {
            InitializeComponent();
            parentlistholder = holder;
            parentlistholder.Initialise();
            // Create some column headers for the data. 
            columnheader = new ColumnHeader();
            columnheader.Text = "Item Name";
            this.ItemView.Columns.Add(columnheader);

            columnheader = new ColumnHeader();
            columnheader.Text = "Quantity";
            this.ItemView.Columns.Add(columnheader);
        }

        XmlDocument DoctorsFile;
        
        ColumnHeader columnheader;		// Used for creating column headers.
        ListViewItem listviewitem;		// Used for creating listview items.

        private void AddPrescription_Load(object sender, EventArgs e)
        {

            UpdateDoctorCombo();
            DodgyBobStockControl.StockControl.LOAD();
            ItemCombo.Items.AddRange(DodgyBobStockControl.StockControl.GET_ITEMS());
            RemoveOutOfDateItems();
        }
        /// <summary>
        /// Updates the Doctor Drop Down with all of the Doctors
        /// </summary>
        private void UpdateDoctorCombo()
        {
            //Add Doctors to the Combo Box
            DoctorsCombo.Items.Clear();
            DoctorsFile = new XmlDocument();
            DoctorsFile.Load("Doctors.xml");
            XmlNodeList DoctorsList = DoctorsFile.GetElementsByTagName("Name");
            foreach (XmlNode node in DoctorsList)
            {
                DoctorsCombo.Items.Add(node.InnerText);
            }
        }
        /// <summary>
        /// Removes Out of Date Items from the Items Drop Down
        /// </summary>
        public void RemoveOutOfDateItems()
        {
            int currentday = DateTime.Now.Date.Day;
            int currentmonth = DateTime.Now.Date.Month;
            int currentyear = DateTime.Now.Date.Year;

            for (int i = 0; i < ItemCombo.Items.Count; i++)
            {
                string expirydate = DodgyBobStockControl.StockControl.ASK("'" + ItemCombo.Items[i].ToString() + "' expiry please"); ; //gets the expiry date
                expirydate = expirydate.Substring(14); //Removes "It Will Expire On "
                int expiryday = int.Parse(expirydate.Substring(0, 2));
                int expirymonth = int.Parse(expirydate.Substring(3, 2));
                int expiryyear = int.Parse(expirydate.Substring(6, 4));

                if (expiryday <= currentday && expirymonth <= currentmonth && expiryyear <= currentyear)
                    ItemCombo.Items.Remove(ItemCombo.Items[i]);
            }
        }

        public void UpdateColumnSize()
        {
            foreach (ColumnHeader ch in this.ItemView.Columns)
            {
                ch.Width = -2;
            }
        }

        int ItemCount;
        private void AddItem_Click(object sender, EventArgs e)
        {
            if (AddItem.Text != "")
            {
                string ItemName = null;
                bool QuantityUpdate = false;
                int Location = -1;
                if (ItemCombo.Text != "")
                {
                    //SUBITEMS[0] is the product Name
                    //SUBITEMS[1] is the quantity
                    for (int i = 0; i < ItemView.Items.Count; i++) //Loop Through the list checking if there are previous entries
                    {
                        ItemName = ItemView.Items[i].SubItems[0].Text; //Selects the previous entry
                        if (ItemName == ItemCombo.Text)
                        {
                            QuantityUpdate = true; //We Need to update the quantity rather than create a new one
                            Location = i; //the location in the list to update the quantity
                            break;
                        }

                    }

                    if (QuantityUpdate == true)
                    {
                        ItemCount = int.Parse(ItemView.Items[Location].SubItems[1].Text);
                        ItemCount++;
                        ItemView.Items[Location].SubItems[1].Text = ItemCount.ToString();
                        QuantityUpdate = false;
                    }
                    else
                    {
                        listviewitem = new ListViewItem(ItemCombo.Text);
                        listviewitem.SubItems.Add("1");
                        this.ItemView.Items.Add(listviewitem);
                    }

                    UpdateColumnSize(); //Automatically Resize the columns
                }
            }
        }
        /// <summary>
        /// Saves New Prescription File, Updates Stock and Cleans For a New Prescription
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, EventArgs e)
        {
            if (txtPatientName.Text.Equals(""))
            {
                MessageBox.Show("Please Enter a Patient Name");
            }
            else if (DoctorsCombo.Text.Equals(""))
            {
                MessageBox.Show("Please Select a Doctor");
            }
            else if (ItemView.Items.Count == 0)
            {
                MessageBox.Show("No Items Have Been Selected");
            }
            else if (txtInstructions.Text.Equals(""))
            {
                MessageBox.Show("No Instructions have been typed");
            }
            else
            {
                bool allitemsinstock = true;
                for (int i = 0; i < ItemView.Items.Count; i++)
                {
                    string quan = DodgyBobStockControl.StockControl.ASK("'" + ItemView.Items[i].SubItems[0].Text + "' stockcheck please");
                    quan = quan.Substring(8);// Gets rid of "We Have "
                    string[] tempvalues = quan.Split(' '); //Splits the string at " "'s
                    int quaninstock = int.Parse(tempvalues[0]); //Gets the values before the space
                    int quantocheck = int.Parse(ItemView.Items[i].SubItems[1].Text);
                    if (quaninstock < quantocheck)
                    {
                        MessageBox.Show("Pharmacy has not got enough items in stock");
                        allitemsinstock = false;
                    }
                }
                if (allitemsinstock)
                {
                    Prescription TempPrescriptionClass = new Prescription(txtPatientName.Text);
                    TempPrescriptionClass.SetDoctorName(DoctorsCombo.Text);
                    TempPrescriptionClass.SetInstructions(txtInstructions.Text);
                    for (int i = 0; i < ItemView.Items.Count; i++)
                    {
                        TempPrescriptionClass.AddItemNameList(ItemView.Items[i].SubItems[0].Text);
                        TempPrescriptionClass.AddQuantity(ItemView.Items[i].SubItems[1].Text);
                    }
                    PrescriptList.Add(TempPrescriptionClass);
                    if (File.Exists("Prescription.xml") == true)
                        ReadOldFile();
                    WritePrescription();
                    MessageBox.Show("Prescription Saved");
                }
            }
            
        }
        

        /// <summary>
        /// Reads the Prescription Files and Loads them into classes
        /// </summary>
        public void ReadOldFile() {
            XmlDocument PrescriptionFile;
            PrescriptionFile = new XmlDocument();
            PrescriptionFile.Load("Prescriptions.xml");
            XmlNodeList Prescript = PrescriptionFile.GetElementsByTagName("Prescription");

          
            foreach (XmlNode node in Prescript)
            {
                string Name = node["Name"].InnerText;
                string Doctor = node["Doctor"].InnerText;
                string instructions = node["Instructions"].InnerText;
                XmlNodeList Items = node.SelectNodes("Item");                
                Prescription CurrentPrescript = new Prescription(Name);
                CurrentPrescript.SetDoctorName(Doctor);
                CurrentPrescript.SetInstructions(instructions);
                foreach (XmlNode node2 in Items)
                {
                    string NameItem = node2.InnerText; 
                    CurrentPrescript.AddItemNameList(NameItem);
                    string Number = node2.Attributes["Quantity"].InnerText;
                    CurrentPrescript.AddQuantity(Number);
                }
                PrescriptList.Add(CurrentPrescript);
            }
        }
        /// <summary>
        /// Writes the Prescription XML file
        /// </summary>
        public void WritePrescription()
        {
            XmlWriterSettings set = new XmlWriterSettings();
            set.Indent = true;
            set.NewLineOnAttributes = true;
            using (XmlWriter writer = XmlWriter.Create("Prescriptions.xml", set))
            {
        
                writer.WriteStartDocument();
                    writer.WriteStartElement("Prescriptions");
                    foreach (Prescription node in PrescriptList)
                    {
                       int amount = 0;
                        writer.WriteStartElement("Prescription");
                        writer.WriteElementString("Name", node.GetPatientName());
                        writer.WriteElementString("Doctor", node.GetDoctorName());
                        writer.WriteElementString("Instructions", node.GetInstruction());
                        foreach(string item in node.ItemName)
                        {
                            writer.WriteStartElement("Item");
                            writer.WriteAttributeString("Quantity", node.Quantity[amount]);
                            writer.WriteString(item);
                            writer.WriteEndElement();
                            amount++;
                        }
                        writer.WriteEndElement();
                        amount++;
                    }
                    writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
        /// <summary>
        /// Add New Doctor Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDoctor_Click(object sender, EventArgs e)
        {
            AddDoctor adddoc = new AddDoctor(parentlistholder);
            adddoc.Show();
        }
        /// <summary>
        /// Clears all the Items from the list view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_Click(object sender, EventArgs e)
        {
            if (ItemView.Items.Count > 0) //if no item is selected
            {
                ItemView.Items.Clear();
            }
            else
            {
                MessageBox.Show("There are No Items to be Removed!");
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
                        ItemView.Items.Remove(ItemView.SelectedItems[0]);
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
            this.Close();
        }
        /// <summary>
        /// When the Doctor Dropdown is clicked, it automatically reads in the doctors, to fix the add new doctor form bug
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoctorsCombo_Click(object sender, EventArgs e)
        {
            UpdateDoctorCombo();
        }
  
   
    }
}
