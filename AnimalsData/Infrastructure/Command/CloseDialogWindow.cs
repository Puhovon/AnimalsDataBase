using System.Windows;
using AnimalsData.Infrastructure.Command.Base;

namespace AnimalsData.Infrastructure.Command
{
    internal class CloseDialogWindow : BaseCommand
    {
        public override bool CanExecute(object? parameter) => parameter is Window;
        public override void Execute(object? parameter)
        {
            if(!CanExecute(parameter)) return;

            var w = (Window) parameter;
            w?.Close();
        }
    }
}
