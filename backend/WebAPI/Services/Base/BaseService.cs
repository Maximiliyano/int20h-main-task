using AutoMapper;
using WebAPI.Database;
using WebAPI.Extensions;

namespace WebAPI.Services.Base;

public abstract class BaseService
{
    private protected readonly WebApiDbContext _context;
    private protected readonly IMapper _mapper;

    public BaseService(WebApiDbContext context)
    {
        _context = context;
        _mapper = MapperResolver.InitiateMapping();
    }
}