using HealthRecord1.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthRecord1.DAL.Database;

public class MyContext : DbContext
{

    // DbSet properties expose entity collections for EF Core
    public DbSet<Patient> Patients { get; set; } = null!;
    public DbSet<ChronicDisease> ChronicDiseases { get; set; } = null!;
    public DbSet<ChronicDiseaseCard> ChronicDiseaseCards { get; set; } = null!;
    public DbSet<Operation> Operations { get; set; } = null!;
    public DbSet<Vaccination> Vaccinations { get; set; } = null!;
    public DbSet<VaccinationCard> VaccinationCards { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=HealthRecord1Db;Trusted_Connection=True;TrustServerCertificate=True;");
    }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

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
