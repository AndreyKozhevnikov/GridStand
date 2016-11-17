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
            GenerateBands();
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
        public ObservableCollection<MyBand> MyBands { get; set; }
        public void GenerateBands() {
            MyBands = new ObservableCollection<MyBand>();
            MyBand b1 = new MyBand() { BandName = "band1" };
            b1.BandColumns = new List<MyColumn>();
            b1.BandColumns.Add(new MyColumn("FirstName"));
            b1.BandColumns.Add(new MyColumn("LastName"));

            MyBand b2 = new MyBand() { BandName = "band2" };
            b2.BandColumns = new List<MyColumn>();
            b2.BandColumns.Add(new MyColumn("Age"));
            b2.BandColumns.Add(new MyColumn("Group"));

            MyBands.Add(b1);
            MyBands.Add(b2);
        }

        public ObservableCollection<MyColumn> MyColumns { get; set; }
        public void GenerateColumns() {
            MyColumns = new ObservableCollection<MyColumn>();
            MyColumns.Add(new MyColumn("Age"));
            MyColumns.Add(new MyColumn("LastName"));
            MyColumns.Add(new MyColumn("FirstName"));
            
         
        }
    }


 
}
