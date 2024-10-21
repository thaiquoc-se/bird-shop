using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class BirdChildrenDAO
    {
        private static BirdChildrenDAO instance = null!;

        private static readonly object instanceLock = new object();

        private readonly BirdFarmShopContext _context;

        public BirdChildrenDAO()
        {
            _context = new BirdFarmShopContext();
        }

        public static BirdChildrenDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BirdChildrenDAO();
                    }
                    return instance;
                }
            }
        }

        public List<Tblchildrenbird> GetAllBirdChildren()
        {
            try
            {
                return _context.Tblchildrenbirds.Include(b => b.Bird).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Tblchildrenbird GetBirdChildrenByID(int id)
        {
            try
            {
                return _context.Tblchildrenbirds.Where(b => b.ChildrenBirdId == id).SingleOrDefault()!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddNew(Tblchildrenbird tblchildrenbird)
        {
            try
            {
                _context.Tblchildrenbirds.Add(tblchildrenbird);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Tblchildrenbird tblchildrenbird)
        {
            try
            {
                var _birdchildren = _context.Tblchildrenbirds.Where(b => b.BirdId == tblchildrenbird.ChildrenBirdId).SingleOrDefault();
                if (_birdchildren != null)
                {
                    _birdchildren.BirdId = tblchildrenbird.BirdId;
                    _birdchildren.ChildrenBirdId = tblchildrenbird.ChildrenBirdId;
                    _birdchildren.ChildrenBirdName = tblchildrenbird.ChildrenBirdName;
                    _birdchildren.ChildrenBirdOfType = tblchildrenbird.ChildrenBirdOfType;
                    _birdchildren.Price = tblchildrenbird.Price;
                    _birdchildren.StatusChildrenBird = tblchildrenbird.StatusChildrenBird;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
