﻿using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace WebApi.DataSource
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        public ApplicationDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dir = "DataSource/SqLiteDb";
            Directory.CreateDirectory(dir);
            optionsBuilder.UseSqlite($"Filename={dir}/SnakeArena.sqlite");

            //
            //optionsBuilder.UseSqlite("server=localhost;user=root;password=кщще;database=userdb;",
            //    new MySqlServerVersion(new Version(8, 0, 28)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "SnakeBot", },
                new User { Id = 2, Name = "RandomBot", }
            );
        }
    }
}
