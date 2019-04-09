using ApiRentFlatMvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApiRentFlatMvc.Data
{
    public class RentContext:DbContext
    {
        public RentContext() : base("name=cadenaazure") { }

        public DbSet<Clientes> Clientes { get; set;}


        public DbSet<Costas> Costas { get; set; }



        public DbSet<Galeria_Fotos> Galeria_Fotos { get; set; }


        public DbSet<Precios_Vivienda> Precios_Vivienda { get; set; }


        public DbSet<Tipos_Vivienda> Tipos_Vivienda { get; set; }


        public DbSet<Usuarios> Usuarios { get; set; }


        public DbSet<Viviendas> Viviendas { get; set; }


        public DbSet<VIVIENDASPORFILTRO> VIVIENDASPORFILTRO { get; set; }

        public List<VIVIENDASPORFILTRO> GetViviendasByFilter(int TipoVivienda, int Costa, int Banios, int Habitaciones, int Cod_Casa, int Cod_Cliente)
        {
            string sql = @"VIVIENDASPORFILTRO @Cod_TiposVivienda 
                                 , @Cod_Provincia  
                                 , @Num_banios 
                                 , @Num_habitaciones 
                                 , @Cod_casa 
                                 , @Cod_cliente";
            SqlParameter tViviendaParam = new SqlParameter("@Cod_TiposVivienda", TipoVivienda);
            SqlParameter costaParam = new SqlParameter("@Cod_Provincia", Costa);
            SqlParameter baParam = new SqlParameter("@Num_banios", Banios);
            SqlParameter habitParam = new SqlParameter("@Num_habitaciones", Habitaciones);
            SqlParameter codcasaParam = new SqlParameter("@Cod_casa", Cod_Casa);
            SqlParameter codclienteParam = new SqlParameter("@Cod_cliente", Cod_Cliente);
            var consulta = this.VIVIENDASPORFILTRO.SqlQuery(sql, tViviendaParam, costaParam, baParam, habitParam, codcasaParam, codclienteParam).ToList();

            return consulta;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<RentContext>(null);
        }
    }
}