using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using UniversalDataGridTest.Models;

namespace UniversalDataGridTest;
public partial class UniversalDataGridAuto : UserControl //, INotifyPropertyChanged
{
    //private ObservableCollection<TableData> _GridData;
    //public List<TableData> GridData { get; set; }
    //{
    //    get => _GridData;
    //    set
    //    {
    //        _GridData = value;
    //        OnPropertyChanged("GridData");
    //    }
    //}

    private List<TStruct> tableStruct;
    public UniversalDataGridAuto(List<TableData> gridData, List<TStruct> tableStructure)
    {
        //GridData = gridData;
        //GridData = new ObservableCollection<TableData>(gridData);
        tableStruct = tableStructure;
        DataContext = this;
        InitializeComponent();
        myDataGrid.ItemsSource = gridData;
        myDataGrid.AutoGeneratingColumn += myDataGrid_AutoGeneratingColumn;
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

    //public event PropertyChangedEventHandler PropertyChanged;
    //public void OnPropertyChanged([CallerMemberName] string prop = "")
    //{
    //    if (PropertyChanged != null)
    //        PropertyChanged(this, new PropertyChangedEventArgs(prop));
    //}
}