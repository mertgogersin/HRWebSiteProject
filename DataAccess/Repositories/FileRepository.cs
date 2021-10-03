using Core.Entities;
using Core.Repositories;
using DataAccess.Context;
using DataAccess.Repositories.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class FileRepository : Repository<File>, IFileRepository
    {
        public FileRepository(HRContext context) : base(context)
        {

        }
        private HRContext Context
        {
            get { return context; }
        }

        public async Task<FileType> GetFileTypeByIDAsync(Guid fileTypeID)
        {
            return await Context.FileTypes.Where(m => m.FileTypeID == fileTypeID).FirstOrDefaultAsync();
        }
    }
}
