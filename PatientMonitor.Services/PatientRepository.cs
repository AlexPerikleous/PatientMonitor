using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientMonitor.Database;
using PatientMonitor.Entities;
using System.Data.Entity;

namespace PatientMonitor.Services
{
    public class PatientRepository
    {
        private MyDatabase db;
        public PatientRepository(MyDatabase db)
        {
            this.db = db;
        }
        //GetAll()
        public IEnumerable<Patient> GetAll()
        {
            return db.Patients.ToList();
        }

        //GetAll()
        public IEnumerable<Patient> GetAllOverCertainAge(int age)
        {
            return db.Patients.Where(p=>Math.Abs(p.DateOfBirth.Year - DateTime.Now.Year) > age).ToList();
        }

        //Find whether specific morbidity group is among the patient's morbidity groups
        public bool FindMorbidityGroupForPatient(MorbidityGroup morbidityGroup, Patient patient)
        {
            return (patient.PatientMorbidityGroups.Any(pmg => pmg.MorbidityGroupId == morbidityGroup.Id));
        }
        //GetAllInMorbidityGroup
        public IEnumerable<Patient> GetAllInMorbidityGroups(List<string> morbidityGroupNames, MorbidityGroupRepository morbidityGroupRepository)
        {
            var patients = GetAll();
            List<Patient> assignedPatients = new List<Patient>();
            int groupCount;
            foreach (var patient in patients)
            {
                groupCount = 0;
                foreach (var morbidityGroupName in morbidityGroupNames)
                {
                    MorbidityGroup morbidityGroup = morbidityGroupRepository.GetByName(morbidityGroupName);
                    if (morbidityGroup != null)
                    {
                        if (FindMorbidityGroupForPatient(morbidityGroup, patient))
                        {
                            groupCount++;
                        }
                    }
                }
                if (groupCount == morbidityGroupNames.Count)
                {
                    assignedPatients.Add(patient);
                }
            }
            return assignedPatients;
        }

        public IEnumerable<Patient> GetAllOverCertainAgeInMorbidityGroupCount(int age, int minCount, MorbidityGroupRepository morbidityGroupRepository)
        {
            var patients = GetAllOverCertainAge(age);
            var morbidityGroups = morbidityGroupRepository.GetAll();
            List<Patient> assignedPatients = new List<Patient>();
            int groupCount;
            foreach (var patient in patients)
            {
                groupCount = 0;
                foreach (var morbidityGroup in morbidityGroups)
                {
                    if (FindMorbidityGroupForPatient(morbidityGroup, patient))
                    {
                        groupCount++;
                    }
                }
                if (groupCount >= minCount)
                {
                    assignedPatients.Add(patient);
                }
            }
            return assignedPatients;
        }

        //GetById
        public Patient GetById(int? id)
        {
            return db.Patients.Find(id);
        }

        //Create
        public void Create(string name, DateTime dateOfBirth, List<string> morbidityGroupNames, MorbidityGroupRepository morbidityGroupRepository)
        {
            Patient patient = new Patient() { Name = name, DateOfBirth = dateOfBirth };
            patient.PatientMorbidityGroups = new List<PatientMorbidityGroup>();

            foreach (var morbidityGroupName in morbidityGroupNames)
            {
                MorbidityGroup morbidityGroup = morbidityGroupRepository.GetByName(morbidityGroupName);
                if (morbidityGroup != null)
                {
                    PatientMorbidityGroup patientMorbidityGroup = new PatientMorbidityGroup() { MorbidityGroup = morbidityGroup, Patient = patient };
                    patient.PatientMorbidityGroups.Add(patientMorbidityGroup);
                    if (morbidityGroup.PatientMorbidityGroups == null)
                    {
                        morbidityGroup.PatientMorbidityGroups = new List<PatientMorbidityGroup>();
                    }
                    morbidityGroup.PatientMorbidityGroups.Add(patientMorbidityGroup);
                }
            }
            Insert(patient);
        }
        //Insert
        public void Insert(Patient Patient)
        {
            db.Entry(Patient).State = EntityState.Added;
            db.SaveChanges();
        }

        //Update
        public void Update(Patient Patient)
        {
            db.Entry(Patient).State = EntityState.Modified;
            db.SaveChanges();
        }

        //Delete
        public void Delete(Patient Patient)
        {
            db.Entry(Patient).State = EntityState.Deleted;
            db.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
