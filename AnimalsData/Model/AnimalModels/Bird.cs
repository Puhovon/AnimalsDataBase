using AnimalsData.Model.Base;

namespace AnimalsData.Model.AnimalModels
{
    class Bird : IAnimal
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }

        public Bird(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }
    }
}
