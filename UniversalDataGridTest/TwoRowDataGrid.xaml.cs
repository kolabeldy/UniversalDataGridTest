using System.Collections.Generic;
using System.Windows.Controls;
using UniversalDataGridTest.Models;

namespace UniversalDataGridTest
{
    public partial class TwoRowDataGrid : UserControl
    {
        public List<TableData> tableData { get; set; }

        public TwoRowDataGrid()
        {
            tableData = TestData.GetData();
            DataContext = this;
            InitializeComponent();
        }
    }
}
