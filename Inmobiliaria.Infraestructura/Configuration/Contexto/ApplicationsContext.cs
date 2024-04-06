﻿using Inmobiliaria.Infraestructura.Configuration.Entitty;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Inmobiliaria.Infraestructura.Configuration.Contexto
{
    public class ApplicationsContext:DbContext
    {
        public DbSet<Propiedad> Propiedades { get; set; }

        public ApplicationsContext()
        {

        }
        public ApplicationsContext(DbContextOptions<ApplicationsContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=RRHH_TEST;Trusted_Connection=True;Encrypt=Optional;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new EmpleadoConfig());
        }
    }
}
