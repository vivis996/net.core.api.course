﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using net.core.api.Data;

namespace net.core.api.Migrations
{
  [DbContext(typeof(DataContext))]
  partial class DataContextModelSnapshot : ModelSnapshot
  {
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
      modelBuilder
          .HasAnnotation("ProductVersion", "5.0.8");

      modelBuilder.Entity("CharacterSkill", b =>
          {
            b.Property<int>("CharactersId")
                      .HasColumnType("INTEGER");

            b.Property<int>("SkillsId")
                      .HasColumnType("INTEGER");

            b.HasKey("CharactersId", "SkillsId");

            b.HasIndex("SkillsId");

            b.ToTable("CharacterSkill");
          });

      modelBuilder.Entity("net.core.api.Models.Character", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("INTEGER");

            b.Property<int>("Class")
                      .HasColumnType("INTEGER");

            b.Property<int>("Defeats")
                      .HasColumnType("INTEGER");

            b.Property<int>("Defense")
                      .HasColumnType("INTEGER");

            b.Property<int>("Fights")
                      .HasColumnType("INTEGER");

            b.Property<int>("HitPoints")
                      .HasColumnType("INTEGER");

            b.Property<int>("Intelligence")
                      .HasColumnType("INTEGER");

            b.Property<string>("Name")
                      .HasColumnType("TEXT");

            b.Property<int>("Strength")
                      .HasColumnType("INTEGER");

            b.Property<int>("UserId")
                      .HasColumnType("INTEGER");

            b.Property<int>("Victories")
                      .HasColumnType("INTEGER");

            b.HasKey("Id");

            b.HasIndex("UserId");

            b.ToTable("Characters");

            b.HasData(
                      new
                      {
                        Id = 1,
                        Class = 0,
                        Defeats = 0,
                        Defense = 120,
                        Fights = 0,
                        HitPoints = 1250,
                        Intelligence = 125,
                        Name = "Obi wan",
                        Strength = 90,
                        UserId = 1,
                        Victories = 0
                      },
                      new
                      {
                        Id = 2,
                        Class = 1,
                        Defeats = 0,
                        Defense = 100,
                        Fights = 0,
                        HitPoints = 1100,
                        Intelligence = 112,
                        Name = "Darth Vader",
                        Strength = 110,
                        UserId = 2,
                        Victories = 0
                      });
          });

      modelBuilder.Entity("net.core.api.Models.Skill", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("INTEGER");

            b.Property<int>("Damage")
                      .HasColumnType("INTEGER");

            b.Property<string>("Name")
                      .HasColumnType("TEXT");

            b.HasKey("Id");

            b.ToTable("Skills");

            b.HasData(
                      new
                      {
                        Id = 1,
                        Damage = 100,
                        Name = "Force"
                      },
                      new
                      {
                        Id = 2,
                        Damage = 110,
                        Name = "Dark Rays"
                      },
                      new
                      {
                        Id = 3,
                        Damage = 80,
                        Name = "Push"
                      });
          });

      modelBuilder.Entity("net.core.api.Models.User", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("INTEGER");

            b.Property<byte[]>("PasswordHash")
                      .HasColumnType("BLOB");

            b.Property<byte[]>("PasswordSalt")
                      .HasColumnType("BLOB");

            b.Property<string>("Role")
                      .IsRequired()
                      .ValueGeneratedOnAdd()
                      .HasColumnType("TEXT")
                      .HasDefaultValue("Player");

            b.Property<string>("Username")
                      .HasColumnType("TEXT");

            b.HasKey("Id");

            b.ToTable("Users");

            b.HasData(
                      new
                      {
                        Id = 1,
                        PasswordHash = new byte[] { 54, 0, 226, 182, 224, 42, 83, 174, 112, 24, 213, 234, 142, 28, 100, 154, 55, 247, 19, 218, 203, 250, 100, 69, 223, 176, 180, 195, 183, 32, 232, 219, 51, 163, 57, 6, 227, 3, 187, 214, 220, 76, 218, 185, 120, 31, 180, 57, 130, 212, 199, 123, 73, 155, 163, 238, 241, 129, 176, 160, 158, 30, 149, 98 },
                        PasswordSalt = new byte[] { 100, 11, 88, 176, 142, 103, 22, 142, 148, 164, 53, 246, 193, 134, 37, 20, 125, 51, 11, 127, 215, 6, 16, 128, 121, 180, 209, 17, 68, 114, 203, 99, 146, 86, 94, 148, 131, 135, 226, 102, 209, 83, 205, 119, 218, 214, 212, 50, 224, 12, 164, 152, 134, 250, 135, 238, 183, 249, 41, 168, 151, 100, 82, 177, 196, 132, 45, 2, 31, 118, 206, 199, 141, 183, 180, 72, 163, 45, 73, 178, 182, 248, 228, 225, 112, 142, 50, 67, 28, 126, 61, 219, 141, 232, 178, 7, 68, 124, 148, 150, 16, 139, 168, 40, 5, 89, 185, 80, 249, 87, 68, 202, 102, 210, 198, 96, 252, 76, 84, 169, 103, 243, 175, 242, 174, 160, 40, 105 },
                        Username = "User1"
                      },
                      new
                      {
                        Id = 2,
                        PasswordHash = new byte[] { 54, 0, 226, 182, 224, 42, 83, 174, 112, 24, 213, 234, 142, 28, 100, 154, 55, 247, 19, 218, 203, 250, 100, 69, 223, 176, 180, 195, 183, 32, 232, 219, 51, 163, 57, 6, 227, 3, 187, 214, 220, 76, 218, 185, 120, 31, 180, 57, 130, 212, 199, 123, 73, 155, 163, 238, 241, 129, 176, 160, 158, 30, 149, 98 },
                        PasswordSalt = new byte[] { 100, 11, 88, 176, 142, 103, 22, 142, 148, 164, 53, 246, 193, 134, 37, 20, 125, 51, 11, 127, 215, 6, 16, 128, 121, 180, 209, 17, 68, 114, 203, 99, 146, 86, 94, 148, 131, 135, 226, 102, 209, 83, 205, 119, 218, 214, 212, 50, 224, 12, 164, 152, 134, 250, 135, 238, 183, 249, 41, 168, 151, 100, 82, 177, 196, 132, 45, 2, 31, 118, 206, 199, 141, 183, 180, 72, 163, 45, 73, 178, 182, 248, 228, 225, 112, 142, 50, 67, 28, 126, 61, 219, 141, 232, 178, 7, 68, 124, 148, 150, 16, 139, 168, 40, 5, 89, 185, 80, 249, 87, 68, 202, 102, 210, 198, 96, 252, 76, 84, 169, 103, 243, 175, 242, 174, 160, 40, 105 },
                        Username = "User2"
                      });
          });

      modelBuilder.Entity("net.core.api.Models.Weapon", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("INTEGER");

            b.Property<int>("CharacterId")
                      .HasColumnType("INTEGER");

            b.Property<int>("Damage")
                      .HasColumnType("INTEGER");

            b.Property<string>("Name")
                      .HasColumnType("TEXT");

            b.HasKey("Id");

            b.HasIndex("CharacterId")
                      .IsUnique();

            b.ToTable("Weapons");

            b.HasData(
                      new
                      {
                        Id = 1,
                        CharacterId = 1,
                        Damage = 105,
                        Name = "Dark Saber"
                      },
                      new
                      {
                        Id = 2,
                        CharacterId = 2,
                        Damage = 100,
                        Name = "Red lightsaber"
                      });
          });

      modelBuilder.Entity("CharacterSkill", b =>
          {
            b.HasOne("net.core.api.Models.Character", null)
                      .WithMany()
                      .HasForeignKey("CharactersId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            b.HasOne("net.core.api.Models.Skill", null)
                      .WithMany()
                      .HasForeignKey("SkillsId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();
          });

      modelBuilder.Entity("net.core.api.Models.Character", b =>
          {
            b.HasOne("net.core.api.Models.User", "User")
                      .WithMany("Characters")
                      .HasForeignKey("UserId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            b.Navigation("User");
          });

      modelBuilder.Entity("net.core.api.Models.Weapon", b =>
          {
            b.HasOne("net.core.api.Models.Character", "Character")
                      .WithOne("Weapon")
                      .HasForeignKey("net.core.api.Models.Weapon", "CharacterId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            b.Navigation("Character");
          });

      modelBuilder.Entity("net.core.api.Models.Character", b =>
          {
            b.Navigation("Weapon");
          });

      modelBuilder.Entity("net.core.api.Models.User", b =>
          {
            b.Navigation("Characters");
          });
#pragma warning restore 612, 618
    }
  }
}
