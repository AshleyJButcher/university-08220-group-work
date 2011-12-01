using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WindowsFormsApplication1
{
    public class ListHolder
    {
       public enum Usertype { Cashier, Pharmacist, Administrator };
       public List<Users> UserList = new List<Users>();
       public List<Prescription> FinalPrescriptionList = new List<Prescription>();
        /// <summary>
        /// Initialise dodgy bobs stock control system
        /// </summary>
       public void Initialise()
       {
           DodgyBobStockControl.StockControl.INITIALISE(); //Loads Dodystock.dat
           if(!DodgyBobStockControl.StockControl.AM_I_INITIALISED_YET) //Checks if it has worked
                DodgyBobStockControl.StockControl.INITIALISE("SureHealthItems.txt"); //if not load original
           DodgyBobStockControl.StockControl.LOAD(); 
       }


    }
}
