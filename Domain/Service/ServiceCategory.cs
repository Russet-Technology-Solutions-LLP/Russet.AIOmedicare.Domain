using AIOmedicare.Domain.Base;
using System.Collections.Generic;

namespace AIOmedicare.Domain.Domain.Service
{
    public class ServiceCategory : DomainObject
    {
        public string Name { get; set; }
        public string Remark { get; set; }

        ///<summary>
        ///Gets or sets a value indicating whether this instance is valid.
        /// </summary>
        /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
        public override bool IsValid
        {
            get
            {
                return Validate<ServiceCategory>();
            }
        }

        public virtual IList<Service> Services { get; set; }
    }
}
