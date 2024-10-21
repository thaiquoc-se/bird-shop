using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IBirdChildrenService
    {
        List<Tblchildrenbird> GetAllBirdChildren();
        Tblchildrenbird GetBirdChildrenByID(int id);
        void AddNew(Tblchildrenbird tblchildrenbird);
        void Update(Tblchildrenbird tblchildrenbird);
    }
}
