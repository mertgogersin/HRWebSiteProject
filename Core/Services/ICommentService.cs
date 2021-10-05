using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> GetAllCommentsByCompanyIDAsync(Guid companyID);
        Task<IEnumerable<Comment>> GetCommentsAsync();
        Task<string> AddCommentAsync(Comment comment);
        Task<string> UpdateCommentAsync(Comment comment);
        Task DeleteCommentAsync(Guid commentID);
    }
}
