using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Model
{
    public class DBPeople
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public DateTime DateSalaryDate { get; set; }
        public int IdSalary { get; set; }
        public double Salary { get; set; }
    }
}