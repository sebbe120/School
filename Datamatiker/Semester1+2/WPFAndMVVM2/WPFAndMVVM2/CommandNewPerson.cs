using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WPFAndMVVM2.Models;
using WPFAndMVVM2.ViewModels;

namespace WPFAndMVVM2
{
    public class CommandNewPerson : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is MainViewModel mvm)
            {
                mvm.AddPerson();
            }
        }
    }
}
