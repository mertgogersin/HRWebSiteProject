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
    public class CommentRepository : Repository<Comment>,ICommentRepository
    {
        public CommentRepository(HRContext context): base(context)
        {

        }
        private HRContext Context
        {
            get { return context; }
        }

        public async Task<IEnumerable<Comment>> GetCommentsByCompanyIDAsync(Guid companyID)
        {
            List<Guid> commentsID = await Context.Comments.Where(x => x.CompanyID == companyID).Select(x => x.CommentID).ToListAsync();
            List<Comment> comments = new List<Comment>();
            foreach (Guid item in commentsID)
            {
                comments.Add(Context.Comments.Where(x => x.CompanyID == item).FirstOrDefault());
            }
            return comments;
        }
    }
}
