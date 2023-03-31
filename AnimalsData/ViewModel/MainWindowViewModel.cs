using AnimalsData.ViewModel.Base;

namespace AnimalsData.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        private string _title = "HomeWork18";
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
    }
}
