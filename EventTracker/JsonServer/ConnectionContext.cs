using System.Collections.Generic;
using System.Threading.Tasks;
using EventTracker.Models;

namespace EventTracker.JsonServer
{
  public class ConnectionContext
  {
    private readonly string connectionString;
    private readonly IConnectionStrategy _connectionStrategy;

    public ConnectionContext(IConnectionStrategy connectionStrategy, string connectionString)
    {
      this._connectionStrategy = connectionStrategy;
      this.connectionString = connectionString;
    }

    public List<User> Connect()
    {
      return _connectionStrategy.Connect(connectionString);
    }
  }
}