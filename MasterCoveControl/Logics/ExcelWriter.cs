using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using ClosedXML.Excel;

namespace MasterCoveControl
{
    sealed class ExcelWriter : IDisposable
    {
        XLWorkbook WorkBook;

        public void WriteExcel(DataTable Table, string Root, string FileNameWithoutExtension)
        {
            WorkBook = new XLWorkbook();
            WorkBook.Worksheets.Add(Table);
            WorkBook.SaveAs(Root + FileNameWithoutExtension + ".xlsx");

            Dispose();
        }

        public void Dispose()
        {
            if (WorkBook != null)
            {
                WorkBook.Dispose();
            }
        }
    }
}
