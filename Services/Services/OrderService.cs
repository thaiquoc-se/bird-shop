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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository) 
        {
            _orderRepository = orderRepository;
        
        }
        public void AddNewOrder(TblOrder order) => _orderRepository.AddNewOrder(order);
        

        public List<TblOrder> GetAllOrders() => _orderRepository.GetAllOrders();
        
    }
}
