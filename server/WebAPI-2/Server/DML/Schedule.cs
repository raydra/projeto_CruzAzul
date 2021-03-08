using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Server.DML
{
    public class Schedule
    {
        public int Id { get; set; }
        public string WeekDay { get; set; }
        public int Hour_Begin { get; set; }
        public int Hour_End { get; set; }
        public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }
    }
}
