using PracticeWeb.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace PracticeWeb.Components
{
    public class PatientEntity : ComponentBase
    {
        /// <summary>
        ///  Method to create instance of Patient
        /// </summary>
        /// <returns></returns>
        public Patient CreatePatient()
        {
            return db.Patients.Create();
        }

        /// <summary>
        /// Method to save Patient add and edit 
        /// </summary>
        /// <param name="Lead"></param>
        public long Save(Patient patient)
        {
                patient.PatStatus = 1;
                patient.Position = 1;
                patient.Guarantor = 1;
                patient.EstBalance = 0;
                patient.PriProv = 1;
                patient.SecProv = 1;
                patient.FeeSched = 1;
                patient.BillingType = 1;
                patient.SchoolName = "A";
                patient.Bal_0_30 = 0;
                patient.Bal_31_60 = 0;
                patient.Bal_61_90 = 0;
                patient.BalOver90 = 0;
                patient.InsEst = 0;
                patient.BalTotal = 0;
                patient.GradeLevel = 1;
                patient.Urgency = 1;
                patient.DateFirstVisit = DateTime.Now; 
                patient.ClinicNum = 1;
                patient.PlannedIsDone = 1;
                patient.Premed = 1;
                patient.PreferConfirmMethod = 1;
                patient.PreferContactMethod = 1;
                patient.PreferRecallMethod = 1;
                patient.SchedDayOfWeek = 1;
                patient.AdmitDate = DateTime.Now;
                patient.PayPlanDue = 0;
                patient.SiteNum = 1;
                patient.DateTStamp = DateTime.Now;
                patient.ResponsParty = 1;
                patient.CanadianEligibilityCode = 1;
                patient.AskToArriveEarly = 1;
                patient.OnlinePassword = "A";
                patient.PreferContactConfidential = 1;
                patient.SuperFamily = 1;
                patient.TxtMsgOk = 1;
                patient.SmokingSnoMed = "A";
                patient.Country = "India";
                patient.DateTimeDeceased = DateTime.Now;
                patient.BillingCycleDay = 1;
                patient.SecUserNumEntry = 1;
                patient.SecDateEntry = DateTime.Now;
                patient.HasSuperBilling = 1;
                db.Patients.AddOrUpdate(patient);
            
            db.SaveChanges();
            return patient.PatNum;
        }

        /// <summary>
        /// Delete Patient based on patientId
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="leadId"></param>
        public void DeletePatient(long patNum)
        {
            db.DeletePatient(patNum);
        }

        /// <summary>
        /// Method to get Patient by patnum
        /// </summary>
        /// <param name="Lead"></param>
        public Patient GetPatientByPatNum(long patNum)
        {
            return db.Patients.Where(x => x.PatNum == patNum).FirstOrDefault();

        }

        /// <summary>
        /// Method to get all Patient
        /// </summary>
        /// <param name="Lead"></param>
        public List<PatientDetail> GetPatientList()
        {
            return db.GetPatients().ToList();
            
        }
    }
}
