using AnimalsData.Model.Base;
using System;

namespace AnimalsData.Model.AnimalModels
{
    class Mammal : IAnimal
    {
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Type { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
