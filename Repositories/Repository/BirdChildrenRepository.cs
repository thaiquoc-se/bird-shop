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
    public class BirdChildrenRepository : IBirdChildrenRepository
    {
        public List<Tblchildrenbird> GetAllBirdChildren() => BirdChildrenDAO.Instance.GetAllBirdChildren();

        public Tblchildrenbird GetBirdChildrenByID(int id) => BirdChildrenDAO.Instance.GetBirdChildrenByID(id);
        public void AddNew(Tblchildrenbird tblchildrenbird) => BirdChildrenDAO.Instance.AddNew(tblchildrenbird);
        public void Update(Tblchildrenbird tblchildrenbird) => BirdChildrenDAO.Instance.Update(tblchildrenbird);

    }
}
