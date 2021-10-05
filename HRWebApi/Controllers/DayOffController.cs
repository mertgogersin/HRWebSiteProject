using AutoMapper;
using Core.Entities;
using Core.Services;
using HRWebApi.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DayOffController : ControllerBase
    {
        private readonly IDayOffService dayOffService;
        private IMapper mapper;

        public DayOffController(IDayOffService _dayOffService, IMapper _mapper)
        {
            this.dayOffService = _dayOffService;
            this.mapper = _mapper;
        }
        [HttpPost]
        public async Task<IActionResult> AddDayOffTypeName(DayOffDTO dayOffDTO)
        {
            if (ModelState.IsValid)
            {
                var dayOffTypeToCreate = mapper.Map<DayOffDTO, DayOffType>(dayOffDTO);
                DayOffType dayOffType = new DayOffType()
                {
                    DayOffTypeID = Guid.NewGuid(),
                    TypeName = dayOffDTO.TypeName,
                    Description = dayOffDTO.Description
                };
                await dayOffService.CreateDayOffTypeAsync(dayOffType);
                var newDayOff = await dayOffService.CreateDayOffTypeAsync(dayOffTypeToCreate);
            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors).ToList());
        }
        [HttpPost]
        public async Task<IActionResult> AddDayOff(DayOffDTO dayOffDTO)
        {
            if (ModelState.IsValid)
            {
                DayOff dayOff = mapper.Map<DayOffDTO, DayOff>(dayOffDTO);
                string error = await dayOffService.AddDayOffAsync(dayOff);
                if (error != null)
                    return BadRequest(error);
                return Ok("Off day successfully added.");
            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors).ToList());
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDayOffInfo(DayOffDTO dayOffDTO)
        {
            if (ModelState.IsValid)
            {
                DayOff dayOffToBeUpdated = await dayOffService.GetDayOffByIDAsync(dayOffDTO.DayOffID);
                DayOff dayOff = mapper.Map(dayOffDTO, dayOffToBeUpdated);
                string error = await dayOffService.UpdateDayOffAsync(dayOff);
                if (error != null) { return BadRequest(error); }
                return Ok("Off day successfully updated.");
            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors).ToList());
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDayOff(Guid id)
        {
            await dayOffService.DeleteDayOffAsync(id);
            return Ok("Off day is successfully deleted.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDayOffByUserIDAsync(Guid id)
        {
            List<DayOff> dayOffs = (List<DayOff>)await dayOffService.GetAllDayOffsByUserIDAsync(id);
            List<DayOffDTO> dayOffDTOs = mapper.Map<List<DayOff>, List<DayOffDTO>>(dayOffs);
            return Ok(dayOffDTOs);
        }
    }
}
