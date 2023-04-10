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

        static public ObservableCollection<IAnimal> GetAnimals(string type)
        {
            using (var con = new Context())
            {
                switch (type)
                {
                    case "Amphibias":
                        var Amphibias = con.Amphibias.ToList();
                        ObservableCollection<IAnimal> amphibias = new ObservableCollection<IAnimal>(Amphibias);
                        return amphibias;
                    case "Mammals":
                        var mammals = con.Mammals.ToList();
                        ObservableCollection<IAnimal> mammal= new ObservableCollection<IAnimal>(mammals);
                        return mammal;
                    case "Birds":
                        var birds = con.Birds.ToList();
                        ObservableCollection<IAnimal> bird = new ObservableCollection<IAnimal>(birds);
                        return bird;
                    case "Undefineds":
                        var undefineds = con.Undefindes.ToList();
                        ObservableCollection<IAnimal> undefined = new ObservableCollection<IAnimal>(undefineds);
                        return undefined;
                    default: return null;
                }
            }
        }

        public void Add(IAnimal animal)
        {
            switch (animal.Type)
            {
                case "Amphibias":
                    context.Amphibias.Add((Amphibia)animal);
                    context.SaveChanges();
                    break;

                case "Mammals":
                    context.Mammals.Add((Mammal)animal);
                    context.SaveChanges();
                    break;

                case "Birds":
                    context.Birds.Add((Bird)animal);
                    context.SaveChanges();

                    break;

                case "Undefineds":
                    context.Undefindes.Add((Undefined)animal);
                    context.SaveChanges();
                    break;
            }
        }

        public void Delete(IAnimal animal)
        {
            switch (animal.Type)
            {
                case "Amphibias":
                    Amphibia am = context.Amphibias.First(e => e.Id == animal.Id);
                    context.Amphibias.Remove(am);
                    break;

                case "Mammals":
                    Mammal mam = context.Mammals.First(e => e.Id == animal.Id);
                    context.Mammals.Remove(mam);
                    break;

                case "Birds":
                    Bird bird = context.Birds.First(e => e.Id == animal.Id);
                    context.Birds.Remove(bird);
                    break;

                case "Undefineds":
                    Undefined undef = context.Undefindes.First(e => e.Id == animal.Id);
                    context.Undefindes.Remove(undef);
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
