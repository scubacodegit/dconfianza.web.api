using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dconfianza.Web.Api.Models.Registration.Interface;
using dconfianza.Entity;
using dconfianza.Model;

namespace dconfianza.Web.Api.Models.Registration.Repository
{
    public class RegistrationRepository : IRegistration
    {
        public RegistrationRepository()
        {         
        }

        /// <summary>
        /// Crea un nuevo usuario
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User CreateUser(User user)
        {

            using (var context = new dconfianzaEntities())
            {                
                int userID = (int)context.reg_spInsertUser(user.FirstName, user.LastName, user.Email,null,user.Password).FirstOrDefault().UserID;
                return SelectUserByID(userID);
            }

        }
        public int FindUserByEmail(string email)
        {
            int userID = 0;

            using (var context = new dconfianzaEntities())
            {

                userID = context.reg_spFindUserByEmail(email).FirstOrDefault().UserID;

            }

            return userID;

        }

        public User SelectUserByEmail(string email)
        {
            User user = null;

            using (var context = new dconfianzaEntities())
            {
                
                reg_spSelectUserByEmail_Result userEF = context.reg_spSelectUserByEmail(email).FirstOrDefault();

                if (userEF != null)
                {
                    user = new User();
                    user.ActivationDate = userEF.ActivationDate.HasValue ? userEF.ActivationDate.Value : DateTime.MinValue;                    
                    user.BirthDate = userEF.BirthDate.HasValue ? userEF.BirthDate.Value : (DateTime?)null;
                    user.CreatedDate = userEF.CreatedDate;
                    user.CreatedBy = userEF.CreatedBy.HasValue ? userEF.CreatedBy.Value : 0;
                    user.Description = userEF.Description;
                    user.Email = userEF.Email;
                    user.FacebookID = userEF.FacebookID.HasValue ? userEF.FacebookID.Value : 0;
                    user.FirstName = userEF.FirstName;
                    user.Gender = userEF.Gender.HasValue ? userEF.Gender.Value : 0;                    
                    user.IsApproved = userEF.IsApproved.HasValue ? userEF.IsApproved.Value : false;
                    user.IsLockedOut = userEF.IsLockedOut.HasValue ? userEF.IsLockedOut.Value : false;
                    user.LastLoginDate = userEF.LastLoginDate.HasValue ? userEF.LastLoginDate.Value : DateTime.MinValue;
                    user.LastName = userEF.LastName;
                    user.LastUpdatedBy = userEF.LastUpdatedBy.HasValue ? userEF.LastUpdatedBy.Value : 0;
                    user.LastUpdatedDate = userEF.LastUpdatedDate.HasValue ? userEF.LastUpdatedDate.Value : DateTime.MinValue;
                    user.Password = null;
                    user.TerminationDate = userEF.TerminationDate.HasValue ? userEF.TerminationDate.Value : DateTime.MinValue;
                    user.UserID = userEF.UserID;                    
                    user.IsProfileComplete = this.IsProfileComplete(user.UserID);                    
                }
            }

            return user;
            
        }

        public User SelectUserByID(int userID)
        {
            User user = null;

            using (var context = new dconfianzaEntities())
            {

                reg_spSelectUserByID_Result userEF = context.reg_spSelectUserByID(userID).FirstOrDefault();

                if (userEF != null)
                {
                    user = new User();
                    user.ActivationDate = userEF.ActivationDate.HasValue ? userEF.ActivationDate.Value : DateTime.MinValue;
                    user.BirthDate = userEF.BirthDate.HasValue ? userEF.BirthDate.Value : (DateTime?)null;
                    user.CreatedDate = userEF.CreatedDate;
                    user.CreatedBy = userEF.CreatedBy.HasValue ? userEF.CreatedBy.Value : 0;
                    user.Description = userEF.Description;
                    user.Email = userEF.Email;
                    user.FacebookID = userEF.FacebookID.HasValue ? userEF.FacebookID.Value : 0;
                    user.FirstName = userEF.FirstName;
                    user.Gender = userEF.Gender.HasValue ? userEF.Gender.Value : 0;
                    user.IsApproved = userEF.IsApproved.HasValue ? userEF.IsApproved.Value : false;
                    user.IsLockedOut = userEF.IsLockedOut.HasValue ? userEF.IsLockedOut.Value : false;
                    user.LastLoginDate = userEF.LastLoginDate.HasValue ? userEF.LastLoginDate.Value : DateTime.MinValue;
                    user.LastName = userEF.LastName;
                    user.LastUpdatedBy = userEF.LastUpdatedBy.HasValue ? userEF.LastUpdatedBy.Value : 0;
                    user.LastUpdatedDate = userEF.LastUpdatedDate.HasValue ? userEF.LastUpdatedDate.Value : DateTime.MinValue;
                    user.Password = null;
                    user.TerminationDate = userEF.TerminationDate.HasValue ? userEF.TerminationDate.Value : DateTime.MinValue;
                    user.UserID = userEF.UserID;
                    user.IsProfileComplete = this.IsProfileComplete(user.UserID);
                }
            }

            return user;
        }

        public User LoginByEmail(string email, byte[] password)
        {
            int? userID = 0;
            User retUser = null;

            using (var context = new dconfianzaEntities())
            {
                userID = context.reg_spLoginByEmail(email, password).SingleOrDefault();
            }

            if (userID.HasValue && userID.Value > 0)
            {
                retUser = this.SelectUserByID(userID.Value);
            }
            return retUser;
        }

        public Boolean IsProfileComplete(int userID)
        {
            return true;
        }
    }
}
