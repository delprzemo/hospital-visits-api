using Domain;
using System.Data.Entity;

namespace Infrastructure.Database
{
    public class HospitalVisitsDbInit : DropCreateDatabaseIfModelChanges<HospitalVisitsContext>
    {
        protected override void Seed(HospitalVisitsContext context)
        {
            var specializations = new List<Specialization>
                {
                    new Specialization { Name = "Cardiology" },
                    new Specialization { Name = "Neurology" },
                    new Specialization { Name = "Pediatrics" }
                };
            specializations.ForEach(s => context.Specializations.Add(s));
            context.SaveChanges();

            // Seed data for Hospitals
            var hospitals = new List<Hospital>
                {
                    new Hospital { Name = "General Hospital" },
                    new Hospital { Name = "City Health Clinic" },
                    new Hospital { Name = "Regional Medical Center" }
                };
            hospitals.ForEach(h => context.Hospitals.Add(h));
            context.SaveChanges();

            // Seed data for Doctors
            var doctors = new List<Doctor>
                {
                    new Doctor { FirstName = "James", LastName = "Smith" },
                    new Doctor { FirstName = "Lisa", LastName = "Taylor" },
                    new Doctor { FirstName = "Robert", LastName = "Johnson" }
                };
            doctors.ForEach(d => context.Doctors.Add(d));
            context.SaveChanges();

            // Seed data for Patients
            var patients = new List<Patient>
                {
                    new Patient { FirstName = "John", LastName = "Doe" },
                    new Patient { FirstName = "Mary", LastName = "Jane" },
                    new Patient { FirstName = "David", LastName = "Brown" }
                };
            patients.ForEach(p => context.Patients.Add(p));
            context.SaveChanges();

            // Seed data for PatientVisits
            var random = new Random();
            for (int i = 0; i < 100; i++)
            {
                context.PatientVisits.Add(new PatientVisit
                {
                    Date = DateTime.Now.AddDays(-random.Next(0, 30)),
                    Hospital = hospitals[random.Next(hospitals.Count)],
                    Patient = patients[random.Next(patients.Count)],
                    Doctor = doctors[random.Next(doctors.Count)],
                    Specialization = specializations[random.Next(specializations.Count)]
                });
            }
            context.SaveChanges();
        }
    }
}
