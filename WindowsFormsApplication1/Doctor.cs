using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Doctor
    {
        private string name; //Doctor Name
        /// <summary>
        /// Creates a New Instance of This Class
        /// </summary>
        /// <param name="Name">Name of Doctor</param>
        public Doctor(string Name) //Constructor Method
        {
            name = Name;
        }
        /// <summary>
        /// Gets Doctor Name
        /// </summary>
        /// <returns>Doctor Name</returns>
        public string GetDoctorName()
        {
            return name;
        }
    }
}
