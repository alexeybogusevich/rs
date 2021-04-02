using AutoMapper;
using KNU.RS.Data.Models;
using KNU.RS.Logic.Models.Account;

namespace KNU.RS.Logic.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<PatientRegistrationModel, User>(MemberList.Source);
            CreateMap<PatientRegistrationModel, Patient>(MemberList.Source);
            CreateMap<DoctorRegistrationModel, User>(MemberList.Source);
            CreateMap<DoctorRegistrationModel, Doctor>(MemberList.Source);
        }
    }
}
