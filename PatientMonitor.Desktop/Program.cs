using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientMonitor.Entities;
using PatientMonitor.Services;

namespace PatientMonitor.Desktop
{
    class Program
    {
        static void Main(string[] args)
        {
            PatientRepository patientRepository = new PatientRepository();
            MorbidityGroupRepository morbidityGroupRepository = new MorbidityGroupRepository();
            SymptomInstanceRepository symptomInstanceRepository = new SymptomInstanceRepository();

            var patients = patientRepository.GetAll();
            foreach (var patient in patients)
            {
                Console.WriteLine("\n----------------------------------------------");
                Console.WriteLine("\nSome basic info for the patient {0} (id:{1}) born on {2}\n", patient.Name, patient.Id, patient.DateOfBirth);
                Console.WriteLine("------Morbidity Groups-----\n");
                foreach (var patientMorbidityGroup in patient.PatientMorbidityGroups)
                {
                    Console.WriteLine(patientMorbidityGroup.MorbidityGroup.Name);
                }
                Console.WriteLine("\n------Symptom Instances-----\n");
                foreach (var symptomInstance in patient.SymptomInstances)
                {
                    Console.WriteLine("(S)he experienced {0} on {1}", symptomInstance.Name, symptomInstance.DateOfOccurrence);
                }
            }
            Console.WriteLine("\n-----End of Patients-------------------------------");

            var morbidityGroups = morbidityGroupRepository.GetAll();
            foreach (var morbidityGroup in morbidityGroups)
            {
                Console.WriteLine("\n----------------------------------------------");
                Console.WriteLine("\nSome basic info for the morbidity group {0} (id:{1})\n", morbidityGroup.Name, morbidityGroup.Id);
                Console.WriteLine("------Patients in this group-----\n");
                foreach (var patientMorbidityGroup in morbidityGroup.PatientMorbidityGroups)
                {
                    Console.WriteLine(patientMorbidityGroup.Patient.Name);
                    Console.WriteLine("\n------Symptoms for this patient-----\n");
                    foreach (var symptominstance in patientMorbidityGroup.Patient.SymptomInstances)
                    {
                        Console.WriteLine("{0} experienced {1} on {2}\n", patientMorbidityGroup.Patient.Name, symptominstance.Name, symptominstance.DateOfOccurrence);
                    }
                }
            }
            Console.WriteLine("\n-----End of Morbidity Groups-------------------------------");

            var symptomInstances = symptomInstanceRepository.GetAll();
            foreach (var symptomInstance in symptomInstances)
            {
                Console.WriteLine("\n----------------------------------------------");
                Console.WriteLine("\nSome basic info for the symptom instance {0} (id:{1}) that occurred on {2}\n", symptomInstance.Name, symptomInstance.Id, symptomInstance.DateOfOccurrence);
                Console.WriteLine("It was experienced by {0}, who belongs to the following morbidity groups\n", symptomInstance.Patient.Name);
                foreach (var patientMorbidityGroup in symptomInstance.Patient.PatientMorbidityGroups)
                {
                    Console.WriteLine(patientMorbidityGroup.MorbidityGroup.Name);
                }
            }
            Console.WriteLine("\n-----End of Symptom Instances-------------------------------");
            Console.ReadKey();
        }
    }
}
