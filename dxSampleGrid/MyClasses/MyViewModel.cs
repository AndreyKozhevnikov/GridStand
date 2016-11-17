using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace dxSampleGrid {
    public partial class MyViewModel {
        public MyViewModel() {
            CreateList(10);
            CreateAdditionalResouces();
            GenerateColumns();
        }

        ObservableCollection<Person> _listPerson;

        public ObservableCollection<Person> ListPerson {
            get {
                return _listPerson;
            }

            set {
                _listPerson = value;
                RaisePropertyChanged("ListPerson");
            }
        }

        public      void CreateList(int k) {
            var lst = new ObservableCollection<Person>();

            for (int i = 0; i < k; i++) {
                Person p = new Person(i);
                lst.Add(p);
            }
            ListPerson=lst;
        }

        public ObservableCollection<MyColumn> MyColumns { get; set; }
        public void GenerateColumns() {
            MyColumns = new ObservableCollection<MyColumn>();
            MyColumns.Add(new MyColumn("FirstName"));
        }
    }


 
}
