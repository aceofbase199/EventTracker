using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventTracker.Configuration;
using EventTracker.JsonServer;
using EventTracker.Services.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RestSharp;

namespace EventTracker.Services
{
  public class ConnectionService: IConnectionService
  {
    private readonly AppSettings _appSettings;
    private readonly IJsonServerApi _jsonServerApi;
    private readonly string _baseJsonServerUrl;

    public ConnectionService(IJsonServerApi jsonServerApi, IOptions<AppSettings> appSettingsAccessor)
    {
      _jsonServerApi = jsonServerApi;
      _appSettings = appSettingsAccessor.Value;
      _baseJsonServerUrl = _appSettings.JsonServerUrl;
    }

    public IRestResponse Get(string route)
    {
      var connectionString = _baseJsonServerUrl + route;

      return _jsonServerApi.GetMethod(connectionString);
    }

    public IRestResponse Post<T>(string route, T body)
    {
      var connectionString = _baseJsonServerUrl + route;

      return _jsonServerApi.PostMethod(connectionString, body);
    }
  }
}