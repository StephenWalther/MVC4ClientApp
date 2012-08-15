using MyApp.Domain.Models;
using MyApp.Domain.Services;
using MyApp.Infrastructure.Persistence.EF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Persistence.EF.Repositories {
    public class BillingRepository:IBillingRepository {

        private DataContext _dataContext = new DataContext();

        public IList<Payment> ListBillingHistory(IPrincipal principal) {
            return _dataContext.Payments.ToList();
        }
    }
}
