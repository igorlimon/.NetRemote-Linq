using System;
using System.Collections.Generic;
using System.Linq;
using Repository;

namespace Week8
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new BlogRepository(@"abc.json");
            IList<Person> persons = repo.GetAllPersons();
            foreach (var person in persons)
            {
                Console.WriteLine(person);
            }
        }

        private static Person CopyPerson(Person person)
        {
            throw new NotImplementedException();
        }

        private static void IncreaseAgeDependOnGender(Person person, int age)
        {
            throw new NotImplementedException();
        }

        private static void SetBirthday(Person person, DateTime date)
        {

        }

        private static void RemoveVowelsFromFirstname(Person person)
        {
            throw new NotImplementedException();
        }

        private static List<Person> FindAllPersonWithFirstLetterAInTheLastname(List<Person> person)
        {
            throw new NotImplementedException();
        }

        /*
         * 1. Add method that will create a copy of person(init new object through constructor)
         * 2. Add method that will receive Person object increase age with 10 years for men and with 5 years for women, if not specified with 20
         * 3. Add method that will receive Person object and DateTime. Set received date as BirthDay
         * 4. Add method that will remove all vowels from Firstname
         * 5. Add method that will find all person that Lastname start with 'A'
         * 6. Add class Event that will have event date, event name, list of attendees, number of places.
         *      Class will contain a method that will return number of available places. Number of places will be readonly property.
         *      Add method that will register one person to event and another method that will register list of persons(pass list of person as argument or use params keyword)
         *      Class will has property IsFull that will return true if available places exist otherwise false     
         */
    }
}