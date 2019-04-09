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
    public class BackUsuariosController : ApiController
    {
        Repository repo;

        public BackUsuariosController()
        {
            this.repo = new Repository();
        }

        [HttpGet]
        [Route("api/GetNombreUsuario")]
        public List<Usuarios> GetNombreUsuario()
        {
            return this.repo.GetUsuarios();
        }

        //-----------------------------------------------------
        [HttpGet]
        [Route("api/BuscarUsuario/{id}")]
        public Usuarios BuscarUsuario(int id)
        {
            return this.repo.BuscarUsuario(id);
        }

        [Route("api/InsertarUsuario")]
        public void Post(Usuarios cost)
        {
            this.repo.InsertarUsuarios(cost);
        }

        [Route("api/ModificarUsuario/{id}")]
        public void Put(Usuarios h, int id)
        {
            this.repo.ModificarUsuario(h);
        }

        [Route("api/EliminarUsuario/{id}")]
        public void Delete(int id)
        {
            this.repo.EliminarUsuario(id);
        }

        [Authorize]
        [HttpGet]
        [Route("api/PerfilEmpleado")]
        public Usuarios PerfilEmpleado()
        {
            ClaimsIdentity identidad =
                User.Identity as ClaimsIdentity;
            string empno =
                identidad.FindFirst(ClaimTypes.NameIdentifier).Value
                ;
            Usuarios empleado = this.repo.ExisteEmpleado(User.Identity.Name,empno);
            return empleado;
        }

    }


}
