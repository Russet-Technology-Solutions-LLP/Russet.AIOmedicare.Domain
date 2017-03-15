using System;
using System.Collections.Generic;
using Russet.AIOmedicare.Domain.Base;

namespace Russet.AIOmedicare.Domain.Domain
{
    public class Account : DomainObject
    {
        public float Balance { get; set; }

        public DateTime AccountCreated { get; set; }

        public DateTime AccountClosed { get; set; }

        public DateTime LastTransaction { get; set; }

        public Guid TypeID { get; set; }
        // status of the account active or not.
        public bool isActive { get; set; }

        ///<summary>
        ///Gets or sets a value indicating whether this instance is valid.
        /// </summary>
        /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
        public override bool IsValid
        {
            get
            {
                return Validate<Account>();
            }
        }

        #region Navigation Properties
        public virtual Person Person { get; set; }

        public virtual AccountType Type { get; set; }

        public virtual IList<Transaction> Transactions { get; set; }
        #endregion
    }
}
