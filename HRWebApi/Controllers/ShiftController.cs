using AutoMapper;
using Core.Entities;
using Core.Model.Authentication;
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
    public class ShiftController : ControllerBase
    {
        private readonly IShiftService shiftService;
        private IMapper mapper;
        public ShiftController(IShiftService _shiftService, IMapper _mapper)
        {
            this.shiftService = _shiftService;
            this.mapper = _mapper;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActiveShiftByUser(Guid id)
        {
            List<Shift> shifts = (List<Shift>)await shiftService.GetAllActiveShiftsByUserIDAsync(id);
            List<ShiftDTO> shiftDTOs = mapper.Map<List<Shift>, List<ShiftDTO>>(shifts);
            return Ok(shiftDTOs);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllShifts()
        {
            IEnumerable<Shift> shifts = await shiftService.GetShiftsAsync();
            IEnumerable<ShiftDTO> shiftDTOs = mapper.Map<IEnumerable<Shift>, IEnumerable<ShiftDTO>>(shifts);
            return Ok(shiftDTOs);
        }
        [HttpPost]
        public async Task<IActionResult> AddShift(ShiftDTO shiftDTO)
        {
            if (ModelState.IsValid)
            {
                Shift shift = mapper.Map<ShiftDTO, Shift>(shiftDTO);
                string error = await shiftService.AddShiftAsync(shift);
                if (error != null)
                    return BadRequest(error);
                return Ok("Shift successfully added.");
            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors).ToList());
        }
        [HttpPut]
        public async Task<IActionResult> UpdateShiftInfo(ShiftDTO shiftDTO)
        {
            if (ModelState.IsValid)
            {
                Shift shiftToBeUpdated = await shiftService.GetShiftByIDAsync(shiftDTO.ShiftID);
                Shift shift = mapper.Map(shiftDTO, shiftToBeUpdated);
                string error = await shiftService.UpdateShiftAsync(shift);
                if (error != null)
                    return BadRequest(error);
                return Ok("Shift successfully updated.");
            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors).ToList());
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShift(Guid id)
        {
            await shiftService.DeleteShiftAsync(id);
            return Ok("Shift is successfully deleted.");
        }
    }
}
