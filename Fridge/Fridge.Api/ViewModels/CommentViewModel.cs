using Fridge.Common.Mapping;
using Fridge.Models.Social;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace Fridge.Api.ViewModels
{
    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string Username { get; set; }

        public string UserImage { get; set; }

        public int Stars { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
             .ForMember(dest => dest.Username, opt => opt.MapFrom(from => from.User.FullName));

            configuration.CreateMap<Comment, CommentViewModel>()
            .ForMember(dest => dest.UserImage, opt => opt.MapFrom(from => from.User.Image));

            configuration.CreateMap<Comment, CommentViewModel>()
            .ForMember(dest => dest.Stars, opt => opt.MapFrom(from => (int)from.Ratings.Select(x => x.Stars).Average()));
        }
    }
}