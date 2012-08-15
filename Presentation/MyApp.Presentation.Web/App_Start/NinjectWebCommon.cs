[assembly: WebActivator.PreApplicationStartMethod(typeof(MyApp.Presentation.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(MyApp.Presentation.Web.App_Start.NinjectWebCommon), "Stop")]

namespace MyApp.Presentation.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using System.Web.Http;
    using Ninject.Syntax;
    using System.Web.Http.Dependencies;
    using Ninject.Activation;
    using System.Collections.Generic;
    using Ninject.Parameters;
    using System.Linq;


    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<MyApp.Service.Services.IAccountService>().To<MyApp.Service.Services.AccountService>();
            kernel.Bind<MyApp.Service.Services.IBillingService>().To<MyApp.Service.Services.BillingService>();

            GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);
        }        
    }


    public class NinjectResolver : NinjectScope, IDependencyResolver {
        private IKernel _kernel;
        public NinjectResolver(IKernel kernel)
            : base(kernel) {
            _kernel = kernel;
        }
        public IDependencyScope BeginScope() {
            return new NinjectScope(_kernel.BeginBlock());
        }
    }

    public class NinjectScope : IDependencyScope {
        protected IResolutionRoot resolutionRoot;

        public NinjectScope(IResolutionRoot kernel) {
            resolutionRoot = kernel;
        }

        public object GetService(Type serviceType) {
            IRequest request = resolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return resolutionRoot.Resolve(request).SingleOrDefault();
        }

        public IEnumerable<object> GetServices(Type serviceType) {
            IRequest request = resolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return resolutionRoot.Resolve(request).ToList();
        }

        public void Dispose() {
            IDisposable disposable = (IDisposable)resolutionRoot;
            if (disposable != null) disposable.Dispose();
            resolutionRoot = null;
        }
    }

}
