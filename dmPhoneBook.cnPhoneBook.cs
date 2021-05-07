﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2021. 05. 05. 23:14:28
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace PhoneBook
{

    public partial class cnPhoneBook : DbContext
    {

        public cnPhoneBook() :
            base()
        {
            OnCreated();
        }

        public cnPhoneBook(DbContextOptions<cnPhoneBook> options) :
            base(options)
        {
            OnCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured ||
                (!optionsBuilder.Options.Extensions.OfType<RelationalOptionsExtension>().Any(ext => !string.IsNullOrEmpty(ext.ConnectionString) || ext.Connection != null) &&
                 !optionsBuilder.Options.Extensions.Any(ext => !(ext is RelationalOptionsExtension) && !(ext is CoreOptionsExtension))))
            {
                optionsBuilder.UseSqlServer(GetConnectionString("csPhoneBook"));
            }
            CustomizeConfiguration(ref optionsBuilder);
            base.OnConfiguring(optionsBuilder);
        }

        private static string GetConnectionString(string connectionStringName)
        {
            var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);
            var configuration = configurationBuilder.Build();
            return configuration.GetConnectionString(connectionStringName);
        }

        partial void CustomizeConfiguration(ref DbContextOptionsBuilder optionsBuilder);

        public virtual DbSet<Person> People
        {
            get;
            set;
        }

        public virtual DbSet<Number> Numbers
        {
            get;
            set;
        }

        public virtual DbSet<City> Cities
        {
            get;
            set;
        }

        public virtual DbSet<Login> Logins
        {
            get;
            set;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            this.PersonMapping(modelBuilder);
            this.CustomizePersonMapping(modelBuilder);

            this.NumberMapping(modelBuilder);
            this.CustomizeNumberMapping(modelBuilder);

            this.CityMapping(modelBuilder);
            this.CustomizeCityMapping(modelBuilder);

            this.LoginMapping(modelBuilder);
            this.CustomizeLoginMapping(modelBuilder);

            RelationshipsMapping(modelBuilder);
            CustomizeMapping(ref modelBuilder);
        }

        #region Person Mapping

        private void PersonMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable(@"People");
            modelBuilder.Entity<Person>().Property(x => x.Id).HasColumnName(@"Id").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Person>().Property(x => x.Name).HasColumnName(@"Name").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<Person>().Property(x => x.Address).HasColumnName(@"Address").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<Person>().Property<int>(@"Zip").HasColumnName(@"Zip").ValueGeneratedNever();
            modelBuilder.Entity<Person>().HasKey(@"Id");
        }

        partial void CustomizePersonMapping(ModelBuilder modelBuilder);

        #endregion

        #region Number Mapping

        private void NumberMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Number>().ToTable(@"Numbers");
            modelBuilder.Entity<Number>().Property(x => x.Id).HasColumnName(@"Id").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Number>().Property(x => x.NumberString).HasColumnName(@"NumberString").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<Number>().HasKey(@"Id");
        }

        partial void CustomizeNumberMapping(ModelBuilder modelBuilder);

        #endregion

        #region City Mapping

        private void CityMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().ToTable(@"Cities");
            modelBuilder.Entity<City>().Property(x => x.Zip).HasColumnName(@"Zip").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<City>().Property(x => x.Name).HasColumnName(@"Name").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<City>().HasKey(@"Zip");
        }

        partial void CustomizeCityMapping(ModelBuilder modelBuilder);

        #endregion

        #region Login Mapping

        private void LoginMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>().ToTable(@"Logins");
            modelBuilder.Entity<Login>().Property(x => x.Id).HasColumnName(@"Id").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Login>().Property(x => x.Username).HasColumnName(@"Username").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<Login>().Property(x => x.Password).HasColumnName(@"Password").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<Login>().HasKey(@"Id");
        }

        partial void CustomizeLoginMapping(ModelBuilder modelBuilder);

        #endregion

        private void RelationshipsMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasMany(x => x.Numbers).WithMany(op => op.People);
            modelBuilder.Entity<Person>().HasOne(x => x.City).WithMany(op => op.People).HasForeignKey(@"Zip").IsRequired(true);

            modelBuilder.Entity<City>().HasMany(x => x.People).WithOne(op => op.City).HasForeignKey(@"Zip").IsRequired(true);
        }

        partial void CustomizeMapping(ref ModelBuilder modelBuilder);

        public bool HasChanges()
        {
            return ChangeTracker.Entries().Any(e => e.State == Microsoft.EntityFrameworkCore.EntityState.Added || e.State == Microsoft.EntityFrameworkCore.EntityState.Modified || e.State == Microsoft.EntityFrameworkCore.EntityState.Deleted);
        }

        partial void OnCreated();
    }
}
