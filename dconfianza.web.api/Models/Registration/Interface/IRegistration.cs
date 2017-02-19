using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dconfianza.Entity;

namespace dconfianza.Web.Api.Models.Registration.Interface
{
    public interface IRegistration
    {
        User CreateUser(User user);
        int FindUserByEmail(string email);
        User SelectUserByEmail(string email);
        User SelectUserByID(int userID);                
        User LoginByEmail(string email, byte[] password);        
        Boolean IsProfileComplete(int userID);
    }
}
