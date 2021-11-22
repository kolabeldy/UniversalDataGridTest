using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using MyServicesLibrary.Controls.UniversalDataGrid;
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
    public void UniversalDataGridAutoShow()
    {
        List<DataGridStruct> tstruct = new()
        {
            new DataGridStruct { Headers = "Код", Binding = "IdER", ColWidth = 0.7 },
            new DataGridStruct { Headers = "Ресурс", Binding = "ERName", ColWidth = 1.5 },
            new DataGridStruct { Headers = "Разм.", Binding = "UnitName", ColWidth = 0.7 },
            new DataGridStruct { Headers = "Перв", Binding = "IsPrime", ColWidth = 0.7 },
            new DataGridStruct { Headers = "Факт", Binding = "FactUse", ColWidth = 1, NumericFormat = "{0:N2}" },
            new DataGridStruct { Headers = "План", Binding = "PlanUse", ColWidth = 1, NumericFormat = "{0:N2}" },
            new DataGridStruct { Headers = "Окл.", Binding = "DiffUse", ColWidth = 1, NumericFormat = "{0:N2}" },
            new DataGridStruct { Headers = "Факт, тыс.руб.", Binding = "FactUseCost", ColWidth = 1, NumericFormat = "{0:N0}" },
            new DataGridStruct { Headers = "План, тыс.руб.", Binding = "PlanUseCost", ColWidth = 1, NumericFormat = "{0:N0}" },
            new DataGridStruct { Headers = "Окл., тыс.руб.", Binding = "DiffUseCost", ColWidth = 1, NumericFormat = "{0:N0}" },
            new DataGridStruct { Headers = "Окл., %", Binding = "DiffProc", ColWidth = 1, NumericFormat = "{0:N1}" }
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

        UniversalDataGrid table = new UniversalDataGrid(tstruct);
        table.Show<TableData>(tableData);
        ContentPanel = table;

    }
    public void UniversalDataGridAuto2Show()
    {
        List<DataGridStruct> tstruct = new()
        {
            new DataGridStruct { Headers = "Ном", Binding = "Id", ColWidth = 0.7 },
            new DataGridStruct { Headers = "Наименование", Binding = "Name", ColWidth = 1.5 },
            new DataGridStruct { Headers = "Количество", Binding = "Count", ColWidth = 0.7 },
            new DataGridStruct { Headers = "Величина", Binding = "Volume", ColWidth = 0.7, NumericFormat = "{0:N2}" },
        };

        List<TableData1> tableData = new();

        tableData.Add(new TableData1
        {
            Id = 1111,
            Name = "Первый",
            Count = 56,
            Volume = 100.674
        });
        tableData.Add(new TableData1
        {
            Id = 2222,
            Name = "Второй",
            Count = 56,
            Volume = 853100.635
        });
        tableData.Add(new TableData1
        {
            Id = 3333,
            Name = "Третий",
            Count = 56,
            Volume = 8925100.14678
        });

        UniversalDataGrid table = new UniversalDataGrid(tstruct);
        table.Show<TableData1>(tableData);
        ContentPanel = table;

    }


}
