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
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        public OrderDetailService(IOrderDetailRepository orderDetailRepository) 
        {
            _orderDetailRepository = orderDetailRepository;
        }
        public void AddNewOrderDetail(TblOrderDetail orderDetail) => _orderDetailRepository.AddNewOrderDetail(orderDetail);
        

        public List<TblOrderDetail> GetOrderDetailByID(int id) => _orderDetailRepository.GetOrderDetailByID(id);
        
    }
}
