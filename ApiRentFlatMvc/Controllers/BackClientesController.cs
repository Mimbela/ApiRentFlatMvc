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
    public class BackClientesController : ApiController
    {
        Repository repo;

        public BackClientesController()
        {
            this.repo = new Repository();
        }

        //-------------------------
        //public List<Clientes> GetClientes()
        //{
        //    return this.entidad.Clientes.ToList();
        //}
        [HttpGet]
        [Route("api/GetClientes")]
        public List<Clientes> GetClientes()
        {
            return this.repo.GetClientes();
        }



        //------------------
        [HttpGet]
        [Route("api/BuscarClientes/{id}")]
        public Clientes BuscarClientes(int id)
        {
            return this.repo.BuscarClientes(id);
        }

        [Route("api/InsertarCliente")]
        public void Post(Clientes cost)
        {
            this.repo.InsertarClientes(cost);
        }

        [Route("api/ModificarCliente/{id}")]
        public void Put(Clientes h, int id)
        {
            this.repo.ModificarClientes(h);
        }

        [Route("api/EliminarCliente/{id}")]
        public void Delete(int id)
        {
            this.repo.EliminarClientes(id);
        }
    }
}
