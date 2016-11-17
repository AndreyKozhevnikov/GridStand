using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace dxSampleGrid {
     [DebuggerDisplay("Id = {Id}, Name = {FirstName}, Value = {Age}")]
    public partial class Person : INotifyPropertyChanged {
        public void CreateAdditionalResources(int i) {
          
            Group = i % 2 == 0;
            Id = i;
            SomeClasses = new ObservableCollection<SomeClass>();

            for (int j = 0; j < 5; j++) {
                SomeClasses.Add(new SomeClass(j));
            }
            SelectedSomeClass = SomeClasses[2].Id;

            BirthDate = new DateTime(2010, 1, 1).AddDays(i);
        }
        public bool Group { get; set; }
        public int Id { get; set; }
        public int ParentId { get; set; }
        public DateTime BirthDate { get; set; }
        public ObservableCollection<SomeClass> SomeClasses { get; set; }
        public int SelectedSomeClass { get; set; }
     //   public override string ToString() {
     //       return FirstName;
      //  }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(String propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
