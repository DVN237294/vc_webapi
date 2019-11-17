﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using vc_webapi.Data;

namespace vc_webapi.Migrations
{
    [DbContext(typeof(Vc_webapiContext))]
    [Migration("20191111203256_addTeacher")]
    partial class addTeacher
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("vc_webapi.Model.Comment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CommentTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Message")
                        .HasColumnType("text");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.Property<long?>("VideoId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("VideoId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("vc_webapi.Model.Course", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 100L,
                            Name = "SDJ1"
                        },
                        new
                        {
                            Id = 101L,
                            Name = "AJP1"
                        });
                });

            modelBuilder.Entity("vc_webapi.Model.Enrollment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("EnrollmentDateUtc")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("UserId");

                    b.ToTable("Enrollments");

                    b.HasData(
                        new
                        {
                            Id = 100L,
                            CourseId = 100L,
                            EnrollmentDateUtc = new DateTime(2019, 8, 13, 20, 32, 55, 190, DateTimeKind.Utc).AddTicks(1966),
                            UserId = 100L
                        },
                        new
                        {
                            Id = 101L,
                            CourseId = 101L,
                            EnrollmentDateUtc = new DateTime(2019, 8, 13, 20, 32, 55, 190, DateTimeKind.Utc).AddTicks(3440),
                            UserId = 100L
                        });
                });

            modelBuilder.Entity("vc_webapi.Model.Session", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Session");

                    b.HasData(
                        new
                        {
                            Id = 100L,
                            CourseId = 100L,
                            Date = new DateTime(2019, 11, 11, 20, 32, 55, 189, DateTimeKind.Utc).AddTicks(6844)
                        },
                        new
                        {
                            Id = 101L,
                            CourseId = 100L,
                            Date = new DateTime(2019, 11, 11, 20, 32, 55, 189, DateTimeKind.Utc).AddTicks(7942)
                        },
                        new
                        {
                            Id = 102L,
                            CourseId = 101L,
                            Date = new DateTime(2019, 11, 11, 20, 32, 55, 190, DateTimeKind.Utc).AddTicks(132)
                        },
                        new
                        {
                            Id = 103L,
                            CourseId = 101L,
                            Date = new DateTime(2019, 11, 11, 20, 32, 55, 190, DateTimeKind.Utc).AddTicks(132)
                        });
                });

            modelBuilder.Entity("vc_webapi.Model.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.Property<bool>("isTeacher")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("vc_webapi.Model.UserSession", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("SessionId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SessionId");

                    b.HasIndex("UserId");

                    b.ToTable("UserSession");

                    b.HasData(
                        new
                        {
                            Id = 100L,
                            SessionId = 100L,
                            UserId = 100L
                        },
                        new
                        {
                            Id = 101L,
                            SessionId = 101L,
                            UserId = 100L
                        },
                        new
                        {
                            Id = 102L,
                            SessionId = 102L,
                            UserId = 100L
                        },
                        new
                        {
                            Id = 103L,
                            SessionId = 103L,
                            UserId = 100L
                        });
                });

            modelBuilder.Entity("vc_webapi.Model.Video", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("PropertiesId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("RecordTimeUtc")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("SessionId")
                        .HasColumnType("bigint");

                    b.Property<string>("StreamUrl")
                        .HasColumnType("text");

                    b.Property<string>("ThumbnailURL")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PropertiesId");

                    b.HasIndex("SessionId");

                    b.ToTable("Videos");

                    b.HasData(
                        new
                        {
                            Id = 100L,
                            Name = "SDJ Lesson 1",
                            PropertiesId = 100L,
                            RecordTimeUtc = new DateTime(2019, 11, 11, 20, 32, 55, 189, DateTimeKind.Utc).AddTicks(3180),
                            SessionId = 100L,
                            StreamUrl = "/api/Videostream/100",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = 101L,
                            Name = "SDJ Lesson 1 part 2",
                            PropertiesId = 100L,
                            RecordTimeUtc = new DateTime(2019, 11, 11, 21, 17, 55, 189, DateTimeKind.Utc).AddTicks(6481),
                            SessionId = 100L,
                            StreamUrl = "/api/Videostream/101",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = 102L,
                            Name = "SDJ Lesson 1 part 3",
                            PropertiesId = 100L,
                            RecordTimeUtc = new DateTime(2019, 11, 11, 22, 2, 55, 189, DateTimeKind.Utc).AddTicks(6748),
                            SessionId = 100L,
                            StreamUrl = "/api/Videostream/102",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = 103L,
                            Name = "SDJ Lesson 1 part 4",
                            PropertiesId = 100L,
                            RecordTimeUtc = new DateTime(2019, 11, 11, 22, 57, 55, 189, DateTimeKind.Utc).AddTicks(6752),
                            SessionId = 100L,
                            StreamUrl = "/api/Videostream/103",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = 104L,
                            Name = "SDJ Lesson 2",
                            PropertiesId = 100L,
                            RecordTimeUtc = new DateTime(2019, 11, 18, 20, 32, 55, 189, DateTimeKind.Utc).AddTicks(6755),
                            SessionId = 101L,
                            StreamUrl = "/api/Videostream/104",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = 105L,
                            Name = "SDJ Lesson 2 part 2",
                            PropertiesId = 100L,
                            RecordTimeUtc = new DateTime(2019, 11, 18, 21, 17, 55, 189, DateTimeKind.Utc).AddTicks(6772),
                            SessionId = 101L,
                            StreamUrl = "/api/Videostream/105",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = 106L,
                            Name = "SDJ Lesson 2 part 3",
                            PropertiesId = 100L,
                            RecordTimeUtc = new DateTime(2019, 11, 18, 22, 2, 55, 189, DateTimeKind.Utc).AddTicks(6776),
                            SessionId = 101L,
                            StreamUrl = "/api/Videostream/106",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = 107L,
                            Name = "SDJ Lesson 2 part 4",
                            PropertiesId = 100L,
                            RecordTimeUtc = new DateTime(2019, 11, 18, 22, 57, 55, 189, DateTimeKind.Utc).AddTicks(6841),
                            SessionId = 101L,
                            StreamUrl = "/api/Videostream/107",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = 108L,
                            Name = "AJP Lesson 1",
                            PropertiesId = 100L,
                            RecordTimeUtc = new DateTime(2019, 11, 12, 20, 32, 55, 190, DateTimeKind.Utc).AddTicks(111),
                            SessionId = 102L,
                            StreamUrl = "/api/Videostream/108",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = 109L,
                            Name = "AJP Lesson 1 part 2",
                            PropertiesId = 100L,
                            RecordTimeUtc = new DateTime(2019, 11, 12, 21, 17, 55, 190, DateTimeKind.Utc).AddTicks(118),
                            SessionId = 102L,
                            StreamUrl = "/api/Videostream/109",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = 110L,
                            Name = "AJP Lesson 1 part 3",
                            PropertiesId = 100L,
                            RecordTimeUtc = new DateTime(2019, 11, 12, 22, 2, 55, 190, DateTimeKind.Utc).AddTicks(122),
                            SessionId = 102L,
                            StreamUrl = "/api/Videostream/110",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = 111L,
                            Name = "AJP Lesson 1 part 4",
                            PropertiesId = 100L,
                            RecordTimeUtc = new DateTime(2019, 11, 12, 22, 57, 55, 190, DateTimeKind.Utc).AddTicks(122),
                            SessionId = 102L,
                            StreamUrl = "/api/Videostream/111",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = 112L,
                            Name = "AJP Lesson 2",
                            PropertiesId = 100L,
                            RecordTimeUtc = new DateTime(2019, 11, 19, 20, 32, 55, 190, DateTimeKind.Utc).AddTicks(125),
                            SessionId = 103L,
                            StreamUrl = "/api/Videostream/112",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = 113L,
                            Name = "AJP Lesson 2 part 2",
                            PropertiesId = 100L,
                            RecordTimeUtc = new DateTime(2019, 11, 19, 21, 17, 55, 190, DateTimeKind.Utc).AddTicks(125),
                            SessionId = 103L,
                            StreamUrl = "/api/Videostream/113",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = 114L,
                            Name = "AJP Lesson 2 part 3",
                            PropertiesId = 100L,
                            RecordTimeUtc = new DateTime(2019, 11, 19, 22, 2, 55, 190, DateTimeKind.Utc).AddTicks(128),
                            SessionId = 103L,
                            StreamUrl = "/api/Videostream/114",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = 115L,
                            Name = "AJP Lesson 2 part 4",
                            PropertiesId = 100L,
                            RecordTimeUtc = new DateTime(2019, 11, 19, 22, 57, 55, 190, DateTimeKind.Utc).AddTicks(128),
                            SessionId = 103L,
                            StreamUrl = "/api/Videostream/115",
                            ThumbnailURL = "/assets/video.jpeg"
                        });
                });

            modelBuilder.Entity("vc_webapi.Model.VideoProperties", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ContainerExt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Duration")
                        .HasColumnType("bigint");

                    b.Property<long>("FileSize")
                        .HasColumnType("bigint");

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<string>("MimeType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("VirtualFilePath")
                        .HasColumnType("text");

                    b.Property<int>("Width")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("VideoProperties");

                    b.HasData(
                        new
                        {
                            Id = 100L,
                            ContainerExt = "mp4",
                            Duration = 10000L,
                            FileSize = 788493L,
                            Height = 176,
                            MimeType = "video/mp4",
                            VirtualFilePath = "testvideo.mp4",
                            Width = 320
                        });
                });

            modelBuilder.Entity("vc_webapi.Model.Student", b =>
                {
                    b.HasBaseType("vc_webapi.Model.User");

                    b.HasDiscriminator().HasValue("Student");

                    b.HasData(
                        new
                        {
                            Id = 100L,
                            Email = "some@mail.com",
                            FullName = "BPR Test Student",
                            UserName = "teststudent",
                            isTeacher = false
                        });
                });

            modelBuilder.Entity("vc_webapi.Model.Users.Admin", b =>
                {
                    b.HasBaseType("vc_webapi.Model.User");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("vc_webapi.Model.Comment", b =>
                {
                    b.HasOne("vc_webapi.Model.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId");

                    b.HasOne("vc_webapi.Model.Video", "Video")
                        .WithMany("Comments")
                        .HasForeignKey("VideoId");
                });

            modelBuilder.Entity("vc_webapi.Model.Enrollment", b =>
                {
                    b.HasOne("vc_webapi.Model.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId");

                    b.HasOne("vc_webapi.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("vc_webapi.Model.Session", b =>
                {
                    b.HasOne("vc_webapi.Model.Course", null)
                        .WithMany("Sessions")
                        .HasForeignKey("CourseId");
                });

            modelBuilder.Entity("vc_webapi.Model.UserSession", b =>
                {
                    b.HasOne("vc_webapi.Model.Session", "Session")
                        .WithMany("UserSessions")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("vc_webapi.Model.User", "User")
                        .WithMany("Sessions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("vc_webapi.Model.Video", b =>
                {
                    b.HasOne("vc_webapi.Model.VideoProperties", "Properties")
                        .WithMany()
                        .HasForeignKey("PropertiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("vc_webapi.Model.Session", null)
                        .WithMany("Recordings")
                        .HasForeignKey("SessionId");
                });
#pragma warning restore 612, 618
        }
    }
}
