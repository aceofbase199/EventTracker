using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventTracker.JsonServer
{
  public interface IJsonServerApi
  {
    IRestResponse GetMethod(string connectionString);
    IRestResponse PostMethod<T>(string connectionString, T body);
  }
}