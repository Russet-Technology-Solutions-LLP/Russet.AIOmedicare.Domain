using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using AIOmedicare.Domain.Domain.Patient;
using AIOmedicare.Domain.Domain.Doctor;
using AIOmedicare.Domain.Domain.Billing;

namespace AIOmedicare.Domain.Domain.Employee
{
    public class User : Employee
    {
        ///<summary>
        /// Gets or sets the UserName of user.
        /// </summary>
        /// <value>The UserName.</value>
        [NotNullValidator(ErrorMessage = "The username can't be null or empty.")]
        [StringLengthValidator(20, ErrorMessage = "username length can't be more than 20 characters.")]
        public string UserName { get; set; }

        ///<summary>
        /// Gets or sets the Hashed password of user.
        /// </summary>
        /// <value>The Hashed Password.</value>
        [NotNullValidator(ErrorMessage = "The Password can't be null or empty.")]
        public string HashedPassword { get; set; }

        public string PasswordHint { get; set; }

        ///<summary>
        ///Gets the latest userlog.
        /// </summary>
        /// <value>The latest userlog.</value>
        public UserLog LatestUserLog
        {
            get
            {
                if (UserLogs == null)
                {
                    return null;
                }
                return UserLogs.Where(x => x.IsLatest).FirstOrDefault();
            }
        }

        ///<summary>
        /// Adds the userlog.
        /// </summary>
        /// <param name="userlog">The userlog.</param>
        public void AddUserLog(UserLog userlog)
        {
            if (UserLogs == null)
            {
                UserLogs = new List<UserLog>();
            }

            // set this one as latest.
            userlog.IsLatest = true;

            // If this is the new latest userlog.
            if (userlog.IsLatest)
            {
                foreach (UserLog log in UserLogs)
                {
                    log.IsLatest = false;
                }
            }

            // If the userlog is not already in the list
            if (!UserLogs.Any(x => x.PrimaryKey == userlog.PrimaryKey))
            {
                UserLogs.Add(userlog);
                userlog.User = this;
            }
        }

        ///<summary>
        /// Removes the userlog.
        /// </summary>
        /// <param name="userlog">The userlog.</param>
        public void RemoveUserLog(UserLog userlog)
        {
            if (UserLogs == null)
            {
                return;
            }

            UserLogs.Remove(userlog);

            if (userlog.IsLatest)
            {
                UserLogs.LastOrDefault().IsLatest = true;
            }
        }

        ///<summary>
        /// Gets or sets the user permissions.
        /// </summary>
        /// <value>The user permissions.</value>
        /******* Not needed right now.
        public virtual IList<Permission> Permissions { get; set; }
        ****************/
        ///<summary>
        /// Gets or sets the user logs.
        /// </summary>
        /// <value>The user logs.</value>
        public virtual IList<UserLog> UserLogs { get; set; }
        public virtual IList<PatientRegistration> PatientRegistrations { get; set; }
        public virtual IList<DoctorFeesHistory> DoctorFeesHistories { get; set; }
        public virtual IList<DoctorCommissionHistory> DoctorCommissionHistories { get; set; }
        public virtual IList<FeesBill> FeesBills { get; set; }
    }
}
