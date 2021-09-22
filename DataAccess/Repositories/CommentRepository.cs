using Core.Entities;
using Core.Repositories;
using DataAccess.Context;
using DataAccess.Repositories.Generics;
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
    }
}
