using AnimalsData.Model.Base;
using AnimalsData.ViewModel.Base;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using AnimalsData.Infrastructure.Command;
using AnimalsData.Model.AnimalModels;
using AnimalsData.Model.DataBase;
using System;
using AnimalsData.View;

namespace AnimalsData.ViewModel
{
    internal class AddNewAnimalViewModel : ViewModelBase
    {

        #region Fields

        private SqlData context;

        #region Name 

        private string _name;

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        #endregion
        
        #region Type of animal

        private IEnumerable<TypeOfAnimal> _typeOfAnimalsTypeOfAnimalsItems;

        public IEnumerable<TypeOfAnimal> TypeOfAnimalsItems
        {
            get => _typeOfAnimalsTypeOfAnimalsItems;
            set => Set(ref _typeOfAnimalsTypeOfAnimalsItems, value);
        }

        private TypeOfAnimal _selectedTypeOfAnimal;

        public TypeOfAnimal SelectedTypeAnimal
        {
            get => _selectedTypeOfAnimal;
            set => Set(ref _selectedTypeOfAnimal, value);
        }

        #endregion

        #endregion

        #region Commands

        public ICommand ApplyCreationNewAnimalCommand { get; }

        private void onApplyCreationNewAnimalCommand(object p)
        {
            switch (SelectedTypeAnimal.ToString())
            {
                case "Amphibias":
                    var amphibia = new Amphibia(Name, SelectedTypeAnimal.ToString());
                    context.Add(amphibia);
                    Debug.WriteLine($"Creation Completed: {SelectedTypeAnimal.ToString()}");
                    break;
                
                case "Mammals":
                    var mammal= new Mammal(Name, SelectedTypeAnimal.ToString());
                    context.Add(mammal);
                    Debug.WriteLine($"Creation Completed: {SelectedTypeAnimal.ToString()}");
                    break;
                
                case "Birds":
                    var bird = new Bird(Name, SelectedTypeAnimal.ToString());
                    context.Add(bird);
                    Debug.WriteLine($"Creation Completed: {SelectedTypeAnimal.ToString()}");
                    break;

                case "Undefineds":
                    var undefiend = new Undefined(Name, SelectedTypeAnimal.ToString());
                    context.Add(undefiend);
                    Debug.WriteLine($"Creation Completed: {SelectedTypeAnimal.ToString()}");
                    break;

            }
        }

        private bool CanApplyCreationNewAnimalCommand(object p)
        {
            if (Name != null && SelectedTypeAnimal != null)
                return true;

            return false;
        }

        #endregion

        public AddNewAnimalViewModel()
        {
            context = new SqlData();

            #region Commands

                ApplyCreationNewAnimalCommand 
                    = new LambdaCommand(onApplyCreationNewAnimalCommand,CanApplyCreationNewAnimalCommand);

            #endregion

            _typeOfAnimalsTypeOfAnimalsItems = (TypeOfAnimal[])Enum.GetValues(typeof(TypeOfAnimal));

        }

    }
}
