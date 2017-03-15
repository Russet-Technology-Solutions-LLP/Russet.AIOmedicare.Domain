using Russet.AIOmedicare.Domain.Base;
using System;
using System.Collections.Generic;

namespace Russet.AIOmedicare.Domain.Domain.Service
{
    public class Service : DomainObject
    {
        public Guid CategoryID { get; set; }
        public string Name { get; set; }

        public double Cost { get; }

        ///<summary>
        ///Gets or sets a value indicating whether this instance is valid.
        /// </summary>
        /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
        public override bool IsValid
        {
            get
            {
                return Validate<Service>();
            }
        }

        public virtual ServiceCategory Category { get; set; }
        public virtual IList<ServiceBill> ServiceBills { get; set; }
        public virtual IList<DoctorCommissionHistory> DoctorCommissionHistories { get; set; }
    }
}
