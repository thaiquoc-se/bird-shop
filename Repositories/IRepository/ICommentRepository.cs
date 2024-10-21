using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface ICommentRepository
    {
        List<TblComment> GetAllCommnets();
        void AddNew(TblComment comment);

        void Delete(int id);
    }
}
