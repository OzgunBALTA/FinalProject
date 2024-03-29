﻿using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public List<OperationClaim> GetClaimsByEmail(string email)
        {
            User user = GetUserByMail(email);
            List<OperationClaim> claims = GetClaims(user);
            return claims;
        }

        public User GetUserByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public List<UserDetailsDto> GetUserDetailsByEmail(string email)
        {
            User user = GetUserByMail(email);
            List<UserDetailsDto> userDetailsDto = _userDal.userDetailsDto(user);
            return userDetailsDto;
        }
    }
}
