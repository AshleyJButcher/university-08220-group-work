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
    public partial class AddDoctor : Form
    {
        ListHolder parentlisthold; //Class Version of ListHolder
        List<Doctor> DoctorList = new List<Doctor>(); //List of Doctor Classes


        public AddDoctor(ListHolder listhold)
        {
            InitializeComponent();
            listhold = parentlisthold; // Loads the Listholder in
        }

        #region XML I/O

        /// <summary>
        /// Reads in Doctors.XML
        /// </summary>
        public void ReadOldFile()
        {
            XmlDocument DoctorFile = new XmlDocument();
            DoctorFile.Load("Doctors.xml"); //Loads Doctors XML file
            XmlNodeList DoctorsName = DoctorFile.GetElementsByTagName("Name"); //Get a List of Doctors by Doctor Name

            foreach (XmlNode node in DoctorsName) //For Each Doctor in DoctorList
            {
                string Name = node.InnerText; //Get Doctor Name
                Doctor doctor = new Doctor(Name); //Create a New Class
                DoctorList.Add(doctor); //Add Class to Class List
            }
        }
        /// <summary>
        /// Writes out Doctors XML file
        /// </summary>
        public void WriteDoctors()
        {
            using (XmlWriter writer = XmlWriter.Create("Doctors.xml")) //Create Doctors XML File
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Doctors"); //Write XML parent Node
                foreach (Doctor node in DoctorList) //For Each Doctor in DoctorList
                {
                    writer.WriteElementString("Name", node.GetDoctorName()); //Write name of the doctor
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
        #endregion
        /// <summary>
        /// Form Loads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDoctor_Load(object sender, EventArgs e)
        {
            ReadOldFile(); //Load Doctors
        }

        /// <summary>
        /// Add Doctor Button Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDoc_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "") //If there is something in Name Box
            {
                Doctor newdoc = new Doctor(txtName.Text); //Create a New Class
                DoctorList.Add(newdoc); //Add to the List
                WriteDoctors(); //Write Out Doctors Including the New One
                this.Hide(); //Close the Form
            }

        }
        /// <summary>
        /// Exit This Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
