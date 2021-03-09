using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace API_MVC.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CRM { get; set; }
        public string Specialty { get; set; }
    }
}
