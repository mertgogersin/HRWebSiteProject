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
    public class DebitController : ControllerBase
    {
        private readonly IDebitService debitService;
        private readonly IMapper mapper;

        public DebitController(IDebitService debitService, IMapper mapper)
        {
            this.debitService = debitService;
            this.mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDebitsByUserIDAsync(Guid id)
        {
            List<Debit> debits = (List<Debit>)await debitService.GetAllDebitsByUserIDAsync(id);
            List<DebitDTO> debitDTOs = mapper.Map<List<Debit>, List<DebitDTO>>(debits);
            return Ok(debitDTOs);
        }
        [HttpPost]
        public async Task<IActionResult> AddDebit(DebitDTO debitDTO)
        {
            if (ModelState.IsValid)
            {
                Debit debit = mapper.Map<DebitDTO, Debit>(debitDTO);
                string error = await debitService.AddDebitAsync(debit);
                if(error != null) { return BadRequest(error); }
                return Ok("Debit successfully added!");
            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors).ToList());
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDebitInfo(DebitDTO debitDTO)
        {
            if (ModelState.IsValid)
            {
                Debit debitToBeUpdated = await debitService.GetDebitByIDAsync(debitDTO.DebitID);
                Debit debit = mapper.Map(debitDTO,debitToBeUpdated);
                string error = await debitService.UpdateDebitAsync(debit);
                if (error != null) { return BadRequest(error); }
                return Ok("Debit successfully updated!");
            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors).ToList());
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDebit(Guid id)
        {
            await debitService.DeleteDebitAsync(id);
            return Ok("Debit is successfully deleted!");
        }
    }
}
