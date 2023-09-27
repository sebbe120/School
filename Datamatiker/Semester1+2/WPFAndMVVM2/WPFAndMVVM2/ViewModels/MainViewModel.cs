using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using WPFAndMVVM2.Models;

namespace WPFAndMVVM2.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private PersonRepository personRepo = new PersonRepository();
        private ObservableCollection<PersonViewModel> personsVM;
        private PersonViewModel selectedPerson;

        public event EventHandler PersonsVMChanged;        

        public ICommand NewCMD { get; set; } = new CommandNewPerson();
        public ICommand DeleteCMD { get; set; } = new CommandDeletePerson();

        public MainViewModel()
        {
            PersonsVM = new ObservableCollection<PersonViewModel>();
            foreach (Person person in personRepo.GetAll())
            {
                PersonsVM.Add(new PersonViewModel(person));
            }
        }

        public ObservableCollection<PersonViewModel> PersonsVM
        {
            get { return personsVM; }
            set { personsVM = value; }
        }

        public PersonViewModel SelectedPerson
        {
            get { return selectedPerson; }
            set
            {
                selectedPerson = value;
                OnPropertyChanged("SelectedPerson");
            }
        }

        public void AddDefaultPerson()
        {
            Person person = new Person
            {
                FirstName = "Specify FirstName",
                LastName = "Specify LastName",
                Age = 0,
                Phone = "Specify Phone"
            };

            personRepo.Add(person.FirstName, person.LastName, person.Age, person.Phone);
            PersonViewModel pvm = new PersonViewModel(person);
            PersonsVM.Add(pvm);
            SelectedPerson = pvm;
            OnPersonsVMChanged();
            OnPropertyChanged("SelectedPerson");
        }

        public void AddPerson()
        {
            PersonEventArgs person = OnNewPersonRequested();
            if (person.FirstName != null && person.LastName != null && person.Phone != null && person.Age >= 0)
            {
                var newPerson = personRepo.Add(person.FirstName, person.LastName, person.Age, person.Phone);
                SelectedPerson = new PersonViewModel(newPerson);

                PersonsVM.Add(SelectedPerson);

                OnPersonsVMChanged();
                OnPropertyChanged("SelectedPerson");
            }
        }


        public void DeleteSelectedPerson()
        {
            if (SelectedPerson is null)
                return;

            foreach (Person person in personRepo.GetAll())
            {
                if (person.FirstName == selectedPerson.FirstName && person.LastName == selectedPerson.LastName && person.Age == selectedPerson.Age && person.Phone == selectedPerson.Phone)
                {
                    personRepo.Remove(person.Id);
                    break;
                }
            }

            PersonsVM.Remove(SelectedPerson);
        }

        protected void OnPersonsVMChanged()
        {
            EventHandler personsVMChanged = PersonsVMChanged;

            if (personsVMChanged != null)
            {
                personsVMChanged(this, null);
            }
        }

        public delegate PersonEventArgs PersonEventHandler(object sender, PersonEventArgs args);
        public event PersonEventHandler NewPersonRequested;
        protected PersonEventArgs OnNewPersonRequested()
        {
            PersonEventArgs result = null;

            PersonEventHandler newPersonRequested = NewPersonRequested;

            if (newPersonRequested != null)
            {
                PersonEventArgs args = null;

                result = newPersonRequested(this, args);
            }
            return result;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {

            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;

            if (propertyChanged != null)

            {

                propertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }

        }
    }
}
