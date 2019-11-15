using System.Collections.Generic;
using System.Threading.Tasks;
using EventTracker.Models;

namespace EventTracker.JsonServer
{
  public interface IConnectionStrategy
  {
    List<User> Connect(string connectionString);
  }
}