using AutoMapper;
using Core.Entities;
using Core.Services;
using Core.UnitOfWork;
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
    public class FileController : ControllerBase
    {
        private readonly IFileService fileService;
        private readonly IMapper mapper;
        public FileController(IUnitOfWork unitofWork, IFileService fileService, IMapper mapper)
        {
            this.mapper = mapper;
            this.fileService = fileService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFilesByUserID(Guid id)
        {
            List<File> files = (List<File>)await fileService.GetAllActiveFilesByUserIDAsync(id);
            List<GetFileDTO> getFileDTOs = mapper.Map<List<File>, List<GetFileDTO>>(files);
            return Ok(getFileDTOs);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFileByFileID(Guid id)
        {
            File file = await fileService.GetFileByFileIDAsync(id);
            GetFileDTO getFileDTO = mapper.Map<File, GetFileDTO>(file);
            return Ok(getFileDTO);
        }
        [HttpGet]
        public async Task<IActionResult> GetFileTypes()
        {
            List<FileType> fileTypes = (List<FileType>)await fileService.GetFileTypesAsync();
            List<FileTypeDTO> fileTypeDTOs = mapper.Map<List<FileType>, List<FileTypeDTO>>(fileTypes);
            return Ok(fileTypeDTOs);
        }
        [HttpPost]
        public async Task<IActionResult> AddFile(SaveFileDTO saveFileDTO)
        {
            if (ModelState.IsValid)
            {
                File file = mapper.Map<SaveFileDTO, File>(saveFileDTO);
                string error = await fileService.AddFileAsync(file);
                if (error != null) { return BadRequest(error); }
                return Ok("File successfully added!");
            }
            return BadRequest(ModelState.Values.SelectMany(x => x.Errors).ToList());
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFile(Guid id)
        {
            await fileService.DeleteFileAsync(id);
            return Ok("File is successfully deleted!");
        }
    }
}
