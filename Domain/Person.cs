using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System.ComponentModel;
using Russet.AIOmedicare.Domain.Base;

namespace Russet.AIOmedicare.Domain.Domain
{
    public abstract class Person: DomainObject ,IDataErrorInfo
    {
        public Guid GenderID { get; set; }
        public Guid? MaritalStatusID { get; set; }
        
        ///<summary>
        ///Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [NotNullValidator(ErrorMessage ="The First Name can't be null or empty.")]
        [StringLengthValidator(50, ErrorMessage ="The First Name length can't be greater than 50 characters.")]
        public string FirstName { get; set; }

        ///<summary>
        ///Gets or sets the middle name.
        /// </summary>
        /// <value>The middle name.</value>
        public string MiddleName { get; set; }

        ///<summary>
        ///Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        [NotNullValidator(ErrorMessage ="The Last Name can't be null or empty.")]
        [StringLengthValidator(50, ErrorMessage ="The Last Name length can't be greater than 50 characters.")]
        public string LastName { get; set; }
        

        ///<summary>
        ///Gets or sets the age.
        /// </summary>
        /// <value>The age.</value>
        ///reference = https://msdn.microsoft.com/en-in/library/ff647449.aspx
        //[NotNullValidator(ErrorMessage ="The Age can't be null or empty.")]
        //[RangeValidator(0, RangeBoundaryType.Inclusive,120, RangeBoundaryType.Inclusive)]
        public int Age { get; set; }

        //[NotNullValidator(ErrorMessage = "The Sex can't be null or empty.")]
        //public Guid SexID { get; set; }

        //public Guid? MaritalStatusID { get; set; }

        ///<summary>
        ///Gets the Date of Birth.
        /// </summary>
        /// <value>The Date of Birth.</value>
        public DateTime? DateOfBirth { get; set; }

        ///<summary>
        ///Gets the full name.
        /// </summary>
        /// <value>The full name.</value>
        public string FullName
        {
            get
            {
                return String.Format("{0} {1} {2}", Title, FirstName, LastName);
            }
        }

        ///<summary>
        ///Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        ///<summary>
        ///Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive { get; set; }

        ///<summary>
        ///Gets or sets a value indicating whether this instance is valid.
        /// </summary>
        /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
        public override bool IsValid
        {
            get
            {
                return Validate<Person>();
            }
        }

        ///<summary>
        ///Gets the default contact.
        /// </summary>
        /// <value>The default contact.</value>
        public Contact DefaultContact
        {
            get
            {
                if(Contacts == null)
                {
                    return null;
                }
                return Contacts.Where(x => x.IsDefault).FirstOrDefault();
            }
        }

        ///<summary>
        /// Adds the contact.
        /// </summary>
        /// <param name="contact">The contact.</param>
        public void AddContact(Contact contact)
        {
            if(Contacts == null)
            {
                Contacts = new List<Contact>();
            }

            // If there are not default address, set this one as default
            if(Contacts.Where(x => x.IsDefault).Count() < 1)
            {
                contact.IsDefault = true;
            }

            // If this is the new default address
            if (contact.IsDefault)
            {
                foreach(Contact cont in Contacts)
                {
                    cont.IsDefault = false;
                }
            }

            // If the address is not already in the list
            if(!Contacts.Any(x => x.PrimaryKey == contact.PrimaryKey))
            {
                Contacts.Add(contact);
                contact.Person = this;
            }
        }

        ///<summary>
        /// Removes the contact.
        /// </summary>
        /// <param name="contact">The contact.</param>
        public void RemoveContact(Contact contact)
        {
            if(Contacts == null)
            {
                return;
            }

            Contacts.Remove(contact);

            if (contact.IsDefault)
            {
                Contacts.FirstOrDefault().IsDefault = true;
            }
        }

        ///<summary>
        ///Gets the default address.
        /// </summary>
        /// <value>The default address.</value>
        public Address DefaultAddress
        {
            get
            {
                if (Addresses == null)
                {
                    return null;
                }
                return Addresses.Where(x => x.IsDefault).FirstOrDefault();
            }
        }

        ///<summary>
        /// Adds the address.
        /// </summary>
        /// <param name="contact">The address.</param>
        public void AddAddress(Address address)
        {
            if (Addresses == null)
            {
                Addresses = new List<Address>();
            }

            // If there are not default address, set this one as default
            if (Addresses.Where(x => x.IsDefault).Count() < 1)
            {
                address.IsDefault = true;
            }

            // If this is the new default address
            if (address.IsDefault)
            {
                foreach (Address addr in Addresses)
                {
                    addr.IsDefault = false;
                }
            }

            // If the address is not already in the list
            if (!Addresses.Any(x => x.PrimaryKey == address.PrimaryKey))
            {
                Addresses.Add(address);
                address.Person = this;
            }
        }

        ///<summary>
        /// Removes the address.
        /// </summary>
        /// <param name="contact">The address.</param>
        public void RemoveAddress(Address address)
        {
            if (Addresses == null)
            {
                return;
            }

            Addresses.Remove(address);

            if (address.IsDefault)
            {
                Addresses.FirstOrDefault().IsDefault = true;
            }
        }

        #region Navigation Properties
        ///<summary>
        ///Gets or sets the the addresses.
        /// </summary>
        /// <value>The addresses.</value>
        public virtual IList<Address> Addresses { get; set; }

        public virtual Account Account { get; set; }

        public virtual Gender Gender { get; set; }

        public virtual MaritalStatus MaritalStatus { get; set; }

        public virtual IList<Contact> Contacts { get; set; }
        
        #endregion

        #region Implementation of IDataErrorInfo
        
        ///<summary>
        /// Gets the error message for the property with the given name.
        /// </summary>
        /// <returns>
        /// The error message for the property. The default is an empty string ("").
        /// </returns>
        /// <param name="columnName">The name of the property whose error message to get.</param>
        public string this[string columnName]
        {
            get
            {
                return "Not Valid";
            }
        } 

        ///<summary>
        /// Gets the error message indicating what is wrong with this object.
        /// </summary>
        /// <returns>
        /// An error message indicating what is wrong with this object. The default is an empty string ("").
        /// </returns>
        public string Error
        {
            get { return null; }
        }
        
        #endregion
    }
}
