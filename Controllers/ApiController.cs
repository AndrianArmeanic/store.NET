using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreApplication.Repos;

namespace StoreApplication.Controllers
{
    [ApiController]
    public abstract class ApiController<TRepo> : ControllerBase where TRepo : IRepo
    {
        protected readonly IMapper Mapper;

        protected readonly TRepo Repository;

        protected ApiController (IMapper mapper, TRepo repository)
        {
            this.Mapper = mapper;
            this.Repository = repository;
        }
    }
}
