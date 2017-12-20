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
    public partial class ExportClient : UserControl
    {
        BusinessLogic BusinessLogic;
        MainForm MainForm;
        BusinessLogic.ProcessExportClient ProcessExportClient;

        private int RelationIndex;
        private string RelationText;
        private int ClientsIndex;
        private string ClientsText;

        int Percentage;

        public ExportClient(BusinessLogic businessLogic, MainForm mainForm)
        {
            InitializeComponent();
            BusinessLogic = businessLogic;
            MainForm = mainForm;
            backgroundWorker1.WorkerReportsProgress = true;
            Percentage = 0;

            ProcessExportClient = new BusinessLogic.ProcessExportClient(BusinessLogic);
            ProcessExportClient.UpdateProgress += UpdateProgress1;
            ComboboxClient.Enabled = false;
            ButtonExportClient.Enabled = false;
            GetRelations();
        }

        private void GetRelations()
        {
            List<int> Years = ProcessExportClient.GetListYears();

            if (Years.Count != 0)
            {
                foreach (var year in Years)
                    ComboboxYear.Items.Add(year);

                ComboboxYear.Items.Add("Todos");
            }
            else
            {
                MainForm.MessageText("No se ha obtenido ninguna Relación. Ingrese Relaciones primero.", Color.Red);
            }
        }

        private void GetClients()
        {
            List<string> Clients = new List<string>();

            Clients = ProcessExportClient.GetClients(ComboboxYear.Text);

            if (Clients.Count != 0)
            {
                ComboboxClient.Items.Clear();

                foreach (var client in Clients)
                    ComboboxClient.Items.Add(client);
            }
            else
                MainForm.MessageText("La relación no contiene ningún cliente, revise la data entregada o contacte con soporte.", Color.Red);
        }

        private void ComboboxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            RelationIndex = ComboboxYear.SelectedIndex;
            RelationText = ComboboxYear.Text;

            if (RelationIndex != -1)
                if (ProcessExportClient.SearchYear(RelationText))
                {
                    GetClients();
                    ComboboxClient.Enabled = true;
                }
                else
                {
                    MainForm.MessageText("Ninguna relación coincide con el año seleccionado. Contacte con soporte.", Color.Red);
                }
        }

        private void ComboboxClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RelationIndex != -1)
            {
                ClientsIndex = ComboboxClient.SelectedIndex;
                ClientsText = ComboboxClient.Text;
                ButtonExportClient.Enabled = true;
            }
        }

        private void ButtonExportClient_Click(object sender, EventArgs e)
        {
            MainForm.ProcessFlag.SetFlag(true, "Exportar Cliente");
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Percentage = 0;
            ProcessExportClient.ExportClient(RelationText, ClientsText);
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

            if (ProcessExportClient.ExportClientFlag)
                MessageBox.Show("Cliente Exportado exitosamente.");
            else
            {
                if (MainForm.ExceptionFlag.ExceptionObtained)
                {
                    MessageBox.Show("El proceso Exportar Cliente ha fallado. Contacte con soporte.\n\n");
                    MainForm.LookExceptionFlag();
                    MainForm.ExceptionFlag.Dropflag();
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

        private void Reset()
        {
            ButtonExportClient.Enabled = false;
            ComboboxClient.Enabled = false;
            ComboboxClient.SelectedIndex = -1;
            ComboboxYear.SelectedIndex = -1;

            Percentage = 0;
            ProgressBarUpdate.Value = 0;

            MainForm.ProcessFlag.DropFlag();
        }
    }
}
