using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Markup;

namespace dxSampleGrid {
      public class custConverter : MarkupExtension, IValueConverter,IMultiValueConverter {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            EditGridCellData cd = value as EditGridCellData;
            if (cd != null)
                Debug.Print(value.ToString());
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            return value;
        }

        public override object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            return values[0];
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
