using System;
using AIOmedicare.Domain.Base;

namespace AIOmedicare.Domain.Domain.Employee
{
    public class UserLog : DomainObject
    {
        public Guid UserID { get; set; }
        ///<summary>
        /// Gets or sets the login time.
        /// </summary>
        /// <value>The Login time.</value>
        public DateTime? LoginTime { get; set; }

        ///<summary>
        /// Gets or sets the logout time.
        /// </summary>
        /// <value>The logout time.</value>
        public DateTime? LogoutTime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is latest.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is latest; otherwise, <c>false</c>.
        /// </value>
        public bool IsLatest { get; set; }

        ///<summary>
        ///Gets or sets a value indicating whether this instance is valid.
        /// </summary>
        /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
        public override bool IsValid
        {
            get
            {
                return Validate<UserLog>();
            }
        }

        // Navigation Property
        public virtual User User { get; set; }
    }
}
