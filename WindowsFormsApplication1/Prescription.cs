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
        string PharmacistName;
        string DateIssued;
        string DateExpiry;
        string Instructions;
        string Completed;
        string Price;
        public List<string> ItemName = new List<string>();
        public List<string> Quantity = new List<string>();

        public Prescription(string name)
        {
            SetPatientName(name);
        }

        public void SetPatientName(string name){
            PatientName = name;
        }

        public string GetPatientName(){
            return PatientName;
        }

        public void SetDoctorName(string name)
        {
            DoctorName = name;
        }

        public string GetDoctorName()
        {
            return DoctorName;
        }

        public void SetPharmacistName(string name)
        {
            PharmacistName = name;
        }

        public string GetPharmacistName()
        {
            return PharmacistName;
        }

        public void SetDateIssued(string Date)
        {
            DateIssued = Date;
        }

        public string GetDateIssued()
        {
            return DateIssued;
        }

        public void SetInstructions(string instruction)
        {
            Instructions = instruction;
        }

        public string GetInstruction()
        {
            return Instructions;
        }

        public void SetDateExpiry(string Date)
        {
            DateExpiry = Date;
        }

        public string GetDateExpiry()
        {
            return DateExpiry;
        }

        public void SetCompleted(string status)
        {
            Completed = status;
        }

        public string GetCompleted()
        {
            return Completed;
        }

        public void SetPrice(string value)
        {
            Price = value;
        }

        public string GetPrice()
        {
            return Price;
        }

        public void AddItemNameList(string NameofItem)
        {
            ItemName.Add(NameofItem);
        }

        public void AddQuantity(string num)
        {
            Quantity.Add(num);
        }


    }
}
