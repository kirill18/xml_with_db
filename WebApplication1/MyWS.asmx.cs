using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using WebApplication1.Model;

namespace WebApplication1
{
    /// <summary>
    /// Сводное описание для MyWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class MyWS : System.Web.Services.WebService
    {
        private MyDCDataContext dc;
        public MyWS (string str)
        {
            dc = new MyDCDataContext(str);//знаю что это костыль , но он просто необходим
        }
        /*private class InsertPeople
        {
            int Id { get; set; }
            public string FIO { get; set; }
            public DateTime DateSalaryDate { get; set; }
            public int IdSalary { get; set; }
        }*/
        [WebMethod]
        public void AddPersonSalary(string fio, DateTime salaryDate, double salary)
        {

            PeoplesSalary dbPeopleSalary = new PeoplesSalary
            {
                Salary = (float)salary
            };
            dc.PeoplesSalary.InsertOnSubmit(dbPeopleSalary);
            dc.SubmitChanges();

            var stringPeopleSalary = from result in dc.PeoplesSalary
                                     where result.Salary == (float)salary
                                     select result;
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string resultString = jss.Serialize(stringPeopleSalary);
            List<PeoplesSalary> dbPeopleaSalaries = (List<PeoplesSalary>)jss.Deserialize(resultString, typeof(List<PeoplesSalary>));
            if (dbPeopleaSalaries.Count == 0)
            {
                return;
            }
            People dbPeople = new People
            {
                FIO = fio,
                SalaryDate = salaryDate,
                IdSalary = dbPeopleaSalaries[0].Id
            };
            dc.People.InsertOnSubmit(dbPeople);
            dc.SubmitChanges();
        }

        [WebMethod]
        public DBPeople GetContactById(string contactId)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var peoples = from result in dc.People
                          where result.Id == int.Parse(contactId)
                          select result;
            string resultString = jss.Serialize(peoples);//для запроса по таблице контактов

            List<DBPeople> dbPeoples = (List<DBPeople>)jss.Deserialize(resultString, typeof(List<DBPeople>));
            if (dbPeoples.Count == 0)//учитываем что возможно контакты пусты
            {
                dbPeoples.Add(new DBPeople
                {
                    Id = 0,
                    FIO = "empty",
                    IdSalary = 0,
                    Salary = 0.0,
                    DateSalaryDate = DateTime.MinValue
                });
                return dbPeoples[0];
            }

            var peopleaSalaries = from result in dc.PeoplesSalary
                                  where result.Id == dbPeoples[0].IdSalary
                                  select result;
            resultString = jss.Serialize(peopleaSalaries);//для запроса по таблице номеров
            List<DBPeopleSalary> dbPeopleSalaries = (List<DBPeopleSalary>)jss.Deserialize(resultString, typeof(List<DBPeopleSalary>));

            if (dbPeopleSalaries.Count == 0)
            {
                dbPeoples[0].IdSalary = 0;
                dbPeoples[0].Salary = 0.0;
            }
            else
            {
                dbPeoples[0].Salary = dbPeopleSalaries[0].Salary;
                dbPeoples[0].IdSalary = dbPeopleSalaries[0].Id;
            }
            return dbPeoples[0];
        }
    }
}
