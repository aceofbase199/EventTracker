using RestSharp;

namespace EventTracker.JsonServer
{
  public interface IConnectionStrategy
  {
    IRestResponse Connect(string connectionString);

    IRestResponse PostMethod<T>(string connectionString, T body);
  }
}