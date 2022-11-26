using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        List<OperationClaim> GetClaimsByEmail(string email);
        void Add(User user);
        User GetUserByMail(string email);
        List<UserDetailsDto> GetUserDetailsByEmail(string email);
    }
}
