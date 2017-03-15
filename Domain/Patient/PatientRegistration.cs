using Russet.AIOmedicare.Domain.Base;
using Russet.AIOmedicare.Domain.Domain.Employee;
using System;

namespace Russet.AIOmedicare.Domain.Domain.Patient
{
    public class PatientRegistration : DomainObject
    {
        public long RegistrationNo { get; set; }
        public Guid PatientID { get; set; }
        public Guid DoctorID { get; set; }
        public Guid UserID { get; set; }
        public int Validity { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        ///<summary>
        ///Gets or sets a value indicating whether this instance is valid.
        /// </summary>
        /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
        public override bool IsValid
        {
            get
            {
                return Validate<PatientRegistration>();
            }
        }

        public virtual Patient Patient { get; set; }
        // brought by or registered by
        public virtual PatientRelative PatientRelative { get; set; }
        // Reffered by or treatment by.
        public virtual Doctor.Doctor Doctor { get; set; }
        // registered by (staff, employee or staff)
        public virtual User User { get; set; }
    }
}
