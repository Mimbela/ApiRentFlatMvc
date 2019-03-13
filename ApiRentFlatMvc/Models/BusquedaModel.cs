using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApiRentFlatMvc.Models
{
    public class BusquedaModel
    {
        //parametros de busqueda 


        public List<SelectListItem> TiposVivienda { get; set; }

        public List<SelectListItem> ListaCostas { get; set; }
        public List<SelectListItem> NumeroBanios { get; set; }
        public List<SelectListItem> NumeroHabitaciones { get; set; }

        public int TiposViviendaSelectedValue { get; set; }
        public int CostasSelectedValue { get; set; }
        public int NumeroBaniosSelectedValue { get; set; }
        public int NumeroHabitacionesSelectedValue { get; set; }
        public int Cod_Casa { get; set; }
        public int Cod_Cliente { get; set; }

    }
}