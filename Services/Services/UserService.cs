    using BusinessObjects.DTOs;
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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }
        public void AddNew(TblUser user) => _userRepository.AddNew(user);
        

        public TblUser checkLogin(string userName, string password) => _userRepository.checkLogin(userName, password);
        
        public void Delete(int id) => _userRepository.Delete(id);
        
        public List<UserDTO> GetAllUsers() => _userRepository.GetAllUsers();
        
        public TblUser GetUserByEmail(string email) => _userRepository.GetUserByEmail(email);
        
        public TblUser GetUserByID(int id)  => _userRepository.GetUserByID(id);
        
        public UserDTO GetUserDTOById(int id) => _userRepository.GetUserDTOById(id);
        
        public void Update(TblUser user) => _userRepository.Update(user);
        
    }
}
