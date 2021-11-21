using System;
using System.Collections.Generic;
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
            new TStruct { Headers = "Окл., %", Binding = "DiffProc", ColWidth = 1, TextAligment = TextAlignment.Right, NumericFormat = "{0:N1}", ColumnVisible = true, TotalRowTextVisible = true }
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
            new TStruct { Headers = "Факт", Binding = "FactUse", ColWidth = 1, TextAligment = TextAlignment.Right, NumericFormat = "{0:N2}", ColumnVisible = true, TotalRowTextVisible = false },
            new TStruct { Headers = "План", Binding = "PlanUse", ColWidth = 1, TextAligment = TextAlignment.Right, NumericFormat = "{0:N2}", ColumnVisible = true, TotalRowTextVisible = false },
            new TStruct { Headers = "Окл.", Binding = "DiffUse", ColWidth = 1, TextAligment = TextAlignment.Right, NumericFormat = "{0:N2}", ColumnVisible = true, TotalRowTextVisible = false },
            new TStruct { Headers = "Факт, т.р.", Binding = "FactUseCost", ColWidth = 1, TextAligment = TextAlignment.Right, NumericFormat = "{0:N0}", ColumnVisible = true, TotalRowTextVisible = true },
            new TStruct { Headers = "План, т.р.", Binding = "PlanUseCost", ColWidth = 1, TextAligment = TextAlignment.Right, NumericFormat = "{0:N0}", ColumnVisible = true, TotalRowTextVisible = true },
            new TStruct { Headers = "Окл., т.р.", Binding = "DiffUseCost", ColWidth = 1, TextAligment = TextAlignment.Right, NumericFormat = "{0:N0}", ColumnVisible = true, TotalRowTextVisible = true },
            new TStruct { Headers = "Окл., %", Binding = "DiffProc", ColWidth = 1, TextAligment = TextAlignment.Right, NumericFormat = "{0:N1}", ColumnVisible = true, TotalRowTextVisible = true }
        };


        ContentPanel = new UniversalDataGridAuto(tstruct);

    }

}
