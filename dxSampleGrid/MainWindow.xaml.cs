﻿using DevExpress.Xpf.Grid;

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
using DevExpress.Mvvm.UI.Interactivity;
using System.IO;

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
            (rootGrid.Children[0] as MyGridControl).tableView1.SearchPanelAllowFilter = !(rootGrid.Children[0] as MyGridControl).tableView1.SearchPanelAllowFilter;

        }

        private void AllowPartialGrouping_Click(object sender, RoutedEventArgs e) {
            (rootGrid.Children[0] as MyGridControl).tableView1.AllowPartialGrouping = !(rootGrid.Children[0] as MyGridControl).tableView1.AllowPartialGrouping;
        }

        private void MasterDetail_Click(object sender, RoutedEventArgs e) {
            var gc = (rootGrid.Children[0] as MyGridControl).gridControl1;
            gc.ItemsSource = vm.ListPerson;
            if (gc.DetailDescriptor == null) {
                DataControlDetailDescriptor dgc = new DataControlDetailDescriptor();
                dgc.ItemsSourceBinding = new Binding("SomeClasses");
                GridControl gcchild = new GridControl();
                gcchild.Columns.Add(new GridColumn() { FieldName = "Name" });

                dgc.DataControl = gcchild;

                if (gc.SelectionMode == MultiSelectMode.Cell)
                    gc.SelectionMode = MultiSelectMode.None;

                gc.DetailDescriptor = dgc;
            }
            else {
                gc.DetailDescriptor = null;
            }
        }

        private void Recreate_Click(object sender, RoutedEventArgs e) {
            rootGrid.Children.Clear();
            rootGrid.Children.Add(new MyGridControl());
            GC.GetTotalMemory(true);
        }

        private void Bands_Click(object sender, RoutedEventArgs e) {
            var gc = (rootGrid.Children[0] as MyGridControl).gridControl1;
            gc.Columns.Clear();
            var b1 = new GridControlBand();
            b1.Header = "band1";
            b1.Columns.Add(new GridColumn() { FieldName = "FirstName" });
            b1.Columns.Add(new GridColumn() { FieldName = "LastName" });
            var b2 = new GridControlBand();
            b2.Header = "band2";
            b2.Columns.Add(new GridColumn() { FieldName = "Age" });
            b2.Columns.Add(new GridColumn() { FieldName = "Group" });
            gc.Bands.Add(b1);
            gc.Bands.Add(b2);
        }

        private void Export_Click(object sender, RoutedEventArgs e) {
            (rootGrid.Children[0] as MyGridControl).tableView1.ExportToXlsx("test.xlsx");
            Process.Start("test.xlsx");
        }

        private void ShowPreview_Click(object sender, RoutedEventArgs e) {
            (rootGrid.Children[0] as MyGridControl).tableView1.ShowPrintPreview(this);
        }

        private void Cell_Checked(object sender, RoutedEventArgs e) {
            var gc = (rootGrid.Children[0] as MyGridControl).gridControl1;
            gc.DetailDescriptor = null;
           gc.SelectionMode = MultiSelectMode.Cell;
        }

        private void Row_Checked(object sender, RoutedEventArgs e) {
            var gc = (rootGrid.Children[0] as MyGridControl).gridControl1;
         //   gc.DetailDescriptor = null;
            gc.SelectionMode = MultiSelectMode.Row;
        }

        private void MultipleRow_Checked(object sender, RoutedEventArgs e) {
            var gc = (rootGrid.Children[0] as MyGridControl).gridControl1;
        //    gc.DetailDescriptor = null;
            gc.SelectionMode = MultiSelectMode.MultipleRow;
        }

        private void None_Checked(object sender, RoutedEventArgs e) {
            (rootGrid.Children[0] as MyGridControl).gridControl1.SelectionMode = MultiSelectMode.None;
        }

        private void Top_Checked(object sender, RoutedEventArgs e) {
            var tv = (rootGrid.Children[0] as MyGridControl).tableView1;
            tv.NewItemRowPosition = NewItemRowPosition.Top;
        }

        private void Bottom_Checked(object sender, RoutedEventArgs e) {
            var tv = (rootGrid.Children[0] as MyGridControl).tableView1;
            tv.NewItemRowPosition = NewItemRowPosition.Bottom;
        }

        private void NoneNewItemRow_Checked(object sender, RoutedEventArgs e) {
            var tv = (rootGrid.Children[0] as MyGridControl).tableView1;
            tv.NewItemRowPosition = NewItemRowPosition.None;
        }

        private void server_Checked(object sender, RoutedEventArgs e) {
            var gc = (rootGrid.Children[0] as MyGridControl).gridControl1;
            removeDD(gc);
            gc.DetailDescriptor = null;
            vm.CreateList(100000);
            vm.CreateAdditionalResouces();
            gc.SetBinding(GridControl.ItemsSourceProperty, new Binding("Data") { ElementName = "dataSource" });
        }

        private void Plain_Checked(object sender, RoutedEventArgs e) {
            var gc = (rootGrid.Children[0] as MyGridControl).gridControl1;
            vm.CreateList(10);
            vm.CreateAdditionalResouces();
            gc.SetBinding(GridControl.ItemsSourceProperty, new Binding("ListPerson"));
        }

        private void save_Click(object sender, RoutedEventArgs e) {
            var gc = (rootGrid.Children[0] as MyGridControl).gridControl1;
            gc.SaveLayoutToXml("text.xml");
        }

        private void Restore_Click(object sender, RoutedEventArgs e) {
            var gc = (rootGrid.Children[0] as MyGridControl).gridControl1;
            if (File.Exists("test.xml"))
                gc.RestoreLayoutFromXml("text.xml");
        }

        private void ColumnsSource_Click(object sender, RoutedEventArgs e) {
            var gc = (rootGrid.Children[0] as MyGridControl).gridControl1;
            gc.Columns.Clear();
            gc.ColumnsSource = null;
            gc.Bands.Clear();
            gc.BandsSource = null;
            gc.SetBinding(GridControl.ColumnsSourceProperty, new Binding("MyColumns"));
            gc.ColumnGeneratorTemplate = this.Resources["DefaultColumnTemplate"] as DataTemplate;
        }

        private void BandsSource_Click(object sender, RoutedEventArgs e) {
            var gc = (rootGrid.Children[0] as MyGridControl).gridControl1;
            gc.Columns.Clear();
            gc.Bands.Clear();
            gc.ColumnsSource = null;
            gc.BandsSource = null;
            vm.GenerateBands();
            gc.SetBinding(GridControl.BandsSourceProperty, new Binding("MyBands"));
            gc.BandGeneratorTemplate = this.Resources["DefaultBandTemplate"] as DataTemplate;
            gc.ColumnGeneratorTemplate = this.Resources["DefaultColumnTemplate"] as DataTemplate;
        }

        private void Dialog_Click(object sender, RoutedEventArgs e) {
            var tv = (rootGrid.Children[0] as MyGridControl).tableView1;
            tv.EditFormShowMode = EditFormShowMode.Dialog;
        }

        private void Inline_Click(object sender, RoutedEventArgs e) {
            var tv = (rootGrid.Children[0] as MyGridControl).tableView1;
            tv.EditFormShowMode = EditFormShowMode.Inline;
        }

        private void InlineHideRow_Click(object sender, RoutedEventArgs e) {
            var tv = (rootGrid.Children[0] as MyGridControl).tableView1;
            tv.EditFormShowMode = EditFormShowMode.InlineHideRow;
        }

        private void NoneEditForm_Click(object sender, RoutedEventArgs e) {
            var tv = (rootGrid.Children[0] as MyGridControl).tableView1;
            tv.EditFormShowMode = EditFormShowMode.None;
        }

        private void AutoWidth_Click(object sender, RoutedEventArgs e) {
            var tv = (rootGrid.Children[0] as MyGridControl).tableView1;
            tv.AutoWidth = !tv.AutoWidth;
        }



        private void CardView_Checked(object sender, RoutedEventArgs e) {
            var gc = (rootGrid.Children[0] as MyGridControl).gridControl1;
            gc.View = new CardView();
            removeDD(gc);
        }

        private static void removeDD(GridControl gc) {
            var b = Interaction.GetBehaviors(gc);
            b.Clear();
        }

        private void TreeListView_Checked(object sender, RoutedEventArgs e) {
            var gc = (rootGrid.Children[0] as MyGridControl).gridControl1;
            gc.View = new TreeListView();
            var b = Interaction.GetBehaviors(gc);
            b.Clear();
            GC.GetTotalMemory(true);
        }

        private void TableView_Checked(object sender, RoutedEventArgs e) {
            Recreate_Click(null, null);
        }



        private void DragDrop_Click(object sender, RoutedEventArgs e) {
            var gc = (rootGrid.Children[0] as MyGridControl).gridControl1;
            gc.ItemsSource = vm.ListPerson;
            var b = Interaction.GetBehaviors(gc);
            if (b.Count > 0) {
                b.Clear();
            }
            else {
                if (gc.View is TableView)
                    b.Add(new GridDragDropManager());
                if (gc.View is TreeListView)
                    b.Add(new TreeListDragDropManager());
            }
        }

        private void CellMerging_Click(object sender, RoutedEventArgs e) {
            var tv = (rootGrid.Children[0] as MyGridControl).tableView1;
            tv.AllowCellMerge = !tv.AllowCellMerge;

        }
    }








}
