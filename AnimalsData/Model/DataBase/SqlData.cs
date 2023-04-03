using AnimalsData.Model.AnimalModels;
using AnimalsData.Model.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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

        public IEnumerable<IAnimal> GetAnimals(string type)
        {
            using (var con = new Context())
            {
                switch (type)
                {
                    case "Amphibias":
                        var Amphibias = con.Amphibias.ToList();
                        return Amphibias;

                    case "Mammals":
                        var mammals = con.Mammals.ToList();
                        return mammals;

                    case "Birds":
                        var birds = con.Birds.ToList();
                        return birds;

                    case "Undefineds":
                        var undefineds = con.Undefindes.ToList();
                        return undefineds;
         
                    default: return null;
                }
            }
        }

        public void Add(IAnimal animal)
        {
            int id = GetAnimals(animal.Type).Count() + 1;
            animal.Id = id;
            switch (animal.Type)
            {
                case "Amphibias":
                    context.Amphibias.Add((Amphibia)animal);
                    break;

                case "Mammals":
                    context.Mammals.Add((Mammal)animal);
                    break;

                case "Birds":
                    context.Birds.Add((Bird)animal);
                    break;

                case "Undefineds":
                    context.Undefindes.Add((Undefined)animal);
                    break;
            }
            context.SaveChanges();
        }

        public void Delete(IAnimal animal)
        {
            switch (animal.Type)
            {
                case "Amphibias":
                    context.Amphibias.Remove((Amphibia)animal);
                    break;

                case "Mammals":
                    context.Mammals.Remove((Mammal)animal);
                    break;

                case "Birds":
                    context.Birds.Remove((Bird)animal);
                    break;

                case "Undefineds":
                    context.Undefindes.Remove((Undefined)animal);
                    break;
            }
            context.SaveChanges();
        }

        public void Update(IAnimal animal)
        {
            if (animal != null)
            {
                switch (animal.Type)
                {
                    case "Amphibias":
                        IAnimal a = context.Amphibias.First(e => e.Id == animal.Id);
                        context.Entry(a).State = EntityState.Detached;
                        context.Amphibias.Update((Amphibia)animal);
                        break;

                    case "Mammals":
                        IAnimal m = context.Mammals.First(e => e.Id == animal.Id);
                        context.Entry(m).State = EntityState.Detached;
                        context.Mammals.Update((Mammal)animal);
                        break;

                    case "Birds":
                        IAnimal b = context.Birds.First(e => e.Id == animal.Id);
                        context.Entry(b).State = EntityState.Detached;
                        context.Birds.Update((Bird)animal);
                        break;

                    case "Undefineds":
                        IAnimal u = context.Undefindes.First(e => e.Id == animal.Id);
                        context.Entry(u).State = EntityState.Detached;
                        context.Undefindes.Update((Undefined)animal);
                        break;
                }
                context.SaveChanges();
            }
        }
    }
}
