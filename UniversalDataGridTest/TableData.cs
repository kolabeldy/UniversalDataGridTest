using System.Collections.Generic;
using System.Linq;

namespace UniversalDataGridTest;
public class TableData
{
    public int Period { get; set; }
    public string PeriodStr { get; set; }
    public int IdER { get; set; }
    public int IdCC { get; set; }
    public string CCName { get; set; }
    public bool IsMainCC { get; set; }
    public string ERName { get; set; }
    public bool IsMain { get; set; }
    public bool IsPrime { get; set; }
    public int Unit { get; set; }
    public string UnitName { get; set; }

    public double FactUse { get; set; }
    public double FactUseCost { get; set; }

    public double PlanUse { get; set; }
    public double PlanUseCost { get; set; }

    public double DiffUse { get; set; }
    public double DiffUseCost { get; set; }
    public double DiffProc { get; set; }

}