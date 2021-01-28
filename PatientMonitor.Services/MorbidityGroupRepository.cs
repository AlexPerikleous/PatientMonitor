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
        private MyDatabase db;
        public MorbidityGroupRepository(MyDatabase db)
        {
            this.db = db;
        }

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

        //GetByName
        public MorbidityGroup GetByName(string name)
        {
            return db.MorbidityGroups.FirstOrDefault(mg=>mg.Name == name);
        }
        //Insert
        public void Insert(MorbidityGroup MorbidityGroup)
        {
            db.Entry(MorbidityGroup).State = EntityState.Added;
            db.SaveChanges();
        }

        //Create
        public void Create(string morbidityGroupName)
        {
            MorbidityGroup morbidityGroup = new MorbidityGroup() { Name = morbidityGroupName };
            Insert(morbidityGroup);
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
