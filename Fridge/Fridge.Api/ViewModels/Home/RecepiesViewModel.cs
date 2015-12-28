namespace Fridge.Api.ViewModels.Home
{
    using System;
    using AutoMapper;
    using Fridge.Common.Mapping;
    using Fridge.Models;

    public class RecepiesViewModel : IMapFrom<Recipe>, IHaveCustomMappings
    {
        public string UrlId {
            get { return this.Name.Replace(" ", "-"); }           
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string PostedBy { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Recipe, RecepiesViewModel>()
              .ForMember(dest => dest.PostedBy, opt => opt.MapFrom(from => from.PostedBy.FullName));
        }
    }
}