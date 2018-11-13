using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Repository
{
    [DataContract]
    public class Person
    {
        public Person()
        {
            
        }

        public Person(string firstName, string lastName, Gender gender, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            BirthDate = birthDate;
        }

        public override string ToString()
        {
            return $"{Id} {FirstName} {LastName} {Gender} {BirthDate}";
        }

        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public Gender Gender { get; set; }

        [DataMember]
        public DateTime BirthDate { get; set; }

        [DataMember]
        public IList<Post> Posts { get; set; }

        public string GenderAsString
        {
            get
            {
                return Gender == Gender.F ? "Female" : "Male";
            }
        }
    }
}