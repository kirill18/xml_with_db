using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace CA_XML_with_DB.Model
{
    class XMLFilesClass
    {
        private string _directoryFiles; 
        private readonly string _directoryFileOriginal =string.Format(Environment.CurrentDirectory.ToString()+"\\source");
                    
        public XMLFilesClass(string dir)
        {
            _directoryFiles = dir;
        }
        public void Processing(string temp=null)//start
        {
            List<XElement> list = GetListXMLTag(_directoryFileOriginal);//remember template xml
            GetListXMLTag(_directoryFiles, list);
        }
        #region don't look
        private string GetOccurs(string dir)
        {
            XmlDocument xmlDocument = new XmlDataDocument();
            xmlDocument.Load(dir);
            XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(xmlDocument.NameTable);
            xmlNamespaceManager.AddNamespace("xs", "http://www.w3.org/2001/XMLSchema");
            XmlNode xmlNode;
            XmlElement element = xmlDocument.DocumentElement;
            xmlNode = element.SelectSingleNode("descendant::xs:element[@ref=\"Person\"]", xmlNamespaceManager);
            try//if this xml , do't coorect . "return" give null
            {
                return xmlNode.Attributes["maxOccurs"].Value;
            }
            catch (NullReferenceException)
            {

                return "";
            }
        }//get Occurs
        string[] GetDirectory(string directoryFiles)
        {
            if (directoryFiles == null)
            {
                return null;
            }
            try
            {
                return Directory.GetFiles(directoryFiles, "*.xml");
            }
            catch (DirectoryNotFoundException)
            {
                return null;
            }
            
        }//gat all files from directory

        List<XElement> FindChild(string p_xmlfile)
        {
            List<XElement> list = new List<XElement>();
            RecursionFindChild(XElement.Load(p_xmlfile).Elements(), list);
            return list;
        }//first step

        void RecursionFindChild(IEnumerable<XElement> xEnum, List<XElement> list)
        {
            foreach (var item in xEnum)
            {
                var child = item.Elements();
                list.Add(item);
                if (child.Any())
                {
                    RecursionFindChild(child, list);
                }
            }
        }//add subclasses
        #endregion
        List<XElement> GetListXMLTag(string xlmDirectory, List<XElement> _listOriginalElements = null)
        {
            //These comments facilitate understanding of what's going on

            string[] directory = GetDirectory(xlmDirectory);//get all files with the extension * .xml
            if (directory == null)
            {
                Console.WriteLine("empty directory or check you string");
                return null;
            }
            List<XElement> list = new List<XElement>();//is filled with a list of tags from file
            for (int i = 0, q = 0, wrongNumber=0; i < directory.Length; i++)
            {
                HandlerRequests h = new HandlerRequests();//working with DataBase(упрощенно)
                Console.WriteLine(directory[i]);//show name file
                list = FindChild(directory[i]);
                if (_listOriginalElements != null)
                {
                    //Console.WriteLine(GetOccurs(directory[i]));//this ,don't need
                        //q < шаблонаxml длина-1
                    for (wrongNumber=0,q= 0; q < (_listOriginalElements.Count - 1); q++)
                    {
                        if (list[q].Name != _listOriginalElements[q].Name)
                        {
                            Console.WriteLine("wrong this: "+list[q].Name);
                            ++wrongNumber;
                        }
                        
                    }
                        //нужно быть уверенно что 13 тэгов совпадают

                    if (_listOriginalElements[_listOriginalElements.Count - 1].Name == list[list.Count - 1].Name)//тут проверяется концовки
                    {
                        q++;
                    }
                    else
                    {
                        ++wrongNumber;
                        Console.WriteLine("wrong this: " + list[q].Name);
                        if (wrongNumber == 13)//13 тегов не совпадает , наверника все не верно
                        {
                            Console.WriteLine("maybe wrong all files ???");
                        }
                    }

                    if (q == _listOriginalElements.Count)
                    {
                        List<DataFromXML> list_r = new List<DataFromXML>();
                        for (int j = 10; j < list.Count; )//countdown begins with the first person
                        {
                            try
                            {
                                if ((j + 2) < list.Count)
                                {
                                    h.AddPersonSalary(list[j].Value, DateTime.Parse(list[j+1].Value.ToString()),
                                        Double.Parse(list[j+2].Value));
                                    j += 3;//go to the next person . if out range , my for 
                                }
                                else
                                {
                                    break;
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Incorrect values \nCheck your value/XML");
                                break;
                            }
                            catch (NullReferenceException)
                            {
                                Console.WriteLine("Enter null argument");
                                break;
                            }
                        }
                    }
                }
            }
            return list;//need for get template xml
        }//each file will compare
    }
}
