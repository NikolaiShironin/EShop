﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EShop.Classes
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class EStoreEntities : DbContext
    {
        private static EStoreEntities _Context;
        public EStoreEntities()
            : base("name=EStoreEntities")
        {
        }

        public static EStoreEntities GetContext()
        {
            if (_Context == null)
                _Context = new EStoreEntities();
            return _Context;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Delivery> Delivery { get; set; }
        public virtual DbSet<DeliveryEmployee> DeliveryEmployee { get; set; }
        public virtual DbSet<Goods> Goods { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrdersGoods> OrdersGoods { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<WayToGet> WayToGet { get; set; }
    }
}