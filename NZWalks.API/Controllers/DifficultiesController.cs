using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //if you will apply versioning
    //[Route("api/v{version:apiVersion}/[controller]")]
    //[ApiVersion("1.0")]
    //[ApiVersion("2.0")]
    public class DifficultiesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IDifficultyRepository difficultyRepository;

        public DifficultiesController(IMapper mapper, IDifficultyRepository difficultyRepository)
        {
            this.mapper = mapper;
            this.difficultyRepository = difficultyRepository;
        }
        //[MapToApiVersion("1.0")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var difficultiesDomain = await difficultyRepository.GetAllAsync();
            var difficultiesDto = mapper.Map<List<DifficultyDto>>(difficultiesDomain);
            return Ok(difficultiesDto);
        }

        //[MapToApiVersion("2.0")]
        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var difficultiesDomain = await difficultyRepository.GetAllAsync();
        //    var difficultiesDto = mapper.Map<List<DifficultyDto>>(difficultiesDomain);
        //    return Ok(difficultiesDto);
        //}
    }
}
