# PatientMonitor
Monitoring program for groups of patients. More info soon...

Here are the basic steps in order to run the whole project smoothly:
1.	Clone the repo locally
2.	Change the connection string in App.config inside PatientMonitor.Database and PatientMonitor.Desktop to use your local database
3.	Build the solution
4.	Restore packages (if missing)
5.	Open Package Manager Console and run "update-database" using the PatientMonitor.Database as default project (this step is needed because we are using Code-First Migrations to populate the Database in the beginning)
6.	Set the PatientMonitor.Desktop as StartUp Project
7.	Run!
