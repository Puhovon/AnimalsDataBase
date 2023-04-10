using AnimalsData.Model.Base;
using Microsoft.EntityFrameworkCore;

namespace AnimalsData.Model.AnimalModels
{
    class Amphibia : IAnimal
    {
        
        public int Id { get; set; }
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
