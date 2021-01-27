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
    public class MorbidityGroupRepository
    {
        MyDatabase db = new MyDatabase();

        //GetAll()
        public IEnumerable<MorbidityGroup> GetAll()
        {
            return db.MorbidityGroups.ToList();
        }

        //GetById
        public MorbidityGroup GetById(int? id)
        {
            return db.MorbidityGroups.Find(id);
        }
        //Insert
        public void Insert(MorbidityGroup MorbidityGroup)
        {
            db.Entry(MorbidityGroup).State = EntityState.Added;
            db.SaveChanges();
        }

        //Update
        public void Update(MorbidityGroup MorbidityGroup)
        {
            db.Entry(MorbidityGroup).State = EntityState.Modified;
            db.SaveChanges();
        }

        //Delete
        public void Delete(MorbidityGroup MorbidityGroup)
        {
            db.Entry(MorbidityGroup).State = EntityState.Deleted;
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
