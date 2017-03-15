using System;
using Russet.AIOmedicare.Domain.Base;

namespace Russet.AIOmedicare.Domain.Domain
{
    public class Permission : DomainObject
    {
        public Nullable<Guid> UserID { get; set; }
        ///<summary>
        /// Gets or sets the allowed modules.
        /// </summary>
        /// <value>The allowed modules.</value>
        public string AllowedModule { get; set; }

        // Navigation Property
        //public virtual User User { get; set; }
    }
}
