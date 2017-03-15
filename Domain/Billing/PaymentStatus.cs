using Russet.AIOmedicare.Domain.Base;
using System.Collections.Generic;

namespace Russet.AIOmedicare.Domain.Domain.Billing
{
    public class PaymentStatus : DomainObject
    {
        public string Status { get; set; }
        public string Remark { get; set; }

        ///<summary>
        ///Gets or sets a value indicating whether this instance is valid.
        /// </summary>
        /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
        public override bool IsValid
        {
            get
            {
                return Validate<PaymentStatus>();
            }
        }

        public virtual IList<Payment> Payments { get; set; }
    }
}
