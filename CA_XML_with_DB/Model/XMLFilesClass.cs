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
        private static string _directoryFiles; 
        private static readonly string _directoryFileOriginal =string.Format(Environment.CurrentDirectory.ToString()+"\\source");
                    //@"C:\Users\kira-\OneDrive\Documents\OneDriveOnlineStorage\OneDrive\Documents\Visual Studio 2013\Projects\CA_XML_with_DB\CA_XML_with_DB\source";
        public XMLFilesClass(string dir)
        {
            _directoryFiles = dir;
        }
        public void Processing(string temp=null)//запускает шарманку
        {
            List<XElement> list = GetListXMLTag(_directoryFileOriginal);//запоминает шаблон
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
            try
            {
                return xmlNode.Attributes["maxOccurs"].Value;
            }
            catch (NullReferenceException)
            {

                return "";
            }
        }//получает Occurs , если нету его то пусто . как приметь без усложнение кода не придумал
        string[] GetDirectory(string directoryFiles)
        {
            if (directoryFiles == null)
            {
                return null;
            }
            return Directory.GetFiles(directoryFiles, "*.xml");
        }//получение всех файлов из директории

        List<XElement> FindChild(string p_xmlfile)
        {
            List<XElement> list = new List<XElement>();
            RecursionFindChild(XElement.Load(p_xmlfile).Elements(), list);
            return list;
        }//первый спуск

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
        }//добавление подклассов
        #endregion
        List<XElement> GetListXMLTag(string xlmDirectory, List<XElement> _listOriginalElements = null)
        {
            //тут много комментарием из-за того .что самый сложный метод и для восприятия возможно сложно

            string[] directory = GetDirectory(xlmDirectory);//вытаскиваем все файлы с расширением *.xml
            List<XElement> list = new List<XElement>();//заполняется списком тегов из файла
            for (int i = 0, q = 0, wrongNumber=0; i < directory.Length; i++)
            {
                HandlerRequests h = new HandlerRequests();//работа с БД(упрощенно)
                Console.WriteLine(directory[i]);//вывод файла с которм работаем
                list = FindChild(directory[i]);//тут заполнение
                if (_listOriginalElements != null)
                {
                    Console.WriteLine(GetOccurs(directory[i]));
                        //самя сложная часть
                        //q < шаблонаxml длина-1(т.к. person может быть много из-за условия Occurs)
                    for (wrongNumber=q= 0; q < (_listOriginalElements.Count - 1); q++)
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
                    }

                    if (wrongNumber == 13)//13 тегов не совпадает , наверника все не верно
                    {
                        Console.WriteLine("maybe wrong all files ???");
                    }
                    GetOccurs(directory[i]);
                    if (q == _listOriginalElements.Count)
                    {
                        List<DataFromXML> list_r = new List<DataFromXML>();
                        for (int j = 10; j < list.Count;)//отсчет начинается с первого person
                        {
                            //добавление ,если есть person в данной xml
                            try
                            {
                                if ((j + 2) < list.Count)
                                {
                                    h.AddPersonSalary(list[j].Value, DateTime.Parse(list[j+1].Value.ToString()),
                                        Double.Parse(list[j+2].Value));
                                    j += 3;//здесь на +3 !!! а не +2 
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
            return list;//нужна только для возврата шаблона
        }//каждый файл будет сравнивать

        [Obsolete("Don't use")]
        private void Foo()
        {
            //string currDir = string.Format(Environment.CurrentDirectory.ToString()+"\\source");
            string[] directory;
            directory = Directory.GetFiles(_directoryFiles, "*.xml");
            for (int i = 0; i < directory.Length; ++i)
            {
                //Console.WriteLine(directory[i]);
                XmlTextReader xmlTextReader = new XmlTextReader(directory[i]);
                while (xmlTextReader.Read())
                {
                    if (xmlTextReader.Name == "xs:element")
                    {
                        if (xmlTextReader.Name == "ref:element")
                        {
                            Console.WriteLine("REF " + xmlTextReader.GetAttribute("ref")); //
                        }
                        else
                        {
                            if (xmlTextReader.Name == "type")
                            {
                                Console.WriteLine("TYPE " + xmlTextReader.GetAttribute("type")); //
                            }
                            else
                            {
                                Console.WriteLine("Default " + xmlTextReader.GetAttribute("name")); //
                            }
                        }
                    }
                    //Console.WriteLine(xmlTextReader.Name);
                }
            }
            #region xml

            //вставка в xml
            /*XmlTextWriter write = new XmlTextWriter("write.xml",Encoding.UTF8);
            write.WriteStartElement("project");//создание атрибута
            
            write.WriteStartElement("config");
            write.WriteAttributeString("name","Hello cat");
            write.WriteEndElement();

            write.WriteEndElement();//закрытие внешнего project
            write.Close();*/

            //считыние файла xml
            /*XmlTextReader xmlTextReader = new XmlTextReader("StorageDB.xml");
            
            
            while (xmlTextReader.Read())
            {
                if (xmlTextReader.Name == "xs:element")
                {
                    Console.WriteLine(xmlTextReader.GetAttribute("name"));//
                }
                //Console.WriteLine(xmlTextReader.Name);
            }
            Console.ReadKey();*/

            #endregion
            Console.ReadKey();
        }//плохой аналог , не подключать
    }
}
