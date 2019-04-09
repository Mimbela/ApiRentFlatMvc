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
    //[Authorize]
    public class BackViviendasController : ApiController
    {
        Repository repo;

        public BackViviendasController()
        {
            this.repo = new Repository();
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

        //---------------------
        [HttpGet]
        [Route("api/BuscarVivienda/{id}")]
        public Viviendas BuscarVivienda(int id)
        {
            return this.repo.BuscarViviendas(id);
        }

        [HttpGet]
        [Route("api/BuscarTipoVivienda/{id}")]
        public Tipos_Vivienda BuscarTipoVivienda(int id)
        {
            return this.repo.BuscarTipoVivienda(id);
        }


        //----------------------------------

        [HttpPost]
        [Route("api/GetViviendasByFilter")]
        public List<VIVIENDASPORFILTRO> GetViviendasByFilter(BusquedaModel content)
        {
            return this.repo.GetViviendasByFilter(content.TiposViviendaSelectedValue, content.CostasSelectedValue, 
                content.NumeroBaniosSelectedValue, content.NumeroHabitacionesSelectedValue, content.Cod_Casa, content.Cod_Cliente);

        }

        //-----------------------------------
        [Route("api/InsertarVivienda")]
        public int Post(Viviendas cost)
        {
            return this.repo.InsertarViviendas(cost);

        }


        [Route("api/InsertarTipoVivienda")]
        public void Post(Tipos_Vivienda cost)
        {
            this.repo.InsertarTipoViviendas(cost);
        }
        //-------------------------
        [Route("api/ModificarTipoVivienda/{id}")]
        public void Put(Tipos_Vivienda h, int id)
        {
            this.repo.ModificarTipoVivienda(h);
        }

        [Route("api/ModificarVivienda/{id}")]
        public void Put(Viviendas h, int id)
        {
            this.repo.ModificarVivienda(h);
        }

        //-----------------
        [Route("api/EliminarTipoVivienda/{id}")]
        public void Delete(int id)
        {
            this.repo.EliminarTipoViviendas(id);
        }

        [Route("api/EliminarVivienda/{id}")]
        public void DeleteVivienda(int id)
        {
            this.repo.EliminarViviendas(id);
        }

    }
}
