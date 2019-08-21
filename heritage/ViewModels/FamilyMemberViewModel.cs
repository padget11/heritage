namespace heritage.ViewModels
{
    using System;
    using System.Diagnostics;
    using System.Windows.Input;
    using heritage.Commands;
    using heritage.Models;
    using heritage.Views;

    internal class FamilyMemberViewModel
    {
        private FamilyMember familyMember;
        private FamilyMemberInfoViewModel childViewModel;

        /// <summary>
        /// Initializes a new instance of the FamilyMemberViewModel class.
        /// </summary>
        public FamilyMemberViewModel()
        {
            familyMember = new FamilyMember("Padget");
            childViewModel = new FamilyMemberInfoViewModel();
            StartCommand = new AddFamilyMemberCommand(this);
        }

        /// <summary>
        /// Gets the familyMember instance
        /// </summary>
        public FamilyMember Member
        {
            get
            {
                return familyMember;
            }
        }

        /// <summary>
        /// Gets the StartCommand for the ViewModel
        /// </summary>
        public ICommand StartCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Saves changes made to the Member instance
        /// </summary>
        public void SaveChanges()
        {
            FamilyMemberInfoView view = new FamilyMemberInfoView()
            {
                DataContext = childViewModel
            };

            childViewModel.Info = Member.Name + " was updated in the database.";

            view.ShowDialog();
        }
    }
}
