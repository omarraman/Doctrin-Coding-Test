using System.Threading.Tasks;
using AutoMapper;
using Doctrin.Api.Resources;
using Doctrin.Api.Validators;
using Doctrin.Core.Entities;
using Doctrin.Core.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Doctrin.Api.Controllers
{
	[Route("api/organisations/{unitId}/setting")]
	public class SettingsController  : ControllerBase
    {
        private readonly ISettingService _settingService;
        private readonly IUnitService _unitService;
        private readonly IMapper _mapper;

        public SettingsController(ISettingService settingService,IUnitService unitService, IMapper mapper)
        {
            _settingService = settingService;
            _unitService = unitService;
            _mapper = mapper;
        }


        #region testregion

        

        #endregion
        [HttpGet("{globalId}", Name = "GetSetting")]
        public async Task<ActionResult<SettingResource>> Get(int unitId, string globalId)
        {
            if (unitId < 1 || string.IsNullOrWhiteSpace(globalId))
            {
                return BadRequest();
            }

            var setting = await _settingService.GetSettingByUnitAsync(unitId, globalId);

            if (setting == null)
            {
                return NotFound();
            }
            var settingResource = _mapper.Map<Setting, SettingResource>(setting);

            return Ok(settingResource);
        }

        [HttpPost()]
        public async Task<ActionResult<SettingResource>> Post(int unitId, SaveSettingResource saveSettingResource)
        {
            if (unitId < 1 )
            {
                return BadRequest();
            }

            var unit = await _unitService.GetAsync(unitId);
            if (unit == null)
            {
                return NotFound();
            }
            var validator = new SaveSettingResourceValidator();
            var validationResult = await validator.ValidateAsync(saveSettingResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var settingToCreate = _mapper.Map<SaveSettingResource, Setting>(saveSettingResource);

            var newSetting = await _settingService.AddAsync(unitId, settingToCreate);

            var settingResource = _mapper.Map<Setting, SettingResource>(newSetting);

            return CreatedAtRoute("GetSetting", new { unitId = newSetting.UnitId, globalId = settingResource.GlobalId }, settingResource);
        }


        [HttpDelete("{globalId}")]
        public async Task<IActionResult> Delete(int unitId, string globalId)
        {
            if (unitId < 1 || string.IsNullOrWhiteSpace(globalId))
            {
                return BadRequest();
            }

            var setting = await _settingService.GetSettingByUnitAsync(unitId, globalId);

            if (setting == null)
                return NotFound();

            await _settingService.DeleteAsync(setting);

            return NoContent();
        }

        [HttpPatch]
        public async Task<ActionResult<SettingResource>> Patch(int unitId, string globalId, [FromBody] JsonPatchDocument<SaveSettingResource> patchDocument)
        {
            if (unitId <1 || string.IsNullOrWhiteSpace(globalId) || patchDocument==null)
            {
                return BadRequest();
            }

            var unit = await _unitService.GetAsync(unitId);
            if (unit == null)
            {
                return NotFound();
            }

            var settingToPatchFromRepository = await _settingService.GetSettingByUnitAsync(unitId, globalId);
            if (settingToPatchFromRepository == null)
            {
                return NotFound();
            }

            var settingToPatchResource = _mapper.Map<SaveSettingResource>(settingToPatchFromRepository);

            patchDocument.ApplyTo(settingToPatchResource);

            var settingToPatchFrom = _mapper.Map<Setting>(settingToPatchResource);

            await _settingService.UpdateAsync(settingToPatchFromRepository, settingToPatchFrom);

            return Ok(settingToPatchResource);
        }

    }
}
