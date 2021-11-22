using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using UniversalDataGridTest.Models;

namespace UniversalDataGridTest;
public partial class UniversalDataGridAuto : UserControl
{
    private List<TStruct> tableStruct;
    public UniversalDataGridAuto(List<TStruct> tableStructure)
    {
        tableStruct = tableStructure;
        InitializeComponent();
        myDataGrid.AutoGeneratingColumn += myDataGrid_AutoGeneratingColumn;
    }
    public void Show<T>(List<T> tableData)
    {
        myDataGrid.ItemsSource = tableData;
    }
    void myDataGrid_AutoGeneratingColumn(object sender, System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
    {
        TStruct rec = tableStruct.Find(m => m.Binding == e.PropertyName);
        if (rec == null)
            e.Cancel = true;
        else
        {
            e.Column.Header = rec.Headers;
            e.Column.Width = new DataGridLength(rec.ColWidth, DataGridLengthUnitType.Star);
            if (e.PropertyType != typeof(double))
            {
                (e.Column).HeaderStyle = this.Resources["mdDataGridTextColumnHeaderStyleLeft"] as Style;
            }
            if (e.PropertyType == typeof(double))
            {
                (e.Column as DataGridTextColumn).Binding.StringFormat = rec.NumericFormat;
                (e.Column as DataGridTextColumn).ElementStyle = this.Resources["mdDataGridTextColumnStyle"] as Style;
                (e.Column).HeaderStyle = this.Resources["mdDataGridTextColumnHeaderStyleRight"] as Style;
            }

        }
    }
}