using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Shared.Services.Abstract
{
    public interface ICommentService
    {
        Task<int> CountAsync();
        Task<int> CountByActiveAsync();
    }
}
