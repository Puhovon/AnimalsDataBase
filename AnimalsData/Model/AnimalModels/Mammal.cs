using AnimalsData.Model.Base;

namespace AnimalsData.Model.AnimalModels
{
    class Mammal : IAnimal
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }

        public Mammal(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }
    }
}
