using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeWeb.Common
{
    public class LogWriter
    {
        private static readonly object _lock = new object();
        private string logRootFolder;
        private string logSubFolder;
        private string logFilePrefix;
        private string logFileSufix;
        private string logTimezone;
        private string logEntryPrefix;
        private string activeLogTypes;

        public string LogEntryPrefix
        {
            get { return logEntryPrefix; }
            set { logEntryPrefix = value; }
        }

        public string LogSubFolder
        {
            get { return logSubFolder; }
            set { logSubFolder = value; }
        }

        public string LogFilePrefix
        {
            get { return logFilePrefix; }
            set { logFilePrefix = value; }
        }

        public bool IsInfoEnabled
        {
            get { return (activeLogTypes.IndexOf("INFO") > -1); }
            set { }
        }
        public bool IsDebugEnabled
        {
            get { return (activeLogTypes.IndexOf("DEBUG") > -1); }
            set { }
        }
        public bool IsWarnEnabled
        {
            get { return (activeLogTypes.IndexOf("WARN") > -1); }
            set { }
        }
        public bool IsErrorEnabled
        {
            get { return (activeLogTypes.IndexOf("ERROR") > -1); }
            set { }
        }

        public LogWriter(string filesufix = null)
        {
            //logRootFolder = ConfigurationManager.AppSettings["LogFolder"];
            //if (null == logRootFolder || logRootFolder.Length == 0)
            //{
            //    // pick up the current folder and add Logs directory
            //    logRootFolder = Assembly.GetExecutingAssembly().Location;
            //    logRootFolder = logRootFolder.Substring(0, logRootFolder.LastIndexOf("\\")) + "\\Logs";
            //}

            ////check if the folder exists, if not create one...
            //if (!Directory.Exists(logRootFolder)) Directory.CreateDirectory(logRootFolder);

            //activeLogTypes = ConfigurationManager.AppSettings["EnableLogTypes"];
            //logTimezone = TimeZoneInfo.Local.StandardName;
            //if (null != filesufix) logFileSufix = filesufix;
        }

        public LogWriter(Type childClassType, string filesufix = null)
        {
            //logRootFolder = ConfigurationManager.AppSettings["LogFolder"];
            //if (null == logRootFolder || logRootFolder.Length == 0)
            //{
            //    // pick up the current folder and add Logs directory
            //    logRootFolder = Assembly.GetExecutingAssembly().Location;
            //    logRootFolder = logRootFolder.Substring(0, logRootFolder.LastIndexOf("\\")) + "\\Logs";
            //}

            ////check if the folder exists, if not create one...
            //if (!Directory.Exists(logRootFolder)) Directory.CreateDirectory(logRootFolder);

            //activeLogTypes = ConfigurationManager.AppSettings["EnableLogTypes"];
            //logTimezone = TimeZoneInfo.Local.StandardName;
            //logEntryPrefix = childClassType.Name;
            //if (null != filesufix) logFileSufix = filesufix;
        }

        public LogWriter(string subfolder, string filePrefix, string timezone, string logPrefix)
        {
            //logRootFolder = ConfigurationManager.AppSettings["LogFolder"];
            //if (null == logRootFolder || logRootFolder.Length == 0)
            //{
            //    // pick up the current folder and add Logs directory
            //    logRootFolder = Assembly.GetExecutingAssembly().Location;
            //    logRootFolder = logRootFolder.Substring(0, logRootFolder.LastIndexOf("\\")) + "\\Logs";
            //}

            //activeLogTypes = ConfigurationManager.AppSettings["EnableLogTypes"];
            //logTimezone = TimeZoneInfo.Local.StandardName;

            //Initiaize(logRootFolder, subfolder, filePrefix, timezone, logPrefix);
        }

        public LogWriter(string subfolder, string logFolder, string filePrefix, string timezone, string logPrefix)
        {
            Initiaize(logFolder, subfolder, filePrefix, timezone, logPrefix);
        }

        public void Initiaize(string logFolder, string subfolder, string fileprefix, string timezone, string logPrefix)
        {
            lock (_lock)
            {
                if (null != subfolder) logSubFolder = subfolder;

                // set local timezone as default time zone if its not given...
                if (null != timezone) logTimezone = timezone;

                if (null != fileprefix) logFilePrefix = fileprefix;

                if (null != logPrefix) logEntryPrefix = logPrefix;

                // check if the required directory exists, if not create directories as needed
                if (null != logFolder && !Directory.Exists(logFolder)) Directory.CreateDirectory(logFolder);
                //if (null != logSubFolder && logSubFolder.Length > 0)
                //{
                //    if (!Directory.Exists(Path.Combine(logRootFolder, logSubFolder)))
                //        Directory.CreateDirectory(Path.Combine(logRootFolder, logSubFolder));
                //}
            }
        }

        private void WriteLog(string logType, string message, Exception ex = null)
        {
            //string logFileName = GetLogFileName();

            //try
            //{
            //    DateTime dt = ConvertToDifferentTimeZone(logTimezone);

            //    string msg = dt.ToString("HH:mm:ss.fff") + " | " + logType.PadRight(5, ' ')
            //        + " | " + (null != logEntryPrefix ? logEntryPrefix + " | " : "") + (null != message ? message : "")
            //        + (null != ex ? Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace : "")
            //        + (null != ex && null != ex.InnerException ? Environment.NewLine + "InnerException: " + ex.InnerException.Message
            //                + Environment.NewLine + ex.InnerException.StackTrace : "")
            //        + (null != ex && null != ex.InnerException && null != ex.InnerException.InnerException 
            //            ? Environment.NewLine + "InnerException (2): " + ex.InnerException.InnerException.Message
            //            + Environment.NewLine + ex.InnerException.InnerException.StackTrace : "");

            //    lock (_lock)
            //    {
            //        if (!File.Exists(logFileName))
            //        {
            //            using (StreamWriter sw = new StreamWriter(logFileName, true))
            //            {
            //                // Put down the full path and name of file, so everything we know is preserved...
            //                sw.WriteLine("Starting new Log file at location: '" + logFileName + "'");
            //                sw.WriteLine("LogRootFolder: " + logRootFolder);
            //                sw.WriteLine("LogSubFolder: " + logSubFolder + ", LogFilePrefix: " + logFilePrefix + ", LogTimezone: " + logTimezone);
            //                sw.WriteLine("".PadRight(150, '-'));

            //                // ... and then continue with normal logging...
            //                sw.WriteLine(msg);
            //            }
            //        }
            //        else
            //        {
            //            // if this is not a new file, continue with normal logging...
            //            using (StreamWriter sw = new StreamWriter(logFileName, true))
            //            {
            //                sw.WriteLine(msg);
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex1)
            //{
            //    lock (_lock)
            //    {
            //        using (StreamWriter sw = new StreamWriter(Path.Combine(logRootFolder, "LoggerErrors.log"), true))
            //        {
            //            DateTime dt = ConvertToDifferentTimeZone(logTimezone);
            //            sw.WriteLine(dt.ToString("HH:mm:ss.fff") + " | Error occured while writing log entry to log file '"
            //                + logFileName + "', logType: " + logType + ", logEntryPrefix:" + logEntryPrefix
            //                + ", message:" + message
            //                + Environment.NewLine + ex1.Message + Environment.NewLine + ex1.StackTrace
            //                + (null != ex1.InnerException ? Environment.NewLine + "InnerException: " + ex1.InnerException.Message
            //                                    + Environment.NewLine + ex1.InnerException.StackTrace : "")
            //                    );
            //            sw.WriteLine("".PadRight(100, '-'));
            //        }
            //    }
            //}
        }

        private string GetLogFileName()
        {
            DateTime dt = ConvertToDifferentTimeZone(logTimezone);
            string logFileName =
                logRootFolder + "\\"
                + ((null != logSubFolder && logSubFolder.Length > 0) ? logSubFolder + "\\" : "")
                + ((null != logFilePrefix && logFilePrefix.Length > 0) ? logFilePrefix + "_" : "")
                + dt.ToString("yyyyMMdd")
                + ((null != logFileSufix && logFileSufix.Length > 0) ? "_" + logFileSufix : "")
                + ".log";
            return logFileName;
        }

        public void Info(string message)
        {
            //if (IsInfoEnabled) WriteLog("INFO", message);
        }

        public void Warn(string message)
        {
            //if (IsWarnEnabled) WriteLog("WARN", message);
        }

        public void Debug(string message)
        {
            //if (IsDebugEnabled) WriteLog("DEBUG", message);
        }

        public void Error(string message, Exception ex = null)
        {
            //if (IsErrorEnabled) WriteLog("ERROR", message, ex);
        }

        public DateTime ConvertToDifferentTimeZone(string toTimeZoneId)
        {
            try
            {
                DateTime localDateTime = DateTime.Now;
                if (null == toTimeZoneId) toTimeZoneId = TimeZoneInfo.Local.StandardName;

                // Convert time in local timezone to that of company timezone...
                TimeZoneInfo tzi;
                // if the convert-to-timezone is UTC, use TimeZoneInfo.Utc instead of Find system timezone 
                //      (because some OS does not recognize it as known timezone)

                if (string.IsNullOrEmpty(toTimeZoneId))
                {
                    tzi = TimeZoneInfo.Utc;
                }
                else if (toTimeZoneId.Equals("Coordinated Universal Time"))
                    tzi = TimeZoneInfo.Utc;
                else
                    tzi = TimeZoneInfo.FindSystemTimeZoneById(toTimeZoneId);

                DateTime companyTime;
                if (localDateTime.Kind == DateTimeKind.Utc)
                    companyTime = TimeZoneInfo.ConvertTime(localDateTime, TimeZoneInfo.Utc, tzi);
                else
                    companyTime = TimeZoneInfo.ConvertTime(localDateTime, TimeZoneInfo.Local, tzi);

                return companyTime;
            }
            catch (TimeZoneNotFoundException ex)
            {
                WriteLog("ERROR", "The registry does not define the '" + toTimeZoneId + "'"
                    + "Error: " + ex.Message + Environment.NewLine + ex.StackTrace);
            }
            catch (InvalidTimeZoneException ex2)
            {
                WriteLog("ERROR", "Registry data on the timezone '" + toTimeZoneId
                    + "' has been corrupted." + "Error: " + ex2.Message + Environment.NewLine + ex2.StackTrace);
            }

            return new DateTime(2000, 1, 1);
        }
    }
}
