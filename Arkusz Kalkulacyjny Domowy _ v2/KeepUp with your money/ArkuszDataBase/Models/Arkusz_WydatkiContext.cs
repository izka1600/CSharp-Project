using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ArkuszDataBase.Models
{
    public partial class Arkusz_WydatkiContext : DbContext
    {
        public Arkusz_WydatkiContext()
        {
        }

        public Arkusz_WydatkiContext(DbContextOptions<Arkusz_WydatkiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kategorie> Kategorie { get; set; }
        public virtual DbSet<Plan> Plan { get; set; }
        public virtual DbSet<Podkategorie> Podkategorie { get; set; }
        public virtual DbSet<Transakcje> Transakcje { get; set; }
        public virtual DbSet<Uzytkownik> Uzytkownik { get; set; }
		public virtual DbSet<RaportFromMonths> RaportFromMonths { get; set; }

		public virtual DbSet<ReportFromMonthsParametres> ReportFromMonthsParametres { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS01;Database=Arkusz_Wydatki;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Kategorie>(entity =>
            {
                entity.HasKey(e => e.KatId)
                    .HasName("PK__Kategori__87B3726890867C4A");

                entity.HasIndex(e => e.Kategoria)
                    .HasName("KatName")
                    .IsUnique();

                entity.Property(e => e.KatId).HasColumnName("Kat_Id");

                entity.Property(e => e.Kategoria)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Uz)
                    .WithMany(p => p.Kategorie)
                    .HasForeignKey(d => d.UzId)
                    .HasConstraintName("FKUzytkownik_K");
            });

            modelBuilder.Entity<Plan>(entity =>
            {
                entity.HasIndex(e => new { e.Miesiąc, e.ZalozonaKwota, e.FaktycznaKwota, e.IdUzytkownika })
                    .HasName("PlanUnique")
                    .IsUnique();

                entity.Property(e => e.PlanId).HasColumnName("Plan_ID");

                entity.Property(e => e.FaktycznaKwota).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Miesiąc).HasColumnType("date");

                entity.Property(e => e.ZalozonaKwota).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdUzytkownikaNavigation)
                    .WithMany(p => p.Plan)
                    .HasForeignKey(d => d.IdUzytkownika)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKPlanUzytkownik");
            });

            modelBuilder.Entity<Podkategorie>(entity =>
            {
                entity.HasKey(e => e.PodId)
                    .HasName("PK__Podkateg__6680BE6EF145A89C");

                entity.HasIndex(e => e.Podkategoria)
                    .HasName("PodName")
                    .IsUnique();

                entity.Property(e => e.PodId).HasColumnName("Pod_ID");

                entity.Property(e => e.Podkategoria)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdKategoriiNavigation)
                    .WithMany(p => p.Podkategorie)
                    .HasForeignKey(d => d.IdKategorii)
                    .HasConstraintName("FKPKategoria");
            });

            modelBuilder.Entity<Transakcje>(entity =>
            {
                entity.HasKey(e => e.TransId)
                    .HasName("PK__Transakc__7B615C8D012D977A");

                entity.HasIndex(e => new { e.Data, e.IdUzytkownika, e.IdKategorii, e.IdPodkategorii, e.Kwota })
                    .HasName("TranUnique")
                    .IsUnique();

                entity.Property(e => e.TransId).HasColumnName("Trans_ID");

                entity.Property(e => e.Data)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdKategoriiNavigation)
                    .WithMany(p => p.Transakcje)
                    .HasForeignKey(d => d.IdKategorii)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKKategoria");

                entity.HasOne(d => d.IdPodkategoriiNavigation)
                    .WithMany(p => p.Transakcje)
                    .HasForeignKey(d => d.IdPodkategorii)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKPodKategoria");

                entity.HasOne(d => d.IdUzytkownikaNavigation)
                    .WithMany(p => p.Transakcje)
                    .HasForeignKey(d => d.IdUzytkownika)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKUzytkownik");
            });

            modelBuilder.Entity<Uzytkownik>(entity =>
            {
                entity.HasKey(e => e.UzytId)
                    .HasName("PK__Uzytkown__866806738B051B36");

                entity.HasIndex(e => e.EMail)
                    .HasName("U_Email")
                    .IsUnique();

                entity.Property(e => e.UzytId).HasColumnName("Uzyt_ID");

                entity.Property(e => e.DataDodania)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EMail)
                    .HasColumnName("e_mail")
                    .HasMaxLength(50);

                entity.Property(e => e.Imie).HasMaxLength(30);

                entity.Property(e => e.Nazwisko).HasMaxLength(50);

                entity.Property(e => e.Nick).HasMaxLength(30);

                entity.Property(e => e.OstatnieLogowanie).HasColumnType("datetime");
            });
        }
    }
}
