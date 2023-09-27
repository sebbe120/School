using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WPFAndMVVM2.Models;
using WPFAndMVVM2.ViewModels;

namespace WPFAndMVVM2
{
    public class CommandDeletePerson : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            bool valid = true;

            if (parameter is MainViewModel mvm)
            {
                if (mvm.SelectedPerson == null)
                    valid = false;
            }

            return valid;
        }

        public void Execute(object parameter)
        {
            if (parameter is MainViewModel mvm)
            {
                mvm.DeleteSelectedPerson();
            }
        }
    }
}
