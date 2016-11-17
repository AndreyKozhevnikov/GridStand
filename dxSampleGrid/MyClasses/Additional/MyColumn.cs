using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxSampleGrid {
      public class MyColumn {
        public MyColumn(String _fieldName) {
            FieldName = _fieldName;
        }
        public string FieldName { get; set; }
        public ObservableCollection<MyColumn> MyColumns { get; set; }
        public void GenerateColumns() {
            MyColumns = new ObservableCollection<MyColumn>();
            MyColumns.Add(new MyColumn( "FirstName" ));
        }
    }
}
