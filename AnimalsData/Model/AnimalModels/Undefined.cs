using AnimalsData.Model.Base;

namespace AnimalsData.Model.AnimalModels
{
    class Undefined : IAnimal
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Undefined";
        public string Type { get; set; } = "Undefined";

        public Undefined(string name,string type)
        {
            this.Name = name;
            this.Type = type;
        }
    }
}
