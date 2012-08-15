using MyApp.Domain.Models;
using System.Collections.Generic;
using System.Security.Principal;

namespace MyApp.Domain.Services {
    public interface IBillingRepository {

        IList<Payment> ListBillingHistory(IPrincipal principal);
    
    }
}
