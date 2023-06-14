﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wordle.Api.Data;

#nullable disable

namespace Wordle.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Wordle.Api.Data.DailyCompletions", b =>
                {
                    b.Property<int>("DateWordId")
                        .HasColumnType("int");

                    b.Property<string>("PlayerName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("DateWordId", "PlayerName");

                    b.ToTable("DailyCompletions");
                });

            modelBuilder.Entity("Wordle.Api.Data.DateWord", b =>
                {
                    b.Property<int>("DateWordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DateWordId"));

                    b.Property<double>("AverageAttempts")
                        .HasColumnType("float");

                    b.Property<double>("AverageSeconds")
                        .HasColumnType("float");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Plays")
                        .HasColumnType("int");

                    b.Property<int>("WordId")
                        .HasColumnType("int");

                    b.HasKey("DateWordId");

                    b.HasIndex("Date")
                        .IsUnique();

                    b.HasIndex("WordId");

                    b.ToTable("DateWords");
                });

            modelBuilder.Entity("Wordle.Api.Data.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayerId"));

                    b.Property<double>("AverageAttempts")
                        .HasColumnType("float");

                    b.Property<int>("GameCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlayerId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Wordle.Api.Data.Word", b =>
                {
                    b.Property<int>("WordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WordId"));

                    b.Property<bool>("IsCommon")
                        .HasColumnType("bit");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WordId");

                    b.ToTable("Words");
                });

            modelBuilder.Entity("Wordle.Api.Data.DateWord", b =>
                {
                    b.HasOne("Wordle.Api.Data.Word", "Word")
                        .WithMany("DateWords")
                        .HasForeignKey("WordId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Word");
                });

            modelBuilder.Entity("Wordle.Api.Data.Word", b =>
                {
                    b.Navigation("DateWords");
                });
#pragma warning restore 612, 618
        }
    }
}