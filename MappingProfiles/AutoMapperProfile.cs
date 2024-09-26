using AutoMapper;
using DotNet8API.dto;
using DotNet8API.Model;

namespace DotNet8API.MappingProfiles
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddUpdateOurHero, OurHero>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.isActive, opt => opt.Ignore());

        }
    }
}
