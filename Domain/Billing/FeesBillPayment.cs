using Russet.AIOmedicare.Domain.Base;
using System;

namespace Russet.AIOmedicare.Domain.Domain.Billing
{
    public class FeesBillPayment : DomainObject
    {
        public Guid FeesBillID { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual FeesBill FeesBill { get; set; } 
    }
}
