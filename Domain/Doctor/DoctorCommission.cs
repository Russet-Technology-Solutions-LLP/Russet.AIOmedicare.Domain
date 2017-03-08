using AIOmedicare.Domain.Base;
using System;
using System.Collections.Generic;

namespace AIOmedicare.Domain.Domain.Doctor
{
    public class DoctorCommission : DomainObject
    {
        public Guid DoctorID { get; set; }
        public Guid CommissionTypeID { get; set; }
        public string CommissionName { get; set; }
        public double CommissionRate { get; set; }
        public string Remark { get; set; }

        ///<summary>
        ///Gets or sets a value indicating whether this instance is valid.
        /// </summary>
        /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
        public override bool IsValid
        {
            get
            {
                return Validate<DoctorCommission>();
            }
        }

        ///<summary>
        /// Gets or sets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        ///  <c>true</c> if this instance is default; otherwise, <c>false</c>.
        /// </value>
        public bool IsDefault { get; set; }

        public virtual DoctorCommissionType DoctorCommissionType { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual IList<DoctorCommissionHistory> DoctorCommissionHistories { get; set; }
    }
}
