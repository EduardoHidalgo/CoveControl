using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Drawing;
using System.Reflection;

namespace MasterCoveControl
{
    public class FileManager : IDisposable
    {
        MainForm MainForm;

        public FileManager(MainForm mainForm)
        {
            MainForm = mainForm;
        }

        /// <summary>
        /// Obtiene un archivo tipo .json y convierte su data a un Objeto definido.
        /// </summary>
        /// <param name="obj">Instancia de un objeto vacía.</param>
        /// <param name="path">Dirección del archivo json en disco.</param>
        /// <param name="fileName">Nombre y extensión del archivo.</param>
        /// <returns></returns>
        public object OpenJson(object obj, string path, string fileName)
        {
            try
            {
                string temp = System.IO.File.ReadAllText(path + fileName);

                switch (obj.GetType().Name)
                {
                    case nameof(Config.AppConfig):
                        return JsonConvert.DeserializeObject<Config.AppConfig>(temp);
                    default:
                        return JsonConvert.DeserializeObject<object> (temp);
                }
            }
            catch (Exception e)
            {
                MainForm.MessageText("FileManager.cs, FileManager Class, OpenJson Method: " + e.Message, Color.Red);
                return null;
            }
            finally
            {
                Dispose();
            }
        }

        /// <summary>
        /// Crea un archivo de tipo. json a partir de un objeto definido.
        /// </summary>
        /// <param name="obj">Instancia de un objeto vacía.</param>
        /// <param name="path">Dirección del archivo json en disco.</param>
        /// <param name="fileName">Nombre y extensión del archivo.</param>
        /// <returns></returns>
        public string SaveJson(object obj, string path, string fileName)
        {
            try
            {
                string Serialize = JsonConvert.SerializeObject(obj, Formatting.Indented);
                System.IO.File.WriteAllText(path + fileName, Serialize);
                return ("");
            }
            catch (Exception e)
            {
                return ("FileManager.cs, FileManager Class, SaveJson Method: " + e.Message);
            }
            finally
            {
                Dispose();
            }
        }

        /// <summary>
        /// Crea un archivo de Log en la ubicación del ejecutable que contiene los errores de ejecución.
        /// </summary>
        /// <param name="ex">Mensaje de Error</param>
        /// <param name="classType">Clase donde proviene el error</param>
        /// <param name="MethodName">Método donde proviene el error</param>
        public ExceptionFlag CreateLog(Exception ex, string classType, string MethodName)
        {
            ExceptionFlag ExceptionFlag = new ExceptionFlag();

            try
            {
                string Inner = "";

                string DateTimeLog = DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss");
                List<string> Log = new List<string>();
                if (ex.InnerException != null)
                    Inner = ("Exception: " + ex.InnerException + " ;");
                else
                    Inner = ("Exception: No InnerException Received. ;");

                Log.Add("Error en clase: " + classType + " ;");
                Log.Add("Método: " + MethodName + " ;");
                Log.Add("Data: " + DateTimeLog + " ;");
                Log.Add("Exception Message: " + ex.Message + " ;");
                Log.Add(Inner);
                Log.Add("Exception StackTrace: " + ex.StackTrace);

                string Serialize = JsonConvert.SerializeObject(Log, Formatting.Indented);
                string FileName = "Log" + DateTimeLog + ".json";
                System.IO.File.WriteAllText(System.IO.Directory.GetCurrentDirectory() + FileName, Serialize);

                ExceptionFlag.SetFlag(ex.Message, classType, MethodName, Inner, ex.StackTrace);
                return ExceptionFlag;
            }
            catch (Exception e)
            {
                string Inner = "";

                if (e.InnerException != null)
                    Inner = ("Exception: " + e.InnerException + " ;");
                else
                    Inner = ("Exception: No InnerException Received. ;");

                ExceptionFlag.SetFlag(e.Message, GetType().Name, MethodBase.GetCurrentMethod().Name, Inner, e.StackTrace);
                return ExceptionFlag;
            }
        }

        /// <summary>
        /// Limpia las variables y objetos en desuso.
        /// </summary>
        public void Dispose()
        {
            //Limpieza
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
