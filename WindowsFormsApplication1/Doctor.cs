using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Doctor
    {
        string name;

        public Doctor(string Name)
        {
            name = Name;
        }

        public string GetDoctorName()
        {
            return name;
        }
    }
}
