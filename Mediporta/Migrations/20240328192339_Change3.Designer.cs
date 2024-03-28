﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Mediporta.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Mediporta.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240328192339_Change3")]
    partial class Change3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Mediporta.Models.CollectiveExternalLinkModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CollectiveModelCollectiveId")
                        .HasColumnType("integer");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CollectiveModelCollectiveId");

                    b.ToTable("CollectiveExternalLinks");

                    b.HasAnnotation("Relational:JsonPropertyName", "external_links");
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

                    b.Property<int?>("TagModelTagId")
                        .HasColumnType("integer");

                    b.HasKey("CollectiveId");

                    b.HasIndex("TagModelTagId");

                    b.ToTable("Collectives");

                    b.HasAnnotation("Relational:JsonPropertyName", "collectives");
                });

            modelBuilder.Entity("Mediporta.Models.TagModel", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TagId"));

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

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Mediporta.Models.CollectiveExternalLinkModel", b =>
                {
                    b.HasOne("Mediporta.Models.CollectiveModel", null)
                        .WithMany("ExternalLinks")
                        .HasForeignKey("CollectiveModelCollectiveId");
                });

            modelBuilder.Entity("Mediporta.Models.CollectiveModel", b =>
                {
                    b.HasOne("Mediporta.Models.TagModel", null)
                        .WithMany("Collectives")
                        .HasForeignKey("TagModelTagId");
                });

            modelBuilder.Entity("Mediporta.Models.CollectiveModel", b =>
                {
                    b.Navigation("ExternalLinks");
                });

            modelBuilder.Entity("Mediporta.Models.TagModel", b =>
                {
                    b.Navigation("Collectives");
                });
#pragma warning restore 612, 618
        }
    }
}
