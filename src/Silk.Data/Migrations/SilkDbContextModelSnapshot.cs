﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Silk.Data;

namespace Silk.Data.Migrations
{
    [DbContext(typeof(SilkDbContext))]
    partial class SilkDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "6.0.0-preview.1.21102.2")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Silk.Data.Models.BlacklistedWord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("GuildId")
                        .HasColumnType("integer");

                    b.Property<string>("Word")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("GuildId");

                    b.ToTable("BlacklistedWord");
                });

            modelBuilder.Entity("Silk.Data.Models.CommandInvocation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CommandName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal?>("GuildId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<decimal>("UserId")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("Id");

                    b.ToTable("CommandInvocations");
                });

            modelBuilder.Entity("Silk.Data.Models.DisabledCommand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CommandName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("GuildConfigId")
                        .HasColumnType("integer");

                    b.Property<decimal>("GuildId")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("Id");

                    b.HasIndex("GuildConfigId");

                    b.HasIndex("GuildId", "CommandName")
                        .IsUnique();

                    b.ToTable("DisabledCommand");
                });

            modelBuilder.Entity("Silk.Data.Models.GlobalUser", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(20,0)");

                    b.Property<int>("Cash")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LastCashOut")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("GlobalUsers");
                });

            modelBuilder.Entity("Silk.Data.Models.Guild", b =>
                {
                    b.Property<decimal>("Id")
                        .HasColumnType("numeric(20,0)");

                    b.Property<string>("Prefix")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)");

                    b.HasKey("Id");

                    b.ToTable("Guilds");
                });

            modelBuilder.Entity("Silk.Data.Models.GuildConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("AutoDehoist")
                        .HasColumnType("boolean");

                    b.Property<bool>("BlacklistInvites")
                        .HasColumnType("boolean");

                    b.Property<bool>("BlacklistWords")
                        .HasColumnType("boolean");

                    b.Property<bool>("DeleteMessageOnMatchedInvite")
                        .HasColumnType("boolean");

                    b.Property<bool>("GreetMembers")
                        .HasColumnType("boolean");

                    b.Property<bool>("GreetOnScreeningComplete")
                        .HasColumnType("boolean");

                    b.Property<bool>("GreetOnVerificationRole")
                        .HasColumnType("boolean");

                    b.Property<decimal>("GreetingChannel")
                        .HasColumnType("numeric(20,0)");

                    b.Property<string>("GreetingText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("GuildId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<int[]>("InfractionDictionary")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.Property<string>("InfractionFormat")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("LogMemberJoing")
                        .HasColumnType("boolean");

                    b.Property<bool>("LogMessageChanges")
                        .HasColumnType("boolean");

                    b.Property<decimal>("LoggingChannel")
                        .HasColumnType("numeric(20,0)");

                    b.Property<int>("MaxRoleMentions")
                        .HasColumnType("integer");

                    b.Property<int>("MaxUserMentions")
                        .HasColumnType("integer");

                    b.Property<decimal>("MuteRoleId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<bool>("ScanInvites")
                        .HasColumnType("boolean");

                    b.Property<bool>("UseAggressiveRegex")
                        .HasColumnType("boolean");

                    b.Property<decimal>("VerificationRole")
                        .HasColumnType("numeric(20,0)");

                    b.Property<bool>("WarnOnMatchedInvite")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("GuildId")
                        .IsUnique();

                    b.ToTable("GuildConfigs");
                });

            modelBuilder.Entity("Silk.Data.Models.Infraction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("Enforcer")
                        .HasColumnType("numeric(20,0)");

                    b.Property<DateTime?>("Expiration")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("HeldAgainstUser")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("InfractionTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("InfractionType")
                        .HasColumnType("integer");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("UserDatabaseId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("UserId")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("Id");

                    b.HasIndex("UserDatabaseId");

                    b.ToTable("Infractions");
                });

            modelBuilder.Entity("Silk.Data.Models.Invite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("GuildConfigId")
                        .HasColumnType("integer");

                    b.Property<decimal>("GuildId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<string>("VanityURL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("GuildConfigId");

                    b.ToTable("Invite");
                });

            modelBuilder.Entity("Silk.Data.Models.SelfAssignableRole", b =>
                {
                    b.Property<decimal>("Id")
                        .HasColumnType("numeric(20,0)");

                    b.Property<int?>("GuildConfigId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GuildConfigId");

                    b.ToTable("SelfAssignableRole");
                });

            modelBuilder.Entity("Silk.Data.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Closed")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsOpen")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("Opened")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("Opener")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("Id");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Silk.Data.Models.TicketMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Sender")
                        .HasColumnType("numeric(20,0)");

                    b.Property<int>("TicketId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.ToTable("TicketMessage");
                });

            modelBuilder.Entity("Silk.Data.Models.TicketResponder", b =>
                {
                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("ResponderId")
                        .HasColumnType("numeric(20,0)");

                    b.ToTable("TicketResponder");
                });

            modelBuilder.Entity("Silk.Data.Models.User", b =>
                {
                    b.Property<long>("DatabaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Flags")
                        .HasColumnType("integer");

                    b.Property<decimal>("GuildId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<decimal>("Id")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("DatabaseId");

                    b.HasIndex("GuildId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Silk.Data.Models.BlacklistedWord", b =>
                {
                    b.HasOne("Silk.Data.Models.GuildConfig", "Guild")
                        .WithMany("BlackListedWords")
                        .HasForeignKey("GuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guild");
                });

            modelBuilder.Entity("Silk.Data.Models.DisabledCommand", b =>
                {
                    b.HasOne("Silk.Data.Models.GuildConfig", null)
                        .WithMany("DisabledCommands")
                        .HasForeignKey("GuildConfigId");

                    b.HasOne("Silk.Data.Models.Guild", "Guild")
                        .WithMany()
                        .HasForeignKey("GuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guild");
                });

            modelBuilder.Entity("Silk.Data.Models.GuildConfig", b =>
                {
                    b.HasOne("Silk.Data.Models.Guild", "Guild")
                        .WithOne("Configuration")
                        .HasForeignKey("Silk.Data.Models.GuildConfig", "GuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guild");
                });

            modelBuilder.Entity("Silk.Data.Models.Infraction", b =>
                {
                    b.HasOne("Silk.Data.Models.User", "User")
                        .WithMany("Infractions")
                        .HasForeignKey("UserDatabaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Silk.Data.Models.Invite", b =>
                {
                    b.HasOne("Silk.Data.Models.GuildConfig", null)
                        .WithMany("AllowedInvites")
                        .HasForeignKey("GuildConfigId");
                });

            modelBuilder.Entity("Silk.Data.Models.SelfAssignableRole", b =>
                {
                    b.HasOne("Silk.Data.Models.GuildConfig", null)
                        .WithMany("SelfAssignableRoles")
                        .HasForeignKey("GuildConfigId");
                });

            modelBuilder.Entity("Silk.Data.Models.TicketMessage", b =>
                {
                    b.HasOne("Silk.Data.Models.Ticket", "Ticket")
                        .WithMany("History")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("Silk.Data.Models.User", b =>
                {
                    b.HasOne("Silk.Data.Models.Guild", "Guild")
                        .WithMany("Users")
                        .HasForeignKey("GuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guild");
                });

            modelBuilder.Entity("Silk.Data.Models.Guild", b =>
                {
                    b.Navigation("Configuration")
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Silk.Data.Models.GuildConfig", b =>
                {
                    b.Navigation("AllowedInvites");

                    b.Navigation("BlackListedWords");

                    b.Navigation("DisabledCommands");

                    b.Navigation("SelfAssignableRoles");
                });

            modelBuilder.Entity("Silk.Data.Models.Ticket", b =>
                {
                    b.Navigation("History");
                });

            modelBuilder.Entity("Silk.Data.Models.User", b =>
                {
                    b.Navigation("Infractions");
                });
#pragma warning restore 612, 618
        }
    }
}
