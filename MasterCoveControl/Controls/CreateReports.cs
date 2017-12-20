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
    public partial class CreateReports : UserControl
    {
        BusinessLogic BusinessLogic;
        MainForm MainForm;
        BusinessLogic.ProcessCreateReports ProcessCreateReports;

        private int SelectedItem;
        private string SelectedText;

        public CreateReports(BusinessLogic businessLogic, MainForm mainForm)
        {
            InitializeComponent();
            BusinessLogic = businessLogic;
            MainForm = mainForm;
            ButtonCreateReports.Enabled = false;
            ProcessCreateReports = new BusinessLogic.ProcessCreateReports(BusinessLogic);

            List<int> Years = ProcessCreateReports.GetListYears();
            foreach (int year in Years)
                ComboboxYears.Items.Add(year);
        }

        private void ComboboxYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedItem = ComboboxYears.SelectedIndex;
            SelectedText = ComboboxYears.Text;

            if (SelectedItem != -1)
            {
                if (ProcessCreateReports.SearchYear(ComboboxYears.Text))
                {
                    ButtonCreateReports.Enabled = true;
                }
                else
                {
                    MainForm.MessageText("Ninguna relación coincide con el año seleccionado. Contacte con soporte.", Color.Red);
                }
            }
        }

        private void ButtonCreateReports_Click(object sender, EventArgs e)
        {
            MainForm.ProcessFlag.SetFlag(true, "Crear Reportes");
            ProcessCreateReports.CreateReports(SelectedText);

            if (ProcessCreateReports.CreateReportsFlag)
                MessageBox.Show("Reportes creados exitosamente.");
            else
            {
                if (MainForm.ExceptionFlag.ExceptionObtained)
                {
                    MessageBox.Show("La creación de los reportes ha fallado. Contacte con soporte.");

                    MainForm.LookExceptionFlag();
                    MainForm.ExceptionFlag.Dropflag();
                }
            }

            MainForm.ProcessFlag.DropFlag();
        }

        private void Reset()
        {
            ButtonCreateReports.Enabled = false;
            ComboboxYears.SelectedIndex = -1;
            MainForm.ProcessFlag.DropFlag();
        }
    }
}
