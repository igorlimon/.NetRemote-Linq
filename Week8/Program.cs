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
            var persons = repo.GetAllPersons();
            DisplayPersons(persons);
        }

        private static void SelectOperator(IList<Person> persons)
        {
            var birthDays = persons
                .Select(p => p.BirthDate);
            foreach (var birthDay in birthDays)
            {
                Console.WriteLine(birthDay);
            }

            var t = persons
                .Select(p => new B()
                { Text = $"{p.FirstName} {p.LastName}", Number = (int)p.Id });
            foreach (var b in t)
            {
                Console.WriteLine(b);
            }
        }

        private static void GroupByOperator(IList<Person> persons)
        {
            var g = persons
                .GroupBy(p => p.Gender)
                .ToList();
            foreach (IGrouping<Gender, Person> group in g)
            {
                Console.WriteLine($"{@group.Key}");
                foreach (Person person in @group)
                {
                    Console.WriteLine(person);
                }
            }
        }

        public static void WhereOperator(IList<Person> persons)
        {
            var difference = DateTime.Now - new DateTime(1990, 1, 1, 0, 0, 0);
            var refferenceDate = DateTime.Now.AddDays(-(int)difference.TotalDays);

            var men = persons
                .Where(person => person.BirthDate > refferenceDate)
                .Where((p, index) => index % p.BirthDate.Day == 0)
                .ToList();

            DisplayPersons(men);
        }

        private static void ForEquivalent(IList<Person> persons, DateTime refferenceDate)
        {
            var result = new List<Person>();
            foreach (var person in persons)
            {
                if (person.BirthDate > refferenceDate && person.FirstName.Contains("X"))
                {
                    result.Add(person);
                }
            }

            for (int i = 0; i < persons.Count; i++)
            {
                if (persons[i].BirthDate > refferenceDate && persons[i].FirstName.Contains("X"))
                {
                    result.Add(persons[i]);
                }
            }
        }

        public static int Do(Person p)
        {
            var nameLength = p.FirstName.Length;
            return p.BirthDate.Day + nameLength;
        }

        public static void MinOperator(IList<Person> persons)
        {
            int olderPerson = persons.Min(Do);
            Console.WriteLine(olderPerson);
        }

        public static void MaxOperator(IList<Person> persons)
        {
            DateTime youngerPerson = persons.Max(p => p.BirthDate);
            Console.WriteLine(youngerPerson);
        }

        public static void OrderByOperator(IList<Person> persons)
        {
            var orderedPersons = persons
                .OrderBy(p => p.Gender)
                .ThenBy(p => p.FirstName)
                .Reverse()
                .ToList();

            DisplayPersons(orderedPersons);
        }

        public static void IntersectOperator(IList<Person> persons)
        {
            var from0To100 = persons.Take(100);
            var from90To200 = persons.Skip(90).Take(110);

            var common = from90To200.Intersect(from0To100)
                .ToList();
            DisplayPersons(common);
        }

        public static void ExceptOperator(IList<Person> persons)
        {
            var from0To99 = persons.Take(100);
            var from90To199 = persons.Skip(90).Take(100);

            var common = from90To199.Except(from0To99)
                .ToList();
            Console.WriteLine(common.Count);
        }

        public static void ToDictionaryOperator(IList<Person> persons)
        {
            Dictionary<long, Person> dic = persons.ToDictionary(p => p.Id, p => p);
            foreach (var person in dic)
            {
                Console.WriteLine($"{person.Key} {person.Value}");
            }
        }

        public static void ToLookupOperator(IList<Person> persons)
        {
            ILookup<Gender, Person> dic = persons.ToLookup(p => p.Gender, p => p);
            foreach (var personsByGender in dic)
            {
                Console.WriteLine($"Key :{personsByGender.Key}");
                foreach (var person in personsByGender)
                {
                    Console.WriteLine(person);
                }
            }
        }

        public static void RepeatOperator(IList<Person> persons)
        {
            var firstPerson = persons.First();
            var tenTimes = Enumerable.Repeat(firstPerson, 0).ToList();

            DisplayPersons(tenTimes);
        }

        private static void DisplayPersons(IList<Person> persons)
        {
            foreach (var person in persons)
            {
                Console.WriteLine(person);
            }
        }

        class A
        {
            public int Number { get; set; }

            public override string ToString()
            {
                return Number.ToString();
            }
        }

        class B : A
        {
            public string Text { get; set; }

            public override string ToString()
            {
                return base.ToString() + Text;
            }
        }

        class C : A
        {
            public bool Flag { get; set; }

            public override string ToString()
            {
                return base.ToString() + Flag;
            }
        }

        private static void OfTypeOperator()
        {
            List<A> a = new List<A>();
            a.Add(new B() { Number = 1, Text = "ABC" });
            a.Add(new C() { Number = 2, Flag = true });

            foreach (var a1 in a)
            {
                Console.WriteLine(a1.Number);
            }

            var texts = a.OfType<int>();
            foreach (var text in texts)
            {
                Console.WriteLine(text);
            }

            var flags = a.OfType<C>();
            foreach (var flag in flags)
            {
                Console.WriteLine(flag);
            }
        }

        private static void DeferredAndImmediate()
        {
            Console.WriteLine("Begin");

            YieldExample();
            Console.WriteLine("Without any extension method");

            YieldExample().Select(i => $"I:{i}");
            Console.WriteLine("Select done");

            YieldExample().Count();
            Console.WriteLine("Count done");

            YieldExample().Select(i => $"I:{i}").ToList();
            Console.WriteLine("ToList done");

            Console.WriteLine("End");
        }

        private static void ReuseQuery()
        {
            var list = new List<int>() { 2, 8, 7, 6, 9 };

            var nums = list
                .Where(n => n % 2 == 0)
                .ToList();
            // 2 8 6

            list.Remove(2);
            list.Remove(8);
            list.Add(4);
            var a = nums.ToList();
            foreach (var i in a)
            {
                Console.WriteLine(i);
            }
        }

        public static IEnumerable<int> YieldExample()
        {
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine($"YieldExample {i}");
                yield return i;
            }
        }
    }
}
;