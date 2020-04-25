using System.Threading.Tasks;
using AutoMapper;
using Doctrin.Api.Resources;
using Doctrin.Api.Validators;
using Doctrin.Core.Entities;
using Doctrin.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Doctrin.Api.Controllers
{
	[Route("api/[controller]")]
	public class OrganisationsController  : ControllerBase
    {

        private readonly IUnitService _unitService;
        private readonly IMapper _mapper;
        
        public OrganisationsController(IUnitService unitService, IMapper mapper)
        {
            _unitService = unitService;
            _mapper = mapper;
        }


        [HttpGet("{id}", Name= "GetUnit")]
        public async Task<ActionResult<UnitResource>> Get(int id)
        {
            if (id<1)
            {
                return BadRequest();
            }
            var unit = await _unitService.GetAsync(id);

            if (unit==null)
            {
                return NotFound();
            }
            var unitResource = _mapper.Map<Unit,UnitResource>(unit);

            return Ok(unitResource);
        }

        [HttpPost()]
        public async Task<ActionResult<UnitResource>> Post([FromBody] SaveUnitResource saveUnitResource)
        {
            var validator = new SaveUnitResourceValidator();
            var validationResult = await validator.ValidateAsync(saveUnitResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); 

            var unitToCreate = _mapper.Map<SaveUnitResource, Unit>(saveUnitResource);

            var newUnit = await _unitService.AddAsync(unitToCreate);

            var unit = await _unitService.GetAsync(newUnit.Id);

            var unitResource = _mapper.Map<Unit, UnitResource>(unit);

            return CreatedAtRoute("GetUnit",new {id =unit.Id}, unitResource);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return BadRequest();

            var unit = await _unitService.GetAsync(id);

            if (unit == null)
                return NotFound();

            await _unitService.DeleteAsync(unit);

            return NoContent();
        }
    }
}
