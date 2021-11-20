using System.Windows;
using System.Windows.Media;

namespace UniversalDataGridTest
{
    public class TStruct
    {
        public string Headers { get; set; }
        public string Binding { get; set; }
        public double ColWidth { get; set; }
        public TextAlignment TextAligment { get; set; }
        public string NumericFormat { get; set; }
        public bool ColumnVisible { get; set; }
        public bool TotalRowTextVisible { get; set; }

    }
}
