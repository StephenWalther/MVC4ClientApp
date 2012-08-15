using MyApp.Service.Models;
using MyApp.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyApp.Presentation.Web.Controllers.API
{
    public class BillingController : ApiController
    {
        private IBillingService _billingService;

        public BillingController(IBillingService billingService) {
            _billingService = billingService;
        }

        [HttpGet]
        public IList<PaymentDTO> List() {
            return _billingService.ListBillingHistory(User);
        }


    }
}
