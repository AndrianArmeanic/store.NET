using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApplication.Dtos.Product;
using StoreApplication.Models;
using StoreApplication.Repos.Product;

namespace StoreApplication.Controllers
{
    [Authorize]
    [Route ("products")]
    public class ProductController : ApiController<IProductRepo>
    {
        public ProductController (IMapper mapper, IProductRepo repository) : base (mapper, repository)
        {
        }

        [HttpGet]
        [ProducesResponseType (typeof(IQueryable<ProductDto>), StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IQueryable<ProductDto>>> Get ()
        {
            IQueryable<ProductModel> products = await this.Repository.FindAll ();

            return !products.Any ()
                ? NotFound ()
                : Ok (this.Mapper.Map<IQueryable<ProductDto>> (products));
        }

        [HttpGet ("{id:guid}")]
        [ProducesResponseType (typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> GetById (Guid id)
        {
            ProductModel? product = await this.Repository.FindById (id);

            return product is null
                ? NotFound ()
                : Ok (this.Mapper.Map<ProductDto> (product));
        }

        [HttpPost]
        [ProducesResponseType (typeof(ProductDto), StatusCodes.Status201Created)]
        [ProducesResponseType (StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductDto>> Create ([FromBody] ProductDto productData)
        {
            ProductModel? product = await this.Repository.FindByName (productData.Name);

            if (product is not null)
            {
                return BadRequest ("Product name already exists!");
            }

            ProductModel newProduct =
                await this.Repository.Create (this.Mapper.Map<ProductModel> (productData));

            return Created ("/", this.Mapper.Map<ProductDto> (newProduct));
        }

        [HttpPut ("{id:guid}")]
        [ProducesResponseType (typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> Update (Guid id, [FromBody] ProductDto productData)
        {
            ProductModel updatedProduct =
                await this.Repository.Update (id, this.Mapper.Map<ProductDto, ProductModel> (productData));

            return Ok (this.Mapper.Map<ProductModel, ProductDto> (updatedProduct));
        }

        [HttpDelete ("{id:guid}")]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete (Guid id)
        {
            await this.Repository.DeleteById (id);

            return NoContent ();
        }
    }
}
