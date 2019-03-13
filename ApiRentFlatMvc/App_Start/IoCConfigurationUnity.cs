using ApiRentFlatMvc.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.WebApi;

namespace ApiRentFlatMvc.App_Start
{
    public class IoCConfigurationUnity
    {

        //public static void Configure()
        //{
        //    UnityContainer container = new UnityContainer();
        //    RegistrarRepos(container);

        //    DependencyResolver.SetResolver(new UnityDependencyResolver(container));


        //}

        //public static void RegistrarRepos(UnityContainer container)
        //{
        //    //enlazo la interface con la clase implementadora
        //    container.RegisterType<IRepository, Repository>();

        //}
    }
}