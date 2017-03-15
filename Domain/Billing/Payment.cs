using Russet.AIOmedicare.Domain.Base;
using System;

namespace Russet.AIOmedicare.Domain.Domain.Billing
{
    public class Payment : DomainObject
    {
        public Guid PaymentMethodID { get; set; }
        public Guid PaymentStatusID { get; set; }
        public DateTime PaymentDate { get; set; }
        
        ///<summary>
        ///Gets or sets a value indicating whether this instance is valid.
        /// </summary>
        /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
        public override bool IsValid
        {
            get
            {
                return Validate<Payment>();
            }
        }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual PaymentStatus PaymentStatus { get; set; }

        public virtual FeesBillPayment FeesBillPayment { get; set; }
        public virtual ServiceBillPayment ServiceBillPayment { get; set; }
    }
}
