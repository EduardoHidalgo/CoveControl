using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasterCoveControl
{
    public partial class LoadIssues : UserControl
    {
        BusinessLogic BusinessLogic;
        MainForm MainForm;
        BusinessLogic.ProcessLoadIssues ProcessLoadIssues;

        int Percentage;
        private int SelectedItem;
        private string SelectedText;

        public LoadIssues(BusinessLogic businessLogic, MainForm mainForm)
        {
            InitializeComponent();
            BusinessLogic = businessLogic;
            MainForm = mainForm;
            TextboxPath.Text = "";
            ButtonGetIssues.Enabled = false;
            ProcessLoadIssues = new BusinessLogic.ProcessLoadIssues(BusinessLogic);
            ProcessLoadIssues.UpdateProgress += UpdateProgress1;
        }

        private void LoadIssues_Load(object sender, EventArgs e)
        {
            Percentage = 0;
            backgroundWorker1.WorkerReportsProgress = true;
            List<int> Years = ProcessLoadIssues.GetListYears();
            foreach (int year in Years)
                ComboboxYears.Items.Add(year);
        }

        private void ComboboxYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedItem = ComboboxYears.SelectedIndex;
            SelectedText = ComboboxYears.Text;
        }

        private void ButtonGetExcel_Click(object sender, EventArgs e)
        {
            if (ProcessLoadIssues.GetExcel() && !string.IsNullOrEmpty(SelectedText))
            {
                TextboxPath.Text = ProcessLoadIssues.ExcelRoot;
                ButtonGetIssues.Enabled = true;
            }
            else
            {
                if (!string.IsNullOrEmpty(SelectedText))
                    MainForm.MessageText("No se ha proporcionado ningún año. Eliga uno.", Color.Red);
                else
                    MainForm.MessageText("No se ha proporcionado ninguna dirección de archivo excel válida. Proporcione uno.", Color.Red);
            }
        }

        private void ButtonGetIssues_Click(object sender, EventArgs e)
        {
            ButtonGetIssues.Enabled = false;
            MainForm.ProcessFlag.SetFlag(true, "Cargando Coves Muertos");
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Percentage = 0;
            ProcessLoadIssues.ImportExcel();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage <= ProgressBarFiles.Maximum)
            {
                // Change the value of the ProgressBar to the BackgroundWorker progress.
                ProgressBarFiles.Value = e.ProgressPercentage;
                // Set the text
                ProgressBarText(ProgressBarFiles);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (ProcessLoadIssues.LoadIssuesFlag)
            {
                ProcessLoadIssues.LoadIssues(SelectedText);
            }
            else
            {
                MainForm.MessageText("La obtención del Excel de Coves Muertos ha fallado. revise su reporte o contacte con soporte.", Color.Red);
                if (MainForm.ExceptionFlag.ExceptionObtained)
                {
                    MainForm.LookExceptionFlag();
                    MainForm.ExceptionFlag.Dropflag();
                }
            }

            MainForm.ProcessFlag.DropFlag();
            Reset();
        }

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
            if ((count % (total / 100)) == 0)
            {
                Percentage++;
                backgroundWorker1.ReportProgress(Percentage);
            }
        }

        private void Reset()
        {
            ButtonGetIssues.Enabled = false;
            TextboxPath.Text = "";
            Percentage = 0;
            ProgressBarFiles.Value = 0;
        }
    }
}
