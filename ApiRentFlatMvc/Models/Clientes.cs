using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ApiRentFlatMvc.Models
{
    [Table("Clientes")]
    public class Clientes
    {
        [Key]
        [Column("IdCliente")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCliente { get; set; }

        [Column("NombreCliente")]
        public String NombreCliente { get; set; }
        //--
        [Column("ApellidoCliente")]
        public String ApellidoCliente { get; set; }

        [Column("EmailCliente")]
        public String EmailCliente { get; set; }

        [Column("Direccion")]
        public String Direccion { get; set; }

        [Column("Ciudad")]
        public String Ciudad { get; set; }

        [Column("Dni")]
        public string Dni { get; set; }

        [Column("Telefono")]
        public int Telefono { get; set; }

    }
}