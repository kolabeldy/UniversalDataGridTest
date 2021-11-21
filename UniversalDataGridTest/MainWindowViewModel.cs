using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using MyServicesLibrary.SideMenu;
using MyServicesLibrary.ViewModelsBase;
using UniversalDataGridTest.Models;

namespace UniversalDataGridTest;
public class MainWindowViewModel : BaseViewModel
{
    public SideMenu? SideMenu { get; set; }


    private UserControl _ContentPanel = new();
    public UserControl ContentPanel
    {
        get => _ContentPanel;
        set
        {
            Set(ref _ContentPanel, value);
        }
    }

    public MainWindowViewModel()
    {
        SideMenu = new SideMenu(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.db"));
        SideMenu.OnMenuChoise += MainMenuChoiseCommand;
    }

    private void MainMenuChoiseCommand(string methodName)
    {
        if (methodName != null)
        {
            MethodInfo? method = typeof(MainWindowViewModel).GetMethod(methodName);
            if (method != null) method.Invoke(this, null);
        }

    }
    public void UniversalDataGridShow1()
    {
        List<TStruct> tstruct = new()
        {
            new TStruct { Headers = "Код", Binding = "IdER", ColWidth = 0.7, TextAligment = TextAlignment.Left, NumericFormat = "{0:N0}", ColumnVisible = true, TotalRowTextVisible = false },
            new TStruct { Headers = "Ресурс", Binding = "ERName", ColWidth = 1.5, TextAligment = TextAlignment.Left, NumericFormat = "{0:N0}", ColumnVisible = true, TotalRowTextVisible = true },
            new TStruct { Headers = "Разм.", Binding = "UnitName", ColWidth = 0.7, TextAligment = TextAlignment.Left, NumericFormat = "{0:N0}", ColumnVisible = true, TotalRowTextVisible = false },
            new TStruct { Headers = "Факт", Binding = "FactUse", ColWidth = 1, TextAligment = TextAlignment.Right, NumericFormat = "{0:N2}", ColumnVisible = true, TotalRowTextVisible = false },
            new TStruct { Headers = "План", Binding = "PlanUse", ColWidth = 1, TextAligment = TextAlignment.Right, NumericFormat = "{0:N2}", ColumnVisible = true, TotalRowTextVisible = false },
            new TStruct { Headers = "Окл.", Binding = "DiffUse", ColWidth = 1, TextAligment = TextAlignment.Right, NumericFormat = "{0:N2}", ColumnVisible = true, TotalRowTextVisible = false },
            new TStruct { Headers = "Факт, т.р.", Binding = "FactUseCost", ColWidth = 1, TextAligment = TextAlignment.Right, NumericFormat = "{0:N0}", ColumnVisible = true, TotalRowTextVisible = true },
            new TStruct { Headers = "План, т.р.", Binding = "PlanUseCost", ColWidth = 1, TextAligment = TextAlignment.Right, NumericFormat = "{0:N0}", ColumnVisible = true, TotalRowTextVisible = true },
            new TStruct { Headers = "Окл., т.р.", Binding = "DiffUseCost", ColWidth = 1, TextAligment = TextAlignment.Right, NumericFormat = "{0:N0}", ColumnVisible = true, TotalRowTextVisible = true },
            new TStruct { Headers = "Окл., %", Binding = "DiffProc", ColWidth = 1, TextAligment = TextAlignment.Right, NumericFormat = "{0:N1}", ColumnVisible = true, TotalRowTextVisible = true },
            new TStruct { Headers = "Первичный", Binding = "IsPrime", ColWidth = 0.7, TextAligment = TextAlignment.Right, NumericFormat = "{0:N1}", ColumnVisible = true, TotalRowTextVisible = true }
        };


        ContentPanel = new UniversalDataGrid(tstruct);

    }
    public void UniversalDataGridAutoShow()
    {
        List<TStruct> tstruct = new()
        {
            new TStruct { Headers = "Код", Binding = "IdER", ColWidth = 0.7, TextAligment = TextAlignment.Left, NumericFormat = "{0:N0}", ColumnVisible = true, TotalRowTextVisible = false },
            new TStruct { Headers = "Ресурс", Binding = "ERName", ColWidth = 1.5, TextAligment = TextAlignment.Left, NumericFormat = "{0:N0}", ColumnVisible = true, TotalRowTextVisible = true },
            new TStruct { Headers = "Разм.", Binding = "UnitName", ColWidth = 0.7, TextAligment = TextAlignment.Left, NumericFormat = "{0:N0}", ColumnVisible = true, TotalRowTextVisible = false },
            new TStruct { Headers = "Перв", Binding = "IsPrime", ColWidth = 0.7, TextAligment = TextAlignment.Right, NumericFormat = "{0:N1}", ColumnVisible = true, TotalRowTextVisible = true },
            new TStruct { Headers = "Факт", Binding = "FactUse", ColWidth = 1, TextAligment = TextAlignment.Right, NumericFormat = "{0:N2}", ColumnVisible = true, TotalRowTextVisible = false },
            new TStruct { Headers = "План", Binding = "PlanUse", ColWidth = 1, TextAligment = TextAlignment.Right, NumericFormat = "{0:N2}", ColumnVisible = true, TotalRowTextVisible = false },
            new TStruct { Headers = "Окл.", Binding = "DiffUse", ColWidth = 1, TextAligment = TextAlignment.Right, NumericFormat = "{0:N2}", ColumnVisible = true, TotalRowTextVisible = false },
            new TStruct { Headers = "Факт, тыс. руб.", Binding = "FactUseCost", ColWidth = 1, TextAligment = TextAlignment.Right, NumericFormat = "{0:N0}", ColumnVisible = true, TotalRowTextVisible = true },
            new TStruct { Headers = "План, тыс. руб.", Binding = "PlanUseCost", ColWidth = 1, TextAligment = TextAlignment.Right, NumericFormat = "{0:N0}", ColumnVisible = true, TotalRowTextVisible = true },
            new TStruct { Headers = "Окл., тыс. руб.", Binding = "DiffUseCost", ColWidth = 1, TextAligment = TextAlignment.Right, NumericFormat = "{0:N0}", ColumnVisible = true, TotalRowTextVisible = true },
            new TStruct { Headers = "Окл., %", Binding = "DiffProc", ColWidth = 1, TextAligment = TextAlignment.Right, NumericFormat = "{0:N1}", ColumnVisible = true, TotalRowTextVisible = true }
        };

        List<TableData> tableData = new();

        tableData.Add(new TableData
        {
            Period = 202106,
            PeriodStr = "2021 июн",
            IdCC = 56,
            CCName = "ЦЗ-056",
            IdER = 990,
            ERName = "пар 13ата",
            UnitName = "Гкал",
            FactUse = 100.674,
            PlanUse = 90.0,
            DiffUse = 10.674,
            FactUseCost = 100.674,
            PlanUseCost = 90.0,
            DiffUseCost = 10.674,
            DiffProc = 12.563,
            IsPrime = false
        });
        tableData.Add(new TableData
        {
            Period = 202106,
            PeriodStr = "2021 июн",
            IdCC = 71,
            CCName = "ЦЗ-071",
            IdER = 991,
            ERName = "горячая вода",
            UnitName = "Гкал",
            FactUse = 100.674,
            PlanUse = 90.0,
            DiffUse = 10.674,
            FactUseCost = 100.674,
            PlanUseCost = 90.0,
            DiffUseCost = 10.674,
            DiffProc = 12.563,
            IsPrime = true
        });
        tableData.Add(new TableData
        {
            Period = 202106,
            PeriodStr = "2021 июн",
            IdCC = 71,
            CCName = "ЦЗ-110",
            IdER = 955,
            ERName = "электроэнергия",
            UnitName = "МВтч",
            FactUse = 55100.674,
            PlanUse = 54090.0,
            DiffUse = 110.674,
            FactUseCost = 55100.674,
            PlanUseCost = 54090.0,
            DiffUseCost = 110.674,
            DiffProc = 12.563,
            IsPrime = true
        });

        UniversalDataGridAuto table = new UniversalDataGridAuto(tableData, tstruct);
        ContentPanel = table;

    }

}
