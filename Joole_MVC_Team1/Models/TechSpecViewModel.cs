using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Services;
using DAL.Models;

namespace Joole_MVC_Team1.Models
{
    public class TechSpecViewModel
    {
        public TechSpecViewModel(int PropID)
        {
            Service s = new Service();
            

        }

        public string propertyName { get; set; }

        public bool isTypeSpec { get; set; }
        public double singleValue { get; set; }

        public double min  { get; set; }

        public double max { get; set; }
    }
}