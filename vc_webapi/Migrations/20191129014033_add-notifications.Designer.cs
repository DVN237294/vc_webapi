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
    [Migration("20191129014033_add-notifications")]
    partial class addnotifications
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.0.1")
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

                    b.Property<long?>("VideoId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("VideoId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = -1L,
                            CommentTime = new DateTime(2019, 10, 5, 22, 3, 59, 0, DateTimeKind.Unspecified),
                            Message = "Comment to test notifications! @teststudent",
                            UserId = -1L,
                            VideoId = -1L
                        });
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
                            Id = -1L,
                            Name = "SDJ1",
                            WebuntisCourseId = -1L
                        },
                        new
                        {
                            Id = -2L,
                            Name = "AJP1",
                            WebuntisCourseId = -2L
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
                            Id = -1L,
                            CourseId = -1L,
                            EnrollmentDateUtc = new DateTime(2019, 8, 25, 1, 48, 40, 606, DateTimeKind.Utc),
                            UserId = -1L
                        },
                        new
                        {
                            Id = -2L,
                            CourseId = -2L,
                            EnrollmentDateUtc = new DateTime(2019, 8, 25, 1, 48, 40, 606, DateTimeKind.Utc),
                            UserId = -1L
                        });
                });

            modelBuilder.Entity("vc_webapi.Model.Notification", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Dismissed")
                        .HasColumnType("boolean");

                    b.Property<string>("Message")
                        .HasColumnType("text");

                    b.Property<DateTime>("NotificationTimeUtc")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("RouterLink")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");

                    b.HasData(
                        new
                        {
                            Id = -1L,
                            Dismissed = false,
                            Message = "You were mentioned in a comment by BPR Test Student, in video \"SDJ Lesson 1\"",
                            NotificationTimeUtc = new DateTime(2019, 10, 5, 22, 4, 2, 0, DateTimeKind.Unspecified),
                            RouterLink = "Comment",
                            UserId = -1L
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
                            Id = -1L,
                            SessionId = -1L,
                            UserId = -1L
                        },
                        new
                        {
                            Id = -2L,
                            SessionId = -2L,
                            UserId = -1L
                        },
                        new
                        {
                            Id = -3L,
                            SessionId = -3L,
                            UserId = -1L
                        },
                        new
                        {
                            Id = -4L,
                            SessionId = -4L,
                            UserId = -1L
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
                            Id = -1L,
                            Name = "F.301a UV",
                            WebuntisId = 1319L
                        },
                        new
                        {
                            Id = -2L,
                            Name = "F.301b UV",
                            WebuntisId = 1320L
                        },
                        new
                        {
                            Id = -3L,
                            Name = "F.302a UV",
                            WebuntisId = 1321L
                        },
                        new
                        {
                            Id = -4L,
                            Name = "F.302b UV",
                            WebuntisId = 1322L
                        },
                        new
                        {
                            Id = -5L,
                            Name = "F.304 UV",
                            WebuntisId = 1323L
                        });
                });

            modelBuilder.Entity("vc_webapi.Model.RouterLinkParam", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("NotificationId")
                        .HasColumnType("bigint");

                    b.Property<string>("Param")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("NotificationId");

                    b.ToTable("RouterLinkParam");

                    b.HasData(
                        new
                        {
                            Id = -1L,
                            NotificationId = -1L,
                            Param = "VideoId",
                            Value = "-1"
                        },
                        new
                        {
                            Id = -2L,
                            NotificationId = -1L,
                            Param = "CommentId",
                            Value = "-1"
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
                            Id = -1L,
                            CourseId = -1L,
                            Date = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = -2L,
                            CourseId = -1L,
                            Date = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = -3L,
                            CourseId = -2L,
                            Date = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = -4L,
                            CourseId = -2L,
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
                            Id = -1L,
                            Name = "SDJ Lesson 1",
                            PropertiesId = -1L,
                            RecordTimeUtc = new DateTime(2019, 11, 23, 1, 48, 40, 606, DateTimeKind.Utc),
                            SessionId = -1L,
                            StreamUrl = "/api/Videostream/-1",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = -2L,
                            Name = "SDJ Lesson 1 part 2",
                            PropertiesId = -1L,
                            RecordTimeUtc = new DateTime(2019, 11, 23, 2, 33, 40, 606, DateTimeKind.Utc),
                            SessionId = -1L,
                            StreamUrl = "/api/Videostream/-2",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = -3L,
                            Name = "SDJ Lesson 1 part 3",
                            PropertiesId = -1L,
                            RecordTimeUtc = new DateTime(2019, 11, 23, 3, 18, 40, 606, DateTimeKind.Utc),
                            SessionId = -1L,
                            StreamUrl = "/api/Videostream/-3",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = -4L,
                            Name = "SDJ Lesson 1 part 4",
                            PropertiesId = -1L,
                            RecordTimeUtc = new DateTime(2019, 11, 23, 4, 13, 40, 606, DateTimeKind.Utc),
                            SessionId = -1L,
                            StreamUrl = "/api/Videostream/-4",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = -5L,
                            Name = "SDJ Lesson 2",
                            PropertiesId = -1L,
                            RecordTimeUtc = new DateTime(2019, 11, 30, 1, 48, 40, 606, DateTimeKind.Utc),
                            SessionId = -2L,
                            StreamUrl = "/api/Videostream/-5",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = -6L,
                            Name = "SDJ Lesson 2 part 2",
                            PropertiesId = -1L,
                            RecordTimeUtc = new DateTime(2019, 11, 30, 2, 33, 40, 606, DateTimeKind.Utc),
                            SessionId = -2L,
                            StreamUrl = "/api/Videostream/-6",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = -7L,
                            Name = "SDJ Lesson 2 part 3",
                            PropertiesId = -1L,
                            RecordTimeUtc = new DateTime(2019, 11, 30, 3, 18, 40, 606, DateTimeKind.Utc),
                            SessionId = -2L,
                            StreamUrl = "/api/Videostream/-7",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = -8L,
                            Name = "SDJ Lesson 2 part 4",
                            PropertiesId = -1L,
                            RecordTimeUtc = new DateTime(2019, 11, 30, 4, 13, 40, 606, DateTimeKind.Utc),
                            SessionId = -2L,
                            StreamUrl = "/api/Videostream/-8",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = -9L,
                            Name = "AJP Lesson 1",
                            PropertiesId = -1L,
                            RecordTimeUtc = new DateTime(2019, 11, 24, 1, 48, 40, 606, DateTimeKind.Utc),
                            SessionId = -3L,
                            StreamUrl = "/api/Videostream/-9",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = -10L,
                            Name = "AJP Lesson 1 part 2",
                            PropertiesId = -1L,
                            RecordTimeUtc = new DateTime(2019, 11, 24, 2, 33, 40, 606, DateTimeKind.Utc),
                            SessionId = -3L,
                            StreamUrl = "/api/Videostream/-10",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = -11L,
                            Name = "AJP Lesson 1 part 3",
                            PropertiesId = -1L,
                            RecordTimeUtc = new DateTime(2019, 11, 24, 3, 18, 40, 606, DateTimeKind.Utc),
                            SessionId = -3L,
                            StreamUrl = "/api/Videostream/-11",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = -12L,
                            Name = "AJP Lesson 1 part 4",
                            PropertiesId = -1L,
                            RecordTimeUtc = new DateTime(2019, 11, 24, 4, 13, 40, 606, DateTimeKind.Utc),
                            SessionId = -3L,
                            StreamUrl = "/api/Videostream/-12",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = -13L,
                            Name = "AJP Lesson 2",
                            PropertiesId = -1L,
                            RecordTimeUtc = new DateTime(2019, 12, 1, 1, 48, 40, 606, DateTimeKind.Utc),
                            SessionId = -4L,
                            StreamUrl = "/api/Videostream/-13",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = -14L,
                            Name = "AJP Lesson 2 part 2",
                            PropertiesId = -1L,
                            RecordTimeUtc = new DateTime(2019, 12, 1, 2, 33, 40, 606, DateTimeKind.Utc),
                            SessionId = -4L,
                            StreamUrl = "/api/Videostream/-14",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = -15L,
                            Name = "AJP Lesson 2 part 3",
                            PropertiesId = -1L,
                            RecordTimeUtc = new DateTime(2019, 12, 1, 3, 18, 40, 606, DateTimeKind.Utc),
                            SessionId = -4L,
                            StreamUrl = "/api/Videostream/-15",
                            ThumbnailURL = "/assets/video.jpeg"
                        },
                        new
                        {
                            Id = -16L,
                            Name = "AJP Lesson 2 part 4",
                            PropertiesId = -1L,
                            RecordTimeUtc = new DateTime(2019, 12, 1, 4, 13, 40, 606, DateTimeKind.Utc),
                            SessionId = -4L,
                            StreamUrl = "/api/Videostream/-16",
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
                            Id = -1L,
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
                            Id = -1L,
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

            modelBuilder.Entity("vc_webapi.Model.Notification", b =>
                {
                    b.HasOne("vc_webapi.Model.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("vc_webapi.Model.RouterLinkParam", b =>
                {
                    b.HasOne("vc_webapi.Model.Notification", null)
                        .WithMany("RouterLinkParameters")
                        .HasForeignKey("NotificationId");
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
