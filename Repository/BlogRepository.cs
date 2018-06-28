using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Repository
{
    public class BlogRepository
    {
        private readonly string _userFilePath;

        public BlogRepository(string userFilePath)
        {
            _userFilePath = userFilePath;
        }

        public IList<Person> GetAllPersons()
        {
            var persons = new List<Person>();
            if (File.Exists(_userFilePath))
            {
                try
                {
                    string templateStr = File.ReadAllText(_userFilePath);
                    persons = JsonHelper.Deserialize<List<Person>>(templateStr);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.ReadKey();
                }
            }

            return persons;
        }

        public void SaveAllPersons(IList<Person> persons, string newPath = null)
        {
            try
            {
                string path = newPath ?? _userFilePath;
                var jsonTemplates = JsonHelper.Serialize(persons.ToList());
                string templates = jsonTemplates;
                File.WriteAllText(path, templates);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
            }
        }

        private static void UpdatePersons(IList<Person> persons)
        {
            Random r = new Random();
            for (int i = 0; i < persons.Count; i++)
            {
                //persons[i].BirthDate = DateTime.Now.AddDays(-r.Next(7000, 14000));
                persons[i].Id = i;
            }
        }
    }
}
