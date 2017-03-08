﻿using System;
using System.ComponentModel.DataAnnotations;
using AIOmedicare.Domain.Base;

namespace AIOmedicare.Domain.Domain
{
    public class Contact : DomainObject
    {
        public Guid PersonID { get; set; }
        public Guid? TypeID { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Required(ErrorMessage ="The Name is a mandatory field.")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        ///<summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>The number.</value>
        [Required(ErrorMessage = "The Number is a mandatory field.")]
        public string Number { get; set; }

        ///<summary>
        /// Gets or sets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        ///  <c>true</c> if this instance is default; otherwise, <c>false</c>.
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
                return Validate<Contact>();
            }
        }

        #region Navigation Properties

        // Navigation Property
        public virtual Person Person { get; set; }

        public virtual ContactType Type { get; set; }

        #endregion
    }
}
