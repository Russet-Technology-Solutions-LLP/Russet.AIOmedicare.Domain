using System;

namespace Russet.AIOmedicare.Domain.Domain.Patient
{
    public class PatientRelative : Person
    {
        public Guid PatientID { get; set; }

        ///<summary>
        ///Gets or sets a value indicating whether this instance is valid.
        /// </summary>
        /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
        public override bool IsValid
        {
            get
            {
                return Validate<PatientRelative>();
            }
        }
        public virtual Patient Patient { get; set; }
        public virtual PatientRegistration PatientRegistration { get; set; }
    }
}
