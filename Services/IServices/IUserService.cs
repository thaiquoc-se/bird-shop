using BusinessObjects.DTOs;
using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IUserService
    {
        List<UserDTO> GetAllUsers();

        UserDTO GetUserDTOById(int id);
        TblUser GetUserByEmail(string email);
        TblUser GetUserByID(int id);

        void AddNew(TblUser user);

        void Update(TblUser user);

        void Delete(int id);

        TblUser checkLogin(string userName, string password);
    }
}
