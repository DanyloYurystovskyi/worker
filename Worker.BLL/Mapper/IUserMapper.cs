using System;
using System.Collections.Generic;
using System.Text;
using Worker.BLL.DTOs.Account;
using Worker.DAL.Entities;

namespace Worker.BLL.Mapper
{
    public interface IUserMapper
    {
        User GetUser(UserRegisterDTO model);
    }
}
