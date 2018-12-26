﻿// <auto-generated />
using System;
using FPTManagerSutdent.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FPTManagerSutdent.Migrations
{
    [DbContext(typeof(Datacontext))]
    [Migration("20181226035504_Create-MyCredential-Update")]
    partial class CreateMyCredentialUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FPTManagerSutdent.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<string>("Salt");

                    b.Property<int>("Status");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("FPTManagerSutdent.Models.ClassRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("ClassRoom");
                });

            modelBuilder.Entity("FPTManagerSutdent.Models.ClassRoomCourse", b =>
                {
                    b.Property<int>("CourseId");

                    b.Property<int>("ClassRoomId");

                    b.HasKey("CourseId", "ClassRoomId");

                    b.HasIndex("ClassRoomId");

                    b.ToTable("ClassRoomCourse");
                });

            modelBuilder.Entity("FPTManagerSutdent.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<DateTime>("ExpiredAt");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("FPTManagerSutdent.Models.Mark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Assignment");

                    b.Property<int>("CourseId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("Practice");

                    b.Property<int>("StudentId");

                    b.Property<int>("Theory");

                    b.Property<DateTime>("UpdateAt");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("Mark");
                });

            modelBuilder.Entity("FPTManagerSutdent.Models.MyCredential", b =>
                {
                    b.Property<string>("AccessToken")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("ExpireAt");

                    b.Property<long>("OwnerId");

                    b.Property<int>("Status");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("AccessToken");

                    b.ToTable("MyCredentials");
                });

            modelBuilder.Entity("FPTManagerSutdent.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId");

                    b.Property<string>("Address");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("DoB");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<int>("Gender");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Phone");

                    b.Property<int>("Status");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("Student");
                });

            modelBuilder.Entity("FPTManagerSutdent.Models.StudentClassRoom", b =>
                {
                    b.Property<int>("ClassRoomId");

                    b.Property<int>("StudentId");

                    b.HasKey("ClassRoomId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentClassRoom");
                });

            modelBuilder.Entity("FPTManagerSutdent.Models.StudentCourse", b =>
                {
                    b.Property<int>("CourseId");

                    b.Property<int>("StudentId");

                    b.HasKey("CourseId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentCourse");
                });

            modelBuilder.Entity("FPTManagerSutdent.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<int>("Status");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("FPTManagerSutdent.Models.ClassRoomCourse", b =>
                {
                    b.HasOne("FPTManagerSutdent.Models.ClassRoom", "ClassRoom")
                        .WithMany("ClassRoomCourses")
                        .HasForeignKey("ClassRoomId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FPTManagerSutdent.Models.Course", "Course")
                        .WithMany("ClassRoomCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FPTManagerSutdent.Models.Mark", b =>
                {
                    b.HasOne("FPTManagerSutdent.Models.Course", "Course")
                        .WithMany("Marks")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FPTManagerSutdent.Models.Student", "Student")
                        .WithMany("Marks")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FPTManagerSutdent.Models.Student", b =>
                {
                    b.HasOne("FPTManagerSutdent.Models.Account", "Account")
                        .WithOne("Student")
                        .HasForeignKey("FPTManagerSutdent.Models.Student", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FPTManagerSutdent.Models.StudentClassRoom", b =>
                {
                    b.HasOne("FPTManagerSutdent.Models.ClassRoom", "ClassRoom")
                        .WithMany("StudentClassRooms")
                        .HasForeignKey("ClassRoomId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FPTManagerSutdent.Models.Student", "Student")
                        .WithMany("StudentClassRooms")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FPTManagerSutdent.Models.StudentCourse", b =>
                {
                    b.HasOne("FPTManagerSutdent.Models.Course", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FPTManagerSutdent.Models.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FPTManagerSutdent.Models.Teacher", b =>
                {
                    b.HasOne("FPTManagerSutdent.Models.Account", "Account")
                        .WithOne("Teacher")
                        .HasForeignKey("FPTManagerSutdent.Models.Teacher", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
