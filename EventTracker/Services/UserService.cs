using System.Collections.Generic;
using System.Linq;
using EventTracker.Entities;
using EventTracker.Models;
using EventTracker.Services.Abstract;
using EventTracker.Utils;

namespace EventTracker.Services
{
  public class UserService : IUserService
  {
    private readonly IConnectionService _connectionService;
    public UserService(IConnectionService connectionService)
    {
      _connectionService = connectionService;
    }

    public List<User> GetUserList()
    {
      var response = _connectionService.Connect();
      var users = DeserializationUtil.DeserializeRestResponse<Models.UserList>(response).Users;

      return users;
    }

    public List<User> SaveUser(UserDTO userDto)
    {
      var users = GetUserList();
      // add AutoMapper
      var user = new User
      {
        Password = userDto.Password,
        UserId = userDto.UserId,
        UserName = userDto.UserName
      };

      users.Add(user);
      var response = _connectionService.Post(users);

      return users;
    }

    public bool IsValidUser(UserDTO user)
    {
      var users = GetUserList();
      var existingUser = users.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);

      return existingUser != null;
    }
  }
}