using AnimalsData.Infrastructure.Command;
using AnimalsData.Model;
using AnimalsData.Model.Base;
using AnimalsData.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace AnimalsData.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {

        #region Fields


        #region ComboBox

        private IEnumerable<TypeOfAnimal> _typeOfAnimalsTypeOfAnimalsItems;

        public IEnumerable<TypeOfAnimal> TypeOfAnimalsItems
        {
            get => _typeOfAnimalsTypeOfAnimalsItems;
            set => Set(ref _typeOfAnimalsTypeOfAnimalsItems, value);
        }

        private TypeOfAnimal _selectedAnimal;

        public TypeOfAnimal SelectedAnimal
        {
            get => _selectedAnimal;
            set=> Set(ref _selectedAnimal, value);
        }

        #endregion

        #region Title

        private string _title = "HomeWork18";
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        #endregion

        #region AnimalsList

        private ObservableCollection<IAnimal> _animals = new ObservableCollection<IAnimal>();

        public ObservableCollection<IAnimal> Animals
        {
            get => _animals;
            set => Set(ref _animals, value);
        }

        #endregion

        #endregion

        #region Commands

        #region SelectTypeOfAnimalCommand

        public ICommand SelectTypeOfAnimalCommand { get; }

        private void OnSelectTypeOfAnimal(object p)
        {
            _animals.Clear();
            var animals = AnimalFactory.GetAnimal(SelectedAnimal.ToString());
            foreach (var animal in animals)
            {
                _animals.Add(animal);
                Debug.Write(animal);
            }

            Debug.Write($"--------------------{SelectedAnimal}--------------------\n");
        }

        private bool CanSelectTypeOfAnimal(object p) => true;

        #endregion
        
        #endregion

        public MainWindowViewModel()
        {
            

            #region Commands

            SelectTypeOfAnimalCommand 
                = new LambdaCommand(OnSelectTypeOfAnimal, CanSelectTypeOfAnimal);

            #endregion

            _typeOfAnimalsTypeOfAnimalsItems = (TypeOfAnimal[])Enum.GetValues(typeof(TypeOfAnimal));
        }
    }
}
