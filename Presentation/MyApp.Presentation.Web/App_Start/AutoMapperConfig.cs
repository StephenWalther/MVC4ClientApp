[assembly: WebActivator.PreApplicationStartMethod(typeof(MyApp.Presentation.Web.App_Start.AutoMapperConfig), "Start")]
namespace MyApp.Presentation.Web.App_Start {
    using AutoMapper;

    public class AutoMapperConfig {
        public static void Start() {
            Mapper.Initialize(c => c.AddProfile<MyApp.Service.Infrastructure.AutoMapperServiceProfile>());
        }
    }
}
