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
    public class SymptomInstanceRepository
    {
        private MyDatabase db;
        public SymptomInstanceRepository(MyDatabase db)
        {
            this.db = db;
        }

        //GetAll()
        public IEnumerable<SymptomInstance> GetAll()
        {
            return db.SymptomInstances.ToList();
        }

        //GetById
        public SymptomInstance GetById(int? id)
        {
            return db.SymptomInstances.Find(id);
        }

        //GetByPatientId
        public IEnumerable<SymptomInstance> GetAllByPatientId(int? id)
        {
            return db.SymptomInstances.Where(s=>s.PatientId == id).ToList();
        }
        //Insert
        public void Insert(SymptomInstance SymptomInstance)
        {
            db.Entry(SymptomInstance).State = EntityState.Added;
            db.SaveChanges();
        }

        //Create
        public void Create(string symptomInstanceName, DateTime dateOfOccurrence, int patientId, PatientRepository patientRepository)
        {
            if (patientRepository.GetById(patientId) != null)
            {
                SymptomInstance symptomInstance = new SymptomInstance() { Name = symptomInstanceName, DateOfOccurrence = dateOfOccurrence, PatientId = patientId };
                Insert(symptomInstance);
            }
        }

        //Update
        public void Update(SymptomInstance SymptomInstance)
        {
            db.Entry(SymptomInstance).State = EntityState.Modified;
            db.SaveChanges();
        }

        //Delete
        public void Delete(SymptomInstance SymptomInstance)
        {
            db.Entry(SymptomInstance).State = EntityState.Deleted;
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
