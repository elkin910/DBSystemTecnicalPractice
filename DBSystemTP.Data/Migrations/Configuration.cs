namespace DBSystemTP.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DBSystemTP.Entities.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<DBSystemTP.Data.DBSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DBSystemTP.Data.DBSystemContext context)
        {

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var tiposDocumento = new List<TiposDocumento>
            {

                new TiposDocumento { Id=1, Nombre = "Cedula" },
                new TiposDocumento { Id=2, Nombre = "Pasaporte" },
                new TiposDocumento { Id=3, Nombre = "Tarjeta de Identidad" }

             };

            tiposDocumento.ForEach(s => context.TiposDocumentoes.AddOrUpdate(p => p.Nombre, s));
            context.SaveChanges();

            var paises = new List<Pais>
            {

                new Pais { Id=1, Nombre = "Colombia" },
                new Pais { Id=2, Nombre = "Mejico" },
                new Pais { Id=3, Nombre = "Argentina" }

            };

            paises.ForEach(s => context.Paises.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();
                       
            context.Departamentos.Add(new Departamento { Id = 1, Nombre = "Cundinamarca", Pais = context.Paises.FirstOrDefault(p => p.Id==1) });
            context.SaveChanges();

            context.Departamentos.Add(new Departamento { Id = 2, Nombre = "Boyaca", Pais = context.Paises.FirstOrDefault(p => p.Id ==1) });
            context.SaveChanges();

            context.Departamentos.AddOrUpdate(d => d.Id, new Departamento { Id = 3, Nombre = "Distrito Federal", Pais = context.Paises.FirstOrDefault(p => p.Id == 2) });
            context.SaveChanges();

            context.Departamentos.AddOrUpdate(d => d.Id, new Departamento { Id = 4, Nombre = "Córdoba", Pais = context.Paises.FirstOrDefault(p => p.Id == 3) });
            context.SaveChanges();

            var d1 = context.Departamentos.Include(p => p.Pais).FirstOrDefault(entity => entity.Id == 1);
            var d2 = context.Departamentos.Include(p => p.Pais).FirstOrDefault(entity => entity.Id == 2);
            var d3 = context.Departamentos.Include(p => p.Pais).FirstOrDefault(entity => entity.Id == 3);
            var d4 = context.Departamentos.Include(p => p.Pais).FirstOrDefault(entity => entity.Id == 4);


            var ciudad = new List<Ciudade>
            {

                new Ciudade { Id=1, Nombre = "Bogota D.C.", Departamento = d1  },
                new Ciudade { Id=1, Nombre = "Tunja", Departamento = d2  },
                new Ciudade { Id=2, Nombre = "Ciudad de México", Departamento = d3  },
                new Ciudade { Id=3, Nombre = "Durango", Departamento = d4}
             };

            ciudad.ForEach(s => context.Ciudades.AddOrUpdate(c => c.Id, s));
            context.SaveChanges();

            context.Usuarios.AddOrUpdate(u => u.Id, new Usuario { Id = 1, Nombre = "Elkin Cubillos", Direccion = "CRa 78F # 6-50", FechaNacimiento = DateTime.Parse("01-01-2018"), NumeroIdentificacion = "1032376628", TiposDocumento = context.TiposDocumentoes.FirstOrDefault(t => t.Id == 1), Ciudade = context.Ciudades.FirstOrDefault(c => c.Id == 1) });
            context.SaveChanges();


        }
    }
}
