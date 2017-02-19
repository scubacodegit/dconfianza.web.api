using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using dconfianza.Model;
using dconfianza.Web.Api.Models.Registration.Interface;
using dconfianza.Web.Api.Models.Main.Interface;
using dconfianza.Web.Api.Models.Registration.Repository;
using dconfianza.Web.Api.Models.Main.Repository;
using dconfianza.Web.Api.Controllers.Registration;
using dconfianza.Web.Api.Controllers.Main;


namespace dconfianza.Web.Api.App_Code
{
    public class dconfianzaContainer : IDependencyResolver
    {
        static readonly IRegistration registrationRepository = new RegistrationRepository();
        static readonly IMain mainRepository = new MainRepository();

        public IDependencyScope BeginScope()
        {
            // This example does not support child scopes, so we simply return 'this'. 
            return this;
        }

        public object GetService(Type serviceType)
        {

            if (serviceType == typeof(RegistrationController))
            {
                return new RegistrationController(registrationRepository);
            }
            if (serviceType == typeof(MainController))
            {
                return new MainController(mainRepository);
            }
            else
            {
                return null;
            }

        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
            // When BeginScope returns 'this', the Dispose method must be a no-op. 
        }


    }
}
