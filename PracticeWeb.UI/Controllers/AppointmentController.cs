using Newtonsoft.Json;
using PracticeWeb.Common;
using PracticeWeb.DB;
using PracticeWeb.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeWeb.UI.Controllers
{
    public class AppointmentController : Controller
    {
        public ActionResult Index()
        {
            AppointmentModel model = new AppointmentModel();
            model.InitData();
            return View(model);
        }


        public JsonResult GetAppointmentList()
        {
            AppointmentModel model = new AppointmentModel();
            model.LoadAllAppointment();
            return Json(model.AppointmentDetailList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult AddUpdateAppointment(string models)
        {
            if(!string.IsNullOrEmpty(models))
            {
                List<AppointmentDTO> appointmentDTOList = JsonConvert.DeserializeObject<List<AppointmentDTO>>(models);
                if (appointmentDTOList != null && appointmentDTOList.Count > 0)
                {
                    AppointmentDTO appointmentDTO = appointmentDTOList[0];
                    AppointmentModel model  = new AppointmentModel();
                    long appointmentID = model.SaveAppointment(appointmentDTO);
                    if(appointmentID > 0)
                    {
                        Result result = model.GetAppointmentByID(appointmentID);
                        if(result.HasSuccess)
                        {
                            AppointmentDetail appointmentDetail = result.ResultObject as AppointmentDetail;
                            if(appointmentDetail != null)
                            {
                                List<AppointmentDetail> list = new List<AppointmentDetail>();
                                list.Add(appointmentDetail);
                                return Json(list, JsonRequestBehavior.AllowGet);
                            }
                        }
                    }
                }
            }
            return Json(new { Result = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult DeleteAppointment(string models)
        {
            List<AppointmentDTO> appointmentDTOList = new List<AppointmentDTO>();
            if (!string.IsNullOrEmpty(models))
            {
                appointmentDTOList = JsonConvert.DeserializeObject<List<AppointmentDTO>>(models);
                if (appointmentDTOList != null && appointmentDTOList.Count > 0)
                {
                    AppointmentDTO appointmentDTO = appointmentDTOList[0];
                    AppointmentModel model = new AppointmentModel();
                    model.DeleteAppointment(appointmentDTO.AppointmentID);
                }
            }
            return Json(appointmentDTOList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BookedAppointments(string patientSearch)
        {
            AppointmentModel model = new AppointmentModel();
            model.LoadBookedAppointment(patientSearch);
            return Json(model.BookedAppointmentDetailList, JsonRequestBehavior.AllowGet);
        }
        
    }
}