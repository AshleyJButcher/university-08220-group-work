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
        ListHolder parentlisthold;
        public AddDoctor(ListHolder listhold)
        {
            InitializeComponent();
            listhold = parentlisthold;
        }

        List<Doctor> DoctorList = new List<Doctor>();

        public void ReadOldFile()
        {
            XmlDocument DoctorFile;
            DoctorFile = new XmlDocument();
            DoctorFile.Load("Doctors.xml");
            XmlNodeList DoctorsName = DoctorFile.GetElementsByTagName("Name");


            foreach (XmlNode node in DoctorsName)
            {
                string Name = node.InnerText;
                Doctor doctor = new Doctor(Name);

                DoctorList.Add(doctor);
            }
        }

        public void WriteDoctors()
        {
            using (XmlWriter writer = XmlWriter.Create("Doctors.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Doctors");
                foreach (Doctor node in DoctorList)
                {
                    writer.WriteElementString("Name", node.GetDoctorName());
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        private void AddDoctor_Load(object sender, EventArgs e)
        {
            ReadOldFile();
        }

        private void AddDoc_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                Doctor newdoc = new Doctor(txtName.Text);
                DoctorList.Add(newdoc);
                WriteDoctors();
                this.Hide();
            }

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
