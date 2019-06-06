using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ANVBookstore.Models
{
    public partial class Team117DBContext : DbContext
    {
        public Team117DBContext()
        {
        }

        public Team117DBContext(DbContextOptions<Team117DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderItems> OrderItems { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Textbook> Textbook { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=buscissql1601\\cisweb;Database=Team117DB;user ID=platy;Password=forms;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.AdminId).HasColumnName("Admin_ID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.RoleId).HasColumnName("Role_ID");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("User_Name")
                    .HasMaxLength(10);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Admin)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Admin_Roles");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseId)
                    .HasColumnName("Course_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasColumnName("Course_Name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CourseProf)
                    .IsRequired()
                    .HasColumnName("Course_Prof")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.Property(e => e.AddressLine)
                    .IsRequired()
                    .HasColumnName("Address_Line")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cell).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("First_Name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("Last_Name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("Role_ID");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("User_Name")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasColumnName("User_Password")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Zipcode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_Roles");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("Order_ID");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("Created_On")
                    .IsRowVersion();

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.Property(e => e.OrderStatus)
                    .HasColumnName("Order_Status")
                    .HasMaxLength(5);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Customer");
            });

            modelBuilder.Entity<OrderItems>(entity =>
            {
                entity.HasKey(e => e.OrderItemPk);

                entity.ToTable("Order_Items");

                entity.Property(e => e.OrderItemPk).HasColumnName("Order_Item_PK");

                entity.Property(e => e.OrderId).HasColumnName("Order_ID");

                entity.Property(e => e.OrderQty).HasColumnName("Order_Qty");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Items_Order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Items_Textbook");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.Property(e => e.RoleId).HasColumnName("Role_ID");

                entity.Property(e => e.UserDefinition)
                    .IsRequired()
                    .HasColumnName("User_Definition")
                    .HasMaxLength(5);
            });

            modelBuilder.Entity<Textbook>(entity =>
            {
                entity.Property(e => e.TextbookId).HasColumnName("Textbook_ID");

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CourseId)
                    .IsRequired()
                    .HasColumnName("Course_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Textbook)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Textbook_Course");
            });
        }
    }
}
