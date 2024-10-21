using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IOrderDetailRepository
    {
        List<TblOrderDetail> GetOrderDetailByID(int id);

        void AddNewOrderDetail(TblOrderDetail orderDetail);
    }
}
