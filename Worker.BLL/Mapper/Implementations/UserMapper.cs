using System;
using System.Collections.Generic;
using System.Text;
using Worker.BLL.DTOs.Account;
using Worker.DAL.Entities;

namespace Worker.BLL.Mapper.Implementations
{
    public class UserMapper : IUserMapper
    {
        public User GetUser(UserRegisterDTO model)
        {
            return new User
            {
                Email = model.Email,
                UserName = model.Email
            };
        }
    }
}
