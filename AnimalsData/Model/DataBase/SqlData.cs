using AnimalsData.Model.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AnimalsData.Model.DataBase
{
    internal class SqlData
    {
        public Context context;

        public SqlData()
        {
            context = new Context();
        }

        public ObservableCollection<IAnimal> Animals { get; set; }

        public IEnumerable<IAnimal> GetAllAnimals()
        {
            using (var con = new Context())
            {
                var animals = con.Animals.ToList();
                return animals;
            }
            
        }

        public void Add(IAnimal animal)
        {
            int id = GetAllAnimals().Count() + 1;
            animal.Id = id;
            context.Animals.Add(animal);
            context.SaveChanges();
        }

        public void Delete(IAnimal animal)
        {
            context.Animals.Remove(animal);
            context.SaveChanges();
        }

        public void Update(IAnimal animal)
        {
            if (animal != null)
            {
                IAnimal an = context.Animals.First(e => e.Id == animal.Id);
                context.Entry(an).State = EntityState.Detached;
                context.Animals.Update(animal);
                context.SaveChanges();
            }
        }
    }
}
