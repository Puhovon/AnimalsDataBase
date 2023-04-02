using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using AnimalsData.Model.AnimalModels;
using AnimalsData.Model.Base;

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
                    break;
                case "Birds":
                    Debug.Write(type.ToString());
                    return animals;
                    break;
                case "Mammals":
                    Debug.Write(type.ToString());
                    return animals;
                    break;
                    default:
                    Debug.Write(type.ToString());
                    return animals;
            }
        }
    }
}
