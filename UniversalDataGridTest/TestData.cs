using System;
using System.Collections.Generic;
using UniversalDataGridTest.Models;

namespace UniversalDataGridTest;
public class TestData
{
    public static List<TableData> GetData()
    {
        Random randomER = new Random();
        Random randomValue = new Random();
        Random randomDiff = new Random();

        var arrPeriod = new[] { "2021 янв", "2021 фев", "2021 мар", "2021 апр", "2021 май", "2021 июн", "2021 июл" };
        var arrCC = new[] { 16, 23, 56, 70, 71, 110, 501 };
        var arrER = new[] { 951, 937, 955, 966, 990 };
        var arrERName = new[] { "вода речная", "холод -20", "электроэнергия", "газ природный", "пар 13 ата" };
        var arrRazm = new[] { "тыс. м3", "Гкал", "МВтч", "Гкал", "Гкал" };
        var arrTariff = new[] { 0.16, 0.670, 3.5, 0.300, 0.870 };
        var arrPrime = new[] { true, false, true, true, true };

        List<TableData> result = new();

        for (int period = 0; period < arrPeriod.Length; period++)
            for (int cc = 0; cc < arrCC.Length; cc++)
                for (int er = 0; er < arrER.Length; er++)
                {
                    double fact = (double)randomValue.Next(2000) / 10f;
                    double diff1 = fact * randomDiff.NextDouble() / 10;
                    double diff = (int)diff1 % 2 == 0 ? diff1 : -diff1;
                    double plan = fact + diff;
                    result.Add(new TableData
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
        return result;

    }

}