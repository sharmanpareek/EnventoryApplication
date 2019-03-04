using IOC_REPOSITORY.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IOC_DATA.Infrastructure;
using IOC_DATA.Core;
using System.Data.Entity;
using IOC_DATA;

namespace IOC_REPOSITORY.Repository
{
    public class UserRepository :  IUserRepository
    {
      private  DatabaseContext db = new DatabaseContext();

        public IUnitOfWork _unitofwork;
        public UserRepository(IUnitOfWork unitofwork)  
        {
            _unitofwork = unitofwork;    
            
        }
        

        public void Delete(User user)
        {
            _unitofwork.GetRepository<User>().Delete(user);
        }

        public void Edit(User user)
        {
            _unitofwork.GetRepository<User>().Edit(user);
           
        }

        public bool EmailExist(string Email)
        {
            
        
            var exist = db.user.Where(a => a.Email == Email).FirstOrDefault();
            if (exist == null)
            {
                return false;
            }
            else
            {
                return true;
            }


        
    }

        public IEnumerable<User> GetAll()
        {
            return _unitofwork.GetRepository<User>().GetAll();
        }

        public User GetById(int id)
        {
            
            return _unitofwork.GetRepository<User>().GetById(id);
        }
       

        public void Insert(User user)
        {
            _unitofwork.GetRepository<User>().Insert(user);
        }

        public User Login(string Email, string Password)
        {
            var _user = db.user.Where(x => x.Email == Email && x.Password == Password && x.IsActive==true).SingleOrDefault();
            return _user;
        }

        public void ActiveUser(User user)
        {
            var userStatus = _unitofwork.GetRepository<User>().GetById(user.UserId);
            userStatus.IsActive = user.IsActive;


           _unitofwork.GetRepository<User>().Edit(userStatus);

        }

        public void UpdateUserProfile(User user)
        {
            var profileData = _unitofwork.GetRepository<User>().GetById(user.UserId);
            profileData.FirstName = user.FirstName;
            profileData.LastName = user.LastName;
            profileData.MobileNumber = user.MobileNumber;
            profileData.DOB = user.DOB;
            profileData.Gender = user.Gender;
            profileData.Address = user.Address;
            _unitofwork.GetRepository<User>().Edit(profileData);
        }
    }
    
}

