using AutoMapper;
using MyApp.Domain.Services;
using MyApp.Infrastructure.Persistence.EF.Repositories;
using MyApp.Service.Models;
using System.Collections.Generic;
using System.Security.Principal;

namespace MyApp.Service.Services {
    public class BillingService : MyApp.Service.Services.IBillingService {

        private IBillingRepository _billingRepository;

        public BillingService():this(new BillingRepository()) {
        }

        public BillingService(IBillingRepository billingRepository) {
            _billingRepository = billingRepository;
        }

        public IList<PaymentDTO> ListBillingHistory(IPrincipal principal) {
            var billingHistory = _billingRepository.ListBillingHistory(principal);
            return Mapper.Map<IList<PaymentDTO>>(billingHistory); 
        }

    }
}
