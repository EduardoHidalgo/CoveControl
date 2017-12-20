using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Data;
using System.Linq;
using System.Reflection;

namespace MasterCoveControl
{
    public sealed class BusinessLogic : IDisposable
    {
        private MainForm MainForm;
        private Config.AppConfig AppConfig;

        private const string FolderRoot = @"CONTROL\";
        private const string FolderAño = "Coves - ";
        private const string FolderAcuses = @"ACUSES\";
        private const string FolderDetalles = @"DETALLES\";
        private const string FolderReferencias = @"REFERENCIAS\";
        private const string FolderReportes = @"REPORTES\";

        private const string FileConfig = @"AppConfig.json";
        private const string FilePath = @"\Path.json";

        private const string VarIssues = "CovesMuertos";
        private const string VarReport = "Report";
        private const string VarFullReport = "FullReport";
        private const string VarAcuse = "ACUSE";
        private const string VarDetail = "DETALLE";

        /// <summary>
        /// Flag que sabe si el Archivo de configuración ha sido cargado o no.
        /// </summary>
        public bool AppConfigObtained;

        public ExceptionFlag ExceptionFlag { get; set; }

        /// <summary>
        /// Obtiene el archivo de configuración de su ubicación en disco para inicializar los datos guardados.
        /// </summary>
        /// <param name="mainForm"></param>
        public BusinessLogic(MainForm mainForm)
        {
            MainForm = mainForm;
            AppConfig = new Config.AppConfig();
            AppConfigObtained = false;

            ExceptionFlag = new ExceptionFlag();

            #region InitialMessages

            MainForm.MessageText("BIENVENIDO AL SISTEMA \"CONTROL DE COVES\". Esta aplicación te permite llevar un control " +
            "de la relación de detalles y acuses descargados contra las relaciones de referencias que se proporcionen.\n");

            MainForm.MessageText("Presione \"Crear Nueva Configuración General\"", Color.Green);
            MainForm.MessageText("para comenzar a operar la aplicación por primera vez.");
            MainForm.MessageText("Presione \"Importar Relación Excel\"", Color.Green);
            MainForm.MessageText("para añadir un nuevo archivo excel que contenga una lista de referencias.");
            MainForm.MessageText("Presione \"Cargar Acuses y Detalles\" ", Color.Green);
            MainForm.MessageText("para cargar los documentos en la ubicación de la configuración.");
            MainForm.MessageText("Presione \"Cargar Coves Muertos\" ", Color.Green);
            MainForm.MessageText("para verificar y registrar las existencias de Documentos y Actualizar la configuración.");
            MainForm.MessageText("Presione \"Generar Reportes\" ", Color.Green);
            MainForm.MessageText("para generar los reportes.");
            MainForm.MessageText("Presione \"Exportar Cliente\" ", Color.Green);
            MainForm.MessageText("para generar un reporte detallado de un único cliente.");
            MainForm.MessageText("Presione \"Crear Carpeta de Carga\" ", Color.Green);
            MainForm.MessageText("para generar carpetas ordenadas para subir a la Intranet.");
            MainForm.MessageText("Presione \"Ver Estadísticas\" ", Color.Green);
            MainForm.MessageText("para ver en tiempo real datos estadísticos sobre el avance de la configuración.");

            MainForm.MessageText("\n-------------------------------------------------------------------------------------------" +
                "--------------------------------------------------------------------------------------------------------------" +
                "------------------------\n\n\n\n\n");

            #endregion

            RetrieveAppConfig();

            if (AppConfigObtained)
                MessageText("Archivo de Configuración obtenido Exitosamente.\n", Color.Green);
            else
                MessageText("No existe ningún archivo de configuración generado. Genere uno para comenzar a operar el sistema.\n", Color.Brown);
        }

        // REGIONES NUEVAS //--------

        //Métodos del Constructor
        #region Configuration Methods              
        /// <summary>
        /// Obtiene un archivo Path.json que contiene la ubicación del archivo config.
        /// </summary>
        /// <returns>Retorna el string de la ubicación del archivo config</returns>
        private string RetrievePath()
        {
            try
            {
                if (File.Exists(System.IO.Directory.GetCurrentDirectory() + FilePath))
                    using (FileManager FileManager = new FileManager(MainForm))
                        return (string)FileManager.OpenJson(new object(), System.IO.Directory.GetCurrentDirectory(), FilePath);
                else
                    return null;
            }
            catch (Exception e)
            {
                CreateLog(e, GetType().Name, MethodBase.GetCurrentMethod().Name);
                return null;
            }
        }

        /// <summary>
        /// Obtiene el archivo .json de la configuración almacenado en disco.
        /// </summary>
        private void RetrieveAppConfig()
        {
            string Path = RetrievePath();

            //Si no es nulo la obtención de la ubicación del archivo de configuración
            if (!string.IsNullOrEmpty(Path))
                using (FileManager FileManager = new FileManager(MainForm))
                {
                    AppConfig = (Config.AppConfig)FileManager.OpenJson(AppConfig, Path, FileConfig);

                    if (AppConfig != null)
                        AppConfigObtained = true;
                }
            else
                AppConfigObtained = false;
        }

        /// <summary>
        /// Guarda la ubicación del archivo de configuración en un archivo de tipo .json .
        /// </summary>
        private void SavePath(string path)
        {
            try
            {
                //Guarda el archivo de configuración
                using (FileManager FileManager = new FileManager(MainForm))
                    FileManager.SaveJson(AppConfig, AppConfig.Root, FileConfig);

                //Guarda el archivo de ubicación
                using (FileManager FileManager = new FileManager(MainForm))
                    FileManager.SaveJson(AppConfig.Root, System.IO.Directory.GetCurrentDirectory(), FilePath);
            }
            catch (Exception e)
            {
                CreateLog(e, GetType().Name, MethodBase.GetCurrentMethod().Name);
            }
        }

        private void SaveEmptyPath(string path)
        {
            try
            {
                //Guarda el archivo de ubicación
                using (FileManager FileManager = new FileManager(MainForm))
                    FileManager.SaveJson(path, System.IO.Directory.GetCurrentDirectory(), FilePath);
            }
            catch (Exception e)
            {
                CreateLog(e, GetType().Name, MethodBase.GetCurrentMethod().Name);
            }
        }

        /// <summary>
        /// Guarda el objeto de configuración en un archivo de tipo .json .
        /// </summary>
        private void SaveConfig()
        {
            try
            {
                //Guarda el archivo de configuración
                using (FileManager FileManager = new FileManager(MainForm))
                    FileManager.SaveJson(AppConfig, AppConfig.Root, FileConfig);
            }
            catch (Exception e)
            {
                CreateLog(e, GetType().Name, MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        //Métodos comunes
        #region Common Methods      
        /// <summary>
        /// Genera un mensaje de texto dentro del panel RichTextBox del MainForm
        /// </summary>
        /// <param name="text">Mensaje a mostrar</param>
        /// <param name="color">color del mensaje</param>
        private void MessageText(string text, Color color) => MainForm.MessageText(text, color);

        /// <summary>
        /// Crea un archivo Log con un mensaje de error
        /// </summary>
        /// <param name="ex">Data de la Excepción</param>
        /// <param name="className">Nombre de la clase</param>
        /// <param name="methodName">Nombre del método</param>
        private void CreateLog(Exception ex, string className, string methodName)
        {
            using (FileManager FileManager = new FileManager(MainForm))
            {
                ExceptionFlag = FileManager.CreateLog(ex, className, methodName);
            }
        }

        /// <summary>
        /// Crea un FolderBrowserDialog para buscar una ubicación, permite usar una descripción del proceso.
        /// </summary>
        /// <param name="description">Descripción del proceso</param>
        /// <returns></returns>
        private string GetRoot(string description)
        {
            using (FolderBrowserDialog FolderBrowserDialog = new FolderBrowserDialog())
            {
                FolderBrowserDialog.Description = description;
                DialogResult result = FolderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(FolderBrowserDialog.SelectedPath))
                    return FolderBrowserDialog.SelectedPath + @"\";
                else
                    return null;
            }
        }

        /// <summary>
        /// Crea un Cuadro de diálogo para verificar el proceso de eliminar la configuración previa y crear una nueva
        /// </summary>
        /// <param name="questionText">Información del diálogo</param>
        /// <param name="title">Título del diálogo</param>
        /// <returns></returns>
        private bool MessageBoxYesNo(string questionText, string title)
        {
            if (MessageBox.Show(questionText, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Crea un Folder
        /// </summary>
        /// <param name="path"></param>
        private void CreateFolder(string path)
        {
            System.IO.Directory.CreateDirectory(path);
        }

        /// <summary>
        /// Obtiene la ubicación de un archivo tipo excel.
        /// </summary>
        /// <returns></returns>
        private string GetExcelRoot()
        {
            using (OpenFileDialog OpenFileDialog = new OpenFileDialog())
            {
                //Configuración del OpenFileDialog
                OpenFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                OpenFileDialog.Multiselect = false;
                OpenFileDialog.ValidateNames = true;
                OpenFileDialog.DereferenceLinks = false; // Will return .lnk in shortcuts.
                OpenFileDialog.Filter = "All Files (*.*)|*.*";

                DialogResult result = OpenFileDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    //string ext = Path.GetExtension(OpenFileDialog.SafeFileName);
                    return OpenFileDialog.FileName;// + ext;
                }
                else
                    return null;
            }
        }

        /// <summary>
        /// Genera un conjunto de Folders que corresponden con la relación que se añade a la configuración
        /// </summary>
        /// <param name="excelRoot"></param>
        /// <returns></returns>
        private Folders GenerateFolders(string excelRoot)
        {
            //Se calculan todos los strings que conforman los nombres de los folders relacionados con esa relación excel
            string year = ExtractNumber(Path.GetFileNameWithoutExtension(excelRoot));
            string folderYear = AppConfig.Root + FolderAño + year + @"\";
            string folderReference = folderYear + FolderReferencias;
            string folderAcuse = folderYear + FolderAcuses;
            string folderDetalle = folderYear + FolderDetalles;

            CreateFolder(folderYear);
            CreateFolder(folderReference);
            CreateFolder(folderAcuse);
            CreateFolder(folderDetalle);

            return new Folders(year, folderYear, folderReference, folderAcuse, folderDetalle);
        }

        /// <summary>
        /// Extrae el valor numérico contenido dentro de una variable string
        /// </summary>
        /// <param name="original">variable para su extracción</param>
        /// <returns></returns>
        private string ExtractNumber(string original)
        {
            return new string(original.Where(c => Char.IsDigit(c)).ToArray());
        }

        /// <summary>
        /// Copia un archivo de su ubicación original a las rutas de la relación
        /// </summary>
        /// <param name="source">Fuente del archivo</param>
        /// <param name="destine">Destino del archivo</param>
        private void CopyFile(string source, string destine)
        {
            if (File.Exists(source))
            {
                if (!File.Exists(destine))
                    File.Copy(source, destine, false); //fuente a destino
                else //Si ya existe el archivo en el destino, lo elimina y vuelve a copiar
                {
                    File.Delete(destine);
                    File.Copy(source, destine, false); //fuente a destino
                }
            }
        }

        /// <summary>
        /// Actualiza la configuración de la relación. Obtiene los datos no repetidos de la relación.
        /// </summary>
        /// <param name="relation">relación a actualizar.</param>
        private void Scrubbler(ReferenceRelation relation)
        {
            for (int i = 0; i < relation.References.Count; i++)
            {
                relation.Configuration.ReferenceDuplicated.Add(relation.References[i].IdReference);
                relation.Configuration.CoveDuplicated.Add(relation.References[i].Edocum);
            }

            //Separa los datos no duplicados de coves
            for (int i = 0; i < relation.Configuration.CoveDuplicated.Count - 1; i++)
                if (!relation.Configuration.CoveSingle.Contains(relation.Configuration.CoveDuplicated[i]))
                    relation.Configuration.CoveSingle.Add(relation.Configuration.CoveDuplicated[i]);

            //Separa los datos no duplicados de referencias
            for (int i = 0; i < relation.Configuration.ReferenceDuplicated.Count - 1; i++)
                if (!relation.Configuration.ReferenceSingle.Contains(relation.Configuration.ReferenceDuplicated[i]))
                    relation.Configuration.ReferenceSingle.Add(relation.Configuration.ReferenceDuplicated[i]);
        }

        private void UpdateConfig(DataTable Table, Folders folders)
        {

            ReferenceRelation Relation = null;
            foreach (ReferenceRelation refrel in AppConfig.ListReferences)
            {
                if (refrel.Folders.FolderYear == folders.Year)
                {
                    Relation = refrel;
                    break;
                }
            }

            if (Relation == null)
            {
                Relation = new ReferenceRelation();
                Relation.Year = folders.Year;
                Relation.Folders = folders;
            }

            foreach (DataRow row in Table.Rows)
            {
                //Obtiene la data del row
                string IdReference = row["REFERENCIA"].ToString();
                IdReference = IdReference.Trim();
                string Pediment = row["PEDIMENTO"].ToString();
                Pediment = Pediment.Trim();
                string PedimentKey = row["CLAVE_PEDIMENTO"].ToString();
                PedimentKey = PedimentKey.Trim();
                string Edocum = row["EDOCUM"].ToString();
                Edocum = Edocum.Trim();
                string Client = row["NOMBRE"].ToString();
                Client = Client.Trim();
                string WithRec = row["CON_REC"].ToString();
                WithRec = WithRec.Trim();

                //Revisa si esa data ya existe dentro de la relación de referencias
                List<Reference> Existences = (Relation.References.Where(e => e.IdReference == IdReference && e.Edocum == Edocum)).ToList();

                if (Existences.Count == 0)
                {
                    Reference reference = new Reference(IdReference, Pediment, PedimentKey, Edocum, Client, WithRec);

                    Relation.Add(reference);

                    //Si el cliente es nuevo, lo agrega a la lista de clientes
                    if (!Relation.Clients.Contains(Client))
                        Relation.Clients.Add(Client);
                }
            }

            AppConfig.ListReferences.Add(Relation);
            Scrubbler(Relation);
            SaveConfig();
        }

        private void CopyAllFiles(string source, string destine)
        {
            foreach (var file in Directory.GetFiles(source))
                File.Copy(file, Path.Combine(destine, Path.GetFileName(file)));
        }

        private void CopyAllFiles(string acuseSource, string detailSource, ProcessLoadFiles.UpdateBarDelegate UpdateBar, ReferenceRelation Relation)
        {
            int Total = Directory.GetFiles(acuseSource).Length + Directory.GetFiles(detailSource).Length;
            int Count = 0;

            foreach (var file in Directory.GetFiles(acuseSource))
            {
                if (!File.Exists(Path.Combine(Relation.Folders.FolderAcuse, Path.GetFileName(file))))
                    File.Copy(file, Path.Combine(Relation.Folders.FolderAcuse, Path.GetFileName(file)));
                Count ++;

                if (Count < Total)
                    UpdateBar(Count, Total);
            }

            foreach (var file in Directory.GetFiles(detailSource))
            {
                if (!File.Exists(Path.Combine(Relation.Folders.FolderDetail, Path.GetFileName(file))))
                    File.Copy(file, Path.Combine(Relation.Folders.FolderDetail, Path.GetFileName(file)));
                Count++;

                if (Count < Total)
                    UpdateBar(Count, Total);
            }

        }
        #endregion

        //Métodos Públicos, expuestos al MainForm
        #region Public Classes      
        /// <summary>
        /// Almacena la lógica para generar un archivo de configuración
        /// </summary>
        public sealed class ProcessCreateConfig : IDisposable
        {
            private BusinessLogic BusinessLogic;

            public bool DeleteConfigFlag { get; set; }

            public string Root { get; set; }

            public ProcessCreateConfig(BusinessLogic businessLogic)
            {
                BusinessLogic = businessLogic;
                DeleteConfigFlag = false;
            }
                
            /// <summary>
            /// Solicita la ubicación raíz donde operará el sistema
            /// </summary>
            public void GetRoot()
            {
                Root = BusinessLogic.GetRoot("Seleccione donde se va a generar la carpeta raíz:");
                if (string.IsNullOrEmpty(Root))
                    BusinessLogic.MainForm.MessageText("No se ha proporcionado ninguna ubicación válida.\n", Color.Red);
            }
            
            /// <summary>
            /// Crea el archivo de configuración a partir de la ubicación dada
            /// </summary>
            public void CreateConfig()
            {
                if (!string.IsNullOrEmpty(Root))
                {
                    if (BusinessLogic.AppConfigObtained)
                    {
                        if (BusinessLogic.MessageBoxYesNo("Ya existe un archivo de configuración, ¿Desea borrar el actual y crear uno nuevo? " +
                            "Esta acción elimina todos los archivos relacionados no podrá deshacerse.", "Crear Archivo de Configuración"))
                        {
                            BusinessLogic.AppConfig = new Config.AppConfig();
                            BusinessLogic.AppConfig.Root = Root + BusinessLogic.FolderRoot;

                            System.IO.DirectoryInfo directory = new DirectoryInfo(Root);

                            foreach (FileInfo file in directory.GetFiles())
                                file.Delete();

                            foreach (DirectoryInfo dir in directory.GetDirectories())
                                dir.Delete(true);

                            BusinessLogic.CreateFolder(Root + BusinessLogic.FolderRoot);
                            BusinessLogic.SavePath(BusinessLogic.AppConfig.Root);

                            BusinessLogic.MessageText("Proceso de Creación de Archivo de Configuración Finalizó Exitosamente.", Color.Green);
                        }
                        else
                        {
                            BusinessLogic.MessageText("Proceso de Creación de Archivo de Configuración Abortado.", Color.Black);
                        }
                    }
                    else
                    {
                        BusinessLogic.AppConfig = new Config.AppConfig();
                        BusinessLogic.AppConfig.Root = Root + BusinessLogic.FolderRoot;

                        BusinessLogic.CreateFolder(Root + BusinessLogic.FolderRoot);
                        BusinessLogic.SavePath(BusinessLogic.AppConfig.Root);

                        BusinessLogic.MessageText("Proceso de Creación de Archivo de Configuración Finalizó Exitosamente.", Color.Green);
                    }
                }
                else
                {
                    BusinessLogic.MessageText("No se ha obtenido ninguna ubicación válida. Seleccione una Carpeta Raíz válida", Color.Red);
                }
            }

            /// <summary>
            /// Elimina el archivo de configuración, Path queda con valor Empty
            /// </summary>
            public void DeleteConfig()
            {
                if (BusinessLogic.AppConfigObtained)
                {
                    if (BusinessLogic.MessageBoxYesNo("Ya existe un archivo de configuración, ¿Desea borrar el actual?" +
                        "Esta acción elimina todos los archivos relacionados no podrá deshacerse.", "Eliminar Archivo de Configuración"))
                    {
                        try
                        {
                            System.IO.DirectoryInfo directory = new DirectoryInfo(BusinessLogic.AppConfig.Root);

                            foreach (System.IO.FileInfo file in directory.GetFiles()) file.Delete();
                            foreach (System.IO.DirectoryInfo subDirectory in directory.GetDirectories()) subDirectory.Delete(true);

                            directory.Delete();

                            BusinessLogic.SaveEmptyPath("");
                            BusinessLogic.AppConfig = new Config.AppConfig();

                            DeleteConfigFlag = true;
                        }
                        catch (Exception e)
                        {
                            BusinessLogic.CreateLog(e, GetType().Name, MethodBase.GetCurrentMethod().Name);
                            DeleteConfigFlag = false;
                        }
                    }
                    else
                    {
                        BusinessLogic.MessageText("Proceso de Eliminación de Archivo de Configuración Abortado.", Color.Red);
                    }
                }
                else
                {
                    MessageBox.Show("No existe ningún archivo de configuración.");
                }
            }

            public void Dispose() { }
        }

        /// <summary>
        /// Almacena la lógica para obtener una relación excel y añadirla a la configuración
        /// </summary>
        public sealed class ProcessImportRelation : IDisposable
        {
            private BusinessLogic BusinessLogic;
            private DataTable Table;
            private Folders Folders;

            public delegate void UpdateBarDelegate(int count, int total);
            public event UpdateBarDelegate UpdateProgress;

            public bool LoadExcelFlag;
            public bool UpdateConfigFlag;

            public int ProgressCount { get; set; }

            public string ExcelRoot { get; set; }
            public ReferenceRelation Relation { get; set; }

            public ProcessImportRelation(BusinessLogic businessLogic)
            {
                BusinessLogic = businessLogic;
                LoadExcelFlag = false;
                UpdateConfigFlag = false;
            }

            /// <summary>
            /// Obtiene la ubicación de un archivo excel
            /// </summary>
            /// <returns>retorna verdadero si se obtuvo correctamente la ubicación</returns>
            public bool GetExcel()
            {
                MessageBox.Show("Nota: Si deseas añadir una relación cuyo año ya existe, no perderás los registros, pero la relación anterior será reemplazada.");

                ExcelRoot = BusinessLogic.GetExcelRoot();

                if (string.IsNullOrWhiteSpace(ExcelRoot))
                {
                    BusinessLogic.MainForm.MessageText("No se obtuvo ningún archivo excel.", Color.Red);
                    return false;
                }
                else
                    return true;
            }

            /// <summary>
            /// Crea los folders de la relación. si ya existen los folders, no los reemplaza, pero el archivo de relación existente si es reemplazado.
            /// </summary>
            public void CreateFolders()
            {
                //Obtiene los folders strings asociados al excel obtenido
                Folders = BusinessLogic.GenerateFolders(ExcelRoot);

                //Copia el archivo usado hacia la raíz generada
                BusinessLogic.CopyFile(ExcelRoot, Folders.FolderYear + Path.GetFileName(ExcelRoot));
            }

            /// <summary>
            /// Obtiene un objeto DataTable a partir de la data del archivo excel que se proporcionó.
            /// </summary>
            public void ImportExcel()
            {
                try
                {
                    using (ExcelReader ExcelReader = new ExcelReader(ExcelRoot, this))
                    {
                        Table = ExcelReader.GetExcelFile();
                        if (Table != null && ExcelReader.Exception == null)
                        {
                            Table = ExcelReader.Table;
                            ProgressCount = Table.Rows.Count;
                            LoadExcelFlag = true;
                        }
                        else
                        {
                            Table = null;
                            BusinessLogic.CreateLog(new ArgumentNullException(), GetType().Name, MethodBase.GetCurrentMethod().Name);
                            LoadExcelFlag = false;
                        }
                    }
                }
                catch (Exception e)
                {
                    BusinessLogic.CreateLog(e, GetType().Name, MethodBase.GetCurrentMethod().Name);
                    LoadExcelFlag = false;
                }
            }

            /// <summary>
            /// Actualiza la configuración con la información del DataTable
            /// </summary>
            public void UpdateConfig()
            {
                try
                {
                    Relation = null;
                    foreach (ReferenceRelation refrel in BusinessLogic.AppConfig.ListReferences)
                    {
                        if (refrel.Folders.FolderYear == Folders.Year)
                        {
                            Relation = refrel;
                            break;
                        }
                    }

                    if (Relation == null)
                    {
                        Relation = new ReferenceRelation();
                        Relation.Year = Folders.Year;
                        Relation.Folders = Folders;
                    }

                    int count = 0;
                    foreach (DataRow row in Table.Rows)
                    {
                        count++;
                        UpdateProgressMethod(count, Table.Rows.Count);

                        //Obtiene la data del row
                        string IdReference = row["REFERENCIA"].ToString();
                        IdReference = IdReference.Trim();
                        string Pediment = row["PEDIMENTO"].ToString();
                        Pediment = Pediment.Trim();
                        string PedimentKey = row["CLAVE_PEDIMENTO"].ToString();
                        PedimentKey = PedimentKey.Trim();
                        string Edocum = row["EDOCUM"].ToString();
                        Edocum = Edocum.Trim();
                        string Client = row["NOMBRE"].ToString();
                        Client = Client.Trim();
                        string WithRec = row["CON_REC"].ToString();
                        WithRec = WithRec.Trim();

                        //Revisa si esa data ya existe dentro de la relación de referencias
                        List<Reference> Existences = (Relation.References.Where(e => e.IdReference == IdReference && e.Edocum == Edocum)).ToList();

                        if (Existences.Count == 0)
                        {
                            Reference reference = new Reference(IdReference, Pediment, PedimentKey, Edocum, Client, WithRec);

                            Relation.Add(reference);

                            //Si el cliente es nuevo, lo agrega a la lista de clientes
                            if (!Relation.Clients.Contains(Client))
                                Relation.Clients.Add(Client);
                        }
                    }
                    UpdateConfigFlag = true;
                }
                catch (Exception e)
                {
                    BusinessLogic.CreateLog(e, GetType().Name, MethodBase.GetCurrentMethod().Name);
                    Relation = null;
                    UpdateConfigFlag = false;
                }
            }

            /// <summary>
            /// Realiza el proceso final de Scrubbler y de guardar la configuración
            /// </summary>
            public void Scrubbler()
            {
                if (Relation != null)
                {
                    BusinessLogic.AppConfig.ListReferences.Add(Relation);
                    BusinessLogic.Scrubbler(Relation);
                    BusinessLogic.SaveConfig();
                }
                else
                {
                    UpdateConfigFlag = false;
                }
            }

            public void UpdateProgressMethod(int count, int total)
            {
                UpdateProgress(count, total);
            }

            public void Dispose()
            {

            }
        }

        /// <summary>
        /// Almacena la lógica para cargar Coves al folder y Revisarlos
        /// </summary>
        public sealed class ProcessLoadFiles : IDisposable
        {
            private BusinessLogic BusinessLogic;
            private ReferenceRelation Relation;
            private Folders Folders;

            public delegate void UpdateBarDelegate(int count, int total);
            public event UpdateBarDelegate UpdateProgress;

            public bool CopyFilesFlag { get; set; }
            public bool CheckFilesFlag { get; set; }

            public ProcessLoadFiles(BusinessLogic businessLogic)
            {
                BusinessLogic = businessLogic;
                CopyFilesFlag = false;
                CheckFilesFlag = false;
            }

            public List<int> GetListYears()
            {
                List<int> Years = new List<int>();
                foreach (ReferenceRelation relations in BusinessLogic.AppConfig.ListReferences)
                    Years.Add(Convert.ToInt32(relations.Year));

                return Years;
            }

            public bool SearchYear(string year)
            {
                bool exists = false;
                foreach (ReferenceRelation relations in BusinessLogic.AppConfig.ListReferences)
                    if (relations.Year == year)
                        exists = true;
                return exists;
            }

            public string GetFolder(string description)
            {
                return BusinessLogic.GetRoot(description);
            }

            public void CopyFiles(string Acuses, string Detalles, string Year)
            {
                try
                {
                    Relation = null;
                    foreach (ReferenceRelation refrel in BusinessLogic.AppConfig.ListReferences)
                    {
                        if (refrel.Year == Convert.ToString(Year))
                        {
                            Relation = refrel;
                            break;
                        }
                    }

                    if (Relation != null)
                    {
                        BusinessLogic.CopyAllFiles(Acuses, Detalles, UpdateProgress, Relation);
                        CopyFilesFlag = true;
                    }
                    else
                        CopyFilesFlag = false;
                }
                catch (Exception e)
                {
                    BusinessLogic.CreateLog(e, GetType().Name, MethodBase.GetCurrentMethod().Name);
                    CopyFilesFlag = false;
                }
            }

            public void CheckFiles(int Year)
            {
                try
                {
                    ReferenceRelation relation = null;
                    foreach (ReferenceRelation refrel in BusinessLogic.AppConfig.ListReferences)
                    {
                        if (refrel.Year == Convert.ToString(Year))
                        {
                            relation = refrel;
                            break;
                        }
                    }

                    if (relation != null)
                    {
                        string acuseFile = "";
                        string detailFile = "";

                        int Count = 0;

                        while (relation.References.Count > Count)
                        {
                            if (relation.References[Count].StateGeneral == States.Empty || relation.References[Count].StateGeneral == States.Incomplete)
                            {
                                acuseFile = relation.Folders.FolderAcuse + relation.References[Count].Edocum + ".pdf";
                                detailFile = relation.Folders.FolderDetail + relation.References[Count].Edocum + ".pdf";

                                if (File.Exists(acuseFile))
                                {
                                    //Crea la carpeta de referencia, copia el archivo, y actualiza el estado
                                    string folderReference = relation.Folders.FolderReference + relation.References[Count].IdReference + @"\";
                                    BusinessLogic.CreateFolder(folderReference);
                                    BusinessLogic.CopyFile(acuseFile, folderReference + relation.References[Count].IdReference + " acuse " + relation.References[Count].Edocum + ".pdf");
                                    relation.References[Count].StateAcuse = States.Complete;
                                }
                                else
                                {
                                    relation.References[Count].StateAcuse = States.Incomplete;
                                }

                                if (File.Exists(detailFile))
                                {
                                    //Crea la carpeta de referencia, copia el archivo, y actualiza el estado
                                    string folderReference = relation.Folders.FolderReference + relation.References[Count].IdReference + @"\";
                                    BusinessLogic.CreateFolder(folderReference);
                                    BusinessLogic.CopyFile(detailFile, folderReference + relation.References[Count].IdReference + " detalle " + relation.References[Count].Edocum + ".pdf");
                                    relation.References[Count].StateDetail = States.Complete;
                                }
                                else
                                {
                                    relation.References[Count].StateDetail = States.Incomplete;
                                }

                                if (relation.References[Count].StateAcuse == States.Complete && relation.References[Count].StateDetail == States.Complete)
                                {
                                    relation.References[Count].StateGeneral = States.Complete;
                                    relation.Configuration.CoveDuplicated[Count] = string.Empty;
                                    relation.Configuration.ReferenceDuplicated[Count] = string.Empty;

                                    //Si no contiene mas coves como ese, lo remueve de la list de únicos
                                    if (!relation.Configuration.CoveSingle.Contains(relation.References[Count].Edocum))
                                        relation.Configuration.CoveSingle.Remove(relation.References[Count].Edocum);

                                    //Si no contiene mas referencias como esa, lo remueve de la list de únicos
                                    if (!relation.Configuration.ReferenceSingle.Contains(relation.References[Count].IdReference))
                                        relation.Configuration.ReferenceSingle.Remove(relation.References[Count].IdReference);
                                }
                                else
                                {
                                    relation.References[Count].StateGeneral = States.Incomplete;
                                }
                            }

                            Count++;
                            if (Count < relation.References.Count)
                                UpdateProgress(Count, relation.References.Count);
                            else
                            {

                            }
                        }
                    }
                    BusinessLogic.SaveConfig();
                    CheckFilesFlag = true;
                }
                catch (Exception e)
                {
                    BusinessLogic.CreateLog(e, GetType().Name, MethodBase.GetCurrentMethod().Name);
                    CheckFilesFlag = false;
                }
            }

            public void Dispose() { }
        }

        /// <summary>
        /// Almacena la lógica para cargar Cover Muertos a la configuración
        /// </summary>
        public sealed class ProcessLoadIssues
        {
            private BusinessLogic BusinessLogic;
            private DataTable Table;

            public delegate void UpdateBarDelegate(int count, int total);
            public event UpdateBarDelegate UpdateProgress;

            public bool LoadIssuesFlag { get; set; }

            public string ExcelRoot { get; set; }

            public ProcessLoadIssues(BusinessLogic businessLogic)
            {
                BusinessLogic = businessLogic;
            }

            public List<int> GetListYears()
            {
                List<int> Years = new List<int>();
                foreach (ReferenceRelation relations in BusinessLogic.AppConfig.ListReferences)
                    Years.Add(Convert.ToInt32(relations.Year));

                return Years;
            }

            /// <summary>
            /// Obtiene la ubicación de un archivo excel
            /// </summary>
            /// <returns>retorna verdadero si se obtuvo correctamente la ubicación</returns>
            public bool GetExcel()
            {
                ExcelRoot = BusinessLogic.GetExcelRoot();

                if (string.IsNullOrWhiteSpace(ExcelRoot))
                {
                    BusinessLogic.MainForm.MessageText("No se obtuvo ningún archivo excel.", Color.Red);
                    return false;
                }
                else
                    return true;
            }

            /// <summary>
            /// Obtiene un objeto DataTable a partir de la data del archivo excel que se proporcionó.
            /// </summary>
            public void ImportExcel()
            {
                try
                {
                    using (ExcelReader ExcelReader = new ExcelReader(ExcelRoot, this))
                    {
                        Table = ExcelReader.GetExcelFile();
                        if (Table != null && ExcelReader.Exception == null)
                        {
                            Table = ExcelReader.Table;
                            LoadIssuesFlag = true;
                        }
                        else
                        {
                            Table = null;
                            BusinessLogic.CreateLog(new ArgumentNullException(), GetType().Name, MethodBase.GetCurrentMethod().Name);
                            LoadIssuesFlag = false;
                        }
                    }
                }
                catch (Exception e)
                {
                    BusinessLogic.CreateLog(e, GetType().Name, MethodBase.GetCurrentMethod().Name);
                    LoadIssuesFlag = false;
                }
            }

            /// <summary>
            /// Agrega la data obtenida del Excel de Coves Muertos a la configuración
            /// </summary>
            /// <param name="year"></param>
            public void LoadIssues(string year)
            {
                try
                {
                    ReferenceRelation relation = null;
                    foreach (ReferenceRelation refrel in BusinessLogic.AppConfig.ListReferences)
                    {
                        if (refrel.Folders.FolderYear.Contains(year))
                        {
                            relation = refrel;
                        }
                    }

                    if (relation != null)
                    {
                        List<string> DeadCoves = new List<string>();

                        foreach (DataRow row in Table.Rows)
                        {
                            DeadCoves.Add(row["Reissues"].ToString());
                        }

                        foreach (var reference in relation.References)
                        {
                            if (DeadCoves.Contains(reference.Edocum))
                            {
                                reference.StateGeneral = States.Wrong;
                                reference.StateDetail = States.Wrong;
                                reference.StateAcuse = States.Wrong;
                            }
                        }

                        BusinessLogic.SaveConfig();
                        MessageBox.Show("Coves Muertos Cargados Exitosamente.\n");
                    }
                    else
                    {
                        BusinessLogic.MainForm.MessageText("Error. El Año no ha coincidido con ninguna relación existente.\n", Color.Red);
                    }
                }
                catch (Exception e)
                {
                    BusinessLogic.CreateLog(e, GetType().Name, MethodBase.GetCurrentMethod().Name);
                }
            }

            public void UpdateProgressMethod(int count, int total)
            {
                UpdateProgress(count, total);
            }
        }

        /// <summary>
        /// Almacena la lógica para generar los reportes de la configuración
        /// </summary>
        public sealed class ProcessCreateReports : IDisposable
        {
            private BusinessLogic BusinessLogic;
            public bool CreateReportsFlag { get; set; }

            public ProcessCreateReports(BusinessLogic businessLogic)
            {
                BusinessLogic = businessLogic;
                CreateReportsFlag = false;
            }

            public List<int> GetListYears()
            {
                List<int> Years = new List<int>();
                foreach (ReferenceRelation relations in BusinessLogic.AppConfig.ListReferences)
                    Years.Add(Convert.ToInt32(relations.Year));

                return Years;
            }

            public void CreateReports(string year)
            {
                try
                {
                    ReferenceRelation Relation = null;
                    foreach (ReferenceRelation refrel in BusinessLogic.AppConfig.ListReferences)
                    {
                        if (refrel.Year == year)
                        {
                            Relation = refrel;
                            break;
                        }
                    }

                    if (Relation != null)
                    {
                        Report report = new Report(Relation.References);
                        string date = DateTime.Now.ToString("yyyyMMddHHmmss");
                        string reportname = VarReport + " - " + year;// + "-" + date;
                        string fullreportname = VarFullReport + " - " + year;// + "-" + date;

                        //Genera un reporte básico
                        DataTable dtreport = ReportToDatatable(report, VarReport + " - " + year);
                        using (ExcelWriter ExcelWriter = new ExcelWriter())
                            ExcelWriter.WriteExcel(dtreport, Relation.Folders.FolderYear + FolderReportes, reportname);

                        //Actualiza y genera un nuevo reporte de coves
                        ListCoves coves = new ListCoves(report, Relation.References);
                        DataTable dtcoves = ListCovesToDatatable(coves, "CoveSingles Updated - " + year);
                        using (ExcelWriter ExcelWriter = new ExcelWriter())
                            ExcelWriter.WriteExcel(dtcoves, Relation.Folders.FolderYear + FolderReportes, "CoveSingles Updated - " + year);

                        //Actualiza y genera un nuevo reporte de referencias
                        ListReferences references = new ListReferences(Relation.Configuration, report);
                        DataTable dtreferences = ListReferencesToDatatable(references, "RefSingle Updated - " + year);
                        using (ExcelWriter ExcelWriter = new ExcelWriter())
                            ExcelWriter.WriteExcel(dtreferences, Relation.Folders.FolderYear + FolderReportes, "RefSingle Updated - " + year);

                        //Genera un reporte completo
                        FullRelationReport fullreport = new FullRelationReport(Relation);
                        DataTable dtFullReport = FullReportToDatatable(fullreport, fullreportname);
                        using (ExcelWriter ExcelWriter = new ExcelWriter())
                            ExcelWriter.WriteExcel(dtFullReport, Relation.Folders.FolderYear + FolderReportes, fullreportname);

                        CreateReportsFlag = true;
                    }
                    else
                        CreateReportsFlag = false;
                }
                catch (Exception e)
                {
                    BusinessLogic.CreateLog(e, GetType().Name, MethodBase.GetCurrentMethod().Name);
                    CreateReportsFlag = false;
                }
            }

            public bool SearchYear(string year)
            {
                bool exists = false;
                foreach (ReferenceRelation relations in BusinessLogic.AppConfig.ListReferences)
                    if (relations.Year == year)
                        exists = true;
                return exists;
            }

            public void Dispose()
            {

            }
        }

        public sealed class ProcessExportClient : IDisposable
        {
            private BusinessLogic BusinessLogic;

            public delegate void UpdateBarDelegate(int count, int total);
            public event UpdateBarDelegate UpdateProgress;

            public bool ExportClientFlag { get; set; }

            public ProcessExportClient(BusinessLogic businessLogic)
            {
                BusinessLogic = businessLogic;
                ExportClientFlag = false;
            }

            public bool SearchYear(string year)
            {
                bool exists = false;
                foreach (ReferenceRelation relations in BusinessLogic.AppConfig.ListReferences)
                    if (relations.Year == year)
                        exists = true;
                return exists;
            }

            public List<int> GetListYears()
            {
                List<int> Years = new List<int>();
                foreach (ReferenceRelation relations in BusinessLogic.AppConfig.ListReferences)
                    Years.Add(Convert.ToInt32(relations.Year));

                return Years;
            }

            public List<string> GetClients(string year)
            {
                List<string> Clients = new List<string>();
                foreach (ReferenceRelation relation in BusinessLogic.AppConfig.ListReferences)
                    if (relation.Year == year)
                        foreach (string client in relation.Clients)
                            if (!Clients.Contains(client))
                                Clients.Add(client);

                return Clients;
            }

            public void ExportClient(string year, string Client)
            {
                try
                {
                    ReferenceRelation relation = null;
                    foreach (ReferenceRelation refrel in BusinessLogic.AppConfig.ListReferences)
                    {
                        if (refrel.Year == year)
                        {
                            relation = refrel;
                            break;
                        }
                    }

                    if (relation != null)
                    {
                        string ClientFolder = relation.Folders.FolderYear + FolderReportes + Client.Substring(0, 20) + @"\";
                        BusinessLogic.CreateFolder(ClientFolder);

                        List<Reference> List = new List<Reference>();

                        int Count = 0;

                        foreach (var reference in relation.References)
                        {
                            if (reference.Client == Client)
                            {
                                string ReferenceFolder = ClientFolder + reference.IdReference + @"\";
                                BusinessLogic.CreateFolder(ReferenceFolder);

                                string acusesource = relation.Folders.FolderAcuse + reference.Edocum + ".pdf";
                                string detailsource = relation.Folders.FolderDetail + reference.Edocum + ".pdf";
                                string acuse = reference.IdReference + " acuse " + reference.Edocum + ".pdf";
                                string detail = reference.IdReference + " detalle " + reference.Edocum + ".pdf";
                                string acusedestine = ReferenceFolder + acuse;
                                string detaildestine = ReferenceFolder + detail;

                                List.Add(reference);

                                BusinessLogic.CopyFile(acusesource, acusedestine);
                                BusinessLogic.CopyFile(detailsource, detaildestine);
                            }

                            Count++;
                            UpdateProgressMethod(Count, relation.References.Count);
                        }

                        using (ExcelWriter ExcelWriter = new ExcelWriter())
                        {
                            ClientReport ClientReport = new ClientReport(List);
                            DataTable table = ClientReportToDataTable(ClientReport, "REPORTE - " + Client.Substring(0, 20));
                            ExcelWriter.WriteExcel(table, ClientFolder, "REPORTE - " + Client.Substring(0, 20));
                        }

                        ExportClientFlag = true;
                    }
                    else
                        ExportClientFlag = false;
                }
                catch (Exception e)
                {
                    BusinessLogic.CreateLog(e, GetType().Name, MethodBase.GetCurrentMethod().Name);
                    ExportClientFlag = false;
                }           
            }

            public void UpdateProgressMethod(int count, int total)
            {
                UpdateProgress(count, total);
            }

            public void Dispose()
            {

            }
        }

        public sealed class ProcessCreateLoadFolder
        {
            private BusinessLogic BusinessLogic;

            public bool LoadFolderFlag { get; set; }

            private ReferenceRelation Relation;

            public List<int> GetListYears()
            {
                List<int> Years = new List<int>();
                foreach (ReferenceRelation relations in BusinessLogic.AppConfig.ListReferences)
                    Years.Add(Convert.ToInt32(relations.Year));

                return Years;
            }

            public ProcessCreateLoadFolder(BusinessLogic businessLogic)
            {
                BusinessLogic = businessLogic;
                LoadFolderFlag = false;
            }

            public bool SearchYear(string Year)
            {
                Relation = null;
                foreach (ReferenceRelation refrel in BusinessLogic.AppConfig.ListReferences)
                {
                    if (refrel.Year == Year)
                    {
                        Relation = refrel;
                        break;
                    }
                }

                if (Relation != null)
                    return true;
                else
                    return false;
            }

            public void LoadFilesToSystem()
            {
                try
                {
                    string acuseFile = "";
                    string detailFile = "";
                    string folderExport = Relation.Folders.FolderYear + FolderReportes + @"ExportFiles\";

                    BusinessLogic.CreateFolder(folderExport);

                    int Count = 0;
                    int CountMessage = 0;
                    int Monto = 1;

                    const string folderAcuse = @"Acuses\";
                    const string folderDetail = @"Detalles\";
                    const string MontoString = "Monto - ";
                    string folderMonto = MontoString + Monto.ToString() + @"\";
                    BusinessLogic.CreateFolder(folderExport + folderMonto);
                    BusinessLogic.CreateFolder(folderExport + folderMonto + folderAcuse);
                    BusinessLogic.CreateFolder(folderExport + folderMonto + folderDetail);

                    while (Relation.References.Count > Count)
                    {
                        if (CountMessage == 100)
                        {
                            CountMessage = 0;
                            Monto++;
                            folderMonto = MontoString + Monto.ToString() + @"\";
                            BusinessLogic.CreateFolder(folderExport + folderMonto);
                            BusinessLogic.CreateFolder(folderExport + folderMonto + folderAcuse);
                            BusinessLogic.CreateFolder(folderExport + folderMonto + folderDetail);
                        }

                        if (Relation.References[Count].StateGeneral == States.Complete)
                        {
                            acuseFile = Relation.Folders.FolderAcuse + Relation.References[Count].IdReference + " acuse " + Relation.References[Count].Edocum + ".pdf";
                            detailFile = Relation.Folders.FolderDetail + Relation.References[Count].IdReference + " detalle " + Relation.References[Count].Edocum + ".pdf";

                            if (File.Exists(acuseFile) && File.Exists(detailFile))
                            {
                                BusinessLogic.CopyFile(acuseFile, folderExport + folderMonto + folderAcuse + Relation.References[Count].IdReference + " acuse " + Relation.References[Count].Edocum + ".pdf");
                                BusinessLogic.CopyFile(detailFile, folderExport + folderMonto + folderDetail + Relation.References[Count].IdReference + " detalle " + Relation.References[Count].Edocum + ".pdf");
                            }
                        }

                        Count++;
                        CountMessage++;
                    }

                    LoadFolderFlag = true;
                }
                catch (Exception e)
                {
                    BusinessLogic.CreateLog(e, GetType().Name, MethodBase.GetCurrentMethod().Name);
                    LoadFolderFlag = false;
                }
            
            }

        }

        /// <summary>
        /// Almacena la lógica para mostrar resultados estadísticos sobre el progreso de la configuración
        /// </summary>
        public sealed class ProcessStats : IDisposable
        {
            private BusinessLogic BusinessLogic;

            public bool GetStatsFlag { get; set; }

            public ProcessStats(BusinessLogic businessLogic)
            {
                BusinessLogic = businessLogic;
                GetStatsFlag = false;
            }

            public List<int> GetListYears()
            {
                List<int> Years = new List<int>();
                foreach (ReferenceRelation relations in BusinessLogic.AppConfig.ListReferences)
                    Years.Add(Convert.ToInt32(relations.Year));

                return Years;
            }

            public List<string> GetClients(string year)
            {
                List<string> Clients = new List<string>();
                foreach (ReferenceRelation relation in BusinessLogic.AppConfig.ListReferences)
                    if (relation.Year == year)
                        foreach (string client in relation.Clients)
                            if (!Clients.Contains(client))
                                Clients.Add(client);

                return Clients;
            }

            public List<string> GetAllClients()
            {
                List<string> Clients = new List<string>();
                foreach (ReferenceRelation relation in BusinessLogic.AppConfig.ListReferences)
                    foreach (string client in relation.Clients)
                        if (!Clients.Contains(client))
                            Clients.Add(client);

                return Clients;
            }

            /// <summary>
            /// Devuelve Todos los años de referencias
            /// </summary>
            public Entities.StatsObject GetStats()
            {
                Entities.StatsObject Stats = new Entities.StatsObject();

                try
                {
                    foreach (ReferenceRelation refrel in BusinessLogic.AppConfig.ListReferences)
                        for (int i = 0; i < refrel.References.Count; i++)
                            Stats.AddStats(refrel.References[i].StateGeneral, refrel.References[i].StateAcuse, refrel.References[i].StateDetail);
                    GetStatsFlag = true;
                }
                catch (Exception e)
                {
                    BusinessLogic.CreateLog(e, GetType().Name, MethodBase.GetCurrentMethod().Name);
                    GetStatsFlag = false;
                }

                return Stats;
            }

            /// <summary>
            /// Devuelve un único año de referencias
            /// </summary>
            /// <param name="Year"></param>
            public Entities.StatsObject GetStats(int Year)
            {
                Entities.StatsObject Stats = new Entities.StatsObject();

                try
                {
                    ReferenceRelation Relation = null;
                    foreach (ReferenceRelation refrel in BusinessLogic.AppConfig.ListReferences)
                    {
                        string temp = Convert.ToString(Year);
                        if (refrel.Year == Convert.ToString(Year))
                        {
                            Relation = refrel;
                            break;
                        }
                    }

                    if (Relation != null)
                    {

                        foreach (Reference Reference in Relation.References)
                            Stats.AddStats(Reference.StateGeneral, Reference.StateAcuse, Reference.StateDetail);

                        GetStatsFlag = true;
                    }
                    else
                        GetStatsFlag = false;
                }
                catch (Exception e)
                {
                    BusinessLogic.CreateLog(e, GetType().Name, MethodBase.GetCurrentMethod().Name);
                    GetStatsFlag = false;
                }

                return Stats;
            }

            /// <summary>
            /// Devuelve todos los registros de todos los años de un único cliente
            /// </summary>
            /// <param name="Client"></param>
            public Entities.StatsObject GetStats(string Client)
            {
                Entities.StatsObject Stats = new Entities.StatsObject();

                try
                {
                    foreach (ReferenceRelation refrel in BusinessLogic.AppConfig.ListReferences)
                                for (int i = 0; i < refrel.References.Count; i++)
                                    if (refrel.References[i].Client == Client)
                                        Stats.AddStats(refrel.References[i].StateGeneral, refrel.References[i].StateAcuse, refrel.References[i].StateDetail);
                }
                catch (Exception e)
                {
                    BusinessLogic.CreateLog(e, GetType().Name, MethodBase.GetCurrentMethod().Name);
                    GetStatsFlag = false;
                }

                return Stats;
            }

            /// <summary>
            /// Devuelve todos los registros de un único año y un único cliente
            /// </summary>
            /// <param name="Year"></param>
            /// <param name="Client"></param>
            public Entities.StatsObject GetStats(int Year, string Client)
            {
                Entities.StatsObject Stats = new Entities.StatsObject();

                try
                {
                    ReferenceRelation Relation = null;
                    foreach (ReferenceRelation refrel in BusinessLogic.AppConfig.ListReferences)
                    {
                        if (refrel.Year == Convert.ToString(Year))
                        {
                            Relation = refrel;
                            break;
                        }
                    }

                    if (Relation != null)
                    {

                        foreach (Reference Reference in Relation.References)
                            if (Reference.Client == Client)
                                Stats.AddStats(Reference.StateGeneral, Reference.StateAcuse, Reference.StateDetail);

                        GetStatsFlag = true;
                    }
                    else
                        GetStatsFlag = false;
                }
                catch (Exception e)
                {
                    BusinessLogic.CreateLog(e, GetType().Name, MethodBase.GetCurrentMethod().Name);
                    GetStatsFlag = false;
                }

                return Stats;
            }

            public void Dispose()
            {

            }
        }

        #endregion

        // REGIONES ANTIGUAS //------


        #region Public Methods

        public bool UpdateConfigProcess()
        {
            CheckerProcess();
            return true;
        }

        public void LoadFilesProcess()
        {
            MainForm.MessageText("----Proceso de Carga de Archivos----\n");
            MainForm.MessageText("Seleccione la carpeta del año al cual correponden los archivos.\n");

            string folderyear = GetRoot(AppConfig.Root, "Selecciona la carpeta del año correspondiente:");

            ReferenceRelation relation = null;
            foreach (ReferenceRelation refrel in AppConfig.ListReferences)
            {
                if (refrel.Folders.FolderYear == folderyear)
                {
                    relation = refrel;
                    break;
                }
            }

            if (relation != null)
            {
                MainForm.MessageText("Seleccione la carpeta de ACUSES a cargar.\n");
                string foldernewacuses = GetRoot("Seleccione  la carpeta de ACUSES a cargar:");

                MainForm.MessageText("Seleccione la carpeta de DETALLES a cargar.\n");
                string foldernewdetails = GetRoot("Seleccione  la carpeta de DETALLES a cargar:");

                MainForm.MessageText("Copiando archivos... espere un momento.\n");

                CopyAllFiles(foldernewacuses, relation.Folders.FolderAcuse);
                CopyAllFiles(foldernewdetails, relation.Folders.FolderDetail);

                MainForm.MessageText("Archivos copiados exitosamente.\n");
            }
            else
            {
                MainForm.MessageText("Error. Folder de Año no ha coincidido con ninguna relación existente.\n", Color.Red);
            }


        }

        public void CheckerProcess()
        {
            int Year = 0;
            string AfterYear = "";
            string BeforeYear = "";

            MainForm.MessageText("----Proceso de Verificación de los Acuses y Detalles----\n");
            MainForm.MessageText("Seleccione la carpeta del año al cual correponden los archivos.\n");

            string folderyear = GetRoot(AppConfig.Root, "Selecciona la carpeta del año correspondiente:");

            ReferenceRelation relation = null;
            foreach (ReferenceRelation refrel in AppConfig.ListReferences)
            {
                if (refrel.Folders.FolderYear == folderyear)
                {
                    relation = refrel;
                    Year = Convert.ToInt32(refrel.Year);
                    AfterYear = Convert.ToString(Year + 1);
                    BeforeYear = Convert.ToString(Year - 1);
                    break;
                }
            }

            if (relation != null)
            {
                MainForm.MessageText("Realizando el Checker de la Carpeta Principal... esto puede tardar unos momentos. \n");

                Checker(relation);
                SaveConfig();

                MainForm.MessageText("Checador finalizado. \n");


                #region ChecarAñosContiguos

                //Checando año Anterior
                Folders Folder = relation.Folders;
                foreach (ReferenceRelation refrel in AppConfig.ListReferences)
                {
                    if (refrel.Year == BeforeYear)
                    {
                        Folder = refrel.Folders;
                        break;
                    }
                }

                if (Folder.Year == BeforeYear)
                {
                    MainForm.MessageText("Realizando el Checker de un año anterior para buscar concidencias de documentos... esto puede tardar unos momentos. \n");

                    CheckerOtherFolder(relation, Folder);
                    SaveConfig();

                    MainForm.MessageText("Checador finalizado. \n");
                }
                else
                {
                    MainForm.MessageText("No existe la carpeta del año" + BeforeYear + ". Checador del año anterior Abortado.\n");
                }

                //Checando año Siguiente
                Folder = relation.Folders;
                foreach (ReferenceRelation refrel in AppConfig.ListReferences)
                {
                    if (refrel.Year == AfterYear)
                    {
                        Folder = refrel.Folders;
                        break;
                    }
                }

                if (Folder.Year == AfterYear)
                {
                    MainForm.MessageText("Realizando el Checker de un año posterior para buscar concidencias de documentos... esto puede tardar unos momentos. \n");

                    CheckerOtherFolder(relation, Folder);
                    SaveConfig();

                    MainForm.MessageText("Checador finalizado. \n");
                }
                else
                {
                    MainForm.MessageText("No existe la carpeta del año" + AfterYear + ". Checador del año posterior Abortado.\n");
                }

                #endregion

            }
            else
            {
                MainForm.MessageText("Error. Folder de Año no ha coincidido con ninguna relación existente.\n", Color.Red);
            }

        }

        public void LoadIssues()
        {
            DataTable Table;
            string excelRoot = GetExcelRoot();

            string year = ExtractNumber(Path.GetFileNameWithoutExtension(excelRoot));

            using (ExcelReader ExcelReader = new ExcelReader(excelRoot))
            {
                Table = ExcelReader.GetExcelFile();
                if (Table != null && ExcelReader.Exception != null)
                {
                    Table = ExcelReader.Table;

                    MainForm.MessageText("Actualizando la configuración con los Coves Muertos.\n");

                    try
                    {
                        ReferenceRelation relation = null;
                        foreach (ReferenceRelation refrel in AppConfig.ListReferences)
                        {
                            if (refrel.Folders.FolderYear.Contains(year))
                            {
                                relation = refrel;
                            }
                        }

                        if (relation != null)
                        {
                            List<string> DeadCoves = new List<string>();

                            foreach (DataRow row in Table.Rows)
                            {
                                DeadCoves.Add(row["Reissues"].ToString());
                            }

                           // List<string> DeadCoves = Table.AsEnumerable()
                           //.Select(r => r.Field<string>("Reissues"))
                           //.ToList();

                            for (int i = 0; i < relation.References.Count; i++)
                            {
                                if (DeadCoves.Contains(relation.References[i].Edocum))
                                {
                                    relation.References[i].StateGeneral = States.Wrong;
                                    relation.References[i].StateDetail = States.Wrong;
                                    relation.References[i].StateAcuse = States.Wrong;
                                }
                            }

                            SaveConfig();
                            MainForm.MessageText("Coves Muertos Cargados Exitosamente.\n");


                        }
                        else
                        {
                            MainForm.MessageText("Error. Folder de Año no ha coincidido con ninguna relación existente.\n", Color.Red);
                        }
                    }
                    catch (Exception e)
                    {
                        MainForm.MessageText("Error al generar reportes: " + e.Message + "\n" +
                        "Stacktrace: " + e.StackTrace, Color.Red);
                    }
                }
                else
                {
                    MainForm.MessageText("Error. ExcelReader ha fallado: \n" + ExcelReader.Exception.Message, Color.Red);
                }
            }
        }

        public void ReporterProcess()
        {
            MainForm.MessageText("----Generación de Reportes----\n");
            MainForm.MessageText("Se va a generar un reporte por cada carpeta anual del control.\n");

            MainForm.MessageText("----Generando reportes...\n");

            try
            {
                foreach (var referenceRelation in AppConfig.ListReferences)
                {
                    Report report = new Report(referenceRelation.References);
                    string date = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string year = referenceRelation.Year;
                    string reportname = VarReport + " - " + year;// + "-" + date;
                    string fullreportname = VarFullReport + " - " + year;// + "-" + date;

                    //Genera un reporte básico
                    DataTable dtreport = ReportToDatatable(report, VarReport + " - " + year);
                    using (ExcelWriter ExcelWriter = new ExcelWriter())
                        ExcelWriter.WriteExcel(dtreport, referenceRelation.Folders.FolderYear, reportname);

                    //Actualiza y genera un nuevo reporte de coves
                    ListCoves coves = new ListCoves(report, referenceRelation.References);
                    DataTable dtcoves = ListCovesToDatatable(coves, "CoveSingles Updated - " + year);
                    using (ExcelWriter ExcelWriter = new ExcelWriter())
                        ExcelWriter.WriteExcel(dtcoves, referenceRelation.Folders.FolderYear, "CoveSingles Updated - " + year);

                    //Actualiza y genera un nuevo reporte de referencias
                    ListReferences references = new ListReferences(referenceRelation.Configuration, report);
                    DataTable dtreferences = ListReferencesToDatatable(references, "RefSingle Updated - " + year);
                    using (ExcelWriter ExcelWriter = new ExcelWriter())
                        ExcelWriter.WriteExcel(dtreferences, referenceRelation.Folders.FolderYear, "RefSingle Updated - " + year);

                    //Genera un reporte completo
                    FullRelationReport fullreport = new FullRelationReport(referenceRelation);
                    DataTable dtFullReport = FullReportToDatatable(fullreport, fullreportname);
                    using (ExcelWriter ExcelWriter = new ExcelWriter())
                        ExcelWriter.WriteExcel(dtFullReport, referenceRelation.Folders.FolderYear, fullreportname);


                    MainForm.MessageText("Listas Generadas.\n");
                }

                MainForm.MessageText("----Reportes generados exitosamente. \n");
            }
            catch (Exception e)
            {
                MainForm.MessageText("Error al generar reportes: " + e.Message + "\n" +
                    "Stacktrace: " + e.StackTrace, Color.Red);
            }
        }

        public void ExportClientProcess()
        {
            MainForm.MessageText("----Exportar Reporte de Cliente----\n");
            MainForm.MessageText("Seleccione la carpeta del año al cual corresponde el reporte a generar.\n");

            string folderyear = GetRoot(AppConfig.Root, "Selecciona la carpeta del año correspondiente:");

            ReferenceRelation relation = null;
            foreach (ReferenceRelation refrel in AppConfig.ListReferences)
            {
                if (refrel.Folders.FolderYear == folderyear)
                {
                    relation = refrel;
                    break;
                }
            }

            if (relation != null)
            {
                try
                {
                    //MainForm.ListClient = relation.Clients;
                    //MainForm.ExportTrigger();

                    //string Client = MainForm.Client;

                    string ClientFolder = relation.Folders.FolderYear;// + Client + @"\";

                    CreateFolder(ClientFolder);

                    List<Reference> List = new List<Reference>();

                    foreach (var reference in relation.References)
                    {
                        if (reference.Client == "")//Client)
                        {
                            string ReferenceFolder = ClientFolder + reference.IdReference + @"\";
                            CreateFolder(ReferenceFolder);

                            string acusesource = relation.Folders.FolderAcuse + reference.Edocum + ".pdf";
                            string detailsource = relation.Folders.FolderDetail + reference.Edocum + ".pdf";
                            string acuse = reference.IdReference + " acuse " + reference.Edocum + ".pdf";
                            string detail = reference.IdReference + " detalle " + reference.Edocum + ".pdf";
                            string acusedestine = ReferenceFolder + acuse;
                            string detaildestine = ReferenceFolder + detail;

                            List.Add(reference);

                            if (reference.StateGeneral == States.Complete)
                            {
                                if (reference.StateAcuse == States.Complete)
                                    CopyFile(acusesource, acusedestine);
                                if (reference.StateDetail == States.Complete)
                                    CopyFile(detailsource, detaildestine);
                            }
                        }
                    }

                    MainForm.MessageText("Archivos exportados... generando reporte. \n");

                    using (ExcelWriter ExcelWriter = new ExcelWriter())
                    {
                        ClientReport ClientReport = new ClientReport(List);
                        string firstWord = "";//Client.Split(' ').First();
                        DataTable table = ClientReportToDataTable(ClientReport, "REPORTE - " + firstWord);
                        ExcelWriter.WriteExcel(table, ClientFolder, "REPORTE - " + firstWord);
                    }

                    MainForm.MessageText("Exportador de reporte de cliente finalizado. \n");
                }
                catch (Exception e)
                {
                    MainForm.MessageText("Error al importar excel: " + e.Message + "\n" +
                    "Stacktrace: " + e.StackTrace, Color.Red);
                }              
            }
            else
            {
                MainForm.MessageText("Error. Folder de Año no ha coincidido con ninguna relación existente.\n", Color.Red);
            }
        }

        public void LoadFilesToSystemProcess()
        {
            MainForm.MessageText("----Crear carpeta de archivos para la intranet----\n");
            MainForm.MessageText("Seleccione la carpeta del año al cual correponden los archivos.\n");

            string folderyear = GetRoot(AppConfig.Root, "Selecciona la carpeta del año correspondiente:");

            ReferenceRelation relation = null;
            foreach (ReferenceRelation refrel in AppConfig.ListReferences)
            {
                if (refrel.Folders.FolderYear == folderyear)
                {
                    relation = refrel;
                    break;
                }
            }

            if (relation != null)
            {
                MainForm.MessageText("CREANDO LA CARPETA... esto puede tardar unos momentos. \n");

                LoadFilesSystem(relation);

                MainForm.MessageText("Carpeta generada exitosamente. \n");
            }
            else
            {
                MainForm.MessageText("Error. Folder de Año no ha coincidido con ninguna relación existente.\n", Color.Red);
            }
        }

        #endregion

        #region LoadFiles Methods

        private void Checker(ReferenceRelation relation)
        {
            string acuseFile = "";
            string detailFile = "";

            int Count = 0;
            int CountMessage = 0;


            while(relation.References.Count > Count)
            {
                if (CountMessage == 300)
                {
                    CountMessage = 0;
                    MainForm.MessageText("Archivos comparados: " + Count, Color.DarkMagenta);
                }

                if (relation.References[Count].StateGeneral == States.Empty || relation.References[Count].StateGeneral == States.Incomplete)
                {
                    acuseFile = relation.Folders.FolderAcuse + relation.References[Count].Edocum + ".pdf";
                    detailFile = relation.Folders.FolderDetail + relation.References[Count].Edocum + ".pdf";

                    if (File.Exists(acuseFile))
                    {
                        //Crea la carpeta de referencia, copia el archivo, y actualiza el estado
                        string folderReference = relation.Folders.FolderReference + relation.References[Count].IdReference + @"\";
                        CreateFolder(folderReference);
                        CopyFile(acuseFile, folderReference + relation.References[Count].IdReference + " acuse " + relation.References[Count].Edocum + ".pdf");
                        relation.References[Count].StateAcuse = States.Complete;
                    }
                    else
                    {
                        relation.References[Count].StateAcuse = States.Incomplete;
                    }

                    if (File.Exists(detailFile))
                    {
                        //Crea la carpeta de referencia, copia el archivo, y actualiza el estado
                        string folderReference = relation.Folders.FolderReference + relation.References[Count].IdReference + @"\";
                        CreateFolder(folderReference);
                        CopyFile(detailFile, folderReference + relation.References[Count].IdReference + " detalle " + relation.References[Count].Edocum + ".pdf");
                        relation.References[Count].StateDetail = States.Complete;
                    }
                    else
                    {
                        relation.References[Count].StateDetail = States.Incomplete;
                    }

                    if (relation.References[Count].StateAcuse == States.Complete && relation.References[Count].StateDetail == States.Complete)
                    {
                        relation.References[Count].StateGeneral = States.Complete;
                        relation.Configuration.CoveDuplicated[Count] = string.Empty;
                        relation.Configuration.ReferenceDuplicated[Count] = string.Empty;

                        //Si no contiene mas coves como ese, lo remueve de la list de únicos
                        if (!relation.Configuration.CoveSingle.Contains(relation.References[Count].Edocum))
                            relation.Configuration.CoveSingle.Remove(relation.References[Count].Edocum);

                        //Si no contiene mas referencias como esa, lo remueve de la list de únicos
                        if (!relation.Configuration.ReferenceSingle.Contains(relation.References[Count].IdReference))
                            relation.Configuration.ReferenceSingle.Remove(relation.References[Count].IdReference);
                    }
                    else
                    {
                        relation.References[Count].StateGeneral = States.Incomplete;
                    }
                }

                Count++;
                CountMessage++;
            }

            MainForm.MessageText("Archivos comparados en total: " + Count + "\n", Color.DarkMagenta);
        }

        private void CheckerOtherFolder(ReferenceRelation relation, Folders Folder)
        {
            string acuseFile = "";
            string detailFile = "";

            int Count = 0;
            int CountMessage = 0;
            int CountAcuseExistences = 0;
            int CountDetailExistences = 0;


            while (relation.References.Count > Count)
            {
                if (CountMessage == 300)
                {
                    CountMessage = 0;
                    MainForm.MessageText("Archivos comparados: " + Count, Color.DarkMagenta);
                }

                if (relation.References[Count].StateGeneral == States.Empty || relation.References[Count].StateGeneral == States.Incomplete)
                {
                    //Obtiene los archivos de otro folder donde posiblemente obtenga mas archivos.
                    acuseFile = Folder.FolderAcuse + relation.References[Count].Edocum + ".pdf";
                    detailFile = Folder.FolderDetail + relation.References[Count].Edocum + ".pdf";

                    if (File.Exists(acuseFile))
                    {
                        //Crea la carpeta de referencia, copia el archivo, y actualiza el estado
                        string folderReference = relation.Folders.FolderReference + relation.References[Count].IdReference + @"\";
                        CreateFolder(folderReference);
                        CopyFile(acuseFile, folderReference + relation.References[Count].IdReference + " acuse " + relation.References[Count].Edocum + ".pdf");
                        relation.References[Count].StateAcuse = States.Complete;
                        CountAcuseExistences++;
                    }
                    else
                    {
                        relation.References[Count].StateAcuse = States.Incomplete;
                    }

                    if (File.Exists(detailFile))
                    {
                        //Crea la carpeta de referencia, copia el archivo, y actualiza el estado
                        string folderReference = relation.Folders.FolderReference + relation.References[Count].IdReference + @"\";
                        CreateFolder(folderReference);
                        CopyFile(detailFile, folderReference + relation.References[Count].IdReference + " detalle " + relation.References[Count].Edocum + ".pdf");
                        relation.References[Count].StateDetail = States.Complete;
                        CountDetailExistences++;
                    }
                    else
                    {
                        relation.References[Count].StateDetail = States.Incomplete;
                    }

                    //Si ambos estados tienen el estado "Completo" entonces el estado general es "Completo" y se debe actualizar la configuración.
                    if (relation.References[Count].StateAcuse == States.Complete && relation.References[Count].StateDetail == States.Complete)
                    {
                        relation.References[Count].StateGeneral = States.Complete;
                        relation.Configuration.CoveDuplicated[Count] = string.Empty;
                        relation.Configuration.ReferenceDuplicated[Count] = string.Empty;

                        //Si no contiene mas coves como ese, lo remueve de la list de únicos
                        if (!relation.Configuration.CoveSingle.Contains(relation.References[Count].Edocum))
                            relation.Configuration.CoveSingle.Remove(relation.References[Count].Edocum);

                        //Si no contiene mas referencias como esa, lo remueve de la list de únicos
                        if (!relation.Configuration.ReferenceSingle.Contains(relation.References[Count].IdReference))
                            relation.Configuration.ReferenceSingle.Remove(relation.References[Count].IdReference);
                    }
                    else
                    {
                        relation.References[Count].StateGeneral = States.Incomplete;
                    }
                }

                Count++;
                CountMessage++;
            }

            MainForm.MessageText("Archivos comparados en total: " + Count, Color.DarkMagenta);
            MainForm.MessageText("Acuses Obtenidos: " + CountAcuseExistences, Color.DarkMagenta);
            MainForm.MessageText("Detalles Obtenidos: " + CountDetailExistences + "\n", Color.DarkMagenta);
        }

        private void LoadFilesSystem(ReferenceRelation relation)
        {
            string acuseFile = "";
            string detailFile = "";
            string folderExport = relation.Folders.FolderYear + @"ExportFiles\";

            CreateFolder(folderExport);

            int Count = 0;
            int CountMessage = 0;
            int Monto = 1;

            const string folderAcuse = @"Acuses\";
            const string folderDetail = @"Detalles\";
            const string MontoString = "Monto - ";
            string folderMonto = MontoString + Monto.ToString() + @"\";
            CreateFolder(folderExport + folderMonto);
            CreateFolder(folderExport + folderMonto + folderAcuse);
            CreateFolder(folderExport + folderMonto + folderDetail);

            while (relation.References.Count > Count)
            {
                if (CountMessage == 100)
                {
                    CountMessage = 0;
                    MainForm.MessageText("Archivos exportados: " + Count, Color.DarkMagenta);
                    Monto++;
                    folderMonto = MontoString + Monto.ToString() + @"\";
                    CreateFolder(folderExport + folderMonto);
                    CreateFolder(folderExport + folderMonto + folderAcuse);
                    CreateFolder(folderExport + folderMonto + folderDetail);
                }

                if (relation.References[Count].StateGeneral == States.Complete)
                {
                    acuseFile = relation.Folders.FolderAcuse + relation.References[Count].IdReference + " acuse " + relation.References[Count].Edocum + ".pdf";
                    detailFile = relation.Folders.FolderDetail + relation.References[Count].IdReference + " detalle " + relation.References[Count].Edocum + ".pdf";

                    if (File.Exists(acuseFile) && File.Exists(detailFile))
                    {
                        CopyFile(acuseFile, folderExport + folderMonto + folderAcuse + relation.References[Count].IdReference + " acuse " + relation.References[Count].Edocum + ".pdf");
                        CopyFile(detailFile, folderExport + folderMonto + folderDetail + relation.References[Count].IdReference + " detalle " + relation.References[Count].Edocum + ".pdf");
                    }
                    else
                    {
                        MainForm.MessageText("Error en Conteo: " + Count + " , Referencia, Acuse, Detalle, StateG, StateA, StateD : (" + 
                            relation.References[Count].IdReference + ", " + relation.References[Count].Edocum +
                            relation.References[Count].StateDetail + ", " + relation.References[Count].StateGeneral +
                            relation.References[Count].StateAcuse + ", " + relation.References[Count].StateGeneral + ")", Color.Red);
                    }
                }

                Count++;
                CountMessage++;
            }

            MainForm.MessageText("Archivos comparados en total: " + Count, Color.DarkMagenta);
        }

        #endregion

        #region CreateReport Methods

        private static DataTable ReportToDatatable(Report report, string DatatableName)
        {
            DataTable dt = new DataTable(DatatableName);
            dt.Clear();

            foreach (PropertyInfo prop in typeof(Report).GetProperties())
            {
                dt.Columns.Add(prop.Name, typeof(string));
            }

            for (int i = 0; i < report.IdReference.Count; i++)
            {
                DataRow Row = dt.NewRow();

                Row["idReference"] = report.IdReference[i];
                Row["Acuse"] = report.Acuse[i];
                Row["Detail"] = report.Detail[i];
                Row["Client"] = report.Client[i];
                Row["StateGeneral"] = report.StateGeneral[i];

                dt.Rows.Add(Row);
            }

            return dt;
        }

        private static DataTable ListCovesToDatatable(ListCoves ListCoves, string DatatableName)
        {
            DataTable dt = new DataTable(DatatableName);
            dt.Clear();

            foreach (PropertyInfo prop in typeof(ListCoves).GetProperties())
            {
                dt.Columns.Add(prop.Name, typeof(string));
            }

            for (int i = 0; i < ListCoves.CovesNotDuplicated.Count; i++)
            {
                DataRow Row = dt.NewRow();

                Row["CovesNotDuplicated"] = ListCoves.CovesNotDuplicated[i];

                dt.Rows.Add(Row);
            }

            return dt;
        }

        private static DataTable ListReferencesToDatatable(ListReferences ListReferences, string DatatableName)
        {
            DataTable dt = new DataTable(DatatableName);
            dt.Clear();

            foreach (PropertyInfo prop in typeof(ListReferences).GetProperties())
            {
                dt.Columns.Add(prop.Name, typeof(string));
            }

            for (int i = 0; i < ListReferences.References.Count; i++)
            {
                DataRow Row = dt.NewRow();
                Row["References"] = ListReferences.References[i];
                Row["State"] = ListReferences.State[i];
                dt.Rows.Add(Row);
            }

            return dt;
        }

        private static DataTable FullReportToDatatable(FullRelationReport FullRelationReport, string DatatableName)
        {
            DataTable dt = new DataTable(DatatableName);
            dt.Clear();

            foreach (PropertyInfo prop in typeof(FullRelationReport).GetProperties())
            {
                dt.Columns.Add(prop.Name, typeof(string));
            }

            for (int i = 0; i < FullRelationReport.IdReference.Count; i++)
            {
                DataRow Row = dt.NewRow();
                Row["IdReference"] = FullRelationReport.IdReference[i];
                Row["Pediment"] = FullRelationReport.Pediment[i];
                Row["PedimentKey"] = FullRelationReport.PedimentKey[i];
                Row["Edocum"] = FullRelationReport.Edocum[i];
                Row["Client"] = FullRelationReport.Client[i];
                Row["WithRec"] = FullRelationReport.WithRec[i];

                Row["StateGeneral"] = FullRelationReport.StateGeneral[i];
                Row["StateAcuse"] = FullRelationReport.StateAcuse[i];
                Row["StateDetail"] = FullRelationReport.StateDetail[i];

                dt.Rows.Add(Row);
            }

            return dt;
        }

        private static DataTable ClientReportToDataTable(ClientReport ClientReport, string DatatableName)
        {
            DataTable dt = new DataTable(DatatableName);
            dt.Clear();

            foreach (PropertyInfo prop in typeof(ClientReport).GetProperties())
            {
                dt.Columns.Add(prop.Name, typeof(string));
            }

            for (int i = 0; i < ClientReport.IdReference.Count; i++)
            {
                DataRow Row = dt.NewRow();
                Row["IdReference"] = ClientReport.IdReference[i];
                Row["Edocum"] = ClientReport.Edocum[i];
                Row["StateGeneral"] = ClientReport.StateGeneral[i];
                Row["Client"] = ClientReport.Client[i];

                dt.Rows.Add(Row);
            }

            return dt;
        }

        #endregion

        #region Common Methods

        /// <summary>
        /// Crea un FolderBrowserDialog para obtener la ubicación raíz de los procesos a almacenar.
        /// </summary>
        /// <returns>Retorna la ubicación raíz "Root".</returns>
        private string GetRoot()
        {
            using (FolderBrowserDialog FolderBrowserDialog = new FolderBrowserDialog())
            {
                DialogResult result = FolderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(FolderBrowserDialog.SelectedPath))
                    return FolderBrowserDialog.SelectedPath + @"\";
                else
                    return null;
            }
        }

        /// <summary>
        /// Crea un FolderBrowserDialog para obtener la ubicación raíz de los procesos a almacenar,
        /// usando la ubicación root como punto de partida.
        /// </summary>
        /// <param name="root">Ubicación de la carpeta raíz</param>
        /// <returns></returns>
        private string GetRoot(string root, string description)
        {
            using (FolderBrowserDialog FolderBrowserDialog = new FolderBrowserDialog())
            {
                FolderBrowserDialog.SelectedPath = root;
                FolderBrowserDialog.Description = description;
                DialogResult result = FolderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(FolderBrowserDialog.SelectedPath))
                    return FolderBrowserDialog.SelectedPath + @"\";
                else
                    return null;
            }
        }

        /// <summary>
        /// Elimina todas las estancias de la clase antes de que sea ellimianda la clase.
        /// </summary>
        public void Dispose()
        {

        }

        #endregion
    }
}
