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
        MyDatabase db = new MyDatabase();

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
        //Insert
        public void Insert(SymptomInstance SymptomInstance)
        {
            db.Entry(SymptomInstance).State = EntityState.Added;
            db.SaveChanges();
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
