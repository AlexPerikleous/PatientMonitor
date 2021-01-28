using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientMonitor.Services
{
    public class Functionality
    {
        public void EnhancedServices(PatientRepository patientRepository, MorbidityGroupRepository morbidityGroupRepository, SymptomInstanceRepository symptomInstanceRepository)
        {
            //1.    Create a morbidity group using its name as input argument
            morbidityGroupRepository.Create("Lung disease");

            //2.	Create a patient, assigning them to all necessary morbidity groups, as the latter are indicated by an input array/list of morbidity names. The patient’s name and date of birth are also input arguments.
            List<string> mgroups = new List<string>();
            mgroups.Add("Lung disease");
            mgroups.Add("Heart disease");
            patientRepository.Create("Jonathan James", new DateTime(1965, 12, 11), mgroups, morbidityGroupRepository);
            patientRepository.Create("Oscar Reed", new DateTime(1975, 10, 15), mgroups, morbidityGroupRepository);

            //3.	Create a new symptom instance for a patient. The symptom name, date of occurrence and the id of the patient that suffered it are input arguments.
            symptomInstanceRepository.Create("Cramps", new DateTime(2021, 1, 11), 1, patientRepository);
            symptomInstanceRepository.Create("Breathing difficulties", new DateTime(2021, 1, 19), 6, patientRepository);
            symptomInstanceRepository.Create("Muscle ache", new DateTime(2021, 1, 12), 7, patientRepository);
            symptomInstanceRepository.Create("Sleepiness", new DateTime(2021, 1, 5), 2, patientRepository);

            //4.	Fetch all patients older than some age
            var oldPatients = patientRepository.GetAllOverCertainAge(65);

            //5.	Fetch all symptom instances of a patient described by a patient id.
            var specificSymptoms = symptomInstanceRepository.GetAllByPatientId(1);

            //6.	Fetch patients that belong to all the morbidity groups of interest, as they are described by an input array/list of morbidity names.
            var mgPatients = patientRepository.GetAllInMorbidityGroups(mgroups, morbidityGroupRepository);

            //Final.Print all symptom instances of the patients older than 65 years that belong to at least two morbidity groups.
            var oldMGPatients = patientRepository.GetAllOverCertainAgeInMorbidityGroupCount(65, 2, morbidityGroupRepository);
            foreach (var oldMGPatient in oldMGPatients)
            {
                var oldMGSymptoms = symptomInstanceRepository.GetAllByPatientId(oldMGPatient.Id);
                Console.WriteLine("The symptoms for patient {0} are as follows:", oldMGPatient.Name);
                foreach (var oldMGSymptom in oldMGSymptoms)
                {
                    Console.WriteLine("\nThe symptom {0} (id:{1}) occurred on {2}\n", oldMGSymptom.Name, oldMGSymptom.Id, oldMGSymptom.DateOfOccurrence);
                }
            }
        }

        public void GeneralInfo(PatientRepository patientRepository, MorbidityGroupRepository morbidityGroupRepository, SymptomInstanceRepository symptomInstanceRepository)
        {
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
                if (morbidityGroup.PatientMorbidityGroups == null)
                    continue;
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
                if (symptomInstance.Patient.PatientMorbidityGroups == null)
                    continue;
                foreach (var patientMorbidityGroup in symptomInstance.Patient.PatientMorbidityGroups)
                {
                    Console.WriteLine(patientMorbidityGroup.MorbidityGroup.Name);
                }
            }
            Console.WriteLine("\n-----End of Symptom Instances-------------------------------");
        }
    }
}
