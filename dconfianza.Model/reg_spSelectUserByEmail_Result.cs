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
    
    public partial class reg_spSelectUserByEmail_Result
    {
        public int UserID { get; set; }
        public Nullable<long> FacebookID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public string ResetPasswordToken { get; set; }
        public Nullable<System.DateTime> ResetPasswordRequestDate { get; set; }
        public Nullable<int> Gender { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> ActivationDate { get; set; }
        public Nullable<System.DateTime> TerminationDate { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public Nullable<bool> IsLockedOut { get; set; }
        public Nullable<System.DateTime> LastLoginDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
        public Nullable<int> LastUpdatedBy { get; set; }
    }
}