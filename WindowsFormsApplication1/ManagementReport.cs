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
        List<Prescription> PrescriptionsList = new List<Prescription>();
        public ManagementReport(ListHolder listholder)
        {
            InitializeComponent();
            prescriptions = listholder;

        }

        private void ManagementReport_Load(object sender, EventArgs e)
        {
            ReadPrescriptionsFile();
            ReadDoctorFile();

            #region Total sold by each doctor
            for (int i = 0; i < DoctorSoldView.Items.Count; i++)
           {
                foreach (Prescription node in PrescriptionsList)
                {
                    string doctorname = node.GetDoctorName();
                    string doctortocomparewith = DoctorSoldView.Items[i].Text;
                    if (doctorname.Equals(doctortocomparewith))
                    {
                        double addprice = double.Parse(DoctorSoldView.Items[i].SubItems[1].Text);
                        addprice += double.Parse(node.GetPrice());
                        DoctorSoldView.Items[i].SubItems[1].Text = addprice.ToString();
                    }
                }

           }
            #endregion


            #region Add Items to Listview
            prescriptions.Initialise();
            string[] Items = DodgyBobStockControl.StockControl.GET_ITEMS();
            int Counter = 0;
            foreach (string name in Items)
            {
                ItemQuantitySold.Items.Add(name);
                ItemQuantitySold.Items[Counter].SubItems.Add("0");
                Counter++;
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
                            double Quantity = double.Parse(ItemQuantitySold.Items[ListViewPos].SubItems[1].Text);
                            Quantity += int.Parse(node.Quantity[Counter]); //Adds Amount Sold to Total
                            ItemQuantitySold.Items[ListViewPos].SubItems[1].Text = Quantity.ToString();
                        }

                    }
                    Counter++;
                }
            }
            #endregion

        }

        public void ReadDoctorFile()
        {
            XmlDocument DoctorFile;
            DoctorFile = new XmlDocument();
            DoctorFile.Load("Doctors.xml");
            XmlNodeList DoctorsName = DoctorFile.GetElementsByTagName("Name");
            int i = 0;
            foreach (XmlNode node in DoctorsName)
            {

                string Name = node.InnerText;
               DoctorSoldView.Items.Add(Name);
               DoctorSoldView.Items[i].SubItems.Add("0");
               i++;
            }
        }

        private void FirstDayOfTheWeek_ValueChanged(object sender, EventArgs e)
        {
            
            DateTime hi;
            hi = FirstDayOfTheWeek.Value;
            if (hi.DayOfWeek.Equals(DayOfWeek.Monday))
            {
            }
            else
            {
                MessageBox.Show("Please Choose a Monday");
            }
        }

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
                string PharaName = node["Pharmacist"].InnerText;
                string PresStatus = node["Completed"].InnerText;
                XmlNodeList Items = node.SelectNodes("Item");
                Prescription CurrentPrescript = new Prescription(Name);
                CurrentPrescript.SetDoctorName(Doctor);
                // CurrentPrescript.SetInstructions(instructions);
                CurrentPrescript.SetPrice(Price);
                CurrentPrescript.SetPharmacistName(PharaName);
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
                PrescriptionsList.Add(CurrentPrescript);
                index++;
            }
        }

        private void Generate_Click(object sender, EventArgs e)
        {
            DateTime[] DaysInWeek = new DateTime[7];
            DaysInWeek[0] = FirstDayOfTheWeek.Value;
            double totalprice = 0.0;
            for (int i = 1; i < 7; i++)
            {
                DaysInWeek[i] = DaysInWeek[i - 1].AddDays(1);
            }

            foreach (Prescription node in PrescriptionsList)
            {
                for(int i = 0; i < 7; i++)
                {
                    if (node.GetDateIssued() == DaysInWeek[i].ToLongDateString())
                        totalprice += double.Parse(node.GetPrice());
                }
            }
            TotalWeeklySales.Text = "£" +  String.Format("{0:0.00}", totalprice.ToString());
        }
    }
}
