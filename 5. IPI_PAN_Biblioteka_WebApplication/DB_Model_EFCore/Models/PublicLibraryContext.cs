using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DB_Model_EFCore.Models
{
    public partial class PublicLibraryContext : DbContext
    {
        public PublicLibraryContext()
        {
        }

        public PublicLibraryContext(DbContextOptions<PublicLibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<BookCovers> BookCovers { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<BooksRental> BooksRental { get; set; }
        public virtual DbSet<DataCarriers> DataCarriers { get; set; }
        public virtual DbSet<Readers> Readers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=PublicLibrary;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Authors>(entity =>
            {
                entity.HasKey(e => e.AuthorId).HasName("PK__Authors__70DAFC34CE119D33");

                entity.ToTable("Authors", "library");

                entity.Property(e => e.CreationDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(30);

                entity.Property(e => e.LastName).IsRequired().HasMaxLength(30);
            });

            modelBuilder.Entity<BookCovers>(entity =>
            {
                entity.HasKey(e => e.CoverId).HasName("PK__BookCove__A8E94256EFA3017C");

                entity.ToTable("BookCovers", "library");

                entity.Property(e => e.CreationDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Books>(entity =>
            {
                entity.HasKey(e => e.BookId).HasName("PK__Books__3DE0C2071E91EEC7");

                entity.ToTable("Books", "library");

                entity.Property(e => e.CreationDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DataCarrierId).HasColumnName("DataCarrierID");

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);

                entity.Property(e => e.PublicationDate).HasColumnType("date");

                entity.HasOne(d => d.Authors).WithMany(p => p.Books).HasForeignKey(d => d.AuthorsId).HasConstraintName("FKAuthor");

                entity.HasOne(d => d.Cover).WithMany(p => p.Books).HasForeignKey(d => d.CoverId).HasConstraintName("FKCover");

                entity.HasOne(d => d.DataCarrier).WithMany(p => p.Books).HasForeignKey(d => d.DataCarrierId).HasConstraintName("FKCarrier");
            });

            modelBuilder.Entity<BooksRental>(entity =>
            {
                entity.HasKey(e => e.RentalId).HasName("PK__tmp_ms_x__9700594363D35771");

                entity.ToTable("BooksRental", "library");

                entity.Property(e => e.Comment).HasMaxLength(100);

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.RentalDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ReturnDate).HasColumnType("datetime");

                entity.HasOne(d => d.Book).WithMany(p => p.BooksRental).HasForeignKey(d => d.BookId).HasConstraintName("FKBook");

                entity.HasOne(d => d.Reader).WithMany(p => p.BooksRental).HasForeignKey(d => d.ReaderId).HasConstraintName("FKReader");
            });

            modelBuilder.Entity<DataCarriers>(entity =>
            {
                entity.HasKey(e => e.DataCarrierId).HasName("PK__DataCarr__5B502FB59DAF3804");

                entity.ToTable("DataCarriers", "library");

                entity.Property(e => e.DataCarrierId).HasColumnName("DataCarrierID");

                entity.Property(e => e.CreationDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.Name).IsRequired().HasMaxLength(15);
            });

            modelBuilder.Entity<Readers>(entity =>
            {
                entity.HasKey(e => e.ReaderId).HasName("PK__Readers__8E67A5E1BA033AD2");

                entity.ToTable("Readers", "library");

                entity.Property(e => e.AccessRights).HasMaxLength(1).IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.Email).IsRequired().HasMaxLength(30);

                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(30);

                entity.Property(e => e.LastName).IsRequired().HasMaxLength(30);
            });
        }
    }
}
