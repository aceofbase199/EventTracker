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
    private readonly string _salt;
    public UserService(IConnectionService connectionService)
    {
      _salt = SaltUtil.Create();
      _connectionService = connectionService;
    }

    public List<User> GetUserList()
    {
      var response = _connectionService.Get("users");
      var users = DeserializationUtil.DeserializeRestResponse<List<User>>(response);

      return users;
    }

    public User SaveUser(UserDTO userDto)
    {
      // add AutoMapper
      var user = new User
      {
        Password = HashUtil.Create(userDto.Password, _salt),
        UserId = userDto.UserId,
        UserName = userDto.UserName
      };

      var response = _connectionService.Post("users", user);

      return response.IsSuccessful ? user : null;
    }

    public bool IsValidUser(UserDTO user)
    {
      var users = GetUserList();
      var password = HashUtil.Create(user.Password, _salt);
      var existingUser = users.FirstOrDefault(x => x.UserName == user.UserName && x.Password == password);

      return existingUser != null;
    }
  }
}