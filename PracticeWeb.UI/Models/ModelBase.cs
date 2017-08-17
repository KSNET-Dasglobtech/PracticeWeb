using PracticeWeb.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeWeb.UI.Models
{
    public class ModelBase : ProductBase
    {
        public ModelBase(Type typeOfChild)
            : base(typeOfChild)
        { }

        public string GetBaseUrl()
        {
            var request = HttpContext.Current.Request;
            var appUrl = HttpRuntime.AppDomainAppVirtualPath;

            if (appUrl != "/") appUrl += "/";

            string baseUrl = string.Format("{0}://{1}{2}", request.Url.Scheme, request.Url.Authority, appUrl);

            return baseUrl;
        }
    }
}