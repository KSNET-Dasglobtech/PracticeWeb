using PracticeWeb.Common;
using PracticeWeb.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeWeb.UI.Controllers
{
    public class PatientController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetPatientList()
        {
            PatientModel model = new PatientModel();
            model.LoadAllPatient();
            return Json(model.PatientList, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult GetPatientDetails(long patNum)
        {
            PatientModel model = new PatientModel();
            var patient = model.GetPatientDetails(patNum);
            return Json(patient, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeletePatient(long patnum)
        {
            PatientModel model = new PatientModel();
            Result result = model.DeletePatient(patnum);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SavePetient(string patNum,string title, string firstName, string lastName,
            string middleName, string gender, string birthdate, string address, string city, string state, string pinCode, string phone)
        {
            if (string.IsNullOrEmpty(patNum))
                patNum = "0";

            PatientModel patient = new Models.PatientModel();
            patient.PatNum = Convert.ToInt64(patNum);
            patient.Title = title;
            patient.FName = firstName;
            patient.LName = lastName;
            patient.MiddleI = middleName;
            patient.Gender = Convert.ToByte(gender);
            if (!string.IsNullOrEmpty(birthdate))
                patient.BirthDate = Convert.ToDateTime(birthdate);
            else
                patient.BirthDate = DateTime.Now;
            patient.Address = address;
            patient.City = city;
            patient.State = state;
            patient.Zip = pinCode;
            patient.HmPhone = phone;

            long Result= patient.SavePatient();

             return Json(new { result = "Success" });
        }


    }
}