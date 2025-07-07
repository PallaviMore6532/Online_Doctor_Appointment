using Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public  class TimeContext:DbContext
    {
        public TimeContext(DbContextOptions<TimeContext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }


        public DbSet<Admin>Admins { get; set; }
        public DbSet<Country> Countrys { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Citys { get; set; }

        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<ClinicAdmin> ClinicsAdmins { get;set; }

        public DbSet<Area> Areas { get; set; }
       public DbSet<OPDSession> OPDSessions { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<BookedAppointment> BookedAppointments { get; set;}
        public DbSet<BookedAppPayment> BookedAppPayments { get;set; }
        public DbSet<DoctorClinicSession> DoctorClinicSessions { get;set; }
        public DbSet<ClinicCertificate> ClinicCertificates { get; set;}
        public DbSet<DoctorSpeciality> DoctorSpecialities { get; set; }
        public DbSet<ClinicRating> ClinicRatings { get; set; }
        public DbSet<DoctorRating> DoctorRatings {  get; set; }
        public DbSet<Specility> Specilities { get; set; }
        public DbSet<ClinicFacility> ClinicFacilities { get;set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<DoctorSchedule> DoctorSchedules { get; set;}

        public DbSet<Prescription> Prescriptions { get; set;}
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<PrescriptionDetail> PrescriptionsDetail { get; set;}


    }
}
