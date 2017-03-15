using Russet.AIOmedicare.Domain.Base;
using System;
using System.Collections.Generic;

namespace Russet.AIOmedicare.Domain.Domain.Doctor
{
    public class DoctorFees : DomainObject
    {
        public Guid DoctorID { get; set; }

        public string FeesName { get; set; }

        public double Fees { get; set; }

        public string Remark { get; set; }
        
        ///<summary>
        ///Gets or sets a value indicating whether this instance is valid.
        /// </summary>
        /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
        public override bool IsValid
        {
            get
            {
                return Validate<DoctorFees>();
            }
        }

        ///<summary>
        /// Gets or sets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        ///  <c>true</c> if this instance is default; otherwise, <c>false</c>.
        /// </value>
        public bool IsDefault { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual IList<DoctorFeesHistory> DoctorFeesHistories { get; set; }
        public virtual IList<FeesBill> FeesBills { get; set; }
    }
}
