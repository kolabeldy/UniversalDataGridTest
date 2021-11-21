using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UniversalDataGridTest.Models;

namespace UniversalDataGridTest;
public partial class UniversalDataGridAuto : UserControl, INotifyPropertyChanged
{
    public ObservableCollection<TableDataRu> GridData { get; set; } = new();
    public ObservableCollection<TableData> TotalData { get; set; } = new();


    public List<TStruct> TableStructure { get; set; } = new();
    public SolidColorBrush TotalRowBrush { get; set; }
    public bool IsHighlight { get; set; }
    private string EmptyStr { get; set; }



    private SolidColorBrush hightLightBrushPink = new SolidColorBrush(Color.FromRgb(255, 235, 235));
    private SolidColorBrush hightLightBrushGreen = new SolidColorBrush(Color.FromRgb(235, 255, 235));
    private SolidColorBrush normalBrush = new SolidColorBrush(Colors.White);


    public UniversalDataGridAuto(List<TStruct> tableStructure, bool isHighlight = false)
    {
        TableStructure = tableStructure;
        IsHighlight = isHighlight;
        EmptyStr = "";
        GridData = Get();
        DataContext = this;
        InitializeComponent();
    }

    private ObservableCollection<TableDataRu> Get()
    {
        ObservableCollection<TableDataRu> result = new();

        result.Add(new TableDataRu { КодРесурса = 990, Энергоресурс = "пар 13ата", Разм = "Гкал", Факт = 100.674, План = 90.0, Откл = 10.674, Факт_тр = 100.674, План_тр = 90.0, Откл_тр = 10.674, Откл_проц = 12.563 });
        result.Add(new TableDataRu { КодРесурса = 951, Энергоресурс = "вода речная", Разм = "тыс.м3", Факт = 100.674, План = 90.0, Откл = 10.674, Факт_тр = 100.674, План_тр = 90.0, Откл_тр = 10.674, Откл_проц = 12.563 });
        result.Add(new TableDataRu { КодРесурса = 955, Энергоресурс = "электроэнергия", Разм = "МВтч", Факт = 100.674, План = 90.0, Откл = 10.674, Факт_тр = 100.674, План_тр = 90.0, Откл_тр = 10.674, Откл_проц = 12.563 });

        return result;
    }
    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
}