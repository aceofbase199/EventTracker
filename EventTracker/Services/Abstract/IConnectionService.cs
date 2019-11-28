using RestSharp;

namespace EventTracker.Services.Abstract
{
  public interface IConnectionService
  {
    IRestResponse Connect();

    IRestResponse Post<T>(T body);
  }
}