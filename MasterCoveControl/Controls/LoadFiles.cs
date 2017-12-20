using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MasterCoveControl
{
    public partial class LoadFiles : UserControl
    {
        BusinessLogic BusinessLogic;
        MainForm MainForm;
        BusinessLogic.ProcessLoadFiles ProcessLoadFiles;

        private int SelectedItem;
        private string SelectedText;
        private string AcusePath;
        private string DetailPath;

        int Percentage;

        public LoadFiles(BusinessLogic businessLogic, MainForm mainForm)
        {
            InitializeComponent();
            BusinessLogic = businessLogic;
            ProcessLoadFiles = new BusinessLogic.ProcessLoadFiles(BusinessLogic);
            ProcessLoadFiles.UpdateProgress += UpdateProgress1;
            MainForm = mainForm;
            Percentage = 0;
        }

        private void LoadFiles_Load(object sender, EventArgs e)
        {
            List<int> Years = ProcessLoadFiles.GetListYears();
            foreach (int year in Years)
                ComboboxYears.Items.Add(year);

            TextboxPathAcuse.Text = "";
            TextboxPathDetail.Text = "";
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker2.WorkerReportsProgress = true;
        }

        private void ComboboxYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboboxYears.SelectedIndex != -1)
            {
                SelectedItem = ComboboxYears.SelectedIndex;
                SelectedText = ComboboxYears.Text;
                ButtonLoadFiles.Enabled = true;

                if (ProcessLoadFiles.SearchYear(ComboboxYears.Text))
                {
                    ButtonGetAcusesFolder.Enabled = true;
                    ButtonGetDetailFolder.Enabled = true;
                }
                else
                {
                    MainForm.MessageText("Ninguna relación coincide con el año seleccionado. Contacte con soporte.", Color.Red);
                }
            }
        }

        private void ComboboxYears_TextChanged(object sender, EventArgs e)
        {
            SelectedText = ComboboxYears.Text;
        }

        private void ButtonGetAcusesFolder_Click(object sender, EventArgs e)
        {
            TextboxPathAcuse.Text = ProcessLoadFiles.GetFolder("Proporcione la ubicación de los Acuses:");

            if (!string.IsNullOrEmpty(TextboxPathAcuse.Text))
                if (Directory.Exists(TextboxPathAcuse.Text))
                {
                    if (!string.IsNullOrEmpty(TextboxPathAcuse.Text) && !string.IsNullOrEmpty(TextboxPathAcuse.Text))
                        ButtonLoadFiles.Enabled = true;
                }
                else
                {
                    MainForm.MessageText("No se proporcionó ningún folder válido. Intente de nuevo.", Color.Red);
                }
            else
                MainForm.MessageText("No se proporcionó ningún folder. Intente de nuevo.", Color.Red);
        }

        private void ButtonGetDetailFolder_Click(object sender, EventArgs e)
        {
            TextboxPathDetail.Text = ProcessLoadFiles.GetFolder("Proporcione la ubicación de los Detalles:");

            if (!string.IsNullOrEmpty(TextboxPathDetail.Text))
                if (Directory.Exists(TextboxPathDetail.Text))
                {
                    if (!string.IsNullOrEmpty(TextboxPathAcuse.Text) && !string.IsNullOrEmpty(TextboxPathDetail.Text))
                        ButtonLoadFiles.Enabled = true;
                }
                else
                {
                    MainForm.MessageText("No se proporcionó ningún folder válido. Intente de nuevo.", Color.Red);
                }
            else
                MainForm.MessageText("No se proporcionó ningún folder. Intente de nuevo.", Color.Red);
        }

        private void ButtonLoadFiles_Click(object sender, EventArgs e)
        {
            ButtonLoadFiles.Enabled = false;
            ButtonGetAcusesFolder.Enabled = false;
            ButtonGetDetailFolder.Enabled = false;

            Percentage = 0;

            AcusePath = TextboxPathAcuse.Text;
            DetailPath = TextboxPathDetail.Text;

            if (ProcessLoadFiles.SearchYear(ComboboxYears.Text) && TextboxPathAcuse.Text != "" && TextboxPathDetail.Text != "")
            {
                MainForm.ProcessFlag.SetFlag(true, "Cargando Excel");
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                if (TextboxPathAcuse.Text != "" || TextboxPathDetail.Text != "")
                    MainForm.MessageText("Falta una ubicación por seleccionar. Proporcione la ubicación de los archivos " +
                        "ACUSE y los archivos DETALLE que desea agregar.", Color.Red);
                else
                    MainForm.MessageText("Ninguna relación coincide con el año seleccionado. Contacte con soporte.", Color.Red);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            ProcessLoadFiles.CopyFiles(AcusePath, DetailPath, SelectedText);
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
            if (ProcessLoadFiles.CopyFilesFlag)
            {
                ProcessLoadFiles.UpdateProgress -= UpdateProgress1;
                ProcessLoadFiles.UpdateProgress += UpdateProgress2;
                Percentage = 0;
                backgroundWorker2.RunWorkerAsync();
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

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            Percentage = 0;
            ProcessLoadFiles.CheckFiles(Convert.ToInt32(SelectedText));
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage <= ProgressBarChecker.Maximum)
            {
                // Change the value of the ProgressBar to the BackgroundWorker progress.
                ProgressBarChecker.Value = e.ProgressPercentage;
                // Set the text
                ProgressBarText(ProgressBarChecker);
            }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (ProcessLoadFiles.CheckFilesFlag)
                MessageBox.Show("Archivos Cargados Exitosamente.");
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

        public void UpdateProgress2(int count, int total)
        {
            if ((count % (double)(total / 100)) < 1)
            {
                Percentage++;
                backgroundWorker2.ReportProgress(Percentage);
            }
        }

        private void Reset()
        {
            ComboboxYears.SelectedIndex = -1;
            ButtonGetAcusesFolder.Enabled = false;
            ButtonGetDetailFolder.Enabled = false;
            ButtonLoadFiles.Enabled = false;
            TextboxPathAcuse.Text = "";
            TextboxPathDetail.Text = "";
            ProgressBarFiles.Value = 0;
            ProgressBarChecker.Value = 0;
            ProcessLoadFiles.UpdateProgress += UpdateProgress1;
            ProcessLoadFiles.UpdateProgress -= UpdateProgress2;
            Percentage = 0;
            MainForm.ProcessFlag.DropFlag();
        }
    }
}
