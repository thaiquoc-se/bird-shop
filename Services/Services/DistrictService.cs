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
    public class DistrictService : IDistrictService
    {
        private readonly IDistrictRepository _districtRepository;
        public DistrictService(IDistrictRepository districtRepository) 
        {
            _districtRepository = districtRepository;
        }
        public List<TblDistrict> GetDistricts() => _districtRepository.GetDistricts();
        
    }
}
