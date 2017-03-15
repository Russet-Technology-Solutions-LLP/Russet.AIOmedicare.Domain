using Russet.AIOmedicare.Domain.Base;
using System.Collections.Generic;

namespace Russet.AIOmedicare.Domain.Domain.Doctor
{
    public class DoctorDepartment : DomainObject
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual IList<Doctor> Doctors { get; set; }
    }
}
