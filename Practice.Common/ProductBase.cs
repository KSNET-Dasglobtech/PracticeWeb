using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace PracticeWeb.Common
{
    public class ProductBase
    {
        //public log4net.ILog Logger;
        public LogWriter ActLogWriter;
        public LogWriter ErrLogWriter;
        //private bool Islog4NetEnabled = true;

        public ProductBase()
        {
            //Logger = LogManager.GetLogger(this.GetType());
            ActLogWriter = new LogWriter();
            ErrLogWriter = new LogWriter("Error");

            // check if the user session is active, if so, set the company name...
            if (System.Web.HttpContext.Current != null)
            {
                LoginSession loginSession = HttpContext.Current.Session["LoginSession"] as LoginSession;
                if (null != loginSession && null != loginSession.UserInfo)
                {
                    // initialize the loggers to user company folder... 

                    ActLogWriter.Initiaize(null /*logFolder*/,
                    RemoveAllNonAlpaNumChars(loginSession.UserInfo.Name) + "_" + loginSession.UserInfo.ID.ToString() /*subfolder*/,
                    null /*fileprefix*/, null /*timezone*/, null /*logEntryPrefix*/);

                    ErrLogWriter.Initiaize(null /*logFolder*/,
                    RemoveAllNonAlpaNumChars(loginSession.UserInfo.Name) + "_" + loginSession.UserInfo.ID.ToString() /*subfolder*/,
                    null /*fileprefix*/, null /*timezone*/, null /*logEntryPrefix*/);
                }
            }
        }

        public ProductBase(Type childClassType)
        {
            //Logger = LogManager.GetLogger(childClassType);
            ActLogWriter = new LogWriter(childClassType);
            ErrLogWriter = new LogWriter(childClassType, "Error");

            // check if the user session is active, if so, set the company name...
            if (HttpContext.Current != null && HttpContext.Current.Session != null)
            {
                LoginSession loginSession = HttpContext.Current.Session["LoginSession"] as LoginSession;

                if (null != loginSession && null != loginSession.UserInfo)
                {
                    // initialize the loggers to user company folder... 
                    ActLogWriter.Initiaize(null /*logFolder*/,
                      RemoveAllNonAlpaNumChars(loginSession.UserInfo.Name) + "_" + loginSession.UserInfo.ID.ToString() /*subfolder*/,
                      null /*fileprefix*/, null /*timezone*/, null /*logEntryPrefix*/);

                    ErrLogWriter.Initiaize(null /*logFolder*/,
                      RemoveAllNonAlpaNumChars(loginSession.UserInfo.Name) + "_" + loginSession.UserInfo.ID.ToString() /*subfolder*/,
                      null /*fileprefix*/, null /*timezone*/, null /*logEntryPrefix*/);
                }
            }
        }



        public void LogInfo(string message)
        {
            //if (Islog4NetEnabled && Logger.IsInfoEnabled) Logger.Info(message);
            ActLogWriter.Info(message);
        }

        public void LogDebug(string message)
        {
            //if (Islog4NetEnabled && Logger.IsDebugEnabled) Logger.Debug(message);
            ActLogWriter.Debug(message);
        }

        public void LogWarn(string message)
        {
            //if (Islog4NetEnabled && Logger.IsWarnEnabled) Logger.Warn(message);
            ActLogWriter.Warn(message);
        }

        public void LogError(string message)
        {
            //if (Islog4NetEnabled && Logger.IsErrorEnabled) Logger.Error(message);
            ActLogWriter.Error(message);
            ErrLogWriter.Error(message);
        }

        public void ProcessException(string message, Exception ex)
        {
            //if (Islog4NetEnabled) Logger.Error(message, ex);
            ActLogWriter.Error(message);
            ErrLogWriter.Error(message, ex);
        }

        public void InitiaizeLoggers(string logFolder, string subfolder, string fileprefix, string timezone, string logPrefix)
        {
            ActLogWriter.Initiaize(logFolder, subfolder, fileprefix, timezone, logPrefix);
            ErrLogWriter.Initiaize(logFolder, subfolder, fileprefix, timezone, logPrefix);
        }

        public string RemoveAllNonAlpaNumChars(string sourceStr)
        {
            var regex = new Regex(@"(\s-|[^A-Za-z0-9-])");
            return regex.Replace(sourceStr, "");
        }
    }
}
