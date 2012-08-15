using System;
namespace MyApp.Service.Services {
    public interface IAccountService {
        bool Authenticate(string userName, string password);
    }
}
