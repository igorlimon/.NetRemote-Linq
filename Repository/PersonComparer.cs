using System.Collections.Generic;

namespace Repository
{
    public class PersonComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if (x.BirthDate == y.BirthDate)
            {
                return 0;
            }

            if (x.BirthDate < y.BirthDate)
            {
                return -1;
            }

            return 1;
        }
    }
}