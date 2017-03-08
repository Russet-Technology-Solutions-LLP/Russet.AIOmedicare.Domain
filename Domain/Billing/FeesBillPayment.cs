using AIOmedicare.Domain.Base;
using System;

namespace AIOmedicare.Domain.Domain.Billing
{
    public class FeesBillPayment : DomainObject
    {
        public Guid FeesBillID { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual FeesBill FeesBill { get; set; } 
    }
}
