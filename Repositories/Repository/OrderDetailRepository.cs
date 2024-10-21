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
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public void AddNewOrderDetail(TblOrderDetail orderDetail) => OrderDetailDAO.Instance.AddNewOrderDetail(orderDetail);
        
        public List<TblOrderDetail> GetOrderDetailByID(int id) => OrderDetailDAO.Instance.GetOrderDetailByID(id);
        
    }
}
