using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApplication.Dtos.Order;
using StoreApplication.Models;
using StoreApplication.Repos.Order;

namespace StoreApplication.Controllers
{
    [Authorize]
    [Route ("orders")]
    public class OrderController : ApiController<IOrderRepo>
    {
        public OrderController (IMapper mapper, IOrderRepo repository) : base (mapper, repository)
        {
        }

        [HttpGet ("user/{userId:guid}")]
        [ProducesResponseType (typeof(IQueryable<OrderDto>), StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IQueryable<OrderDto>>> GetByUserId (Guid userId)
        {
            IQueryable<OrderModel> usersOrders = await this.Repository.FindByUserId (userId);

            return !usersOrders.Any ()
                ? NotFound ()
                : Ok (this.Mapper.Map<IQueryable<OrderDto>> (usersOrders));
        }

        [HttpGet ("product/{productId:guid}")]
        [ProducesResponseType (typeof(IQueryable<OrderDto>), StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IQueryable<OrderDto>>> GetByProductId (Guid productId)
        {
            IQueryable<OrderModel> productOrders = await this.Repository.FindByProductId (productId);

            return !productOrders.Any ()
                ? NotFound ()
                : Ok (this.Mapper.Map<IQueryable<OrderDto>> (productOrders));
        }

        [HttpPost]
        [ProducesResponseType (typeof(OrderDto), StatusCodes.Status201Created)]
        [ProducesResponseType (StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrderDto>> Create ([FromBody] OrderDto orderData)
        {
            OrderModel newUser = await this.Repository.Create (this.Mapper.Map<OrderModel> (orderData));

            return Created ("/", this.Mapper.Map<OrderDto> (newUser));
        }
    }
}
