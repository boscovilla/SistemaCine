using Dominio;
using Dominio.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;



namespace Persistencia
{
   public class SistemaCineContext: IdentityDbContext<Usuario>
    {

        public SistemaCineContext(DbContextOptions options): base (options)
        {
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Reparto>().HasKey(r => new { r.ActorId, r.PeliculaId });
        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Pelicula> Pelicula { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<Actor> Actor { get; set; }
        public DbSet<Reparto> Reparto { get; set; }
        public DbSet<Funcion> Funcion { get; set; }
        public DbSet<Programacion> Programacion { get; set; }
        public DbSet<Sala> Sala { get; set; }
        public DbSet<Cine> Cine { get; set; }
        public DbSet<HorarioFuncion> HorarioFuncion { get; set; }




    }
}
