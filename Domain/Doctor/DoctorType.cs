﻿using AIOmedicare.Domain.Base;
using System.Collections.Generic;

namespace AIOmedicare.Domain.Domain.Doctor
{
    public class DoctorType : DomainObject
    {
        public string Name { get; set; }

        public string Description { get; set; }

        ///<summary>
        ///Gets or sets a value indicating whether this instance is valid.
        /// </summary>
        /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
        public override bool IsValid
        {
            get
            {
                return Validate<DoctorType>();
            }
        }

        // Navigation Property
        public virtual IList<Doctor> Doctors { get; set; }
    }
}
