using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System.Collections.Generic;
using Russet.AIOmedicare.Domain.Base;

namespace Russet.AIOmedicare.Domain.Domain.Employee
{
    public class Role : DomainObject
    {
        ///<summary>
        /// Gets or sets the name of role.
        /// </summary>
        /// <value>The Name of role.</value>
        [NotNullValidator(ErrorMessage = "The Name can't be null or empty.")]
        [StringLengthValidator(50, ErrorMessage = "The name can't be more than 50 characters.")]
        public string Name { get; set; }

        ///<summary>
        /// Gets or sets the description of role.
        /// </summary>
        /// <value>The Description of role.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is default; otherwise, <c>false</c>.
        /// </value>
        public bool IsDefault { get; set; }

        ///<summary>
        ///Gets or sets a value indicating whether this instance is valid.
        /// </summary>
        /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
        public override bool IsValid
        {
            get
            {
                return Validate<Role>();
            }
        }

        public virtual IList<Employee> Employees { get; set; }
    }
}
