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
    
    public partial class Operatory
    {
        public Operatory()
        {
            this.PatAppointments = new HashSet<PatAppointment>();
        }
    
        public int OperatoryID { get; set; }
        public string OperatoryName { get; set; }
        public string KeyColor { get; set; }
    
        public virtual ICollection<PatAppointment> PatAppointments { get; set; }
    }
}
