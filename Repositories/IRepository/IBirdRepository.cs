using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IBirdRepository
    {
        List<Bird> GetAllBirds();
        Bird GetBirdByID(int id);

        void AddNew(Bird bird);
        void Update(Bird bird);
    }
}
