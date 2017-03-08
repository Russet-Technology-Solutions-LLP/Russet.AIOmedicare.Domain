using AIOmedicare.Domain.Base;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System.Collections.Generic;

namespace AIOmedicare.Domain.Domain
{
    public class Gender : DomainObject
    {
        ///<summary>
        /// Gets or sets the name of Person Sex.
        /// </summary>
        /// <value>The Name of Person Sex.</value>
        [NotNullValidator(ErrorMessage = "The Name can't be null or empty.")]
        [StringLengthValidator(50, ErrorMessage = "The name can't be more than 50 characters.")]
        public string Name { get; set; }

        ///<summary>
        /// Gets or sets the description of Person Sex.
        /// </summary>
        /// <value>The Description of Person Sex.</value>
        public string Description { get; set; }

        ///<summary>
        ///Gets or sets a value indicating whether this instance is valid.
        /// </summary>
        /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
        public override bool IsValid
        {
            get
            {
                return Validate<Gender>();
            }
        }

        public virtual IList<Person> Persons { get; set; }
    }
}
