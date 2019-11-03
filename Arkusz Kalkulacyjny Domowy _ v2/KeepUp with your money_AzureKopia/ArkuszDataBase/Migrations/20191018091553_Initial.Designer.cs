﻿// <auto-generated />
using System;
using ArkuszDataBase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ArkuszDataBase.Migrations
{
    [DbContext(typeof(Arkusz_WydatkiContext))]
    [Migration("20191018091553_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ArkuszDataBase.Models.Kategorie", b =>
                {
                    b.Property<int>("KatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Kat_Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Kategoria")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int?>("UzId");

                    b.HasKey("KatId")
                        .HasName("PK__Kategori__87B3726890867C4A");

                    b.HasIndex("Kategoria")
                        .IsUnique()
                        .HasName("KatName")
                        .HasFilter("[Kategoria] IS NOT NULL");

                    b.HasIndex("UzId");

                    b.ToTable("Kategorie");
                });

            modelBuilder.Entity("ArkuszDataBase.Models.Plan", b =>
                {
                    b.Property<int>("PlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Plan_ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<decimal?>("FaktycznaKwota")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<int>("IdUzytkownika");

                    b.Property<DateTime?>("Miesiąc")
                        .HasColumnType("date");

                    b.Property<int?>("Warning")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<decimal?>("ZalozonaKwota")
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("PlanId");

                    b.HasIndex("IdUzytkownika");

                    b.HasIndex("Miesiąc", "ZalozonaKwota", "FaktycznaKwota", "IdUzytkownika")
                        .IsUnique()
                        .HasName("PlanUnique")
                        .HasFilter("[Miesiąc] IS NOT NULL AND [ZalozonaKwota] IS NOT NULL AND [FaktycznaKwota] IS NOT NULL");

                    b.ToTable("Plan");
                });

            modelBuilder.Entity("ArkuszDataBase.Models.Podkategorie", b =>
                {
                    b.Property<int>("PodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Pod_ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IdKategorii");

                    b.Property<string>("Podkategoria")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("PodId")
                        .HasName("PK__Podkateg__6680BE6EF145A89C");

                    b.HasIndex("IdKategorii");

                    b.HasIndex("Podkategoria")
                        .IsUnique()
                        .HasName("PodName")
                        .HasFilter("[Podkategoria] IS NOT NULL");

                    b.ToTable("Podkategorie");
                });

            modelBuilder.Entity("ArkuszDataBase.Models.RaportFromMonths", b =>
                {
                    b.Property<DateTime>("DateOfTransaction");

                    b.Property<string>("Kategoria");

                    b.Property<double>("Kwota");

                    b.Property<string>("Podkategoria");

                    b.HasKey("DateOfTransaction");

                    b.ToTable("RaportFromMonths");
                });

            modelBuilder.Entity("ArkuszDataBase.Models.Transakcje", b =>
                {
                    b.Property<int>("TransId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Trans_ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Data")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("IdKategorii");

                    b.Property<int>("IdPodkategorii");

                    b.Property<int>("IdUzytkownika");

                    b.Property<double?>("Kwota");

                    b.Property<int?>("PlanId");

                    b.HasKey("TransId")
                        .HasName("PK__Transakc__7B615C8D012D977A");

                    b.HasIndex("IdKategorii");

                    b.HasIndex("IdPodkategorii");

                    b.HasIndex("IdUzytkownika");

                    b.HasIndex("Data", "IdUzytkownika", "IdKategorii", "IdPodkategorii", "Kwota")
                        .IsUnique()
                        .HasName("TranUnique")
                        .HasFilter("[Data] IS NOT NULL AND [Kwota] IS NOT NULL");

                    b.ToTable("Transakcje");
                });

            modelBuilder.Entity("ArkuszDataBase.Models.Uzytkownik", b =>
                {
                    b.Property<int>("UzytId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Uzyt_ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataDodania")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("DataUsuniecia");

                    b.Property<string>("EMail")
                        .HasColumnName("e_mail")
                        .HasMaxLength(50);

                    b.Property<string>("Imie")
                        .HasMaxLength(30);

                    b.Property<string>("Nazwisko")
                        .HasMaxLength(50);

                    b.Property<string>("Nick")
                        .HasMaxLength(30);

                    b.Property<DateTime?>("OstatnieLogowanie")
                        .HasColumnType("datetime");

                    b.HasKey("UzytId")
                        .HasName("PK__Uzytkown__866806738B051B36");

                    b.HasIndex("EMail")
                        .IsUnique()
                        .HasName("U_Email")
                        .HasFilter("[e_mail] IS NOT NULL");

                    b.ToTable("Uzytkownik");
                });

            modelBuilder.Entity("ArkuszDataBase.Models.Kategorie", b =>
                {
                    b.HasOne("ArkuszDataBase.Models.Uzytkownik", "Uz")
                        .WithMany("Kategorie")
                        .HasForeignKey("UzId")
                        .HasConstraintName("FKUzytkownik_K");
                });

            modelBuilder.Entity("ArkuszDataBase.Models.Plan", b =>
                {
                    b.HasOne("ArkuszDataBase.Models.Uzytkownik", "IdUzytkownikaNavigation")
                        .WithMany("Plan")
                        .HasForeignKey("IdUzytkownika")
                        .HasConstraintName("FKPlanUzytkownik");
                });

            modelBuilder.Entity("ArkuszDataBase.Models.Podkategorie", b =>
                {
                    b.HasOne("ArkuszDataBase.Models.Kategorie", "IdKategoriiNavigation")
                        .WithMany("Podkategorie")
                        .HasForeignKey("IdKategorii")
                        .HasConstraintName("FKPKategoria");
                });

            modelBuilder.Entity("ArkuszDataBase.Models.Transakcje", b =>
                {
                    b.HasOne("ArkuszDataBase.Models.Kategorie", "IdKategoriiNavigation")
                        .WithMany("Transakcje")
                        .HasForeignKey("IdKategorii")
                        .HasConstraintName("FKKategoria");

                    b.HasOne("ArkuszDataBase.Models.Podkategorie", "IdPodkategoriiNavigation")
                        .WithMany("Transakcje")
                        .HasForeignKey("IdPodkategorii")
                        .HasConstraintName("FKPodKategoria");

                    b.HasOne("ArkuszDataBase.Models.Uzytkownik", "IdUzytkownikaNavigation")
                        .WithMany("Transakcje")
                        .HasForeignKey("IdUzytkownika")
                        .HasConstraintName("FKUzytkownik");
                });
#pragma warning restore 612, 618
        }
    }
}
