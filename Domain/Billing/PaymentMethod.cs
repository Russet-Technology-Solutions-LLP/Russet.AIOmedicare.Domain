using AIOmedicare.Domain.Base;
using System.Collections.Generic;

namespace AIOmedicare.Domain.Domain.Billing
{
    public class PaymentMethod : DomainObject
    {
        public string Method { get; set; }
        public string Remark { get; set; }

        ///<summary>
        ///Gets or sets a value indicating whether this instance is valid.
        /// </summary>
        /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
        public override bool IsValid
        {
            get
            {
                return Validate<PaymentMethod>();
            }
        }

        public virtual IList<Payment> Payments { get; set; }
    }
}
