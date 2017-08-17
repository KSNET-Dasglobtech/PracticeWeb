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
    using System.Collections.Generic;
    
    public partial class Appointment
    {
        public long AptNum { get; set; }
        public long PatNum { get; set; }
        public byte AptStatus { get; set; }
        public string Pattern { get; set; }
        public long Confirmed { get; set; }
        public short TimeLocked { get; set; }
        public long Op { get; set; }
        public string Note { get; set; }
        public long ProvNum { get; set; }
        public long ProvHyg { get; set; }
        public System.DateTime AptDateTime { get; set; }
        public long NextAptNum { get; set; }
        public long UnschedStatus { get; set; }
        public byte IsNewPatient { get; set; }
        public string ProcDescript { get; set; }
        public long Assistant { get; set; }
        public long ClinicNum { get; set; }
        public byte IsHygiene { get; set; }
        public System.DateTime DateTStamp { get; set; }
        public System.DateTime DateTimeArrived { get; set; }
        public System.DateTime DateTimeSeated { get; set; }
        public System.DateTime DateTimeDismissed { get; set; }
        public long InsPlan1 { get; set; }
        public long InsPlan2 { get; set; }
        public System.DateTime DateTimeAskedToArrive { get; set; }
        public string ProcsColored { get; set; }
        public int ColorOverride { get; set; }
        public long AppointmentTypeNum { get; set; }
    }
}