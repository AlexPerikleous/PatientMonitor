using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientMonitor.Entities
{
    public class MorbidityGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PatientMorbidityGroup> PatientMorbidityGroups { get; set; }
    }
}
