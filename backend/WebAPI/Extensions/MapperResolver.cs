using AutoMapper;
using WebAPI.Database.Dtos;
using WebAPI.Models;

namespace WebAPI.Extensions;

public static class MapperResolver
{
    public static Mapper InitiateMapping()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<UserDto, User>()
                .ForMember(d => d.Skills, o => o
                    .Ignore());

            cfg.CreateMap<ProjectDto, Project>()
                .ForMember(d => d.ProjectState, o => o.Ignore())
                .ForMember(d => d.Members, o => o.Ignore())
                .ForMember(d => d.Steck, o => o.Ignore());
        });

        var mapper = new Mapper(config);
        return mapper;
    }
}