using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ProjectAppContext : DbContext
    {
        public string dbPath;
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Entry> Entrys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            dbPath = System.IO.Path.Combine(path, "ProjectAppDB.db");
            optionsBuilder.UseSqlite($"Data Source ={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectContract>()
                .HasKey(pc => new { pc.ProjectId, pc.ContractId });
            modelBuilder.Entity<ProjectContract>()
                .HasOne(pc => pc.Project)
                .WithMany(p => p.ProjectContracts)
                .HasForeignKey(pc => pc.ProjectId);
            modelBuilder.Entity<ProjectContract>()
                .HasOne(pc => pc.Contract)
                .WithMany(c => c.ProjectContracts)
                .HasForeignKey(pc => pc.ContractId);
        }
    }
}
