using AIOmedicare.Domain.Domain.Patient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Russet.AIOmedicare.Domain.Domain.Doctor
{
    public class Doctor : Person
    {
        public Guid DoctorTypeID { get; set; }
        public Guid DoctorDepartmentID { get; set; }
        public double Salary { get; set; }

        ///<summary>
        ///Gets or sets a value indicating whether this instance is valid.
        /// </summary>
        /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
        public override bool IsValid
        {
            get
            {
                return Validate<Doctor>();
            }
        }

        ///<summary>
        ///Gets the default doctor commission.
        /// </summary>
        /// <value>The default doctor commission.</value>
        public DoctorCommission DefaultDoctorCommission
        {
            get
            {
                if (DoctorCommissions == null)
                {
                    return null;
                }
                return DoctorCommissions.Where(x => x.IsDefault).FirstOrDefault();
            }
        }

        ///<summary>
        /// Adds the doctor commission.
        /// </summary>
        /// <param name="doctorcommission">The doctor commission.</param>
        public void AddDoctorCommission(DoctorCommission commission)
        {
            if (DoctorCommissions == null)
            {
                DoctorCommissions = new List<DoctorCommission>();
            }

            // If there are not default commission, set this one as default
            if (DoctorCommissions.Where(x => x.IsDefault).Count() < 1)
            {
                commission.IsDefault = true;
            }

            // If this is the new default commission
            if (commission.IsDefault)
            {
                foreach (DoctorCommission comm in DoctorCommissions)
                {
                    comm.IsDefault = false;
                }
            }

            // If the commission is not already in the list
            if (!DoctorCommissions.Any(x => x.PrimaryKey == commission.PrimaryKey))
            {
                DoctorCommissions.Add(commission);
                commission.Doctor = this;
            }
        }

        ///<summary>
        /// Removes the doctor commission.
        /// </summary>
        /// <param name="doctorcommission">The doctor commission.</param>
        public void RemoveDoctorCommission(DoctorCommission commission)
        {
            if (DoctorCommissions == null)
            {
                return;
            }

            DoctorCommissions.Remove(commission);

            if (commission.IsDefault)
            {
                DoctorCommissions.FirstOrDefault().IsDefault = true;
            }
        }

        ///<summary>
        ///Gets the default doctor fees.
        /// </summary>
        /// <value>The default doctor fees.</value>
        public DoctorFees DefaultDoctorFees
        {
            get
            {
                if (DoctorFees == null)
                {
                    return null;
                }
                return DoctorFees.Where(x => x.IsDefault).FirstOrDefault();
            }
        }

        ///<summary>
        /// Adds the doctor fees.
        /// </summary>
        /// <param name="doctorfees">The doctor fees.</param>
        public void AddDoctorFees(DoctorFees fees)
        {
            if (DoctorFees == null)
            {
                DoctorFees = new List<DoctorFees>();
            }

            // If there are not default fees, set this one as default
            if (DoctorFees.Where(x => x.IsDefault).Count() < 1)
            {
                fees.IsDefault = true;
            }

            // If this is the new default fees
            if (fees.IsDefault)
            {
                foreach (DoctorFees fee in DoctorFees)
                {
                    fee.IsDefault = false;
                }
            }

            // If the fees is not already in the list
            if (!DoctorFees.Any(x => x.PrimaryKey == fees.PrimaryKey))
            {
                DoctorFees.Add(fees);
                fees.Doctor = this;
            }
        }

        ///<summary>
        /// Removes the doctor fees.
        /// </summary>
        /// <param name="doctorfees">The doctor fees.</param>
        public void RemoveDoctorFees(DoctorFees fees)
        {
            if (DoctorFees == null)
            {
                return;
            }

            DoctorFees.Remove(fees);

            if (fees.IsDefault)
            {
                DoctorFees.FirstOrDefault().IsDefault = true;
            }
        }

        ///<summary>
        ///Gets the latest feeshistory.
        /// </summary>
        /// <value>The latest feeshistory.</value>
        public DoctorFeesHistory LatestDoctorFeesHistory
        {
            get
            {
                if (DoctorFeesHistories == null)
                {
                    return null;
                }
                return DoctorFeesHistories.Where(x => x.IsLatest).FirstOrDefault();
            }
        }

        ///<summary>
        /// Adds the doctorfeeshistory.
        /// </summary>
        /// <param name="doctorfeeshistory">The doctorfeeshistory.</param>
        public void AddDoctorFeesHistory(DoctorFeesHistory feesHistory)
        {
            if (DoctorFeesHistories == null)
            {
                DoctorFeesHistories = new List<DoctorFeesHistory>();
            }

            // set this one as latest.
            feesHistory.IsLatest = true;

            // If this is the new latest feeshistory.
            if (feesHistory.IsLatest)
            {
                foreach (DoctorFeesHistory history in DoctorFeesHistories)
                {
                    history.IsLatest = false;
                }
            }

            // If the feeshistory is not already in the list
            if (!DoctorFeesHistories.Any(x => x.PrimaryKey == feesHistory.PrimaryKey))
            {
                DoctorFeesHistories.Add(feesHistory);
                feesHistory.Doctor = this;
            }
        }

        ///<summary>
        /// Removes the doctorfeeshistory.
        /// </summary>
        /// <param name="doctorfeeshistory">The doctorfeeshistory.</param>
        public void RemoveDoctorFeesHistory(DoctorFeesHistory feesHistory)
        {
            if (DoctorFeesHistories == null)
            {
                return;
            }

            DoctorFeesHistories.Remove(feesHistory);

            if (feesHistory.IsLatest)
            {
                DoctorFeesHistories.LastOrDefault().IsLatest = true;
            }
        }

        ///<summary>
        ///Gets the latest commissionhistory.
        /// </summary>
        /// <value>The latest commissionhistory.</value>
        public DoctorCommissionHistory LatestDoctorCommissionHistory
        {
            get
            {
                if (DoctorCommissionHistories == null)
                {
                    return null;
                }
                return DoctorCommissionHistories.Where(x => x.IsLatest).FirstOrDefault();
            }
        }

        ///<summary>
        /// Adds the doctorcommissionhistory.
        /// </summary>
        /// <param name="doctorcommissionhistory">The doctorcommissionhistory.</param>
        public void AddDoctorCommissionHistory(DoctorCommissionHistory commissionHistory)
        {
            if (DoctorCommissionHistories == null)
            {
                DoctorCommissionHistories = new List<DoctorCommissionHistory>();
            }

            // set this one as latest.
            commissionHistory.IsLatest = true;

            // If this is the new latest commissionhistory.
            if (commissionHistory.IsLatest)
            {
                foreach (DoctorCommissionHistory history in DoctorCommissionHistories)
                {
                    history.IsLatest = false;
                }
            }

            // If the commissionhistory is not already in the list
            if (!DoctorCommissionHistories.Any(x => x.PrimaryKey == commissionHistory.PrimaryKey))
            {
                DoctorCommissionHistories.Add(commissionHistory);
                commissionHistory.Doctor = this;
            }
        }

        ///<summary>
        /// Removes the doctorcommissionhistory.
        /// </summary>
        /// <param name="doctorcommissionhistory">The doctorcommissionhistory.</param>
        public void RemoveDoctorCommissionHistory(DoctorCommissionHistory commissionHistory)
        {
            if (DoctorCommissionHistories == null)
            {
                return;
            }

            DoctorCommissionHistories.Remove(commissionHistory);

            if (commissionHistory.IsLatest)
            {
                DoctorCommissionHistories.LastOrDefault().IsLatest = true;
            }
        }

        public virtual DoctorDepartment DoctorDepartment { get; set; }
        public virtual DoctorType DoctorType { get; set; }
        public virtual IList<DoctorFees> DoctorFees { get; set; }
        public virtual IList<DoctorCommission> DoctorCommissions { get; set; }
        public virtual IList<PatientRegistration> PatientRegistrations { get; set; }
        public virtual IList<DoctorFeesHistory> DoctorFeesHistories { get; set; }
        public virtual IList<DoctorCommissionHistory> DoctorCommissionHistories { get; set; }
    }
}
