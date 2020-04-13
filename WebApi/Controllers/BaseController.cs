using BusinessLogic.Services.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly IMapper Mapper;

        public BaseController(
            IMapper mapper)
        {
            Mapper = mapper;
        }

        protected IActionResult ProcessOperationResult<T>(OperationResult<T> operationResult)
        {
            if (!operationResult.Success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, operationResult.GetErrors());
            }
            return Ok(operationResult.Result);
        }
    }
}
