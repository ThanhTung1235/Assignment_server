﻿// <auto-generated />
using System;
using FPTManagerSutdent.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FPTManagerSutdent.Migrations
{
    [DbContext(typeof(Datacontext))]
    partial class DatacontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<DateTime>("ExpiredAt");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("FPTManagerSutdent.Models.Mark", b =>
                {
                    b.Property<int>("CourseId");

                    b.Property<int>("StudentId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("Id");

                    b.Property<int>("Status");

                    b.Property<int>("Type");

                    b.Property<int>("TypeMark");

                    b.Property<DateTime>("UpdateAt");

                    b.Property<int>("Value");

                    b.HasKey("CourseId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("Mark");
                });

            modelBuilder.Entity("FPTManagerSutdent.Models.MyCredential", b =>
                {
                    b.Property<string>("AccessToken")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("ExpireAt");

                    b.Property<int>("OwnerId");

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

                    b.Property<string>("Address");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("DoB");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<int>("Gender");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Password");

                    b.Property<string>("Phone");

                    b.Property<string>("Salt");

                    b.Property<int>("Status");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("FPTManagerSutdent.Models.StudentClassRoom", b =>
                {
                    b.Property<int>("ClassRoomId");

                    b.Property<int>("StudentId");

                    b.Property<DateTime>("JoinedAt");

                    b.Property<DateTime>("LeftAt");

                    b.Property<int>("Status");

                    b.HasKey("ClassRoomId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentClassRoom");
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
#pragma warning restore 612, 618
        }
    }
}
