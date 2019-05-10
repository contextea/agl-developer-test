using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PeopleService.Tests
{
    [TestClass]
    public class PeopleModelTests
    {
        private static readonly List<Person> _peopleList = new List<Person>
        {
            new Person
            {
                Name = "P1", Gender = Gender.Male.ToString(),
                Pets = new List<Pet>
                {
                    new Pet {Name = "Cat1", Type = PetType.Cat.ToString()},
                    new Pet {Name = "Dog1", Type = PetType.Dog.ToString()},
                }
            },
            new Person
            {
                Name = "P2", Gender = Gender.Male.ToString(),
                Pets = null
            },
            new Person
            {
                Name = "P3", Gender = Gender.Male.ToString(),
                Pets = new List<Pet>
                {
                    new Pet {Name = "Fish1", Type = PetType.Fish.ToString()},
                }
            },
            new Person
            {
                Name = "P4", Gender = Gender.Female.ToString(),
                Pets = new List<Pet>
                {
                    new Pet {Name = "Cat2", Type = PetType.Cat.ToString()},
                    new Pet {Name = "Cat3", Type = PetType.Cat.ToString()},
                }
            }

        };

        [TestMethod]
        public void GetsCorrectFemaleOwnedCats()
        {
            //Arrange
            var classUnderTest = new PeopleModel(_peopleList);

            //Act
            var femaleOwnedCats = classUnderTest.GetPetsByOwnerGenderAndPetType(Gender.Female, PetType.Cat);

            //Assert
            Assert.AreEqual(2, femaleOwnedCats.Count);
        }

        [TestMethod]
        public void GetsCorrectMaleOwnedCats()
        {
            //Arrange
            var classUnderTest = new PeopleModel(_peopleList);

            //Act
            var maleOwnedCats = classUnderTest.GetPetsByOwnerGenderAndPetType(Gender.Male, PetType.Cat);

            //Assert
            Assert.AreEqual(1, maleOwnedCats.Count);
        }
    }
}
