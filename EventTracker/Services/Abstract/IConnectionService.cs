using RestSharp;

namespace EventTracker.Services.Abstract
{
  public interface IConnectionService
  {
    IRestResponse Get(string route);

    IRestResponse Post<T>(string route, T body);
  }
}