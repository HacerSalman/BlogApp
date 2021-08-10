using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlogApp.Shared.Repositories.Abstract;
using BlogApp.Data.Entities;

namespace BlogApp.Shared.Repositories.Concrete
{
    public class CommentRepository:BaseRepository<Comment>,ICommentRepository
    {
        public CommentRepository(DbContext context) : base(context)
        {
        }
    }
}
