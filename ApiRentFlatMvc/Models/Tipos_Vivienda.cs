using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ApiRentFlatMvc.Models
{
    [Table("Tipos_Vivienda")]
    public class Tipos_Vivienda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("Cod_tipo_vivienda")]
        public int Cod_tipo_vivienda { get; set; }

        [Column("Descripcion")]
        public String Descripcion { get; set; }
    }
}