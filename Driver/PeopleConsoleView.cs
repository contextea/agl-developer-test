using PeopleService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Driver
{
    public class PeopleConsoleView
    {
        public PeopleModel PeopleModel { get; set; }

        public PeopleConsoleView(PeopleModel model)
        {
            PeopleModel = model;
            if (PeopleModel == null) throw new ArgumentNullException("model");
        }

        public void Render()
        {
            Console.WriteLine("Male\n");

            var maleOwnerCats = PeopleModel.GetPetsByOwnerGenderAndPetType(Gender.Male, PetType.Cat);

            maleOwnerCats.ForEach(cat => Console.WriteLine($"* {cat.Name}"));

            Console.WriteLine("\nFemale\n");

            var femaleOwnerCats = PeopleModel.GetPetsByOwnerGenderAndPetType(Gender.Female, PetType.Cat);

            femaleOwnerCats.ForEach(cat => Console.WriteLine($"* {cat.Name}"));
        }
    }
}
