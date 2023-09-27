using System;
using System.Windows;
using WPFAndMVVM2.ViewModels;
using WPFAndMVVM2.Views;

namespace WPFAndMVVM2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel mvm = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();

            DataContext = mvm;

            mvm.PersonsVMChanged += PersonsVMChangedHandler;
            mvm.NewPersonRequested += NewPersonRequestedHandler;
        }

        private void PersonsVMChangedHandler(object sender, object e)
        {
            lbPersonsVM.ScrollIntoView(mvm.SelectedPerson);
        }

        private PersonEventArgs NewPersonRequestedHandler(object sender, PersonEventArgs args)
        {
            PersonDialog personDialog = new PersonDialog();
            personDialog.ShowDialog();

            PersonEventArgs person = new PersonEventArgs();

            if ((bool)personDialog.DialogResult)
            {
                person.FirstName = personDialog.FirstName;
                person.LastName = personDialog.LastName;
                person.Age = personDialog.Age;
                person.Phone = personDialog.Phone;
            }

            return person;
        }

    }
}
