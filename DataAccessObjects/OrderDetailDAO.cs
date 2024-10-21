using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class OrderDetailDAO 
    {
        private static OrderDetailDAO instance = null!;

        private static readonly object instanceLock = new object();
        private readonly BirdFarmShopContext _context;

        public OrderDetailDAO()
        {
            _context = new BirdFarmShopContext();
        }

        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                    return instance;
                }
            }
        }

        public List<TblOrderDetail> GetOrderDetailByID(int id)
        {
            try
            {
                return _context.TblOrderDetails
                .Include(t => t.Bird)
                .Include(t => t.Order).Where(t => t.OrderId == id).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddNewOrderDetail(TblOrderDetail orderDetail)
        {
            try
            {
                _context.TblOrderDetails.Add(orderDetail);
                _context.SaveChanges(); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
