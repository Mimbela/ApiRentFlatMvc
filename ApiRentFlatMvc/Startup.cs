using System;
using System.Threading.Tasks;
using System.Web.Http;
using ApiRentFlatMvc.Credentials;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using ApiRentFlatMvc.Repositories;

[assembly: OwinStartup(typeof(ApiRentFlatMvc.Startup))]

namespace ApiRentFlatMvc
{
    public class Startup
    {

        public void ConfigurarOAuth(IAppBuilder app)
        {

            OAuthAuthorizationServerOptions opcionesautorizacion = new OAuthAuthorizationServerOptions()
            {
                //PERMITIMOS AUTORIZACIONES HTTP
                AllowInsecureHttp = true,
                //INCLUIMOS UNA RUTA PARA ACCEDER A LA GENERACION
                //DEL TOKEN
                TokenEndpointPath = new PathString("/login"),
                //TIEMPO QUE EL TOKEN NOS PERMITIRA ACCEDER A LAS
                //PETICIONES GET SIN NECESIDAD DE GENERAR NINGUN OTRO
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),
                //CLASE ENCARGADA DE VALIDAR SI EL USUARIO
                //TIENE ACCESO A LA GENERACION DE TOKENS
               // Provider = new AutorizacionToken()//OJO-->porque inyecto lo pongo
               Provider=new AutorizacionToken()
            };

            //AÑADIMOS LA AUTORIZACION A NUESTRA APLICACION
            app.UseOAuthAuthorizationServer(opcionesautorizacion);
            //CREARNOS LAS OPCIONES DE AUTORIZACION BEARER
            //QUE NOS GENERARA EL TOKEN

            OAuthBearerAuthenticationOptions beareroptions =
            new OAuthBearerAuthenticationOptions()
            {
                //INDICAMOS QUE UTILIZAMOS LA AUTORIZACION
                //DE TIPO OWIN ESTA ACTIVADA
                AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active
            };
            //CONFIGURAMOS LA APLICACION INDICANDO LAS OPCIONES
            //DE SEGURIDAD BEARER
            app.UseOAuthBearerAuthentication(beareroptions);
        }

        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            //ESTE METODO ES EL ACCESO DE ARRANQUE DE
            //NUESTRA APP WEB API
            //CREAMOS EL OBJETO PARA CONFIGURACION DE NUESTRO API
            HttpConfiguration config = new HttpConfiguration();
            //REGISTRAR LAS RUTAS DE ACCESO A NUESTRO API
            WebApiConfig.Register(config);
            //SI DESEAMOS INCLUIR SEGURIDAD, LLAMAMOS
            //AL METODO DE CONFIGURACION OAUTH
            ConfigurarOAuth(app);
            //INDICAMOS A LA APLICACION LA CONFIGURACION DEL API
            app.UseWebApi(config);
        }
    }
}
