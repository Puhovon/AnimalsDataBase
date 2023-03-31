using AnimalsData.Model.Base;

namespace AnimalsData.Model.AnimalModels
{
    class Undefined : IAnimal
    {
        public string Name { get; set; } = "Undefined";
        public string Type { get; set; } = "Undefined";
    }
}
