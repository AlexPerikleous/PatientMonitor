using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientMonitor.Entities;
using PatientMonitor.Services;
using PatientMonitor.Database;

namespace PatientMonitor.Desktop
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDatabase db = new MyDatabase();
            PatientRepository patientRepository = new PatientRepository(db);
            MorbidityGroupRepository morbidityGroupRepository = new MorbidityGroupRepository(db);
            SymptomInstanceRepository symptomInstanceRepository = new SymptomInstanceRepository(db);

            Functionality functionality = new Functionality();
            functionality.EnhancedServices(patientRepository, morbidityGroupRepository, symptomInstanceRepository);
            functionality.GeneralInfo(patientRepository, morbidityGroupRepository, symptomInstanceRepository);
            Console.ReadKey();
        }
    }
}
