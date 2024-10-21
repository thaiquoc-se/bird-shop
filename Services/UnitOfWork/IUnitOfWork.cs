using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UnitOfWork
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        void Update<T>(T entity) where T : class;
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BirdFarmShopContext _context;
        public UnitOfWork()
        {
            _context = new BirdFarmShopContext();
        }

        public void SaveChanges() => _context.SaveChanges();
        public void Update<T>(T entity) where T : class
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
