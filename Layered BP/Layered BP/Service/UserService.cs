using Layered_BP;
using Layered_BP.UserModel;
using Layered_BP.userrepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Layered_BP.Service
{
    class UserService
    {
        private readonly UserRepository _repository;
        public List<User> Users;

        public UserService()
        {
            _repository = new UserRepository();
            Users = _repository.GetAll();
        }

        public User FindUser(string name)
        {
            foreach (User u in Users)
            {
                if (u.UserName == name && u.UserName != "")
                    return u;
            }
            return null;
        }

        public void AddCustomer(User user)
        {
            Users.Add(user);
            _repository.SaveAll(Users);
        }

        public void UpdateMembership(User user, float amountSpent)
        {
            user.TotalSpent += amountSpent;
            if (user.TotalSpent >= 15000)
                user.Membership = "Gold";
            else if (user.TotalSpent >= 8000)
                user.Membership = "Silver";
            _repository.SaveAll(Users);
        }

        public void SaveAll()
        {
            _repository.SaveAll(Users);
        }

        public List<User> GetAllUsers()
        {
            return Users;
        }
    }
}
