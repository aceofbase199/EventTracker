using System;
using System.Collections.Generic;
using EventTracker.Entities;
using EventTracker.Models;

namespace EventTracker.Services.Abstract
{
  public interface IUserService
  {
    List<User> GetUserList();
    bool IsValidUser(UserDTO user);
    List<User> SaveUser(UserDTO userDto);
  }
}