﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcApplication1.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ComputersEntities5 : DbContext
    {
        public ComputersEntities5()
            : base("name=ComputersEntities5")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Client> Clients { get; set; }
        public DbSet<ListSale> ListSales { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Sklad> Sklads { get; set; }
        public DbSet<Tovar> Tovars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Oplata> Oplatas { get; set; }
        public DbSet<Korzina> Korzinas { get; set; }
    }
}