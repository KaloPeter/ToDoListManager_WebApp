﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Data.Migrations
{
    [DbContext(typeof(TodoDataContext))]
    partial class TodoDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.25");

            modelBuilder.Entity("API.Entities.Role", b =>
                {
                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleName")
                        .HasColumnType("TEXT");

                    b.HasKey("RoleId");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("API.Entities.ToDoRangedEvent", b =>
                {
                    b.Property<string>("ToDoRangedEventId")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("RangedEventEndDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("RangedEventImportance")
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("RangedEventStartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ToDoRangedEventDescription")
                        .HasColumnType("TEXT");

                    b.Property<string>("ToDoRangedEventName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("ToDoRangedEventId");

                    b.HasIndex("UserId");

                    b.ToTable("ToDoRangedEvents", (string)null);
                });

            modelBuilder.Entity("API.Entities.ToDoSingleEvent", b =>
                {
                    b.Property<string>("ToDoEventId")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("SingleEventDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("SingleEventImportance")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ToDoSingleEventDescription")
                        .HasColumnType("TEXT");

                    b.Property<string>("ToDoSingleEventName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("ToDoEventId");

                    b.HasIndex("UserId");

                    b.ToTable("ToDoSingleEvents", (string)null);
                });

            modelBuilder.Entity("API.Entities.User", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("BLOB");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("API.Entities.ToDoRangedEvent", b =>
                {
                    b.HasOne("API.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("API.Entities.ToDoSingleEvent", b =>
                {
                    b.HasOne("API.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("API.Entities.User", b =>
                {
                    b.HasOne("API.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("API.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
