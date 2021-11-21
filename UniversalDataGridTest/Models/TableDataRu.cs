using System.Collections.Generic;
using System.Linq;

namespace UniversalDataGridTest.Models;
public class TableDataRu
{
    public int Период { get; set; }
    public string ИмяПериода { get; set; }
    public int КодРесурса { get; set; }
    public int КодЦЗ { get; set; }
    public string ЦентрЗатрат { get; set; }
    public string Энергоресурс { get; set; }
    public bool Основной { get; set; }
    public bool Первичный { get; set; }
    public int КодРазм { get; set; }
    public string Разм { get; set; }

    public double Факт { get; set; }
    public double Факт_тр { get; set; }

    public double План { get; set; }
    public double План_тр { get; set; }

    public double Откл { get; set; }
    public double Откл_тр { get; set; }
    public double Откл_проц { get; set; }

}