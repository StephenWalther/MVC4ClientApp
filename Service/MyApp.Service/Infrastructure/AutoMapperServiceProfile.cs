using AutoMapper;
using MyApp.Domain.Models;
using MyApp.Service.Models;

namespace MyApp.Service.Infrastructure {

public class AutoMapperServiceProfile : Profile {

    public override string ProfileName {
        get {
            return "ServiceProfile";
        }
    }

    protected override void Configure() {
        Mapper.CreateMap<Payment, PaymentDTO>();
    }

}
}