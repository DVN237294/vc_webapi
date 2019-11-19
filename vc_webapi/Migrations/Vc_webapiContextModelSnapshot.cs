﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using vc_webapi.Data;

namespace vc_webapi.Migrations
{
    [DbContext(typeof(Vc_webapiContext))]
    partial class Vc_webapiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<long>("WebuntisCourseId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 9223372036854775807L,
                            Name = "SDJ1",
                            WebuntisCourseId = 9223372036854775807L
                        },
                        new
                        {
                            Id = 9223372036854775806L,
                            Name = "AJP1",
                            WebuntisCourseId = 9223372036854775806L
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
                            Id = 9223372036854775807L,
                            CourseId = 9223372036854775807L,
                            EnrollmentDateUtc = new DateTime(2019, 8, 25, 1, 48, 40, 606, DateTimeKind.Utc),
                            UserId = 9223372036854775807L
                        },
                        new
                        {
                            Id = 9223372036854775806L,
                            CourseId = 9223372036854775806L,
                            EnrollmentDateUtc = new DateTime(2019, 8, 25, 1, 48, 40, 606, DateTimeKind.Utc),
                            UserId = 9223372036854775807L
                        });
                });

            modelBuilder.Entity("vc_webapi.Model.Participant", b =>
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

                    b.ToTable("Participant");

                    b.HasData(
                        new
                        {
                            Id = 9223372036854775807L,
                            SessionId = 9223372036854775807L,
                            UserId = 9223372036854775807L
                        },
                        new
                        {
                            Id = 9223372036854775806L,
                            SessionId = 9223372036854775806L,
                            UserId = 9223372036854775807L
                        },
                        new
                        {
                            Id = 9223372036854775805L,
                            SessionId = 9223372036854775805L,
                            UserId = 9223372036854775807L
                        },
                        new
                        {
                            Id = 9223372036854775804L,
                            SessionId = 9223372036854775804L,
                            UserId = 9223372036854775807L
                        });
                });

            modelBuilder.Entity("vc_webapi.Model.Room", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<long>("WebuntisId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 9223372036854775807L,
                            Name = "F.301a UV",
                            WebuntisId = 1319L
                        },
                        new
                        {
                            Id = 9223372036854775806L,
                            Name = "F.301b UV",
                            WebuntisId = 1320L
                        },
                        new
                        {
                            Id = 9223372036854775805L,
                            Name = "F.302a UV",
                            WebuntisId = 1321L
                        },
                        new
                        {
                            Id = 9223372036854775804L,
                            Name = "F.302b UV",
                            WebuntisId = 1322L
                        },
                        new
                        {
                            Id = 9223372036854775803L,
                            Name = "F.304 UV",
                            WebuntisId = 1323L
                        });
                });

            modelBuilder.Entity("vc_webapi.Model.ScheduledSession", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("RoomId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("WebuntisCourseId")
                        .HasColumnType("bigint");

                    b.Property<long>("WebuntisId")
                        .HasColumnType("bigint");

                    b.Property<long[]>("WebuntisTeacherIds")
                        .HasColumnType("bigint[]");

                    b.HasKey("Id");

                    b.HasAlternateKey("WebuntisId");

                    b.HasIndex("RoomId");

                    b.HasIndex("WebuntisCourseId");

                    b.ToTable("ScheduledSessions");
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
                            Id = 9223372036854775807L,
                            CourseId = 9223372036854775807L,
                            Date = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 9223372036854775806L,
                            CourseId = 9223372036854775807L,
                            Date = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 9223372036854775805L,
                            CourseId = 9223372036854775806L,
                            Date = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 9223372036854775804L,
                            CourseId = 9223372036854775806L,
                            Date = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc)
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
                            Id = 9223372036854775807L,
                            Name = "SDJ Lesson 1",
                            PropertiesId = 9223372036854775807L,
                            RecordTimeUtc = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc),
                            SessionId = 9223372036854775807L,
                            StreamUrl = "/api/Videostream/100",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = 9223372036854775806L,
                            Name = "SDJ Lesson 1 part 2",
                            PropertiesId = 9223372036854775807L,
                            RecordTimeUtc = new DateTime(2019, 11, 23, 2, 33, 40, 606, DateTimeKind.Utc),
                            SessionId = 9223372036854775807L,
                            StreamUrl = "/api/Videostream/101",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = 9223372036854775805L,
                            Name = "SDJ Lesson 1 part 3",
                            PropertiesId = 9223372036854775807L,
                            RecordTimeUtc = new DateTime(2019, 11, 23, 3, 18, 40, 606, DateTimeKind.Utc),
                            SessionId = 9223372036854775807L,
                            StreamUrl = "/api/Videostream/102",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = 9223372036854775804L,
                            Name = "SDJ Lesson 1 part 4",
                            PropertiesId = 9223372036854775807L,
                            RecordTimeUtc = new DateTime(2019, 11, 23, 4, 13, 40, 606, DateTimeKind.Utc),
                            SessionId = 9223372036854775807L,
                            StreamUrl = "/api/Videostream/103",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = 9223372036854775803L,
                            Name = "SDJ Lesson 2",
                            PropertiesId = 9223372036854775807L,
                            RecordTimeUtc = new DateTime(2019, 11, 30, 1, 48, 40, 606, DateTimeKind.Utc),
                            SessionId = 9223372036854775806L,
                            StreamUrl = "/api/Videostream/104",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = 9223372036854775802L,
                            Name = "SDJ Lesson 2 part 2",
                            PropertiesId = 9223372036854775807L,
                            RecordTimeUtc = new DateTime(2019, 11, 30, 2, 33, 40, 606, DateTimeKind.Utc),
                            SessionId = 9223372036854775806L,
                            StreamUrl = "/api/Videostream/105",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = 9223372036854775801L,
                            Name = "SDJ Lesson 2 part 3",
                            PropertiesId = 9223372036854775807L,
                            RecordTimeUtc = new DateTime(2019, 11, 30, 3, 18, 40, 606, DateTimeKind.Utc),
                            SessionId = 9223372036854775806L,
                            StreamUrl = "/api/Videostream/106",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = 9223372036854775800L,
                            Name = "SDJ Lesson 2 part 4",
                            PropertiesId = 9223372036854775807L,
                            RecordTimeUtc = new DateTime(2019, 11, 30, 4, 13, 40, 606, DateTimeKind.Utc),
                            SessionId = 9223372036854775806L,
                            StreamUrl = "/api/Videostream/107",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = 9223372036854775799L,
                            Name = "AJP Lesson 1",
                            PropertiesId = 9223372036854775807L,
                            RecordTimeUtc = new DateTime(2019, 11, 24, 1, 48, 40, 606, DateTimeKind.Utc),
                            SessionId = 9223372036854775805L,
                            StreamUrl = "/api/Videostream/108",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = 9223372036854775798L,
                            Name = "AJP Lesson 1 part 2",
                            PropertiesId = 9223372036854775807L,
                            RecordTimeUtc = new DateTime(2019, 11, 24, 2, 33, 40, 606, DateTimeKind.Utc),
                            SessionId = 9223372036854775805L,
                            StreamUrl = "/api/Videostream/109",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = 9223372036854775797L,
                            Name = "AJP Lesson 1 part 3",
                            PropertiesId = 9223372036854775807L,
                            RecordTimeUtc = new DateTime(2019, 11, 24, 3, 18, 40, 606, DateTimeKind.Utc),
                            SessionId = 9223372036854775805L,
                            StreamUrl = "/api/Videostream/110",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = 9223372036854775796L,
                            Name = "AJP Lesson 1 part 4",
                            PropertiesId = 9223372036854775807L,
                            RecordTimeUtc = new DateTime(2019, 11, 24, 4, 13, 40, 606, DateTimeKind.Utc),
                            SessionId = 9223372036854775805L,
                            StreamUrl = "/api/Videostream/111",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = 9223372036854775795L,
                            Name = "AJP Lesson 2",
                            PropertiesId = 9223372036854775807L,
                            RecordTimeUtc = new DateTime(2019, 12, 1, 1, 48, 40, 606, DateTimeKind.Utc),
                            SessionId = 9223372036854775804L,
                            StreamUrl = "/api/Videostream/112",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = 9223372036854775794L,
                            Name = "AJP Lesson 2 part 2",
                            PropertiesId = 9223372036854775807L,
                            RecordTimeUtc = new DateTime(2019, 12, 1, 2, 33, 40, 606, DateTimeKind.Utc),
                            SessionId = 9223372036854775804L,
                            StreamUrl = "/api/Videostream/113",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = 9223372036854775793L,
                            Name = "AJP Lesson 2 part 3",
                            PropertiesId = 9223372036854775807L,
                            RecordTimeUtc = new DateTime(2019, 12, 1, 3, 18, 40, 606, DateTimeKind.Utc),
                            SessionId = 9223372036854775804L,
                            StreamUrl = "/api/Videostream/114",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = 9223372036854775792L,
                            Name = "AJP Lesson 2 part 4",
                            PropertiesId = 9223372036854775807L,
                            RecordTimeUtc = new DateTime(2019, 12, 1, 4, 13, 40, 606, DateTimeKind.Utc),
                            SessionId = 9223372036854775804L,
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
                            Id = 9223372036854775807L,
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
                            Id = 9223372036854775807L,
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

            modelBuilder.Entity("vc_webapi.Model.Participant", b =>
                {
                    b.HasOne("vc_webapi.Model.Session", "Session")
                        .WithMany("DbParticipants")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("vc_webapi.Model.User", "User")
                        .WithMany("DbParticipants")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("vc_webapi.Model.ScheduledSession", b =>
                {
                    b.HasOne("vc_webapi.Model.Room", "Room")
                        .WithMany("ScheduledSessions")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("vc_webapi.Model.Course", "Course")
                        .WithMany("ScheduledSessions")
                        .HasForeignKey("WebuntisCourseId")
                        .HasPrincipalKey("WebuntisCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("vc_webapi.Model.Session", b =>
                {
                    b.HasOne("vc_webapi.Model.Course", null)
                        .WithMany("Sessions")
                        .HasForeignKey("CourseId");
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
