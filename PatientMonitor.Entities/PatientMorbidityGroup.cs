using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientMonitor.Entities
{
    public class PatientMorbidityGroup
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("MorbidityGroup")]
        public int MorbidityGroupId { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual MorbidityGroup MorbidityGroup { get; set; }

    }
}
