using AIOmedicare.Domain.Domain.Patient;
using AIOmedicare.Domain.Domain.Service;
using AIOmedicare.Domain.Base;
using System;
using System.Collections.Generic;

namespace AIOmedicare.Domain.Domain.Billing
{
    public class ServiceBill : DomainObject
    {
        public Guid PatientID { get; set; }
        public Guid ServiceID { get; set; }

        public DateTime BillingDate { get; set; }

        ///<summary>
        ///Gets or sets a value indicating whether this instance is valid.
        /// </summary>
        /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
        public override bool IsValid
        {
            get
            {
                return Validate<ServiceBill>();
            }
        }

        public virtual Patient.Patient Patient { get; set; }
        public virtual Service.Service Service { get; set; }
        public virtual IList<ServiceBillPayment> Payments { get; set; }
    }
}
