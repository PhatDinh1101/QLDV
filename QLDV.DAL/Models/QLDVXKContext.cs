using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QLDV.DAL.Models
{
    public partial class QLDVXKContext : DbContext
    {
        public QLDVXKContext()
        {
        }

        public QLDVXKContext(DbContextOptions<QLDVXKContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<ChuyenXe> ChuyenXes { get; set; }
        public virtual DbSet<Garage> Garages { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DINHHUUPHAT\\SQLEXPRESS;Initial Catalog=QLDVXK;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.TicketId).HasColumnName("TicketID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.TicketId)
                    .HasConstraintName("FK_Booking_Ticket");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Booking_User");
            });

            modelBuilder.Entity<ChuyenXe>(entity =>
            {
                entity.ToTable("ChuyenXe");

                entity.Property(e => e.ChuyenXeId).HasColumnName("ChuyenXeID");

                entity.Property(e => e.Finish).IsUnicode(false);

                entity.Property(e => e.GarageId).HasColumnName("GarageID");

                entity.Property(e => e.Start).IsUnicode(false);

                entity.HasOne(d => d.Garage)
                    .WithMany(p => p.ChuyenXes)
                    .HasForeignKey(d => d.GarageId)
                    .HasConstraintName("FK_ChuyenXe_Garage");
            });

            modelBuilder.Entity<Garage>(entity =>
            {
                entity.ToTable("Garage");

                entity.Property(e => e.GarageId).HasColumnName("GarageID");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Ticket");

                entity.Property(e => e.TicketId).HasColumnName("TicketID");

                entity.Property(e => e.ChuyenXeId).HasColumnName("ChuyenXeID");

                entity.Property(e => e.TimeStart).HasColumnType("datetime");

                entity.HasOne(d => d.ChuyenXe)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.ChuyenXeId)
                    .HasConstraintName("FK_Ticket_ChuyenXe");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Avatar)
                    .HasMaxLength(255)
                    .IsFixedLength(true);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .HasColumnName("FIrstName")
                    .IsFixedLength(true);

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.PassWord)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
