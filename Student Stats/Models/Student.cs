using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Student_Stats.Models
{
    public class Student
    {
        public int id { get; set; }
        public string name { get; set; }
        public string age { get; set; }
        public int phy { get; set; }
        public int chem { get; set; }
        public int maths { get; set; }
    }
}