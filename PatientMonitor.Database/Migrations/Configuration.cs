namespace PatientMonitor.Database.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using PatientMonitor.Database;
    using PatientMonitor.Entities;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<PatientMonitor.Database.MyDatabase>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PatientMonitor.Database.MyDatabase context)
        {
            #region SEED PATIENT DATA
            //=================Seeding Patients=================
            Patient p1 = new Patient() { Name = "John Doe", DateOfBirth = new DateTime(1940, 1, 1) };
            Patient p2 = new Patient() { Name = "James Fiennes", DateOfBirth = new DateTime(1950, 10, 12) };
            Patient p3 = new Patient() { Name = "Chris Schwimmer", DateOfBirth = new DateTime(1960, 4, 2) };
            Patient p4 = new Patient() { Name = "Mike Miller", DateOfBirth = new DateTime(1970, 11, 24) };
            Patient p5 = new Patient() { Name = "Bruce Wayne", DateOfBirth = new DateTime(1960, 9, 30) };

            //=================Seeding Morbidity Groups=================
            MorbidityGroup m1 = new MorbidityGroup() { Name = "Heart disease" };
            MorbidityGroup m2 = new MorbidityGroup() { Name = "Diabetes" };
            MorbidityGroup m3 = new MorbidityGroup() { Name = "COPD" };

            //=================Seeding Symptom Instances=================
            SymptomInstance s1 = new SymptomInstance() { Name = "Headache", DateOfOccurrence = new DateTime(2021, 1, 26) };
            SymptomInstance s2 = new SymptomInstance() { Name = "Diarrhea", DateOfOccurrence = new DateTime(2021, 1, 24) };
            SymptomInstance s3 = new SymptomInstance() { Name = "Pain", DateOfOccurrence = new DateTime(2020, 12, 23) };
            SymptomInstance s4 = new SymptomInstance() { Name = "Blood pressure", DateOfOccurrence = new DateTime(2020, 12, 1) };
            SymptomInstance s5 = new SymptomInstance() { Name = "Body temperature", DateOfOccurrence = new DateTime(2020, 4, 2) };
            SymptomInstance s6 = new SymptomInstance() { Name = "Fatigue", DateOfOccurrence = new DateTime(2020, 12, 14) };
            SymptomInstance s7 = new SymptomInstance() { Name = "Cough", DateOfOccurrence = new DateTime(2021, 1, 12) };
            SymptomInstance s8 = new SymptomInstance() { Name = "Nausea", DateOfOccurrence = new DateTime(2021, 1, 15) };
            SymptomInstance s9 = new SymptomInstance() { Name = "Congestion", DateOfOccurrence = new DateTime(2021, 1, 18) };
            SymptomInstance s10 = new SymptomInstance() { Name = "Palpitations", DateOfOccurrence = new DateTime(2021, 1, 21) };

            //=================Seeding Patient-MorbidityGroup Relationships=================
            PatientMorbidityGroup pm1 = new PatientMorbidityGroup() { MorbidityGroup = m1, Patient = p1 };
            PatientMorbidityGroup pm2 = new PatientMorbidityGroup() { MorbidityGroup = m1, Patient = p2 };
            PatientMorbidityGroup pm3 = new PatientMorbidityGroup() { MorbidityGroup = m2, Patient = p1 };
            PatientMorbidityGroup pm4 = new PatientMorbidityGroup() { MorbidityGroup = m2, Patient = p2 };
            PatientMorbidityGroup pm5 = new PatientMorbidityGroup() { MorbidityGroup = m3, Patient = p3 };
            PatientMorbidityGroup pm6 = new PatientMorbidityGroup() { MorbidityGroup = m3, Patient = p4 };
            PatientMorbidityGroup pm7 = new PatientMorbidityGroup() { MorbidityGroup = m3, Patient = p5 };
            
            p1.PatientMorbidityGroups = new List<PatientMorbidityGroup>() { pm1, pm3 };
            p2.PatientMorbidityGroups = new List<PatientMorbidityGroup>() { pm2, pm4 };
            p3.PatientMorbidityGroups = new List<PatientMorbidityGroup>() { pm5 };
            p4.PatientMorbidityGroups = new List<PatientMorbidityGroup>() { pm6 };
            p5.PatientMorbidityGroups = new List<PatientMorbidityGroup>() { pm7 };

            m1.PatientMorbidityGroups = new List<PatientMorbidityGroup>() { pm1, pm2 };
            m2.PatientMorbidityGroups = new List<PatientMorbidityGroup>() { pm3, pm4 };
            m3.PatientMorbidityGroups = new List<PatientMorbidityGroup>() { pm5, pm6, pm7 };

            //=================Seeding Patient-SymptomInstance Relationships=================
            p1.SymptomInstances = new List<SymptomInstance>() { s1, s2 };
            p2.SymptomInstances = new List<SymptomInstance>() { s3, s4 };
            p3.SymptomInstances = new List<SymptomInstance>() { s5, s6 };
            p4.SymptomInstances = new List<SymptomInstance>() { s7, s8 };
            p5.SymptomInstances = new List<SymptomInstance>() { s9, s10 };

            s1.Patient = p1;
            s2.Patient = p1;
            s3.Patient = p2;
            s4.Patient = p2;
            s5.Patient = p3;
            s6.Patient = p3;
            s7.Patient = p4;
            s8.Patient = p4;
            s9.Patient = p5;
            s10.Patient = p5;

            context.Patients.AddOrUpdate(x => x.Name, p1, p2, p3, p4, p5);
            context.MorbidityGroups.AddOrUpdate(x => x.Name, m1, m2, m3);

            context.SaveChanges();
            #endregion
        }
    }
}
