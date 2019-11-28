using System.Collections.Generic;
using System.Threading.Tasks;
using EventTracker.Models;
using RestSharp;

namespace EventTracker.JsonServer
{
  public class ConnectionContext
  {
    private readonly string _connectionString;
    private readonly IConnectionStrategy _connectionStrategy;

    public ConnectionContext(IConnectionStrategy connectionStrategy, string connectionString)
    {
      this._connectionStrategy = connectionStrategy;
      this._connectionString = connectionString;
    }

    public IRestResponse Connect()
    {
      return _connectionStrategy.Connect(_connectionString);
    }

    public IRestResponse PostMethod<T>(T body)
    {
      return _connectionStrategy.PostMethod(_connectionString, body);
    }
  }
}