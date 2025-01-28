﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SportsTournamentApp.Data;

#nullable disable

namespace SportsTournamentApp.Migrations
{
    [DbContext(typeof(SportsTournamentAppContext))]
    partial class SportsTournamentAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SportsTournamentApp.Models.Match", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MatchDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ScoreTeamA")
                        .HasColumnType("int");

                    b.Property<int?>("ScoreTeamB")
                        .HasColumnType("int");

                    b.Property<int>("TeamAID")
                        .HasColumnType("int");

                    b.Property<int?>("TeamBID")
                        .HasColumnType("int");

                    b.Property<int?>("TournamentID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TeamAID");

                    b.HasIndex("TeamBID");

                    b.HasIndex("TournamentID");

                    b.ToTable("Match");
                });

            modelBuilder.Entity("SportsTournamentApp.Models.Player", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeamID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TeamID");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("SportsTournamentApp.Models.Team", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Coach")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FoundingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("SportsTournamentApp.Models.Tournament", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Spotlight")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("WinningTeamID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("WinningTeamID");

                    b.ToTable("Tournament");
                });

            modelBuilder.Entity("SportsTournamentApp.Models.Match", b =>
                {
                    b.HasOne("SportsTournamentApp.Models.Team", "TeamA")
                        .WithMany()
                        .HasForeignKey("TeamAID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportsTournamentApp.Models.Team", "TeamB")
                        .WithMany()
                        .HasForeignKey("TeamBID");

                    b.HasOne("SportsTournamentApp.Models.Tournament", "Tournament")
                        .WithMany("Matches")
                        .HasForeignKey("TournamentID");

                    b.Navigation("TeamA");

                    b.Navigation("TeamB");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("SportsTournamentApp.Models.Player", b =>
                {
                    b.HasOne("SportsTournamentApp.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamID");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("SportsTournamentApp.Models.Tournament", b =>
                {
                    b.HasOne("SportsTournamentApp.Models.Team", "WinningTeam")
                        .WithMany()
                        .HasForeignKey("WinningTeamID");

                    b.Navigation("WinningTeam");
                });

            modelBuilder.Entity("SportsTournamentApp.Models.Tournament", b =>
                {
                    b.Navigation("Matches");
                });
#pragma warning restore 612, 618
        }
    }
}
