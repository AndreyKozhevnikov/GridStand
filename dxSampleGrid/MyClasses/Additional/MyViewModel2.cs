using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace dxSampleGrid {
    public partial class MyViewModel : INotifyPropertyChanged {
        string _viewModelName;
        Person _selectedPerson;
        ICommand _myVoidCommand;

        public ObservableCollection<SomeClass> MainSomeClasses { get; set; }
        public int k { get; set; }
        public string ViewModelName {
            get { return _viewModelName; }
            set {
                _viewModelName = value;
                RaisePropertyChanged("ViewModelName");
            }
        }
        public int SomeValue { get; set; }
        public Person SelectedPerson {
            get { return _selectedPerson; }
            set {
                _selectedPerson = value;
                RaisePropertyChanged("SelectedPerson");
            }
        }

        public ICommand MyVoidCommand {
            get {
                if (_myVoidCommand == null)
                    _myVoidCommand = new DelegateCommand(SomeMethod);
                return _myVoidCommand;
            }
        }

        public void CreateAdditionalResouces() {
            foreach (Person p in ListPerson) {
                p.CreateAdditionalResources(p.Age==0?0: p.Age/ 10);
            }
            ViewModelName = "MyViewModel1";
            SomeValue = 5;
            SelectedPerson = ListPerson[0];
            MainSomeClasses = new ObservableCollection<SomeClass>();
            for (int i = 0; i < 20; i++)
                MainSomeClasses.Add(new SomeClass(i));
        }

        void SomeMethod() {
            Debug.Print("Some action");

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(String propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
