﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prilozhenie.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class DatabaseEntities : DbContext
    {
        public static DatabaseEntities _instance;
        public DatabaseEntities()
            : base("name=DatabaseEntities")
        {
        }
        public static DatabaseEntities GetContext()
        {
            if (_instance == null)
                _instance = new DatabaseEntities();
            return _instance;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Contracts> Contracts { get; set; }
        public virtual DbSet<CountsOfRooms> CountsOfRooms { get; set; }
        public virtual DbSet<Requests> Requests { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Rooms> Rooms { get; set; }
        public virtual DbSet<TypeOfRooms> TypeOfRooms { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
