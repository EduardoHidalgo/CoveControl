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
    public partial class Stats : UserControl
    {
        BusinessLogic BusinessLogic;
        MainForm MainForm;
        BusinessLogic.ProcessStats ProcessStats;

        private int RelationIndex;
        private string RelationText;
        private int ClientsIndex;
        private string ClientsText;

        public Stats(BusinessLogic businessLogic, MainForm mainForm)
        {
            InitializeComponent();
            BusinessLogic = businessLogic;
            MainForm = mainForm;
            ProcessStats = new BusinessLogic.ProcessStats(BusinessLogic);
        }

        private void Stats_Load(object sender, EventArgs e)
        {
            RelationIndex = ComboboxRelations.SelectedIndex;
            RelationText = ComboboxRelations.Text;
            ClientsIndex = ComboboxClients.SelectedIndex;
            ClientsText = ComboboxClients.Text;

            GetRelations();
        }

        #region ComboboxRelations

        private void ComboboxRelations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboboxRelations.SelectedIndex != -1)
            {
                RelationIndex = ComboboxRelations.SelectedIndex;
                RelationText = ComboboxRelations.Text;
                ComboboxClients.SelectedIndex = -1;
                ComboboxClients.Text = "";
                ClientsIndex = ComboboxClients.SelectedIndex;
                ClientsText = ComboboxClients.Text;
                GetClients();
                GetStats();
            }
            else
            {
                MainForm.MessageText("Rompiste el programa!", Color.Red);
            }
        }

        private void BoxReferenceTotal_TextChanged(object sender, EventArgs e)
        {
            RelationText = ComboboxRelations.Text;
        }

        #endregion

        #region ComboboxClients

        private void ComboboxClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClientsIndex = ComboboxClients.SelectedIndex;
            ClientsText = ComboboxClients.Text;
            GetStats();
        }

        private void ComboboxClients_TextChanged(object sender, EventArgs e)
        {

        }

        #endregion

        private void GetRelations()
        {
            List<int> Years = ProcessStats.GetListYears();

            if (Years.Count != 0)
            {
                foreach (var year in Years)
                    ComboboxRelations.Items.Add(year);

                ComboboxRelations.Items.Add("Todos");
            }
            else
            {
                MainForm.MessageText("No se ha obtenido ninguna Relación. Ingrese Relaciones primero.", Color.Red);
            }
        }

        private void GetClients()
        {
            List<string> Clients = new List<string>();

            if (RelationText == "Todos" && (ClientsIndex == -1 || ClientsText == "Todos"))
            {
                Clients = ProcessStats.GetAllClients();
            }
            else
            {
                Clients = ProcessStats.GetClients(ComboboxRelations.Text);
            }

            if (Clients.Count != 0)
            {
                ComboboxClients.Items.Clear();

                foreach (var client in Clients)
                    ComboboxClients.Items.Add(client);

                ComboboxClients.Items.Add("Todos");
            }
            else
                MainForm.MessageText("La relación no contiene ningún cliente, revise la data entregada o contacte con soporte.", Color.Red);
        }

        private void GetStats()
        {
            Entities.StatsObject StatsObject = new Entities.StatsObject();

            if (RelationText != "Todos") //Algún año en particular
            {
                if (ClientsText == "Todos" || ClientsIndex == -1) //Si no tiene cliente seleccionado o elige "todos"
                {
                    StatsObject = ProcessStats.GetStats(Convert.ToInt32(RelationText));
                }
                else
                {
                    StatsObject = ProcessStats.GetStats(Convert.ToInt32(RelationText), ClientsText);
                }
            }
            else //Todos los años
            {
                if (ClientsText == "Todos" || ClientsIndex == -1) //Si no tiene cliente seleccionado o elige "todos"
                {
                    StatsObject = ProcessStats.GetStats();
                }
                else
                {
                    StatsObject = ProcessStats.GetStats(ClientsText);
                }
            }

            if (ProcessStats.GetStatsFlag)
                AddStats(StatsObject);
            else
                MainForm.MessageText("El proceso de Obtención de Estadísticas ha fallado. Contacte con soporte.", Color.Red);
        }

        private void AddStats(Entities.StatsObject StatsObject)
        {
            BoxReferencesTotal.Text = Convert.ToString(StatsObject.ReferencesTotal);
            BoxReferencesFull.Text = Convert.ToString(StatsObject.ReferencesFull);
            BoxReferencesUnfull.Text = Convert.ToString(StatsObject.ReferencesUnfull);
            BoxReferencesWrong.Text = Convert.ToString(StatsObject.ReferencesWrong);
            BoxAcuseFull.Text = Convert.ToString(StatsObject.AcusesFull);
            BoxAcuseUnfull.Text = Convert.ToString(StatsObject.AcusesUnfull);
            BoxAcuseWrong.Text = Convert.ToString(StatsObject.AcusesWrong);
            BoxAcuseEmpty.Text = Convert.ToString(StatsObject.AcusesEmpty);
            BoxDetailFull.Text = Convert.ToString(StatsObject.DetailsFull);
            BoxDetailUnfull.Text = Convert.ToString(StatsObject.DetailsUnfull);
            BoxDetailWrong.Text = Convert.ToString(StatsObject.DetailsWrong);
            BoxDetailEmpty.Text = Convert.ToString(StatsObject.DetailsEmpty);
        }
    }
}
