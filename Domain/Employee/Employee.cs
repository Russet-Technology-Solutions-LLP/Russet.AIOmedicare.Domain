using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace AIOmedicare.Domain.Domain.Employee
{
    public class Employee : Person
    {
        // Navigation Property.
        public virtual IList<Role> Roles { get; set; }

        ///<summary>
        /// Gets or sets the joining date of the employee.
        /// </summary>
        /// <value>The joining date.</value>
        [NotNullValidator(ErrorMessage = "The Joining Date can't be null or empty.")]
        public DateTime? JoiningDate { get; set; } 

        ///<summary>
        /// Gets or sets the leaving date of the employee.
        /// </summary>
        /// <value>The Leaving Date.</value>
        public DateTime? LeavingDate { get; set; }

        ///<summary>
        ///Gets the default role.
        /// </summary>
        /// <value>The default role.</value>
        public Role DefaultRole
        {
            get
            {
                if (Roles == null)
                {
                    return null;
                }
                return Roles.Where(x => x.IsDefault).FirstOrDefault();
            }
        }

        ///<summary>
        /// Adds the role.
        /// </summary>
        /// <param name="role">The role.</param>
        public void AddRole(Role role)
        {
            if (Roles == null)
            {
                Roles = new List<Role>();
            }

            // If there are not default role, set this one as default
            if (Roles.Where(x => x.IsDefault).Count() < 1)
            {
                role.IsDefault = true;
            }

            // If this is the new default role
            if (role.IsDefault)
            {
                foreach (Role rl in Roles)
                {
                    rl.IsDefault = false;
                }
            }

            // If the role is not already in the list
            if (!Roles.Any(x => x.PrimaryKey == role.PrimaryKey))
            {
                Roles.Add(role);
            }
        }

        ///<summary>
        /// Removes the role.
        /// </summary>
        /// <param name="role">The role.</param>
        public void RemoveRole(Role role)
        {
            if (Roles == null)
            {
                return;
            }

            Roles.Remove(role);

            if (role.IsDefault)
            {
                Roles.FirstOrDefault().IsDefault = true;
            }
        }
    }
}
