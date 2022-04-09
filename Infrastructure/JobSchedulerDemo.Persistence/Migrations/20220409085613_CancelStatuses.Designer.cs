﻿// <auto-generated />
using System;
using JobSchedulerDemo.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JobSchedulerDemo.Persistence.Migrations
{
    [DbContext(typeof(ScheduledJobsDbContext))]
    [Migration("20220409085613_CancelStatuses")]
    partial class CancelStatuses
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Coravel.Pro.EntityFramework.CoravelJobHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ErrorMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Failed")
                        .HasColumnType("bit");

                    b.Property<string>("StackTrace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("TypeFullPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Coravel_JobHistory");
                });

            modelBuilder.Entity("Coravel.Pro.EntityFramework.CoravelScheduledJob", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CronExpression")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Days")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Frequency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvocableFullPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PreventOverlapping")
                        .HasColumnType("bit");

                    b.Property<string>("TimeZoneInfo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Coravel_ScheduledJobs");
                });

            modelBuilder.Entity("Coravel.Pro.EntityFramework.CoravelScheduledJobHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ErrorMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Failed")
                        .HasColumnType("bit");

                    b.Property<string>("StackTrace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeFullPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Coravel_ScheduledJobHistory");
                });

            modelBuilder.Entity("JobSchedulerDemo.Domain.ScheduledJob", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("Completed")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Error")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Scheduled")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Started")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("ScheduledJobs");
                });

            modelBuilder.Entity("JobSchedulerDemo.Domain.ScheduledJobStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ScheduledJobStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "Initial Create",
                            DateCreated = new DateTime(2022, 4, 9, 8, 56, 13, 643, DateTimeKind.Utc).AddTicks(1250),
                            LastModifiedBy = "Initial Create",
                            LastModifiedDate = new DateTime(2022, 4, 9, 8, 56, 13, 643, DateTimeKind.Utc).AddTicks(1250),
                            Status = "Created"
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "Initial Create",
                            DateCreated = new DateTime(2022, 4, 9, 8, 56, 13, 643, DateTimeKind.Utc).AddTicks(1250),
                            LastModifiedBy = "Initial Create",
                            LastModifiedDate = new DateTime(2022, 4, 9, 8, 56, 13, 643, DateTimeKind.Utc).AddTicks(1250),
                            Status = "Scheduled"
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "Initial Create",
                            DateCreated = new DateTime(2022, 4, 9, 8, 56, 13, 643, DateTimeKind.Utc).AddTicks(1250),
                            LastModifiedBy = "Initial Create",
                            LastModifiedDate = new DateTime(2022, 4, 9, 8, 56, 13, 643, DateTimeKind.Utc).AddTicks(1250),
                            Status = "Running"
                        },
                        new
                        {
                            Id = 4,
                            CreatedBy = "Initial Create",
                            DateCreated = new DateTime(2022, 4, 9, 8, 56, 13, 643, DateTimeKind.Utc).AddTicks(1250),
                            LastModifiedBy = "Initial Create",
                            LastModifiedDate = new DateTime(2022, 4, 9, 8, 56, 13, 643, DateTimeKind.Utc).AddTicks(1250),
                            Status = "Completed"
                        },
                        new
                        {
                            Id = 5,
                            CreatedBy = "Initial Create",
                            DateCreated = new DateTime(2022, 4, 9, 8, 56, 13, 643, DateTimeKind.Utc).AddTicks(1250),
                            LastModifiedBy = "Initial Create",
                            LastModifiedDate = new DateTime(2022, 4, 9, 8, 56, 13, 643, DateTimeKind.Utc).AddTicks(1250),
                            Status = "Error"
                        },
                        new
                        {
                            Id = 6,
                            CreatedBy = "Initial Create",
                            DateCreated = new DateTime(2022, 4, 9, 8, 56, 13, 643, DateTimeKind.Utc).AddTicks(1250),
                            LastModifiedBy = "Initial Create",
                            LastModifiedDate = new DateTime(2022, 4, 9, 8, 56, 13, 643, DateTimeKind.Utc).AddTicks(1250),
                            Status = "Rejected"
                        },
                        new
                        {
                            Id = 7,
                            CreatedBy = "Initial Create",
                            DateCreated = new DateTime(2022, 4, 9, 8, 56, 13, 643, DateTimeKind.Utc).AddTicks(1250),
                            LastModifiedBy = "Initial Create",
                            LastModifiedDate = new DateTime(2022, 4, 9, 8, 56, 13, 643, DateTimeKind.Utc).AddTicks(1250),
                            Status = "Cancelling"
                        },
                        new
                        {
                            Id = 8,
                            CreatedBy = "Initial Create",
                            DateCreated = new DateTime(2022, 4, 9, 8, 56, 13, 643, DateTimeKind.Utc).AddTicks(1250),
                            LastModifiedBy = "Initial Create",
                            LastModifiedDate = new DateTime(2022, 4, 9, 8, 56, 13, 643, DateTimeKind.Utc).AddTicks(1250),
                            Status = "Cenceled"
                        });
                });

            modelBuilder.Entity("JobSchedulerDemo.Domain.ScheduledJob", b =>
                {
                    b.HasOne("JobSchedulerDemo.Domain.ScheduledJobStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });
#pragma warning restore 612, 618
        }
    }
}
