using AnimalsData.Model.Base;

namespace AnimalsData.Model.AnimalModels
{
    class Amphibia : IAnimal
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public Amphibia(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }
        public Amphibia(string name)
        {
            this.Name = name;
        }
    }
}
