//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PracticeWeb.DB
{
    using System;
    
    public partial class AppointmentDetail
    {
        public long AppointmentID { get; set; }
        public Nullable<long> PatNum { get; set; }
        public string PatName { get; set; }
        public System.DateTime PatBirthdate { get; set; }
        public Nullable<int> OperatoryID { get; set; }
        public string OperatoryName { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public string StartTimezone { get; set; }
        public string EndTimezone { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public Nullable<bool> IsAllDay { get; set; }
        public string Description { get; set; }
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public string KeyColor { get; set; }
    }
}