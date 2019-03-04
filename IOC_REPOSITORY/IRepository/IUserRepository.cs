using IOC_DATA.Core;
using System.Collections.Generic;


namespace IOC_REPOSITORY.IRepository
{
    public interface IUserRepository
    {
        User GetById(int id);

        IEnumerable<User> GetAll();

        void Edit(User user);

        void Insert(User user);

        void Delete(User user);

        bool EmailExist(string Email);

        User Login(string Email, string Password);

        void ActiveUser(User user);

        void UpdateUserProfile(User user);

    
    }

}

