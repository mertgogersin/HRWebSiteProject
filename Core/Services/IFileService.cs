using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IFileService
    {
        Task<IEnumerable<File>> GetAllActiveFilesByUserIDAsync(Guid userID);
        Task<IEnumerable<File>> GetAllFilesByUserIDAsync(Guid userID);
        Task<FileType> GetFileTypeByFileIDAsync(Guid fileTypeID);
        Task<string> AddFileAsync(File file);
        Task<string> UpdateFileAsync(File file);
        Task DeleteFileAsync(Guid fileID);
    }
}
