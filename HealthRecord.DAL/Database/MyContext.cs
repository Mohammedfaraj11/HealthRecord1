using HealthRecord1.DAL.Entities;
using HealthRecord1.DAL.Extends;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthRecord1.DAL.Database;

public class MyContext : IdentityDbContext <ApplicationUser>
{

    public MyContext(DbContextOptions<MyContext> opt) : base(opt)
    { }







    // DbSet properties expose entity collections for EF Core
    public DbSet<Patient> Patients { get; set; } = null!;
    public DbSet<ChronicDisease> ChronicDiseases { get; set; } = null!;
    public DbSet<ChronicDiseaseCard> ChronicDiseaseCards { get; set; } = null!;
    public DbSet<Operation> Operations { get; set; } = null!;
    public DbSet<Vaccination> Vaccinations { get; set; } = null!;
    public DbSet<VaccinationCard> VaccinationCards { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure unique index for Patient's NationalId
        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasIndex(p => p.NationalId)
                  .IsUnique()
                  .HasDatabaseName("IX_Patient_NationalId");

            // Global query filter to exclude soft-deleted patients
            entity.HasQueryFilter(p => !p.IsDeleted);
        });

        // Configure relationships / constraints for the ChronicDiseaseCard join entity
        modelBuilder.Entity<ChronicDiseaseCard>(entity =>
        {
            entity.HasOne(card => card.Patient)
                  .WithMany(patient => patient.ChronicDiseaseCards)
                  .HasForeignKey(card => card.PatientId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(card => card.ChronicDisease)
                  .WithMany(disease => disease.ChronicDiseaseCards)
                  .HasForeignKey(card => card.ChronicDiseaseId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.Property(card => card.DiagnosisDate)
                  .HasColumnType("date");
        });

        // Configure relationship between Patient and Operation
        modelBuilder.Entity<Operation>(entity =>
        {
            entity.HasOne(op => op.Patient)
                  .WithMany(patient => patient.Operations)
                  .HasForeignKey(op => op.PatientId)
                  .OnDelete(DeleteBehavior.Cascade);
        });


        // Configure relationships / constraints for the VaccinationCard join entity
        modelBuilder.Entity<VaccinationCard>(entity =>
        {
            entity.HasOne(card => card.Patient)
                  .WithMany(patient => patient.VaccinationCards)
                  .HasForeignKey(card => card.PatientId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(card => card.Vaccination)
                  .WithMany(vaccination => vaccination.VaccinationCards)
                  .HasForeignKey(card => card.VaccinationId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.Property(card => card.AdministrationDate)
                  .HasColumnType("datetime");
        });
    }
}
