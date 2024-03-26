﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Mediporta.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Mediporta.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Mediporta.Models.CollectiveExternalLinkModel", b =>
                {
                    b.Property<int>("CollectiveExternalLinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CollectiveExternalLinkId"));

                    b.Property<int>("CollectiveId")
                        .HasColumnType("integer");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("CollectiveExternalLinkId");

                    b.HasIndex("CollectiveId");

                    b.ToTable("CollectiveExternalLinks");
                });

            modelBuilder.Entity("Mediporta.Models.CollectiveModel", b =>
                {
                    b.Property<int>("CollectiveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CollectiveId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CollectiveId");

                    b.ToTable("Collectives");
                });

            modelBuilder.Entity("Mediporta.Models.TagModel", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TagId"));

                    b.Property<int?>("CollectiveId")
                        .HasColumnType("integer");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<bool>("HasSynonyms")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsModeratorOnly")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsRequired")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastActivityDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<string>>("Synonyms")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("TagId");

                    b.HasIndex("CollectiveId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Mediporta.Models.CollectiveExternalLinkModel", b =>
                {
                    b.HasOne("Mediporta.Models.CollectiveModel", "Collective")
                        .WithMany("ExternalLinks")
                        .HasForeignKey("CollectiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Collective");
                });

            modelBuilder.Entity("Mediporta.Models.TagModel", b =>
                {
                    b.HasOne("Mediporta.Models.CollectiveModel", "Collective")
                        .WithMany("Tags")
                        .HasForeignKey("CollectiveId");

                    b.Navigation("Collective");
                });

            modelBuilder.Entity("Mediporta.Models.CollectiveModel", b =>
                {
                    b.Navigation("ExternalLinks");

                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}