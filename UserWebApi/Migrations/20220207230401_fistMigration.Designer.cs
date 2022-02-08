﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserWebApi.Models.DataBase;

namespace UserWebApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220207230401_fistMigration")]
    partial class fistMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("UserWebApi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("avatar_url")
                        .HasColumnType("TEXT");

                    b.Property<string>("events_url")
                        .HasColumnType("TEXT");

                    b.Property<string>("followers_url")
                        .HasColumnType("TEXT");

                    b.Property<string>("following_url")
                        .HasColumnType("TEXT");

                    b.Property<string>("gists_url")
                        .HasColumnType("TEXT");

                    b.Property<string>("gravatar_id")
                        .HasColumnType("TEXT");

                    b.Property<string>("html_url")
                        .HasColumnType("TEXT");

                    b.Property<string>("login")
                        .HasColumnType("TEXT");

                    b.Property<string>("node_id")
                        .HasColumnType("TEXT");

                    b.Property<string>("organizations_url")
                        .HasColumnType("TEXT");

                    b.Property<string>("received_events_url")
                        .HasColumnType("TEXT");

                    b.Property<string>("repos_url")
                        .HasColumnType("TEXT");

                    b.Property<string>("site_admin")
                        .HasColumnType("TEXT");

                    b.Property<string>("starred_url")
                        .HasColumnType("TEXT");

                    b.Property<string>("subscriptions_url")
                        .HasColumnType("TEXT");

                    b.Property<string>("type")
                        .HasColumnType("TEXT");

                    b.Property<string>("url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
