﻿using SBLibrary.Data.Models.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary.Data.Models.Repository
{
    public class SBLibraryContext : DbContext
    {
        //specify the connection string to use
        public SBLibraryContext() : base("SBLibraryContext")
        {
            //this.Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer(new SBLInitializer());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> Roles { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ReadList> ReadLists { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<ShareBook> ShareBooks { get; set; }
        public DbSet<ForgotPassword> ForgotPasswords { get; set; }

        //prevent db from pluralizing db name 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<SBLibrary.Data.Models.Domain.ChangePassword> ResetPasswords { get; set; }

        public System.Data.Entity.DbSet<SBLibrary.Data.Models.Domain.UploadBook> UploadBooks { get; set; }

        //public System.Data.Entity.DbSet<SBLibrary.Service.Models.UploadBook> UploadBooks { get; set; }
    }
}
