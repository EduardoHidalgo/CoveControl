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
    public partial class CreateConfig : UserControl
    {
        BusinessLogic BusinessLogic;
        BusinessLogic.ProcessCreateConfig ClassCreateconfig;

        MainForm MainForm;

        public CreateConfig(BusinessLogic businessLogic, MainForm mainForm)
        {
            InitializeComponent();
            BusinessLogic = businessLogic;
            MainForm = mainForm;
            TextboxPath.Text = "";
        }

        private void ButtonGetFolder_Click(object sender, EventArgs e)
        {
            ClassCreateconfig = new BusinessLogic.ProcessCreateConfig(BusinessLogic);
            ClassCreateconfig.GetRoot();
            if (!string.IsNullOrEmpty(ClassCreateconfig.Root))
                TextboxPath.Text = ClassCreateconfig.Root;
        }

        private void ButtonCreateConfig_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextboxPath.Text))
            {
                MainForm.ProcessFlag.SetFlag(true, "Crear Archivo de Configuración");
                ClassCreateconfig.CreateConfig();
                TextboxPath.Text = "";
                MainForm.ProcessFlag.DropFlag();
                MainForm.MessageText("\nConfiguración Generada Exitosamente.", Color.Green);
            }
            else
            {
                MainForm.MessageText("No ha proporcionado ninguna carpeta, seleccione una antes de generar una configuración.\n", Color.Red);
            }
        }

        private void ButtonDeleteConfig_Click(object sender, EventArgs e)
        {
            if (ClassCreateconfig.DeleteConfigFlag)
            {
                MainForm.ProcessFlag.SetFlag(true, "Crear Archivo de Configuración");
                BusinessLogic = new BusinessLogic(MainForm);
                ClassCreateconfig = new BusinessLogic.ProcessCreateConfig(BusinessLogic);
                ClassCreateconfig.DeleteConfig();

                BusinessLogic = new BusinessLogic(MainForm);
                MainForm.ProcessFlag.DropFlag();

                MessageBox.Show("\nConfiguración Eliminada Exitosamente.");
            }

            if (BusinessLogic.ExceptionFlag.ExceptionObtained)
            {
                MainForm.ExceptionFlag = BusinessLogic.ExceptionFlag;
                MainForm.LookExceptionFlag();
                MainForm.ExceptionFlag.Dropflag();
                BusinessLogic.ExceptionFlag.Dropflag();
            }
        }
    }
}
