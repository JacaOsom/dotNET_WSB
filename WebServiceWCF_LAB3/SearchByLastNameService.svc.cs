using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WebServiceWCF_LAB3
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : ISearchByLastNameService
    {

        public string GetDataByLastName(string lastName)
        {
            List<Person> personList = new List<Person>();
            personList.Add(new Person("Jacek", "Placek", "Gdańsk, ul. Zielona 2A"));
            personList.Add(new Person("Marian", "Bogucki", "Gdańsk, ul. Piekarnicza 60"));
            personList.Add(new Person("Agnieszka", "Kożuchowska", "Warszawa, ul. Leśmiana 5"));
            personList.Add(new Person("Karolina", "Nowak", "Bydgoszcz, ul. Gdańska 2A/15"));
            personList.Add(new Person("Józef", "Wiśniewski", "Gdynia, ul. Storczyków 11B"));

            bool isSearching = false;
            var result = "";

            foreach (var item in personList)
            {
                if (item.LastName.Equals(lastName))
                {
                    isSearching = true;
                    result = item.FirstName + " " + item.LastName + " " + item.Address;
                    break;
                } 
                else
                {
                    isSearching = false;
                    result = "brak";
                }
            }
            return result;
        }
    }
}
