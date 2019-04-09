using ApiRentFlatMvc.Models;
using ApiRentFlatMvc.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace ApiRentFlatMvc.Controllers
{
    public class BackCostasController : ApiController
    {
        Repository repo;

        public BackCostasController()
        {
            this.repo = new Repository();
        }
        //---------------------
        [HttpGet]
       
        [Route("api/GetNombreCostas")]
        public List<Costas> GetNombreCostas()
        {
            return this.repo.GetNombreCostas();
        }

        //-----------------------------------------------------
        [HttpGet]
        [Route("api/BuscarCosta/{id}")]
        public Costas BuscarCosta(int id)
        {
            return this.repo.BuscarCosta(id);
        }

        [Route("api/InsertarCosta")]
        public void Post(Costas cost)
        {
            this.repo.InsertarCosta(cost);
        }

        [Route("api/ModificarCosta/{id}")]
        public void Put(Costas h, int id)
        {
            this.repo.ModificarCosta(h);
        }

        [Route("api/EliminarCosta/{id}")]
        public void Delete(int id)
        {
            this.repo.EliminarCosta(id);
        }

       

    }
}
