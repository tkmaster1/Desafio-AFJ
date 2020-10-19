using AFJ.Empregos.Application.ViewModels;
using AFJ.Empregos.Domain.Entities;
using AFJ.Empregos.Domain.ValueObjects;
using AutoMapper;

namespace AFJ.Empregos.Application.AutoMapper.CustomProfiles.DomainToViewModelProfile
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappings";
            }
        }

        public DomainToViewModelMappingProfile()
        {
            ConfigureMappings();
        }

        /// <summary>
        /// Creates a mapping between source (Domain) and destination (ViewModel)
        /// </summary>
        private void ConfigureMappings()
        {
            CreateMap<DDD, DDDViewModel>().ReverseMap();
            CreateMap<Operadora, OperadoraViewModel>().ReverseMap();
            CreateMap<Plano, PlanoViewModel>().ReverseMap();
            CreateMap<TipoPlano, TipoPlanoViewModel>().ReverseMap();

            //ValueObjects
            CreateMap<PlanoTelefoniaVO, PlanoTelefoniaVOViewModel>().ReverseMap();
        }
    }
}
