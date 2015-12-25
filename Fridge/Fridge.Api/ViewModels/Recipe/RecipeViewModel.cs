﻿namespace Fridge.Api.ViewModels.Recipe
{
    using Common.Mapping;
    using Fridge.Models;
    using System;
    using AutoMapper;
    using System.Linq;
    using System.Collections.Generic;

    public class RecipeViewModel : IMapFrom<Recipe>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public TimeSpan PreparationTime { get; set; }

        public TimeSpan CookingTime { get; set; }

        public TimeSpan TotalTime { get; set; }

        public string PostedBy { get; set; }

        public IEnumerable<string> Instructions { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Recipe, RecipeViewModel>()
              .ForMember(dest => dest.PostedBy, opt => opt.MapFrom(from => from.PostedBy.FullName));

            configuration.CreateMap<Recipe, RecipeViewModel>()
              .ForMember(dest => dest.Instructions,
              opt => opt.MapFrom(from => from.PreparationSteps
                                                .OrderBy(x => x.Position)
                                                .Select(x => x.Text)));
        }
    }
}