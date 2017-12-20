using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace MasterCoveControl
{
    public partial class ImportRelation : UserControl
    {
        BusinessLogic BusinessLogic;
        MainForm MainForm;
        BusinessLogic.ProcessImportRelation ProcessImportRelation;

        int Percentage;

        public ImportRelation(BusinessLogic businessLogic, MainForm mainForm)
        {
            InitializeComponent();
            BusinessLogic = businessLogic;
            MainForm = mainForm;
            Percentage = 0;
        }

        private void ImportRelation_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker2.WorkerReportsProgress = true;
        }

        private void ButtonGetExcel_Click(object sender, EventArgs e)
        {
            MainForm.ProcessFlag.SetFlag(true, "Obtener Archivo Excel");

            ProcessImportRelation = new BusinessLogic.ProcessImportRelation(BusinessLogic);
            ProcessImportRelation.UpdateProgress += UpdateProgress1;

            for (int i = 0; i < CheckedListProgress.Items.Count; i++)
                CheckedListProgress.SetItemChecked(i, false);

            bool ExcelObtained = ProcessImportRelation.GetExcel();
            if (ExcelObtained)
            {
                CheckedListProgress.SetItemChecked(0, true);
                TextboxPath.Text = ProcessImportRelation.ExcelRoot;
                ProcessImportRelation.CreateFolders();
                CheckedListProgress.SetItemChecked(1, true);
                CheckedListProgress.SetItemChecked(2, true);
                CheckedListProgress.SetItemChecked(3, true);
                CheckedListProgress.SetItemChecked(4, true);

                ButtonLoadExcel.Enabled = true;
            }

            MainForm.ProcessFlag.DropFlag();
        }

        #region ButtonLoadExcel

        private void ButtonLoadExcel_Click(object sender, EventArgs e)
        {
            ButtonLoadExcel.Enabled = false;
            Percentage = 0;
            // Start the BackgroundWorker.
            MainForm.ProcessFlag.SetFlag(true, "Cargando Excel");
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            ProcessImportRelation.ImportExcel();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage <= ProgressBarLoadExcel.Maximum)
            {
                // Change the value of the ProgressBar to the BackgroundWorker progress.
                ProgressBarLoadExcel.Value = e.ProgressPercentage;
                // Set the text
                ProgressBarText(ProgressBarLoadExcel);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (ProcessImportRelation.LoadExcelFlag)
            {
                MessageBox.Show("Excel Cargado Exitosamente.");
                CheckedListProgress.SetItemChecked(5, true);

                ButtonGetExcel.Enabled = false;
                ButtonUpdateConfig.Enabled = true;
                MainForm.ProcessFlag.DropFlag();
            }
            else
            {
                if (BusinessLogic.ExceptionFlag.ExceptionObtained)
                {
                    MainForm.ExceptionFlag = BusinessLogic.ExceptionFlag;
                    MainForm.LookExceptionFlag();
                    MainForm.ExceptionFlag.Dropflag();
                    BusinessLogic.ExceptionFlag.Dropflag();
                }
                Reset();
            }
        }

        #endregion

        #region ButtonUpdateconfig

        private void ButtonUpdateConfig_Click(object sender, EventArgs e)
        {
            ButtonUpdateConfig.Enabled = false;
            // Start the BackgroundWorker.
            MainForm.ProcessFlag.SetFlag(true, "Cargando Relación");
            ProcessImportRelation.UpdateProgress -= UpdateProgress1;
            ProcessImportRelation.UpdateProgress += UpdateProgress2;
            Percentage = 0;
            backgroundWorker2.RunWorkerAsync();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            Percentage = 0;
            ProcessImportRelation.UpdateConfig();
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage <= ProgressBarUpdate.Maximum)
            {
                // Change the value of the ProgressBar to the BackgroundWorker progress.
                ProgressBarUpdate.Value = e.ProgressPercentage;
                // Set the text
                ProgressBarText(ProgressBarUpdate);
            }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (ProcessImportRelation.UpdateConfigFlag)
            {
                ProcessImportRelation.Scrubbler();
                MessageBox.Show("Relación Cargada.");
            }
            else
            {
                if (BusinessLogic.ExceptionFlag.ExceptionObtained)
                {
                    MainForm.ExceptionFlag = BusinessLogic.ExceptionFlag;
                    MainForm.LookExceptionFlag();
                    MainForm.ExceptionFlag.Dropflag();
                    BusinessLogic.ExceptionFlag.Dropflag();
                }
            }

            Reset();
        }

        #endregion

        private void ProgressBarText(ProgressBar Bar)
        {
            Bar.Refresh();

            using (Graphics gr = Bar.CreateGraphics())
            {
                gr.DrawString(Percentage.ToString() + "%",
                    SystemFonts.DefaultFont,
                    Brushes.Black,
                    new PointF(Bar.Width / 2 - (gr.MeasureString(Percentage.ToString() + "%",
                        SystemFonts.DefaultFont).Width / 2.0F),
                    Bar.Height / 2 - (gr.MeasureString(Percentage.ToString() + "%",
                        SystemFonts.DefaultFont).Height / 2.0F)));
            }
        }

        /// <summary>
        /// Método que se liga al delegado observador.
        /// </summary>
        /// <param name="count"></param>
        /// <param name="total"></param>
        public void UpdateProgress1(int count, int total)
        {
            if ((count % (double)(total / 100)) < 1)
            {
                Percentage++;
                backgroundWorker1.ReportProgress(Percentage);
            }
        }

        /// <summary>
        /// Método que se liga al delegado observador.
        /// </summary>
        /// <param name="count"></param>
        /// <param name="total"></param>
        public void UpdateProgress2(int count, int total)
        {
            if ((count % (double)(total / 100)) < 1)
            {
                Percentage++;
                backgroundWorker2.ReportProgress(Percentage);
            }
        }

        private void VerifyCheckedList()
        {
            bool allChecked = true;

            for (int i = 0; i < CheckedListProgress.Items.Count; i++)
                if (!CheckedListProgress.GetItemChecked(i))
                    allChecked = false;

            if (allChecked)
                ButtonUpdateConfig.Enabled = true;
        }

        private void Reset()
        {
            //Setea todo a su estado predeterminado
            ProgressBarLoadExcel.Value = 0;
            ProgressBarUpdate.Value = 0;
            TextboxPath.Text = "";
            for (int i = 0; i < CheckedListProgress.Items.Count; i++)
                CheckedListProgress.SetItemChecked(i, false);

            ButtonLoadExcel.Enabled = false;
            ButtonUpdateConfig.Enabled = false;

            ProcessImportRelation.Dispose();
            ProcessImportRelation = null;

            MainForm.ProcessFlag.DropFlag();
        }
    }
}