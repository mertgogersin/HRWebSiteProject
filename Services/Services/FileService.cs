using Core.Entities;
using Core.Services;
using Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class FileService : IFileService
    {
        private readonly IUnitOfWork unitOfWork;
        public FileService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> AddFileAsync(File file)
        {
            string error = null;
            try
            {
                await unitOfWork.Files.AddAsync(file);
                await unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                error = "File couldn't be added ";
            }

            return error;
        }

        public async Task DeleteFileAsync(Guid fileID)
        {
            File fileToDelete = await unitOfWork.Files.GetByIdAsync(fileID);
            fileToDelete.IsActive = false;
            unitOfWork.Files.Delete(fileToDelete);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<File>> GetAllActiveFilesByUserIDAsync(Guid userID)
        {
            List<File> files = (List<File>)await GetAllFilesByUserIDAsync(userID);
            return files.Where(m => m.IsActive);
        }

        public async Task<IEnumerable<File>> GetAllFilesByUserIDAsync(Guid userID)
        {
            return await Task.FromResult(unitOfWork.Files.List(m => m.UserID == userID));
        }

        public async Task<FileType> GetFileTypeByFileIDAsync(Guid fileTypeID)
        {
            return await unitOfWork.Files.GetFileTypeByIDAsync(fileTypeID); 
        }

        public async Task<string> UpdateFileAsync(File file)
        {
            string error = null;
            try
            {
                unitOfWork.Files.Update(file);
                await unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                error = "File couldn't be updated";
            }
            return error;
        }
    }
}
