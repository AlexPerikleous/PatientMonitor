using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PatientMonitor.Entities;

namespace PatientMonitor.Database
{
    public class MyDatabase : DbContext
    {
        public MyDatabase() : base("Connection")
        {

        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<MorbidityGroup> MorbidityGroups { get; set; }
        public DbSet<PatientMorbidityGroup> PatientMorbidityGroups { get; set; }
        public DbSet<SymptomInstance> SymptomInstances { get; set; }

    }
}
