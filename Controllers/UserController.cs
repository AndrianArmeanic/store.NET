using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreApplication.Dtos.User;
using StoreApplication.Models;
using StoreApplication.Repos.User;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace StoreApplication.Controllers
{
    [Route ("users")]
    public class UserController : ApiController<IUserRepo>
    {
        private readonly UserManager<UserModel> userManager;

        private readonly SignInManager<UserModel> signInManager;

        public UserController (IMapper mapper, IUserRepo repository, UserManager<UserModel> userManager,
            SignInManager<UserModel> signInManager) : base (mapper, repository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType (typeof(IQueryable<UserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IQueryable<UserDto>>> Get ()
        {
            IQueryable<UserModel> users = await this.Repository.FindAll ();

            return !users.Any ()
                ? NotFound ()
                : Ok (this.Mapper.Map<IQueryable<UserDto>> (users));
        }

        [HttpGet ("{id:guid}")]
        [Authorize]
        [ProducesResponseType (typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDto>> GetById (Guid id)
        {
            UserModel? user = await this.Repository.FindById (id);

            return user is null
                ? NotFound ()
                : Ok (this.Mapper.Map<UserDto> (user));
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType (typeof(UserDto), StatusCodes.Status201Created)]
        [ProducesResponseType (StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> Create ([FromBody] UserDto userData)
        {
            UserModel? user = await this.Repository.FindByEmail (userData.Email);

            if (user is null)
            {
                return BadRequest ("Email already exists!");
            }

            UserModel newUser = await this.Repository.Create (this.Mapper.Map<UserModel> (userData));

            return Created ("/", this.Mapper.Map<UserDto> (newUser));
        }

        [HttpPut ("{id:guid}")]
        [Authorize]
        [ProducesResponseType (typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDto>> Update (Guid id, [FromBody] UserDto userData)
        {
            UserModel updatedUser = await this.Repository.Update (id, this.Mapper.Map<UserModel> (userData));

            return Ok (this.Mapper.Map<UserDto> (updatedUser));
        }

        [HttpDelete ("{id:guid}")]
        [Authorize]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete (Guid id)
        {
            await this.Repository.DeleteById (id);

            return NoContent ();
        }

        [HttpPost ("login")]
        [AllowAnonymous]
        [ProducesResponseType (typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<string>> Login ([FromBody] LoginDto loginDto)
        {
            UserModel user = await this.userManager.FindByNameAsync (loginDto.Username);
            if (user is null)
            {
                return Unauthorized ("Wrong credentials!");
            }
            SignInResult signInResult = await this.signInManager.PasswordSignInAsync (user, loginDto.Password, true, false);
            if (signInResult.Succeeded)
            {
                return Ok ("Success login!");
            }
            return Unauthorized ("Wrong credentials!");
        }
        
        [HttpPost ("logout")]
        [Authorize]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();
            return NoContent ();
        }
    }
};
