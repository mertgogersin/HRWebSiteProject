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
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork unitOfWork;

        public CommentService(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }

        public async Task<string> AddCommentAsync(Comment comment)
        {
            string error = null;
            try
            {
                await unitOfWork.Comments.AddAsync(comment);
                await unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                error = "Comment couldn't be added!";
            }
            return error;
        }

        public async Task DeleteCommentAsync(Guid commentID)
        {
            Comment commentToDelete = await unitOfWork.Comments.GetByIdAsync(commentID);
            unitOfWork.Comments.Delete(commentToDelete);
            await unitOfWork.CommitAsync();

        }

        public Comment GetCommentByCompanyIDAsync(Guid companyID)
        {
            return unitOfWork.Comments.List(x => x.CompanyID == companyID).FirstOrDefault();
        }

        public async Task<Comment> GetCommentByIDAsync(Guid commentID)
        {
            return await unitOfWork.Comments.GetByIdAsync(commentID);
        }

        public async Task<IEnumerable<Comment>> GetCommentsAsync()
        {
            return await unitOfWork.Comments.GetAllAsync();
        }

        public List<Comment> GetCompany(Guid companyID)
        {
            List<Comment> comments = unitOfWork.Comments.List(x => x.CompanyID == companyID && x.Content != null).ToList();
            return comments;
        }

        public async Task<string> UpdateCommentAsync(Comment comment)
        {
            string error = null;
            try
            {
                unitOfWork.Comments.Update(comment);
                await unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                error = "Comment couldn't be update!";
            }
            return error;
        }
    }
}
