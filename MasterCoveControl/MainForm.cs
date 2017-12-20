using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasterCoveControl
{
    /// <summary>
    /// Formulario Principal del Sistema de Control de Coves
    /// </summary>
    public partial class MainForm : Form
    {
        public ProcessFlag ProcessFlag { get; set; }

        public ExceptionFlag ExceptionFlag { get; set; }

        private BusinessLogic BusinessLogic;

        public MainForm()
        {
            InitializeComponent();

            BusinessLogic = new BusinessLogic(this);

            ProcessFlag = new ProcessFlag(this);
            ProcessFlag.DropFlag();

            ExceptionFlag = new ExceptionFlag();
            ExceptionFlag.Dropflag();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        #region Event Buttons

        private void ButtonCreateConfig_Click(object sender, EventArgs e)
        {
            if (!ProcessFlag.Enable)
            {
                AddControl(new CreateConfig(BusinessLogic, this));
            }
            else
            {
                MessageText("No puede ejecutar otro proceso. Operación \"" + ProcessFlag.Name + "\" en proceso.", Color.Red);
            }
        }

        private void ButtonImport_Click(object sender, EventArgs e)
        {
            if (!ProcessFlag.Enable)
            {
                AddControl(new ImportRelation(BusinessLogic, this));
            }
            else
            {
                MessageText("No puede ejecutar otro proceso. Operación \"" + ProcessFlag.Name + "\" en proceso.", Color.Red);
            }
        }

        private void ButtonLoadFiles_Click(object sender, EventArgs e)
        {
            if (!ProcessFlag.Enable)
            {
                AddControl(new LoadFiles(BusinessLogic, this));
            }
            else
            {
                MessageText("No puede ejecutar otro proceso. Operación \"" + ProcessFlag.Name + "\" en proceso.", Color.Red);
            }
        }

        private void ButtonReissues_Click(object sender, EventArgs e)
        {
            if (!ProcessFlag.Enable)
            {
                AddControl(new LoadIssues(BusinessLogic, this));
            }
            else
            {
                MessageText("No puede ejecutar otro proceso. Operación \"" + ProcessFlag.Name + "\" en proceso.", Color.Red);
            }
        }

        private void ButtonGenerateReports_Click(object sender, EventArgs e)
        {
            if (!ProcessFlag.Enable)
            {
                AddControl(new CreateReports(BusinessLogic, this));
            }
            else
            {
                MessageText("No puede ejecutar otro proceso. Operación \"" + ProcessFlag.Name + "\" en proceso.", Color.Red);
            }
        }

        private void ButtonExportClient_Click(object sender, EventArgs e)
        {
            if (!ProcessFlag.Enable)
            {
                AddControl(new ExportClient(BusinessLogic, this));
            }
            else
            {
                MessageText("No puede ejecutar otro proceso. Operación \"" + ProcessFlag.Name + "\" en proceso.", Color.Red);
            }
        }

        private void ButtonLoadToSystem_Click(object sender, EventArgs e)
        {
            if (!ProcessFlag.Enable)
            {
                AddControl(new CreateLoadFolder(BusinessLogic, this));
            }
            else
            {
                MessageText("No puede ejecutar otro proceso. Operación \"" + ProcessFlag.Name + "\" en proceso.", Color.Red);
            }
        }

        private void ButtonStats_Click(object sender, EventArgs e)
        {
            if (!ProcessFlag.Enable)
            {
                AddControl(new Stats(BusinessLogic, this));
            }
            else
            {
                MessageText("No puede ejecutar otro proceso. Operación \"" + ProcessFlag.Name + "\" en proceso.", Color.Red);
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            if (!ProcessFlag.Enable)
            {
                if (BusinessLogic != null)
                    BusinessLogic.Dispose();
                this.Dispose();
                Application.Exit();
            }
            else
            {
                MessageText("No puede salir de la aplicación. Operación \"" + ProcessFlag.Name + "\" en proceso.", Color.Red);
            }
        }

        #endregion

        #region TextBox Methods

        public void MessageText(string Text)
        {
            RichTextBoxDebug.AppendText(Text + "\n");
            RichTextBoxDebug.ScrollToCaret();
        }

        public void MessageText(string Text, Color Color)
        {
            Color TempColor = RichTextBoxDebug.ForeColor;
            RichTextBoxDebug.SelectionColor = Color;
            RichTextBoxDebug.AppendText(Text + "\n");
            RichTextBoxDebug.SelectionColor = TempColor;
            RichTextBoxDebug.ScrollToCaret();
        }

        public void MessageText(string[] Text)
        {
            foreach (var item in Text)
                RichTextBoxDebug.AppendText(item + "\n");

            RichTextBoxDebug.ScrollToCaret();
        }

        public void MessageText(string[] Text, Color Color)
        {
            Color TempColor = RichTextBoxDebug.ForeColor;
            RichTextBoxDebug.SelectionColor = Color;
            foreach (var item in Text)
                RichTextBoxDebug.AppendText(item + "\n");
            RichTextBoxDebug.SelectionColor = TempColor;
            RichTextBoxDebug.ScrollToCaret();
        }

        public void ClearTextBoxDebug()
        {
            RichTextBoxDebug.Clear();
        }

        #endregion

        private void AddControl(Control control)
        {
            PanelContainer.Controls.Clear();
            PanelContainer.Controls.Add(control);
        }

        public void EnableAllButtons()
        {
            ButtonCreateConfig.Enabled = true;
            ButtonExportClient.Enabled = true;
            ButtonGenerateReports.Enabled = true;
            ButtonImport.Enabled = true;
            ButtonLoadFiles.Enabled = true;
            ButtonLoadToSystem.Enabled = true;
            ButtonReissues.Enabled = true;
            ButtonStats.Enabled = true;

            if (!BusinessLogic.AppConfigObtained)
            {
                ButtonExportClient.Enabled = false;
                ButtonGenerateReports.Enabled = false;
                ButtonImport.Enabled = false;
                ButtonLoadFiles.Enabled = false;
                ButtonLoadToSystem.Enabled = false;
                ButtonReissues.Enabled = false;
                ButtonStats.Enabled = false;
            }
        }

        public void DisableAllButtons()
        {
            ButtonCreateConfig.Enabled = false;
            ButtonExportClient.Enabled = false;
            ButtonGenerateReports.Enabled = false;
            ButtonImport.Enabled = false;
            ButtonLoadFiles.Enabled = false;
            ButtonLoadToSystem.Enabled = false;
            ButtonReissues.Enabled = false;
            ButtonStats.Enabled = false;
        }

        public void LookExceptionFlag()
        {
            if (ExceptionFlag.ExceptionObtained)
            {
                MessageBox.Show("Has obtenido un error importante durante el proceso que realizabas. Revise el cuadro de alertas.");
                MessageText(ExceptionFlag.ClassException, Color.Red);
                MessageText(ExceptionFlag.MethodException, Color.Red);
                MessageText(ExceptionFlag.Exception, Color.Red);
                MessageText(ExceptionFlag.InnerException, Color.Red);
                MessageText(ExceptionFlag.StackTrace, Color.Red);
                MessageText("\n\nContacte con soporte inmediatamente.", Color.Red);
            }
        }
    }
}
