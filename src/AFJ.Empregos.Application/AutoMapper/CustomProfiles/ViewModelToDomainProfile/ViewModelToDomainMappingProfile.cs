using AFJ.Empregos.Application.ViewModels;
using AFJ.Empregos.Domain.Entities;
using AFJ.Empregos.Domain.ValueObjects;
using AutoMapper;

namespace AFJ.Empregos.Application.AutoMapper.CustomProfiles.ViewModelToDomainProfile
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        public ViewModelToDomainMappingProfile()
        {
            ConfigureMappings();
        }

        protected void ConfigureMappings()
        {
            CreateMap<DDDViewModel, DDD>().ReverseMap();
            CreateMap<OperadoraViewModel, Operadora>().ReverseMap();
            CreateMap<PlanoViewModel, Plano>().ReverseMap();
            CreateMap<TipoPlanoViewModel, TipoPlano>().ReverseMap();

            //ValueObjects
            CreateMap<PlanoTelefoniaVOViewModel, PlanoTelefoniaVO>().ReverseMap();
        }
    }
}
