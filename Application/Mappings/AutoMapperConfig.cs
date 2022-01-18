using Application.Dto;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(c =>
            {
                c.CreateMap<Post, PostDto>();
                c.CreateMap<CreatePostDto, Post>();
                c.CreateMap<UpdatePostDto, Post>();
            })
            .CreateMapper();
    }
}
