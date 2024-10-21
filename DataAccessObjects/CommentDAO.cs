using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class CommentDAO
    {
        private static CommentDAO instance = null!;

        private static readonly object instanceLock = new object();

        private readonly BirdFarmShopContext _context;

        public CommentDAO()
        {
            _context = new BirdFarmShopContext();
        }

        public static CommentDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CommentDAO();
                    }
                    return instance;
                }
            }
        }

        public List<TblComment> GetAllComments()
        {
            try
            {
                return _context.TblComments.Include(c => c.Bird).Include(c => c.User).ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddNew(TblComment comment)
        {
            try
            {
                _context.TblComments.Add(comment);
                _context.SaveChanges();
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var comment = _context.TblComments.Where(c => c.CommentId == id).FirstOrDefault();
                if (comment != null)
                {
                    _context.TblComments.Remove(comment);
                    _context.SaveChanges();
                }              
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
