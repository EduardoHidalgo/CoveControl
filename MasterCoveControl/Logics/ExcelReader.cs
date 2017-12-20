using System;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;       //microsoft Excel 14 object in references-> COM tab
using System.Data;
using System.Drawing;

namespace MasterCoveControl
{
    public class ExcelReader : IDisposable
    {
        public string ExcelFile { get; set; }
        public DataTable Table { get; set; }
        public bool TableFilled { get; set; }
        public Exception Exception { get; set; }

        private BusinessLogic.ProcessImportRelation ProcessImportRelation;
        private BusinessLogic.ProcessLoadIssues ProcessLoadIssues;
        public int colCount { get; set; }
        public int CountedRows { get; set; }

        DataColumn ColumnTemp;
        DataRow RowTemp;

        Excel.Application xlApp;
        Excel.Workbook xlWorkbook;
        Excel._Worksheet xlWorksheet;
        Excel.Range xlRange;

        public ExcelReader(string excelFile)
        {
            ExcelFile = excelFile;
            TableFilled = false;
            Exception = null;

            Table = new DataTable();
        }

        public ExcelReader(string excelFile, BusinessLogic.ProcessImportRelation processImportRelation)
        {
            ExcelFile = excelFile;
            TableFilled = false;
            Exception = null;
            ProcessImportRelation = processImportRelation;

            Table = new DataTable();
        }

        public ExcelReader(string excelFile, BusinessLogic.ProcessLoadIssues processLoadIssues)
        {
            ExcelFile = excelFile;
            TableFilled = false;
            Exception = null;
            ProcessLoadIssues = processLoadIssues;

            Table = new DataTable();
        }

        public DataTable GetExcelFile()
        {
            try
            {
                //Create COM Objects. Create a COM object for everything that is referenced
                xlApp = new Excel.Application();
                xlWorkbook = xlApp.Workbooks.Open(ExcelFile);
                xlWorksheet = xlWorkbook.Sheets[1];
                xlRange = xlWorksheet.UsedRange;

                int rowCount = xlRange.Rows.Count;
                colCount = xlRange.Columns.Count;

                //iterate over the rows and columns and print to the console as it appears in the file
                //excel is not zero based!!
                for (int i = 1; i <= rowCount; i++)
                {
                    RowTemp = Table.NewRow();

                    //itera todas las variables en la row 
                    for (CountedRows = 1; CountedRows <= colCount; CountedRows++)
                    {
                        //new line
                        if (i == 1)
                        {
                            //Usa la primera columna para crear los nombres de los campos del DataTable
                            string Field = (string)(xlRange.Cells[i, CountedRows] as Excel.Range).Value2;
                            ColumnTemp = new DataColumn(Field);
                            ColumnTemp.DataType = typeof(string);
                            Table.Columns.Add(ColumnTemp);
                        }
                        else
                        {
                            string pathraw = Convert.ToString((xlRange.Cells[i, CountedRows] as Excel.Range).Value2);
                            if (!string.IsNullOrEmpty(pathraw))
                            {
                                pathraw.Trim();
                                RowTemp[CountedRows - 1] = pathraw;
                            }
                        }
                    }

                    if (i != 1)
                    {
                        Table.Rows.Add(RowTemp);
                        if (i != 0 && xlRange.Rows.Count != 0)
                        {
                            if (ProcessImportRelation != null)
                                ProcessImportRelation.UpdateProgressMethod(i, xlRange.Rows.Count);

                            if(ProcessLoadIssues != null)
                                ProcessLoadIssues.UpdateProgressMethod(i, xlRange.Rows.Count);
                        }
                    }
                }

                TableFilled = true;

            }
            catch (Exception e)
            {
                Exception = e;
                return null;
            }

            return Table;
        }

        public void Dispose()
        {

            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);

            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
