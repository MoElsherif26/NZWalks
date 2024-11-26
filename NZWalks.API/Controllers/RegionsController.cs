using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;
using System.Data;
using System.Text.Json;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;
        private readonly ILogger<RegionsController> logger;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper,
            ILogger<RegionsController> logger)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
            this.logger = logger;
        }
        [HttpGet]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {
            //logger.LogInformation("GetAllRegions Action method was invoked");
            //logger.LogWarning("This is a warning log");
            //logger.LogError("This is an error log");

            //try
            //{
            //    throw new Exception("This is a custom exception");
            //    var regionsDomain = await regionRepository.GetAllAsync();
            //    var regionsDto = mapper.Map<List<RegionDto>>(regionsDomain);
            //    logger.LogInformation($"Finished GetAllRegions request with data: {JsonSerializer.Serialize(regionsDomain)}");
            //    return Ok(regionsDto);
            //}
            //catch (Exception ex)
            //{
            //    logger.LogError(ex, ex.Message);
            //    throw;
            //}

            var regionsDomain = await regionRepository.GetAllAsync();
            var regionsDto = mapper.Map<List<RegionDto>>(regionsDomain);
            logger.LogInformation($"Finished GetAllRegions request with data: {JsonSerializer.Serialize(regionsDomain)}");
            return Ok(regionsDto);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var regionDomain = await regionRepository.GetByIdAsync(id);
            if (regionDomain == null)
            {
                return NotFound();
            }
            var regionDto = mapper.Map<RegionDto>(regionDomain);
            return Ok(regionDto);
        }
        [HttpPost]
        [ValidateModel]
        //[Authorize(Roles = "Writer")]

        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            var regionDomain = mapper.Map<Region>(addRegionRequestDto);
            regionDomain = await regionRepository.CreateAsync(regionDomain);
            var regionDto = mapper.Map<RegionDto>(regionDomain);
            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Writer")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            var regionDomain = mapper.Map<Region>(updateRegionRequestDto);
            regionDomain = await regionRepository.UpdateAsync(id, regionDomain);
            if (regionDomain == null)
            {
                return NotFound();
            }
            var regionDto = mapper.Map<RegionDto>(regionDomain);
            return Ok(regionDto);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Writer")]
        //[Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomain = await regionRepository.DeleteAsync(id);
            if (regionDomain == null)
            {
                return NotFound();
            }
            var regionDto = mapper.Map<RegionDto>(regionDomain);
            return Ok(regionDto);
        }
    }
}