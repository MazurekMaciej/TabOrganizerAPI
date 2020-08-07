using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TabOrganizer_website.Dtos;
using TabOrganizer_website.Models;

namespace TabOrganizer_website.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<UserUpdateDto, User>();

            CreateMap<Container, ContainerReadDto>();
            CreateMap<ContainerReadDto, Container>();

            //CreateMap<Container, ContainerUpdateDto>();
            CreateMap<ContainerUpdateDto, Container>();
            CreateMap<ContainerCreateDto, Container>();

            CreateMap<Website, WebsiteReadDto>();
            CreateMap<WebsiteDto, Website>();
        }
    }
}
