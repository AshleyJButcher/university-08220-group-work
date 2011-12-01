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
        double Price = 0.1;
        ColumnHeader columnheader;		// Used for creating column headers.
        ListViewItem listviewitem;		// Used for creating listview items.	

        ListHolder ParentListHolder;
        string PatientName;
        string DoctorName;

        List<Prescription> ToDoPrescriptList = new List<Prescription>();

        public Pharmacist(ListHolder listhold)
        {
            InitializeComponent();
            DodgyBobStockControl.StockControl.INITIALISE("SureHealthItems.txt"); //Load In Sure Health Stock Control
            DodgyBobStockControl.StockControl.LOAD(); 
            SetupListview(); //Adds Headers to ListView
            ParentListHolder = listhold;
        }

        public void SetupListview()
        {

            // Create some column headers for the data. 
            columnheader = new ColumnHeader();
            columnheader.Text = "Item Name";
            this.listView1.Columns.Add(columnheader);

            columnheader = new ColumnHeader();
            columnheader.Text = "Quantity";
            this.listView1.Columns.Add(columnheader);

            columnheader = new ColumnHeader();
            columnheader.Text = "Price";
            this.listView1.Columns.Add(columnheader);

            columnheader = new ColumnHeader();
            columnheader.Text = "Use By Date";
            this.listView1.Columns.Add(columnheader);
        }
       

        private void Pharmacist_Load(object sender, EventArgs e)
        {
            DateExpiry.MinDate = DateTime.Now.Date;
            foreach (Users LoadUsers in ParentListHolder.UserList)
            {
                if (LoadUsers.GetUserStatus() == ListHolder.Usertype.Pharmacist) //Is this not your name?
                    PharmaCombo.Items.Add(LoadUsers.GetUsername());   
            }
            ReadToDoPrescriptionsFile();
            ReadPrescriptionsFile();
            #region Check if more than 24 hours have gone by
            foreach (Prescription prescript in ParentListHolder.FinalPrescriptionList)
            {
                string dateissued = prescript.GetDateIssued();
                DateTime date = Convert.ToDateTime(dateissued);
                if (date.Add(TimeSpan.FromDays(1)) < DateTime.Today.Date && prescript.GetCompleted() == "Not Completed") //If It Has Not Been Collected
                {
                    MessageBox.Show(prescript.GetPatientName() + ": " + prescript.GetDateIssued() + " Prescription has not been collected please return items to stock");
                    int i = 0;
                    foreach (string itemname in prescript.ItemName)
                    {
                        DodgyBobStockControl.StockControl.DO("'" + itemname + "' restock " + prescript.Quantity[i] + " please");
                        i++;
                    }
                    if (DodgyBobStockControl.StockControl.SAVE() == true)
                    {
                        ParentListHolder.FinalPrescriptionList.Remove(prescript);
                    }
                }
            #endregion
                WritePrescription(); //this should remove any prescriptions that are out of date
                UpdatePrescriptionsToCollect();
            }
        }
        #region To Do Prescriptions
        public void ReadToDoPrescriptionsFile()
        {
            XmlDocument PrescriptionFile;
            PrescriptionFile = new XmlDocument();
            PrescriptionFile.Load("Prescriptions.xml");
            XmlNodeList Prescript = PrescriptionFile.GetElementsByTagName("Prescription");
            int index = 0;

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
                ToDoPrescriptList.Add(CurrentPrescript);
                PrescriptionList.Items.Add(CurrentPrescript.GetPatientName());
                index++;
            }
        }

        public void WriteToDoPrescription()
        {
            XmlWriterSettings set = new XmlWriterSettings();
            set.Indent = true;
            set.NewLineOnAttributes = true;
            using (XmlWriter writer = XmlWriter.Create("Prescriptions.xml", set))
            {

                writer.WriteStartDocument();
                writer.WriteStartElement("Prescriptions");
                foreach (Prescription node in ToDoPrescriptList)
                {
                    int amount = 0;
                    writer.WriteStartElement("Prescription");
                    writer.WriteElementString("Name", node.GetPatientName());
                    writer.WriteElementString("Doctor", node.GetDoctorName());
                    writer.WriteElementString("Instructions", node.GetInstruction());
                    foreach (string item in node.ItemName)
                    {
                        writer.WriteStartElement("Item");
                        writer.WriteAttributeString("Quantity", node.Quantity[amount]);
                        writer.WriteString(item);
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    amount++;
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
        #endregion

        #region Completed Prescriptions

        public void ReadPrescriptionsFile()
        {
            XmlDocument PrescriptionFile;
            PrescriptionFile = new XmlDocument();
            PrescriptionFile.Load("CompletedPrescriptions.xml");
            XmlNodeList Prescript = PrescriptionFile.GetElementsByTagName("Prescription");
            int index = 0;

            foreach (XmlNode node in Prescript)
            {
                string Name = node["Name"].InnerText;
                string Doctor = node["Doctor"].InnerText;
                //string instructions = node["Instructions"].InnerText;
                string Price = node["Price"].InnerText;
                string DateIssue = node["DateIssue"].InnerText;
                string DateExpiry = node["DateExpiry"].InnerText;
                string ReadPrice = node["Price"].InnerText;
                string PharaName = node["Pharmacist"].InnerText;
                string PresStatus = node["Completed"].InnerText;
                XmlNodeList Items = node.SelectNodes("Item");
                Prescription CurrentPrescript = new Prescription(Name);
                CurrentPrescript.SetDoctorName(Doctor);
               // CurrentPrescript.SetInstructions(instructions);
                CurrentPrescript.SetPharmacistName(PharaName);
                CurrentPrescript.SetPrice(ReadPrice);
                CurrentPrescript.SetDateIssued(DateIssue);
                CurrentPrescript.SetDateExpiry(DateExpiry);
                CurrentPrescript.SetCompleted(PresStatus);

                foreach (XmlNode node2 in Items)
                {
                    string NameItem = node2.InnerText;
                    CurrentPrescript.AddItemNameList(NameItem);
                    string Number = node2.Attributes["Quantity"].InnerText;
                    CurrentPrescript.AddQuantity(Number);
                }
                ParentListHolder.FinalPrescriptionList.Add(CurrentPrescript);
                index++;
            }
        }

        public void WritePrescription()
        {
            XmlWriterSettings set = new XmlWriterSettings();
            set.Indent = true;
            set.NewLineOnAttributes = true;
            using (XmlWriter writer = XmlWriter.Create("CompletedPrescriptions.xml", set))
            {

                writer.WriteStartDocument();
                writer.WriteStartElement("Prescriptions");
                foreach (Prescription node in ParentListHolder.FinalPrescriptionList)
                {
                    int amount = 0;
                    writer.WriteStartElement("Prescription");
                    writer.WriteElementString("Name", node.GetPatientName());
                    writer.WriteElementString("Doctor", node.GetDoctorName());
                    writer.WriteElementString("Pharmacist", node.GetPharmacistName());
                    writer.WriteElementString("Price", node.GetPrice());
                    writer.WriteElementString("DateIssue", node.GetDateIssued());
                    writer.WriteElementString("DateExpiry", node.GetDateExpiry());
                    writer.WriteElementString("Completed", node.GetCompleted());
                    foreach (string item in node.ItemName)
                    {
                        writer.WriteStartElement("Item");
                        writer.WriteAttributeString("Quantity", node.Quantity[amount]);
                        writer.WriteString(item);
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    amount++;
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        #endregion

        #region Prescription Certificates
        private void FixedPrice_Click(object sender, EventArgs e)
        {
            Price = 7.5;
            MessageBox.Show("Patient will pay a fixed price of £7.50");
        }

        private void Free_Click(object sender, EventArgs e)
        {
            Price = 0.0;
            MessageBox.Show("Patient will Not pay for this prescription");
        }
        #endregion
        
        private void PrescriptionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            listView1.Clear();
            SetupListview();
            Prescription loadprescript = ToDoPrescriptList[PrescriptionList.SelectedIndex];
            for (int totalitems = 0; totalitems < loadprescript.ItemName.Count; totalitems++ )
            {
                listviewitem = new ListViewItem(loadprescript.ItemName[totalitems]);
                listviewitem.SubItems.Add(loadprescript.Quantity[totalitems]);
                string price = DodgyBobStockControl.StockControl.ASK("'" + loadprescript.ItemName[totalitems] + "' cost please");
                listviewitem.SubItems.Add(price);
                string expiry = DodgyBobStockControl.StockControl.ASK("'" + loadprescript.ItemName[totalitems] + "' expiry please");
                listviewitem.SubItems.Add(expiry);
                PatientName = loadprescript.GetPatientName(); //These are used later on for saving completed prescriptions
                DoctorName = loadprescript.GetDoctorName();  //**
                this.listView1.Items.Add(listviewitem);
            }
            UpdateColumnSize();
            txtInstructions.Text = loadprescript.GetInstruction();

        }

        public void UpdateColumnSize()
        {
            foreach (ColumnHeader ch in this.listView1.Columns)
            {
                ch.Width = -2;
            }
        }

        private void Complete_Click(object sender, EventArgs e)
        {
            double TotalPrice = 0;
            if (listView1.Items.Count > 0 && PharmaCombo.Text != null)
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    #region Total Price
                    string pricestring = listView1.Items[i].SubItems[2].Text.Substring(1);
                    string quantitystring = listView1.Items[i].SubItems[1].Text;
                    double price = double.Parse(pricestring); //Items Price
                    int quantity = int.Parse(quantitystring); //Items Quantity
                    price = price * quantity; //price is quantity times items price
                    TotalPrice += price; //add the price to the total price
                    #endregion
                    DodgyBobStockControl.StockControl.DO("'" + listView1.Items[i].Text + "' consume " + quantity + " please");
                }

                #region Saving the data to a class
                Prescription tempprescrip = new Prescription(PatientName);
                if (Collecting.Checked == true)
                {
                    tempprescrip.SetCompleted("Completed");
                }
                else
                {
                    tempprescrip.SetCompleted("Not Completed");
                }
                tempprescrip.SetDoctorName(DoctorName);
                tempprescrip.SetPharmacistName(PharmaCombo.Text);
                tempprescrip.SetDateExpiry(DateExpiry.Text);
                tempprescrip.SetDateIssued(DateIssue.Text);
                tempprescrip.SetPrice(TotalPrice.ToString());
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    string itemnamestring = listView1.Items[i].Text;
                    string quantitystring = listView1.Items[i].SubItems[1].Text;
                    tempprescrip.ItemName.Add(itemnamestring);
                    tempprescrip.Quantity.Add(quantitystring);
                }
                ParentListHolder.FinalPrescriptionList.Add(tempprescrip);
                #endregion
                UpdatePrescriptionsToCollect();
                //Remove prescription class, write 
                #region Tidying Up
                for (int i = 0; i < ToDoPrescriptList.Count; i++)//Removes the completed prescription from the old list
                {
                    Prescription node = ToDoPrescriptList[i];
                    if (node.GetPatientName() == PatientName && node.GetDoctorName() == DoctorName && node.GetInstruction() == txtInstructions.Text)
                    {
                        ToDoPrescriptList.Remove(node);
                        break;
                    }
                }

                WriteToDoPrescription(); //Re-Writes To Do Prescriptions without
                ToDoPrescriptList.Clear(); //Cleans the List
                PrescriptionList.Items.Clear();
                ReadToDoPrescriptionsFile(); //Reads the Prescriptions Back
                listView1.Items.Clear();
                txtInstructions.Text = "";
                Collecting.Checked = false;

                #endregion
                if (File.Exists("CompletedPrescription.xml") == true)
                    ReadPrescriptionsFile();
                WritePrescription();

                if (Price != 0.1)
                    TotalPrice = Price;

                ToPay Newform = new ToPay("£" + string.Format("{0:0.00}", TotalPrice)); //formats the price with two decimal places
                Newform.Show();
            }
        }

        #region  Prescriptions To Collect
        public void UpdatePrescriptionsToCollect()
        {
            PrescriptionToCollect.Items.Clear();
            foreach (Prescription node in ParentListHolder.FinalPrescriptionList)
            {
                string CompletedStatus = node.GetCompleted();
                if (CompletedStatus.Equals("Not Completed"))
                {
                    string displayname = node.GetPatientName() + ": " + node.GetDateIssued();
                    PrescriptionToCollect.Items.Add(displayname);
                }
            }
        }

        private void Collected_Click(object sender, EventArgs e)
        {
            if (PrescriptionToCollect.Items.Count > 0)
            {
                string[] tempvalues = PrescriptionToCollect.SelectedItem.ToString().Split((":").ToCharArray());
                foreach (Prescription node in ParentListHolder.FinalPrescriptionList)
                {
                    //Made a Unique ID with date issued and Patient Name this breaks it down and checks against the classes
                    if (node.GetDateIssued().Equals(tempvalues[1].Substring(1)) && node.GetPatientName().Equals(tempvalues[0]))
                    {
                        node.SetCompleted("Completed");
                        MessageBox.Show("Prescription Has Been Collected");
                        UpdatePrescriptionsToCollect();
                    }
                }
            }
        }


        #endregion

        private void DateIssue_ValueChanged(object sender, EventArgs e)
        {
            DateExpiry.MinDate = DateIssue.Value;
            DateExpiry.Enabled = true;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

