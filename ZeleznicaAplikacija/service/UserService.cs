﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeleznicaAplikacija.model;
using ZeleznicaAplikacija.repo;

namespace ZeleznicaAplikacija.service
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
    }
}
