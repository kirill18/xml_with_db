using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using WebApplication1;
using WebApplication1.Model;
using CA_XML_with_DB.Model;
namespace CA_XML_with_DB
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                XMLFilesClass element =
                    new XMLFilesClass(
                        args[0]);
                element.Processing();
            }
            Console.ReadKey();
        }
    }
}