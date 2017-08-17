using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PracticeWeb.Common
{
    public class Result
    {
        public bool HasError
        {
            get
            {
                return (Status == StatusType.Error);
            }
            set { }
        }

        public bool HasSuccess
        {
            get
            {
                return (Status == StatusType.Success);
            }
            set { }
        }

        public StatusType Status { get; set; }

        public string Message { get; set; }
        public string ExceptionMessage { get; set; }
        public string ExceptionStackTrace { get; set; }
        public Exception ResultException { get; set; }

        // All other data elements     
        public XElement xElement;
        public Object ResultObject; // to pass generic data in results

        public Result()
        {
            this.Status = StatusType.Success;
        }

        // Error result
        public Result(string message)
        {
            this.Status = StatusType.Error;
            this.Message = message;
        }

        public Result(string message, StatusType statusType)
        {
            this.Status = statusType;
            this.Message = message;
        }

        // Error result
        public Result(string message, Exception exp)
        {
            this.Status = StatusType.Error;
            this.Message = message;
            if (null != exp)
            {
                this.ExceptionMessage = exp.Message;
                this.ExceptionStackTrace = exp.StackTrace;
            }
            this.ResultException = exp;
        }
    }

    public enum StatusType
    {
        Success,
        Warning,
        Error
    }
}
