using Newtonsoft.Json;
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

        public List<AppointmentDetail> AppointmentDetailList { get; set; }

        public List<PatientShortDetail> PatientList { get; set; }
        public List<Operatory> RoomList { get; set; }
        public string RoomListJson { get; set; }
        public List<Doctor> DoctorList { get; set; }

        public PatientModel PatientModel { get; set; }
        

        #endregion

        #region Method

        public Result InitData()
        {
            Result result = new Result();
            try
            {
                PatientEntity patientEntity = new PatientEntity();
                PatientList = patientEntity.GetPatientShortDetailList();

                AppointmentEntity appointmentEntity = new AppointmentEntity();
                RoomList = appointmentEntity.GetAllRooms();
                if (RoomList == null)
                {
                    RoomList = new List<Operatory>();
                }

                List<RoomDTO> roomDTOList = new List<RoomDTO>();
                foreach(var room in RoomList)
                {
                    roomDTOList.Add(new RoomDTO { text = room.OperatoryName, value = room.OperatoryID, color = room.KeyColor });
                }

                RoomListJson = JsonConvert.SerializeObject(roomDTOList);

                DoctorList = appointmentEntity.GetAllDoctor();

            }
            catch(Exception ex)
            {
                ProcessException("An error occurred while loading init detail for appointment, error: " + ex.Message, ex);
                return new Result("An error occurred while loading init detail for appointment");
            }
            return result;
        }

        public Result LoadAllAppointment()
        {
            Result result = new Result();
            try
            {
                AppointmentEntity AppointmentEntity = new AppointmentEntity();
                AppointmentDetailList = AppointmentEntity.GetAppointmentDetailList();
                if(AppointmentDetailList != null && AppointmentDetailList.Count > 0)
                {
                    foreach(var appointmentDetail in AppointmentDetailList)
                    {
                        
                        appointmentDetail.StartTime = ChangeDateTimeKindToUTC(appointmentDetail.StartTime);
                        appointmentDetail.EndTime = ChangeDateTimeKindToUTC(appointmentDetail.EndTime);
                    }
                }
            }
            catch (Exception ex)
            {
                ProcessException("An error occurred while loading all PatAppointment detail, error: " + ex.Message, ex);
                return new Result("An error occurred while loading all PatAppointment detail");
            }
            return result;
        }

        private DateTime? ChangeDateTimeKindToUTC(DateTime? date)
        {
            if (date.HasValue)
            {
                DateTime tmpDate = date.Value;
                return new DateTime(tmpDate.Year, tmpDate.Month, tmpDate.Day, tmpDate.Hour, tmpDate.Minute, tmpDate.Second, DateTimeKind.Utc);
            }
            return date;
        }

        public Result GetAppointmentByID(long appointmentID)
        {
            Result result = new Result();
            try
            {
                AppointmentEntity AppointmentEntity = new AppointmentEntity();
                AppointmentDetail appointmentDetail = AppointmentEntity.GetAppointmentDetailByID(appointmentID);
                if(appointmentDetail != null)
                {
                    appointmentDetail.StartTime = ChangeDateTimeKindToUTC(appointmentDetail.StartTime);
                    appointmentDetail.EndTime = ChangeDateTimeKindToUTC(appointmentDetail.EndTime);
                }
                result.ResultObject = appointmentDetail;
            }
            catch (Exception ex)
            {
                ProcessException("An error occurred while loading PatAppointment detail by id, error: " + ex.Message, ex);
                return new Result("An error occurred while loading PatAppointment detail by id");
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

        //public PatAppointment GetAppointmentDetails(long appointmentId)
        //{
        //    PatAppointment PatAppointment = new PatAppointment();
        //    AppointmentEntity AppointmentEntity = new AppointmentEntity();
        //    PatAppointment = AppointmentEntity.GetAppointmentByPatNum(appointmentId);
        //    if (PatAppointment != null)
        //    {
        //        this.AppointmentID = PatAppointment.AppointmentID;
        //        this.PatNum = PatAppointment.PatNum;
        //        this.OperatoryID = PatAppointment.OperatoryID;
        //        this.StartTime = PatAppointment.StartTime;
        //        this.EndTime = PatAppointment.EndTime;
        //        this.IsAllDay = PatAppointment.IsAllDay;
        //        this.Description = PatAppointment.Description;
        //        this.DoctorId = PatAppointment.DoctorID;

        //    }
        //    return PatAppointment;
        //}

        public long SaveAppointment(AppointmentDTO appointmentDTO)
        {
            long Result = 0;
            try
            {
                PatAppointment patAppointment = new PatAppointment();
                patAppointment.AppointmentID = appointmentDTO.AppointmentID;
                patAppointment.PatNum = appointmentDTO.PatNum;
                patAppointment.OperatoryID = appointmentDTO.OperatoryID;
                patAppointment.StartTime = appointmentDTO.StartTime;
                patAppointment.EndTime = appointmentDTO.EndTime;
                patAppointment.IsAllDay = appointmentDTO.IsAllDay;
                patAppointment.Description = appointmentDTO.Description;
                patAppointment.DoctorID = appointmentDTO.DoctorId;

                AppointmentEntity AppointmentEntity = new AppointmentEntity();
                Result = AppointmentEntity.Save(patAppointment);
            }
            catch (Exception ex)
            {
                ProcessException("An error occurred while save PatAppointment, error: " + ex.Message, ex);
            }
            return Result;
        }

        #endregion
    }

    public class RoomDTO
    {
        public string text { get; set; }
        public int value { get; set; }
        public string color { get; set; }
    }

    public class AppointmentDTO
    {
        public long AppointmentID { get; set; }
        public long PatNum { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public int OperatoryID { get; set; }
        public int DoctorId { get; set; }
        public bool IsAllDay { get; set; }
    }
}