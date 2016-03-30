using System;
using System.Activities;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1;
using WebApplication1.Model;

namespace CA_XML_with_DB.Model
{
    
    class HandlerRequests
    {
        //переопределити эту строку !!!!!
        //от нее зависит работа с БД
        //другого способа не нашел
        private readonly string connectionString = global::CA_XML_with_DB.Properties.Settings.Default.DBSalaryConnectionString;
        


        //так как в задание о нем небыло речи , я просто показал что реализовал такую возможность
        //и он работает
        public DBPeople ShowById(int number)//show value int table by id
        {
            using (MyWS ws = new MyWS(connectionString))
            {
                DBPeople people = ws.GetContactById(string.Format("{0}", number));
                Console.WriteLine("ID:{0} Salary:{1} Date:{2} FIO:{3} IDSalary:{4}", people.Id, people.Salary, people.DateSalaryDate, people.FIO, people.IdSalary);
                return people;
            }
        }

        public bool AddPersonSalary(string fio, DateTime salaryDate, double salary)//add new value in table
        {
            if (fio == null | salaryDate == null)
            {
                throw new NullReferenceException();//в случае , если переданы null агргумент(ы) 
            }
            using (MyWS ws = new MyWS(connectionString))
            {
                try//проверка на содинение с бд
                {
                    ws.AddPersonSalary(fio, salaryDate, salary);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            //примеры
            //MyWS ws = new MyWS(connectionString);//для побключения веб сервиза
            //DBPeople people= ws.GetContactById("1");
            //ws.AddPersonSalary("Zoro Kolimov Robanov",DateTime.Parse("7/4/2016"), 38000.5);//добавление перса
            //people = ws.GetContactById("4");//поиск
            //Console.WriteLine("ID:{0} Salary:{1} Date:{2} FIO:{3} IDSalary:{4}", people.Id, people.Salary, people.DateSalaryDate, people.FIO, people.IdSalary);
        }
    }
}
