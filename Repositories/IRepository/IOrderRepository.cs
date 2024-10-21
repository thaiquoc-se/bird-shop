using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IOrderRepository
    {
        List<TblOrder> GetAllOrders();
        void AddNewOrder(TblOrder order);
    }
}
