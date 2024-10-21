using BusinessObjects.Models;
using DataAccessObjects;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class CommentRepository : ICommentRepository
    {
        public void AddNew(TblComment comment) => CommentDAO.Instance.AddNew(comment);

        public void Delete(int id) => CommentDAO.Instance.Delete(id);
        
        public List<TblComment> GetAllCommnets() => CommentDAO.Instance.GetAllComments();
       
    }
}
