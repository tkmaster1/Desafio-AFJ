using AFJ.Empregos.Application.AutoMapper.CustomProfiles.DomainToViewModelProfile;
using AFJ.Empregos.Application.AutoMapper.CustomProfiles.ViewModelToDomainProfile;
using AutoMapper;

namespace AFJ.Empregos.Application.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x => {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            });

            Mapper.AssertConfigurationIsValid();
        }
    }
}
