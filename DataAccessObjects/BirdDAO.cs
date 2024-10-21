using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class BirdDAO
    {
        private static BirdDAO instance = null!;

        private static readonly object instanceLock = new object();

        private readonly BirdFarmShopContext _context;

        public BirdDAO()
        {
            _context = new BirdFarmShopContext();
        }

        public static BirdDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BirdDAO();
                    }
                    return instance;
                }
            }
        }

        public List<Bird> GetAllBirds()
        {
            try
            {
                return _context.Birds.Include(b => b.User).ToList();
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Bird GetBirdByID(int id)
        {
            try
            {
                return _context.Birds.Where(b => b.BirdId == id).SingleOrDefault()!;
            }catch (Exception ex)
            {
            throw new Exception(ex.Message);
            }
        }

        public void AddNew(Bird bird)
        {
            try
            {
                _context.Birds.Add(bird);
                _context.SaveChanges(); 
            }catch  (Exception ex)
            {
                    throw new Exception(ex.Message);
            }
        }

        public void Update(Bird bird)
        {
            try
            {
                var _bird = _context.Birds.Where(b => b.BirdId == bird.BirdId).SingleOrDefault();
                if (_bird != null)
                {
                    _bird.BirdId = bird.BirdId;
                    _bird.BirdName = bird.BirdName;
                    _bird.BirdStatus = bird.BirdStatus;
                    _bird.BirdDescription = bird.BirdDescription;
                    _bird.Price = bird.Price;
                    _bird.Quantity = bird.Quantity;
                    _bird.WeightofBirds = bird.WeightofBirds;
                    _bird.Estimation = bird.Estimation;
                    _bird.Gender = bird.Gender;
                    _bird.UserId = bird.UserId;
                    _context.SaveChanges();
                }
            }catch  (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
