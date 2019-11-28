using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventTracker.JsonServer;
using EventTracker.Services.Abstract;
using RestSharp;

namespace EventTracker.Services
{
  public class ConnectionService: IConnectionService
  {
    private const string JsonServerConnectionString = "https://my-json-server.typicode.com/aceofbase199/demo/db";
    private readonly ConnectionContext _context;

    public ConnectionService()
    {
      _context = new ConnectionContext(new JsonServerConnection(), JsonServerConnectionString);
    }

    public IRestResponse Connect()
    {
      return _context.Connect();
    }

    public IRestResponse Post<T>(T body)
    {
      return _context.PostMethod(body);
    }
  }
}
