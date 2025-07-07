using Entities;
using Entities.Repositories.Classes;
using Entities.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddDbContextPool<TimeContext>(
  opt=>opt.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("scon"))
    );
builder.Services.AddScoped<IAdminRepo,AdminRepo>();
builder.Services.AddScoped<ICountryRepo,CountryRepo>();
builder.Services.AddScoped<IStateRepo, StateRepo>();
builder.Services.AddScoped<ICityRepo, CityRepo>();
builder.Services.AddScoped<IClinicAdminRepo, ClinicAdminRepo>();
builder.Services.AddScoped<IClinicRepo,CllinicRepo>();
builder.Services.AddScoped<IClinicFacilityRepo, ClinicFacilityRepo>();
builder.Services.AddScoped<IClinicCertificateRepo, ClinicCertificateRepo>();
builder.Services.AddScoped<IClinicRatingRepo, ClinicRatingRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<ISpecilityRepo, SpecilityRepo>();
builder.Services.AddScoped<IAreaRepo, AreaRepo>();
builder.Services.AddScoped<IdoctorSpecialitiesRepo,DoctorSpecilitiesrepo>();
builder.Services.AddScoped<IDoctorRepo,DoctorRepo>();
builder.Services.AddScoped<IDoctorScheduleRepo, DoctorScheduleRepo>();
builder.Services.AddScoped<IOpdSessionRepo,OpdSessionRepo>();
builder.Services.AddScoped<IPatientinfo, PatientInfo>();
builder.Services.AddScoped<IBookAppointmentRepo, BookAppointmentRepo>();
builder.Services.AddScoped<ITimeRepo, TimeRepo>();
builder.Services.AddScoped<IMedicineRepo,MedicineRepo>();
builder.Services.AddScoped<IPrescriptionRepo,PrescriptionRepo>();
builder.Services.AddScoped<IUserAppointmentRepo, UserAppointmentRepo>();
builder.Services.AddScoped<IDoctorRatingRepo, DoctorRatingRepo>();
builder.Services.AddScoped<IReportRepo, ReportRepo>();
builder.Services.AddScoped<IDoctorReportRepo, DoctorReportRepo>();


var app = builder.Build();
app.UseSession();

app.MapControllerRoute(
    name:"area",
    pattern:"{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.Run();
