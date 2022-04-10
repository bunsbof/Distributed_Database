using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QLUniqlo.Connection
{
    public partial class QLUniqloContext : DbContext
    {
        public QLUniqloContext(string connectionString)
            : base(connectionString)
        {
        }

        public virtual DbSet<Attribute> Attributes { get; set; }
        public virtual DbSet<BillDetail> BillDetails { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<sysreplserver> sysreplservers { get; set; }
        public virtual DbSet<sysmergearticle> sysmergearticles { get; set; }
        public virtual DbSet<sysmergepartitioninfo> sysmergepartitioninfoes { get; set; }
        public virtual DbSet<sysmergepublication> sysmergepublications { get; set; }
        public virtual DbSet<sysmergeschemaarticle> sysmergeschemaarticles { get; set; }
        public virtual DbSet<sysmergeschemachange> sysmergeschemachanges { get; set; }
        public virtual DbSet<sysmergesubscription> sysmergesubscriptions { get; set; }
        public virtual DbSet<sysmergesubsetfilter> sysmergesubsetfilters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attribute>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Attribute)
                .HasForeignKey(e => e.id_attribute)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Bill>()
                .HasMany(e => e.BillDetails)
                .WithRequired(e => e.Bill)
                .HasForeignKey(e => e.id_bill);

            modelBuilder.Entity<Branch>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Branch)
                .HasForeignKey(e => e.id_branch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.id_category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.salary)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Bills)
                .WithRequired(e => e.Employee)
                .HasForeignKey(e => e.id_emp)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.BillDetails)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.id_product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sysmergearticle>()
                .Property(e => e.schema_option)
                .IsFixedLength();

            modelBuilder.Entity<sysmergearticle>()
                .Property(e => e.procname_postfix)
                .IsFixedLength();

            modelBuilder.Entity<sysmergepublication>()
                .Property(e => e.snapshot_jobid)
                .IsFixedLength();

            modelBuilder.Entity<sysmergeschemaarticle>()
                .Property(e => e.schema_option)
                .IsFixedLength();

            modelBuilder.Entity<sysmergesubscription>()
                .Property(e => e.replnickname)
                .IsFixedLength();
        }
    }
}
