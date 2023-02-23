using Business.Abstract;
using Entities.Dtos.Concrete.RentedBookDtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Helpers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = AppConstants.User)]
    public class RentedBookController : ControllerBase
    {
        private readonly IRentedBookService _rentedBookService;
        public RentedBookController(IRentedBookService rentedBookService)
        {
            _rentedBookService = rentedBookService;
        }

        [HttpPost("rent")]
        public IActionResult Rent([FromBody] RentedBookRentDto rentedBookRentDto)
        {
            var result = _rentedBookService.Rent(rentedBookRentDto);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("delivery")]
        public IActionResult Delivery([FromBody] RentedBookDeliveryDto rentedBookDeliveryDto)
        {
            var result = _rentedBookService.Delivery(rentedBookDeliveryDto);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}
