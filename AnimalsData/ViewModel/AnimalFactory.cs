using AnimalsData.Model.AnimalModels;
using AnimalsData.Model.Base;
using AnimalsData.Model.DataBase;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace AnimalsData.ViewModel
{ 
    static class AnimalFactory
    {
        static ObservableCollection<IAnimal> animals;

        public static ObservableCollection<IAnimal> GetAnimal(string type)
        {
            animals = new ObservableCollection<IAnimal>();
            switch (type)
            {   
                case "Amphibias":
                    Debug.Write(type.ToString());
                    for (var i = 0; i < 10; i++)
                    {
                        var a = new Amphibia($"{type}{i}", $"asd{i}");
                        animals.Add(a);
                    }

                    return animals;
                case "Birds":
                    animals = SqlData.GetAnimals(type);
                    return animals;
                case "Mammals":
                    animals = SqlData.GetAnimals(type);
                    return animals;
                case "Undefined":
                    animals = SqlData.GetAnimals(type);
                    return animals;
                default: 
                        animals = SqlData.GetAnimals(type);
                    return animals;
            }
        }

       
    }
}
