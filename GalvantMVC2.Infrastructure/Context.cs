using GalvantMVC2.Domain.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = GalvantMVC2.Domain.Model.Type;

namespace GalvantMVC2.Infrastructure
{
    public class Context : IdentityDbContext
    { 
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Forklift> Forklifts { get; set; }
        public DbSet<Gantry> Gantries { get; set; }
        public DbSet<Hoist> Hoists { get; set; }
        public DbSet<Crane> Cranes { get; set; }
        public DbSet<Tank> Tanks { get; set; }
        public DbSet<Location2> Location2s { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Domain.Model.Task> Tasks { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Role> Roles { get; set; }


        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Equipment>()
                .HasOne(a => a.Forklift).WithOne(b => b.Equipment)
                .HasForeignKey<Forklift>(c => c.EquipmentId);

            builder.Entity<Equipment>()
                .HasOne(a => a.Gantry).WithOne(b => b.Equipment)
                .HasForeignKey<Gantry>(c => c.EquipmentId);

            builder.Entity<Forklift>()
            .Property(c => c.LiftingCapacity)
            .HasColumnType("decimal(9,2)");

            builder.Entity<Forklift>()
            .Property(c => c.RaisingHeight)
            .HasColumnType("decimal(9,2)");

            builder.Entity<Forklift>()
            .Property(c => c.Weight)
            .HasColumnType("decimal(9,2)");

            builder.Entity<Gantry>()
            .Property(c => c.LiftingCapacity)
            .HasColumnType("decimal(9,2)");

            builder.Entity<Gantry>()
            .Property(c => c.Range)
            .HasColumnType("decimal(9,2)");

            builder.Entity<Gantry>()
            .Property(c => c.RaisingHeight)
            .HasColumnType("decimal(9,2)");

            builder.Entity<Gantry>()
            .Property(c => c.Weight)
            .HasColumnType("decimal(9,2)");

            builder.Entity<Tank>()
                .Property (c => c.Capacity)
                .HasColumnType("decimal(9,2)");

            builder.Entity<Tank>()
                .Property(c => c.PermissiblePressure)
                .HasColumnType("decimal(9,2)");

            builder.Entity<Crane>()
            .Property(c => c.LiftingCapacity)
            .HasColumnType("decimal(9,2)");

            builder.Entity<Crane>()
            .Property(c => c.RaisingHeight)
            .HasColumnType("decimal(9,2)");

            builder.Entity<Crane>()
            .Property(c => c.Weight)
            .HasColumnType("decimal(9,2)");

            builder.Entity<Hoist>()
            .Property(c => c.LiftingCapacity)
            .HasColumnType("decimal(9,2)");

            builder.Entity<Hoist>()
            .Property(c => c.RaisingHeight)
            .HasColumnType("decimal(9,2)");

            builder.Entity<Hoist>()
            .Property(c => c.Weight)
            .HasColumnType("decimal(9,2)");
        }
    }
}
