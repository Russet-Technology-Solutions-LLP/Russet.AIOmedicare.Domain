using AIOmedicare.Domain.Base;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace AIOmedicare.Domain.Domain.Patient
{
    public class BloodGroup : DomainObject
    {
        ///<summary>
        ///Gets or sets the blood group name.
        /// </summary>
        /// <value>The blood group name.</value>
        [NotNullValidator(ErrorMessage = "The Blood Group Name can't be null or empty.")]
        [StringLengthValidator(50, ErrorMessage = "The Blood Group Name length can't be greater than 50 characters.")]
        public string Name { get; set; }

        ///<summary>
        /// Gets or sets the description of Blood Group.
        /// </summary>
        /// <value>The Description of Blood Group.</value>
        public string Description { get; set; }

        ///<summary>
        ///Gets or sets a value indicating whether this instance is valid.
        /// </summary>
        /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
        public override bool IsValid
        {
            get
            {
                return Validate<BloodGroup>();
            }
        }

        public virtual Patient Patient { get; set; }
    }
}
