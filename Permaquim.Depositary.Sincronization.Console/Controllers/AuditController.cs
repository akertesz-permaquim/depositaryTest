﻿using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Permaquim.Depositary.Sincronization.Console.Controllers
{
    internal static class AuditController
    {
        public enum LogTypeEnum
        {
            None,
            Exception,
            Information,
            Navigation
        }

        public const long APPLICATION_ID = 1;

        public static void Log(LogTypeEnum logType, string description, string detail)
        {
            try
            {
                StackTrace stackTrace = new StackTrace(); //Para obtener el nombre del metodo que lo llamo

                Depositario.Business.Tables.Auditoria.Log entities = new();
                Depositario.Entities.Tables.Auditoria.Log entity = new()
                {
                    AplicacionId = APPLICATION_ID,
                    Fecha = DateTime.Now,
                    Metodo = stackTrace.GetFrame(1).GetMethod().Name,
                    Modulo = stackTrace.GetFrame(1).GetMethod().Module.Name,
                    TipoId = (long)logType,
                    Descripcion = description,
                    Detalle = detail,
                    UsuarioId = -1

                };

                entities.Add(entity);
            }
            catch
            {
                return;
            }
        }

        public static void Log(Exception exception)
        {
            Log(LogTypeEnum.Exception, exception.Message, exception.StackTrace);
        }

        public static void LogToFile(Exception ex)
        {

            string logDirectory = AppDomain.CurrentDomain.BaseDirectory + @"\Logs\";
            if (!System.IO.Directory.Exists(logDirectory))
                System.IO.Directory.CreateDirectory(logDirectory);

            string filename = logDirectory + DateTime.Now.ToString("dd.MM.yyyy") + ".log";

            System.IO.StreamWriter file = new(filename, true);

            file.WriteLine("Exception at " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss.ms.f") + ":");
            file.WriteLine("Message : " + ex.Message + Environment.NewLine
                + "StackTrace :" + ex.StackTrace);
            file.WriteLine("");
            file.Flush();
            file.Close();
        }

        public static void LogToFile(string message)
        {
            string logDirectory = AppDomain.CurrentDomain.BaseDirectory + @"\Logs\";
            if (!System.IO.Directory.Exists(logDirectory))
                System.IO.Directory.CreateDirectory(logDirectory);

            string filename = logDirectory + DateTime.Now.ToString("dd.MM.yyyy") + ".log";

            System.IO.StreamWriter file = new(filename, true);

            file.WriteLine("Message at " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss.ms.f") + ":");
            file.WriteLine(message);
            file.WriteLine("");
            file.Flush();
            file.Close();

            //file = null;
        }
    }
}
