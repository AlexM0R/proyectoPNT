using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoPNT_MVC.Models;


namespace ProyectoPNT_MVC.Context
{
    public class ProyectoPNTDatabaseContext : DbContext
    {
        public
        ProyectoPNTDatabaseContext(DbContextOptions<ProyectoPNTDatabaseContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\ServidorLocal;Database=ProyectoPNTDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Carrito>().HasKey(c => new { c.articuloId, c.usuarioId });
            modelBuilder.Entity<Carrito>()
                .HasOne<Usuario>(c => c.usuario)
                .WithMany(a => a.carrito)
                .HasForeignKey(c => c.usuarioId);


            modelBuilder.Entity<ListaArticulos>().HasKey(la => new { la.articuloId, la.compraId });
            modelBuilder.Entity<ListaArticulos>()
                .HasOne<Compra>(la => la.compra)
                .WithMany(c => c.listaArticulos)
                .HasForeignKey(la => la.compraId);


            modelBuilder.Entity<ListaDeseados>().HasKey(ld => new { ld.articuloId, ld.usuarioId });
            modelBuilder.Entity<ListaDeseados>()
                .HasOne<Usuario>(ld => ld.usuario)
                .WithMany(d => d.deseados)
                .HasForeignKey(ld => ld.usuarioId);


            modelBuilder.Entity<ListaCompras>().HasKey(lc => new { lc.compraId, lc.usuarioId });
            modelBuilder.Entity<ListaCompras>()
                .HasOne<Usuario>(lc => lc.usuario)
                .WithMany(c => c.compras)
                .HasForeignKey(lc => lc.usuarioId);


        }

        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Carrito> Carrito { get; set; }
        public DbSet<ListaArticulos> ListaArticulos { get; set; }
        public DbSet<ListaDeseados> ListaDeseados{ get; set; }
        public DbSet<ListaCompras> ListaCompras { get; set; }


    }
}