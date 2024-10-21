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
    public class BirdService : IBirdService
    {
        private readonly IBirdRepository _birdRepository;
        public BirdService(IBirdRepository birdRepository)
        {
            _birdRepository = birdRepository;
        }

        public Bird GetBirdByID(int id) => _birdRepository.GetBirdByID(id);
        

        public List<Bird> GetAllBirds() => _birdRepository.GetAllBirds();

        public void AddNew(Bird bird) => _birdRepository.AddNew(bird);
        

        public void Update(Bird bird) => _birdRepository.Update(bird);
        
    }
}
