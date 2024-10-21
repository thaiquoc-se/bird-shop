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
    public class WardService : IWardService
    {
        private readonly IWardRepository _wardRepository;
        public WardService(IWardRepository wardRepository) 
        {
            _wardRepository = wardRepository;
        }

        public List<TblWard> GetWards() => _wardRepository.GetWards();  
        
    }
}
