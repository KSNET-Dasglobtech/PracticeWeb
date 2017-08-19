using PracticeWeb.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeWeb.Components
{
    public class AppointmentEntity : ComponentBase
    {
        /// <summary>
        ///  Method to create instance of PatAppointment
        /// </summary>
        /// <returns></returns>
        public PatAppointment CreateAppointment()
        {
            return db.PatAppointments.Create();
        }

        /// <summary>
        /// Method to save PatAppointment add and edit 
        /// </summary>
        /// <param name="Lead"></param>
        public long Save(PatAppointment PatAppointment)
        {
            //PatAppointment.PatStatus = 1;
            //PatAppointment.Position = 1;
            //PatAppointment.Guarantor = 1;
            //PatAppointment.EstBalance = 0;
            //PatAppointment.PriProv = 1;
            //PatAppointment.SecProv = 1;
            //PatAppointment.FeeSched = 1;
            //PatAppointment.BillingType = 1;
            //PatAppointment.SchoolName = "A";
            //PatAppointment.Bal_0_30 = 0;
            //PatAppointment.Bal_31_60 = 0;
            //PatAppointment.Bal_61_90 = 0;
            //PatAppointment.BalOver90 = 0;
            //PatAppointment.InsEst = 0;
            //PatAppointment.BalTotal = 0;
            //PatAppointment.GradeLevel = 1;
            //PatAppointment.Urgency = 1;
            //PatAppointment.DateFirstVisit = DateTime.Now;
            //PatAppointment.ClinicNum = 1;
            //PatAppointment.PlannedIsDone = 1;
            //PatAppointment.Premed = 1;
            //PatAppointment.PreferConfirmMethod = 1;
            //PatAppointment.PreferContactMethod = 1;
            //PatAppointment.PreferRecallMethod = 1;
            //PatAppointment.SchedDayOfWeek = 1;
            //PatAppointment.AdmitDate = DateTime.Now;
            //PatAppointment.PayPlanDue = 0;
            //PatAppointment.SiteNum = 1;
            //PatAppointment.DateTStamp = DateTime.Now;
            //PatAppointment.ResponsParty = 1;
            //PatAppointment.CanadianEligibilityCode = 1;
            //PatAppointment.AskToArriveEarly = 1;
            //PatAppointment.OnlinePassword = "A";
            //PatAppointment.PreferContactConfidential = 1;
            //PatAppointment.SuperFamily = 1;
            //PatAppointment.TxtMsgOk = 1;
            //PatAppointment.SmokingSnoMed = "A";
            //PatAppointment.Country = "India";
            //PatAppointment.DateTimeDeceased = DateTime.Now;
            //PatAppointment.BillingCycleDay = 1;
            //PatAppointment.SecUserNumEntry = 1;
            //PatAppointment.SecDateEntry = DateTime.Now;
            //PatAppointment.HasSuperBilling = 1;
            db.PatAppointments.AddOrUpdate(PatAppointment);

            db.SaveChanges();
            return PatAppointment.AppointmentID;
        }

        /// <summary>
        /// Delete PatAppointment based on AppointmentId
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="leadId"></param>
        public void DeleteAppointment(long patNum)
        {
            //db.DeleteAppointment(patNum);
        }

        /// <summary>
        /// Method to get PatAppointment by patnum
        /// </summary>
        /// <param name="Lead"></param>
        public PatAppointment GetAppointmentByPatNum(long appointmentId)
        {
            return db.PatAppointments.Where(x => x.AppointmentID == appointmentId).FirstOrDefault();

        }

        /// <summary>
        /// Method to get all PatAppointment
        /// </summary>
        /// <param name="Lead"></param>
        public List<GetAppointments_Result> GetAppointmentList()
        {
            return  db.GetAppointments().ToList();           

        }
    }
}
