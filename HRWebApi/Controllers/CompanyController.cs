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
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService companyService;
        private readonly IMapper mapper;

        public CompanyController(ICompanyService _companyService, IMapper _mapper)
        {
            this.companyService = _companyService;
            this.mapper = _mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCompanies()
        {
            IEnumerable<Company> companies = await companyService.GetCompaniesAsync();
            IEnumerable<CompanySaveDTO> companyDTOs = mapper.Map<IEnumerable<Company>, IEnumerable<CompanySaveDTO>>(companies);
            return Ok(companyDTOs);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCompanyInfo(CompanySaveDTO companySaveDTO)
        {
            if (ModelState.IsValid)
            {
                Company companyToBeUpdated = companyService.GetCompanyByID(companySaveDTO.CompanyID);
                Company company = mapper.Map(companySaveDTO,companyToBeUpdated);
                await companyService.UpdateCompanyAsync(company);
                                
                return Ok("Company is successfully updated!");
            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors).ToList());
        }
    }
}
