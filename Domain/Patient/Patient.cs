using AIOmedicare.Domain.Domain.Billing;
using AIOmedicare.Domain.Domain.Doctor;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System;
using System.Collections.Generic;

namespace AIOmedicare.Domain.Domain.Patient
{
    public class Patient : Person
    {
        public Guid PatientTypeID { get; set; }

        ///<summary>
        ///Gets or sets the father/husband/wife name.
        /// </summary>
        /// <value>The father/husband/wife name.</value>
        [StringLengthValidator(50, ErrorMessage = "The Husband or Wife Name length can't be greater than 50 characters.")]
        public string HusbandOrWifeName { get; set; }

        ///<summary>
        ///Gets or sets a value indicating whether this instance is valid.
        /// </summary>
        /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
        public override bool IsValid
        {
            get
            {
                return Validate<Patient>();
            }
        }

        public virtual BloodGroup BloodGroup { get; set; }
        public virtual PatientType PatientType { get; set; }

        public virtual IList<ServiceBill> ServiceBills { get; set; }
        public virtual IList<FeesBill> FeesBills { get; set; }
        public virtual IList<PatientRegistration> PatientRegistrations { get; set; }
        public virtual IList<PatientRelative> PatientRelatives { get; set; }
        public virtual IList<DoctorFeesHistory> DoctorFeesHistories { get; set; }
        public virtual IList<DoctorCommissionHistory> DoctorCommissionHistories { get; set; }
    }
}
