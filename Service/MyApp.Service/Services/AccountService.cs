using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Service.Services
{
    public class AccountService : MyApp.Service.Services.IAccountService
    {

        public bool Authenticate(string userName, string password) {
            return userName == "Stephen";
        }

    }
}
