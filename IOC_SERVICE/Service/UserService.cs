using IOC_SERVICE.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IOC_REPOSITORY.IRepository;

using AutoMapper;
using IOC.SERVICE.Data;
using IOC_DATA.Core;
using System.Collections;

namespace IOC_SERVICE.Service
{
    public class UserService : IUserService
    {
        IUserRepository userRepository;

        public UserService(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        public void ActiveUser(UserModel usermodel)
        {
            var UserStatus = userRepository.GetById(usermodel.UserId);
            UserStatus.IsActive = usermodel.IsActive;
            Mapper.Initialize(a => { a.CreateMap<UserModel, User>(); });
            var user = Mapper.Map<User>(UserStatus);

            userRepository.ActiveUser(user);
        }

        public void Delete(UserModel userModel)
        {

        }

      

        public void Edit(UserModel userModel)
        {
            Mapper.Initialize(map => { map.CreateMap<UserModel, User>(); });
            var profileData = Mapper.Map<User>(userModel);
            userRepository.Edit(profileData);
        }

        public bool EmailExist(string Email)
        {
          return userRepository.EmailExist(Email);
           
            
        }

        public IEnumerable<UserModel> GetAll()
        {
            var user = userRepository.GetAll();
            Mapper.Initialize(map => { map.CreateMap<User,  UserModel >(); });
            var userData = Mapper.Map<IEnumerable<User>, IEnumerable<UserModel>>(user);

            return userData;
        }


        public UserModel GetById(int id)
        {
            var user = userRepository.GetById(id);
            Mapper.Initialize(cfg => { cfg.CreateMap<User, UserModel>(); });

            var userModel = Mapper.Map<UserModel>(user);
            

            return userModel;
        }

        public void Insert(UserModel userModel)
        {
            

            Mapper.Initialize(cfg => { cfg.CreateMap<UserModel, User>(); });

            var user = Mapper.Map<User>(userModel);
            user.CreatedDate = DateTime.Now;
            user.LastUpdatedDate = null;
            user.Role = "User";
            //User user = new User();

            userRepository.Insert(user);
        }

        public UserModel Login(string Email, string Password)
        {
            var result= userRepository.Login(Email, Password);
            if(result!=null)
            {
                Mapper.Initialize(cfg => { cfg.CreateMap<User,UserModel>(); });

                var user = Mapper.Map<UserModel>(result);
                return user;
            }
            return null;
            
        }

        public void UpdateUserProfile(UserModel usermodel)
        {
            var profileData = userRepository.GetById(usermodel.UserId);
            profileData.FirstName = usermodel.FirstName;
            profileData.LastName = usermodel.LastName;
            profileData.MobileNumber = usermodel.MobileNumber;
            profileData.DOB = usermodel.DOB;
            profileData.Gender = usermodel.Gender;
            profileData.Address = usermodel.Address;
            Mapper.Initialize(a => { a.CreateMap<UserModel, User>(); });
            var user = Mapper.Map<User>(profileData);

            userRepository.UpdateUserProfile(user);
        }
    }
}
