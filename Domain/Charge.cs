using AIOmedicare.Domain.Base;

namespace AIOmedicare.Domain.Domain
{
    public class Charge : DomainObject
    {
        public string ChargeName { get; set; }

        public double Cost { get; set; }

        public string Remark { get; set; }
    }
}
