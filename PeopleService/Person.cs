using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleService
{
    /// <summary>
    /// Person DTO
    /// </summary>
    public class Person
    {
        public string Name { get; set; }
        public string Gender { get; set; }

        public List<Pet> Pets { get; set; }

        public Person()
        {
            Pets = new List<Pet>();
        }
    }
}
