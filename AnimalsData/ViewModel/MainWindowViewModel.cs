using AnimalsData.Infrastructure.Command;
using AnimalsData.Model;
using AnimalsData.Model.Base;
using AnimalsData.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AnimalsData.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {

        #region Fields


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
            set=> Set(ref _selectedTypeOfAnimal, value);
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

        #region Selected animal

        private IAnimal _selectedAnimal;

        public IAnimal SelectedAnimal
        {
            get => _selectedAnimal;
            set => Set(ref _selectedAnimal, value);
        }
        
        #endregion

        
        
        #endregion

        #region Commands

        #region SelectTypeOfAnimalCommand

        public ICommand SelectTypeOfAnimalCommand { get; }

        private void OnSelectTypeOfAnimal(object p)
        {
            _animals.Clear();
            var animals = AnimalFactory.GetAnimal(SelectedTypeAnimal.ToString());
            foreach (var animal in animals)
            {
                _animals.Add(animal);
            }
        }

        private bool CanSelectTypeOfAnimal(object p) => true;

        #endregion
       
        #region OpenAddNewAnimalCommand

        public ICommand OpenAddNewAnimalCommand { get; }

        private void OnOpenAddNewAnimal(object p)
        {

        }

        private bool CanOpenAddNewAnimal(object p) => true;


        #endregion

        #region DeleteSelectedAnimalCommand

        public ICommand DeleteSelectedAnimalCommand { get; }

        private void OnDeleteSelectedAnimal(object p)
        {
            _animals.Remove(SelectedAnimal);
        }

        private bool CanDeleteSelectedAnimal(object p)
        {
            if (SelectedAnimal != null)
                return true;
            else
                return false;
        }

        #endregion

        #region OpenEditAnimalWindow

        public ICommand OpenEditAnimalWindowCommand { get; }

        private void OnOpenEditAnimalWindow(object p)
        {

        }

        private bool CanOpenEditAnimalWindow(Object p)
        {
            if (SelectedAnimal != null)
                return true;
            else
                return false;
        }

        #endregion

        #endregion

        public MainWindowViewModel()
        {


            #region Commands

            OpenAddNewAnimalCommand
                = new LambdaCommand(OnOpenAddNewAnimal, CanOpenAddNewAnimal);
            OpenEditAnimalWindowCommand
                = new LambdaCommand(OnOpenEditAnimalWindow, CanOpenEditAnimalWindow);
            DeleteSelectedAnimalCommand
                = new LambdaCommand(OnDeleteSelectedAnimal, CanDeleteSelectedAnimal);
            SelectTypeOfAnimalCommand 
                = new LambdaCommand(OnSelectTypeOfAnimal, CanSelectTypeOfAnimal);

            #endregion

            _typeOfAnimalsTypeOfAnimalsItems = (TypeOfAnimal[])Enum.GetValues(typeof(TypeOfAnimal));
        }
    }
}
