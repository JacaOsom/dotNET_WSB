using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceWCF_LAB3
{
    public class Person
    {
        List<Person> personList = new List<Person>();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public Person() { }
        public Person(string firstName, string lastName, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
        }

    }
}