﻿// <auto-generated />
using System;
using KNU.RS.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KNU.RS.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230117214356_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("KNU.RS.Data.Models.Clinic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Location")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("WorkingHours")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Clinics");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a6285a67-6f1b-4adb-8de1-ffb26050c36a"),
                            Location = "вул. Госпітальна, 16",
                            Name = "Військовий шпиталь",
                            PhoneNumber = "044 521 8413",
                            WorkingHours = "Пн.-Пт.: 8:00 - 18:00"
                        });
                });

            modelBuilder.Entity("KNU.RS.Data.Models.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Biography")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<Guid>("ClinicId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Competencies")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Degree")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("QualificationId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Room")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ClinicId");

                    b.HasIndex("QualificationId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("KNU.RS.Data.Models.DoctorPatient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("DoctorPatients");
                });

            modelBuilder.Entity("KNU.RS.Data.Models.Education", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Degree")
                        .HasColumnType("longtext");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("InstitutionName")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("Educations");
                });

            modelBuilder.Entity("KNU.RS.Data.Models.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Complaints")
                        .HasColumnType("longtext");

                    b.Property<string>("Diagnosis")
                        .HasColumnType("longtext");

                    b.Property<int>("EducationStatus")
                        .HasColumnType("int");

                    b.Property<string>("HealthInsuranse")
                        .HasColumnType("longtext");

                    b.Property<string>("HealthInsuranseCompany")
                        .HasColumnType("longtext");

                    b.Property<decimal?>("Height")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Job")
                        .HasColumnType("longtext");

                    b.Property<int>("MaritalStatus")
                        .HasColumnType("int");

                    b.Property<int>("Occupation")
                        .HasColumnType("int");

                    b.Property<string>("Passport")
                        .HasColumnType("longtext");

                    b.Property<string>("Position")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<decimal?>("Weight")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("KNU.RS.Data.Models.Qualification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Qualifications");

                    b.HasData(
                        new
                        {
                            Id = new Guid("35b9add3-729d-41b9-8a8c-d74681d1d526"),
                            Name = "Лаборант"
                        },
                        new
                        {
                            Id = new Guid("a2e2facf-6554-4bd1-9133-673e0fc45ed0"),
                            Name = "Фізіотерапевт"
                        });
                });

            modelBuilder.Entity("KNU.RS.Data.Models.RecoveryDailyPlan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Completed")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Day")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<Guid>("DoctorPatientId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("SerialNumber")
                        .HasColumnType("int");

                    b.Property<int>("Times")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoctorPatientId");

                    b.ToTable("RecoveryDailyPlans");
                });

            modelBuilder.Entity("KNU.RS.Data.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("7322ebe8-cfc4-4bd8-8cf9-67a9ceeae0a3"),
                            ConcurrencyStamp = "eea7aefd-c56b-4ba2-8bc9-b3a00343eaee",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("5ec23f46-4f31-457f-b9b7-16f4fb090ee3"),
                            ConcurrencyStamp = "da6c1c66-96df-4afa-b811-97ea0033dcd9",
                            Name = "Doctor",
                            NormalizedName = "DOCTOR"
                        },
                        new
                        {
                            Id = new Guid("c63e87f9-dee0-4ec5-911c-a8d2c591dc17"),
                            ConcurrencyStamp = "7f176045-4291-42e2-bc75-2ce7b18db55a",
                            Name = "Patient",
                            NormalizedName = "PATIENT"
                        });
                });

            modelBuilder.Entity("KNU.RS.Data.Models.StudyDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<decimal>("AvgClockwiseDegrees")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("AvgCounterClockwiseDegrees")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("MaxClockwiseDegrees")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("MaxCounterClockwiseDegrees")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("MinClockwiseDegrees")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("MinCounterClockwiseDegrees")
                        .HasColumnType("decimal(65,30)");

                    b.Property<Guid>("StudyHeaderId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("StudySubtypeId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("StudyHeaderId");

                    b.HasIndex("StudySubtypeId");

                    b.ToTable("StudyDetails");
                });

            modelBuilder.Entity("KNU.RS.Data.Models.StudyHeader", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("DoctorPatientId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorPatientId");

                    b.ToTable("StudyHeaders");
                });

            modelBuilder.Entity("KNU.RS.Data.Models.StudySubtype", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("SerialNumber")
                        .HasColumnType("int");

                    b.Property<Guid>("StudyTypeId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("StudyTypeId");

                    b.ToTable("StudySubtypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("89e5b4be-aef1-4107-a7ed-32e05efb864b"),
                            Name = "Поворот по осі крену",
                            SerialNumber = 0,
                            StudyTypeId = new Guid("568342a7-cc8b-476d-a76b-f6519a9e2b42")
                        },
                        new
                        {
                            Id = new Guid("b492fb11-5e11-4a4a-9ab9-575c9eaa1be6"),
                            Name = "Поворот по осі рискання",
                            SerialNumber = 0,
                            StudyTypeId = new Guid("568342a7-cc8b-476d-a76b-f6519a9e2b42")
                        },
                        new
                        {
                            Id = new Guid("d785a91d-18ba-40f4-ad5a-c353ecf81bed"),
                            Name = "Поворот по осі тангажу",
                            SerialNumber = 0,
                            StudyTypeId = new Guid("568342a7-cc8b-476d-a76b-f6519a9e2b42")
                        });
                });

            modelBuilder.Entity("KNU.RS.Data.Models.StudyType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("StudyTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("568342a7-cc8b-476d-a76b-f6519a9e2b42"),
                            Name = "Обстеження шийного відділу"
                        });
                });

            modelBuilder.Entity("KNU.RS.Data.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("HasPhoto")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("PromotedToAdmin")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("KNU.RS.Data.Models.Doctor", b =>
                {
                    b.HasOne("KNU.RS.Data.Models.Clinic", "Clinic")
                        .WithMany("Doctors")
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KNU.RS.Data.Models.Qualification", "Qualification")
                        .WithMany("Doctors")
                        .HasForeignKey("QualificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KNU.RS.Data.Models.User", "User")
                        .WithOne("Doctor")
                        .HasForeignKey("KNU.RS.Data.Models.Doctor", "UserId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Clinic");

                    b.Navigation("Qualification");

                    b.Navigation("User");
                });

            modelBuilder.Entity("KNU.RS.Data.Models.DoctorPatient", b =>
                {
                    b.HasOne("KNU.RS.Data.Models.Doctor", "Doctor")
                        .WithMany("Patients")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KNU.RS.Data.Models.Patient", "Patient")
                        .WithMany("Doctors")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("KNU.RS.Data.Models.Education", b =>
                {
                    b.HasOne("KNU.RS.Data.Models.Doctor", "Doctor")
                        .WithMany("Educations")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("KNU.RS.Data.Models.Patient", b =>
                {
                    b.HasOne("KNU.RS.Data.Models.User", "User")
                        .WithOne("Patient")
                        .HasForeignKey("KNU.RS.Data.Models.Patient", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("KNU.RS.Data.Models.RecoveryDailyPlan", b =>
                {
                    b.HasOne("KNU.RS.Data.Models.DoctorPatient", "DoctorPatient")
                        .WithMany("RecoveryDailyPlans")
                        .HasForeignKey("DoctorPatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DoctorPatient");
                });

            modelBuilder.Entity("KNU.RS.Data.Models.StudyDetails", b =>
                {
                    b.HasOne("KNU.RS.Data.Models.StudyHeader", "StudyHeader")
                        .WithMany("StudyDetails")
                        .HasForeignKey("StudyHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KNU.RS.Data.Models.StudySubtype", "StudySubtype")
                        .WithMany("StudyDetails")
                        .HasForeignKey("StudySubtypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StudyHeader");

                    b.Navigation("StudySubtype");
                });

            modelBuilder.Entity("KNU.RS.Data.Models.StudyHeader", b =>
                {
                    b.HasOne("KNU.RS.Data.Models.DoctorPatient", "DoctorPatient")
                        .WithMany("StudyHeaders")
                        .HasForeignKey("DoctorPatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DoctorPatient");
                });

            modelBuilder.Entity("KNU.RS.Data.Models.StudySubtype", b =>
                {
                    b.HasOne("KNU.RS.Data.Models.StudyType", "StudyType")
                        .WithMany("StudySubtypes")
                        .HasForeignKey("StudyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StudyType");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("KNU.RS.Data.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("KNU.RS.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("KNU.RS.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("KNU.RS.Data.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KNU.RS.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("KNU.RS.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KNU.RS.Data.Models.Clinic", b =>
                {
                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("KNU.RS.Data.Models.Doctor", b =>
                {
                    b.Navigation("Educations");

                    b.Navigation("Patients");
                });

            modelBuilder.Entity("KNU.RS.Data.Models.DoctorPatient", b =>
                {
                    b.Navigation("RecoveryDailyPlans");

                    b.Navigation("StudyHeaders");
                });

            modelBuilder.Entity("KNU.RS.Data.Models.Patient", b =>
                {
                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("KNU.RS.Data.Models.Qualification", b =>
                {
                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("KNU.RS.Data.Models.StudyHeader", b =>
                {
                    b.Navigation("StudyDetails");
                });

            modelBuilder.Entity("KNU.RS.Data.Models.StudySubtype", b =>
                {
                    b.Navigation("StudyDetails");
                });

            modelBuilder.Entity("KNU.RS.Data.Models.StudyType", b =>
                {
                    b.Navigation("StudySubtypes");
                });

            modelBuilder.Entity("KNU.RS.Data.Models.User", b =>
                {
                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });
#pragma warning restore 612, 618
        }
    }
}