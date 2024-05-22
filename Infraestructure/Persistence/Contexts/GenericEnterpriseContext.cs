using Core.Entities.GenericEnterpise;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Contexts;

public partial class GenericEnterpriseContext : DbContext
{
    public GenericEnterpriseContext()
    {
    }

    public GenericEnterpriseContext(DbContextOptions<GenericEnterpriseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<GeAuthentication> GeAuthentications { get; set; }

    public virtual DbSet<GeInspectable> GeInspectables { get; set; }

    public virtual DbSet<GeInspectableType> GeInspectableTypes { get; set; }

    public virtual DbSet<GeInspection> GeInspections { get; set; }

    public virtual DbSet<GeInspectionDetail> GeInspectionDetails { get; set; }

    public virtual DbSet<GeInspectionStatus> GeInspectionStatuses { get; set; }

    public virtual DbSet<GeMemberOf> GeMemberOfs { get; set; }

    public virtual DbSet<GeProfile> GeProfiles { get; set; }

    public virtual DbSet<GeUser> GeUsers { get; set; }

    public virtual DbSet<GeVehicle> GeVehicles { get; set; }

    public virtual DbSet<GeVehicleType> GeVehicleTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:GenericEnterpise");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GeAuthentication>(entity =>
        {
            entity.HasKey(e => e.IdAuth);

            entity.ToTable("GE_AUTHentications");

            entity.Property(e => e.IdAuth).HasColumnName("Id_AUTH");
            entity.Property(e => e.DisplayNameAuth)
                .HasMaxLength(255)
                .HasColumnName("DisplayName_AUTH");
            entity.Property(e => e.IsActiveAuth)
                .HasDefaultValue(true)
                .HasComment("")
                .HasColumnName("IsActive_AUTH");
            entity.Property(e => e.IsDeletedAuth)
                .HasComment("")
                .HasColumnName("IsDeleted_AUTH");
            entity.Property(e => e.NameAuth)
                .HasMaxLength(255)
                .HasColumnName("Name_AUTH");
        });

        modelBuilder.Entity<GeInspectable>(entity =>
        {
            entity.HasKey(e => e.InspectableId).HasName("PK__GE_Inspe__CC03D868BF36D141");

            entity.ToTable("GE_Inspectable");

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<GeInspectableType>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("GE_InspectableType");

            entity.HasOne(d => d.Inspectable).WithMany()
                .HasForeignKey(d => d.InspectableId)
                .HasConstraintName("FK__GE_Inspec__Inspe__1DB06A4F");

            entity.HasOne(d => d.VehicleType).WithMany()
                .HasForeignKey(d => d.VehicleTypeId)
                .HasConstraintName("FK__GE_Inspec__Vehic__1CBC4616");
        });

        modelBuilder.Entity<GeInspection>(entity =>
        {
            entity.HasKey(e => e.InspectionId).HasName("PK__GE_Inspe__30B2DC08E5AAEC86");

            entity.ToTable("GE_Inspection");

            entity.Property(e => e.Comment).HasMaxLength(255);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.Status).WithMany(p => p.GeInspections)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK__GE_Inspec__Statu__236943A5");

            entity.HasOne(d => d.Vehicle).WithMany(p => p.GeInspections)
                .HasForeignKey(d => d.VehicleId)
                .HasConstraintName("FK__GE_Inspec__Vehic__22751F6C");
        });

        modelBuilder.Entity<GeInspectionDetail>(entity =>
        {
            entity.HasKey(e => e.InspectionDetailId).HasName("PK__GE_Inspe__F9BA6C2DC84CCF5E");

            entity.ToTable("GE_InspectionDetail");

            entity.Property(e => e.Observation).HasMaxLength(255);
            entity.Property(e => e.Result).HasMaxLength(50);

            entity.HasOne(d => d.Inspectable).WithMany(p => p.GeInspectionDetails)
                .HasForeignKey(d => d.InspectableId)
                .HasConstraintName("FK__GE_Inspec__Inspe__2739D489");

            entity.HasOne(d => d.Inspection).WithMany(p => p.GeInspectionDetails)
                .HasForeignKey(d => d.InspectionId)
                .HasConstraintName("FK__GE_Inspec__Inspe__2645B050");
        });

        modelBuilder.Entity<GeInspectionStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__GE_Inspe__C8EE206313D6C839");

            entity.ToTable("GE_InspectionStatus");

            entity.Property(e => e.StatusId).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(255);
        });

        modelBuilder.Entity<GeMemberOf>(entity =>
        {
            entity.HasKey(e => e.IdMeof);

            entity.ToTable("GE_MEmberOF");

            entity.Property(e => e.IdMeof).HasColumnName("Id_MEOF");
            entity.Property(e => e.IdProf).HasColumnName("Id_PROF");
            entity.Property(e => e.IdUser).HasColumnName("Id_USER");

            entity.HasOne(d => d.IdProfNavigation).WithMany(p => p.GeMemberOfs)
                .HasForeignKey(d => d.IdProf)
                .HasConstraintName("FK_GE_MEmberOF_GE_PROFiles");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.GeMemberOfs)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_GE_MEmberOF_GE_USERs");
        });

        modelBuilder.Entity<GeProfile>(entity =>
        {
            entity.HasKey(e => e.IdProf);

            entity.ToTable("GE_PROFiles");

            entity.Property(e => e.IdProf).HasColumnName("Id_PROF");
            entity.Property(e => e.DisplayNameProf)
                .HasMaxLength(255)
                .HasColumnName("DisplayName_PROF");
            entity.Property(e => e.IsActiveProf)
                .HasDefaultValue(true)
                .HasComment("")
                .HasColumnName("IsActive_PROF");
            entity.Property(e => e.IsDeletedProf)
                .HasComment("")
                .HasColumnName("IsDeleted_PROF");
            entity.Property(e => e.NameProf)
                .HasMaxLength(255)
                .HasColumnName("Name_PROF");
        });

        modelBuilder.Entity<GeUser>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("GE_USERs");

            entity.HasIndex(e => e.LoginUser, "IX_GE_USERs").IsUnique();

            entity.Property(e => e.IdUser).HasColumnName("Id_USER");
            entity.Property(e => e.FirstNameUser)
                .HasMaxLength(255)
                .HasColumnName("FirstName_USER");
            entity.Property(e => e.IdAuth).HasColumnName("Id_AUTH");
            entity.Property(e => e.IsActiveUser)
                .HasDefaultValue(true)
                .HasComment("")
                .HasColumnName("IsActive_USER");
            entity.Property(e => e.IsDeletedUser)
                .HasComment("")
                .HasColumnName("IsDeleted_USER");
            entity.Property(e => e.JobTitleUser)
                .HasMaxLength(255)
                .HasColumnName("JobTitle_USER");
            entity.Property(e => e.LastNameUser)
                .HasMaxLength(255)
                .HasColumnName("LastName_USER");
            entity.Property(e => e.LoginUser)
                .HasMaxLength(255)
                .HasColumnName("Login_USER");
            entity.Property(e => e.MailUser)
                .HasMaxLength(255)
                .HasColumnName("Mail_USER");
            entity.Property(e => e.PasswordUser)
                .HasMaxLength(255)
                .HasColumnName("Password_USER");
            entity.Property(e => e.PhoneUser)
                .HasMaxLength(20)
                .HasColumnName("Phone_USER");
            entity.Property(e => e.PhotoUser).HasColumnName("Photo_USER");

            entity.HasOne(d => d.IdAuthNavigation).WithMany(p => p.GeUsers)
                .HasForeignKey(d => d.IdAuth)
                .HasConstraintName("FK_GE_USERs_GE_AUTHentications");
        });

        modelBuilder.Entity<GeVehicle>(entity =>
        {
            entity.HasKey(e => e.VehicleId).HasName("PK__GE_Vehic__476B549201ED5257");

            entity.ToTable("GE_Vehicle");

            entity.Property(e => e.LicensePlate).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.VehicleType).WithMany(p => p.GeVehicles)
                .HasForeignKey(d => d.VehicleTypeId)
                .HasConstraintName("FK__GE_Vehicl__Vehic__18EBB532");
        });

        modelBuilder.Entity<GeVehicleType>(entity =>
        {
            entity.HasKey(e => e.VehicleTypeId).HasName("PK__GE_Vehic__9F44964356A6D05B");

            entity.ToTable("GE_VehicleType");

            entity.Property(e => e.Brand).HasMaxLength(50);
            entity.Property(e => e.Feature1).HasMaxLength(50);
            entity.Property(e => e.Feature2).HasMaxLength(50);
            entity.Property(e => e.Feature3).HasMaxLength(50);
            entity.Property(e => e.Model).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
