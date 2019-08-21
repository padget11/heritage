namespace heritage.Commands
{
    using System;
    using System.Windows.Input;
    using heritage.ViewModels;

    internal class AddFamilyMemberCommand : ICommand
    {
        private FamilyMemberViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the AddFamilyMemberCommand class.
        /// </summary>
        public AddFamilyMemberCommand(FamilyMemberViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event System.EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.SaveChanges();
        }
    }
}