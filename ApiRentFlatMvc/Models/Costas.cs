using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ApiRentFlatMvc.Models
{
    [Table("Costas")]
    public class Costas
    {
            [Key]
            [Column("Cod_Provincia")]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Cod_Provincia { get; set; }

            [Column("NombreProvincia")]
            public String NombreProvincia { get; set; }

            [Column("Foto")]
            public byte[] Foto { get; set; }

        
    }
}