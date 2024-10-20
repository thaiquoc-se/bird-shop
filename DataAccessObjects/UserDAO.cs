using BusinessObjects.DTOs;
using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class UserDAO
    {
        private static UserDAO instance = null!;

        private static readonly object instanceLock = new object();
        private readonly BirdFarmShopContext _context;

        public UserDAO()
        {
            _context = new BirdFarmShopContext();
        }

        public static UserDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new UserDAO();
                    }
                    return instance;
                }
            }
        }
        public TblUser checkLogin(string userName, string password)
        {
            try
            {
                var check = _context.TblUsers.Where(u => u.UserName!.Equals(userName) && u.Pass!.Equals(password)).FirstOrDefault();

                if (check != null)
                {
                    return check;
                }
                throw new Exception();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<UserDTO> GetAllUsers()
        {
            var users = _context.TblUsers
                .Include(t => t.District)
                .Include(t => t.Role)
                .Include(t => t.Ward).ToList();

            List<UserDTO> userList = new List<UserDTO>();
            foreach (var user in users)
            {
                var _user = new UserDTO()
                {
                    UserId = user.UserId,
                    UserName = user.UserName,
                    UserAddress = user.UserAddress + ", " + user.Ward!.WardName + ", " + user.District!.DistrictName,
                    FullName = user.FullName,
                    UserStatus = user.UserStatus,
                    RoleId = user.RoleId,
                    image = user.image,
                    RoleName = user.Role.RoleName!,
                    Pass = user.Pass,
                    Email = user.Email,
                    Phone = user.Phone,
                };

                userList.Add(_user);
            }

            return userList;
        }
        public TblUser GetUserByEmail(string email)
        {
            try
            {
                return _context.TblUsers.Where(u => u.Email.Equals(email)).SingleOrDefault()!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public UserDTO GetUserDTOByID(int id)
        {
            try
            {
                return GetAllUsers().Where(u => u.UserId.Equals(id)).FirstOrDefault()!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public TblUser GetUserByID(int id)
        {
            try
            {
                return _context.TblUsers
                .Include(t => t.District)
                .Include(t => t.Role)
                .Include(t => t.Ward).FirstOrDefault()!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AddNew(TblUser user)
        {
            try
            {  
                _context.TblUsers.Add(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(TblUser user)
        {
            _context.Attach(user).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblUserExists(user.UserId))
                {
                    throw new Exception("User not exist");
                }
                throw;
            }
        }
        public void Delete(int id)
        {
            try
            {
                var check = TblUserExists(id);
                if (check)
                {
                    _context.Remove(check);
                    _context.SaveChanges();
                }
                throw new Exception("User not exist");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        private bool TblUserExists(int id)
        {
            return (_context.TblUsers?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
