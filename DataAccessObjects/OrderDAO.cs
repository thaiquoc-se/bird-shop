using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class OrderDAO
    {
        private static OrderDAO instance = null!;

        private static readonly object instanceLock = new object();
        private readonly BirdFarmShopContext _context;

        public OrderDAO()
        {
            _context = new BirdFarmShopContext();
        }

        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }

        public List<TblOrder> GetAllOrders()
        {
            try
            {
                return _context.TblOrders.Include(o => o.User).OrderByDescending(b => b.StartDate).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddNewOrder(TblOrder order)
        {
            try
            {
                _context.TblOrders.Add(order);
                _context.SaveChanges();
            }catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner exception: " + ex.InnerException.Message);
                }
                else
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }
            }
        }
    }
}
