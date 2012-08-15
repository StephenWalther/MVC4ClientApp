using MyApp.Service.Models;
using System;
using System.Collections.Generic;
using System.Security.Principal;
namespace MyApp.Service.Services {
    public interface IBillingService {
        IList<PaymentDTO> ListBillingHistory(IPrincipal principal);
    }
}
