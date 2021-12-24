using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Context
{
    //Menentukan relasi dan sebagainya yang berhubungan dengan tabel2
    public class MyContext : DbContext //ORM yang akan digunakan (Entity Framework) 5.0.11
    {
        public MyContext(DbContextOptions<MyContext> options): base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; } //representasi dari nama tabelnya,
                                                       //tiap ada tabel baru, ditambah DbSet nya
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Profiling> Profilings { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<University> Universities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One to One Employee -> Account
            modelBuilder.Entity<Employee>()
                .HasOne(employee => employee.Account)
                .WithOne(account => account.Employee)
                .HasForeignKey<Account>(account => account.NIK);  
            // One to One Account -> Profiling
            modelBuilder.Entity<Account>()
                .HasOne(account => account.Profiling)
                .WithOne(profiling => profiling.Account)
                .HasForeignKey<Profiling>(profiling => profiling.NIK);
            // One to Many Education -> Profiling
            modelBuilder.Entity<Education>()
                .HasMany(e => e.Profilings)
                .WithOne(p => p.Education);
            // One to Many University -> Education
            modelBuilder.Entity<University>()
                .HasMany(u => u.Educations)
                .WithOne(e => e.University);
        }
    }
}
