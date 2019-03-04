using IOC.SERVICE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_SERVICE.IService
{
   public interface IUserService
    {
        UserModel GetById(int id);

        IEnumerable<UserModel> GetAll();

        void Edit(UserModel user);

        void Insert(UserModel user);

        void Delete(UserModel user);

        bool EmailExist(String Email);

        UserModel Login(string Email, string Password);

        void UpdateUserProfile(UserModel usermodel);

        void ActiveUser(UserModel usermodel);
    }
}
