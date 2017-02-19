using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using dconfianza.Web.Api.Models.Registration.Interface;
using dconfianza.Entity;

namespace dconfianza.Web.Api.Controllers.Registration
{
    public class RegistrationController : ApiController
    {
        private readonly IRegistration repository;
        
        public RegistrationController(IRegistration repository)
        {
            this.repository = repository;
        }

        #region Gets

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>
        /// http://server/selery/api/registration/id
        /// </remarks>
        public User Get(int id)
        {
            User user = repository.SelectUserByID(id);
            if (user == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }

            return user;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        /// <remarks>
        /// http://server/Selery/api/registration/getuserbyemail/?email=email
        /// </remarks>
        public User GetUserByEmail(string email)
        {
            User user = repository.SelectUserByEmail(email);
            if (user == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }

            return user;

        }

        #endregion

        #region Posts

        [HttpPost, ActionName("new")]
        public HttpResponseMessage Post(User user)
        {
            User newUser = repository.CreateUser(user);
            var response = Request.CreateResponse<User>(HttpStatusCode.Created, newUser);
            response.Headers.Location = new Uri(Request.RequestUri, string.Format("/api/registration/{0}", newUser.UserID.ToString()));
            return response;
        }

        [HttpPost, ActionName("login")]
        public HttpResponseMessage PostLogin(Credentials credentials)
        {
            User result = repository.LoginByEmail(credentials.Email, credentials.Password);
            if (result == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Request.CreateResponse<User>(HttpStatusCode.OK, result);
        }
         
        #endregion

    }

}
