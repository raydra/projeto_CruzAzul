using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAPI2.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CPF { get; set; }
        public string Email { get; set; }
        public int Whatsapp { get; set; }
    }
}
