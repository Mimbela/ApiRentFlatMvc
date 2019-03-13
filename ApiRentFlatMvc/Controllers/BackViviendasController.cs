using ApiRentFlatMvc.Models;
using ApiRentFlatMvc.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiRentFlatMvc.Controllers
{
    public class BackViviendasController : ApiController
    {
        IRepository repo;

        public BackViviendasController(IRepository repo)
        {
            this.repo = repo;
        }

        //-------------------
        //api/Tipos_Vivienda
        [HttpGet]
        [Route("api/GetTiposViviendas")]
        public List<Tipos_Vivienda> ObtenerTiposViviendas()
        {
            return this.repo.GetTiposViviendas();
        }


        [HttpGet]
        [Route("api/GetViviendas")]
        public List<Viviendas> ObtenerViviendas()
        {
            return this.repo.GetViviendas();
        }

        [HttpPost]
        [Route("api/GetViviendasByFilter")]
        public List<VIVIENDASPORFILTRO> GetViviendasByFilter(BusquedaModel content)
        {
            return this.repo.GetViviendasByFilter(content.TiposViviendaSelectedValue, content.CostasSelectedValue, 
                content.NumeroBaniosSelectedValue, content.NumeroHabitacionesSelectedValue, content.Cod_Casa, content.Cod_Cliente);

        }

        //[HttpPost]
        //[Route("api/")]



    }
}
