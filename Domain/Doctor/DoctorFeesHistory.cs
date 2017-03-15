using AIOmedicare.Domain.Domain.Employee;
using Russet.AIOmedicare.Domain.Base;
using System;

namespace Russet.AIOmedicare.Domain.Domain.Doctor
{
    public class DoctorFeesHistory : DomainObject
    {
        public DateTime RegistrationDate { get; set; }
        public Guid DoctorID { get; set; }
        public Guid DoctorFeesID { get; set; }
        public Guid UserID { get; set; }
        public Guid PatientID { get; set; }
        // set this unpaid untill it is paid to the doctor.
        public string PaidToDoctor { get; set; }

        ///<summary>
        ///Gets or sets a value indicating whether this instance is valid.
        /// </summary>
        /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
        public override bool IsValid
        {
            get
            {
                return Validate<DoctorFeesHistory>();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is latest.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is latest; otherwise, <c>false</c>.
        /// </value>
        public bool IsLatest { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual DoctorFees DoctorFees { get; set; }
        public virtual User User { get; set; }
        public virtual Patient.Patient Patient { get; set; }
    }
}
