using System;
using System.ComponentModel.DataAnnotations;
using AIOmedicare.Domain.Base;

namespace AIOmedicare.Domain.Domain
{
    public class Address : DomainObject
    {
        public Guid PersonID { get; set; }
        
        // Nullable TypeID for one to many relationships
        public Guid? TypeID { get; set; }
        
        /// <summary>
        /// Gets or sets the address line1.
        /// </summary>
        /// <value>The address line1.</value>
        [Required(ErrorMessage = "The AddressLine1 is a mandatory field")]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets the address line2.
        /// </summary>
        /// <value>The address line2.</value>
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the town.
        /// </summary>
        /// <value>The town.</value>
        public string Town { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        //[Required(ErrorMessage = "The State is a mandatory field")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>The country.</value>
        //[Required(ErrorMessage = "The Country is a mandatory field")]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        /// <value>The zip code.</value>
        //[Required(ErrorMessage = "The ZipCode is a mandatory field")]
        public string ZipCode { get; set; }

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
                return Validate<Address>();
            }
        }

        #region Navigation Properties

        public virtual Person Person { get; set; }

        public virtual AddressType Type { get; set; }

        #endregion
    }
}
