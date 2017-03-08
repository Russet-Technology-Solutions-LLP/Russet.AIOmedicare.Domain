using System;
using AIOmedicare.Domain.Base;

namespace AIOmedicare.Domain.Domain
{
    public class Transaction : DomainObject
    {
        public Guid AccountID { get; set; }
        public DateTime DateTime { get; set; }

        public TransactionType Type { get; set; }

        public float Amount { get; set; }

        public string Remark { get; set; }

        ///<summary>
        ///Gets or sets a value indicating whether this instance is valid.
        /// </summary>
        /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
        public override bool IsValid
        {
            get
            {
                return Validate<Transaction>();
            }
        }

        #region Navigation Properties

        public virtual Account Account { get; set; }

        #endregion
    }
}
