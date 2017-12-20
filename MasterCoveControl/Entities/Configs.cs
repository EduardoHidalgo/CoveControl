using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterCoveControl
{
    public class Config
    {
        /// <summary>
        /// Almacena la ubicación raíz de la carpeta de operación
        /// así como un conjunto de las actualizaciones, configuraciones y
        /// banderas producidas por el sistema...
        /// </summary>
        public class AppConfig
        {
            public string Root { get; set; }

            public List<ReferenceRelation> ListReferences { get; set; }

            public AppConfig()
            {
                ListReferences = new List<ReferenceRelation>();
            }
        }
    }

    public class ReferenceRelation
    {
        public string Year { get; set; }

        public Folders Folders { get; set; }

        public List<string> Clients { get; set; }
        public List<Reference> References { get; set; }
        public Configuration Configuration { get; set; }

        public ReferenceRelation()
        {
            Clients = new List<string>();
            References = new List<Reference>();
            Configuration = new Configuration();
        }

        public void Add(Reference reference)
        {
            References.Add(reference);
        }
    }

    public class FullRelationReport
    {
        public List<string> IdReference { get; set; }
        public List<string> Pediment { get; set; }
        public List<string> PedimentKey { get; set; }
        public List<string> Edocum { get; set; }
        public List<string> Client { get; set; }
        public List<string> WithRec { get; set; }

        public List<string> StateGeneral { get; set; }
        public List<string> StateAcuse { get; set; }
        public List<string> StateDetail { get; set; }

        public FullRelationReport(ReferenceRelation relation)
        {
            IdReference = new List<string>();
            Pediment = new List<string>();
            PedimentKey = new List<string>();
            Edocum = new List<string>();
            Client = new List<string>();
            WithRec = new List<string>();

            StateGeneral = new List<string>();
            StateAcuse = new List<string>();
            StateDetail = new List<string>();

            foreach (var reference in relation.References)
            {
                IdReference.Add(reference.IdReference);
                Pediment.Add(reference.Pediment);
                PedimentKey.Add(reference.PedimentKey);
                Edocum.Add(reference.Edocum);
                Client.Add(reference.Client);
                WithRec.Add(reference.WithRec);

                StateGeneral.Add(reference.StateGeneral);
                StateAcuse.Add(reference.StateAcuse);
                StateDetail.Add(reference.StateDetail);
            }
        }
    }

    public class Reference
    {
        public string IdReference { get; set; }
        public string Pediment { get; set; }
        public string PedimentKey { get; set; }
        public string Edocum { get; set; }
        public string Client { get; set; }
        public string WithRec { get; set; }

        public string StateGeneral { get; set; }
        public string StateAcuse { get; set; }
        public string StateDetail { get; set; }

        public Reference(string idReference, string pediment, string pedimentKey, string edocum, string client, string withRec)
        {
            IdReference = idReference;
            Pediment = pediment;
            PedimentKey = pedimentKey;
            Edocum = edocum;
            Client = client;
            WithRec = withRec;
            StateGeneral = States.Empty;
        }
    }

    public class Configuration
    {
        public List<string> ReferenceSingle { get; set; }
        public List<string> ReferenceDuplicated { get; set; }
        public List<string> CoveSingle { get; set; }
        public List<string> CoveDuplicated { get; set; }

        public Configuration()
        {
            ReferenceSingle = new List<string>();
            ReferenceDuplicated = new List<string>();
            CoveSingle = new List<string>();
            CoveDuplicated = new List<string>();
        }
    }

    public class Report
    {
        public List<string> IdReference { get; set; }
        public List<string> Acuse { get; set; }
        public List<string> Detail { get; set; }
        public List<string> Client { get; set; }
        public List<string> StateGeneral { get; set; }

        public Report(List<Reference> References)
        {
            IdReference = new List<string>();
            Acuse = new List<string>();
            Detail = new List<string>();
            Client = new List<string>();
            StateGeneral = new List<string>();

            foreach (var reference in References)
            {
                if (reference.StateGeneral != States.Complete)
                {
                    IdReference.Add(reference.IdReference);
                    if (!Acuse.Contains(reference.Edocum))
                    {
                        if (reference.StateAcuse != States.Complete)
                            Acuse.Add(reference.Edocum);
                        else
                            Acuse.Add(States.Complete);
                    }
                    else
                        Acuse.Add("Duplicated");

                    if (!Detail.Contains(reference.Edocum))
                    {
                        if (reference.StateDetail != States.Complete)
                            Detail.Add(reference.Edocum);
                        else
                            Detail.Add(States.Complete);
                    }
                    else
                        Detail.Add("Duplicated");

                    Client.Add(reference.Client);
                    StateGeneral.Add(reference.StateGeneral);
                }
            }
        }
    }

    public class ClientReport
    {
        public List<string> IdReference { get; set; }
        public List<string> Edocum { get; set; }
        public List<string> StateGeneral { get; set; }
        public List<string> Client { get; set; }

        public ClientReport(List<Reference> References)
        {
            IdReference = new List<string>();
            Edocum = new List<string>();
            Client = new List<string>();
            StateGeneral = new List<string>();

            foreach (var item in References)
            {
                IdReference.Add(item.IdReference);
                Edocum.Add(item.Edocum);
                Client.Add(item.Client);
                StateGeneral.Add(item.StateGeneral);
            }
        }
    }

    public class ListCoves
    {
        public List<string> CovesNotDuplicated { get; set; }

        public ListCoves(Configuration config)
        {
            CovesNotDuplicated = new List<string>();

            for (int i = 0; i < config.CoveSingle.Count; i++)
                CovesNotDuplicated.Add(config.CoveSingle[i]);
        }

        /// <summary>
        /// Usar cuando exista un reporte generado
        /// </summary>
        /// <param name="report"></param>
        /// <param name="References"></param>
        public ListCoves(Report report, List<Reference> References)
        {
            CovesNotDuplicated = new List<string>();

            for (int i = 0; i < References.Count; i++)
                if (report.IdReference.Contains(References[i].IdReference))
                    if (!CovesNotDuplicated.Contains(References[i].Edocum))
                        CovesNotDuplicated.Add(References[i].Edocum);
        }
    }

    public class ListReferences
    {
        public List<string> References { get; set; }
        public List<string> State { get; set; }

        public ListReferences(Configuration config)
        {
            References = new List<string>();
            State = new List<string>();

            for (int i = 0; i < config.ReferenceSingle.Count; i++)
                References.Add(config.ReferenceSingle[i]);
        }

        /// <summary>
        /// Usar cuando exista un reporte generado
        /// </summary>
        /// <param name="config"></param>
        /// <param name="report"></param>
        public ListReferences(Configuration config, Report report)
        {
            References = new List<string>();
            State = new List<string>();

            for (int i = 0; i < config.ReferenceSingle.Count; i++)
            {
                if (report.IdReference.IndexOf(config.ReferenceSingle[i]) > 0)
                {
                    int index = report.IdReference.IndexOf(config.ReferenceSingle[i]);

                        if (report.StateGeneral[index] != States.Complete && report.StateGeneral[index] != States.Wrong)
                        {
                            References.Add(config.ReferenceSingle[i]);
                            State.Add(report.StateGeneral[index]);
                        }
                }
            }
        }
    }

    public static class States
    {
        public const string Complete = "Complete";
        public const string Empty = "Empty";
        public const string Wrong = "Wrong";
        public const string Incomplete = "Incomplete";
    }

    public struct Folders
    {
        public string Year { get; set; }
        public string FolderYear { get; set; }
        public string FolderReference { get; set; }
        public string FolderAcuse { get; set; }
        public string FolderDetail { get; set; }

        public Folders(string year, string folderYear, string folderReference, string folderAcuse, string folderDetail)
        {
            Year = year;
            FolderYear = folderYear;
            FolderReference = folderReference;
            FolderAcuse = folderAcuse;
            FolderDetail = folderDetail;
        }

        public void AddFolders(string folderYear, string folderReference, string folderAcuse, string folderDetail)
        {
            FolderYear = folderYear;
            FolderReference = folderReference;
            FolderAcuse = folderAcuse;
            FolderDetail = folderDetail;
        }
    }

    public class ProcessFlag
    {
        public bool Enable;
        public string Name;
        MainForm MainForm;

        public ProcessFlag(MainForm mainForm)
        {
            MainForm = mainForm;
        }

        public void SetFlag(bool enable, string name)
        {
            Enable = enable;
            Name = name;
            MainForm.DisableAllButtons();
        }

        public void DropFlag()
        {
            Enable = false;
            Name = "";
            MainForm.EnableAllButtons();
        }
    }

    public class ExceptionFlag
    {
        public bool ExceptionObtained { get; set; }
        public string Exception { get; set; }
        public string ClassException { get; set; }
        public string MethodException { get; set; }
        public string InnerException { get; set; }
        public string StackTrace { get; set; }

        public ExceptionFlag()
        {
            ExceptionObtained = false;
            Exception = "";
            ClassException = "";
            MethodException = "";
            InnerException = "";
            StackTrace = "";
        }

        public void SetFlag(string exception, string classException, string methodException, string innerException, string stackTrace)
        {
            ExceptionObtained = true;
            Exception = "\n\nException Message: " + exception + " ;";
            ClassException = "Error en clase: " + classException + " ;";
            MethodException = "Método: " + methodException + " ;";
            InnerException = "Exception: " + innerException + " ;";
            StackTrace = "Exception StackTrace: " + stackTrace;
        }

        public void Dropflag()
        {
            ExceptionObtained = false;
            Exception = "";
            ClassException = "";
            MethodException = "";
            InnerException = "";
            StackTrace = "";
        }
    }
}
