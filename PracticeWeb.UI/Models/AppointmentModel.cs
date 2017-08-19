using PracticeWeb.Common;
using PracticeWeb.Components;
using PracticeWeb.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeWeb.UI.Models
{
    public class AppointmentModel : ModelBase
    {
        public AppointmentModel(Type childClassType)
            : base(childClassType)
        { }

        public AppointmentModel()
            : base(typeof(AppointmentModel))
        { }

        #region Field

        public List<GetAppointments_Result> AppointmentList { get; set; }

        public long AppointmentID { get; set; }
        public long? PatNum{ get; set; }
        public string PatName { get; set; }
        
        public int? OperatoryID { get; set; }

        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public string StartTimezone { get; set; }
        public string EndTimezone { get; set; }
        public bool? IsAllDay { get; set; }
        public string Description { get; set; }

            public int? DoctorId { get; set; }

        #endregion

        #region Method

        public Result LoadAllAppointment()
        {
            Result result = new Result();
            try
            {
                AppointmentEntity AppointmentEntity = new AppointmentEntity();
               AppointmentList = AppointmentEntity.GetAppointmentList();
            }
            catch(Exception ex)
            {
                ProcessException("An error occurred while loading all PatAppointment detail, error: " + ex.Message, ex);
                return new Result("An error occurred while loading all PatAppointment detail");
            }
            return result;
        }

        public Result DeleteAppointment(long patNum)
        {
            Result result = new Result();
            try
            {
                AppointmentEntity AppointmentEntity = new AppointmentEntity();
                AppointmentEntity.DeleteAppointment(patNum);
            }
            catch (Exception ex)
            {
                ProcessException("An error occurred while deleting PatAppointment, error: " + ex.Message, ex);
                return new Result("An error occurred while deleting PatAppointment");
            }
            return result;
        }

        public PatAppointment GetAppointmentDetails(long appointmentId)
        {
            PatAppointment PatAppointment = new PatAppointment();
            AppointmentEntity AppointmentEntity = new AppointmentEntity();
            PatAppointment = AppointmentEntity.GetAppointmentByPatNum(appointmentId);
            if(PatAppointment!=null)
            {
                this.AppointmentID = PatAppointment.AppointmentID;
                this.PatNum = PatAppointment.PatNum;
                this.OperatoryID = PatAppointment.OperatoryID;
                this.StartTime= PatAppointment.StartTime;
                this.EndTime = PatAppointment.EndTime;
                this.IsAllDay= PatAppointment.IsAllDay;
                this.Description= PatAppointment.Description;
                this.DoctorId= PatAppointment.DoctorId;
                
            }
            return PatAppointment;
        }
        public long SaveAppointment()
        {
            long Result = 0;
            try
            {
                PatAppointment PatAppointment = new PatAppointment();
                PatAppointment.AppointmentID= this.AppointmentID;
                PatAppointment.PatNum = this.PatNum;
                PatAppointment.OperatoryID = this.OperatoryID;
                PatAppointment.StartTime= this.StartTime;
                PatAppointment.EndTime= this.EndTime;
                PatAppointment.IsAllDay= this.IsAllDay;
                PatAppointment.Description = this.Description;
                PatAppointment.DoctorId = this.DoctorId;
                
                AppointmentEntity AppointmentEntity = new AppointmentEntity();
                Result= AppointmentEntity.Save(PatAppointment);
            }
            catch (Exception ex)
            {
                ProcessException("An error occurred while save PatAppointment, error: " + ex.Message, ex);             
            }
            return Result;
        }

        #endregion
    }
}