using AnimalsData.Model.Base;
using AnimalsData.ViewModel.Base;
using System.Collections.Generic;
using System.Windows.Input;

namespace AnimalsData.ViewModel
{
    internal class AddNewAnimalViewModel : ViewModelBase
    {

        #region Fields

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

        }

    }
}
