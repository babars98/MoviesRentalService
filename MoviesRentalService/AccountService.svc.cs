using MoviesRentalService.BusinessLogic;
using MoviesRentalService.DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MoviesRentalService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class AccountService : IAccountService
    {
        private readonly AccountBL _accBusinessLogic;

        public AccountService()
        {
            _accBusinessLogic = new AccountBL();
        }

        public Object Login(string email, string password)
        {
            var result = _accBusinessLogic.LoginUser(email, password);
            return result == null ? null : JsonConvert.SerializeObject(result);
        }

        public bool Register(string name, string email, string password)
        {
            return _accBusinessLogic.RegisterUser(name, email, password);
        }
    }
}
