using AnimalsData.Model.AnimalModels;
using AnimalsData.Model.Base;

namespace AnimalsData.ViewModel
{
    static class AnimalFactory
    {
        public static IAnimal GetAnimal(string type)
        {
            switch (type)
            {
                case "Amphibia":
                    return new Amphibia();
                    break;
                case "Bird":
                    return new Bird();
                    break;
                case "Mammal":
                    return new Mammal();
                    break;
                    default: return new Undefined();
            }
        }
    }
}
