//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace dconfianza.Model
{
    using System;
    
    public partial class spWorkerSelectByID_Result
    {
        public int WorkerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobilPhone { get; set; }
        public string WorkPhone { get; set; }
        public string Email { get; set; }
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public Nullable<double> Rating { get; set; }
        public string Resume { get; set; }
        public bool Active { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int CreatedByID { get; set; }
        public string CreatedByFirstName { get; set; }
        public string CreatedByLastName { get; set; }
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
    }
}
