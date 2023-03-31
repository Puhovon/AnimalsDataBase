using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using AnimalsData.Infrastructure.Command;
using AnimalsData.Model;
using AnimalsData.Model.AnimalModels;
using AnimalsData.ViewModel.Base;

namespace AnimalsData.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {

        #region Fields

        #region ComboBox

        private IEnumerable<TypeOfAnimal> _ComboboxItems;

        public IEnumerable<TypeOfAnimal> ComboboxItems
        {
            get => (TypeOfAnimal[])Enum.GetValues(typeof(TypeOfAnimal));
            set => Set(ref _ComboboxItems, value);
        }

        private TypeOfAnimal _selectedAnimalComboBox;

        public TypeOfAnimal SelectedAnimal
        {
            get => _selectedAnimalComboBox;
            set => Set(ref _selectedAnimalComboBox, value);
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

        private ObservableCollection<Amphibia> _animals;

        public ObservableCollection<Amphibia> Animals
        {
            get => _animals;
            set => Set(ref _animals, value);
        }

        #endregion

        #endregion

        #region Commands

        #region SelectOneOfTypeAnimal

        public ICommand SelectOneOfTypeAnimal { get; }

        private bool CanSelectOneOfTypeAnimal(object p) => true;

        private void OnSelectOneOfTypeAnimal(object p)
        {
            AnimalFactory.GetAnimal(SelectedAnimal.ToString());
        }

        #endregion

        #endregion

        public MainWindowViewModel()
        {
            #region Commands

            SelectOneOfTypeAnimal 
                = new LambdaCommand(OnSelectOneOfTypeAnimal, CanSelectOneOfTypeAnimal);

            #endregion
        }
    }
}
