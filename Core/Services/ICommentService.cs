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
        Comment GetCommentByCompanyIDAsync(Guid companyID);
        Task<IEnumerable<Comment>> GetCommentsAsync();
        List<Comment> GetCompany(Guid companyID);
        Task<Comment> GetCommentByIDAsync(Guid commentID);
        Task<string> AddCommentAsync(Comment comment);
        Task<string> UpdateCommentAsync(Comment comment);
        Task DeleteCommentAsync(Guid commentID);
    }
}
