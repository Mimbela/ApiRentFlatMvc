using ApiRentFlatMvc.Models;
using ApiRentFlatMvc.Repositories;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace ApiRentFlatMvc.Credentials
{
    public class AutorizacionToken: OAuthAuthorizationServerProvider
    {
        Repository repo;

        public AutorizacionToken()
        {
            this.repo = new Repository();
        }

        //------------------------------------------

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return base.ValidateClientAuthentication(context);
        }

        //----------

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //INCLUIMOS LOS PERMISOS CORS POR SI ENTRAMOS DESDE AJAX
            //   context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            //DEBEMOS VALIDAR EL USUARIO Y PASSWORD
            //DICHOS VALORES VIENEN DENTRO DEL CONTEXT
            string login = context.UserName;
            string password = context.Password;

            Usuarios doc = this.repo.ExisteEmpleado(login, password);

            if (doc == null)
            {
                //SI NO EXISTE EL EMPLEADO, INCLUIMOS UN ERROR
                //DENTROL CONTEXT PARA QUE NO LO VALIDE
                context.SetError("Usuario/Password incorrectos"
                , "Has introducido mal tus credenciales");
            }
            else
            {
                //EL EMPLEADO EXISTE Y CREAMOS UNA IDENTIDAD
                ClaimsIdentity identidad = new ClaimsIdentity(context.Options.AuthenticationType);
                //AÑADIMOS DATOS A LA IDENTIDAD POR SI
                //DESEAMOS UTILIZARLOS EN ALGUNO MOMENTO
                identidad.AddClaim(new Claim(ClaimTypes.Name, doc.Login));
                identidad.AddClaim(new Claim(ClaimTypes.NameIdentifier, doc.Password));
                identidad.AddClaim(new Claim(ClaimTypes.Role, doc.Perfil));//rol
                //puedo elegir los tipos de claim que vaya a necesitar
                //INCLUIMOS LA IDENTIDAD DENTRO DE LA VALIDACION
                context.Validated(identidad);
            }
            return base.GrantResourceOwnerCredentials(context);
        }

    }
}