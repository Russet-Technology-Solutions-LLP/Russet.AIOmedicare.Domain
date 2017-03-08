using AIOmedicare.Domain.Base;
using System;

namespace AIOmedicare.Domain.Domain.Billing
{
    public class ServiceBillPayment : DomainObject
    {
        public Guid ServiceBillID { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual ServiceBill ServiceBill { get; set; } 
    }
}
