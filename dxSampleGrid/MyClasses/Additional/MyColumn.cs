﻿using System;
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
   
    }

    public class MyBand {
        public string BandName { get; set; }
        public List<MyColumn> BandColumns { get; set; }
    }
}
