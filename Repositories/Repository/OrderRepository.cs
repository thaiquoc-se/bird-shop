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
    public class OrderRepository : IOrderRepository
    {
        public void AddNewOrder(TblOrder order) => OrderDAO.Instance.AddNewOrder(order);
        

        public List<TblOrder> GetAllOrders() => OrderDAO.Instance.GetAllOrders();
        
    }
}
