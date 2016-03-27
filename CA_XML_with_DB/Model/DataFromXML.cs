using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_XML_with_DB.Model
{
    public class DataFromXML
    {
        //класс , будет использоваться в модифицированой версии
        //для addSalaryPeople
        public string FIO { get; set; }
        public DateTime SalaryDate { get; set; }
        public double Salary { get; set; }
    }
}
