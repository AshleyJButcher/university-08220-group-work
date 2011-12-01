using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class ListHolder
    {
       public enum Usertype { Cashier, Pharmacist, Administrator };
       public List<Users> UserList = new List<Users>();
       public List<Prescription> FinalPrescriptionList = new List<Prescription>();
    }
}
