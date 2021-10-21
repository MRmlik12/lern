﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Lern.Core.ProjectAggregate.Set;
using Lern.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Lern.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Lern.Core.ProjectAggregate.Group.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("Admin")
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<List<Guid>>("MembersId")
                        .HasColumnType("uuid[]");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<List<Guid>>("SetCollectionId")
                        .HasColumnType("uuid[]");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Admin");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Lern.Core.ProjectAggregate.Set.Set", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("Author")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<List<SetItem>>("Items")
                        .HasColumnType("jsonb");

                    b.Property<string>("Language")
                        .HasColumnType("text");

                    b.Property<List<string>>("Tags")
                        .HasColumnType("text[]");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Author");

                    b.ToTable("Sets");
                });

            modelBuilder.Entity("Lern.Core.ProjectAggregate.User.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AvatarUrl")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<Guid?>("Stars")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Stars");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Lern.Core.ProjectAggregate.Group.Group", b =>
                {
                    b.HasOne("Lern.Core.ProjectAggregate.User.User", "User")
                        .WithMany()
                        .HasForeignKey("Admin");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Lern.Core.ProjectAggregate.Set.Set", b =>
                {
                    b.HasOne("Lern.Core.ProjectAggregate.User.User", "User")
                        .WithMany()
                        .HasForeignKey("Author");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Lern.Core.ProjectAggregate.User.User", b =>
                {
                    b.HasOne("Lern.Core.ProjectAggregate.Set.Set", null)
                        .WithMany("Stars")
                        .HasForeignKey("Stars");
                });

            modelBuilder.Entity("Lern.Core.ProjectAggregate.Set.Set", b =>
                {
                    b.Navigation("Stars");
                });
#pragma warning restore 612, 618
        }
    }
}
