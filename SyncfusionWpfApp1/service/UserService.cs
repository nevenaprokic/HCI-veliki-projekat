﻿using SyncfusionWpfApp1.Model;
using SyncfusionWpfApp1.repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncfusionWpfApp1.service
{
    public class UserService
    {
        public UserService()
        {
        }
        public UserType logIn(string userName, string password)
        {
            IEnumerable<User> user = from u in MainRepository.Users
                                      where u.Email == userName && u.Password == password
                                        select u;
            if (user.Count() == 0)
                return UserType.NO_TYPE;
            return user.ElementAt(0).Type;
  

        }

        public static User findByEmail(string email)
        {
            IEnumerable<User> users = from user in MainRepository.Users
                                      where user.Email == email
                                      select user;
            if(users.Count() > 0)
            {
                return users.ElementAt(0);
            }
            return null;
        }
    }
}
