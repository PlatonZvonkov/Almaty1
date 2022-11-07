using AlmatyApi.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AlmatyApi.Context
{
    public partial class SQLLocalDBContext : DbContext
    {
        public SQLLocalDBContext()
        {
        }

        public SQLLocalDBContext(DbContextOptions<SQLLocalDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MoovedGoods> MoovedGoods { get; set; }
        public virtual DbSet<Nomenclature> Nomenclature { get; set; }
        public virtual DbSet<Warehouses> Warehouses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MoovedGoods>(entity =>
            {
                entity.HasKey(e => new { e.NomenclatureId, e.WarehouseToId, e.WarehouseFromId })
                    .HasName("PK__MoovedGo__4AAC7BE2137399D5");

                entity.Property(e => e.NomenclatureId).HasColumnName("Nomenclature_id");

                entity.Property(e => e.WarehouseToId).HasColumnName("WarehouseTo_id");

                entity.Property(e => e.WarehouseFromId).HasColumnName("WarehouseFrom_id");

                entity.Property(e => e.Date).HasColumnType("datetime");
            });

            modelBuilder.Entity<MoovedGoods>().HasData(
                new MoovedGoods[]
            {
                new MoovedGoods { NomenclatureId=1,WarehouseFromId=2,WarehouseToId=3,Date=DateTime.Now,Ammount=10},
                new MoovedGoods { NomenclatureId=2,WarehouseFromId=3,WarehouseToId=1,Date=DateTime.Now,Ammount=11},
                new MoovedGoods { NomenclatureId=3,WarehouseFromId=1,WarehouseToId=2,Date=DateTime.Now,Ammount=22}
            });
            modelBuilder.Entity<Nomenclature>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasColumnType("text");
            });
            modelBuilder.Entity<Nomenclature>().HasData(
               new Nomenclature[]
           {
                new Nomenclature { Id=1,Name="IPhone"},
                new Nomenclature { Id=2,Name="Samsung"},
                new Nomenclature { Id=3,Name="Nokia"},
                new Nomenclature { Id=4,Name="Xiaomi"},
                new Nomenclature { Id=5,Name="Huawei"},
                new Nomenclature { Id=6,Name="Sony"},
                new Nomenclature { Id=7,Name="Honor"}
           });

            modelBuilder.Entity<Warehouses>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasColumnType("text");
            });
            modelBuilder.Entity<Warehouses>().HasData(
              new Warehouses[]
              {
                  new Warehouses { Id = 1, Name = "Almaty" },
                  new Warehouses { Id = 2, Name = "Astana" },
                  new Warehouses { Id = 3, Name = "Kokshetau" },
              });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
