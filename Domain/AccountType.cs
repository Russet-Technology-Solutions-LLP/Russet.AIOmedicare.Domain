using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIOmedicare.Domain.Base;

namespace AIOmedicare.Domain.Domain
{
    public class AccountType : DomainObject
    {
        public string Name { get; set; }

        ///<summary>
        ///Gets or sets a value indicating whether this instance is valid.
        /// </summary>
        /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
        public override bool IsValid
        {
            get
            {
                return Validate<AccountType>();
            }
        }

        // Navigation property.
        public virtual IList<Account> Accounts { get; set; }
    }
}
