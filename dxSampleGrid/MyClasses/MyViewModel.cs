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
            CreateList();
            CreateAdditionalResouces();
        }

        public ObservableCollection<Person> ListPerson { get; set; }

        void CreateList() {
            ListPerson = new ObservableCollection<Person>();

            for (int i = 0; i < 10; i++) {
                Person p = new Person(i);
                ListPerson.Add(p);
            }
        }
    }


 
}
