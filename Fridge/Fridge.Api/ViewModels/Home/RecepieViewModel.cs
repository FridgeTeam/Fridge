﻿namespace Fridge.Api.ViewModels.Home
{
    using System;
    using AutoMapper;
    using Fridge.Common.Mapping;
    using Fridge.Models;

    public class RecepieViewModel : IMapFrom<Recipe>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string FromUsername { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Recipe, RecepieViewModel>()
              .ForMember(dest => dest.FromUsername, opt => opt.MapFrom(from => from.PostedBy.FullName));
        }
    }
}