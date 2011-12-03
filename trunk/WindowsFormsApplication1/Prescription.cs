using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class Prescription
    {
        private string PatientName;
        private string DoctorName;
        private string PharmacistName;
        private string DateIssued;
        private string DateExpiry;
        private string Instructions;
        private string Completed;
        private string Price;
        public List<string> ItemName = new List<string>();
        public List<string> Quantity = new List<string>();
        /// <summary>
        /// Constructor Method
        /// </summary>
        /// <param name="name"> Patient Name</param>
        public Prescription(string name)
        {
            SetPatientName(name);
        }
        /// <summary>
        /// Sets Patient Name
        /// </summary>
        /// <param name="name">Patient Name</param>
        public void SetPatientName(string name){
            PatientName = name;
        }
        /// <summary>
        /// Gets Patient Name
        /// </summary>
        /// <returns>Patient Name</returns>
        public string GetPatientName(){
            return PatientName;
        }
        /// <summary>
        /// Sets Doctor Name
        /// </summary>
        /// <param name="name">Doctor name</param>
        public void SetDoctorName(string name)
        {
            DoctorName = name;
        }
        /// <summary>
        /// Gets Doctor Name
        /// </summary>
        /// <returns>Doctor Name</returns>
        public string GetDoctorName()
        {
            return DoctorName;
        }
        /// <summary>
        /// Set Pharmacist Name
        /// </summary>
        /// <param name="name">Pharmacist Name</param>
        public void SetPharmacistName(string name)
        {
            PharmacistName = name;
        }
        /// <summary>
        /// Gets Pharmacist Name
        /// </summary>
        /// <returns>Pharmacist Name</returns>
        public string GetPharmacistName()
        {
            return PharmacistName;
        }
        /// <summary>
        /// Sets Date of Issue
        /// </summary>
        /// <param name="Date">Date Issued</param>
        public void SetDateIssued(string Date)
        {
            DateIssued = Date;
        }
        /// <summary>
        /// Gets Date Issued
        /// </summary>
        /// <returns>Date Issued</returns>
        public string GetDateIssued()
        {
            return DateIssued;
        }
        /// <summary>
        /// Sets Pharmacists Instructions
        /// </summary>
        /// <param name="instruction">Instructions</param>
        public void SetInstructions(string instruction)
        {
            Instructions = instruction;
        }
        /// <summary>
        /// Returns Pharmacists Instructions
        /// </summary>
        /// <returns>Instructions</returns>
        public string GetInstruction()
        {
            return Instructions;
        }
        /// <summary>
        /// Sets Date of Expiry
        /// </summary>
        /// <param name="Date">Expiry Date</param>
        public void SetDateExpiry(string Date)
        {
            DateExpiry = Date;
        }
        /// <summary>
        /// Gets Date of Expiry
        /// </summary>
        /// <returns>Expiry Date</returns>
        public string GetDateExpiry()
        {
            return DateExpiry;
        }
        /// <summary>
        /// Sets Whether the prescription has been collect or not
        /// </summary>
        /// <param name="status">Collected or Not </param>
        public void SetCompleted(string status)
        {
            Completed = status;
        }
        /// <summary>
        /// Gets Whether the prescription has been collected or not
        /// </summary>
        /// <returns>Collected or Not</returns>
        public string GetCompleted()
        {
            return Completed;
        }
        /// <summary>
        /// Sets Total Price of prescription
        /// </summary>
        /// <param name="value">Price</param>
        public void SetPrice(string value)
        {
            Price = value;
        }
        /// <summary>
        /// Gets Total Price of Prescription
        /// </summary>
        /// <returns>Price</returns>
        public string GetPrice()
        {
            return Price;
        }
        /// <summary>
        /// Adds Item to Item List
        /// </summary>
        /// <param name="NameofItem">Item Name</param>
        public void AddItemNameList(string NameofItem)
        {
            ItemName.Add(NameofItem);
        }
        /// <summary>
        /// Adds Quantity value to Quantity List
        /// </summary>
        /// <param name="num">Quantity</param>
        public void AddQuantity(string num)
        {
            Quantity.Add(num);
        }


    }
}
