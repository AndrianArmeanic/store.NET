using AutoMapper;

namespace StoreApplication.Mappers
{
    public abstract class BaseMapper<TModel, TDto>: Profile
    {
        protected BaseMapper()
        {
            // Source -> Target
            CreateMap<TModel, TDto>();
            CreateMap<TDto, TModel>();
        }
    }
}
