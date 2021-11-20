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

namespace UniversalDataGridTest;
public partial class UniversalDataGrid : UserControl, INotifyPropertyChanged
{
    public ObservableCollection<TableData> GridData { get; set; } = new();
    public ObservableCollection<TableData> TotalData { get; set; } = new();


    public List<TStruct> TableStructure { get; set; } = new();
    public SolidColorBrush TotalRowBrush { get; set; }
    public bool IsHighlight { get; set; }
    private string EmptyStr { get; set; }



    private SolidColorBrush hightLightBrushPink = new SolidColorBrush(Color.FromRgb(255, 235, 235));
    private SolidColorBrush hightLightBrushGreen = new SolidColorBrush(Color.FromRgb(235, 255, 235));
    private SolidColorBrush normalBrush = new SolidColorBrush(Colors.White);


    public UniversalDataGrid(List<TStruct> tableStructure, bool isHighlight = false)
    {
        TableStructure = tableStructure;
        IsHighlight = isHighlight;
        EmptyStr = "";
        GridData = Get();
        DataContext = this;
        InitializeComponent();
    }

    private ObservableCollection<TableData> Get()
    {
        ObservableCollection<TableData> result = new();

        result.Add(new TableData { Period = 202106, PeriodStr = "2021 июн", IdCC = 56, CCName = "ЦЗ-056", IdER = 990, ERName = "пар 13ата", UnitName = "Гкал", FactUse = 100.674, PlanUse = 90.0, DiffUse = 10.674, FactUseCost = 100.674, PlanUseCost = 90.0, DiffUseCost = 10.674, DiffProc = 12.563 });
        result.Add(new TableData { Period = 202106, PeriodStr = "2021 июн", IdCC = 71, CCName = "ЦЗ-071", IdER = 991, ERName = "горячая вода", UnitName = "Гкал", FactUse = 100.674, PlanUse = 90.0, DiffUse = 10.674, FactUseCost = 100.674, PlanUseCost = 90.0, DiffUseCost = 10.674, DiffProc = 12.563 });
        result.Add(new TableData { Period = 202106, PeriodStr = "2021 июн", IdCC = 71, CCName = "ЦЗ-110", IdER = 955, ERName = "электроэнергия", UnitName = "МВтч", FactUse = 55100.674, PlanUse = 54090.0, DiffUse = 110.674, FactUseCost = 55100.674, PlanUseCost = 54090.0, DiffUseCost = 110.674, DiffProc = 12.563 });

        return result;
    }
    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
}