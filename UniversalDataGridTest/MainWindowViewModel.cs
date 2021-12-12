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
            new DataGridStruct { Headers = "ЦЗ", Binding = "IdCC", ColWidth = 0.7, IsGrouping = true },
            new DataGridStruct { Headers = "Код", Binding = "IdER", ColWidth = 0.7 },
            new DataGridStruct { Headers = "Энергоресурс", Binding = "ERName", ColWidth = 1.5 },
            new DataGridStruct { Headers = "Разм.", Binding = "UnitName", ColWidth = 0.7 },
            new DataGridStruct { Headers = "Первичные", Binding = "IsPrime", ColWidth = 1.1 },
            new DataGridStruct { Headers = "Факт", Binding = "FactUse", ColWidth = 1, NumericFormat = "{0:N2}" },
            new DataGridStruct { Headers = "План", Binding = "PlanUse", ColWidth = 1, NumericFormat = "{0:N2}" },
            new DataGridStruct { Headers = "Окл.", Binding = "DiffUse", ColWidth = 1, NumericFormat = "{0:N2}" },
            new DataGridStruct { Headers = "Факт, тыс.руб.", Binding = "FactUseCost", ColWidth = 1, NumericFormat = "{0:N0}" },
            new DataGridStruct { Headers = "План, тыс.руб.", Binding = "PlanUseCost", ColWidth = 1, NumericFormat = "{0:N0}" },
            new DataGridStruct { Headers = "Окл., тыс.руб.", Binding = "DiffUseCost", ColWidth = 1, NumericFormat = "{0:N0}" },
            new DataGridStruct { Headers = "Окл., %", Binding = "DiffProc", ColWidth = 1, NumericFormat = "{0:N1}" }
        };

        List<TableData> tableData = new();
        var arrPeriod = new[] { "2021 янв" };
        var arrCC = new[] { 16, 23, 56, 70, 71, 110, 501 };
        var arrER = new[] { 951, 937, 955, 966, 990 };
        var arrERName = new[] { "вода речная", "холод -20", "электроэнергия", "газ природный", "пар 13 ата" };
        var arrRazm = new[] { "тыс. м3", "Гкал", "МВтч", "Гкал", "Гкал" };
        var arrTariff = new[] { 0.16, 0.670, 3.5, 0.300, 0.870 };
        var arrPrime = new[] { true, false, true, true, true };

        Random randomER = new Random();
        Random randomValue = new Random();
        Random randomDiff = new Random();

        tableData = new();

        for (int period = 0; period < arrPeriod.Length; period++)
            for (int cc = 0; cc < arrCC.Length; cc++)
                for (int er = 0; er < arrER.Length; er++)
                {
                    double fact = (double)randomValue.Next(2000) / 10f;
                    double diff1 = fact * randomDiff.NextDouble() / 10;
                    double diff = (int)diff1 % 2 == 0 ? diff1 : -diff1;
                    double plan = fact + diff;
                    tableData.Add(new TableData
                    {
                        PeriodStr = arrPeriod[period],
                        IdCC = arrCC[cc],
                        IdER = arrER[er],
                        ERName = arrERName[er],
                        UnitName = arrRazm[er],
                        FactUse = fact,
                        PlanUse = plan,
                        DiffUse = diff,
                        FactUseCost = fact * arrTariff[er],
                        PlanUseCost = plan * arrTariff[er],
                        DiffUseCost = diff * arrTariff[er],
                        DiffProc = diff * 100 / plan,
                        IsPrime = arrPrime[er]
                    });
                }

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
    public void TwoRowDataGridShow()
    {
        UserControl table = new TwoRowDataGrid();
        ContentPanel = table;

    }


}
