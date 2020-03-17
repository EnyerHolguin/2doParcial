using Microsoft.EntityFrameworkCore;
using SegParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SegParcial.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Llamadas> Llamadas{ get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = SegParcial.db");
        }

       
    }
}
