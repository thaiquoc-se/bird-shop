using BusinessObjects.DTOs;
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
    public class UserRepository : IUserRepository
    {
        public void AddNew(TblUser user) => UserDAO.Instance.AddNew(user);

        public TblUser checkLogin(string userName, string password) => UserDAO.Instance.checkLogin(userName, password);
        

        public void Delete(int id) => UserDAO.Instance.Delete(id);
        

        public List<UserDTO> GetAllUsers() => UserDAO.Instance.GetAllUsers();

        public TblUser GetUserByEmail(string email) => UserDAO.Instance.GetUserByEmail(email);
        

        public TblUser GetUserByID(int id) => UserDAO.Instance.GetUserByID(id);
        

        public UserDTO GetUserDTOById(int id) => UserDAO.Instance.GetUserDTOByID(id);


        public void Update(TblUser user) => UserDAO.Instance.Update(user);
        
    }
}
