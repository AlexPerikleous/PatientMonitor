using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientMonitor.Entities
{
    public class SymptomInstance
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfOccurrence { get; set; }
        public float Value { get; set; }

        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
