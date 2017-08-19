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
    public class PatientModel : ModelBase
    {
        public PatientModel(Type childClassType)
            : base(childClassType)
        { }

        public PatientModel()
            : base(typeof(PatientModel))
        { }

        #region Field

        public List<PatientDetail> PatientList { get; set; }

        public long PatNum{ get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Please select title.")]
        public string Title { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please enter first name.")]
        public string FName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please enter last name.")]
        public string LName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleI { get; set; }
        public string Suffix { get; set; }
        public string Greeting { get; set; }
        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Please select gender.")]
        public byte Gender { get; set; }
        public string Social { get; set; }

        [UIHint("DateNullable")]
        [Required(ErrorMessage = "Please select birth year.")]
        public DateTime? BirthDate { get; set; }
        public int BirthYear { get; set; }
        [Required(ErrorMessage = "Please select birth month.")]
        public int BirthMonth { get; set; }
        [Required(ErrorMessage = "Please select birth day.")]
        public int BirthDay { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "State")]
        public string State { get; set; }
        [Display(Name = "Postal Code")]
        public string Zip { get; set; }
        [AllowHtml]
        [Display(Name = "Email Address")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Invalid Email Address")]

        public string Email { get; set; }

        public string Orthodontist { get; set; }
        public string Location { get; set; }
        [Display(Name = "Contact Info")]

        public string HmPhone { get; set; }


        //public string Preferred { get; set; }
        //public byte PatStatus { get; set; }

        //public byte Position { get; set; }

        //public string SSN { get; set; }
        //public string Address { get; set; }
        //public string Address2 { get; set; }
        //public string City { get; set; }
        //public string State { get; set; }
        //public string Zip { get; set; }
        //public string HmPhone { get; set; }
        //public string WkPhone { get; set; }
        //public string WirelessPhone { get; set; }
        //public long Guarantor { get; set; }
        //public string CreditType { get; set; }
        //public string Email { get; set; }
        //public string Salutation { get; set; }
        //public double EstBalance { get; set; }
        //public long PriProv { get; set; }
        //public long SecProv { get; set; }
        //public long FeeSched { get; set; }
        //public long BillingType { get; set; }
        //public string ImageFolder { get; set; }
        //public string AddrNote { get; set; }
        //public string FamFinUrgNote { get; set; }
        //public string MedUrgNote { get; set; }
        //public string ApptModNote { get; set; }
        //public string StudentStatus { get; set; }
        //public string SchoolName { get; set; }
        //public string ChartNumber { get; set; }
        //public string MedicaidID { get; set; }
        //public double Bal_0_30 { get; set; }
        //public double Bal_31_60 { get; set; }
        //public double Bal_61_90 { get; set; }
        //public double BalOver90 { get; set; }
        //public double InsEst { get; set; }
        //public double BalTotal { get; set; }
        //public long EmployerNum { get; set; }
        //public string EmploymentNote { get; set; }
        //public string County { get; set; }
        //public short GradeLevel { get; set; }
        //public short Urgency { get; set; }
        //public System.DateTime DateFirstVisit { get; set; }
        //public long ClinicNum { get; set; }
        //public string HasIns { get; set; }
        //public string TrophyFolder { get; set; }
        //public byte PlannedIsDone { get; set; }
        //public byte Premed { get; set; }
        //public string Ward { get; set; }
        //public byte PreferConfirmMethod { get; set; }
        //public byte PreferContactMethod { get; set; }
        //public byte PreferRecallMethod { get; set; }
        //public Nullable<System.DateTime> SchedBeforeTime { get; set; }
        //public Nullable<System.DateTime> SchedAfterTime { get; set; }
        //public byte SchedDayOfWeek { get; set; }
        //public string Language { get; set; }
        //public System.DateTime AdmitDate { get; set; }

        //public double PayPlanDue { get; set; }
        //public long SiteNum { get; set; }
        //public System.DateTime DateTStamp { get; set; }
        //public long ResponsParty { get; set; }
        //public short CanadianEligibilityCode { get; set; }
        //public int AskToArriveEarly { get; set; }
        //public string OnlinePassword { get; set; }
        //public short PreferContactConfidential { get; set; }
        //public long SuperFamily { get; set; }
        //public short TxtMsgOk { get; set; }
        //public string SmokingSnoMed { get; set; }
        //public string Country { get; set; }
        //public System.DateTime DateTimeDeceased { get; set; }
        //public int BillingCycleDay { get; set; }
        //public long SecUserNumEntry { get; set; }
        //public System.DateTime SecDateEntry { get; set; }
        //public short HasSuperBilling { get; set; }

        #endregion

        #region Method

        public Result LoadAllPatient()
        {
            Result result = new Result();
            try
            {
                PatientEntity patientEntity = new PatientEntity();
               PatientList = patientEntity.GetPatientList();
            }
            catch(Exception ex)
            {
                ProcessException("An error occurred while loading all patient detail, error: " + ex.Message, ex);
                return new Result("An error occurred while loading all patient detail");
            }
            return result;
        }

        public Result DeletePatient(long patNum)
        {
            Result result = new Result();
            try
            {
                PatientEntity patientEntity = new PatientEntity();
                patientEntity.DeletePatient(patNum);
            }
            catch (Exception ex)
            {
                ProcessException("An error occurred while deleting patient, error: " + ex.Message, ex);
                return new Result("An error occurred while deleting patient");
            }
            return result;
        }

        public Patient GetPatientDetails(long patNum)
        {
            Patient patient = new Patient();
            PatientEntity patientEntity = new PatientEntity();
            patient = patientEntity.GetPatientByPatNum(patNum);
            if(patient!=null)
            {
                this.PatNum = patient.PatNum;
                this.Title = patient.Title;
                this.FName = patient.FName;
                this.LName = patient.LName;
                this.MiddleI = patient.MiddleI;
                this.Gender = patient.Gender;
                this.BirthDate = patient.Birthdate;
                this.Address = patient.Address;
                this.City = patient.City;
                this.State = patient.State;
                this.Zip = patient.Zip;
                this.HmPhone = patient.HmPhone;
            }
            return patient;
        }
        public long SavePatient()
        {
            long Result = 0;
            try
            {
                Patient patient = new Patient();
                patient.PatNum = this.PatNum;
                patient.Title = this.Title;
                patient.FName = this.FName;
                patient.LName = this.LName;
                patient.MiddleI = this.MiddleI;
                patient.Gender = this.Gender;
                patient.Birthdate = (DateTime)this.BirthDate;
                patient.Email = this.Email;
                patient.Address = this.Address;
                patient.City = this.City;
                patient.State = this.State;
                patient.Zip = this.Zip;
                patient.HmPhone = this.HmPhone;

                PatientEntity patientEntity = new PatientEntity();
                Result= patientEntity.Save(patient);
            }
            catch (Exception ex)
            {
                ProcessException("An error occurred while save patient, error: " + ex.Message, ex);             
            }
            return Result;
        }

        #endregion
    }
}