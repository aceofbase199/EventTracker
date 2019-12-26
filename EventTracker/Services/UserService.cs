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
      _connectionService = connectionService;
    }
  }
}