﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SzkolaKomunikator.Entity;

namespace SzkolaKomunikator.Migrations
{
    [DbContext(typeof(CommunicatorDbContext))]
    [Migration("20210522114049_TokenError")]
    partial class TokenError
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChatUser", b =>
                {
                    b.Property<int>("ChatsId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("ChatsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("ChatUser");
                });

            modelBuilder.Entity("RankUser", b =>
                {
                    b.Property<int>("RanksId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("RanksId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RankUser");
                });

            modelBuilder.Entity("SzkolaKomunikator.Entity.Chat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("SzkolaKomunikator.Entity.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int?>("ChatId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.ToTable("Messeges");
                });

            modelBuilder.Entity("SzkolaKomunikator.Entity.Rank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AddUser")
                        .HasColumnType("bit");

                    b.Property<int?>("ChatId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ColorText")
                        .HasColumnType("bit");

                    b.Property<bool>("GiveRank")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("Mention")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("NewUser")
                        .HasColumnType("bit");

                    b.Property<bool>("Reaction")
                        .HasColumnType("bit");

                    b.Property<bool>("RemoveUser")
                        .HasColumnType("bit");

                    b.Property<bool>("SendMessege")
                        .HasColumnType("bit");

                    b.Property<bool>("SendPhoto")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.ToTable("Ranks");
                });

            modelBuilder.Entity("SzkolaKomunikator.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nick")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Nick")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ChatUser", b =>
                {
                    b.HasOne("SzkolaKomunikator.Entity.Chat", null)
                        .WithMany()
                        .HasForeignKey("ChatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SzkolaKomunikator.Entity.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RankUser", b =>
                {
                    b.HasOne("SzkolaKomunikator.Entity.Rank", null)
                        .WithMany()
                        .HasForeignKey("RanksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SzkolaKomunikator.Entity.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SzkolaKomunikator.Entity.Message", b =>
                {
                    b.HasOne("SzkolaKomunikator.Entity.Chat", "Chat")
                        .WithMany("Messeges")
                        .HasForeignKey("ChatId");

                    b.Navigation("Chat");
                });

            modelBuilder.Entity("SzkolaKomunikator.Entity.Rank", b =>
                {
                    b.HasOne("SzkolaKomunikator.Entity.Chat", "Chat")
                        .WithMany("Ranks")
                        .HasForeignKey("ChatId");

                    b.Navigation("Chat");
                });

            modelBuilder.Entity("SzkolaKomunikator.Entity.Chat", b =>
                {
                    b.Navigation("Messeges");

                    b.Navigation("Ranks");
                });
#pragma warning restore 612, 618
        }
    }
}
