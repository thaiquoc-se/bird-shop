using BusinessObjects.Models;
using Repositories.IRepository;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public void AddNew(TblComment comment) => _commentRepository.AddNew(comment);

        public void Delete(int id) => _commentRepository.Delete(id);
        

        public List<TblComment> GetAllCommnets() => _commentRepository.GetAllCommnets();
        
    }
}
