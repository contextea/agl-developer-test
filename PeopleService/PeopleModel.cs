using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeopleService
{
    /// <summary>
    /// Encapsulates operations on a PeopleList
    /// </summary>
    public class PeopleModel
    {
        internal List<Person> PeopleList { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="peopleList">Data for this model</param>
        public PeopleModel(List<Person> peopleList)
        {
            PeopleList = peopleList;
            if (PeopleList == null) throw new ArgumentNullException("peopleList");
        }

        /// <summary>
        /// Get pets for owners of a particular gender
        /// </summary>
        /// <param name="gender">Pet Owner gender</param>
        /// <param name="petType">Type of Owner pet</param>
        /// <returns></returns>
        public List<Pet> GetPetsByOwnerGenderAndPetType(Gender gender, PetType petType)
        {
            var genderStr = gender.ToString();
            var petTypeStr = petType.ToString();

            return PeopleList
                .Where(person => person.Gender.ToString() == genderStr && person.Pets?.Count > 0)
                .SelectMany(person => person.Pets)
                .Where(pet => pet.Type.ToString() == petTypeStr)
                .OrderBy(pet => pet.Name)
                .ToList();
        }
    }
}
