using DevExpress.Xpf.Grid;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;
using DevExpress.Xpf.Core.ServerMode;
using System.Data;

namespace dxSampleGrid {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            vm = new MyViewModel();
            DataContext = vm;
        }
        MyViewModel vm;

        private void Button_Click(object sender, RoutedEventArgs e) {
         
        }

        private void SearchPanelAllowFilter_Click(object sender, RoutedEventArgs e) {
           MyGridControl1.tableView1.SearchPanelAllowFilter = !MyGridControl1.tableView1.SearchPanelAllowFilter;
        }

        private void AllowPartialGrouping_Click(object sender, RoutedEventArgs e) {
            MyGridControl1.tableView1.AllowPartialGrouping = !MyGridControl1.tableView1.AllowPartialGrouping;
        }

        private void MasterDetail_Click(object sender, RoutedEventArgs e) {
            var gc = MyGridControl1.gridControl1;
            if (gc.DetailDescriptor == null) {
                DataControlDetailDescriptor dgc = new DataControlDetailDescriptor();
                dgc.ItemsSourceBinding = new Binding("SomeClasses");
                GridControl gcchild = new GridControl();
                gcchild.Columns.Add(new GridColumn() { FieldName = "Name" });

                dgc.DataControl = gcchild;
                gc.DetailDescriptor = dgc;
            }
            else {
                gc.DetailDescriptor = null;
            }
        }
    }








}
