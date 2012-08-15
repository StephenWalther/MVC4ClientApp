using MyApp.Service.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;

namespace MyApp.Presentation.Web.Controllers.API {

    public class AccountController : ApiController {

        private IAccountService _accountService;

        public AccountController(IAccountService accountService) {
            _accountService = accountService;
        }


        [HttpPost]
        public HttpResponseMessage Authenticate(AuthenticateViewModel vm) {
            if (vm == null) {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Missing user name or password");
            }

            // Attempt to authenticate
            if (_accountService.Authenticate(vm.UserName, vm.Password) == false) {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid user name or password");
            }

            // Authenticated!
            FormsAuthentication.SetAuthCookie(vm.UserName, false);
            return Request.CreateResponse(HttpStatusCode.OK, true);        
        }


    }


    public class AuthenticateViewModel {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }


}
