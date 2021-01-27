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
        MyDatabase db = new MyDatabase();

        //GetAll()
        public IEnumerable<Patient> GetAll()
        {
            return db.Patients.ToList();
        }

        //GetById
        public Patient GetById(int? id)
        {
            return db.Patients.Find(id);
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
