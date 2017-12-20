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
    public partial class CreateLoadFolder : UserControl
    {
        BusinessLogic BusinessLogic;
        MainForm MainForm;
        BusinessLogic.ProcessCreateLoadFolder ProcessCreateLoadFolder;

        private int Percentage;
        private int SelectedItem;
        private string SelectedText;

        public CreateLoadFolder(BusinessLogic businessLogic, MainForm mainForm)
        {
            InitializeComponent();
            BusinessLogic = businessLogic;
            MainForm = mainForm;

            ProcessCreateLoadFolder = new BusinessLogic.ProcessCreateLoadFolder(BusinessLogic);
            backgroundWorker1.WorkerReportsProgress = true;

            List<int> Years = ProcessCreateLoadFolder.GetListYears();
            foreach (int year in Years)
                ComboboxYears.Items.Add(year);
        }

        private void ComboboxYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedItem = ComboboxYears.SelectedIndex;
            SelectedText = ComboboxYears.Text;

            if (ComboboxYears.SelectedIndex != -1)
                ButtonCreateFolder.Enabled = true;
        }

        private void ButtonCreateFolder_Click(object sender, EventArgs e)
        {
            MainForm.ProcessFlag.SetFlag(true, "Crear Carpeta de Carga");

            if (ProcessCreateLoadFolder.SearchYear(SelectedText))
                backgroundWorker1.RunWorkerAsync();
            else
                MainForm.MessageText("No se ha encontrado ninguna relación que coincida con el año. Contacte con soporte.", Color.Red);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Percentage = 0;
            ProcessCreateLoadFolder.LoadFilesToSystem();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage <= ProgressBarUpdate.Maximum)
            {
                // Change the value of the ProgressBar to the BackgroundWorker progress.
                ProgressBarUpdate.Value = e.ProgressPercentage;
                // Set the text
                ProgressBarText(ProgressBarUpdate);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (ProcessCreateLoadFolder.LoadFolderFlag)
            {
                MessageBox.Show("Carpeta Generada Correctamente");
            }
            else
            {
                MainForm.MessageText("La generación de la carpeta de carga ha fallado. contacte con soporte.\n\n", Color.Red);
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

        public void Reset()
        {
            Percentage = 0;
            ComboboxYears.SelectedIndex = -1;
            SelectedItem = -1;
            SelectedText = "";

            ButtonCreateFolder.Enabled = false;
            ProgressBarUpdate.Value = 0;

            MainForm.ProcessFlag.DropFlag();
            
        }
    }
}
