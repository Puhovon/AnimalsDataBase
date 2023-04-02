using AnimalsData.Model.Base;
using System;

namespace AnimalsData.Model.AnimalModels
{
    class Bird : IAnimal
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public Bird(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }
    }
}
