using PracticeWeb.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeWeb.UI.Controllers
{
    public class ControllerBase : Controller
    {
        protected ProductBase productBase;

        public ControllerBase()
            : base()
        {
            productBase = new ProductBase(this.GetType());
        }

        public ControllerBase(Type typeOfChild)
            : base()
        {
            productBase = new ProductBase(typeOfChild);
        }

        public string GetWebUrlLeftPart()
        {
            // For Localhost
            return Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath;

            // For Live Domain
            //return Request.Url.GetLeftPart(UriPartial.Authority);

        }

        public void LogInfo(string strInfo)
        {
            productBase.LogInfo(strInfo);
        }

        public void LogDebug(string strInfo)
        {
            productBase.LogDebug(strInfo);
        }

        public void LogWarn(string strInfo)
        {
            productBase.LogWarn(strInfo);
        }

        public void LogError(string strError)
        {
            productBase.LogError(strError);
        }

        public void LogError(Exception ex, String Area)
        {
            productBase.LogError("Unhandled error occured at (" + Area + ")"
                    + Environment.NewLine + "Error: " + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + " Error InnerData " + Environment.NewLine + ex.InnerException.ToString());
        }
        public void ProcessException(string message, Exception ex)
        {
            productBase.ProcessException(message, ex);
        }
    }
}